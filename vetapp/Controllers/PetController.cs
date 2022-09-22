using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace vetapp.Controllers
{
    public class PetController : Controller
    {
        private readonly IPetRepository repo;

        public PetController(IPetRepository repo)
        {
            this.repo = repo;
        }


        public IActionResult Index()
        {
            var pets = repo.GetAllPets();
            return View(pets);
        }
    }
}

