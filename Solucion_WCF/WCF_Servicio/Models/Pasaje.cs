using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace WCF_Servicio.Models
{
    [DataContract]
    public class Pasaje
    {
        [DataMember] public int npasaje { get; set; }
        [DataMember] public int idHorario { get; set; }
        [DataMember] public string dniper { get; set; }
        [DataMember] public string nomper { get; set; }
        [DataMember] public int nasiento { get; set; }
        [DataMember] public double precio { get; set; }
    }
}