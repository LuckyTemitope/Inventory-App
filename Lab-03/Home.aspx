<%@ Page Title="" Language="C#" MasterPageFile="~/HOME.Master" AutoEventWireup="true" CodeBehind="Home.aspx.cs" Inherits="Lab_03.Home" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <br />

    <div class="landing-page">

        <div class="landing-page-main-text">
            <div class="typewriter">
                <h1>Get your favourite items
                   </h1>
            </div>

            <asp:LinkButton class="viewBtn" runat="server" PostBackUrl="~/Storage.aspx">View Inventory</asp:LinkButton>
            
        </div>

        <div class="hero-image">
            <asp:Image ID="mainImage" runat="server" ImageUrl="~/Assets/lady.jpg" />
        </div>

        <br />
        

    </div>
</asp:Content>
