<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Inicio.aspx.cs" Inherits="CRUDingrid.Inicio" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <Table>
                <tr>
                    <td>
                        <asp:Label ID="lbNombre" runat="server" Text="Nombre"></asp:Label>
                    </td>
                    <td colspan="2">
                        <asp:TextBox ID="txtNombre" runat="server"></asp:TextBox>
                    </td>
                </tr>

                 <tr>
                    <td>
                        <asp:Label ID="lbprecio" runat="server" Text="Precio"></asp:Label>
                    </td>
                    <td colspan="2">
                        <asp:TextBox ID="txtPrecio" runat="server"></asp:TextBox>
                    </td>
                </tr>

                 <tr>
                    <td>
                        <asp:Label ID="lbCantidad" runat="server" Text="Cantidad"></asp:Label>
                    </td>
                    <td colspan="2">
                        <asp:TextBox ID="txtCantidad" runat="server"></asp:TextBox>
                    </td>
                </tr>

                 <tr>
                    <td>
                        <asp:Label ID="lbDescripcion" runat="server" Text="Descripción"></asp:Label>
                    </td>
                    <td colspan="2">
                        <asp:TextBox ID="txtDescripcion" runat="server"></asp:TextBox>
                    </td>
                </tr>

                <tr>
                    <td></td>
                    <td colspan="3">
                        <asp:Button ID="btnGuardar" runat="server" Text="Guardar" />
                        <asp:Button ID="btnEliminar" runat="server" Text="Eliminar" />
                        <asp:Button ID="btnLimpiar" runat="server" Text="Limpiar" />
                    </td>
                </tr>

                <tr>
                    <td></td>
                    <td colspan="2">
                        <asp:Label ID="lbExito" runat="server" Text="" ForeColor="Green"></asp:Label>
                    </td>
                </tr>
                 <tr>
                    <td></td>
                    <td colspan="2">
                        <asp:Label ID="lbError" runat="server" Text="" ForeColor="Red"></asp:Label>
                    </td>
                </tr>

            </Table>

            <br/. />
            <asp:GridView ID="gvDiscos" runat="server" AutoGenerateColumns="false" Width="428px">
                <Columns>
                    <asp:BoundField DataField="Nombre" HeaderText="Nombre" />
                    <asp:BoundField DataField="Precio" HeaderText="Precio" />
                    <asp:BoundField DataField="Cantidad" HeaderText="Cantidad" />
                    <asp:BoundField DataField="Descripcion" HeaderText="Descripción" />
                    <asp:TemplateField>
                        <ItemTemplate>
                            <asp:LinkButton Text="Seleccionar" ID="lnkSeleccionar" CommandArgument='<% Eval("iddisco") %>' runat="server" />
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
        </div>
    </form>
</body>
</html>
