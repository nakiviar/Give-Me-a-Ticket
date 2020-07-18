using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace WCF_Servicio.Models
{
    [DataContract]
    public class Ciudad
    {
        [DataMember] public int idCiudad { get; set; }
        [DataMember] public string nomCiudad { get; set; }
    }
}