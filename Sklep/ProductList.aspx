<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="ProductList.aspx.cs" Inherits="Sklep.TermsAndConditions" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <section>
        <div class="container-fluid">
            <div class="row">
                <div class="col-md-3">
                    <center>
                        <br /><h1>"Two words my friend<br />
                        No refunds"</h1><br />
                        <h3>September 18, 2012 ~ Marcus</h3>
                    </center>
                </div>
                <div class="col-md-9">
                    <asp:DataList ID="DataListProduct" runat="server" DataSourceID="SqlDataProducts" RepeatColumns="3" RepeatDirection="Horizontal">
                        <ItemTemplate>
                            <table>
                                <tr>
                                    <td>
                                        <a class="" href="HomePage.aspx">
                                            <img height="300px" src='<%# Eval("Path")%>' class="img-fluid" href="HomePage.aspx"/>
                                        </a>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:Label ID="Label1" runat="server" Text='<%# Eval("Name") %>'></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:Label ID="Label2" runat="server" Text='<%# Eval("Price") %>'></asp:Label>
                                    </td>
                                </tr>
                                <div style="height: 15px;">

                                </div>
                            </table>
                        </ItemTemplate>
                    </asp:DataList>
                </div>
                <div style="height: 50px;">

                </div>
            </div>
        </div>

    </section>
    <asp:SqlDataSource ID="SqlDataProducts" runat="server" ConnectionString="<%$ ConnectionStrings:ShopConnectionString2 %>" SelectCommand="select p.Name, p.Description, tp.TypeName as Type, p.Price, pic.Path
from Product p
left join ProductType tp on tp.id = p.Type
left join Pictures Pic on Pic.IDCard = P.id
Order by p.name">
    </asp:SqlDataSource>
    

    
</asp:Content>
