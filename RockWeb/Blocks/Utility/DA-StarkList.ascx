<%@ Control Language="C#" AutoEventWireup="true" CodeFile="Task1.ascx.cs" Inherits="RockWeb.Plugins.org_rocksolidchurch.Tutorials.Task1" %>

<asp:UpdatePanel ID="upnlContent" runat="server">
    <ContentTemplate>

        <Rock:Grid ID="gPeople" runat="server" AllowSorting="true" OnRowSelected="gPeople_RowSelected" RowItemText="Group" RowSelectionEnabled="true" DataKeyNames="Id">
            <Columns>
                <asp:BoundField DataField="Name" HeaderText="Group Name" />
                <asp:BoundField DataField="GroupTypeId" HeaderText="Type" />
                <asp:BoundField DataField="Description" HeaderText="Description" />
                <asp:BoundField DataField="IsActive" HeaderText="Active" />
            </Columns>
        </Rock:Grid>


    </ContentTemplate>
</asp:UpdatePanel>
