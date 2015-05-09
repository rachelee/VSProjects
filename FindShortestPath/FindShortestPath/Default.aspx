<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="FindShortestPath._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <p>
        <asp:Label ID="Label1" runat="server" Text="Find Shortest Path To Emergency"></asp:Label>
        <br />
        <asp:TextBox ID="address" runat="server"></asp:TextBox>
    </p>
    <p>
        <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Find" />
    </p>
    <p>
        &nbsp;</p>
    <p>
        <asp:Label ID="HospitalName" runat="server"></asp:Label>
    </p>
    <div id="div1" runat="server">
        
        
       
    
        
        
        
    </div>
    <p>
        &nbsp;</p>

</asp:Content>
