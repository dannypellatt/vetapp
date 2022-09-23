using System;
using System.Data;
using Dapper;
using Microsoft.AspNetCore.Mvc;
using vetapp.Models;

namespace vetapp
{
    public class PetRepository : IPetRepository
    {
        private readonly IDbConnection _conn;

        public PetRepository(IDbConnection conn)
        {
            _conn = conn;
        }

        public IEnumerable<Pet> GetAllPets()
        {
            return _conn.Query<Pet>("SELECT pet.idpet, pet.pet_first_name, pet.pet_last_name, pet.pet_type, owner.owner_first_name, owner.owner_last_name, owner.idowner FROM vetapp.pet INNER JOIN vetapp.owner ON pet.idowner = owner.idowner;");
        }

        public Pet GetPet(int id)
        {
            return _conn.QuerySingle<Pet>("SELECT pet.idpet, pet.pet_first_name, pet.pet_last_name, pet.pet_type, owner.owner_first_name, owner.owner_last_name, owner.idowner FROM vetapp.pet INNER JOIN vetapp.owner ON pet.idowner = owner.idowner WHERE IDPET = @id", new { id = id });
        }

        public void UpdatePet(Pet pet)
        {
            _conn.Execute("UPDATE pet SET Name = @pet_first_name, Surname = @pet_last_name, Type = @pet_type, Owner = idowner WHERE IDPET = @id",
             new { Name = pet.pet_first_name, Surname = pet.pet_last_name, Type = pet.pet_type, Owner=pet.idowner});
        }

        public void InsertPet(Pet petToInsert)
        {
            _conn.Execute("INSERT INTO pet (ID, NAME, SURNAME, TYPE, IDOWNER) VALUES (@idpet, @pet_first_name, @pet_last_name, @pet_type, @idowner);",
                new { name = petToInsert.pet_first_name, surname = petToInsert.pet_last_name, type = petToInsert.pet_type, idowner = petToInsert.idowner });
        }

        public IEnumerable<Owner> GetOwners()
        {
            return _conn.Query<Owner>("SELECT * FROM owner;");
        }

        public Pet AssignOwner()
        {
            var OwnerList = GetOwners();
            var pet = new Pet();
            pet.Owners = OwnerList;
            return pet;
        }
    }
}

