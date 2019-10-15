<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm2.aspx.cs" Inherits="WebApplication2Paginas.WebForm2" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataKeyNames="nifAlumno,periodo" DataSourceID="SqlDataSource2">
                <Columns>
                    <asp:CommandField ShowDeleteButton="True" ShowEditButton="True" />
                    <asp:BoundField DataField="nifAlumno" HeaderText="nifAlumno" ReadOnly="True" SortExpression="nifAlumno" />
                    <asp:BoundField DataField="periodo" HeaderText="periodo" ReadOnly="True" SortExpression="periodo" />
                    <asp:BoundField DataField="fol" HeaderText="fol" SortExpression="fol" />
                    <asp:BoundField DataField="ret" HeaderText="ret" SortExpression="ret" />
                    <asp:BoundField DataField="ina" HeaderText="ina" SortExpression="ina" />
                    <asp:BoundField DataField="fpr" HeaderText="fpr" SortExpression="fpr" />
                    <asp:BoundField DataField="ral" HeaderText="ral" SortExpression="ral" />
                    <asp:BoundField DataField="sim" HeaderText="sim" SortExpression="sim" />
                </Columns>
            </asp:GridView>
            <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConflictDetection="CompareAllValues" ConnectionString="<%$ ConnectionStrings:ConnectionString3 %>" DeleteCommand="DELETE FROM [Notas] WHERE ([nifAlumno] = ? AND [periodo] = ?)" InsertCommand="INSERT INTO [Notas] ([nifAlumno], [periodo], [fol], [ret], [ina], [fpr], [ral], [sim]) VALUES (?, ?, ?, ?, ?, ?, ?, ?)" OldValuesParameterFormatString="original_{0}" ProviderName="<%$ ConnectionStrings:ConnectionString3.ProviderName %>" SelectCommand="SELECT * FROM [Notas] WHERE (([nifAlumno] LIKE '%' + ? + '%') AND ([periodo] = ?)) ORDER BY [nifAlumno]" UpdateCommand="UPDATE [Notas] SET [fol] = ?, [ret] = ?, [ina] = ?, [fpr] = ?, [ral] = ?, [sim] = ? WHERE ([nifAlumno] = ? AND [periodo] = ?)">
                <DeleteParameters>
                    <asp:Parameter Name="original_nifAlumno" Type="String" />
                    <asp:Parameter Name="original_periodo" Type="String" />
                    
                </DeleteParameters>
                <InsertParameters>
                    <asp:Parameter Name="nifAlumno" Type="String" />
                    <asp:Parameter Name="periodo" Type="String" />
                    <asp:Parameter Name="fol" Type="Byte" />
                    <asp:Parameter Name="ret" Type="Byte" />
                    <asp:Parameter Name="ina" Type="Byte" />
                    <asp:Parameter Name="fpr" Type="Byte" />
                    <asp:Parameter Name="ral" Type="Byte" />
                    <asp:Parameter Name="sim" Type="Byte" />
                </InsertParameters>
                <SelectParameters>
                    <asp:SessionParameter Name="nifAlumno" SessionField="alumno" Type="String" />
                    <asp:SessionParameter Name="periodo" SessionField="periodo" Type="String" />
                </SelectParameters>
                <UpdateParameters>
                    <asp:Parameter Name="fol" Type="Byte" />
                    <asp:Parameter Name="ret" Type="Byte" />
                    <asp:Parameter Name="ina" Type="Byte" />
                    <asp:Parameter Name="fpr" Type="Byte" />
                    <asp:Parameter Name="ral" Type="Byte" />
                    <asp:Parameter Name="sim" Type="Byte" />
                    <asp:Parameter Name="original_nifAlumno" Type="String" />
                    <asp:Parameter Name="original_periodo" Type="String" />
                    <asp:Parameter Name="original_fol" Type="Byte" />
                    <asp:Parameter Name="original_fol" Type="Byte" />
                    <asp:Parameter Name="original_ret" Type="Byte" />
                    <asp:Parameter Name="original_ret" Type="Byte" />
                    <asp:Parameter Name="original_ina" Type="Byte" />
                    <asp:Parameter Name="original_ina" Type="Byte" />
                    <asp:Parameter Name="original_fpr" Type="Byte" />
                    <asp:Parameter Name="original_fpr" Type="Byte" />
                    <asp:Parameter Name="original_ral" Type="Byte" />
                    <asp:Parameter Name="original_ral" Type="Byte" />
                    <asp:Parameter Name="original_sim" Type="Byte" />
                    <asp:Parameter Name="original_sim" Type="Byte" />
                </UpdateParameters>
            </asp:SqlDataSource>
            <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString2 %>" ProviderName="<%$ ConnectionStrings:ConnectionString2.ProviderName %>" SelectCommand="SELECT * FROM [Notas] WHERE (([nifAlumno] = ?) AND ([periodo] = ?)) ORDER BY [nifAlumno]">
                <SelectParameters>
                    <asp:QueryStringParameter Name="nifAlumno" QueryStringField="alumno" Type="String" />
                    <asp:QueryStringParameter Name="periodo" QueryStringField="periodo" Type="String" />
                </SelectParameters>
            </asp:SqlDataSource>
        </div>
    </form>
</body>
</html>
