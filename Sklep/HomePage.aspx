<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="HomePage.aspx.cs" Inherits="Sklep.HomePage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <section>
        <img src="imgs/bg_candles3.png" class="img-fluid w-100" />
    </section>

    <section>
        <div class="container">
            <div class="row">
                <div class="col-12">
                    <center>
                        <div class="mt-5">
                            <h2>Our products</h2>
                        </div>
                       <p><b>Our products are created by the only master of it's kind</b></p>
                    </center>
                </div>
            </div>

            <div class="row pb-3">
                <div class="col-md-4">
                    <center>
                        <img width="150px" src="imgs/candles.png" />
                        <h4>Candles</h4>
                        <p align="justify">We have a wide selection of unique candles to suit every need. Candles are not only a fragrance but also a spiritual journey that you may never experience</p>
                    </center>
                </div>

                <div class="col-md-4">
                    <center>
                        <img width="150px" src="imgs/scents.png" />
                        <h4>Scents</h4>
                        <p align="justify">Our fragrances will create a unique atmosphere and transport your mind to a completely different place, better place</p>
                    </center>
                </div>

                <div class="col-md-4">
                    <center>
                        <img width="150px" src="imgs/file.png" />
                        <h4>Other</h4>
                        <p align="justify">However, do not worry if candles and fragrances are not what you are looking for in the adventure called life. In our store we have much more to offer</p>
                    </center>
                </div>
            </div>
        </div>
    </section>

    <section>
        <img src="imgs/bg_candles4.png" class="img-fluid w-100"/>
    </section>

    <section>
        <div class="container">
            <div class="row">
                <div class="col-12">
                    <center>
                        <div class="mt-5 mb-3">
                            <h2>Those who believe in us</h2>
                        </div>
                    </center>
                </div>
            </div>

            <div class="row pb-5">
                <div class="col-md-4">
                    <center>
                        <img height="300px" src="imgs/joakim.jpg" class="img-fluid" />
                        <div class="mt-3">
                            <h4>Joakim Broden</h4>
                        </div>
                        <p align="justify">One of our first and most loyal customers is Joakim Broden, lead singer of Sabaton. Our paths met when Joakim was struggling with an odour on the set of a music video for a new song and was looking for help, and we delivered. </p>
                    </center>
                </div>

                <div class="col-md-4">
                    <center>
                        <img height="300px" src="imgs/oprah.jpg" class="img-fluid" />
                        <div class="mt-3">
                            <h4>Oprah</h4>
                        </div>
                        <p align="justify">We all know and love Oprah's voice and know that it is absolutely unique, but as she once said, "Not as unique as the scents in World of Smells".</p>
                    </center>
                </div>

                <div class="col-md-4">
                    <center>
                        <img height="300px" src="imgs/kiss1.jpg" class="img-fluid" />
                        <div class="mt-3">
                            <h4>Kiss</h4>
                        </div>
                        <p align="justify">All members of the kiss team love our products and have used them continuously for many years. A little known fact is that in the song "I Was Made For Lovin' You" Paul Stanley refers to our candles as "Baby".</p>
                    </center>
                </div>
            </div>
        </div>
    </section>

</asp:Content>
