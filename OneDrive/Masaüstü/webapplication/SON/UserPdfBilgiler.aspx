<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="UserPdfBilgiler.aspx.cs" Inherits="SON.UserPdfBilgiler" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <link href="Content/bootstrap.min.css" rel="stylesheet" />
    <link href="Content/bootstrap.min.css" rel="stylesheet" />
</head>
<body>
    <div class="col-md-6">
    <form id="form1" runat="server">
        
        <div class="container ">
            <div class="form-group">
                <asp:Label ID="Label1" runat="server" Text="Pdf İd:"></asp:Label>
                 <asp:TextBox   CssClass="form-control"         ID="TextBox1" runat="server"></asp:TextBox>
            </div>
         <div class="form-group">
                <asp:Label ID="Label2" runat="server" Text="Yazar Bilgileri:"></asp:Label>
                 <asp:TextBox   CssClass="form-control"         ID="TextBox2" runat="server"></asp:TextBox>
            </div>
         <div class="form-group">
                <asp:Label ID="Label3" runat="server" Text="Ders Adı:"></asp:Label>
                 <asp:TextBox   CssClass="form-control"         ID="TextBox3" runat="server"></asp:TextBox>
            </div>
         <div class="form-group">
                <asp:Label ID="Label4" runat="server" Text="Proje Özeti:"></asp:Label>,
             <br />
             
             <asp:TextBox CssClass="text-area" ID="TextBox4" TextMode="MultiLine" runat="server" Height="529px" Width="803px"></asp:TextBox>
                
            </div>
         <div class="form-group">
                <asp:Label ID="Label5" runat="server" Text="Teslim Tarihi:"></asp:Label>
                 <asp:TextBox   CssClass="form-control"         ID="TextBox5" runat="server"></asp:TextBox>
            </div>
         <div class="form-group">
                <asp:Label ID="Label6" runat="server" Text="Proje Başlık:"></asp:Label>
                 <asp:TextBox   CssClass="form-control"         ID="TextBox6" runat="server"></asp:TextBox>
            </div>
         <div class="form-group">
                <asp:Label ID="Label7" runat="server" Text="Anahtar Kelimeler:"></asp:Label>
                 <asp:TextBox   CssClass="form-control"         ID="TextBox7" runat="server"></asp:TextBox>
            </div>
         <div class="form-group">
                <asp:Label ID="Label8" runat="server" Text="Danışman Bilgileri:"></asp:Label>
                 <asp:TextBox   CssClass="form-control"         ID="TextBox8" runat="server"></asp:TextBox>
            </div>
         <div class="form-group">
                <asp:Label ID="Label9" runat="server" Text="Juri Bilgileri"></asp:Label>
                 <asp:TextBox   CssClass="form-control"         ID="TextBox9" runat="server"></asp:TextBox>
            </div>
            
           </div>
           




        
    </form>
        </div>
</body>
</html>
