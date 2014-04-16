using System;
using System.Collections.Generic;
using System.Configuration;
using System.Drawing;
using System.Dynamic;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Script.Serialization;
using Facebook;

namespace Kotiki
{
    /// <summary>
    /// Summary description for ajax
    /// </summary>
    public class ajax : IHttpHandler
    {
        public void ProcessRequest(HttpContext context)
        {
            JavaScriptSerializer jsonSerializer = new JavaScriptSerializer();
            switch (context.Request.Params["m"])
            {
                case "getpage":
                    {
                        using (var db = new KotDataContext())
                        {
                            var data = db.spGetCats(Convert.ToInt32(context.Request.Params["page"]),
                                Convert.ToInt32(context.Request.Params["uid"]), context.Request.Params["qtype"]).ToArray();
                            context.Response.Write(jsonSerializer.Serialize(data));
                        }
                        break;
                    }

                case "saveadvert":
                    {
                        using (var db = new KotDataContext())
                        {
                            try
                            {
                                db.spAddAdvert(Convert.ToInt32(context.Request.Params["uid"]),
                                                      Guid.Parse(context.Request.Params["sessid"]),
                                                      context.Request.Params["phone"],
                                                      context.Request.Params["email"],
                                                      context.Request.Params["city"],
                                                      context.Request.Params["descr"],
                                                      context.Request.Params["photos"]);
                                context.Response.Write(jsonSerializer.Serialize(new { result = true }));
                            }
                            catch (Exception)
                            {
                                context.Response.Write(jsonSerializer.Serialize(new { result = false }));
                            }
                            
                        }
                        break;
                    }
                case "updateadvert":
                    {
                        using (var db = new KotDataContext())
                        {
                            try
                            {
                                db.spUpdateAdvert(Convert.ToInt32(context.Request.Params["aid"]),
                                                      Convert.ToInt32(context.Request.Params["uid"]),
                                                      Guid.Parse(context.Request.Params["sessid"]),
                                                      context.Request.Params["phone"],
                                                      context.Request.Params["email"],
                                                      context.Request.Params["city"],
                                                      context.Request.Params["descr"],
                                                      context.Request.Params["photos"],
                                                      Convert.ToBoolean(context.Request.Params["closed"]),
                                                      Convert.ToBoolean(context.Request.Params["deleted"]));
                                context.Response.Write(jsonSerializer.Serialize(new { result = true }));
                            }
                            catch (Exception)
                            {
                                context.Response.Write(jsonSerializer.Serialize(new { result = false }));
                            }

                        }
                        break;
                    }

                case "showadvert":
                    {
                        using (var db = new KotDataContext())
                        {
                            var data = db.spGetCat2(Convert.ToInt32(context.Request.Params["advid"])).First();
                            context.Response.Write(jsonSerializer.Serialize(data));
                        }
                        break;
                    }
                case "loadfromweb":
                    {
                        const string path = "captured/orig";
                        string mapPath = HttpContext.Current.Server.MapPath(path);
                        if (Directory.Exists(mapPath) == false)
                        {
                            Directory.CreateDirectory(mapPath);
                        }

                        var filename = Guid.NewGuid() + ".jpg";
                        FileStream fileStream = new FileStream(mapPath + "\\" + filename, FileMode.OpenOrCreate);

                        var request = WebRequest.Create(context.Request.Params["fileurl"]);

                        using (var response = request.GetResponse())
                        using (var stream = response.GetResponseStream())
                        {
                            stream.CopyTo(fileStream);
                        }

                        fileStream.Close();

                        CreateSizesFiles(mapPath + "\\" + filename, filename);

                        context.Response.Write(
                        jsonSerializer.Serialize(
                            new
                            {
                                success = true,
                                name = filename
                            }
                        )
                        );
                        break;
                    }

                case "UploadToVK":
                    {
                        context.Response.Write(UploadImageToVK(context.Request.Params["uploadurl"],
                                                               context.Request.Params["imageid"],
                                                               context));
                        break;
                    }
            }
        }

