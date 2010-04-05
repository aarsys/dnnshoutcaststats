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

