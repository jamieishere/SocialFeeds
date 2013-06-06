<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="TwitterFeed.ascx.cs" Inherits="SocialFeeds.TwitterFeed" %>
<asp:ListView ID="TweetList" runat="server">
    <LayoutTemplate>
        <div class="root timeline ltr customisable-border twitter-timeline var-narrow not-touch twitter-timeline-rendered var-narrow" dir="ltr" data-profile-id="40856031" data-dt-now="now" data-dt-s="s" data-dt-m="m" data-dt-h="h" data-dt-second="second" data-dt-seconds="seconds" data-dt-minute="minute" data-dt-minutes="minutes" data-dt-hour="hour" data-dt-hours="hours" data-dt-months="Jan|Feb|Mar|Apr|May|Jun|Jul|Aug|Sep|Oct|Nov|Dec" data-dt-abbr="%{number}%{symbol}" data-dt-short="%{day} %{month}" data-dt-long="%{day} %{month} %{year}" id="twitter-widget-0" lang="en" data-twitter-event-id="0">
            <div class="timeline-header customisable-border">
                <h1 class="summary">
                    <a class="customisable-highlight" href="https://twitter.com/PeopleMgt" title="Tweets from People Management">Tweets</a>
                </h1>
                <iframe allowtransparency="true" frameborder="0" scrolling="no" src="http://platform.twitter.com/widgets/follow_button.1368146021.html#_=1369389012605&amp;align=right&amp;id=twitter-widget-1&amp;lang=en&amp;screen_name=PeopleMgt&amp;show_count=false&amp;show_screen_name=true&amp;size=m" class="twitter-follow-button twitter-follow-button" style="width: 133px; height: 20px;" title="Twitter Follow Button" data-twttr-rendered="true"></iframe>
            </div>
            <div role="alert" class="new-tweets-bar" aria-live="polite" aria-atomic="false" aria-relevant="additions">
                <button><i class="ic-top"></i>New Tweets</button>
            </div>
            <div class="stream" style="height: 525px;">
                <ol class="h-feed">
                    <asp:PlaceHolder ID="itemPlaceholder" runat="server" />
                </ol>
                <button class="load-more customisable">Load More</button>
                <p class="no-more-pane" role="alert">
                  There are no more Tweets in this stream.
                  <i class="ic-bird-flourish"></i>
                </p>
              </div>
            <div class="timeline-footer">
              <a class="tweet-box-button web-intent" href="https://twitter.com/intent/tweet?screen_name=PeopleMgt">Tweet to @PeopleMgt</a>
            </div>
        </div>
    </LayoutTemplate>

    <ItemTemplate>
        <li class="tweet h-entry with-expansion customisable-border" data-tweet-id="337684363238051843">
                <a class="u-url permalink customisable-highlight" href="https://twitter.com/<%# Eval("UserName") %>/statuses/" data-datetime="<%# Eval("DateCreated") %>"><time pubdate="" class="dt-updated" datetime="<%# Eval("DateCreated") %>" title="Time posted: <%# Eval("DateCreated") %>" aria-label="Posted 18 hours ago">19<abbr title="hours">h</abbr></time></a>
                <div class="header h-card p-author">
                  <a class="u-url profile" href="https://twitter.com/<%# Eval("UserName") %>" aria-label="<%# Eval("UserName") %> (screen name: <%# Eval("UserScreenName") %>)">
                    <img class="u-photo avatar" alt="" src="<%# Eval("UserAvatar") %>" data-src-2x="<%# Eval("UserAvatar") %>">
                    <span class="full-name">
      
                      <span class="p-name customisable-highlight"> <%# Eval("UserScreenName") %> </span>
                    </span>
                    <span class="p-nickname" dir="ltr">@<b><%# Eval("UserName") %></b></span>
                  </a>
                </div>

                <div class="e-entry-content">
                    <p class="e-entry-title"><%# Eval("Source") %></p>
                    <%--<div class="retweet-credit">
                        <i class="ic-rt"></i>Retweeted by <a class="profile h-card" href="https://twitter.com/PeopleMgt" title="@PeopleMgt on Twitter">People Management</a>
                    </div>--%>
                </div>

                <div class="footer customisable-border">
                    <span class="stats-narrow">
                        <span class="stats">
                            <span class="stats-retweets">
                                <strong>1</strong> Retweet
                            </span>
                        </span>
                    </span>
    
                    <a class="expand customisable-highlight" href="https://twitter.com/lisaburton77/statuses/337588361558646784" data-toggled-text="Collapse"><b>Expand</b></a>

                    <ul class="tweet-actions">
                      <li><a href="https://twitter.com/intent/tweet?in_reply_to=337588361558646784" class="reply-action web-intent" title="Reply"><i class="ic-reply ic-mask"></i><b>Reply</b></a></li>
                      <li><a href="https://twitter.com/intent/retweet?tweet_id=337588361558646784" class="retweet-action web-intent" title="Retweet"><i class="ic-retweet ic-mask"></i><b>Retweet</b></a></li>
                      <li><a href="https://twitter.com/intent/favorite?tweet_id=337588361558646784" class="favorite-action web-intent" title="Favorite"><i class="ic-fav ic-mask"></i><b>Favorite</b></a></li>
                    </ul>
                    <span class="stats-wide"><b>· </b>
                        <span class="stats">
                            <span class="stats-retweets">
                                <strong>1</strong> Retweet
                            </span>
                        </span>
                    </span>
                </div>
            </li>
    </ItemTemplate>
    <EmptyDataTemplate>
        <div>Sorry, no Tweets found.</div>
    </EmptyDataTemplate>
</asp:ListView>


            
       
