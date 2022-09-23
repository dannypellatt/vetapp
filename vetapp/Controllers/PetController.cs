using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using vetapp.Models;

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

        public IActionResult ViewPet(int id)
        {
            var pet = repo.GetPet(id);
            return View(pet);
        }

        public IActionResult UpdatePet(int id)
        {
            Pet pet = repo.GetPet(id);
            if (pet == null)
            {
                return View("PetNotFound");
            }
            return View(pet);
        }

        public IActionResult UpdatePetToDatabase(Pet pet)
        {
            repo.UpdatePet(pet);

            return RedirectToAction("ViewPet", new { id = pet.idpet });
        }

        public IActionResult InsertPet()
        {
            var prod = repo.AssignOwner();
            return View(prod);
        }

        //This redirect to index may be wrong place

        public IActionResult InsertPetToDatabase(Pet petToInsert)
        {
            repo.InsertPet(petToInsert);
            return RedirectToAction("Index");
        }
    }
}

