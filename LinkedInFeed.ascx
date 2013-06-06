<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="LinkedInFeed.ascx.cs" Inherits="SocialFeeds.LinkedInFeed" %>
<asp:ListView ID="LinkedIn_UpdateList" runat="server">
    <LayoutTemplate>
                    <ul><asp:PlaceHolder ID="itemPlaceholder" runat="server" /></ul>
    </LayoutTemplate>

    <ItemTemplate>
       <li> <%# Eval("TimeStamp") %></li>
        
    </ItemTemplate>
    <EmptyDataTemplate>
        <div>Sorry, no updates found.</div>
    </EmptyDataTemplate>
</asp:ListView>


            
       
