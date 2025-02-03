using CsvHelper.Configuration.Attributes;
using System.ComponentModel.DataAnnotations;

namespace KwikFitTestCentreApi.Models
{
    public class AuthorisedMOTTesters
    {
        [Name("Id")]
        public int Id { get; set; }

        [Name("Firstname")]
        public string? Firstname { get; set; }

        [Name("Surname")]
        public string? Surname { get; set; }

        [Name("UserID")]
        [Required(ErrorMessage = "User ID is required")]
        public string? UserID { get; set; }
    }
}
