<%@ Page Title="Home Page" Language="C#" AutoEventWireup="true" CodeFile="Upload.aspx.cs" Inherits="Upload" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta charset="utf-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1.0" />
    <webopt:bundlereference runat="server" path="~/Content/css" />
    <title>
        <h1>Tushar Garud (Id: 8901)</h1>
    </title>
</head>
<body>
            <div class="jumbotron">
                <h1>Tushar Garud (Id: 8901)</h1>                
            </div>
        <form id="form1" runat="server">

        <div class="container">
            <h2><asp:Label id="welcomeText" runat="server" /></h2>
            <h3>Upload new photo here</h3>            
            <asp:FileUpload ID="fudUploadPhoto"  runat="server" />&nbsp;&nbsp;&nbsp; 
            <br /> 
            <h4><asp:Label runat="server"> Enter photo description : 
            <asp:TextBox ID="txtPhotoTitle" Width="300px" Height="30px" runat="server" /> </asp:Label></h4>            
            <asp:Button ID="btnUpload" Text="Upload Photo" Width="150px" Height="30px" runat="server" OnClick="btnUpload_Click" />     
            <br /><br /><br />
        </div>
        <div class="container">
            <asp:Repeater ID="rptPhotos" runat="server" OnItemCommand="rptPhotos_ItemCommand">
                <HeaderTemplate>
                        <table>
                </HeaderTemplate>
                <ItemTemplate>
                    <tr><td style="padding: 50px;">
                    <div class="jumbotron">
                        <h2><asp:Label runat="server" Text='<%# Eval("photoTitle") %>' /></h2>

                        <h5><asp:Label style="display: block; text-align: right;" runat="server" Text='<%# "Uploaded by " + Eval("userName") %>' /></h5>

                        <asp:Image runat="server" width="400px" height="300px" Src='<%# Eval("photoContent") %>' />     
                        
                        <h6><asp:Label style="display: block; text-align: right;" runat="server" Text='<%# Eval("timestamp") %>' /></h6>
                     </div>
                        </td>
                </ItemTemplate>
                <AlternatingItemTemplate>                    
                    <td style="padding: 50px;">
                        <div class="jumbotron">
                            <h2><asp:Label runat="server" Text='<%# Eval("photoTitle") %>' /></h2>

                            <h5><asp:Label style="display: block; text-align: right;" runat="server" Text='<%# "Uploaded by " + Eval("userName") %>' /></h5>

                            <asp:Image runat="server" width="400px" height="300px" Src='<%# Eval("photoContent") %>' />     

                            <h6><asp:Label style="display: block; text-align: right;" runat="server" Text='<%# Eval("timestamp") %>' /></h6>
                         </div>
                    </td></tr>
                </AlternatingItemTemplate>
                <FooterTemplate>
                    </table>
                </FooterTemplate>
            </asp:Repeater>
        </div>

	</form>

    <asp:Image id="catImage" runat="server" width="400px" height="300px" />     

</body>
</html>