        string UploadImageToVK(string path, string imageid, HttpContext context)
        {
            try
            {
                string boundary = "----------" + DateTime.Now.Ticks.ToString("x");

                HttpWebRequest myReq = (HttpWebRequest)HttpWebRequest.Create(path);
                myReq.Method = "POST";

                myReq.ContentType = String.Format("multipart/form-data; boundary={0}", boundary);
                Stream myReqStream = myReq.GetRequestStream();
                string header = String.Format("\r\n--{0}\r\nContent-Disposition: form-data; name=\"{1}\"\r\n\r\n", boundary, "format");
                byte[] h = System.Text.Encoding.UTF8.GetBytes(header);
                myReqStream.Write(h, 0, h.Length);
                byte[] b = System.Text.Encoding.UTF8.GetBytes("xml");
                myReqStream.Write(b, 0, b.Length);

                header = String.Format("\r\n--{0}\r\nContent-Disposition: form-data; name=\"{1}\"; filename=\"{2}\"\r\nContent-Type: {3}\r\n\r\n", boundary, "photo", "image.jpg", "image/jpeg");
                h = System.Text.Encoding.UTF8.GetBytes(header);
                myReqStream.Write(h, 0, h.Length);

                //System.Configuration.ConfigurationManager.AppSettings["appid"]
                //using (BinaryReader myReader = new BinaryReader(new StreamReader(context.Server.MapPath("Genegated/" + imageid)).BaseStream))
                using (BinaryReader myReader = new BinaryReader(new StreamReader(context.Server.MapPath(imageid)).BaseStream))
                {
                    byte[] buffer = myReader.ReadBytes(2048);
                    while (buffer.Length > 0)
                    {
                        myReq.GetRequestStream().Write(buffer, 0, buffer.Length);
                        buffer = myReader.ReadBytes(2048);
                    }
                }

                myReqStream = myReq.GetRequestStream();
                string footer = String.Format("\r\n--{0}--\r\n", boundary);
                byte[] f = System.Text.Encoding.UTF8.GetBytes(footer);
                myReqStream.Write(f, 0, f.Length);

                HttpWebResponse myResp = (HttpWebResponse)myReq.GetResponse();
                StreamReader myStream = new StreamReader(myResp.GetResponseStream(), System.Text.Encoding.UTF8);

                return myStream.ReadToEnd();
            }
            catch (Exception ex)
            {
                return ex.ToString();
            }


        }

        private bool PostFbToWall(string sessionId, string pic, string link)
        {
            using (KotDataContext ctx = new KotDataContext())
            {
                var token = ctx.Users.FirstOrDefault(x => x.sessid.ToString() == sessionId);

                if (token != null)
                {
                    try
                    {
                        var fb = new FacebookClient(token.token);
                        var args = new Dictionary<string, object>();
                        args["caption"] = "Битва цен";
                        args["description"] = "Я куплю дешево в М.Видео";

                        string attachementPath = HttpContext.Current.Server.MapPath(@"prizes/share/" + pic.Replace(@"http://m-bitva.ru/prizes/share/", ""));
                        dynamic parameters = new ExpandoObject();
                        parameters.message = args["description"] + " Битва цен: " + link;
                        parameters.source = new FacebookMediaObject
                        {
                            ContentType = "image/jpeg",
                            FileName = attachementPath
                        }.SetValue(File.ReadAllBytes(attachementPath));

                        fb.Post("me/photos", parameters);
                        return true;
                    }
                    catch (Exception ex)
                    {
                        return false;
                    }

                }
            }
            return true;
        }

        private void CreateSizesFiles(string fullfilename, string filename)
        {
            var orig = Image.FromFile(fullfilename);
            //small
            string mapPath = HttpContext.Current.Server.MapPath("captured/small");
            if (!Directory.Exists(mapPath))
            {
                Directory.CreateDirectory(mapPath);
            }
            ScaleImage(orig, 120, 120).Save(mapPath + "\\" + filename);

            //medium
            mapPath = HttpContext.Current.Server.MapPath("captured/medium");
            if (!Directory.Exists(mapPath))
            {
                Directory.CreateDirectory(mapPath);
            }
            ScaleImage(orig, 200, 200).Save(mapPath + "\\" + filename);

            //big
            mapPath = HttpContext.Current.Server.MapPath("captured/big");
            if (!Directory.Exists(mapPath))
            {
                Directory.CreateDirectory(mapPath);
            }
            ScaleImage(orig, 470, 470).Save(mapPath + "\\" + filename);
        }

        private static Image ScaleImage(Image image, int maxWidth, int maxHeight)
        {
            var ratioX = (double)maxWidth / image.Width;
            var ratioY = (double)maxHeight / image.Height;
            var ratio = Math.Min(ratioX, ratioY);

            var newWidth = (int)(image.Width * ratio);
            var newHeight = (int)(image.Height * ratio);

            var newImage = new Bitmap(newWidth, newHeight);
            Graphics.FromImage(newImage).DrawImage(image, 0, 0, newWidth, newHeight);
            return newImage;
        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}