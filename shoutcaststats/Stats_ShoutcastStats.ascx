<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Stats_ShoutcastStats.ascx.cs" Inherits="ShoutcastStats.Stats_ShoutcastStats" %>
<%@ Register TagPrefix="dnn" Namespace="DotNetNuke.UI.WebControls" Assembly="DotNetNuke" %>
<%@ Register TagPrefix="dnn" TagName="Label" Src="~/controls/LabelControl.ascx" %>

    <div>
     
    <asp:Label ID="lbl_Status" CssClass="scs_label" runat="server"></asp:Label>
    <asp:Label ID="lbl_ViewXml" CssClass="scs_label" runat="server"></asp:Label><br />
    <asp:Panel ID="Panel1" CssClass="scs_panel" runat="server">
            <asp:Label ID="lbl_Listeners" CssClass="scs_label" runat="server"></asp:Label>
        </asp:Panel>
        <br />
        <asp:Panel ID="Panel2" CssClass="scs_panel" runat="server">
            <asp:Label ID="lbl_SongHistory" CssClass="scs_label" runat="server"></asp:Label>
        </asp:Panel>
    </div>