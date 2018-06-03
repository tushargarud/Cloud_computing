<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Page2.aspx.cs" Inherits="Page2" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:label Font-Size="XX-Large" runat="server" Text="Welcome " ID="lblWelcome"></asp:label><br /><br />
        </div>
        <div>
            <asp:Button ID="btnViewPhotos" Width="200px" Height="40px" Text="View Photos" runat="server" OnClick="btnViewPhotos_Click" /><br /><br />
            <asp:FileUpload ID="FileUpload1" Height="40px" runat="server" />&nbsp;&nbsp;&nbsp;
            <asp:Button ID="btnUploadPhotos" Width="200px" Height="40px" Text="Upload Photos" runat="server" OnClick="btnUploadPhotos_Click" />
        </div>
        <div>
            <asp:GridView ID="gvImages" runat="server" DataKeyNames="PhotoId" AutoGenerateColumns="false" OnRowDataBound="OnRowDataBound" OnRowCommand="gvImages_RowCommand">
                <Columns>
                    <asp:BoundField HeaderText="ID" DataField="PhotoId" Visible="false" />
                    <asp:BoundField HeaderText="Title" DataField="Title" />
                    <asp:BoundField HeaderText="User Id" DataField="UserId" />
                    <asp:BoundField HeaderText="Create Time" DataField="CreateTime" />
                    <asp:TemplateField HeaderText = "Image">
                        <ItemTemplate>
                            <asp:Image ID="Image1" runat="server" Height="200" Width="200" />
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:BoundField HeaderText="Likes" DataField="LikesNumber" />
                    <asp:TemplateField HeaderText="Like Photo">
                      <ItemTemplate>
                        <asp:Button ID="Like" runat="server" 
                          CommandName="LikePhoto"
                          CommandArgument="<%# ((GridViewRow) Container).RowIndex %>"
                          Text="Like" />
                      </ItemTemplate> 
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
        </div>
    </form>
</body>
</html>
