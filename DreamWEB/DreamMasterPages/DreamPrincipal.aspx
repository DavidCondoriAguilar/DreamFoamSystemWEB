<%@ Page Title="" Language="C#" MasterPageFile="~/DreamMaster.Master" AutoEventWireup="true" CodeBehind="DreamPrincipal.aspx.cs" Inherits="DreamWEB.DreamMasterPages.DreamPrincipal" %>
<%@ Register assembly="System.Web.DataVisualization, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" namespace="System.Web.UI.DataVisualization.Charting" tagprefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

   
    <asp:Label ID="lblNombreSesion" runat="server"></asp:Label>
   <div class="container">
       <div>
           <h3 class="display-6" style="color:#38394e; ;">Dream Foam</h3>
           <h4 class="display-4">Consultas y Metricas</h4>
           <h6 class=" mb-5">¿Que consultas y metricas desea ver?</h6>
       </div>
         <div class="row">
          <div class="col-sm-4 mb-3 mb-sm-0">
            <div class="card h-100">
              <div class="card-body">
                <h5 class="card-title">Consulta General</h5>
                <p class="card-text h-50">Realice una consulta donde se mostraran datos generales y ademas mostrar una grilla
                    segun el area o el estado de la marca.
                </p>
                  <asp:Button ID="btnConsGeneral" runat="server" Text="Ir a Consulta General" CssClass="btn btn-primary" OnClick="btnConsGeneral_Click" />
              </div>
            </div>
          </div>
          <div class="col-sm-4">
            <div class="card h-100">
              <div class="card-body">
                <h5 class="card-title">Consulta Individual</h5>
                <p class="card-text">Consulte especificamente el rendimiento de un empleado. Podra visualizar datos puntuales asi como una grilla
                    de todas sus asistencias en un rango de fecha.
                </p>
                 <asp:Button ID="btnConsEmpl" runat="server" Text="Ir a Consulta Individual"  CssClass="btn btn-primary"  OnClick="btnConsEmpl_Click" />
              </div>
            </div>
          </div> <div class="col-sm-4">
               <div class="card h-100">
                 <div class="card-body">
                   <h5 class="card-title">Metricas Adicionales</h5>
                   <p class="card-text h-50">Pagina donde se muestran datos generales sobre los empleados.</p>
                    <asp:Button ID="btnMetrics" runat="server" OnClick="btnMetrics_Click" CssClass="btn btn-primary" Text="Ir a Metricas Generales" />
                 </div>
               </div>
             </div>
        </div>
   </div>
    <!--
    <div>
        <h3>Metricas</h3>
        <div>
            <h4>Metricas de empleados en General</h4>
            <p>Consulte a detalle sobre las estadisticas de empleados en general</p>
            <p>
               
            </p>
        </div>
        <div>
            <h4>Metricas particulares de cada empleado</h4>
            <p>Consulte a detalle las metricas individuales de cada empleado..</p>
            <p>
               
            </p>
        </div>
        <div>
            <h4>Metricas de rendimiento</h4>
            <p>Consulte a detalle a cerca de las tendencias de los empleados, dias que mas tardanzas ocupan,
               etc.</p>
            <p>
               
            </p>
        </div>
    </div>
    -->
</asp:Content>
