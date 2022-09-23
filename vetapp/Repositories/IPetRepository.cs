using System;
using vetapp.Models;

namespace vetapp
{
    public interface IPetRepository
    {
        public IEnumerable<Pet> GetAllPets();
        public Pet GetPet(int id);
        public void UpdatePet(Pet pet);
        public void InsertPet(Pet petToInsert);
        public IEnumerable<Owner> GetOwners();
        public Pet AssignOwner();
    }
}

