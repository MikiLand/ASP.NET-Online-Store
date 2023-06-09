﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="OrderDetails.aspx.cs" Inherits="Sklep.OrderDetails" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <section>
        <div style="height: 10px;">

        </div>
        <div class="container">
            <div class="row">
                <div class="col-md-9">
                    <asp:DataList ID="DataListBasket" runat="server" DataSourceID="SqlDataOrder" RepeatColumns="1" RepeatDirection="Horizontal">
                        <ItemTemplate>
                            <div class="container">
                                <div class="row">
                                    <div class="col-md-3">
                                        <img src='<%# Eval("Path")%>' class="img-fluid" height="200" href="HomePage.aspx"/>
                                    </div>

                                    <div class="col-md-9">
                                        <asp:Label ID="Label3" runat="server" Text='<%# Eval("Name") %>'></asp:Label>
                                        <br />

                                        <div class="input-group mb-1">
                                            <label>Net:&nbsp;</label>
                                            <asp:Label ID="Label2" runat="server" Text='<%# Eval("net") %>'></asp:Label>
                                        </div>
                                        <div class="input-group mb-1">
                                            <label>Gross:&nbsp;</label>
                                            <asp:Label ID="Label5" runat="server" Text='<%# Eval("gross") %>'></asp:Label>
                                        </div>
                                        <div class="input-group mb-1">
                                            <label>Amount:&nbsp;</label>
                                            <asp:Label ID="Label1" runat="server" Text='<%# Eval("amount") %>'></asp:Label>
                                        </div>
                                        <br />
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
                                <asp:Label ID="LblPromoCodeDescription" runat="server" Visible="false" >Code value:&nbsp;</asp:Label>
                                <asp:Label ID="LblPromoCodeValue" runat="server" Visible="false"></asp:Label>
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
    <asp:SqlDataSource ID="SqlDataOrder" runat="server" ConnectionString="<%$ ConnectionStrings:ShopConnectionString2 %>" SelectCommand="select top 1 OP.id_order as id, op.net, op.gross, p.name, p.description, Pic.Path, op.amount from OrderPosition OP
left join Product p on p.id = op.id_product
left join Pictures Pic on Pic.IDCard = P.id">
    </asp:SqlDataSource>
</asp:Content>
