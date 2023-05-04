<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="ProductList.aspx.cs" Inherits="Sklep.TermsAndConditions" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <section>
        <div class="container">
            <div class="row">
                <div class="col-md-2">
                    <center>
                        <br /><h1>"Two words my friend<br />
                        No refunds"</h1><br />
                        <h3>September 18, 2012 ~ Marcus</h3>
                    </center>
                </div>
                <div class="col-md-10">
                    <asp:DataList ID="DataListProduct" runat="server" DataSourceID="SqlDataProducts">
                        <ItemTemplate>
                            <table>
                                <tr>
                                    <td>
                                        <asp:Label ID="Label1" runat="server" Text='<%# Eval("Name") %>'></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:Label ID="Label2" runat="server" Text="Label"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:Label ID="Label3" runat="server" Text="Label"></asp:Label>
                                    </td>
                                </tr>
                            </table>
                        </ItemTemplate>
                    </asp:DataList>
                </div>
            </div>
        </div>

    </section>
    <asp:SqlDataSource ID="SqlDataProducts" runat="server" ConnectionString="<%$ ConnectionStrings:ShopConnectionString2 %>" SelectCommand="select p.Name, p.Description, tp.TypeName as Type, p.Price
from Product p
left join ProductType tp on tp.id = p.Type
Order by p.name">
    </asp:SqlDataSource>
    

    
</asp:Content>
