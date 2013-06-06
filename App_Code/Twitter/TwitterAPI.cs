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
using System.Security.Cryptography;

namespace SocialFeeds
{
    public class TwitterAPI
    {
        string Username { get; set; }
        string Password { get; set; }
        string Screenname { get; set; }
        string ConsumerKey { get; set; }
        string ConsumerSecret { get; set; }
        string oAuthToken { get; set; }
        string oAuthSecret { get; set; }
        int tweetCount { get; set; }

        public TwitterAPI(string username="", string password="", string screenname="", string consumerkey="", string consumersecret="", string oauthtoken="", string oauthsecret="", int tweetcount=0)
        {
            this.Username = username;
            this.Password = password;
            this.Screenname = screenname;
            this.ConsumerKey = consumerkey;
            this.ConsumerSecret = consumersecret;
            this.oAuthToken = oauthtoken;
            this.oAuthSecret = oauthsecret;
            this.tweetCount = tweetcount;
        }

        // This method works OK, but has no true oAuth authorisation, so the number of requests will be limited (no good on a high traffic production site)
        //private JArray ExecuteTwitterRequest(string url)
        //{
        //    HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
        //    ServicePointManager.Expect100Continue = false;
        //    request.Credentials = new NetworkCredential(this.Username, this.Password);
        //    //var response = (HttpWebResponse)request.GetResponse();
        //    WebResponse response = request.GetResponse();
        //    string responseData = new StreamReader(response.GetResponseStream()).ReadToEnd();
        //    JArray dynObj = (JArray)JsonConvert.DeserializeObject(responseData);

        //    return dynObj;
        //}

        private JArray ExecuteTwitterRequest()
        {
            var oauth_token = oAuthToken; // "756995389-OGEOwg5JSGMWInCsoKWAekmXFIhpvggRjMXF4f9f";
            var oauth_token_secret = oAuthSecret; // "8xs6NfQf5JLeQthvL2RQLb32HEiLrypM4DwDcZj0";
            var oauth_consumer_key = ConsumerKey; // "F4O7XhYTiBF2s2oXKVZMA";
            var oauth_consumer_secret = ConsumerSecret;  //"iHio0tuJei2pz7GVehSWziCkOtm32MywPpO3sr8dqU";
            var screen_name = Screenname; // "JamieGriffiths8";
            var count = tweetCount; // "2";

            // oauth implementation details
            var oauth_version = "1.0";
            var oauth_signature_method = "HMAC-SHA1";

            // unique request details
            var oauth_nonce = Convert.ToBase64String(
                new ASCIIEncoding().GetBytes(DateTime.Now.Ticks.ToString()));
            var timeSpan = DateTime.UtcNow
                - new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc);
            var oauth_timestamp = Convert.ToInt64(timeSpan.TotalSeconds).ToString();

            // message api details
            var status = "Updating status via REST API if this works";
            var resource_url = "https://api.twitter.com/1.1/statuses/user_timeline.json";

            // create oauth signature
            var baseFormat = "count={7}&oauth_consumer_key={0}&oauth_nonce={1}&oauth_signature_method={2}" +
                            "&oauth_timestamp={3}&oauth_token={4}&oauth_version={5}&screen_name={6}";

            var baseString = string.Format(baseFormat,
                                        oauth_consumer_key,
                                        oauth_nonce,
                                        oauth_signature_method,
                                        oauth_timestamp,
                                        oauth_token,
                                        oauth_version,
                                         Uri.EscapeDataString(screen_name),
                                          Uri.EscapeDataString(count.ToString())
                                        );

            baseString = string.Concat("GET&", Uri.EscapeDataString(resource_url), "&", Uri.EscapeDataString(baseString));

            var compositeKey = string.Concat(Uri.EscapeDataString(oauth_consumer_secret),
                                    "&", Uri.EscapeDataString(oauth_token_secret));

            string oauth_signature;
            using (HMACSHA1 hasher = new HMACSHA1(ASCIIEncoding.ASCII.GetBytes(compositeKey)))
            {
                oauth_signature = Convert.ToBase64String(
                    hasher.ComputeHash(ASCIIEncoding.ASCII.GetBytes(baseString)));
            }

