<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="UpdatePage.aspx.cs" Inherits="SON.UpdatePage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <link href="Content/bootstrap.min.css" rel="stylesheet" />
</head>
<body class="text-center">
    <form id="form1" runat="server">
        <div class="container mb-5">
              <main class="login-form">

       
            <img src="img\koupdf.png" alt="Resim Yok" class="mb-4" height="75" width="75"/>
            <h1 class="h3 mb-3">Kullanıcı Güncelle</h1> 
              <asp:TextBox  CssClass="form-control"  placeholder="İd" ID="TextBox3" runat="server"></asp:TextBox>
            <asp:TextBox CssClass="form-control"  placeholder="Kullanıcı Adı" ID="TextBox1" runat="server"></asp:TextBox>
            <asp:TextBox  CssClass="form-control" ID="TextBox2" runat="server"  placeholder="Şifre"></asp:TextBox>
            
            <br />
                   <asp:Button  CssClass="w-30  btn btn-lg  btn-primary"  ID="Button1" runat="server" Text="Güncelle" OnClick="Button1_Click" />
          
             <br />
                 
           


      
        
   
        
    </main>


        </div>
    </form>
</body>
</html>
