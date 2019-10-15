<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" Inherits="WebApplication2Paginas.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <style type="text/css">
        .auto-style1 {
            width: 243px;
        }
        .auto-style2 {
            width: 316px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <table style="width: 100%;">
                <tr>
                    <td class="auto-style1">
                        <asp:Label ID="Label1" runat="server" Text="Alumnos"></asp:Label>
                    </td>
                    <td class="auto-style2">
                        <asp:Label ID="Label2" runat="server" Text="Evaluación"></asp:Label>
                    </td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td class="auto-style1">
                        <asp:ListBox ID="ListBox1" runat="server" DataSourceID="SqlDataSource1" DataTextField="nombre" DataValueField="nif" Height="97px" Width="209px"></asp:ListBox>
                        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString %>" ProviderName="<%$ ConnectionStrings:ConnectionString.ProviderName %>" SelectCommand="SELECT [nif], [nombre] FROM [Alumnos] WHERE ([baja] = ?) ORDER BY [nombre]">
                            <SelectParameters>
                                <asp:Parameter DefaultValue="false" Name="baja" Type="Boolean" />
                            </SelectParameters>
                        </asp:SqlDataSource>
                    </td>
                    <td class="auto-style2">
                        <asp:DropDownList ID="DropDownList1" runat="server" Width="160px">
                            <asp:ListItem Value="1">Evaluación 1</asp:ListItem>
                            <asp:ListItem Value="2">Evaluación 2</asp:ListItem>
                            <asp:ListItem Value="3">Evaluación 3</asp:ListItem>
                            <asp:ListItem Value="J">Junio</asp:ListItem>
                            <asp:ListItem Value="S">Septiembre</asp:ListItem>
                        </asp:DropDownList>
                    </td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td class="auto-style1">
                        <asp:CheckBox ID="CheckBox1" runat="server" AutoPostBack="True" OnCheckedChanged="CheckBox1_CheckedChanged" Text="Todos" />
                    </td>
                    <td class="auto-style2">
                        <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Ver Notas" />
                    </td>
                    <td>&nbsp;</td>
                </tr>
            </table>
        </div>
    </form>
</body>
</html>
