using CsvHelper.Configuration.Attributes;
using System.ComponentModel.DataAnnotations;

namespace KwikFitTestCentreApi.Models
{
    public class AuthorisedMOTTesters
    {
        [Name("Id")]
        public int Id { get; set; }

        [Name("Firstname")]
        [Required(ErrorMessage = "Firstname is required")]
        public string? Firstname { get; set; }

        [Name("Surname")]
        [Required(ErrorMessage = "Surname is required")]
        public string? Surname { get; set; }

        [Name("UserID")]
        [Required(ErrorMessage = "User ID is required")]
        public string? UserID { get; set; }

        [Name("isManager")]
        public bool isManager { get; set; }
    }
}
