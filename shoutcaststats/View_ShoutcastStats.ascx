<%@ Control Language="C#" Inherits="Aarsys.ShoutcastStats.View_ShoutcastStats" AutoEventWireup="true" CodeBehind="View_ShoutcastStats.ascx.cs" %>
<%@ Register Assembly="DotNetNuke.WebControls" Namespace="DotNetNuke.UI.WebControls" TagPrefix="DNN" %>
<%@ Register TagPrefix="dnn" TagName="Label" Src="~/controls/LabelControl.ascx" %>


<table class="scs_table">

<asp:UpdatePanel id="UpdatePanel1" runat="server" RenderMode="Block">
     <ContentTemplate>
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
        <td class="scs_table.td">
        
        <asp:Label id="lbl_SongTitle" cssclass="scs_label" runat="server"></asp:Label>
            <asp:Label id="lbl_ScsSong" runat="server"></asp:Label>
         </td>
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
            <asp:ImageButton id="WinampStart" runat="server" />
            <asp:ImageButton id="MediaPlayerStart" runat="server" />
            <asp:ImageButton id="RealPlayerStart" runat="server" />
            <asp:ImageButton id="ITunesStart" runat="server" />
        </td>
        </tr>
        <asp:Timer id="Timer1" OnTick="SCS_TimerTick" Interval="60000" runat="server" />
    </ContentTemplate>
</asp:UpdatePanel>

</table>


 
    

