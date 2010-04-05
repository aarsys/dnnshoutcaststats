<%@ Control Language="C#" Inherits="Aarsys.ShoutcastStats.View_ShoutcastStats"
    AutoEventWireup="true" CodeBehind="View_ShoutcastStats.ascx.cs" %>
    <div>
        <h1>
            Shoutcast Server Details</h1>
        <p>
            Below are some&nbsp; fields that contains a typical shoutcast xml file. Don&#39;t
            forget to enter you stream url and don&#39;t forget to change your password at the
            query string in order to be authenticated. This is still a early Alpha, and it could include security issues!  It have not to be used into a production environment!</p>
        <p>
            <asp:Label ID="lbl_CurrentListeners" runat="server" Text="Example : http://DOMAIN:PORT/admin.cgi?mode=viewxml&pass=YOURADMINPASS"></asp:Label>
        </p>
        <p>
            <asp:Label ID="lbl_MaxListeners" runat="server"></asp:Label>
        </p>
        <p>
            <asp:Label ID="lbl_SongTitle" runat="server"></asp:Label>
        </p>
        <p>
            <asp:Label ID="lbl_AIM" runat="server"></asp:Label>
        </p>
        <p>
            <asp:Label ID="lbl_Bitrate" runat="server"></asp:Label>
        </p>
        <p>
            <asp:Label ID="lbl_ViewXml" runat="server"></asp:Label>
        </p>
        <asp:Panel ID="Panel1" runat="server">
            <asp:Label ID="lbl_Listeners" runat="server"></asp:Label>
        </asp:Panel>
        <br />
        <asp:Panel ID="Panel2" runat="server">
            <asp:Label ID="lbl_SongHistory" runat="server"></asp:Label>
        </asp:Panel>
    </div>

