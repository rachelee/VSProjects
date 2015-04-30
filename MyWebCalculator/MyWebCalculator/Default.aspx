<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="MyWebCalculator._Default" %>

<asp:Content runat="server" ID="FeaturedContent" ContentPlaceHolderID="FeaturedContent">
    <section class="featured">
        <div class="content-wrapper">
            <hgroup class="title">
                <h1>Calculator</h1>
            </hgroup>
            <p>
                Using this web calculator to do basic calculations.</p>
        </div>
    </section>
</asp:Content>
<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="MainContent">
    <p style="font-size: large">
        <asp:LoginView ID="LoginView1" runat="server">
            <AnonymousTemplate>
                You are not logged in. Please login to use web calculator.<br />
                <asp:LoginStatus ID="LoginStatus2" runat="server" />
                &nbsp;<asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="~/Account/Register.aspx">Register</asp:HyperLink>
                <br />
                <br />
            </AnonymousTemplate>
            <LoggedInTemplate>
                You are logged in. How you can use the calculator.
                <asp:LoginName ID="LoginName1" runat="server" />
                <br />
                <asp:LoginStatus ID="LoginStatus1" runat="server" />
                <br />
            </LoggedInTemplate>
        </asp:LoginView>
    </p>
<p style="font-size: large">
        &nbsp;</p>
<p style="font-size: large">
                <br __designer:mapid="27" />
                <asp:Label ID="Label_Op" runat="server"></asp:Label>
                <br __designer:mapid="29" />
                <asp:TextBox ID="Result" runat="server" Width="541px" CssClass="auto-style1">0</asp:TextBox>
                <br __designer:mapid="2b" class="auto-style1" />
                <asp:Button ID="Number7" runat="server" OnClick="buttonClick" Text="7" Width="62px" CssClass="auto-style1" />
                <asp:Button ID="Number8" runat="server" OnClick="buttonClick" Text="8" Width="62px" CssClass="auto-style1" />
                <asp:Button ID="Number9" runat="server" OnClick="buttonClick" Text="9" Width="62px" CssClass="auto-style1" />
                <asp:Button ID="Divide" runat="server" Text="/" Width="62px" CssClass="auto-style1" OnClick="operatorClick" />
                <asp:Button ID="Clear" runat="server" Text="C" Width="62px" CssClass="auto-style1" OnClick="Clear_Click" />
                <asp:Button ID="Sin" runat="server" Text="sin" Width="62px" OnClick="Sin_Click" CssClass="auto-style1" />
                <asp:Button ID="Cos" runat="server" Text="cos" Width="62px" CssClass="auto-style1" OnClick="Cos_Click" />
                <asp:Button ID="Tan" runat="server" Text="tan" Width="62px" CssClass="auto-style1" OnClick="Tan_Click" />
                <br __designer:mapid="34" class="auto-style1" />
                <asp:Button ID="Number4" runat="server" OnClick="buttonClick" Text="4" Width="62px" CssClass="auto-style1" />
                <asp:Button ID="Number5" runat="server" OnClick="buttonClick" Text="5" Width="62px" CssClass="auto-style1" />
                <asp:Button ID="Number6" runat="server" OnClick="buttonClick" Text="6" Width="62px" CssClass="auto-style1" />
                <asp:Button ID="Multiply" runat="server" Text="*" Width="62px" CssClass="auto-style1" OnClick="operatorClick" />
                <asp:Button ID="ClearEntry" runat="server" Text="CE" Width="62px" CssClass="auto-style1" OnClick="ClearEntry_Click" />
                <asp:Button ID="X2" runat="server" Text="x^2" Width="62px" CssClass="auto-style1" OnClick="X2_Click" />
                <asp:Button ID="X3" runat="server" Text="x^3" Width="62px" CssClass="auto-style1" OnClick="X3_Click" />
                <asp:Button ID="Reciprocal" runat="server" Text="1/x" Width="62px" CssClass="auto-style1" OnClick="Reciprocal_Click" />
                <br __designer:mapid="3d" class="auto-style1" />
                <asp:Button ID="Number1" runat="server" OnClick="buttonClick" Text="1" Width="62px" CssClass="auto-style1" />
                <asp:Button ID="Number2" runat="server" OnClick="buttonClick" Text="2" Width="62px" CssClass="auto-style1" />
                <asp:Button ID="Number3" runat="server" OnClick="buttonClick" Text="3" Width="62px" CssClass="auto-style1" />
                <asp:Button ID="Minus" runat="server" Text="-" Width="62px" CssClass="auto-style1" OnClick="operatorClick" />
                <asp:Button ID="Pi" runat="server" Text="Pi" Width="62px" CssClass="auto-style1" OnClick="Pi_Click" />
                <asp:Button ID="Sqrt" runat="server" Text="Sqrt" Width="62px" CssClass="auto-style1" OnClick="Sqrt_Click" />
                <asp:Button ID="Log" runat="server" Text="ln x" Width="132px" CssClass="auto-style1" OnClick="Log_Click" />
                <br __designer:mapid="45" class="auto-style1" />
                <asp:Button ID="Number0" runat="server" OnClick="buttonClick" Text="0" Width="135px" CssClass="auto-style1" />
                <asp:Button ID="Dot" runat="server" OnClick="pointClick" Text="." Width="62px" CssClass="auto-style1" />
                <asp:Button ID="Plus" runat="server" Text="+" Width="62px" CssClass="auto-style1" OnClick="operatorClick" />
                <asp:Button ID="EqualTo" runat="server" Text="=" Width="132px" CssClass="auto-style1" OnClick="EqualTo_Click" />
                <asp:Button ID="Backspace" runat="server" Text="Backspace" Width="132px" CssClass="auto-style1" OnClick="Backspace_Click" />
    </p>
</asp:Content>
<asp:Content ID="Content1" runat="server" contentplaceholderid="HeadContent">
    <style type="text/css">
    .auto-style1 {
        font-size: small;
    }
</style>
</asp:Content>

