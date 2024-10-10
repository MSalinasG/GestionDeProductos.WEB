using GestionDeProductos.Data.Helpers;
using GestionDeProductos.Data.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionDeProductos.Data.Database
{
    public static class DatabaseInitializer
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context =
                new ApplicationDbContext
                (serviceProvider.GetRequiredService<DbContextOptions<ApplicationDbContext>>()))
            {
                CreateProducts(serviceProvider, context);
            }
        }

        public static void CreateProducts(IServiceProvider serviceProvider, ApplicationDbContext context)
        {

            var productsToCreate = new List<Products>
            {
                new Products
                {
                    Id = Guid.NewGuid(),
                    Nombre = "Galletas",
                    Descripcion = "",
                    EsActivo = true,
                    Cantidad = 50,
                    PrecioEntero = 20,
                    FechaExpiracion = DateTime.Now
                },
                new Products
                {
                    Id = Guid.NewGuid(),
                    Nombre = "Fideos",
                    Descripcion = "",
                    EsActivo = false,
                    Cantidad = 20,
                    PrecioEntero = 50,
                    FechaExpiracion = DateTime.Now
                },
                new Products
                {
                    Id = Guid.NewGuid(),
                    Nombre = "Aceite",
                    Descripcion = "",
                    EsActivo = true,
                    Cantidad = 60,
                    PrecioEntero = 15,
                    FechaExpiracion = DateTime.Now
                },
                new Products
                {
                    Id = Guid.NewGuid(),
                    Nombre = "Pan",
                    Descripcion = "",
                    EsActivo = true,
                    Cantidad = 50,
                    PrecioEntero = 20,
                    FechaExpiracion = DateTime.Now
                }

            };

            context.Products.AddRange(productsToCreate);
            context.SaveChanges();

        }
    }
}
