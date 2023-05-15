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
                                            <asp:TextBox class="form-control" ID="TBAmount" runat="server" Enabled="false" Style="width: 40px;" Text='<%# Eval("Amount") %>' ></asp:TextBox>
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
                            <asp:Label ID="Label4" runat="server" Text='Summary:'></asp:Label>
                            <br />
                            <div class="input-group mb-1">
                                <label>Partial price:&nbsp;</label>
                                <asp:Label ID="LblPartialPrice" runat="server" Text='<%# Eval("PartialPrice") %>'></asp:Label>
                                <label>$</label>
                            </div>

                            <div class="input-group mb-1">
                                <label>Delivery:&nbsp;</label>
                                <asp:Label ID="LblDelivery" runat="server"></asp:Label>
                                <label>$</label>
                            </div>

                            <div class="row">
                                <div class="col">
                                    <center>
                                        <hr />
                                    </center>
                                </div>
                            </div>

                            <label>Promo code:</label>
                            <div class="input-group mb-1">
                                <asp:TextBox class="form-control" ID="TBAmount" runat="server" Style="width: 100px;"></asp:TextBox>
                                <asp:Button Class="btn d-grid gap-2 btn-primary btn-block btn-lgmt-3 mt-3" Style="width: 100px;" ID="BtnReedem" OnClick="BtnReedemOnClick" runat="server" Text="Reedem" />
                            </div>
                            <div class="input-group mb-1">
                                <asp:Label ID="Label2" runat="server" Visible="false" Text="Code value:"> </asp:Label>
                                <asp:Label ID="Label1" runat="server" Visible="false"></asp:Label>
                                <asp:Label ID="Label5" runat="server" Visible="false" Text="$"> </asp:Label>
                            </div>

                            <div class="row">
                                <div class="col">
                                    <center>
                                        <hr />
                                    </center>
                                </div>
                            </div>

                            <div class="input-group mb-1">
                                <label>Total:&nbsp;</label>
                                <asp:Label ID="LblTotal" runat="server"></asp:Label>
                                <label>$</label>
                            </div>
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
</asp:Content>
