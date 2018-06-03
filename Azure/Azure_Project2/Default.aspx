<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta charset="utf-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1.0" />
    <webopt:bundlereference runat="server" path="~/Content/css" />
    <title>        
    </title>
</head>
<body>
    <div class="container">
        <div class="jumbotron">
            <h1>Tushar Garud (Id: 8901)</h1>
            <p class="lead">Upload, share and rate photos...</p>
        </div>

        <div class="jumbotron">
            <form id="form_welcome" runat="server">
                <h3>Please type your username below to proceed</h3> 
                <br/><asp:TextBox runat="server" Width="500px" ID="txtUserName"></asp:TextBox> <br/> <br/>
                <asp:Button runat="server" Text="View Photos" Width="400px" ID="btnNext" OnClick="btnNext_Click" />
            </form>
        </div>
    </div>
</body>
</html>
