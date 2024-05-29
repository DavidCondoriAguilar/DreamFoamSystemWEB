<%@ Page Title="" Language="C#" MasterPageFile="~/DreamMaster.Master" AutoEventWireup="true" CodeBehind="DreamConsEmpleado.aspx.cs" Inherits="DreamWEB.DreamMasterPages.DreamConsEmpleado" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .auto-style1 {
            width: 206px;
        }
        .auto-style2 {
            width: 259px;
        }
        .auto-style3 {
            width: 116px;
        }
        .auto-style4 {
            width: 314px;
        }
        .auto-style5 {
            width: 146px;
        }
        .auto-style6 {
            width: 127px;
        }
        .auto-style7 {
            width: 279px;
        }
        .auto-style8 {
            width: 280px;
        }
        .auto-style9 {
            width: 274px;
        }
    </style>
    </asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container">
        <h1 class="mb-3">Consulta Individual</h1>
        <div class="container card" style="padding:25px;">
            <div><h5>Filtros</h5></div>
            <div>
                <table class="w-100 mb-3">
                    <tr>
                        <td class="auto-style1"><a>Ingrese codigo empleado:</a>&nbsp;</td>
                        <td class="auto-style2">
                            <asp:TextBox ID="txtCodigo" CssClass="form-control" runat="server" Width="90px" Height="40px"></asp:TextBox>
                        </td>
                        <td class="auto-style3"><a>Estado:</a>&nbsp;</td>
                        <td>
                            <asp:DropDownList ID="cboEstado" CssClass="form-control" runat="server" Height="40px" Width="200px">
                                <asp:ListItem Selected="True" Value="1">Todos los valores</asp:ListItem>
                                <asp:ListItem Value="2">PUNTUAL</asp:ListItem>
                                <asp:ListItem Value="3">TARDE</asp:ListItem>
                            </asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <td class="auto-style1"><a class="small">Ingrese el rango de fechas*</a>&nbsp;</td>
                        <td class="auto-style2">&nbsp;</td>
                        <td class="auto-style3">&nbsp;</td>
                        <td>&nbsp;</td>
                    </tr>
                    <tr>
                        <td class="auto-style1"><a>Fecha de inicio:</a>&nbsp;</td>
                        <td class="auto-style2">
                            <asp:TextBox ID="txtFecInicio" runat="server" CssClass="form-control" Height="40px" Width="200px"></asp:TextBox>
                            <ajaxToolkit:CalendarExtender ID="txtFecInicio_CalendarExtender" runat="server" BehaviorID="txtFecInicio_CalendarExtender" TargetControlID="txtFecInicio" 
                            />
                        <td class="auto-style3"><a>Fecha de fin:</a>&nbsp;</td>
                        <td>
                            <asp:TextBox ID="txtFecFin" runat="server" CssClass="form-control" Height="40px" Width="200px"></asp:TextBox>
                            <ajaxToolkit:CalendarExtender ID="txtFecFin_CalendarExtender" runat="server" BehaviorID="txtFecFin_CalendarExtender" TargetControlID="txtFecFin"
                            />
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2"> 
                            <asp:Button ID="btnConsultar" runat="server" Text="Consultar" CssClass="btn btn-primary" OnClick="btnConsultar_Click" />
              
                        </td>
                        <td colspan="2"><asp:Label ID="lblMensaje" runat="server"  CssClass="d-block end mt-3 text-danger"></asp:Label></td>
                    </tr>
                </table>
                
            </div>
        </div>

        <div class="container card mt-3" style="padding:25px;">
            <h5>Datos del empleado</h5>
            <a class="small">Datos obtenidos del empleado:</a>
            <div class="mt-2">
                <table class="w-100">
                    <tr>
                        <td class="auto-style5"><a>Documento:</a></td>
                        <td class="auto-style4">
                            <asp:TextBox ID="txtNumDoc" runat="server" CssClass="form-control" Height="40px" ReadOnly="True" Width="175px"></asp:TextBox>
                        </td>
                        <td class="auto-style6"><a>Tipo de documento:</a></td>
                        <td>
                            <asp:TextBox ID="txtTipDoc" runat="server" CssClass="form-control" Height="40px" ReadOnly="True" Width="250px"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="auto-style5"><a>Apellido y nombres:</a>&nbsp;</td>
                        <td class="auto-style4"><asp:TextBox ID="txtEmpleado" runat="server" CssClass="form-control" Height="40px" ReadOnly="True" Width="250px"></asp:TextBox></td>
                        <td class="auto-style6"><a>Foto:</a>&nbsp;</td>
                        <td>&nbsp;</td>
                    </tr>
                    <tr>
                        <td class="auto-style5"><a>Correo:</a></td>
                        <td class="auto-style4"> <asp:TextBox ID="txtCorreo" runat="server" CssClass="form-control" Height="40px" ReadOnly="True" Width="250px"></asp:TextBox></td>
                        <td colspan="2" rowspan="6"> 
                            <div class="container">
                                <asp:Image ID="imgFoto" runat="server" Height="250px" Width="205px" loading="lazy"/>
                            </div>
                        </td>
                    </tr>
                    <tr>
                        <td class="auto-style5"><a>Fecha de ingreso:</a>&nbsp;</td>
                        <td class="auto-style4"><asp:TextBox ID="txtFechaIng" runat="server" CssClass="form-control" Height="40px" ReadOnly="True" Width="150px"></asp:TextBox></td>
                    </tr>
                    <tr>
                        <td class="auto-style5"><a>Cargo:</a></td>
                        <td class="auto-style4"> <asp:TextBox ID="txtCargo" runat="server" CssClass="form-control" Height="40px" ReadOnly="True" Width="200px"></asp:TextBox></td>
                    </tr>
                    <tr>
                        <td class="auto-style5"><a>Area:</a>&nbsp;</td>
                        <td class="auto-style4"><asp:TextBox ID="txtArea" runat="server" CssClass="form-control" Height="40px" ReadOnly="True" Width="200px"></asp:TextBox></td>
                    </tr>
                    <tr>
                        <td class="auto-style5"><a>Sede:</a></td>
                        <td class="auto-style4"><asp:TextBox ID="txtSede" runat="server" CssClass="form-control" Height="40px" ReadOnly="True" Width="200px"></asp:TextBox></td>
                    </tr>
                    <tr>
                        <td class="auto-style5"><a>Horario:</a>&nbsp;</td>
                        <td class="auto-style4"> <asp:TextBox ID="txtHorario" runat="server" CssClass="form-control" Height="40px" ReadOnly="True" Width="200px"></asp:TextBox></td>
                    </tr>
                </table>
                
            </div>
        </div>

        <div class="container card mt-3" style="padding:25px;">
            <h5>Resultados del empleado</h5>
            <a class="small">Datos adicionales:</a>
            <div>

                <table class="w-100">
                    <tr>
                        <td class="auto-style7"><a>Numero de asistencias:</a></td>
                        <td class="auto-style8"> 
                            <asp:TextBox ID="txtNumAsis"  CssClass="form-control" runat="server" Height="40px" ReadOnly="True" Width="200px"></asp:TextBox>
                        </td>
                        <td colspan="2" rowspan="4">
                              <asp:Chart ID="charAsistPorcent" runat="server">
                                   <Series>
                                       <asp:Series ChartType="Pie" Name="Series1">
                                       </asp:Series>
                                   </Series>
                                   <ChartAreas>
                                       <asp:ChartArea Name="ChartArea1">
                                       </asp:ChartArea>
                                   </ChartAreas>
                               </asp:Chart>
                        </td>
                    </tr>
                    <tr>
                        <td class="auto-style7"><a>Numero de tardanzas:</a>&nbsp;</td>
                        <td class="auto-style8">
                            <asp:TextBox ID="txtNumTar" CssClass="form-control" runat="server" Height="40px" ReadOnly="True" Width="200px"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="auto-style7"><a>Tiempo acumulado de tardanzas:</a> </td>
                        <td class="auto-style8"><asp:TextBox ID="txtHrsTard" CssClass="form-control" runat="server" Height="40px" ReadOnly="True" Width="200px"></asp:TextBox></td>
                    </tr>
                    <tr>
                        <td class="auto-style7"><a>Mayor registro de tardanza:</a></td>
                        <td class="auto-style8"> <asp:TextBox ID="txtMasTar" CssClass="form-control" runat="server" Height="40px" ReadOnly="True" Width="200px"></asp:TextBox></td>
                    </tr>
                    <tr>
                        <td class="auto-style7"><a>Tiempo acumulado de exceso de refrigerio:</a></td>
                        <td class="auto-style8"><asp:TextBox ID="txtExeRef" CssClass="form-control" runat="server" Height="40px" ReadOnly="True" Width="200px"></asp:TextBox></td>
                        <td class="auto-style9"><a>Mayor registro de exceso de refrigerio:</a></td>
                        <td><asp:TextBox ID="txtMasRef" CssClass="form-control" runat="server" Height="40px" ReadOnly="True" Width="200px"></asp:TextBox></td>
                    </tr>
                    <tr>
                        <td class="auto-style7"><a>Tiempo acumulado en exceso de jornada:</a></td>
                        <td class="auto-style8"><asp:TextBox ID="txtExeJor" CssClass="form-control" runat="server" Height="40px" ReadOnly="True" Width="200px"></asp:TextBox></td>
                        <td class="auto-style9"><a>Mayor registro de exceso de jornada:</a></td>
                        <td><asp:TextBox ID="txtMasJor" CssClass="form-control" runat="server" Height="40px" ReadOnly="True" Width="200px"></asp:TextBox></td>
                    </tr>
                    </table>

            </div>
            <div>
                <a class="small">Tabla de registros de marcas del empleado segun el rango de fecha:</a>
                <div class="mb-4">
                    <a style="padding-right: 15px">Nro.de registros encontrados:</a> <asp:TextBox ID="txtNumReg" runat="server" CssClass="form-control d-inline" Height="40px" ReadOnly="True" Width="50px"></asp:TextBox>
                </div>
                <div class="text-center">
                    <div class="mx-auto" style="width:90%;">
                        <asp:GridView ID="grvConsEmpleado" CssClass="table table-bordered" runat="server" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" CellPadding="4" ForeColor="Black" GridLines="Horizontal" AllowPaging="True" AutoGenerateColumns="False" OnPageIndexChanging="grvConsEmpleado_PageIndexChanging" PageSize="5">
                        <Columns>
                            <asp:BoundField DataField="fecha" DataFormatString="{0:d}" HeaderText="Fecha" />
                            <asp:BoundField DataField="ingrTard" DataFormatString="{0:T}" HeaderText="Tiempo Tarde" />
                            <asp:BoundField DataField="exeRefr" DataFormatString="{0:T}" HeaderText="Exediente Refrigerio" />
                            <asp:BoundField DataField="exeJornd" DataFormatString="{0:T}" HeaderText="Exediente Jornada" />
                            <asp:BoundField DataField="observ" HeaderText="Estado" />
                        </Columns>
                        <FooterStyle BackColor="#CCCC99" ForeColor="Black" />
                        <HeaderStyle BackColor="#333333" Font-Bold="True" ForeColor="White" />
                        <PagerStyle BackColor="White" ForeColor="Black" HorizontalAlign="Right" />
                        <SelectedRowStyle BackColor="#CC3333" Font-Bold="True" ForeColor="White" />
                        <SortedAscendingCellStyle BackColor="#F7F7F7" />
                        <SortedAscendingHeaderStyle BackColor="#4B4B4B" />
                        <SortedDescendingCellStyle BackColor="#E5E5E5" />
                        <SortedDescendingHeaderStyle BackColor="#242121" />
                    </asp:GridView>
                    </div>
                </div>
            </div>
        </div>
    </div>

</asp:Content>
