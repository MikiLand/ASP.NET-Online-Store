<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="Basket.aspx.cs" Inherits="Sklep.ProductList" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <section>
        <div class="container-fluid">
            <div class="row">
                <div class="col-md-9">
                    <asp:DataList ID="DataListProduct" runat="server" DataSourceID="SqlDataProducts" RepeatColumns="1" RepeatDirection="Horizontal">
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






                <div class="col-md-3">
                    <div style="height: 15px;">

                    </div>
                </div>

                
                <div style="height: 50px;">

                </div>
            </div>
        </div>

    </section>
    <asp:SqlDataSource ID="SqlDataBasket" runat="server" ConnectionString="<%$ ConnectionStrings:ShopConnectionString2 %>" SelectCommand="select top 1 id_user, p.Name, p.Description, p.Price, b.Amount, p.Price* b.Amount, pic.Path as Value  from Basket b
left join Product p on p.id = b.id_product
left join Pictures Pic on Pic.IDCard = P.id">
    </asp:SqlDataSource>
    

    
    <asp:SqlDataSource ID="SqlDataBasketSummary" runat="server" ConnectionString="<%$ ConnectionStrings:ShopConnectionString2 %>" SelectCommand="select round(min(price),0)-1 as MinPrice, round(max(price),0)+1 as MixPrice from Product">
    </asp:SqlDataSource>
    

    
</asp:Content>
