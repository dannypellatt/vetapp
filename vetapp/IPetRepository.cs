﻿using System;
using vetapp.Models;

namespace vetapp
{
    public interface IPetRepository
    {
        public IEnumerable<Pet> GetAllPets();
    }
}

