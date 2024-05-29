using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProyDreamFoam_BE;

namespace ProyDreamFoam_ADO
{
    public class EmpleadoADO
    {
        public EmpleadoBECons ConsultarEmpleado(Int32 cod)
        {
            try
            {
                DreamFoam_DBEntities dreamDB = new DreamFoam_DBEntities();
                Tb_Empleado objEmple =
                    (
                        from reg in dreamDB.Tb_Empleado
                        where reg.codEmpleado == cod
                        select reg
                    ).FirstOrDefault();
                EmpleadoBECons empleadoBE = new EmpleadoBECons();
                if (objEmple == null ) {
                    empleadoBE.codEmpleado = 0;
                }
                else
                {
                    empleadoBE.codEmpleado = objEmple.codEmpleado;
                    empleadoBE.numroDoc = objEmple.numroDoc;
                    empleadoBE.tipoDoc = objEmple.Tb_Documento.descrLarga;
                    empleadoBE.nombreCompleto = objEmple.apellidos + ", "+objEmple.nombres;
                    empleadoBE.fecNacimiento = objEmple.fecNacimiento;
                    empleadoBE.genero = objEmple.genero;
                    empleadoBE.correo = objEmple.correo;
                    empleadoBE.direccion = objEmple.direccion;
                    empleadoBE.telefono = Convert.ToInt64(objEmple.telefono);
                    empleadoBE.fecIngreso = objEmple.fecIngreso;
                    empleadoBE.cargo = objEmple.Tb_Cargo.nomCargo;
                    empleadoBE.area = objEmple.Tb_Area.nomArea;
                    empleadoBE.sede = objEmple.Tb_Sede.nomSede;
                    empleadoBE.horario = objEmple.Tb_Horario.desHorario;
                    empleadoBE.foto = objEmple.foto;
                }

                return empleadoBE;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
