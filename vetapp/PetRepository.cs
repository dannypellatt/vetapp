using System;
using System.Data;
using Dapper;
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
            return _conn.Query<Pet>("SELECT * FROM PET;");
        }
    }
}

