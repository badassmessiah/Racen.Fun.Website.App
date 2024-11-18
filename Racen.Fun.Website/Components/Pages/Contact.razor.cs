using System.ComponentModel.DataAnnotations;
using System.IO;
using Microsoft.AspNetCore.Components;
using Microsoft.Extensions.Configuration;
using Microsoft.JSInterop;

namespace Racen.Fun.Website.Components.Pages
{
    public partial class Contact
    {
        private ContactModel contactModel = new ContactModel();
        private string csvFilePath;
        private string successMessage;
        [Inject] private IJSRuntime JS { get; set; }

        protected override void OnInitialized()
        {

            var appSettingsPath = Path.Combine(Directory.GetCurrentDirectory(), "appsettings.json");

            csvFilePath = Path.Combine(Path.GetDirectoryName(appSettingsPath), "emails.csv");
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
            [Required(ErrorMessage = "Email is required.")]
            [EmailAddress(ErrorMessage = "Invalid email address.")]
            public string Email { get; set; }
        }
    }
}
