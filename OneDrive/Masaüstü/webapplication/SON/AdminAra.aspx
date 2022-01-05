<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AdminAra.aspx.cs" Inherits="SON.AdminAra" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <link href="Content/bootstrap.min.css" rel="stylesheet" />
    <style>
        .sol{float:left;width:30%;height:80%}
        .sag{float:right;width:70%;height:80%}
    </style>
</head>
    
<body>
    <form id="form1" runat="server">
         <div class="sol">
            <div>
                <asp:Label ID="Label1" runat="server" Text="Yazar Bilgileri:"></asp:Label>
            <asp:ListBox CssClass="list-group-item" ID="ListBox1" runat="server" Height="70px" OnSelectedIndexChanged="ListBox1_SelectedIndexChanged" Width="400px"></asp:ListBox>
                <br />
                <asp:Button CssClass="btn btn-dark" ID="Button2" runat="server" Text="Ara" OnClick="Button2_Click" />
                </div>
            
            <br 
                 <br />

              <div>
                    <asp:Label ID="Label2" runat="server" Text="Ders Ad:"></asp:Label>
               
                  <asp:ListBox CssClass="list-group-item" ID="ListBox2" runat="server" Height="70px" OnSelectedIndexChanged="ListBox1_SelectedIndexChanged" Width="400px"></asp:ListBox>
                   <br />
                  <asp:Button  CssClass="btn btn-dark"   ID="Button3" runat="server" Text="Ara" OnClick="Button3_Click" />
           </div>
                  <br />
             <br />
                
             <div>
                   <asp:Label ID="Label3" runat="server" Text="Teslim Tarihi:"></asp:Label>
                 <asp:ListBox CssClass="list-group-item" ID="ListBox3" runat="server" Height="70px" OnSelectedIndexChanged="ListBox1_SelectedIndexChanged" Width="400px"></asp:ListBox>
                  <br />
                 <asp:Button CssClass="btn btn-dark" ID="Button4" runat="server" Text="Ara" OnClick="Button4_Click" />
             </div>
                 <br />
             <br />
              <div>
                    <asp:Label ID="Label4" runat="server" Text="Proje Adı:"></asp:Label>
            <asp:ListBox CssClass="list-group-item" ID="ListBox4" runat="server" Height="70px" OnSelectedIndexChanged="ListBox1_SelectedIndexChanged" Width="400px"></asp:ListBox>
                   <br />
                  <asp:Button   CssClass="btn btn-dark"           ID="Button5" runat="server" Text="Ara" OnClick="Button5_Click" />
            </div>
                  <br />
             <br />
            <div>
                  <asp:Label ID="Label5" runat="server" Text="Anahtar Kelimeler:"></asp:Label>
            <asp:ListBox CssClass="list-group-item" ID="ListBox5" runat="server" Height="70px" OnSelectedIndexChanged="ListBox1_SelectedIndexChanged" Width="400px"></asp:ListBox>
                 <br />
                <asp:Button CssClass="btn btn-dark"              ID="Button6" runat="server" Text="Ara" OnClick="Button6_Click" />
             </div> 
                <br />
             <br />
          
        </div>

        <div class="sag">
              <table class="table table-bordered">
                  <thead>
                 <tr>
                     <th>Pdf İd</th>
                     

                      <th>Bilgiler</th>
                     
                    
                   



                 </tr>

                      </thead>
                   <asp:Repeater ID="Repeater1" runat="server">
                     <ItemTemplate>
                        
                          <tr>   

                      
                       <th ><%# Eval("İd")%></th>
                     
                      
                 
                      <td><asp:HyperLink    NavigateUrl='<%#"UserPdfBilgiler.aspx?İd=" + Eval("İd") +"&Hocaİd="+Eval("Hocaİd")%>'  CssClass=" btn btn-info" ID="HyperLink3" runat="server">Bilgiler</asp:HyperLink></td>

                   
                             
                    


                   

                         </tr>
                     </ItemTemplate>
                     

                    
                 </asp:Repeater>
                 
                
                 </table>























        </div>






    </form>
</body>
</html>
