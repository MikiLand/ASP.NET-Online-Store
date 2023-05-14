<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="Basket.aspx.cs" Inherits="Sklep.Basket" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <section>
        <div style="height: 10px;">

        </div>
        <div class="container">
            <div class="row">
                <div class="col-md-9">
                    <asp:DataList ID="DataListProduct" runat="server" DataSourceID="SqlDataBasket" RepeatColumns="1" RepeatDirection="Horizontal">
                        <ItemTemplate>
                            <div class="container">
                                <div class="row">
                                    <div class="col-md-3">
                                        <img src='<%# Eval("Path")%>' class="img-fluid" height="200" href="HomePage.aspx"/>
                                    </div>

                                    <div class="col-md-9">
                                        <asp:Label ID="Label3" runat="server" Text='<%# Eval("Name") %>'></asp:Label>
                                        <br />
                                        <asp:Label ID="Label4" runat="server" Text='<%# Eval("Price") %>'></asp:Label>
                                        <div class="input-group mb-1">
                                            <asp:Button Class="btn d-grid gap-2 btn-primary btn-block btn-lgmt-3 mt-3" Style="width: 30px;" ID="BtnUpdateProduct" OnClick="BtnBasketMoreOnClick" runat="server" Text="+" />
                                            <asp:TextBox class="form-control" ID="TBAmount" runat="server" Enabled="false" Style="width: 40px;"></asp:TextBox>
                                            <asp:Button Class="btn d-grid gap-2 btn-primary btn-block btn-lgmt-3 mt-3" Style="width: 30px;" ID="Button1" OnClick="BtnBasketLessOnClick" runat="server" Text="-" />
                                        </div>
                                        <br />
                                        <asp:Button Class="btn d-grid gap-2 btn-danger btn-block btn-lgmt-3 mt-1" Style="width: 150px;"  ID="BtnDeleteProduct" OnClick="BtnDeleteFromBasketOnClick" runat="server" Text="Delete" />
                                    </div>
                                    <div class="row">
                                        <div class="col">
                                            <center>
                                                <hr />
                                            </center>
                                        </div>
                                    </div>
                            </div>
                        </ItemTemplate>
                    </asp:DataList>
                </div>

                <div class="col-md-3">
                    <div style="height: 15px;">

                    </div>
                    <div class="card">
                        <div class="card-body">
                            <asp:Label ID="Label4" runat="server" Text='Test'></asp:Label>
                        </div>
                    </div>
                </div>

                
                <div style="height: 50px;">

                </div>
            </div>
        </div>

    </section>
    <asp:SqlDataSource ID="SqlDataBasket" runat="server" ConnectionString="<%$ ConnectionStrings:ShopConnectionString2 %>" SelectCommand="select top 1 id_user, p.Name, p.Description, p.Price, b.Amount, p.Price, b.Amount, p.Price * b.Amount as Value, pic.Path  from Basket b
left join Product p on p.id = b.id_product
left join Pictures Pic on Pic.IDCard = P.id">
    </asp:SqlDataSource>
    

    
    <asp:SqlDataSource ID="SqlDataBasketSummary" runat="server" ConnectionString="<%$ ConnectionStrings:ShopConnectionString2 %>" SelectCommand="select round(min(price),0)-1 as MinPrice, round(max(price),0)+1 as MixPrice from Product">
    </asp:SqlDataSource>
    

    
</asp:Content>
