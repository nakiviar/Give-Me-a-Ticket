using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace WCF_Servicio.Models
{
    [DataContract]
    public class Horario
    {
        [DataMember] public int idHorario { get; set; }
        [DataMember] public int idCiudad { get; set; }
        [DataMember] public DateTime fechasalida { get; set; }
        [DataMember] public string horasalida { get; set; }
        [DataMember] public string placa { get; set; }
        [DataMember] public Decimal costo { get; set; }
    }
}