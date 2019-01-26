using System;
using System.ComponentModel.DataAnnotations;
using PatientServiceModels;

namespace PatientService.Models
{
    public class PatientAddress
    {
        [Key]
        public int Id { get; set; }

        public string Street { get; set; }

        public string ZipCode { get; set; }

        public string Town { get; set; }

        public Country Country { get; set; }

        public PatientAddress(string street, string zipCode, string town, Country country)
        {
            Street = street ?? throw new ArgumentNullException(nameof(Street));
            ZipCode = zipCode ?? throw new ArgumentNullException(nameof(ZipCode));
            Town = town ?? throw new ArgumentNullException(nameof(Town));
            Country = country;
        }
    }
}
