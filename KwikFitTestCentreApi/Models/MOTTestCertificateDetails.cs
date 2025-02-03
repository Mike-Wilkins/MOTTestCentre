using CsvHelper.Configuration.Attributes;
using System.ComponentModel.DataAnnotations;

namespace KwikFitTestCentreApi.Models
{
    public class MOTTestCertificateDetails
    {
        [Name("Id")]
        public int Id { get; set; }

        [Name("VehicleID")]
        [Display(Name = "Vehicle identification number")]
        [Required(ErrorMessage = "Vehicle ID is required")]
        public string? VehicleID { get; set; }

        [Name("RegistrationNumber")]
        [Display(Name = "Registration number")]
        [Required(ErrorMessage = "Registration number is required")]
        public string? RegistrationNumber { get; set; }

        [Name("CountryOfRegistration")]
        [Display(Name = "Country of registration")]
        [Required(ErrorMessage = "Registration number is required")]
        public string? CountryOfRegistration { get; set; }

        [Name("Make")]
        [Required(ErrorMessage = "Make is required")]
        public string? Make { get; set; }

        [Name("Model")]
        [Required(ErrorMessage = "Model is required")]
        public string? Model { get; set; }

        [Name("VehicleCategory")]
        [Display(Name = "Vehicle Category")]
        [Required(ErrorMessage = "Vehicle category is required")]
        public string? VehicleCategory { get; set; }

        [Name("Mileage")]
        [Required(ErrorMessage = "Mileage is required")]
        public string? Mileage { get; set; }

        [Name("TestResult")]
        public string? TestResult { get; set; }

        [Name("DateOfTest")]
        [Display(Name = "Date of Test")]
        [Required(ErrorMessage = "Test date is required")]
        public string? DateOfTest { get; set; }

        [Name("ExpiryDate")]
        [Display(Name = "Expiry date")]
        [Required(ErrorMessage = "Expiry date is required")]
        public string? ExpiryDate { get; set; }

        [Name("EariestTestDate")]
        [Display(Name = "Eariest Test Date")]
        [Required(ErrorMessage = "Earliest test date is required")]
        public string? EariestTestDate { get; set; }

        [Name("TestLocation")]
        [Display(Name = "Test location")]
        [Required(ErrorMessage = "Test location is required")]
        public string? TestLocation { get; set; }

        [Name("TestOrganisation")]
        [Display(Name = "Test organisation")]
        [Required(ErrorMessage = "Test organisation is required")]
        public string? TestOrganisation { get; set; }

        [Name("InspectorName")]
        [Display(Name = "Inspector name")]
        [Required(ErrorMessage = "Inspector name is required")]
        public string? InspectorName { get; set; }

        [Name("MOTTestNumber")]
        [Display(Name = "MOT test number")]
        [Required(ErrorMessage = "MOT test number is required")]
        public string? MOTTestNumber { get; set; }
    }
}
