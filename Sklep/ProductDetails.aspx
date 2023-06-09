﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="ProductDetails.aspx.cs" Inherits="Sklep.ProductDetails" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <section>
        <div class="container">
            <div class="row">
                <div style="height: 15px;">

                </div>
                <div class="col-md-3">
                    <asp:DataList ID="DataListProduct" runat="server" DataSourceID="SqlDataProducts">
                        <ItemTemplate>
                            <a class="">
                                <img height="300" src='<%# Eval("Path")%>' class="img-fluid" commandargument='<%# Eval("id") %>' Commandname="ToProductPage" />
                            </a>
                        </ItemTemplate>
                    </asp:DataList>


                </div>
                <div class="col-md-9">
                    <asp:DataList ID="DataList1" runat="server" DataSourceID="SqlDataProducts">
                        <ItemTemplate>
                            <asp:Label ID="Label3" runat="server" Text='<%# Eval("Name") %>'></asp:Label>
                            <br />
                            <asp:Label ID="Label4" runat="server" Text='<%# Eval("Price") %>'></asp:Label>
                            <br />
                            <asp:Label ID="Label1" runat="server" Text='<%# Eval("Description") %>'></asp:Label>

                            <asp:Button Class="btn d-grid gap-2 btn-primary btn-block btn-lgmt-3 mt-1" Style="width: 150px;"  ID="BtnAddToBasket" runat="server" Text="Add to basket" OnClick="BtnAddToBasketOnClick"/>
                        </ItemTemplate>
                    </asp:DataList>
                </div>
                <div style="height: 50px;">

                </div>
            </div>
        </div>

    </section>
    <asp:SqlDataSource ID="SqlDataProducts" runat="server" ConnectionString="<%$ ConnectionStrings:ShopConnectionString2 %>" SelectCommand="select top 1 p.id, p.Name, p.Description, tp.TypeName as Type, p.Price, pic.Path
from Product p
left join ProductType tp on tp.id = p.Type
left join Pictures Pic on Pic.IDCard = P.id 
        WHERE (p.id = @id)">
        <SelectParameters>
            <asp:QueryStringParameter Name="id" QueryStringField="id" Type="Int32" />
        </SelectParameters>
    </asp:SqlDataSource>
</asp:Content>
