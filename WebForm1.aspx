<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" Inherits="Repaso.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        Departamento<br />
        <asp:Label ID="Label1" runat="server" Text="Nombre:"></asp:Label>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:TextBox ID="TB_Depto" runat="server" Width="297px"></asp:TextBox>
        <br />
        <br />
        <asp:Button ID="BTN_DEPTO" runat="server" OnClick="Button1_Click" Text="Guardar Departamento" Width="161px" />
        <br />
        <br />
        Municipio<br />
        Nombre:&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:TextBox ID="TB_MUN" runat="server" Width="292px"></asp:TextBox>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Departamento:&nbsp;&nbsp;&nbsp;
        <asp:DropDownList ID="DDL_MUN_DEPTO" runat="server" DataSourceID="SqlDSDepartamentos" DataTextField="Nombre" DataValueField="IDDepartamento" Height="30px" OnSelectedIndexChanged="DDL_MUN_DEPTO_SelectedIndexChanged" Width="229px" AppendDataBoundItems="true">
            <asp:ListItem Value="0" Text="-- Elige una opción --"></asp:ListItem>
        </asp:DropDownList>
        <br />
        <br />
        <asp:Button ID="BTN_MUN" runat="server" OnClick="BTN_MUN_Click" Text="Guardar Municipio" Width="162px" />
        <br />
        <br />
        Usuario:<br />
        Nombre:&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:TextBox ID="TB_USR" runat="server" Width="288px"></asp:TextBox>
        <br />
        Telefono:&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:TextBox ID="TB_TELUSR" runat="server" style="margin-left: 0px" Width="286px"></asp:TextBox>
        <br />
        Departamento:&nbsp;&nbsp;&nbsp;
        <asp:DropDownList ID="DDL_USR_DEPTO" runat="server" DataSourceID="SqlDSDepartamentos" DataTextField="Nombre" DataValueField="IDDepartamento" Height="17px" Width="273px" AppendDataBoundItems="true" AutoPostBack="True" OnSelectedIndexChanged="DDL_USR_DEPTO_SelectedIndexChanged">
            <asp:ListItem Value="0" Text="-- Elige una opción --"></asp:ListItem>
        </asp:DropDownList>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Municipio:&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:DropDownList ID="DDL_USR_MUN" runat="server" Height="16px" Width="276px" AppendDataBoundItems="True">
            <asp:ListItem Value="0" Text="-- Elige una opción --"></asp:ListItem>
        </asp:DropDownList>
        <asp:SqlDataSource ID="SqlDSMunicipios" runat="server" ConnectionString="<%$ ConnectionStrings:TestConnectionString %>" SelectCommand="SELECT [IDMunicipio], [Nombre] FROM [municipio]"></asp:SqlDataSource>
        <br />
        <br />
        <asp:Button ID="BTN_USR" runat="server" OnClick="BTN_USR_Click" Text="Guardar Usuario" Width="160px" />
        <br />
        <asp:SqlDataSource ID="SqlDSDepartamentos" runat="server" ConnectionString="<%$ ConnectionStrings:TestConnectionString %>" SelectCommand="SELECT [IDDepartamento], [Nombre] FROM [departamento]"></asp:SqlDataSource>
        <br />
        <br />
    </form>
</body>
</html>
