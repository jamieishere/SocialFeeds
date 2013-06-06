using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SocialFeeds
{
    public partial class LinkedInFeed : System.Web.UI.UserControl
    {
        public string CompanyID { get; set; }
        public string APIKey { get; set; }
        public string SecretKey { get; set; }
        public string oAuthToken { get; set; }
        public string oAuthSecret { get; set; }
        public string oAuthVerificationCode { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                List<LinkedIn_Update> liupdates = new List<LinkedIn_Update>();
                GetLinkedInUpdates getLIUpdates = new GetLinkedInUpdates();
                liupdates = getLIUpdates.GetLinkedIn_UpdateList(CompanyID, APIKey, SecretKey, oAuthToken, oAuthSecret, oAuthVerificationCode);
                LinkedIn_UpdateList.DataSource = liupdates;
                LinkedIn_UpdateList.DataBind();
            }
        }
    }
}