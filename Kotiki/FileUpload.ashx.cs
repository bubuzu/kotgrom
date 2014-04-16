using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;

namespace Kotiki
{
    /// <summary>
    /// File Upload httphandler to receive files and save them to the server.
    /// </summary>
    public class FileUpload : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            JavaScriptSerializer jsonSerializer  = new JavaScriptSerializer();

            const string path = "captured/orig";
            String filename = HttpContext.Current.Request.Headers["X-File-Name"];

            if (string.IsNullOrEmpty(filename) && HttpContext.Current.Request.Files.Count <= 0)
            {
                context.Response.Write(
                        jsonSerializer.Serialize(
                            new
                            {
                                success = false,
                                name = filename
                            }
                        )
                        );
            }
            else
            {
                string mapPath = HttpContext.Current.Server.MapPath(path);
                if (Directory.Exists(mapPath) == false)
                {
                    Directory.CreateDirectory(mapPath);
                }
                if (filename == null)
                {
                    //This work for IE
                    try
                    {
                        HttpPostedFile uploadedfile = context.Request.Files[0];
                        filename = Guid.NewGuid()+".jpg";

                        uploadedfile.SaveAs(mapPath + "\\" + filename);
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

                    }
                    catch (Exception ex)
                    {
                        context.Response.Write(
                        jsonSerializer.Serialize(
                            new
                            {
                                success = false,
                                name = filename,
                                error = ex.Message
                            }
                        )
                        );

                    }
                }
                else
                {
                    filename = Guid.NewGuid() + ".jpg";
                    //This work for Firefox and Chrome.
                    FileStream fileStream = new FileStream(mapPath + "\\" + filename, FileMode.OpenOrCreate);

                    try
                    {
                        Stream inputStream = HttpContext.Current.Request.InputStream;
                        inputStream.CopyTo(fileStream);
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

                    }
                    catch (Exception ex)
                    {
                        context.Response.Write(
                       jsonSerializer.Serialize(
                           new
                           {
                               success = false,
                               name = filename,
                               error = ex.Message
                           }
                       )
                       );
                    }
                    finally
                    {
                        fileStream.Close();
                    }

                }
            }

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

            var scaled = ScaleImage(orig, 470, 470);
            using (Graphics g = Graphics.FromImage(scaled))
            {
                string vmpath = HttpContext.Current.Server.MapPath("images");
                Image vm = Image.FromFile(vmpath + "\\kotavdom.png");

                g.DrawImage(vm, (scaled.Width / 2 + 50), (scaled.Height / 2 + 110));
            }
            scaled.Save(mapPath + "\\" + filename);
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

        private static Image ScaleImageMax(Image image, int maxWidth, int maxHeight)
        {
            var ratioX = (double)maxWidth / image.Width;
            var ratioY = (double)maxHeight / image.Height;
            var ratio = Math.Max(ratioX, ratioY);

            var newWidth = (int)(image.Width * ratio);
            var newHeight = (int)(image.Height * ratio);

            var newImage = new Bitmap(newWidth, newHeight);
            Graphics.FromImage(newImage).DrawImage(image, 0, 0, newWidth, newHeight);
            return newImage;
        }

        public bool IsReusable
        {
            get { return false; }
        }
    }
}