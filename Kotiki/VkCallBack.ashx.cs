using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Script.Serialization;
using System.Web.SessionState;

namespace Kotiki
{
    /// <summary>
    /// Summary description for VkCallBack1
    /// </summary>
    public class VkCallBack : IHttpHandler, IRequiresSessionState
    {
        public void ProcessRequest(HttpContext context)
        {
            string error = "";
            spAddUserResult usr = null;

            int? refid = null;

            try
            {
                string callback = System.Configuration.ConfigurationManager.AppSettings["VkRedirectUri"];

                if (context.Request.Params["state"] != null)
                {
                    refid = Convert.ToInt32(context.Request.Params["state"]);
                    callback += "?state=" + refid;
                    callback = HttpUtility.UrlEncode(callback);
                }

                WebClient webClient = new WebClient();
                string requesturl = "https://api.vk.com/oauth/token?client_id=" +
                    System.Configuration.ConfigurationManager.AppSettings["VkAppId"] + "&client_secret=" +
                    System.Configuration.ConfigurationManager.AppSettings["VkAppSecret"] + "&code=" +
                    context.Request.Params["code"] + "&redirect_uri=" +
                    callback;

                Stream stream = webClient.OpenRead(requesturl);
                StreamReader streamReader = new StreamReader(stream);
                string vktokenresponse = streamReader.ReadToEnd();

                JavaScriptSerializer c = new JavaScriptSerializer();
                dynamic resp = c.DeserializeObject(vktokenresponse);
                string token = resp["access_token"].ToString();
                int uid = (int)resp["user_id"];

                requesturl = "https://api.vk.com/method/users.get?uids=" + uid +
                             "&fields=uid,first_name,last_name&access_token=" + token;

                var res = new StreamReader(webClient.OpenRead(requesturl)).ReadToEnd();
                dynamic response = c.DeserializeObject(res);

                var name = response["response"][0]["first_name"] + " " + response["response"][0]["last_name"];

                using (var dataContext = new KotDataContext())
                {
                    var all = dataContext.spAddUser(uid, 0, name, token);

                    foreach (spAddUserResult o in all)
                    {
                        usr = o;
                    }
                }
            }
            catch (Exception ex)
            {
                error = ex.Message;
            }

            context.Response.Redirect("Default.aspx?sessid=" + usr.sessid + "&error=" + error + "&uid=" + usr.uid);
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