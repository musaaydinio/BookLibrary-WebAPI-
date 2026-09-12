using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DataTranferObjcets
{
    public record UserForResgistrationDto
    {
        /// <example>John</example>
        public string? FirstName { get; set; }
        /// <example>Doe</example>
        public string? LastName { get; set; }

        /// <example>johndoe</example>
        [Required(ErrorMessage ="Username is required.")]
        public string? UserName { get; set; }

        /// <example>Password123!</example>
        [Required(ErrorMessage = "Password is required.")]
        public string? Password { get; set; }

        /// <example>john.doe@example.com</example>
        public string? Email { get; set; }
        /// <example>5551234567</example>
        public string? PhoneNumber { get; set; }
        /// <example>["User"]</example>
        public ICollection<string>? Roles { get; set; }

    }
}
