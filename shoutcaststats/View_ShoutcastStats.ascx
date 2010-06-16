<%@ Control Language="C#" Inherits="Aarsys.ShoutcastStats.View_ShoutcastStats" AutoEventWireup="true" CodeBehind="View_ShoutcastStats.ascx.cs" %>
<%@ Register Assembly="DotNetNuke.WebControls" Namespace="DotNetNuke.UI.WebControls" TagPrefix="DNN" %>

<%--<asp:ScriptManager ID="SCS_Scriptmanager" runat="server">
</asp:ScriptManager>--%>
<asp:Timer ID="SCS_Timer" OnTick="SCS_TimerTick" runat="server">
</asp:Timer>
<asp:UpdatePanel ID="SCS_UpdatePanel" runat="server">
    <ContentTemplate>
        

<table class="scs_table">
    <tr>
        <td>
            <asp:Label ID="lbl_Status" CssClass="scs_label" runat="server"></asp:Label>
            <asp:Label ID="lbl_Station" CssClass="scs_label" runat="server"></asp:Label>
        </td>
        </tr>
        <tr>
            <td>
            <asp:Label ID="lbl_CurrentListeners" CssClass="scs_label" runat="server" ></asp:Label>
            </td>
            </tr>
            <tr>
            <td>
                <asp:Label ID="lbl_PeakListeners" CssClass="scs_label" runat="server"></asp:Label>
            </td>
            </tr>
            <tr>
            <td><asp:Label ID="lbl_MaxListeners" CssClass="scs_label" runat="server"></asp:Label></td>
            </tr>
        <tr>
        <td>
        
        <asp:Label ID="lbl_SongTitle" CssClass="scs_label" runat="server"></asp:Label><br />
            <asp:Label ID="lbl_ScsSong" runat="server"></asp:Label></td>
            </tr>
        
        <tr>
        <td>
        <asp:Label ID="lbl_AIM" CssClass="scs_label" runat="server"></asp:Label><br />
            <asp:HyperLink ID="lkl_AIM" runat="server"></asp:HyperLink>
         
            <asp:HyperLink ID="lkl_AOL" runat="server"></asp:HyperLink>
        
            <asp:HyperLink ID="lkl_ICQ" CssClass="scs_Chat" runat="server"></asp:HyperLink>
        
            <asp:HyperLink ID="lkl_MSN" CssClass="scs_Chat" runat="server"></asp:HyperLink>
        
            <asp:HyperLink ID="lkl_Yahoo" CssClass="scs_Chat" runat="server"></asp:HyperLink>
        </td>
        </tr>
        <tr>
        <td>
            <asp:Label ID="lbl_Bitrate" CssClass="scs_label" runat="server"></asp:Label>
        </td>
        </tr>
        <tr>
        <td>
            <asp:Label ID="lblStartPlayer" CssClass="scs_PlayerText" runat="server"></asp:Label>
        </td>
        </tr>
        <tr>
        <td>
            <asp:ImageButton ID="WinampStart" runat="server" OnClick="WinampButton_Click" />
            <asp:ImageButton ID="MediaPlayerStart" OnClick="MediaButton_Click" runat="server" />
            <asp:ImageButton ID="RealPlayerStart" OnClick="RealButton_Click" runat="server" />
            <asp:ImageButton ID="ITunesStart" OnClick="ITunesButton_Click" runat="server" />
        </td>
        </tr>
</table>
    </ContentTemplate>
</asp:UpdatePanel>


 
    

