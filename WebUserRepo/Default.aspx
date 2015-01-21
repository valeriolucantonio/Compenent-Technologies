<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true"
    CodeBehind="Default.aspx.cs" Inherits="WebUserRepo._Default" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
    <h2>
        <asp:CheckBox ID="checkBoxAll" runat="server" 
            oncheckedchanged="checkBoxAll_CheckedChanged" Text="all" AutoPostBack="true"/>
        <asp:CheckBox ID="checkBoxJava" runat="server" Text="java" AutoPostBack="true" 
            oncheckedchanged="checkBoxJava_CheckedChanged" />
        <asp:CheckBox ID="checkBoxCOM" runat="server" Text="COM" AutoPostBack="true" 
            oncheckedchanged="checkBoxCOM_CheckedChanged" />
        <asp:CheckBox ID="checkBoxNET" runat="server" Text=".NET" AutoPostBack="true" 
            oncheckedchanged="checkBoxNET_CheckedChanged" />
        <asp:Label ID="Label1" runat="server" Text=""></asp:Label>
        <asp:Label ID="Label2" runat="server" Text="Label"></asp:Label>
    </h2>
    <h2>
        <asp:GridView ID="GridView2" runat="server" Width="298px" >
            <Columns>
                <asp:TemplateField HeaderText="view">
                <ItemTemplate>
                <asp:LinkButton runat="server" ID="Download" OnClick="Download">Download</asp:LinkButton>
                <asp:LinkButton runat="server" ID="Inspect" OnClick="Inspect">Inspect</asp:LinkButton>
                </ItemTemplate>
                </asp:TemplateField>
                                 
            </Columns>
        </asp:GridView>
    </h2>
    <h2>
        <asp:Label ID="Label3" runat="server" Visible="False"></asp:Label>
    </h2>
    <h2>
        <asp:GridView ID="GridView4" runat="server">
        </asp:GridView>
    </h2>
    <h2>
        <asp:GridView ID="GridView5" runat="server">
        </asp:GridView>
    </h2>
    <h2>
        <asp:Label ID="Label4" runat="server"></asp:Label>
        <asp:GridView ID="GridView3" runat="server">
        </asp:GridView>
    </h2>
    </asp:Content>
