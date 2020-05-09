using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Cedesistemas.Api.Models
{
    public class Producto
    {
        public Producto()
        {
            Id = Guid.NewGuid();
        }
        [Key]
        public Guid Id { get; set; }
        public Guid RestauranteId { get; set; }
        public string Nombre { get; set; } 
        public double Precio { get; set; }
        public string Descripcion { get; set; } 
        public Restaurante Restaurante { get; set; }
    }
}
