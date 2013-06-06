using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Text;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;

namespace SocialFeeds
{
    public class GetLinkedInUpdates
    {
        // Need to handle caching - 5000 requests per month... is there a Tridion cache object I can use easily?
        //  private readonly string _cacheKeyFormat = "SimpleTwitterContentFragment-un:{0}-sn:{1}-c:{2}";
        public List<LinkedIn_Update> GetLinkedIn_UpdateList(string CompanyID="", string APIKey="", string SecretKey="", string oAuthToken="", string oAuthSecret="", string oAuthVerificationCode="")
        {
            // string cacheKey = "SimpleTwitterContentFragment";
            //List<Tweet> tweets = CSCache.Get(cacheKey) as List<Tweet>;
            List<LinkedIn_Update> liupdates = null;

            if (liupdates == null)
            {
                //lock (CSCache.GetCacheEntryLock(cacheKey))
                //  {
                   // tweets = CSCache.Get(cacheKey) as List<Tweet>;
                if (liupdates == null)
                    {
                        liupdates = new List<LinkedIn_Update>();
                            //int tweetCount = 2; //set this again in the parameters

                        LinkedInAPI linkedinAPI = new LinkedInAPI(CompanyID, APIKey, SecretKey, oAuthToken, oAuthSecret, oAuthVerificationCode);
                            try
                            {
                                liupdates.AddRange(linkedinAPI.GetCompanyUpdate());
                            }
                            catch (Exception ex)
                            {
                                //
                                throw new HttpUnhandledException();
                            }
                       // }
                     //   CSCache.Insert(cacheKey, tweets, (int)(2 * CSCache.MinuteFactor));
                    }
                //}
            }

            try
            {
                //liupdates.Sort((x, y) => (y.DateCreated.CompareTo(x.DateCreated)));
            }
            catch (Exception)
            {
                //error
            }

            return liupdates;

        }
    }
}


