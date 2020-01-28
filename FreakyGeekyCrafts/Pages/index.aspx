<%@ Page Title="" Language="C#" MasterPageFile="~/Master/Main.Master" AutoEventWireup="true" CodeBehind="index.aspx.cs" Inherits="FreakyGeekyCrafts.Pages.index" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
      

    <header id="index_header" runat="server">


        <div class="hero">
            <h1>Shop The Latest Fashion Trends</h1>
            <a class="btn" title="Explore Now" href="ProductView.aspx">EXPLORE NOW</a>
        </div>

    </header>
    <div class="discount-banner">
        GET 10% OFF WITH CODE: BUYME2020
    </div>
    <section class="main">
        <aside>
            <div id="helpme" class="content trending">
                <h3><a href="#">See what's trending</a></h3>
                <p>The hot new items of the season are all here, which are all currently flying off the shelves. They go with any outfit and really lets you flaunt your personality. Order today and guarantee that you can get one before they go out of stock.</p>
            </div>
        </aside>

        <aside>
            <div class="content about">
                <h3><a href="#">Find out more about us</a></h3>
                <p>We are a UK based custom jewellery designer for a wide range of products. <br /><br /><br /><br /></p>
        </div>
    </aside>
    <aside>
        <div class="content questions">
            <h3><a href="#">Frequently asked questions</a></h3>
            <p>How much will shipping cost me? Shipping within the UK costs £2 for a purchase, shipping is not currently available for customers outside of the UK.<br /><br /><br /></p>
        </div>
    </aside>

    </section>

    <section class="section-two">
        <article>
            <h2>We stock a wide range of craft jewellery</h2>
            <p>From earrings to rings, we cover a wide range of custom jewellery for that perfect occasion. With low low prices and £2 shipping, you wouldn&#39;t want to miss out on these custom items.</p>
        </article>
        <a id="section-two-btn" class="btn" title="see more" href="ProductView.aspx">SEE MORE</a>
    </section>
    <br />
    <section class="models-image">
        <div class="hero">
            <h1>A HOMEMADE BRAND</h1>
            <a class="btn" title="DISCOVER MORE" href="AboutUs.aspx">DISCOVER MORE</a>
        </div>
    </section>
    <section class="section-three">
        Get Ahead Of The Trends. Shop Now.
        <br>
        <a title="" href="ProductView.aspx">FIND OUT MORE</a>
    </section>
    <script>
        //Enables the header background image to automaticly change at a set interval.
        $(function () {
            var header = $('header');//Sets the html DOM to a variable.
            var backgrounds = [ //An array to store images.
                'url(../Images/fgc_banner_1200.jpg)',
                'url(../Images/fgc_banner2_1200.png)',
                'url(../Images/fgc_banner3_1200.png)'];
            var current = 0;//Current position of the array.

           // Sets the background a specified interval.
            function nextBackground() {
                //Sets fade effect.
                $(header).fadeTo(1000, 0.05, "swing", function () {
                header.css(//Targets the header DOM.
                    'background',
                    backgrounds[current = ++current % backgrounds.length]);                   
                }).delay(500).fadeTo(500, 1, "swing")
                setTimeout(nextBackground, 5000);//Time it takes the images to change.
            }
            setTimeout(nextBackground, 5000);
            header.css('background', backgrounds[0]);
        });

    </script>
</asp:Content>
