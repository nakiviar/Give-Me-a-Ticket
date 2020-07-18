using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace WCF_Servicio.Models
{

     [DataContract]
     public class Bus
    {
            [DataMember] public string Placa { get; set; }
            [DataMember] public string chofer { get; set; }
                      
    }
}