<%@ Control Language="C#" AutoEventWireup="false" Inherits="Aarsys.ShoutcastStats.Settings" Codebehind="Settings.ascx.cs" %>
<%@ Register TagPrefix="dnn" TagName="Label" Src="~/controls/LabelControl.ascx" %>


<table cellspacing="0" cellpadding="2" border="0" summary="ShoutcastStats Settings Design Table" width="700">
<colgroup><col width="150" /><col width="70%" /></colgroup>
    <tr>
        <td class="SubHead" style="width:150"><dnn:label id="lblSC_IP" runat="server" 
                controlname="txtSC_IP" suffix=":"></dnn:label></td>
        <td valign="bottom" >
            <asp:textbox id="txtSC_IP" cssclass="NormalTextBox" width="390" columns="155" textmode="SingleLine" rows="1" maxlength="200" runat="server" />
        </td>
    </tr>
    <tr>
        <td class="SubHead" style="width:150"><dnn:label id="lblSC_Port" runat="server" controlname="txtSC_Port" suffix=":"></dnn:label></td>
        <td valign="bottom" >
            <asp:textbox id="txtSC_Port" cssclass="NormalTextBox" width="53px" columns="6" 
                textmode="SingleLine" rows="1" maxlength="200" runat="server" />
        </td>
    </tr>
    <tr>
        <td class="SubHead" style="width:150"><dnn:label id="lblSC_Password" runat="server" controlname="txtSC_Password" suffix=":"></dnn:label></td>
        <td valign="bottom" >
            <asp:textbox id="txtSC_Password" cssclass="NormalTextBox" width="100" columns="30" textmode="SingleLine" rows="1" maxlength="200" runat="server" />
        </td>
    </tr>
    </table>
    <table cellspacing="0" cellpadding="1" border="0" width="700">
    <tr>
    <td valign="bottom" style="font-weight:bold"><dnn:label id="lblSC_MSG" runat="server"  ></dnn:label></td>
    </tr>
    </table>
    <table cellspacing="0" cellpadding="4" border="0" width="700">
    <tr>
        <td valign="bottom" class="SubHead" style="width:100"><dnn:label id="lblSC_AIM" runat="server" controlname="SC_AIMCheckBox" suffix=":"></dnn:label></td>
        <td valign="bottom" style="width:50">
            <asp:CheckBox ID="SC_AIMCheckBox" runat="server" /></td>
            <td valign="bottom" class="SubHead" ><dnn:label id="lblSC_AOL" runat="server" controlname="SC_AOLCheckBox" suffix=":"></dnn:label></td>
            <td valign="bottom" style="width:50">
            <asp:CheckBox ID="SC_AOLCheckBox" runat="server" /></td>
     </tr>
     <tr>
            <td valign="bottom" class="SubHead" style="width:100"><dnn:label id="lblSC_ICQ" runat="server" controlname="SC_ICQCheckBox" suffix=":"></dnn:label></td>
            <td valign="bottom" style="width:50">
            <asp:CheckBox ID="SC_ICQCheckBox" runat="server" /></td>
     </tr>
     <tr>
            <td valign="bottom" class="SubHead" style="width:50"><dnn:label id="lblSC_MSN" runat="server" controlname="SC_MSNCheckBox" suffix=":"></dnn:label></td>
            <td valign="bottom" style="width:50">
            <asp:CheckBox ID="SC_MSNCheckBox" runat="server" /></td>
            <td valign="bottom" class="SubHead"><dnn:label id="lblSC_Yahoo" runat="server" controlname="SC_YahooCheckBox" suffix=":"></dnn:label></td>
            <td valign="bottom" style="width:50">
            <asp:CheckBox ID="SC_YahooCheckBox" runat="server" /></td>
    </tr>
    </table>
    <table>
    <tr>
    <td valign="bottom" style="font-weight:bold"><dnn:Label id="lblSC_Features" runat="server" />
    </td>
    </tr>
  </table>
  <table cellspacing="0" cellpadding="4" border="0" width="700">
  <tr>
  <td valign="bottom" class="SubHead" style="width:200"><dnn:Label id="lblSC_Station" runat="server" controlname="SC_StationBox" suffix=":" /></td>
  <td valign="bottom"><asp:CheckBox ID="SC_StationBox" runat="server" /></td>
  <td valign="bottom" class="SubHead"><dnn:Label ID="lblSC_CurrentListeners" runat="server" ControlName="SC_CurrentListenersBox" /></td>
  <td valign="bottom"><asp:Checkbox ID="SC_CurrentListenersBox" runat="server" /></td>
  </tr>
  <tr>
  <td valign="bottom" style="width:200" class="SubHead"><dnn:Label ID="lblSC_PeakListeners" runat="server" ControlName="SC_PeakListenersBox" /></td>
  <td valign="bottom"><asp:Checkbox ID="SC_PeakListenersBox" runat="server" /></td>
  <td valign="bottom" class="SubHead"><dnn:Label ID="lblSC_MaxListeners" runat="server" ControlName="SC_MaxListenersBox" /></td>
  <td valign="bottom"><asp:CheckBox ID="SC_MaxListenersBox" runat="server" /></td>
  </tr>
  <tr>
  <td valign="bottom" class="SubHead" style="width:200"><dnn:Label ID="lblSC_genre" runat="server" ControlName="SC_genreBox" /></td>
  <td valign="bottom"><asp:CheckBox ID="SC_genreBox" runat="server" /></td>
  <td valign="bottom" class="SubHead"><dnn:Label ID="lblSC_Song" runat="server" ControlName="SC_SongBox" /></td>
  <td valign="bottom"><asp:CheckBox ID="SC_SongBox" runat="server" /></td>
  </tr>
  <tr>
  <td valign="bottom" class="SubHead" style="width:200"><dnn:Label ID="lblSC_DJ" runat="server" ControlName="SC_DJBox" /></td>
  <td valign="bottom"><asp:CheckBox ID="SC_DJBox" runat="server" /></td>
  <td valign="bottom" class="SubHead"><dnn:Label ID="lblSC_Bitrate" runat="server" ControlName="SC_BitrateBox" /></td>
  <td valign="bottom"><asp:CheckBox ID="SC_BitrateBox" runat="server" /></td>
  </tr>
  <tr>
  <td valign="bottom" class="SubHead" style="width:200"><dnn:Label ID="lblSC_Content" runat="server" ControlName="SC_ContentBox" /></td>
  <td valign="bottom"><asp:CheckBox ID="SC_ContentBox" runat="server" /></td>
  </tr>
  </table>
  <table>
  <tr>
  <td valign="bottom" style="font-weight:bold"><dnn:Label ID="lblPlayer" runat="server" /></td>
  </tr>
  </table>
  <table cellspacing="0" cellpadding="8">
  <tr>
  <td valign="bottom" class="SubHead" style="width:50"><dnn:Label ID="lblPlayerText" runat="server" ControlName="SC_PlayerBox" /></td>
  <td valign="bottom" style="width:50"><asp:CheckBox ID="SC_PlayerBox" runat="server" /></td>
  </tr>
  <tr>
  <td valign="bottom" class="SubHead"><dnn:Label ID="lblWinamp" runat="server" ControlName="SC_WinampBox" /></td>
  <td valign="bottom"><asp:CheckBox ID="SC_WinampBox" runat="server" /></td>
  <td valign="bottom" class="SubHead"><dnn:Label ID="lblMediaPlayer" runat="server" ControlName="SC_MediaPlayerBox" /></td>
  <td valign="bottom"><asp:CheckBox ID="SC_MediaPlayerBox" runat="server" /></td>
  <td valign="bottom" class="SubHead"><dnn:Label ID="lblRealPlayer" runat="server" ControlName="SC_RealPlayerBox" /></td>
  <td valign="bottom"><asp:CheckBox ID="SC_RealPlayerBox" runat="server" /></td>
  <td valign="bottom" class="SubHead"><dnn:label ID="lbliTunes" runat="server" ControlName="SC_iTunesBox" /></td>
  <td valign="bottom"><asp:CheckBox ID="SC_iTunesBox" runat="server" /></td>
  </tr>
</table>

