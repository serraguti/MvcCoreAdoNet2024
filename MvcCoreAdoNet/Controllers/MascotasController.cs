using Microsoft.AspNetCore.Mvc;
using MvcCoreAdoNet.Models;

namespace MvcCoreAdoNet.Controllers
{
    public class MascotasController : Controller
    {
        public IActionResult ColeccionMascotas()
        {
            List<Mascota> mascotasList = new List<Mascota>();
            mascotasList.Add(new Mascota { Nombre = "Flounder", Raza = "Pez", Edad = 21 });
            mascotasList.Add(new Mascota { Nombre = "Pluto", Raza = "Perro", Edad = 51 });
            mascotasList.Add(new Mascota { Nombre = "Olaf", Raza = "Cosa Fría", Edad = 11 });
            mascotasList.Add(new Mascota { Nombre = "Simba", Raza = "León", Edad = 18 });
            mascotasList.Add(new Mascota { Nombre = "Nala", Raza = "Leona", Edad = 17 });
            return View(mascotasList);
        }
    }
}
