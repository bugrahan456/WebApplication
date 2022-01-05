<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AdminBilgiler.aspx.cs" Inherits="SON.AdminBilgiler" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <link href="Content/bootstrap.min.css" rel="stylesheet" />
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
           <div>
           
            <br />
            <br />
     
             <table class="table table-bordered">
                  <thead>
                 <tr>
                     <th>Pdf İd</th>
                     <th>Pdf İsmi</th>
                     
                       <th >Kullanıcı İd</th>
                     
                      <th>Bilgiler</th>
                     
                      <th class="auto-style2">Sil</th>
                      <th>İndir</th>
                   



                 </tr>
                      </thead>
                 <asp:Repeater ID="Repeater1" runat="server">
                     <ItemTemplate>
                        
                          <tr>   

                      
                      <th ><%# Eval("İd")%></th>
                       <td ><%# Eval("FileName")%></td>
                        <td ><%# Eval("HocaİD")%></td>
                  

                 
              
                                  
                      <td><asp:HyperLink    NavigateUrl='<%#"UserPdfBilgiler.aspx?İd=" + Eval("İd") +"&Hocaİd="+Eval("Hocaİd")%>'  CssClass=" btn btn-info" ID="HyperLink3" runat="server">Bilgiler</asp:HyperLink></td>

                   
                             
                     <td><asp:HyperLink   NavigateUrl='<%#"DeleteUserPdfAdmin.aspx?İd=" + Eval("İd") +"&Hocaİd="+Eval("Hocaİd")%>'  CssClass=" btn btn-danger" ID="HyperLink1" runat="server">Sil</asp:HyperLink></td>


                           <td> <asp:LinkButton CssClass=" btn btn-dark" ID="lnkDownload" runat="server" Text="İndir" OnClick="DownloadFile"
                    CommandArgument='<%# Eval("İd") %>'></asp:LinkButton>
                               </td> 
                   

                         </tr>
                     </ItemTemplate>
                     


                 </asp:Repeater>
                
                 </table>


            

             
        </div>
    </form>
</body>
</html>
