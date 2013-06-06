using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SocialFeeds
{
    public class Tweet
    {
        public long ID { get; set; }
        public string Text { get; set; }
        public string Source { get; set; }
        public DateTime DateCreated { get; set; }
        public string UserName { get; set; }
        public string UserScreenName { get; set; }
        public string UserAvatar { get; set; }
        public string ProfileImageUrl { get; set; }
        public string UserUrl
        {
            get { return string.Format("http://twitter.com/{0}/", UserScreenName); }
        }
    }
}