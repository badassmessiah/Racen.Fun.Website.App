using System.ComponentModel.DataAnnotations;
using System.IO;
using Microsoft.AspNetCore.Components;
using Microsoft.Extensions.Configuration;
using Microsoft.JSInterop;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;

namespace Racen.Fun.Website.Components.Pages
{
    public partial class Contact
    {
        private ContactModel contactModel = new ContactModel();
        private string csvFilePath;
        private string successMessage;
        private List<Country> countries = new List<Country>();
        [Inject] private IJSRuntime JS { get; set; }

        protected override void OnInitialized()
        {
            var appSettingsPath = Path.Combine(Directory.GetCurrentDirectory(), "appsettings.json");
            csvFilePath = Path.Combine(Path.GetDirectoryName(appSettingsPath), "emails.csv");

            /// Load countries from Configuration
            var countriesJsonPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "countries", "Countries.json");
            var countriesJson = File.ReadAllText(countriesJsonPath);
            countries = JsonSerializer.Deserialize<List<Country>>(countriesJson);
        }

        private async Task HandleValidSubmit()
        {
            SaveEmailToCsv(contactModel.Email);
            successMessage = "Thank you for registering!";
            Console.WriteLine("Form submitted successfully!");

            await Task.Delay(2000);
            await JS.InvokeVoidAsync("scrollToElement", "main");
        }

        private void SaveEmailToCsv(string email)
        {
            try
            {
                using (var writer = new StreamWriter(csvFilePath, append: true))
                {
                    writer.WriteLine(email);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred while saving the email: {ex.Message}");
            }
        }

        public class ContactModel
        {
            [Required(ErrorMessage = "Name is required.")]
            public string Name { get; set; }

            [Required(ErrorMessage = "Country is required.")]
            public string Country { get; set; }

            [Required(ErrorMessage = "Email is required.")]
            [EmailAddress(ErrorMessage = "Invalid email address.")]
            public string Email { get; set; }
        }
    }
}