<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <div class="jumbotron">
        <h1>Project 2- Photo Album Application</h1>
        <h2>By: Tushar Garud</h2>
    </div>

    <div class="row">
        <h3>Please Enter your User ID below to continue:</h3><br />
       <asp:TextBox runat="server" Width="450px" ID="txtUserId"></asp:TextBox> <br /><br />
        <asp:Button runat="server" Text="Login" ID="btnLogin" Width="200px" OnClick="btnLogin_Click" />
    </div>
</asp:Content>
