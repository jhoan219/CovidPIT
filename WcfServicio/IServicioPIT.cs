using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace WcfServicio
{
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de interfaz "IServicioPIT" en el código y en el archivo de configuración a la vez.
    [ServiceContract]
    public interface IServicioPIT
    {

        [OperationContract] List<Ciudadano> Ciudadanos();
        [OperationContract] string AgregarCiudadano(Ciudadano reg);
        [OperationContract] string ActualizarCiudadano(Ciudadano reg);
        [OperationContract] Ciudadano DetalleCiudadano(string id);
        [OperationContract] string EliminarCiudadano(string id);

        /////////////////////////////
        [OperationContract] List<Users> Users();
        [OperationContract] string AgregarUsers(Ciudadano reg);
        [OperationContract] string ActualizarUsers(Ciudadano reg);
        [OperationContract] Ciudadano DetalleUsers(string id);
        [OperationContract] string EliminarUsers(string id);


    }

    [DataContract]
    public class Users
    {

        [DataMember] public string id  { get; set; }
        [DataMember] public string nombre { get; set; }
        [DataMember] public string apellidos { get; set; }
        [DataMember] public string dni { get; set; }
        [DataMember] public string direccion { get; set; }
        [DataMember] public string usuario { get; set; }
        [DataMember] public string contraseña { get; set; } 

    }



      
        [DataContract]
        public class Ciudadano
        {

            [DataMember] public string idciudadano { get; set; }
            [DataMember] public string nombres { get; set; }
            [DataMember] public string nacionalidad { get; set; }
            [DataMember] public string tipodocumento { get; set; }
            [DataMember] public string numdocumento { get; set; }
            [DataMember] public string iddepartamento { get; set; }
            [DataMember] public string idprovincia { get; set; }
            [DataMember] public string iddistrito { get; set; }
            [DataMember] public string idestado { get; set; }


        }
    }

