using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using WCF_Servicio.Models;

namespace WCF_Servicio
{
    [ServiceContract]
    public interface IService1
    {
        [OperationContract] List<Ciudad> listadoCiudad();//ok
        [OperationContract] List<Horario> listado_Horarios(int idCiudad);//ok
        [OperationContract] Horario horario_Esp(int idHorario);//ok
        [OperationContract] List<Pasaje> listado_Pasajes(int idHorario);//ok
        [OperationContract] string agregar_asiento(Pasaje reg);//ok
        [OperationContract] List<Horario> Horarios();//ok


    }
}
