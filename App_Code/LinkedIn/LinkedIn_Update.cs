using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SocialFeeds
{
    public class LinkedIn_Update
    {
        public long ID { get; set; }
        public string TimeStamp { get; set; }
        public string UpdateType { get; set; }
        public string UpdateKey { get; set; }
        public string Company_ID { get; set; }
        public string CompanyName { get; set; }

        public string Job_ID { get; set; }
        public string Job_Name { get; set; }
        public string Job_Position { get; set; }
        public string Job_RequestURL { get; set; }
        public string Job_Description { get; set; }
        public string Job_LocationDescription { get; set; }
        public string Job_Action_Code { get; set; }

        public string Person_ID { get; set; }
        public string Person_FirstName { get; set; }
        public string Person_LastName{ get; set; }
        public string Person_Headline { get; set; }
        public string Person_PictureURL { get; set; }
        public string Person_A_ProfileRequest_URL { get; set; }
        public string Person_S_ProfileRequest_URL { get; set; }
        public string Person_Action_Code { get; set; }
        public string Person_OldPosition_Title { get; set; }
        public string Person_OldPosition_Company_Name { get; set; }
        public string Person_OldPosition_Company_ID { get; set; }
        public string Person_NewPosition_Title { get; set; }
        public string Person_NewPosition_Company_Name{ get; set; }
        public string Person_NewPosition_Company_ID { get; set; }
        public string Person_LocationDescription { get; set; }

        public string Product_Action_Code { get; set; }
        public string Product_Event_Code { get; set; }
        public string Product_Product_ID { get; set; }
        public string Product_Product_Name { get; set; }

        public string Status_ID { get; set; }
        public string Status_Timestamp { get; set; }
        public string Status_Visibility_Code { get; set; }
        public string Status_Comment { get; set; }
        public string Status_Content_SubmittedURL { get; set; }
        public string Status_Content_ShortenedURL { get; set; }
        public string Status_Content_Title { get; set; }
        public string Status_Content_Description { get; set; }
        public string Status_Content_ImageURL { get; set; }
        public string Status_Content_ThumbnailURL { get; set; }
        public string Status_Content_EyebrowURL { get; set; }
        public string Status_Source_SP_Name { get; set; }

    }
}