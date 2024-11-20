using System.ComponentModel.DataAnnotations;
using System.IO;
using Microsoft.AspNetCore.Components;
using Microsoft.Extensions.Configuration;
using Microsoft.JSInterop;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using Racen.Fun.Website.Services;

namespace Racen.Fun.Website.Components.Pages
{
    public partial class Contact
    {
        private ContactModel contactModel = new ContactModel();
        private string successMessage;
        private List<Country> countries = new List<Country>();
        [Inject] private IJSRuntime JS { get; set; }
        [Inject] private DbService DbService { get; set; }
        protected override void OnInitialized()
        {
            // Load countries from Configuration
            var countriesJsonPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "countries", "Countries.json");
            var countriesJson = File.ReadAllText(countriesJsonPath);
            countries = JsonSerializer.Deserialize<List<Country>>(countriesJson);
        }

        private async Task HandleValidSubmit()
        {
            try
            {
                contactModel.Id = Guid.NewGuid().ToString();
                await DbService.CreateNewContactAsync(contactModel);
                successMessage = "Thank you for registering!";

                await Task.Delay(2000);
                await JS.InvokeVoidAsync("scrollToElement", "main");
            }
            catch (Exception ex)
            {
                successMessage = "An error occurred. Please try again later.";
            }
        }


        public class ContactModel
        {
            [Key]
            public string Id { get; set; }
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