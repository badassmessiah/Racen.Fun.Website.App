using System.ComponentModel.DataAnnotations;

namespace Racen.Fun.Website.Components.Pages
{
    public partial class Contact
    {
        private ContactModel contactModel = new ContactModel();



        private void HandleValidSubmit()

        {

            // Handle form submission logic here

            Console.WriteLine("Form submitted successfully!");

        }



        public class ContactModel

        {

            [Required(ErrorMessage = "Email is required.")]

            [EmailAddress(ErrorMessage = "Invalid email address.")]

            public string Email { get; set; }

        }
    }
}
