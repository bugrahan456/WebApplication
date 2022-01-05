<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="LoginUser.aspx.cs" Inherits="SON.LoginUser" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>Giriş Ekranı</title>
   
    <style>.ortala{margin:auto}
     .first{float:left }
      .right{float:right ;margin-left:270px}
    </style>
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.0.2/dist/css/bootstrap.min.css" rel="stylesheet" integrity="sha384-EVSTQN3/azprG1Anm3QDgpJLIm9Nao0Yz1ztcQTwFspd3yD65VohhpuuCOmLASjC" crossorigin="anonymous">
     <link href="./style.css" rel="stylesheet" />
</head>
<body class="text-center background-colar bg-white" >
    <form id="form1" runat="server" class="ortala" >
   

        <div class="first">
        <main class="login-form">

       
            <img src="img\koupdf.png" alt="Resim Yok" class="mb-4" height="75" width="75"/>
            <h1 class="h3 mb-3">Kullanıcı Girişi</h1> 
            <asp:TextBox CssClass="form-control"  placeholder="Kullanıcı Adı" ID="TextBox1" runat="server"></asp:TextBox>
            <asp:TextBox type="password" CssClass="form-control" ID="TextBox2" runat="server"  placeholder="Şifre"></asp:TextBox>
            
            <br />
            <asp:Button CssClass="w-30  btn btn-lg  btn-primary" ID="Button2" runat="server" Text=" Giriş Yap" OnClick="Button2_Click" />
             <br />
            <asp:Label         ID="Label1" runat="server" Text="Label"></asp:Label>


      
        
   
        
    </main>
            </div>
     
         <div class="right">
        <main class="login-form">

       
            <img src="img\koupdf.png" alt="Resim Yok" class="mb-4" height="75" width="75"/>
            <h1 class="h3 mb-3">Yönetici Girişi</h1> 
            <asp:TextBox CssClass="form-control"  placeholder="Kullanıcı Adı" ID="TextBox3" runat="server"></asp:TextBox>
            <asp:TextBox type="password" CssClass="form-control" ID="TextBox4" runat="server"  placeholder="Şifre"></asp:TextBox>
            
            <br />
            <asp:Button CssClass="w-30  btn btn-lg  btn-primary" ID="Button1" runat="server" Text=" Giriş Yap" OnClick="Button1_Click" />
             <br />
            <asp:Label         ID="Label2" runat="server" Text="Label"></asp:Label>


      
        
   
        
    </main>
            </div>
    </form>
    
</body>
</html>
