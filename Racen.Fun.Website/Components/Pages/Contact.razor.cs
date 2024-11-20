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
        private string alertClass = "alert-success";
        private int totalCount = 0;
        private int maxCount = 10000;
        private bool isFormDisabled = false;
        private ContactModels contactModel = new ContactModels();
        private string? successMessage;
        private List<Country> countries = new List<Country>();
        [Inject] private IJSRuntime? JS { get; set; }
        [Inject] private DbService? DbService { get; set; }
        protected override async Task OnInitializedAsync()
        {
            if (DbService != null)
            {
                totalCount = await DbService.GetTotalCountAsync();
                if (totalCount >= maxCount)
                {
                    isFormDisabled = true;
                }
            }
            // Load countries from Configuration
            var countriesJsonPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "countries", "Countries.json");
            var countriesJson = File.ReadAllText(countriesJsonPath);
            countries = JsonSerializer.Deserialize<List<Country>>(countriesJson) ?? new List<Country>();
        }

        private async Task HandleValidSubmit()
        {
            if (DbService != null)
            {
                totalCount = await DbService.GetTotalCountAsync();
                if (totalCount >= maxCount)
                {
                    successMessage = "Registration limit reached.";
                    alertClass = "alert-warning";
                    isFormDisabled = true;
                    return;
                }

                if (string.IsNullOrEmpty(contactModel.Email))
                {
                    successMessage = "Email is required.";
                    alertClass = "alert-warning";
                    return;
                }

                bool isEmailRegistered = await DbService.IsEmailRegisteredAsync(contactModel.Email);
                if (isEmailRegistered)
                {
                    successMessage = "This email is already registered.";
                    alertClass = "alert-warning";
                    return;
                }

                // Assign a new ID and set the country code
                contactModel.Id = Guid.NewGuid().ToString();
                var selectedCountry = countries.FirstOrDefault(c => c.Name == contactModel.CountryName);
                if (selectedCountry != null)
                {
                    contactModel.CountryCode = selectedCountry.Code;
                }

                // Save the new contact
                await DbService.CreateNewContactAsync(contactModel);
                successMessage = "Thank you for registering!";
                alertClass = "alert-success";
                // Optionally update the count and check again
                totalCount = await DbService.GetTotalCountAsync();
                if (totalCount >= maxCount)
                {
                    isFormDisabled = true;
                }

                // Scroll to the main element
                // if (JS != null)
                // {
                //     await JS.InvokeVoidAsync("scrollToElement", "main");
                // }
            }
            else
            {
                successMessage = "Something went wrong. Please try again later.";
                alertClass = "alert-danger";
            }
        }


    }
}