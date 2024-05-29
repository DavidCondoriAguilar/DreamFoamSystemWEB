using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using ProyDreamFoam_BE;

namespace ProyDreamFoam_ADO
{
    public class DiarioADO
    {
        public List<DiarioBEGenMetrics2> MetricasDiarioAddSede(String estado)
        {
            try
            {
                DreamFoam_DBEntities dreamDB = new DreamFoam_DBEntities();
                List<DiarioBEGenMetrics2> lst = new List<DiarioBEGenMetrics2>();
                var areaq = (
                   from reg in dreamDB.Tb_Diario
                   join empl in dreamDB.Tb_Empleado on reg.empleado equals empl.codEmpleado
                   join sed in dreamDB.Tb_Sede on empl.codSede equals sed.codSede
                   where reg.observ == estado
                   group reg by new { sed.nomSede, reg.observ } into grupo
                   orderby grupo.Count() descending
                   select new
                   {
                       nom = grupo.Key.nomSede,
                       regs = grupo.Count()
                   }
                   );
                foreach (var obj in areaq)
                {
                    DiarioBEGenMetrics2 mtr = new DiarioBEGenMetrics2();
                    mtr.nomSede = obj.nom;
                    mtr.sedeMarc = obj.regs;
                    lst.Add(mtr);
                }
                return lst;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public List<DiarioBEGenMetrics2> MetricasDiarioAddHora(String estado)
        {
            try
            {
                DreamFoam_DBEntities dreamDB = new DreamFoam_DBEntities();
                List<DiarioBEGenMetrics2> lst = new List<DiarioBEGenMetrics2>();
                var areaq = (
                   from reg in dreamDB.Tb_Diario
                   join empl in dreamDB.Tb_Empleado on reg.empleado equals empl.codEmpleado
                   join hor in dreamDB.Tb_Horario on empl.codHorario equals hor.codHorario
                   where reg.observ == estado
                   group reg by new { hor.desHorario, reg.observ } into grupo
                   orderby grupo.Count() descending
                   select new
                   {
                       nom = grupo.Key.desHorario,
                       regs = grupo.Count()
                   }
                   );
                foreach (var obj in areaq)
                {
                    DiarioBEGenMetrics2 mtr = new DiarioBEGenMetrics2();
                    mtr.nomHora = obj.nom;
                    mtr.horaMarc = obj.regs;
                    lst.Add(mtr);
                }
                return lst;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public List<DiarioBEGenMetrics2> MetricasDiarioAddArea(String estado)
        {
            try
            {
                DreamFoam_DBEntities dreamDB = new DreamFoam_DBEntities();
                List<DiarioBEGenMetrics2> lst = new List<DiarioBEGenMetrics2>();
                var areaq = (
                   from reg in dreamDB.Tb_Diario
                   join empl in dreamDB.Tb_Empleado on reg.empleado equals empl.codEmpleado
                   join are in dreamDB.Tb_Area on empl.codArea equals are.codArea
                   where reg.observ == estado
                   group reg by new {  are.nomArea, reg.observ} into grupo
                   orderby grupo.Count() descending
                   select new
                   {
                       nom = grupo.Key.nomArea,
                       regs = grupo.Count()
                   }
                   );
                foreach(var obj in areaq)
                {
                    DiarioBEGenMetrics2 mtr = new DiarioBEGenMetrics2();
                    mtr.nomArea = obj.nom;
                    mtr.areaMarc = obj.regs;
                    lst.Add( mtr );
                }
                return lst;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public List<DiarioBEGenMetrics> MetricasTopEmplTar()
        {
            try
            {
                DreamFoam_DBEntities dreamDB = new DreamFoam_DBEntities();
                List<DiarioBEGenMetrics> lst = new List<DiarioBEGenMetrics>();
                var empleadoPunt = (
                    from reg in dreamDB.Tb_Diario
                    join empl in dreamDB.Tb_Empleado on reg.empleado equals empl.codEmpleado
                    where reg.observ == "TARDE"
                    group reg by new { reg.empleado, reg.observ, empl.nombres, empl.apellidos } into grupo
                    orderby grupo.Count() descending
                    select new
                    {
                        nomEmpl = grupo.Key.nombres,
                        apeEmpl = grupo.Key.apellidos,
                        punReg = grupo.Count()
                    }
                    ).Take(5);
                foreach (var obj in empleadoPunt)
                {
                    DiarioBEGenMetrics metr = new DiarioBEGenMetrics();
                    metr.emplTar = obj.apeEmpl + "," + obj.nomEmpl;
                    metr.emplTarMarc = obj.punReg;
                    lst.Add(metr);
                }
                return lst;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public List<DiarioBEGenMetrics> MetricasTopEmplPun()
        {
            try { 
            DreamFoam_DBEntities dreamDB = new DreamFoam_DBEntities();
            List<DiarioBEGenMetrics> lst = new List<DiarioBEGenMetrics>();
                   var empleadoPunt = (
                       from reg in dreamDB.Tb_Diario
                       join empl in dreamDB.Tb_Empleado on reg.empleado equals empl.codEmpleado
                       where reg.observ == "PUNTUAL" 
                       group reg by new { reg.empleado, reg.observ, empl.nombres, empl.apellidos } into grupo
                       orderby grupo.Count() descending
                       select new
                       {
                           nomEmpl = grupo.Key.nombres,
                           apeEmpl = grupo.Key.apellidos,
                           punReg = grupo.Count()
                       }
                       ).Take(5);
                foreach(var obj in empleadoPunt )
                {
                    DiarioBEGenMetrics metr = new DiarioBEGenMetrics();
                    metr.emplPun = obj.apeEmpl+","+obj.nomEmpl;
                    metr.emplPunMarc = obj.punReg;
                    lst.Add( metr );
                }
                return lst;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public DiarioBEGenMetrics MetricasGenEmpl(DateTime fecIni, DateTime fecFin)
        {
            try
            {
                DreamFoam_DBEntities dreamDB = new DreamFoam_DBEntities();
                DiarioBEGenMetrics metr = new DiarioBEGenMetrics();

                var empleadoTard = (
                    from reg in dreamDB.Tb_Diario
                    join empl in dreamDB.Tb_Empleado on reg.empleado equals empl.codEmpleado
                    where reg.observ == "TARDE" && reg.fecha >= fecIni && reg.fecha <= fecFin
                    group reg by new { reg.empleado, reg.observ, empl.nombres, empl.apellidos} into grupo
                    orderby grupo.Count() descending
                    select new
                    {
                        nomEmpl = grupo.Key.nombres,
                        apeEmpl = grupo.Key.apellidos,
                        tarReg = grupo.Count()
                    }).FirstOrDefault();
                metr.emplTar = empleadoTard.apeEmpl + ","+ empleadoTard.nomEmpl;
                metr.emplTarMarc = empleadoTard.tarReg;

                var empleadoPunt = (
                    from reg in dreamDB.Tb_Diario
                    join empl in dreamDB.Tb_Empleado on reg.empleado equals empl.codEmpleado
                    where reg.observ == "PUNTUAL" && reg.fecha >= fecIni && reg.fecha <= fecFin
                    group reg by new { reg.empleado, reg.observ, empl.nombres, empl.apellidos } into grupo
                    orderby grupo.Count() descending
                    select new
                    {
                        nomEmpl = grupo.Key.nombres,
                        apeEmpl = grupo.Key.apellidos,
                        punReg = grupo.Count()
                    }
                    ).FirstOrDefault();
                metr.emplPun = empleadoPunt.apeEmpl +","+ empleadoPunt.nomEmpl;
                metr.emplPunMarc = empleadoPunt.punReg;

                var areaTarde = (
                    from reg in dreamDB.Tb_Diario
                    join empl in dreamDB.Tb_Empleado on reg.empleado equals empl.codEmpleado
                    join are in dreamDB.Tb_Area on empl.codArea equals are.codArea
                    where reg.observ == "TARDE" && reg.fecha >= fecIni && reg.fecha <= fecFin
                    group reg by new { are.codArea, reg.observ,are.nomArea } into grupo
                    orderby grupo.Count() descending
                    select new
                    {
                        nomArea =  grupo.Key.nomArea,
                        regAre = grupo.Count()
                    }
                    ).FirstOrDefault();
                metr.areaTar = areaTarde.nomArea;

                var areaPun = (
                    from reg in dreamDB.Tb_Diario
                    join empl in dreamDB.Tb_Empleado on reg.empleado equals empl.codEmpleado
                    join are in dreamDB.Tb_Area on empl.codArea equals are.codArea
                    where reg.observ == "PUNTUAL" && reg.fecha >= fecIni && reg.fecha <= fecFin
                    group reg by new { are.codArea, reg.observ, are.nomArea } into grupo
                    orderby grupo.Count() descending
                    select new
                    {
                        nomArea = grupo.Key.nomArea,
                        regAre = grupo.Count()
                    }
                    ).FirstOrDefault();
                metr.areaPun = areaPun.nomArea;

                var horarTar = (
                    from reg in dreamDB.Tb_Diario
                    join empl in dreamDB.Tb_Empleado on reg.empleado equals empl.codEmpleado
                    join hor in dreamDB.Tb_Horario on empl.codHorario equals hor.codHorario
                    where reg.observ == "TARDE" && reg.fecha >= fecIni && reg.fecha <= fecFin
                    group reg by new { hor.codHorario, reg.observ, hor.desHorario} into grupo
                    orderby grupo.Count() descending
                    select new
                    {
                        nomHor = grupo.Key.desHorario,
                        regHor = grupo.Count()
                    }
                    ).FirstOrDefault();
                metr.horarTar = horarTar.nomHor;

                var horarPun = (
                   from reg in dreamDB.Tb_Diario
                   join empl in dreamDB.Tb_Empleado on reg.empleado equals empl.codEmpleado
                   join hor in dreamDB.Tb_Horario on empl.codHorario equals hor.codHorario
                   where reg.observ == "PUNTUAL" && reg.fecha >= fecIni && reg.fecha <= fecFin
                   group reg by new { hor.codHorario, reg.observ, hor.desHorario } into grupo
                   orderby grupo.Count() descending
                   select new
                   {
                       nomHor = grupo.Key.desHorario,
                       regHor = grupo.Count()
                   }
                   ).FirstOrDefault();
                metr.horarPun = horarPun.nomHor;

                var cargoTar = (
                   from reg in dreamDB.Tb_Diario
                   join empl in dreamDB.Tb_Empleado on reg.empleado equals empl.codEmpleado
                   join carg in dreamDB.Tb_Cargo on empl.codCargo equals carg.codCargo
                   where reg.observ == "TARDE" && reg.fecha >= fecIni && reg.fecha <= fecFin
                   group reg by new { carg.codCargo, reg.observ, carg.nomCargo} into grupo
                   orderby grupo.Count() descending
                   select new
                   {
                       nomCarg = grupo.Key.nomCargo,
                       regCarg = grupo.Count()
                   }
                   ).FirstOrDefault();
                metr.carTar = cargoTar.nomCarg;

                var cargoPun = (
                   from reg in dreamDB.Tb_Diario
                   join empl in dreamDB.Tb_Empleado on reg.empleado equals empl.codEmpleado
                   join carg in dreamDB.Tb_Cargo on empl.codCargo equals carg.codCargo
                   where reg.observ == "PUNTUAL" && reg.fecha >= fecIni && reg.fecha <= fecFin
                   group reg by new { carg.codCargo, reg.observ, carg.nomCargo } into grupo
                   orderby grupo.Count() descending
                   select new
                   {
                       nomCarg = grupo.Key.nomCargo,
                       regCarg = grupo.Count()
                   }
                   ).FirstOrDefault();
                metr.carPun = cargoPun.nomCarg;

                return metr; 
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public DiarioBEMetrics MetricasEmplInd( Int32 codigo, DateTime fecIni, DateTime fecFin)
        {
            try
            {
                DreamFoam_DBEntities dreamDB = new DreamFoam_DBEntities();
                DiarioBEMetrics metr = new DiarioBEMetrics();

                //DateTime fecIniMod = Convert.ToDateTime(fecIni.ToString("yyyyMMdd"));
                //DateTime fecFinMod = Convert.ToDateTime(fecFin.ToString("yyyyMMdd"));

                var sumTardanza = dreamDB.usp_DiarioMetrSumTard(codigo,fecIni , fecFin).FirstOrDefault();    
                metr.sumTar = sumTardanza ?? TimeSpan.Zero;

                var sumRefri = dreamDB.usp_DiarioMetrSumRef(codigo, fecFin, fecIni).FirstOrDefault();
                metr.sumRef = sumRefri ?? TimeSpan.Zero; ;  

                var sumJornada = dreamDB.usp_DiarioMetrSumJor(codigo, fecIni, fecFin).FirstOrDefault();
                metr.sumJor = sumJornada ?? TimeSpan.Zero; ;

                var mayorTardanza = (
                    from reg in dreamDB.Tb_Diario
                    where reg.empleado == codigo && reg.fecha >= fecIni && reg.fecha <= fecFin
                    orderby reg.ingrTard descending
                    select reg.ingrTard
                ).FirstOrDefault();
                metr.mayorTard = Convert.ToDateTime(mayorTardanza.ToString());

                var mayorRefri = (
                    from reg in dreamDB.Tb_Diario
                    where reg.empleado == codigo && reg.fecha >= fecIni && reg.fecha <= fecFin
                    orderby reg.exeRefr descending
                    select reg.exeRefr
                ).FirstOrDefault();
                metr.mayorExeRef = Convert.ToDateTime(mayorRefri.ToString());

                var mayorJornada= (
                    from reg in dreamDB.Tb_Diario
                    where reg.empleado == codigo && reg.fecha >= fecIni && reg.fecha <= fecFin
                    orderby reg.exeJornd descending
                    select reg.exeJornd
                ).FirstOrDefault();
                metr.mayorExeJornd = Convert.ToDateTime(mayorJornada.ToString());

                return metr;    
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public List<DiarioBECons> ListarDiarioEmpGeneral(Int32 codigo, DateTime fecIni, DateTime fecFin)
        {
            try
            {
                DreamFoam_DBEntities dreamDB = new DreamFoam_DBEntities();
                List<DiarioBECons> objLista = new List<DiarioBECons>();

                var query = (
                        from reg in dreamDB.Tb_Diario
                        join empl in dreamDB.Tb_Empleado on reg.empleado equals empl.codEmpleado
                        join are in dreamDB.Tb_Area on empl.codArea equals are.codArea
                        where reg.empleado == codigo && reg.fecha >= fecIni && reg.fecha <= fecFin
                        select new
                        {
                            fecha = reg.fecha,
                            apellidos = empl.apellidos,
                            nombres = empl.nombres,
                            nomArea = are.nomArea,
                            ingrTard = reg.ingrTard,
                            exeRefr = reg.exeRefr,
                            exeJornd = reg.exeJornd,
                            observ = reg.observ
                        }
                    );

                foreach (var obj in query)
                {
                    DiarioBECons diario = new DiarioBECons();
                    diario.fecha = obj.fecha;
                    diario.empleado = obj.apellidos + "," + obj.nombres;
                    diario.area = obj.nomArea;
                    diario.ingrTard = Convert.ToDateTime(obj.ingrTard.ToString());
                    diario.exeRefr = Convert.ToDateTime(obj.exeRefr.ToString());
                    diario.exeJornd = Convert.ToDateTime(obj.exeJornd.ToString());
                    diario.observ = obj.observ;
                    objLista.Add(diario);
                }
                return objLista;

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public List<DiarioBECons> ListarDiarioEmpEstad(Int32 codigo, String estado, DateTime fecIni, DateTime fecFin)
        {
            try
            {
                DreamFoam_DBEntities dreamDB = new DreamFoam_DBEntities();
                List<DiarioBECons> objLista = new List<DiarioBECons>();

                var query = (
                        from reg in dreamDB.Tb_Diario
                        join empl in dreamDB.Tb_Empleado on reg.empleado equals empl.codEmpleado
                        join are in dreamDB.Tb_Area on empl.codArea equals are.codArea
                        where reg.empleado == codigo && reg.observ == estado && reg.fecha >= fecIni && reg.fecha <= fecFin
                        select new
                        {
                            fecha = reg.fecha,
                            apellidos = empl.apellidos,
                            nombres = empl.nombres,
                            nomArea = are.nomArea,
                            ingrTard = reg.ingrTard,
                            exeRefr = reg.exeRefr,
                            exeJornd = reg.exeJornd,
                            observ = reg.observ
                        }
                    );

                foreach (var obj in query)
                {
                    DiarioBECons diario = new DiarioBECons();
                    diario.fecha = obj.fecha;
                    diario.empleado = obj.apellidos + "," + obj.nombres;
                    diario.area = obj.nomArea;
                    diario.ingrTard = Convert.ToDateTime(obj.ingrTard.ToString());
                    diario.exeRefr = Convert.ToDateTime(obj.exeRefr.ToString());
                    diario.exeJornd = Convert.ToDateTime(obj.exeJornd.ToString());
                    diario.observ = obj.observ;
                    objLista.Add(diario);
                }
                return objLista;

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public List<DiarioBECons> ListarDiarioCompleto (String area, String estado, DateTime fecIni, DateTime fecFin)
        {
            try
            {
                DreamFoam_DBEntities dreamDB = new DreamFoam_DBEntities ();
                List<DiarioBECons> objLista = new List<DiarioBECons> ();

                var query = (
                        from reg in dreamDB.Tb_Diario
                        join empl in dreamDB.Tb_Empleado on reg.empleado equals empl.codEmpleado
                        join are in dreamDB.Tb_Area on empl.codArea equals are.codArea
                        where are.nomArea == area && reg.observ == estado && reg.fecha >= fecIni && reg.fecha <= fecFin
                        select new
                        {
                            fecha = reg.fecha,
                            apellidos = empl.apellidos,
                            nombres = empl.nombres,
                            nomArea = are.nomArea,
                            ingrTard = reg.ingrTard,
                            exeRefr = reg.exeRefr,
                            exeJornd = reg.exeJornd,
                            observ = reg.observ
                        }
                    );

                foreach ( var obj in query )
                {
                    DiarioBECons diario = new DiarioBECons ();
                    diario.fecha = obj.fecha;
                    diario.empleado = obj.apellidos + "," + obj.nombres;
                    diario.area = obj.nomArea;
                    diario.ingrTard = Convert.ToDateTime(obj.ingrTard.ToString());
                    diario.exeRefr = Convert.ToDateTime(obj.exeRefr.ToString());
                    diario.exeJornd = Convert.ToDateTime(obj.exeJornd.ToString());
                    diario.observ = obj.observ;
                    objLista.Add ( diario );   
                }
                return objLista;

            }catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public List<DiarioBECons> ListarDiarioArea(String area, DateTime fecIni, DateTime fecFin)
        {
            try
            {
                DreamFoam_DBEntities dreamDB = new DreamFoam_DBEntities();
                List<DiarioBECons> objLista = new List<DiarioBECons>();

                var query = (
                        from reg in dreamDB.Tb_Diario
                        join empl in dreamDB.Tb_Empleado on reg.empleado equals empl.codEmpleado
                        join are in dreamDB.Tb_Area on empl.codArea equals are.codArea
                        where are.nomArea == area && reg.fecha >= fecIni && reg.fecha <= fecFin
                        select new
                        {
                            fecha = reg.fecha,
                            apellidos = empl.apellidos,
                            nombres = empl.nombres,
                            nomArea = are.nomArea,
                            ingrTard = reg.ingrTard,
                            exeRefr = reg.exeRefr,
                            exeJornd = reg.exeJornd,
                            observ = reg.observ
                        }
                    );

                foreach (var obj in query)
                {
                    DiarioBECons diario = new DiarioBECons();
                    diario.fecha = obj.fecha;
                    diario.empleado = obj.apellidos + "," + obj.nombres;
                    diario.area = obj.nomArea;
                    diario.ingrTard = Convert.ToDateTime(obj.ingrTard.ToString());
                    diario.exeRefr = Convert.ToDateTime(obj.exeRefr.ToString());
                    diario.exeJornd = Convert.ToDateTime(obj.exeJornd.ToString());
                    diario.observ = obj.observ;
                    objLista.Add(diario);
                }
                return objLista;

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public List<DiarioBECons> ListarDiarioEstado(String estado, DateTime fecIni, DateTime fecFin)
        {
            try
            {
                DreamFoam_DBEntities dreamDB = new DreamFoam_DBEntities();
                List<DiarioBECons> objLista = new List<DiarioBECons>();

                var query = (
                        from reg in dreamDB.Tb_Diario
                        join empl in dreamDB.Tb_Empleado on reg.empleado equals empl.codEmpleado
                        join are in dreamDB.Tb_Area on empl.codArea equals are.codArea
                        where reg.observ == estado && reg.fecha >= fecIni && reg.fecha <= fecFin
                        select new
                        {
                            fecha = reg.fecha,
                            apellidos = empl.apellidos,
                            nombres = empl.nombres,
                            nomArea = are.nomArea,
                            ingrTard = reg.ingrTard,
                            exeRefr = reg.exeRefr,
                            exeJornd = reg.exeJornd,
                            observ = reg.observ
                        }
                    );

                foreach (var obj in query)
                {
                    DiarioBECons diario = new DiarioBECons();
                    diario.fecha = obj.fecha;
                    diario.empleado = obj.apellidos + "," + obj.nombres;
                    diario.area = obj.nomArea;
                    diario.ingrTard = Convert.ToDateTime(obj.ingrTard.ToString());
                    diario.exeRefr = Convert.ToDateTime(obj.exeRefr.ToString());
                    diario.exeJornd = Convert.ToDateTime(obj.exeJornd.ToString());
                    diario.observ = obj.observ;
                    objLista.Add(diario);
                }
                return objLista;

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public List<DiarioBECons> ListarDiario (DateTime fecIni, DateTime fecFin)
        {
            try
            {
                DreamFoam_DBEntities dreamDB = new DreamFoam_DBEntities();
                List<DiarioBECons> objLista = new List<DiarioBECons>();

                var query = (
                        from reg in dreamDB.Tb_Diario
                        join empl in dreamDB.Tb_Empleado on reg.empleado equals empl.codEmpleado
                        join are in dreamDB.Tb_Area on empl.codArea equals are.codArea
                        where reg.fecha >= fecIni && reg.fecha <= fecFin
                        select new
                        {
                            fecha = reg.fecha,
                            apellidos = empl.apellidos,
                            nombres = empl.nombres,
                            nomArea = are.nomArea,
                            ingrTard = reg.ingrTard,
                            exeRefr = reg.exeRefr,
                            exeJornd = reg.exeJornd,
                            observ = reg.observ
                        }
                    );

                foreach (var obj in query)
                {
                    DiarioBECons diario = new DiarioBECons();
                    diario.fecha = obj.fecha;
                    diario.empleado = obj.apellidos + "," + obj.nombres;
                    diario.area = obj.nomArea;
                    diario.ingrTard = Convert.ToDateTime(obj.ingrTard.ToString());
                    diario.exeRefr = Convert.ToDateTime(obj.exeRefr.ToString());
                    diario.exeJornd = Convert.ToDateTime(obj.exeJornd.ToString());
                    diario.observ = obj.observ;
                    objLista.Add(diario);
                }
                return objLista;

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
