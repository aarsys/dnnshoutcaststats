<%@ Control Language="C#" Inherits="Aarsys.ShoutcastStats.View_ShoutcastStats"
    AutoEventWireup="true" CodeBehind="View_ShoutcastStats.ascx.cs" %>
<%@ Register Assembly="DotNetNuke.WebControls" Namespace="DotNetNuke.UI.WebControls"
    TagPrefix="DNN" %>

    <div class="scs_table">
        <!--<h1>
    
            Shoutcast Server Details</h1>
        <p>
            Below are some&nbsp; fields that contains a typical shoutcast xml file. Don&#39;t
            forget to enter you stream url and don&#39;t forget to change your password at the
            query string in order to be authenticated. This is still a early Alpha, and it could include security issues!  It have not to be used into a production environment!
            </p> -->
            <p>
            <asp:Label ID="lbl_Status" CssClass="scs_label" runat="server"></asp:Label>
            <asp:Label ID="lbl_Station" CssClass="scs_label" runat="server"></asp:Label><br />
            <asp:Label ID="lbl_CurrentListeners" CssClass="scs_label" runat="server" ></asp:Label><br />
            <asp:Label ID="lbl_MaxListeners" CssClass="scs_label" runat="server"></asp:Label>
        </p>
        <p>
            <asp:Label ID="lbl_SongTitle" CssClass="scs_label" runat="server"></asp:Label><br />
            <asp:Label ID="lbl_ScsSong" runat="server"></asp:Label>
        </p>
        <p>
        <%-- <asp:HyperLink ID="lkl_AIM" runat="server">--%>
        <asp:Label ID="lbl_AIM" CssClass="scs_label" runat="server"></asp:Label>
        </p>
        <p>
            <asp:Label ID="lbl_Bitrate" CssClass="scs_label" runat="server"></asp:Label>
        </p>
<%--        <p>
            <asp:Label ID="lbl_ViewXml" CssClass="scs_label" runat="server"></asp:Label>
        </p>
        <asp:Panel ID="Panel1" CssClass="scs_panel" runat="server">
            <asp:Label ID="lbl_Listeners" CssClass="scs_label" runat="server"></asp:Label>
        </asp:Panel>
        <br />
        <asp:Panel ID="Panel2" CssClass="scs_panel" runat="server">
            <asp:Label ID="lbl_SongHistory" CssClass="scs_label" runat="server"></asp:Label>
        </asp:Panel>
--%>    </div>

