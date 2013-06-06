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
    public class GetTweets
    {
        // Need to handle caching - Twitter only allows 350 requests per day (check this)

        //  private readonly string _cacheKeyFormat = "SimpleTwitterContentFragment-un:{0}-sn:{1}-c:{2}";
        public List<Tweet> GetTweetList(string twitterUsername = "", string twitterPassword = "", string twitterScreenName = "" , string consumerKey="", string consumerSecret="", string oAuthToken="", string oAuthSecret="", int tweetCount = 1)
        {
            // string cacheKey = "SimpleTwitterContentFragment";
            //List<Tweet> tweets = CSCache.Get(cacheKey) as List<Tweet>;
            List<Tweet> tweets = null;

            if (tweets == null)
            {
                //lock (CSCache.GetCacheEntryLock(cacheKey))
                //  {
                   // tweets = CSCache.Get(cacheKey) as List<Tweet>;
                    if (tweets == null)
                    {
                        tweets = new List<Tweet>();
                            //int tweetCount = 2; //set this again in the parameters

                        TwitterAPI twitterAPI = new TwitterAPI(twitterUsername, twitterPassword, twitterScreenName, consumerKey, consumerSecret, oAuthToken, oAuthSecret, tweetCount);
                            try
                            {
                                tweets.AddRange(twitterAPI.GetUserTimeline(twitterScreenName, tweetCount));
                            }
                            catch (Exception ex)
                            {
                                throw new HttpUnhandledException();
                            }
                       // }
                     //   CSCache.Insert(cacheKey, tweets, (int)(2 * CSCache.MinuteFactor));
                    }
                //}
            }

            try
            {
                tweets.Sort((x, y) => (y.DateCreated.CompareTo(x.DateCreated)));
            }
            catch (Exception)
            {
                //error
            }

            return tweets;

        }
    }
}


