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
            return _conn.Query<Pet>("SELECT * FROM vetapp.pet;");
        }

        public Pet GetPet(int id)
        {
            return _conn.QuerySingle<Pet>("SELECT * FROM vetapp.pet WHERE IDPET = @id", new { id = id });
        }
    }
}

