using System;
using System.Collections.Generic;
using System.Text;

namespace CedesistemasApp.Models
{
    public class StudentModel
    {
        public string Nombres { get; set; }
        public string Apellidos { get; set; }
        public string Cedula { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public string Email { get; set; }
        public string Telefono { get; set; }
    }
}
