using Microsoft.AspNetCore.Mvc;
using MvcCoreAdoNet.Models;
using MvcCoreAdoNet.Repositories;

namespace MvcCoreAdoNet.Controllers
{
    public class DoctoresController : Controller
    {
        RepositoryDoctor repo;

        public DoctoresController()
        {
            this.repo = new RepositoryDoctor();
        }

        public IActionResult DoctoresEspecialidad()
        {
            List<Doctor> doctores = this.repo.GetDoctores();
            return View(doctores);
        }

        [HttpPost]
        public IActionResult DoctoresEspecialidad(string especialidad)
        {
            List<Doctor> doctores = 
                this.repo.GetDoctoresEspecialidad(especialidad);
            return View(doctores);
        }

        public IActionResult DoctoresEspecialidadViewData()
        {
            List<Doctor> doctores = this.repo.GetDoctores();
            ViewData["ESPECIALIDADES"] = this.repo.GetEspecialidades();
            return View(doctores);
        }

        [HttpPost]
        public IActionResult DoctoresEspecialidadViewData(string especialidad)
        {
            List<Doctor> doctores =
                this.repo.GetDoctoresEspecialidad(especialidad);
            ViewData["ESPECIALIDADES"] = this.repo.GetEspecialidades();
            return View(doctores);
        }



        public IActionResult DoctoresEspecialidadOneModel()
        {
            List<Doctor> doctores = this.repo.GetDoctores();
            List<string> especialidades = this.repo.GetEspecialidades();
            ModelDoctores model = new ModelDoctores();
            model.Doctores = doctores;
            model.Especialidades = especialidades;
            return View(model);
        }

        [HttpPost]
        public IActionResult DoctoresEspecialidadOneModel(string especialidad)
        {
            List<Doctor> doctores =
                this.repo.GetDoctoresEspecialidad(especialidad);
            List<string> especialidades = this.repo.GetEspecialidades();
            ModelDoctores model = new ModelDoctores();
            model.Doctores = doctores;
            model.Especialidades = especialidades;
            return View(model);
        }
    }
}
