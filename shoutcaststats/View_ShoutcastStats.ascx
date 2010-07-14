<%@ Control Language="C#" Inherits="Aarsys.ShoutcastStats.View_ShoutcastStats" AutoEventWireup="true" CodeBehind="View_ShoutcastStats.ascx.cs" %>
<%@ Register Assembly="DotNetNuke.WebControls" Namespace="DotNetNuke.UI.WebControls" TagPrefix="DNN" %>
<%@ Register TagPrefix="dnn" TagName="Label" Src="~/controls/LabelControl.ascx" %>

<asp:Timer id="SCS_Timer" OnTick="SCS_TimerTick" runat="server">
</asp:Timer>
<asp:UpdatePanel id="SCS_UpdatePanel" runat="server">
    <ContentTemplate>
<table class="scs_table">
    <tr>
        <td class="Column">
            <asp:Label id="lbl_Status" cssclass="scs_label" runat="server"></asp:Label>
            <asp:Label id="lbl_Station" cssclass="scs_label" runat="server"></asp:Label>
        </td>
        </tr>
        <tr>
            <td>
            <asp:Label id="lbl_CurrentListeners" cssclass="scs_label" runat="server" ></asp:Label>
            </td>
            </tr>
            <tr class="Column">
            <td>
                <asp:Label id="lbl_PeakListeners" cssclass="scs_label" runat="server"></asp:Label>
            </td>
            </tr>
            <tr>
            <td class="Column"><asp:Label id="lbl_MaxListeners" cssclass="scs_label" runat="server"></asp:Label></td>
            </tr>
            <tr>
            <td class="Column"><asp:Label id="lbl_Genre" cssclass="scs_label" runat="server"></asp:Label></td>
            </tr>
        <tr>
        <td class="Column">
        
        <asp:Label id="lbl_SongTitle" cssclass="scs_label" runat="server"></asp:Label>
            <asp:Label id="lbl_ScsSong" runat="server"></asp:Label></td>
            </tr>
        
        <tr>
        <td class="Column">
        <asp:Label id="lbl_AIM" cssclass="scs_label" runat="server"></asp:Label>
        </td>
        </tr>
        <tr>
        <td>
            <asp:HyperLink id="lkl_AIM" cssclass="scs_Chat" runat="server"></asp:HyperLink>
         
            <asp:HyperLink id="lkl_AOL" cssclass="scs_Chat" runat="server"></asp:HyperLink>
        
            <asp:HyperLink id="lkl_ICQ" cssclass="scs_Chat" runat="server"></asp:HyperLink>
        
            <asp:HyperLink id="lkl_MSN" cssclass="scs_Chat" runat="server"></asp:HyperLink>
        
            <asp:HyperLink id="lkl_Yahoo" cssclass="scs_Chat" runat="server"></asp:HyperLink>
        </td>
        </tr>
        <tr>
        <td class="Column">
            <asp:Label id="lbl_Bitrate" cssclass="scs_label" runat="server"></asp:Label>
        </td>
        </tr>
        <tr>
        <td class="Column">
            <asp:Label id="lbl_ContentType" cssclass="scs_label" runat="server"></asp:Label>
        </td>
        </tr>
        <tr>
        <td class="Column">
            <asp:Label id="lblStartPlayer" cssclass="scs_PlayerText" runat="server"></asp:Label>
        </td>
        </tr>
        <tr>
        <td class="Column" >
            <asp:ImageButton id="WinampStart" runat="server" OnClick="WinampButton_Click" />
            <asp:ImageButton id="MediaPlayerStart" OnClick="MediaButton_Click" runat="server" />
            <asp:ImageButton id="RealPlayerStart" OnClick="RealButton_Click" runat="server" />
            <asp:ImageButton id="ITunesStart" OnClick="ITunesButton_Click" runat="server" />
        </td>
        </tr>
</table>
    </ContentTemplate>
</asp:UpdatePanel>


 
    

