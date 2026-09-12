using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Entities.DataTranferObjcets
{
    [XmlRoot("UserForResgistrationDto")]
    public record UserForResgistrationDto
    {
        /// <example>Musa</example>
        [XmlElement("firstName")]
        public string? FirstName { get; set; }

        /// <example>Aydın</example>
        [XmlElement("lastName")]
        public string? LastName { get; set; }

        [Required(ErrorMessage = "Username is required.")]
        /// <example>musaaydin</example>
        [XmlElement("userName")]
        public string? UserName { get; set; }

        [Required(ErrorMessage = "Password is required.")]
        /// <example>Password123!</example>
        [XmlElement("password")]
        public string? Password { get; set; }

        /// <example>musa@example.com</example>
        [XmlElement("email")]
        public string? Email { get; set; }

        /// <example>5551234567</example>
        [XmlElement("phoneNumber")]
        public string? PhoneNumber { get; set; }

        /// <example>User</example>
        [XmlElement("roles")]
        public List<string>? Roles { get; set; }
    }
}


