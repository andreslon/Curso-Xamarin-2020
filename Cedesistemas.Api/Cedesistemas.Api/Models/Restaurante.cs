using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Cedesistemas.Api.Models
{
    public class Restaurante
    {
        public Restaurante()
        {
            Id = Guid.NewGuid();
        }
        [Key]
        public Guid Id { get; set; }
        public string Nombre { get; set; }
        public string Imagen { get; set; }
        public string Direccion { get; set; }
        public string Telefono { get; set; }
        public string SitioWeb { get; set; }
        public double Latitud { get; set; }
        public double Longitud { get; set; }
        public List<Producto> Productos { get; set; }
    }
}
