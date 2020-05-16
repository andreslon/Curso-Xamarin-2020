using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using Cedesistemas.Api.Data;
using Cedesistemas.Api.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
namespace Cedesistemas.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InstallController : ControllerBase
    {
        public CedesistemasDbContext CedesistemasDbContext { get; set; }
        public InstallController(CedesistemasDbContext cedesistemasDbContext)
        {
            CedesistemasDbContext = cedesistemasDbContext;
        }
        [HttpGet]
        public async Task<IActionResult> Install()
        {
            await InstallSeed();
            return Ok();
        }

        private async Task InstallSeed()
        {
            var random = new Random();
            var rest = new List<Restaurante>
              {
                new Restaurante
                {
                    Direccion = "Carrera 73 # Circular 4ta - 13, Medellín Colombia",
                    Imagen = "https://media-cdn.tripadvisor.com/media/photo-s/10/ab/0f/cd/muy-pero-muy-acogedor.jpg",
                    Latitud = 6.252487,
                    Longitud = -75.591399,
                    Nombre = "La Pampa Burger & Ribs",
                    SitioWeb = "http://www.lapampa.co/",
                    Telefono = "+57 4 3660706",
                    Calificacion=random.Next(0,5)
                },
                new Restaurante
                {
                    Direccion = "Carrera 32d 7a # 7a-77 Local 01, Medellín 050021 Colombia",
                    Imagen = "https://media-cdn.tripadvisor.com/media/photo-s/1b/27/3a/a3/caption.jpg",
                    Latitud = 6.252487,
                    Longitud = -75.591399,
                    Nombre = "Betty's Bowls",
                    SitioWeb = "http://bettysbowls.com/en",
                    Telefono = "+57 319 4458527",
                    Calificacion=random.Next(0,5)
                },
                new Restaurante
                {
                    Direccion = "Carrera 43D #10-77 Local 116, Medellín 050021 Colombia",
                    Imagen = "https://media-cdn.tripadvisor.com/media/photo-s/19/9a/d1/0e/fallafel-vegetarian.jpg",
                    Latitud = 6.252487,
                    Longitud = -75.591399,
                    Nombre = "Pokawa",
                    SitioWeb = "http://www.pokawa.co/",
                    Telefono = "+57 313 4948365",
                    Calificacion=random.Next(0,5)
                },
                new Restaurante
                {
                    Direccion = "Carrera 34 7 29 Barrio Provenza Poblado Medellín, Medellín 050021 Colombia",
                    Imagen = "https://media-cdn.tripadvisor.com/media/photo-s/18/4d/dc/b4/asi-nos-vemos.jpg",
                    Latitud = 6.252487,
                    Longitud = -75.591399,
                    Nombre = "Tika Dogs Gourmet",
                    SitioWeb = "http://www.facebook.com/tikadogsgourmet/",
                    Telefono = "+57 314 8943337",
                    Calificacion=random.Next(0,5)
                },
                new Restaurante
                {
                    Direccion = "Primer parque de laureles Calle 38 # 79-46, Medellín 050031 Colombia",
                    Imagen = "https://media-cdn.tripadvisor.com/media/photo-p/18/dc/c2/42/tiradito-de-pez-a-banado.jpg",
                    Latitud = 6.252487,
                    Longitud = -75.591399,
                    Nombre = "Malanga del Trópico",
                    SitioWeb = "http://www.malangadeltropico.com/",
                    Telefono = "+57 311 7823084",
                    Calificacion=random.Next(0,5)
                },
                new Restaurante
                {
                    Direccion = "Carrera 80 # 32 ee 04, Medellín Colombia",
                    Imagen = "https://media-cdn.tripadvisor.com/media/photo-s/17/a0/bb/85/t-bone-steak.jpg",
                    Latitud = 6.252487,
                    Longitud = -75.591399,
                    Nombre = "Toro Restaurante",
                    SitioWeb = "http://www.facebook.com/ToroRestauranteMedellin",
                    Telefono = "+57 300 7603091",
                    Calificacion=random.Next(0,5)
                },
                new Restaurante
                {
                    Direccion = "Carrera 37 10a 23, Medellín 050021 Colombia",
                    Imagen = "https://media-cdn.tripadvisor.com/media/photo-s/15/47/48/a9/la-letra-b-insignia-de.jpg",
                    Latitud = 6.252487,
                    Longitud = -75.591399,
                    Nombre = "Bárbaro Cocina Primitiva Sede Poblado",
                    SitioWeb = "http://www.barbarococinaprimitiva.com/",
                    Telefono = "+57 4 4799447",
                    Calificacion=random.Next(0,5)
                },
                new Restaurante
                {
                    Direccion = "Carrera 76 73b 27 Laureles, Medellín 050031 Colombia",
                    Imagen = "https://media-cdn.tripadvisor.com/media/photo-s/16/2f/98/e5/segundo-puesto-en-pizza.jpg",
                    Latitud = 6.252487,
                    Longitud = -75.591399,
                    Nombre = "Takout",
                    SitioWeb = "https://www.facebook.com/TakoutColombia/",
                    Telefono = "+57 4 2500203",
                    Calificacion=random.Next(0,5)
                }
              };
            await CedesistemasDbContext.Restaurante.AddRangeAsync(rest);

            var prods = new List<Producto>();

            foreach (var r in rest)
            {

                prods.Add(new Producto
                {
                    RestauranteId = r.Id,
                    Nombre = "Mini Sandwiches Ahumados",
                    Precio = 17900,
                    Descripcion = "4 mini sandwiches, cada uno con una de nuestras carnes ahumadas (pernil, tocino, res y pollo), cogollo europeo, tomate y una salsa de tu elección"
                });
                prods.Add(new Producto
                {
                    RestauranteId = r.Id,
                    Nombre = "Sweet Bacon",
                    Precio = 15900,
                    Descripcion = "7 lonjas de tocino ahumado y caramelizado, acompañado de una salsa de tu elección."
                });
                prods.Add(new Producto
                {
                    RestauranteId = r.Id,
                    Nombre = "De tapeo",
                    Precio = 13900,
                    Descripcion = "5 porciones de pan baguete recién horneados, acompañado de una deliciosa mermelada de tocineta (tocineta, champiñones y cebolla caramelizada)"
                });
                prods.Add(new Producto
                {
                    RestauranteId = r.Id,
                    Nombre = "Palitos de Pollo con Uchuva",
                    Precio = 14900,
                    Descripcion = "Tiras de pollo de 150gr apanadas en finas hierbas para untar en una deliciosa salsa de uchuvas."
                });
                prods.Add(new Producto
                {
                    RestauranteId = r.Id,
                    Nombre = "Cacerola de Queso",
                    Precio = 15900,
                    Descripcion = "Delicioso queso ahumado acompañado de tomates cherry, albahaca y orégano."
                });
                prods.Add(new Producto
                {
                    RestauranteId = r.Id,
                    Nombre = "Pollo con Pimentón Caramelizado",
                    Precio = 19500,
                    Descripcion = "Sándwich de pollo, panceta, acompañado de cogollo europeo, tomate, queso tipo cheddar y pimentón a la plancha caramelizado y sin piel. ​"
                });
                prods.Add(new Producto
                {
                    RestauranteId = r.Id,
                    Nombre = "POrk-cheta",
                    Precio = 21900,
                    Descripcion = "Sándwich de panceta ahumada por 6 horas, cogollo europeo, tomate verde y queso tipo cheddar. ​"
                });
                prods.Add(new Producto
                {
                    RestauranteId = r.Id,
                    Nombre = "Philadelphia",
                    Precio = 20900,
                    Descripcion = "Sándwich de res, pollo y cerdo ahumados, salteados en queso derretido de mozzarella, cebolla caramelizada y pimentón."
                });
                prods.Add(new Producto
                {
                    RestauranteId = r.Id,
                    Nombre = "Tentación Vegetariana",
                    Precio = 19500,
                    Descripcion = "Proteína a base de lentejas, acompañada de champiñones salteados, cogollo europeo, tomate verde y queso tipo cheddar."
                });
                prods.Add(new Producto
                {
                    RestauranteId = r.Id,
                    Nombre = "Grosseto",
                    Precio = 16700,
                    Descripcion = "Pan rústico acompañado de láminas de pechuga de pollo zukini y calabacín parrillados, tomate y lechuga, salteados en nuestra salsa César"
                });
                prods.Add(new Producto
                {
                    RestauranteId = r.Id,
                    Nombre = "Calamares Apanados",
                    Precio = 23900,
                    Descripcion = "Anillos de Calamar pasados por huevo, harina, se sirven fritos y se acompañan con salsa tártara"
                });
                prods.Add(new Producto
                {
                    RestauranteId = r.Id,
                    Nombre = "Ceviche Mixto",
                    Precio = 30900,
                    Descripcion = "Camarón y pescado marinados en zumo de limón, cilantro y cebolla"
                });
                prods.Add(new Producto
                {
                    RestauranteId = r.Id,
                    Nombre = "Filet Mignón",
                    Precio = 39900,
                    Descripcion = "Medallón de solomito calidad Brahman, con tocineta, asado a la parrilla, bañado en salsa demi-glace y champiñones"
                });
                prods.Add(new Producto
                {
                    RestauranteId = r.Id,
                    Nombre = "Mixto de Pasta con: Pollo, Cerdo o Res",
                    Precio = 34900,
                    Descripcion = "Filete asado a la parrilla, acompañado de espagueti en salsa: Alfredo o Carbonara."
                });
                prods.Add(new Producto
                {
                    RestauranteId = r.Id,
                    Nombre = "Parrillada carnes blancas",
                    Precio = 31800,
                    Descripcion = "Carne de cerdo, costilla y pechuga de pollo a la parrilla, mazorcas, cascos de papa, arepa y ensalada de lechuga, tomate y aguacate"
                });
                prods.Add(new Producto
                {
                    RestauranteId = r.Id,
                    Nombre = "Mixto 3 Carnes",
                    Precio = 32000,
                    Descripcion = "Medallones de Solomito, pechuga y cañón de cerdo"
                });
            }

            await CedesistemasDbContext.Producto.AddRangeAsync(prods);

            await CedesistemasDbContext.SaveChangesAsync();
        }
    }
}