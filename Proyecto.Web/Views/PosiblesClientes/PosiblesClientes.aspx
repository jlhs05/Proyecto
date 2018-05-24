<%@ Page Title="" Language="C#" MasterPageFile="~/Resources/Template/Template.Master" AutoEventWireup="true" CodeBehind="PosiblesClientes.aspx.cs" Inherits="Proyecto.Web.Views.PosiblesClientes.PosiblesClientes" %>
<asp:Content ID="ContentHeader" ContentPlaceHolderID="header" runat="server" >
<script src="../../css/sweetalert.css" type="text/javascript"></script>
<link href="../../css/sweetalert.css" type="text/css" rel="stylesheet" />
</asp:Content>

<asp:Content ID="Content1" ContentPlaceHolderID="contenedor" runat="server">

    <div class="mx-auto mt-5">
        <%-- PRIMERA SECCION --%>
        
        <div class="form-group">
            <div class="form-row">
                <div class="col-md-12">
                    <h1>
                        <b> Posibles clientes</b>
                        <asp:Label runat="server" ID="lblOpcion" Visible="false"></asp:Label>
                    </h1>
                </div>
            </div>
        </div>

        <div class="form-group">
            <div class="form-row">
                <div class="col-md-3">
                    <asp:Label runat="server" ID="lblIdentificacion" Text="Identificación"></asp:Label>
                    <asp:TextBox runat="server" ID="txtIdentificacion" CssClass="form-control"></asp:TextBox>
                </div>
                <div class="col-md-3">
                    <asp:Label runat="server" ID="lblEmpresa" Text="Empresa"></asp:Label>
                    <asp:TextBox runat="server" ID="txtEmpresa" CssClass="form-control"></asp:TextBox>
                </div>
                <div class="col-md-3">
                    <asp:Label runat="server" ID="lblPrimerNombre" Text="Primer Nombre"></asp:Label>
                    <asp:TextBox runat="server" ID="txtPrimerNombre" CssClass="form-control"></asp:TextBox>
                </div>
                <div class="col-md-3">
                    <asp:Label runat="server" ID="lblSegundoNombre" Text="Segundo Nombre"></asp:Label>
                    <asp:TextBox runat="server" ID="txtSegundoNombre" CssClass="form-control"></asp:TextBox>
                </div>
            </div>
        </div>
        <%-- SEGUNDA SECCION --%>
        <div class="form-group">
            <div class="form-row">
                <div class="col-md-3">
                    <asp:Label runat="server" ID="lblPimeroApellido" Text="PrimerApellido"></asp:Label>
                    <asp:TextBox runat="server" ID="txtPrimerApellido" CssClass="form-control"></asp:TextBox>
                </div>
                <div class="col-md-3">
                    <asp:Label runat="server" ID="lblSegundoApellido" Text="Segundo Apellido"></asp:Label>
                    <asp:TextBox runat="server" ID="txtSegundoApellido" CssClass="form-control"></asp:TextBox>
                </div>
                <div class="col-md-3">
                    <asp:Label runat="server" ID="lblDireccion" Text="Direccion"></asp:Label>
                    <asp:TextBox runat="server" ID="txtDireccion" CssClass="form-control"></asp:TextBox>
                </div>
                <div class="col-md-3">
                    <asp:Label runat="server" ID="lblTelefono" Text="Telefono"></asp:Label>
                    <asp:TextBox runat="server" ID="txtTelefono" CssClass="form-control"></asp:TextBox>
                </div>
            </div>
        </div>
        <%-- TERCERA SECCION --%>
        <div class="form-group">
            <div class="form-row">
                <div class="col-md-12">
                    <asp:Label runat="server" ID="lblCorreo" Text="Email"></asp:Label>
                    <asp:TextBox runat="server" ID="txtCorreo" CssClass="form-control"></asp:TextBox>
                </div>
            </div>
        </div>
        <%-- CUARTA SECCION --%>
        <div class="form-group">
            <div class="form-row">
                <div class="col-md-12">
                    <asp:Button runat="server" ID="btnGuardar" Text="Guardar" CssClass="btn btn-primary" OnClick="btnGuardar_Click"/>
                    <asp:Button runat="server" ID="btnCancelar" Text="Cancelar" CssClass="btn btn-primary" OnClick="btnCancelar_Click" />
                </div>
            </div>
        </div>
        <%-- QUINTA SECCION--%>
        <div class="form-group">
            <div class="form-row">
                <div class="col-md-12">
                    <h3> Resultados</h3>
                </div>
            </div>
        </div>
        <div class="form-group">
            <div class="form-row">
                <div class="col-md-12" style="overflow:auto">
                   <asp:GridView runat="server" ID="gvwDatos" Width="100%" 
                       AutoGenerateColumns="False" 
                       EmptyDataText="No se Encontraron Registros" 
                       BackColor="White" 
                       BorderColor="#3366CC" 
                       BorderStyle="None" 
                       BorderWidth="1px" 
                       CellPadding="4" 
                       GridLines="Vertical" OnRowCommand="gvwDatos_RowCommand">
                       
                       <Columns>
                           <%--Representacion de datos en controles WEB--%>
                           <asp:TemplateField HeaderText="Identificacion">
                               <ItemTemplate>
                                   <asp:Label runat="server" ID="lblIdentificacion" Text='<%# Bind("Identificacion") %>'></asp:Label>
                               </ItemTemplate>
                           </asp:TemplateField>
                           <%--REPRESENTACION DE DATOS EN CELDAS--%>
                          <asp:BoundField HeaderText="Empresa" DataField="Empresa" />
                           <asp:BoundField HeaderText="Primer nombre" DataField="PrimerNombre" />
                           <asp:BoundField HeaderText="Segundo Nombre" DataField="SegundoNombre" />
                           <asp:BoundField HeaderText="Primer Apeliido" DataField="PrimerApellido" />
                           <asp:BoundField HeaderText="Segundo Apellido" DataField="SegundoApellido" />
                           <asp:BoundField HeaderText="Direccion" DataField="Direccion" />
                           <asp:BoundField HeaderText="Telefono" DataField="Telefono" />
                           <asp:BoundField HeaderText="Email" DataField="Correo" />

                           <%--COLUMNA EDITAR
                              Propiedades:
                             "CommandName"=> agrega un ImageButton por cada fila,y se peude tener varios controles
                               web dentro de una fila y poper identificar cual de esos controles el usuario hizo click
                              "CommandArgument=>identificar sobre cual fila se preciono ese boton",
                               asi mismo el GridView comienza a representar las filas en posicion 0, como 
                               si fuera un vector
                               --%>
                            <asp:TemplateField HeaderText="Editar">
                               <ItemTemplate>
                                  <asp:ImageButton runat="server" ID="ibEditar" Width="15px" Height="15px" ImageUrl="~/Resources/Images/editar.png" 
                                      CommandName="Editar" CommandArgument="<%#((GridViewRow)Container).RowIndex %>" />
                               </ItemTemplate>
                                <ItemStyle HorizontalAlign="Center"/>
                           </asp:TemplateField>

                           <%--ELIMINAR--%>
                           <asp:TemplateField HeaderText="Eliminar">
                               <ItemTemplate>
                                  <asp:ImageButton runat="server" ID="ibEliminar" Width="15px" Height="15px" ImageUrl="~/Resources/Images/eliminar.png" 
                                      CommandName="Eliminar" CommandArgument="<%#((GridViewRow)Container).RowIndex %>" />
                               </ItemTemplate>
                                <ItemStyle HorizontalAlign="Center"/>
                           </asp:TemplateField>


                       </Columns>


                       <FooterStyle BackColor="#99CCCC" ForeColor="#003399" />
                       <HeaderStyle BackColor="#003399" Font-Bold="True" ForeColor="#CCCCFF" />
                       <PagerStyle BackColor="#99CCCC" ForeColor="#003399" HorizontalAlign="Left" />
                       <RowStyle BackColor="White" ForeColor="#003399" />
                       <SelectedRowStyle BackColor="#009999" Font-Bold="True" ForeColor="#CCFF99" />
                       <SortedAscendingCellStyle BackColor="#EDF6F6" />
                       <SortedAscendingHeaderStyle BackColor="#0D4AC4" />
                       <SortedDescendingCellStyle BackColor="#D6DFDF" />
                       <SortedDescendingHeaderStyle BackColor="#002876" />


                   </asp:GridView>
                </div>
            </div>
        </div>



    </div>

</asp:Content>