            // create the request header
            var headerFormat = "OAuth oauth_nonce=\"{0}\", oauth_signature_method=\"{1}\", " +
                               "oauth_timestamp=\"{2}\", oauth_consumer_key=\"{3}\", " +
                               "oauth_token=\"{4}\", oauth_signature=\"{5}\", " +
                               "oauth_version=\"{6}\"";

            var authHeader = string.Format(headerFormat,
                                    Uri.EscapeDataString(oauth_nonce),
                                    Uri.EscapeDataString(oauth_signature_method),
                                    Uri.EscapeDataString(oauth_timestamp),
                                    Uri.EscapeDataString(oauth_consumer_key),
                                    Uri.EscapeDataString(oauth_token),
                                    Uri.EscapeDataString(oauth_signature),
                                    Uri.EscapeDataString(oauth_version)
                            );


            // make the request

            ServicePointManager.Expect100Continue = false;

            var postBody = string.Format("screen_name={0}&count={1}", Uri.EscapeDataString(screen_name), Uri.EscapeDataString(count.ToString()));
            resource_url += "?" + postBody;
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(resource_url);
            request.Headers.Add("Authorization", authHeader);
            request.Method = "GET";
            request.ContentType = "application/x-www-form-urlencoded";

            //HttpWebRequest req = (HttpWebRequest)WebRequest.Create(url);
            //ServicePointManager.Expect100Continue = false;
            //req.Credentials = new NetworkCredential(this.Username, this.Password);
            //var response = (HttpWebResponse)req.GetResponse();
            WebResponse response = request.GetResponse();
            string responseData = new StreamReader(response.GetResponseStream()).ReadToEnd();
            JArray dynObj = (JArray)JsonConvert.DeserializeObject(responseData);

            return dynObj;
        }


        public void PostTweet(string tweet)
        {
            // Create a webclient with the twitter account credentials, which will be used to set the HTTP header for basic authentication
            WebClient client = new WebClient { Credentials = new NetworkCredential { UserName = this.Username, Password = this.Password } };

            // Don't wait to receive a 100 Continue HTTP response from the server before sending out the message body
            ServicePointManager.Expect100Continue = false;

            // Construct the message body
            byte[] messageBody = Encoding.ASCII.GetBytes("status=" + tweet);

            // Send the HTTP headers and message body (a.k.a. Post the data)
            client.UploadData("http://twitter.com/statuses/update.xml", messageBody);
        }


        private static DateTime ParseTwitterDate(string dateString)
        {
            return DateTime.ParseExact(dateString, "ddd MMM dd HH:mm:ss zzz yyyy", CultureInfo.InvariantCulture);
        }

        public List<Tweet> GetUserTimeline(string userScreenName, int numberOfTweets)
        {
            List<Tweet> tweets = new List<Tweet>();
            //string url = null;
            // only needed for non oAuth method
            //string _twitterOtherUserTimelineUrl = "http://api.twitter.com/1/statuses/user_timeline.json?include_entities=true&include_rts=true&screen_name={0}&count={1}";

            if (!string.IsNullOrEmpty(userScreenName))
            {
                //url = String.Format(_twitterOtherUserTimelineUrl, userScreenName, numberOfTweets);
                // Make the request to the Twitter API service
                //JArray jresponse = ExecuteTwitterRequest(url);
                JArray jresponse = ExecuteTwitterRequest();

                tweets = (from item in jresponse
                          select new Tweet
                                       {
                                           ID = (long)item["id"],
                                           Text = (string)item["text"],
                                           Source = (string)item["text"],
                                           DateCreated = ParseTwitterDate((string)item["created_at"]),
                                           UserName = (string)item["user"]["name"],
                                           UserScreenName = (string)item["user"]["screen_name"],
                                           UserAvatar = (string)item["user"]["profile_image_url"],
                                           ProfileImageUrl = (string)item["user"]["profile_image_url"],
                                       }).ToList();
            }
            return tweets;
        }
    }
}

