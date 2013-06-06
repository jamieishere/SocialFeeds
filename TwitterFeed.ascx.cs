using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SocialFeeds
{
    public partial class TwitterFeed : System.Web.UI.UserControl
    {
        public string Username{get;set;}
        public string Screenname { get; set; }
        public string Password { get; set; }
        public string ConsumerKey { get; set; }
        public string ConsumerSecret { get; set; }
        public string oAuthToken { get; set; }
        public string oAuthSecret { get; set; }
        public int tweetCount { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                List<Tweet> tweets = new List<Tweet>();
                GetTweets getTweets = new GetTweets();
                tweets = getTweets.GetTweetList(Username, Password, Screenname,ConsumerKey, ConsumerSecret, oAuthToken, oAuthSecret, tweetCount);
                TweetList.DataSource = tweets;
                TweetList.DataBind();
            }
        }
    }
}