<%@ Control Language="C#" Inherits="Aarsys.ShoutcastStats.View_ShoutcastStats" AutoEventWireup="true" CodeBehind="View_ShoutcastStats.ascx.cs" %>
<%@ Register Assembly="DotNetNuke.WebControls" Namespace="DotNetNuke.UI.WebControls" TagPrefix="DNN" %>

<table class="scs_table">
    
 <tr>
        <td>
            <asp:Label ID="lbl_Status" CssClass="scs_label" runat="server"></asp:Label>
            <asp:Label ID="lbl_Station" CssClass="scs_label" runat="server"></asp:Label>
        </td>
        </tr>
        <tr>
            <td><asp:Label ID="lbl_CurrentListeners" CssClass="scs_label" runat="server" ></asp:Label></td>
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
        <%--<tr>
        <td>
            <asp:HyperLink ID="lkl_media" CssClass="scs_PlayerLink" runat="server"></asp:HyperLink>
        </td></tr>--%>
</table>
 
    

