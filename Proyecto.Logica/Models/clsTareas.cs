﻿namespace Proyecto.Logica.Models
{
    public class clsTareas
    {
        public int inCodigo { get; set; }
        public string stTitular { get; set; }
        public string stAsunto { get; set; }
        public string stFechaVencimiento { get; set; }
        public string stContacto { get; set; }
        public string stCuenta { get; set; }
        public clsEstadoTareas obclsEstadoTareas { get; set; }
        public clsPrioridad obclsPrioridad { get; set; }
        public string stEnviarMensaje { get; set; }
        public string stRepetir { get; set; }
        public string stDescripcion { get; set; }
    }
}