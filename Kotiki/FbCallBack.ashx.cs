using System;
using System.Collections.Generic;
using System.Data.Linq;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Script.Serialization;
using System.Web.SessionState;

namespace Kotiki
{
    /// <summary>
    /// Summary description for FbCallBack
    /// </summary>
    public class FbCallBack : IHttpHandler, IRequiresSessionState
    {
        public void ProcessRequest(HttpContext context)
        {
            string error = "";
            spAddUserResult usr = null;

            int? refid = null;

            try
            {
                string callback = System.Configuration.ConfigurationManager.AppSettings["FbRedirectUri"];

                if (context.Request.Params["state"] != null)
                {
                    refid = Convert.ToInt32(context.Request.Params["state"]);
                    callback += "?state=" + refid;
                    callback = HttpUtility.UrlEncode(callback);
                }
                

                WebClient webClient = new WebClient();
                string requesturl = "https://graph.facebook.com/oauth/access_token?client_id=" +
                    System.Configuration.ConfigurationManager.AppSettings["FbAppId"] + "&client_secret=" +
                    System.Configuration.ConfigurationManager.AppSettings["FbAppSecret"] + "&code=" +
                    context.Request.Params["code"] + "&redirect_uri=" +
                    callback;

                var res = new StreamReader(webClient.OpenRead(requesturl)).ReadToEnd();
                string token = HttpUtility.ParseQueryString(res).Get("access_token");
                JavaScriptSerializer c = new JavaScriptSerializer();

                requesturl = "https://graph.facebook.com/me?access_token=" + token;

                var res2 = new StreamReader(webClient.OpenRead(requesturl)).ReadToEnd();
                dynamic response = c.DeserializeObject(res2);

                string name = response["name"];
                long uid = Convert.ToInt64(response["id"]);

                using (var dataContext = new KotDataContext())
                {
                    var all = dataContext.spAddUser(0, uid, name, token);

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