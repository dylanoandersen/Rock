<%@ Control Language="C#" AutoEventWireup="true" CodeFile="Task1Details.ascx.cs" Inherits="RockWeb.Plugins.org_rocksolidchurch.Tutorials.Task1Details" %>
<asp:UpdatePanel ID="upnlContent" runat="server">
    <ContentTemplate>

        <h2>Group Details</h2>
        <p><strong>Name: </strong> <asp:Literal ID="Name" runat="server" /> </p>
        <p><strong>Description: </strong> <asp:Literal ID="Description" runat="server" /> </p>
        <p><strong>Date Created: </strong> <asp:Literal ID="DateCreated" runat="server" /> </p>
        <p><strong>Date Modified: </strong> <asp:Literal ID="DateModified" runat="server" /> </p>
        <p><strong>Group Capacity: </strong> <asp:Literal ID="GroupCapacity" runat="server" /> </p>


    </ContentTemplate>
</asp:UpdatePanel>