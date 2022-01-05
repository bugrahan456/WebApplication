<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AdminForm.aspx.cs" Inherits="SON.AdminForm" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <link href="Content/bootstrap.min.css" rel="stylesheet" />
    <link href="Content/bootstrap.min.css" rel="stylesheet" />
</head>
<body>
    
    <form id="form1" runat="server">




        <div style="margin-top:30px" class="mb-4">

             <asp:HyperLink NavigateUrl="AdminAra.aspx" CssClass="btn btn-dark" ID="HyperLink5" runat="server">Veri Tabanında Ara</asp:HyperLink>
            <br />
            <br />

            <table class="table" >
                <thead>
                <tr>
                    <th>ID</th>
                    <th>Kullanıcı Adı</th>
                    <th>Şifre</th>
                    <th>Sil</th>
                    <th>Güncelle</th>
                    <th>Bilgiler</th>
                
                </tr>
                    </thead>
                <asp:HyperLink NavigateUrl="~/KullaniciEkle.aspx" CssClass="btn btn-success" ID="HyperLink3" runat="server">Kullanıcı Ekle</asp:HyperLink>
                        <br/>
             
                <asp:Repeater ID="Repeater1" runat="server">
                    <ItemTemplate>              
                <tr>
                    
                      
                      <th ><%# Eval("İd")%></th>
                      <td><%# Eval("KullaniciAdi")%></td>
                      <td><%# Eval("KullaniciSifre")%></td>
                     <td><asp:HyperLink   NavigateUrl='<%#"DeletePage.aspx?İd=" + Eval("İd")%>' CssClass=" btn btn-danger" ID="HyperLink1" runat="server">Sil</asp:HyperLink></td>
                     <td>
                         
                         <asp:HyperLink  NavigateUrl='<%#"UpdatePage.aspx?İd=" + Eval("İd")%>' CssClass="btn btn-success" ID="HyperLink2" runat="server">Güncelle</asp:HyperLink>
                     </td>
                    <td>
                         <asp:HyperLink  NavigateUrl='<%#"AdminBilgiler.aspx?İd=" + Eval("İd")%>' CssClass="btn btn-info" ID="HyperLink4" runat="server">Bilgi</asp:HyperLink>
                    </td>
                </tr>
                        </ItemTemplate>
                    </asp:Repeater>

            </table>

        </div>
    </form>
</body>
</html>
