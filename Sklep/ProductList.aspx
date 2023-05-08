<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="ProductList.aspx.cs" Inherits="Sklep.TermsAndConditions" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <section>
        <div class="container-fluid">
            <div class="row">
                <div class="col-md-3">
                    <!--<center>
                        <br /><h1>"Two words my friend<br />
                        No refunds"</h1><br />
                        <h3>September 18, 2012 ~ Marcus</h3>
                    </center>-->
                    <center>
                        <h3>Products</h3>
                    </center>
                    <br />

                    <label>Products type:</label>
                    <div class="form-check">
                      <input class="form-check-input" type="checkbox" value="" id="flexCheckChecked" checked>
                      <label class="form-check-label" for="flexCheckChecked">
                        Candle
                      </label>
                    </div>
                    <div class="form-check">
                      <input class="form-check-input" type="checkbox" value="" id="flexCheckChecked" checked>
                      <label class="form-check-label" for="flexCheckChecked">
                        Scent
                      </label>
                    </div>
                    <div class="form-check">
                      <input class="form-check-input" type="checkbox" value="" id="flexCheckChecked" checked>
                      <label class="form-check-label" for="flexCheckChecked">
                        Other
                      </label>
                    </div>

                    <br />
                    
                    
                    <label>Price up to: </label><label id="LblPrice"></label><label>$</label>
                    <input type="range" class="form-range" min="0" max="50" id="RangePrice">
                    <script>
                        var slider = document.getElementById("RangePrice");
                        var output = document.getElementById("LblPrice");
                        output.innerHTML = slider.value;

                        slider.oninput = function() {
                        output.innerHTML = this.value;
                        }
                    </script>

                    <div class="form-check">
                      <input class="form-check-input" type="radio" name="flexRadioDefault" id="flexRadioDefault2" checked>
                      <label class="form-check-label" for="flexRadioDefault2">
                        Name ascending
                      </label>
                    </div>
                    <div class="form-check">
                      <input class="form-check-input" type="radio" name="flexRadioDefault" id="flexRadioDefault1">
                      <label class="form-check-label" for="flexRadioDefault1">
                        Name descending
                      </label>
                    </div>
                    <div class="form-check">
                      <input class="form-check-input" type="radio" name="flexRadioDefault" id="flexRadioDefault1">
                      <label class="form-check-label" for="flexRadioDefault1">
                        Price ascending
                      </label>
                    </div>
                    <div class="form-check">
                      <input class="form-check-input" type="radio" name="flexRadioDefault" id="flexRadioDefault1">
                      <label class="form-check-label" for="flexRadioDefault1">
                        Price descending
                      </label>
                    </div>
                    <div class="form-check">
                      <input class="form-check-input" type="radio" name="flexRadioDefault" id="flexRadioDefault1">
                      <label class="form-check-label" for="flexRadioDefault1">
                        Product type
                      </label>
                    </div>
                    
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
