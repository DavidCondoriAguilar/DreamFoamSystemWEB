<%@ Page Title="" Language="C#" MasterPageFile="~/DreamMaster.Master" AutoEventWireup="true" CodeBehind="DreamMetricas.aspx.cs" Inherits="DreamWEB.DreamMasterPages.DreamMetricas" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .auto-style1 {
            text-align: center;
            height: 17px;
        }
        .auto-style2 {
            width: 596px;
        }
        .auto-style3 {
            width: 597px;
        }
        .auto-style4 {
            width: 596px;
            height: 302px;
        }
        .auto-style5 {
            height: 302px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container">
        <h1>Metricas</h1>
        <div class="container card" style="padding:25px;">
            <div>
                <table class="w-100">
                    <tr>
                        <td class="auto-style1"><h5>Top empleados más puntuales</h5></td>
                        <td class="auto-style1"><h5>Top empleados con más tardanzas</h5></td>
                    </tr>
                    <tr>
                        <td>
                             <div class="mx-auto" style="width:80%;">
                            <asp:GridView ID="grdTopPun" CssClass="table table-bordered table-striped" runat="server" AutoGenerateColumns="False">
                                <Columns>
                                    <asp:BoundField DataField="emplPun" HeaderText="Empleado">
                                    <ItemStyle HorizontalAlign="Left" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="emplPunMarc" HeaderText="Nro. Marcas" >
                                    <ItemStyle HorizontalAlign="Center" />
                                    </asp:BoundField>
                                </Columns>
                            </asp:GridView>
                            </div>
                        </td>
                        <td>
                            <div class="mx-auto" style="width:80%;">
                            <asp:GridView ID="grdTopTar" CssClass="table table-bordered table-striped" runat="server" AutoGenerateColumns="False">
                                <Columns>
                                    <asp:BoundField DataField="emplTar" HeaderText="Empleado">
                                    <ItemStyle HorizontalAlign="Left" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="emplTarMarc" HeaderText="Nro.Marcas">
                                    <ItemStyle HorizontalAlign="Center" />
                                    </asp:BoundField>
                                </Columns>
                            </asp:GridView>
                                </div>
                        </td>
                    </tr>
                </table>
            </div>
            <div>
                <h5>Según Areas</h5>
                <a class="small"> Datos de los registros según el estado de las asistencias en las areas</a>
                <h6 class="mt-3">Areas según marcas puntuales</h6>
                <div>

                    <table class="w-100">
                        <tr>
                            <td class="auto-style2">
                                 <div class="mx-auto" style="width:80%;">
                                <asp:GridView ID="grdArePunt" CssClass="table table-bordered table-striped" runat="server" AutoGenerateColumns="False">
                                    <Columns>
                                        <asp:BoundField DataField="nomArea" HeaderText="Area">
                                        <ItemStyle HorizontalAlign="Left" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="areaMarc" HeaderText="Nro.Marcas">
                                        <ItemStyle HorizontalAlign="Center" />
                                        </asp:BoundField>
                                    </Columns>
                                </asp:GridView>
                                     </div>
                            </td>
                            <td>
                                <asp:Chart ID="charArePunt" runat="server" Width="521px">
                                    <Series>
                                        <asp:Series ChartType="Bar" Name="Series1" XValueMember="areaMarc" YValueMembers="nomArea" YValuesPerPoint="4">
                                        </asp:Series>
                                    </Series>
                                    <ChartAreas>
                                        <asp:ChartArea Name="ChartArea1">
                                        </asp:ChartArea>
                                    </ChartAreas>
                                </asp:Chart>
                            </td>
                        </tr>
                    </table>

                </div>
                <h6>Areas según marcas con tardanza</h6>
                <div>

                    <table class="w-100">
                        <tr>
                            <td class="auto-style3">
                                 <div class="mx-auto" style="width:80%;">
                                <asp:GridView ID="grdAreaTar" CssClass="table table-bordered table-striped" runat="server" AutoGenerateColumns="False">
                                    <Columns>
                                        <asp:BoundField DataField="nomArea" HeaderText="Area">
                                        <ItemStyle HorizontalAlign="Left" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="areaMarc" HeaderText="Nro.Marcas">
                                        <ItemStyle HorizontalAlign="Center" />
                                        </asp:BoundField>
                                    </Columns>
                                    
                                </asp:GridView>
                                    </div> 
                           </td>
                            <td>
                                <asp:Chart ID="charAreTar" runat="server" Width="516px">
                                    <Series>
                                        <asp:Series ChartType="Bar" Name="Series1">
                                        </asp:Series>
                                    </Series>
                                    <ChartAreas>
                                        <asp:ChartArea Name="ChartArea1">
                                        </asp:ChartArea>
                                    </ChartAreas>
                                </asp:Chart>
                            </td>
                        </tr>
                    </table>

                </div>
            </div>

            <div>
                    <h5>Según Horarios</h5>
                    <a class="small"> Datos de los registros según el estado de las asistencias en los horarios</a>
                    <h6 class="mt-3">Horarios según marcas puntuales</h6>
                    <div>

                        <table class="w-100">
                            <tr>
                                <td class="auto-style4">
                                     <div class="mx-auto" style="width:80%;">
                                    <asp:GridView ID="grdHorPun" CssClass="table table-bordered table-striped" runat="server" AutoGenerateColumns="False">
                                        <Columns>
                                            <asp:BoundField DataField="nomHora" HeaderText="Horario">
                                            <ItemStyle HorizontalAlign="Left" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="HoraMarc" HeaderText="Nro.Marcas">
                                            <ItemStyle HorizontalAlign="Center" />
                                            </asp:BoundField>
                                        </Columns>
                                    </asp:GridView>
                                         </div>
                                </td>
                                <td class="auto-style5">
                                    <asp:Chart ID="charHorPun" runat="server" OnLoad="charHorPun_Load">
                                        <Series>
                                            <asp:Series ChartType="Doughnut" Name="Series1">
                                            </asp:Series>
                                        </Series>
                                        <ChartAreas>
                                            <asp:ChartArea Name="ChartArea1">
                                            </asp:ChartArea>
                                        </ChartAreas>
                                    </asp:Chart>
                                </td>
                            </tr>
                        </table>

                    </div>
                    <h6>Horarios según marcas con tardanza</h6>
                    <div>

                        <table class="w-100">
                            <tr>
                                <td class="auto-style3">
                                     <div class="mx-auto" style="width:80%;">
                                    <asp:GridView ID="grdHorTar" CssClass="table table-bordered table-striped" runat="server" AutoGenerateColumns="False">
                                        <Columns>
                                            <asp:BoundField DataField="nomHora" HeaderText="Horario">
                                            <ItemStyle HorizontalAlign="Left" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="HoraMarc" HeaderText="Nro.Marcas">
                                            <ItemStyle HorizontalAlign="Center" />
                                            </asp:BoundField>
                                        </Columns>
                                    </asp:GridView>
                                         </div>
                                </td>
                                <td>
                                    <asp:Chart ID="charHorTar" runat="server">
                                        <Series>
                                            <asp:Series ChartType="Doughnut" Name="Series1">
                                            </asp:Series>
                                        </Series>
                                        <ChartAreas>
                                            <asp:ChartArea Name="ChartArea1">
                                            </asp:ChartArea>
                                        </ChartAreas>
                                    </asp:Chart>
                                </td>
                            </tr>
                        </table>

                    </div>
                </div>

            <div>
                <h5>Según Sede</h5>
                <a class="small"> Datos de los registros según el estado de las asistencias en las sedes</a>
                <h6 class="mt-3">Sedes según marcas puntuales</h6>
                <div>

                    <table class="w-100">
                        <tr>
                            <td class="auto-style2">
                                 <div class="mx-auto" style="width:80%;">
                                <asp:GridView ID="grdSedePun" CssClass="table table-bordered table-striped" runat="server" AutoGenerateColumns="False">
                                    <Columns>
                                        <asp:BoundField DataField="nomSede" HeaderText="Sede">
                                        <ItemStyle HorizontalAlign="Left" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="sedeMarc" HeaderText="Nro.Marcas">
                                        <ItemStyle HorizontalAlign="Center" />
                                        </asp:BoundField>
                                    </Columns>
                                </asp:GridView>
                                     </div>
                            </td>
                            <td>
                                <asp:Chart ID="charSedePun" runat="server">
                                    <Series>
                                        <asp:Series ChartType="Doughnut" Name="Series1">
                                        </asp:Series>
                                    </Series>
                                    <ChartAreas>
                                        <asp:ChartArea Name="ChartArea1">
                                        </asp:ChartArea>
                                    </ChartAreas>
                                </asp:Chart>
                            </td>
                        </tr>
                    </table>

                </div>
                <h6>Sedes según marcas con tardanza</h6>
                <div>

                    <table class="w-100">
                        <tr>
                            <td class="auto-style3">
                                 <div class="mx-auto" style="width:80%;">
                                <asp:GridView ID="grdSedeTar" CssClass="table table-bordered table-striped" runat="server" AutoGenerateColumns="False">
                                    <Columns>
                                        <asp:BoundField DataField="nomSede" HeaderText="Sede">
                                        <ItemStyle HorizontalAlign="Left" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="sedeMarc" HeaderText="Nro.Marcas">
                                        <ItemStyle HorizontalAlign="Center" />
                                        </asp:BoundField>
                                    </Columns>
                                </asp:GridView>
                                     </div>
                            </td>
                            <td>
                                <asp:Chart ID="charSedeTar" runat="server">
                                    <Series>
                                        <asp:Series ChartType="Doughnut" Name="Series1">
                                        </asp:Series>
                                    </Series>
                                    <ChartAreas>
                                        <asp:ChartArea Name="ChartArea1">
                                        </asp:ChartArea>
                                    </ChartAreas>
                                </asp:Chart>
                            </td>
                        </tr>
                    </table>

                </div>
            </div>

        </div>
    </div>
</asp:Content>
