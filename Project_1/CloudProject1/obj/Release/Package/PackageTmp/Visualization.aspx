<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Visualization.aspx.cs" Inherits="CloudAssignment4.Visualization" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

 
<asp:Literal ID="lit_NewDataTable" runat="server" />
<asp:DataGrid ID="DataGrid1" runat="server" Width="350px" AutoGenerateColumns="False">
<Columns>
<asp:BoundColumn DataField="StateName" HeaderText="ID" />
<asp:BoundColumn DataField="TotalPop" HeaderText="Name" />
<asp:BoundColumn DataField="VotePop" HeaderText="Age" />
</Columns>
</asp:DataGrid>


</asp:Content>
