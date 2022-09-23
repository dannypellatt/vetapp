using System;
namespace vetapp.Models
{
    public class Pet
    {
        public int idpet { get; set; }
        public string? pet_first_name { get; set; }
        public string? pet_last_name { get; set; }
        public string? pet_type { get; set; }
        public IEnumerable<Owner> Owners { get; set; }

    }
}

