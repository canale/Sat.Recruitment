using System.ComponentModel.DataAnnotations;

namespace Sat.Recruitment.Api.Requests
{
    public class UserCreationRequest
    {
        [Required(ErrorMessage = "The Name is required")]
        public string Name { get; set; }

        [Required(ErrorMessage = "The Email is required")]
        public string Email { get; set; }

        [Required(ErrorMessage = "The Address is required")]
        public string Address { get; set; }

        [Required(ErrorMessage = "The Phone is required")]
        public string Phone { get; set; }

        public string UserType { get; set; }

        public decimal Money { get; set; }
    }
}
