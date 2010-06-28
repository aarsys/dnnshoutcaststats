<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="StatsSettings.ascx.cs" Inherits="Aarsys.ShoutcastStats.StatsSettings" %>
<%@ Register TagPrefix="dnn" TagName="Label" Src="~/controls/LabelControl.ascx" %>

<table cellspacing="0" cellpadding="2" border="0" summary="Stats_ShoutcastStats Settings Design Table" width="700">
<colgroup><col width="150" /><col width="70%" /></colgroup>
    <tr>
        <td class="SubHead" style="width:150"><dnn:label id="lblSCS_IP" runat="server" 
                controlname="txtSCS_IP" suffix=":"></dnn:label></td>
        <td valign="bottom" >
            <asp:textbox id="txtSCS_IP" cssclass="NormalTextBox" width="390" columns="155" textmode="SingleLine" rows="1" maxlength="200" runat="server" />
        </td>
    </tr>
    <tr>
        <td class="SubHead" style="width:150"><dnn:label id="lblSCS_Port" runat="server" controlname="txtSCS_Port" suffix=":"></dnn:label></td>
        <td valign="bottom" >
            <asp:textbox id="txtSCS_Port" cssclass="NormalTextBox" width="53px" columns="6" 
                textmode="SingleLine" rows="1" maxlength="200" runat="server" />
        </td>
    </tr>
    <tr>
        <td class="SubHead" style="width:150"><dnn:label id="lblSCS_Password" runat="server" controlname="txtSCS_Password" suffix=":"></dnn:label></td>
        <td valign="bottom" >
            <asp:textbox id="txtSCS_Password" cssclass="NormalTextBox" width="100" columns="30" textmode="SingleLine" rows="1" maxlength="200" runat="server" />
        </td>
    </tr>
    </table>
    <table cellspacing="0" cellpadding="2" border="0" width="700">
    <tr>
    <td></td>
    </tr>
    <tr>
    <td valign="bottom" style="font-weight:bold">
        <dnn:Label ID="SCS_FeatureSettings" runat="server" ></dnn:Label>
    </td>
    </tr>
    </table>
    <table cellspacing="0" cellpadding="2" border="0" width="200">
    <tr>
    <td class="SubHead" >
        <dnn:label ID="lblSC_XMLFileCount" runat="server" controlname="SC_XMLFileCount"></dnn:label>
    </td>
    <td  >
        <asp:CheckBox ID="SC_XMLFileCount" runat="server" />
    </td>
    </tr>
    <tr>
    <td class="SubHead" >
        <dnn:label ID="lblSC_ListenerList" runat="server" controlname="SC_ListenerList"></dnn:label></td>
    <td >
        <asp:CheckBox ID="SC_ListenerList" runat="server" />
    </td>
    </tr>
    <tr>
    <td class="SubHead" >
        <dnn:label ID="lblSC_LastPlayed" runat="server" controlname="SC_LastPlayed"></dnn:label></td>
    <td >
        <asp:CheckBox ID="SC_LastPlayed" runat="server" />
    </td>
    </tr>

    </table>
    