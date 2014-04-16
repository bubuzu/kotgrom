using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Kotiki
{
    public partial class Default : System.Web.UI.Page
    {
        public string VkAppId = System.Configuration.ConfigurationManager.AppSettings["VkAppId"];
        public string VkRedirectUri
        {
            get
            {
                return System.Configuration.ConfigurationManager.AppSettings["VkRedirectUri"];
            }
        }

        public string FbAppId = System.Configuration.ConfigurationManager.AppSettings["FbAppId"];
        public string FbRedirectUri
        {
            get
            {
                return System.Configuration.ConfigurationManager.AppSettings["FbRedirectUri"];
            }
        }

        public string CatsCount = "0";
        public User m_User;
        
        public string Uid
        {
            get
            {
                if (m_User == null)
                 {
                     return "undefined";
                 }
                return m_User.uid.ToString();
            }
        }

        public string Sessid
        {
            get
            {
                if (m_User == null)
                {
                    return "undefined";
                }
                return "'" + m_User.sessid.ToString() + "'";
            }
        }

        public string IsAdmin
        {
            get
            {
                if (m_User != null && m_User.admin != null)
                {
                    m_User.admin.ToString().ToLower();
                }
                return false.ToString().ToLower();
            }
        }

        public string Token
        {
            get
            {
                if (m_User == null)
                {
                    return "undefined";
                }
                return "'" + m_User.token + "'";
            }
        }

        public string UserId
        {
            get
            {
                if (m_User == null)
                {
                    return "undefined";
                }
                return (m_User.fbid == 0? m_User.vkid : m_User.fbid).ToString();
            }
        }

        public string SocialType
        {
            get
            {
                if (m_User == null)
                {
                    return "undefined";
                }
                if (m_User.fbid != 0)
                {
                    return "'fb'";
                }
                if (m_User.vkid != 0)
                    return "'vk'";

                return "undefined";
            }
        }

        public string Aid = "undefined";

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.Params.AllKeys.Contains("sessid"))
            {
                using (var db = new KotDataContext())
                {
                    m_User = db.spGetUser(Guid.Parse(Request.Params["sessid"]), Convert.ToInt32(Request.Params["uid"])).FirstOrDefault();
                }
            }

            if (Request.Params.AllKeys.Contains("aid"))
            {
                Aid = Request.Params["aid"];
            }
        }
    }
}