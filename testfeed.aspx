<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="testfeed.aspx.cs" Inherits="SocialFeeds.testfeed" %>
<%@ Register src="~/TwitterFeed.ascx" TagName="TwitterFeed" TagPrefix="SocialFeed" %>
<%@ Register src="~/LinkedInFeed.ascx" TagName="LinkedInFeed" TagPrefix="LinkedInFeed" %>
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style>
        #example1 {
            -moz-border-radius: 5px;
            -webkit-border-radius: 5px;
            border-radius: 5px;
            -moz-box-shadow: 2px 2px 2px #888;
            -webkit-box-shadow: 2px 2px 2px #888;
            box-shadow: 2px 2px 2px #888;
            width:400px;
}
    </style>

    <link rel="stylesheet" type="text/css" href="http://twitter.github.io/bootstrap/1.4.0/bootstrap.min.css">
</head>
<body>
    <form id="form1" runat="server">
    <div id="example1">
        <LinkedInFeed:LinkedInFeed id="LinkedInFeed" CompanyID="9523" APIKey="70g7x04p4r0b" SecretKey="phnCQc8wtjYIaQ6J" oAuthToken="586a4ee8-acc7-471a-bab8-1aaa6a66cac8" oAuthSecret="fbd5891e-e658-4a48-98bb-25f01ca6554d" oAuthVerificationCode="89698" runat="server"/> 
        <%--<SocialFeed:TwitterFeed id="TwitterFeed" UserName="JamieGriffiths8" Password="b0ilerr00m" Screenname="JamieGriffiths8" ConsumerKey="F4O7XhYTiBF2s2oXKVZMA" ConsumerSecret="iHio0tuJei2pz7GVehSWziCkOtm32MywPpO3sr8dqU" oAuthToken="756995389-OGEOwg5JSGMWInCsoKWAekmXFIhpvggRjMXF4f9f" oAuthSecret="8xs6NfQf5JLeQthvL2RQLb32HEiLrypM4DwDcZj0" tweetCount="5" runat="server"/>--%> 
    </div>
    </form>
</body>
</html>
