<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Stats_ShoutcastStats.ascx.cs" Inherits="Aarsys.ShoutcastStats.Stats_ShoutcastStats" %>
<%@ Register TagPrefix="dnn" Namespace="DotNetNuke.UI.WebControls" Assembly="DotNetNuke" %>
<%@ Register TagPrefix="dnn" TagName="Label" Src="~/controls/LabelControl.ascx" %>

    <div>
     
    <asp:Label id="lbl_Status" cssclass="scs_label" runat="server"></asp:Label>
    <asp:Label id="lbl_ViewXml" cssclass="scs_label" runat="server"></asp:Label><br />
    <asp:Panel id="Panel1" cssclass="scs_panel" runat="server">
            <asp:Label id="lbl_Listeners" cssclass="scs_label" runat="server"></asp:Label>
        </asp:Panel>
        <br />
        <asp:Panel id="Panel2" cssclass="scs_panel" runat="server">
            <asp:Label ID="lbl_SongHistory" cssclass="scs_label" runat="server"></asp:Label>
        </asp:Panel>
    </div>