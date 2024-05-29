<%@ Page Title="" Language="C#" MasterPageFile="~/DreamMaster.Master" AutoEventWireup="true" CodeBehind="DreamConsGeneral.aspx.cs" Inherits="DreamWEB.DreamMasterPages.DreamConsGeneral" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    
    <style type="text/css">
        .auto-style1 {
            width: 175px;
        }
        .auto-style2 {
            width: 281px;
        }
        .auto-style3 {
            width: 175px;
            height: 31px;
        }
        .auto-style4 {
            width: 281px;
            height: 31px;
        }
        .auto-style5 {
            height: 31px;
        }
        .auto-style6 {
            width: 240px;
        }
        .auto-style9 {
            width: 307px;
        }
        .auto-style10 {
            width: 213px;
        }
        .auto-style11 {
            width: 240px;
            height: 48px;
        }
        .auto-style12 {
            width: 307px;
            height: 48px;
        }
        .auto-style13 {
            width: 213px;
            height: 48px;
        }
        .auto-style14 {
            height: 48px;
        }
        </style>
    
    </asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container">
        <h1 class="mb-3">Consulta General</h1>
        <div class="container card" style="padding:25px">
            <table class="w-100 mb-3">
                <tr>
                    <td class="auto-style1"><a>Seleccione area:</a>&nbsp;</td>
                    <td class="auto-style2">
                        <asp:DropDownList ID="cboArea" runat="server" CssClass="form-control d-inline" Height="40px" Width="200px">
                             <asp:ListItem Selected="True" Value="0">-Todas las areas-</asp:ListItem>
                        </asp:DropDownList> &nbsp;</td>
                    <td class="auto-style1">&nbsp;</td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td class="auto-style3"><a>Estado:</a>&nbsp;</td>
                    <td class="auto-style4"> 
                        <asp:DropDownList ID="cboEstado" runat="server" Height="40px" Width="200px" CssClass="form-control d-inline">
                               <asp:ListItem Selected="True" Value="1">Todos los valores</asp:ListItem>
                               <asp:ListItem Value="2">PUNTUAL</asp:ListItem>
                                <asp:ListItem Value="3">TARDE</asp:ListItem>
                        </asp:DropDownList>&nbsp;</td>
                    <td class="auto-style3"></td>
                    <td class="auto-style5"></td>
                </tr>
                
                <tr>
                    <td class="auto-style1"><a class="small">Ingrese el rango de fechas*</a></td>
                    <td class="auto-style2">&nbsp;</td>
                    <td class="auto-style1">&nbsp;</td>
                    <td>&nbsp;</td>
                </tr>
                
                <tr>
                    <td class="auto-style1"><a>Fecha de inicio:</a>&nbsp;</td>
                    <td class="auto-style2">
                        <asp:TextBox ID="txtFecInicio" runat="server" CssClass="form-control" Height="40px" Width="200px"></asp:TextBox>
                        <ajaxToolkit:CalendarExtender ID="txtFecInicio_CalendarExtender" runat="server" BehaviorID="txtFecInicio_CalendarExtender" TargetControlID="txtFecInicio" PopupPosition="TopRight" 
                         />
                    </td>
                    <td class="auto-style1"><a>Fecha de fin:</a>&nbsp;</td>
                    <td>
                        <asp:TextBox ID="txtFecFin" runat="server" CssClass="form-control" Height="40px" Width="200px"></asp:TextBox>
                            <ajaxToolkit:CalendarExtender ID="txtFecFin_CalendarExtender" runat="server" BehaviorID="txtFecFin_CalendarExtender" TargetControlID="txtFecFin" PopupPosition="TopRight"
                            />
                   </td>
                </tr>
            </table>
            <div>
                <asp:Button ID="btnConsultar" runat="server" Text="Consultar" CssClass ="btn btn-primary" OnClick="btnConsultar_Click" />
                <asp:Label ID="lblMensaje" runat="server" CssClass="d-block end mt-3 text-danger"></asp:Label>
            </div>
        </div>
        <div class="container card mt-3" style="padding:25px;">
            <h5>Resultados Generales</h5>
            <a class="small">Estos resultados son independientes a los filtros seleccionados.</a>
            <div>

                <table class="w-100">
                    <tr>
                        <td class="auto-style6"><a>Datos sobre los empleados:</a>&nbsp;</td>
                        <td class="auto-style9">&nbsp;</td>
                        <td class="auto-style10">&nbsp;</td>
                        <td>&nbsp;</td>
                        <td>&nbsp;</td>
                    </tr>
                    <tr>
                        <td class="auto-style6"><a>Empleado mas puntual:</a>&nbsp;</td>
                        <td class="auto-style9">
                            <asp:TextBox ID="txtEmpPunt" runat="server" CssClass="form-control" Height="40px" Width="250px" ReadOnly="True"></asp:TextBox>
                        </td>
                        <td class="auto-style10"><a>Nro.marcas a tiempo:</a>&nbsp;</td>
                        <td><asp:TextBox ID="txtEmpPuntMar" runat="server" CssClass="form-control" Height="40px" ReadOnly="True" Width="100px"></asp:TextBox></td>
                        <td>&nbsp;</td>
                    </tr>
                    <tr>
                        <td class="auto-style11"><a>Empleado con mas tardanzas:</a>&nbsp;</td>
                        <td class="auto-style12"> 
                            <asp:TextBox ID="txtEmpTar" runat="server" Height="40px" CssClass="form-control" ReadOnly="True" Width="250px"></asp:TextBox>

                        </td>
                        <td class="auto-style13"><a>Nro. de tardanzas:</a>&nbsp;</td>
                        <td class="auto-style14">
                            <asp:TextBox ID="txtEmpTarMar" runat="server" CssClass="form-control" Height="40px" ReadOnly="True" Width="100px"></asp:TextBox>
                        </td>
                        <td class="auto-style14">
                            &nbsp;</td>
                    </tr>
                    <tr>
                        <td colspan="2"><a>Datos sobre indicadores de la empresa:</a>&nbsp;</td>
                        <td class="auto-style10">&nbsp;</td>
                        <td>&nbsp;</td>
                        <td>&nbsp;</td>
                    </tr>
                    <tr>
                        <td class="auto-style11"><a>Area más puntual:</a>&nbsp;</td>
                        <td class="auto-style12">
                            <asp:TextBox ID="txtAreaPun" runat="server" Height="40px" CssClass="form-control" ReadOnly="True" Width="250px"></asp:TextBox>
                        </td>
                        <td class="auto-style13"><a>Area con más tardanzas:</a>&nbsp;</td>
                        <td class="auto-style14">
                            <asp:TextBox ID="txtAreaTar" runat="server" Height="40px" CssClass="form-control" ReadOnly="True" Width="250px"></asp:TextBox>
                        </td>
                        <td class="auto-style14">
                            &nbsp;</td>
                    </tr>
                    <tr>
                        <td class="auto-style6"><a>Cargo más puntual:</a>&nbsp;</td>
                        <td class="auto-style9">
                            <asp:TextBox ID="txtCarPun" runat="server" Height="40px" CssClass="form-control" ReadOnly="True" Width="250px"></asp:TextBox>
                        </td>
                        <td class="auto-style10"><a>Cargo con más tardanzas</a>&nbsp;</td>
                        <td>
                            <asp:TextBox ID="txtCarTar" runat="server" Height="40px" CssClass="form-control" ReadOnly="True" Width="250px"></asp:TextBox>
                        </td>
                        <td>
                            &nbsp;</td>
                    </tr>
                    <tr>
                        <td class="auto-style11"><a>Horario más puntual:</a>&nbsp;</td>
                        <td class="auto-style12">
                             <asp:TextBox ID="txtHorPun" runat="server" Height="40px" CssClass="form-control" ReadOnly="True" Width="250px"></asp:TextBox>
                        </td>
                        <td class="auto-style13"><a>Horario con más tardanzas:</a>&nbsp;</td>
                        <td class="auto-style14">
                             <asp:TextBox ID="txtHorTar" runat="server" Height="40px" CssClass="form-control" ReadOnly="True" Width="250px"></asp:TextBox>
                        </td>
                        <td class="auto-style14">
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2"><a class="small">Grafica general de marcas</a>&nbsp;</td>
                        <td colspan="2"><a class="small">Grafica segun area seleccionada</a>&nbsp;</td>
                        <td>&nbsp;</td>
                    </tr>
                    <tr>
                        <td colspan="2">
                            <div class="text-center">
                                <asp:Chart ID="charTarPun" runat="server">
                                    <Series>
                                        <asp:Series ChartType="Pie" Name="Series1">
                                        </asp:Series>
                                    </Series>
                                    <ChartAreas>
                                        <asp:ChartArea Name="ChartArea1">
                                        </asp:ChartArea>
                                    </ChartAreas>
                                </asp:Chart>
                            </div>
                        </td>
                        <td colspan="2">
                            <div class="text-center">
                                <asp:Chart ID="charArea" runat="server">
                                    <Series>
                                        <asp:Series ChartType="Pie" Name="Series1">
                                        </asp:Series>
                                    </Series>
                                    <ChartAreas>
                                        <asp:ChartArea Name="ChartArea1">
                                        </asp:ChartArea>
                                    </ChartAreas>
                                </asp:Chart>
                            </div>
                        </td>
                        <td>&nbsp;</td>
                    </tr>
                </table>
            </div>
        </div>
        <div class="container card mt-3" style="padding: 25px;">
            <h5>Resultados Filtrado</h5>
            <a class="small">Tabla con todos los empleados segun los filtros colocados en el rango de fechas:</a>
            <div class="mb-4">
            <a style="padding-right:15px;">Nro.de registros encontrados:</a><asp:TextBox ID="txtNumReg" runat="server" CssClass="form-control d-inline" Height="40px" ReadOnly="True" Width="50px"></asp:TextBox>
            </div>
            <div class="text-center">
                <div class="mx-auto" style="width:90%;">
                <asp:GridView ID="grvConsGeneral" CssClass="table table-bordered table-striped" runat="server" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" CellPadding="4" ForeColor="Black" GridLines="Horizontal" AllowPaging="True" AutoGenerateColumns="False" OnPageIndexChanging="grvConsGeneral_PageIndexChanging" Width="997px">
                <Columns>
                    <asp:BoundField DataField="fecha" DataFormatString="{0:d}" HeaderText="Fecha" />
                    <asp:BoundField DataField="empleado" HeaderText="Empleado" >
                    <FooterStyle HorizontalAlign="Left" />
                    <ItemStyle HorizontalAlign="Left" />
                    </asp:BoundField>
                    <asp:BoundField DataField="area" HeaderText="Area" />
                    <asp:BoundField DataField="ingrTard" DataFormatString="{0:t}" HeaderText="Tiempo Tarde" />
                    <asp:BoundField DataField="exeRefr" DataFormatString="{0:t}" HeaderText="Exediente Refrigerio" />
                    <asp:BoundField DataField="exeJornd" DataFormatString="{0:t}" HeaderText="Exediente Jornada" />
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
   


</asp:Content>
