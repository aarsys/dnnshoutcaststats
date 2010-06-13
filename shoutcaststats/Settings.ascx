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
    <table>
    <tr>
    <td valign="bottom" ><dnn:label id="lblSC_MSG" runat="server"></dnn:label></td>
        <td valign="bottom" ><dnn:label id="lblSC_AIM" runat="server" controlname="SC_AIMCheckBox" suffix=":"></dnn:label></td>
        <td valign="bottom" >
            <asp:CheckBox ID="SC_AIMCheckBox" runat="server" /></td>
            <td valign="bottom" ><dnn:label id="lblSC_AOL" runat="server" controlname="SC_AOLCheckBox" suffix=":"></dnn:label></td>
            <td valign="bottom">
            <asp:CheckBox ID="SC_AOLCheckBox" runat="server" /></td>
            <td valign="bottom"><dnn:label id="lblSC_ICQ" runat="server" controlname="SC_ICQCheckBox" suffix=":"></dnn:label></td>
            <td valign="bottom">
            <asp:CheckBox ID="SC_ICQCheckBox" runat="server" /></td>
            <td valign="bottom"><dnn:label id="lblSC_MSN" runat="server" controlname="SC_MSNCheckBox" suffix=":"></dnn:label></td>
            <td valign="bottom">
            <asp:CheckBox ID="SC_MSNCheckBox" runat="server" /></td>
            <td valign="bottom"><dnn:label id="lblSC_Yahoo" runat="server" controlname="SC_YahooCheckBox" suffix=":"></dnn:label></td>
            <td valign="bottom">
            <asp:CheckBox ID="SC_YahooCheckBox" runat="server" /></td>
        
    </tr>
  
</table>

