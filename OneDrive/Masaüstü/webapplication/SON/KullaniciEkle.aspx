<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="KullaniciEkle.aspx.cs" Inherits="SON.KullaniciEkle" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
      <style>.ortala{margin:auto}

     
    </style>
    <link href="Content/bootstrap.min.css" rel="stylesheet" />
    <link href="./style.css" rel="stylesheet" />
</head>
<body class="text-center ortala bg-white">
    <form id="form1" runat="server" class="ortala">
        <div class="ortala">
              
    
           
            <h1 class="h3 mb-3">Kullanıcı Kayıt</h1> 
            <asp:TextBox CssClass="form-control ortala"  placeholder="Kullanıcı Adı" ID="TextBox1" runat="server"></asp:TextBox>
            <asp:TextBox type="password" CssClass="form-control ortala" ID="TextBox2" runat="server"  placeholder="Şifre"></asp:TextBox>
            
            <br />
            <asp:Button CssClass="w-30  btn   btn-success" ID="Button2" runat="server" Text=" Kullanıcı Ekle" OnClick="Button2_Click" />
             <br />
           

        </div>
    </form>
</body>
</html>
