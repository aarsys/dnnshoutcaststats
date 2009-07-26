<%@ Control Language="C#" AutoEventWireup="false" Inherits="Aarsys.Modules.DNN_ShoutcastStats.Settings" Codebehind="Settings.ascx.cs" %>
<%@ Register TagPrefix="dnn" TagName="Label" Src="~/controls/LabelControl.ascx" %>
<table cellspacing="0" cellpadding="2" border="0" summary="DNN_ShoutcastStats Settings Design Table">
    <tr>
        <td class="SubHead" style="width:150"><dnn:label id="lblSC_IP" runat="server" controlname="txtSC_IP" suffix=":"></dnn:label></td>
        <td valign="bottom" >
            <asp:textbox id="txtSC_IP" cssclass="NormalTextBox" width="390" columns="30" textmode="SingleLine" rows="1" maxlength="200" runat="server" />
        </td>
    </tr>
    <tr>
        <td class="SubHead" style="width:150"><dnn:label id="lblSC_Port" runat="server" controlname="txtSC_Port" suffix=":"></dnn:label></td>
        <td valign="bottom" >
            <asp:textbox id="txtSC_Port" cssclass="NormalTextBox" width="390" columns="30" textmode="SingleLine" rows="1" maxlength="200" runat="server" />
        </td>
    </tr>
    <tr>
        <td class="SubHead" style="width:150"><dnn:label id="lblSC_Password" runat="server" controlname="txtSC_Password" suffix=":"></dnn:label></td>
        <td valign="bottom" >
            <asp:textbox id="txtSC_Password" cssclass="NormalTextBox" width="390" columns="30" textmode="SingleLine" rows="1" maxlength="200" runat="server" />
        </td>
    </tr>
</table>

