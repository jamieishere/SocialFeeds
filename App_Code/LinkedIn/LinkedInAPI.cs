using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Net;
using System.Text;
using System.Xml;
using System.Xml.Linq;
using System.Globalization;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.IO;

namespace SocialFeeds
{
    public class LinkedInAPI
    {
        private oAuthLinkedIn _oauth = new oAuthLinkedIn();
        private string _companyID { get; set; }

        public LinkedInAPI(string CompanyID = "", string APIKey = "", string SecretKey = "", string oAuthToken = "", string oAuthSecret = "", string oAuthVerificationCode = "")
        {
            _oauth.ConsumerKey = APIKey;
            _oauth.ConsumerSecret = SecretKey;
            _oauth.Token = oAuthToken;
            _oauth.TokenSecret = oAuthSecret;
            _oauth.Verifier = oAuthVerificationCode; //this is where it is set...
            _companyID = CompanyID;
            //http://developer.linkedin.com/reading-company-shares
        }

        private JObject ExecuteLinkedInRequest()
        {
            string response = _oauth.APIWebRequest("GET", string.Format("http://api.linkedin.com/v1/companies/{0}/updates?format=json", _companyID), null);
            JObject dynObj = (JObject)JsonConvert.DeserializeObject(response);
            return dynObj;
        }

        public List<LinkedIn_Update> GetCompanyUpdate()
        {
            List<LinkedIn_Update> liupdates = new List<LinkedIn_Update>();
            
            JObject jresponse = ExecuteLinkedInRequest();
            JArray root = (JArray)jresponse["values"];

            // LINQ - projection
            //http://www.codeproject.com/Articles/33769/Basics-of-LINQ-Lamda-Expressions#lambda
            liupdates = (from item in root
                         select new LinkedIn_Update
                                      {
                                          TimeStamp = (string)item["timestamp"],
                                      }).ToList();
            return liupdates;
        }
    }
}

