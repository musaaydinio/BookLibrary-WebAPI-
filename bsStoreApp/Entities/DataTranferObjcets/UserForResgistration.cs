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
        [XmlElement("firstName")]
        public string? FirstName { get; set; }

        [XmlElement("lastName")]
        public string? LastName { get; set; }

        [Required(ErrorMessage = "Username is required.")]
        [XmlElement("userName")]
        public string? UserName { get; set; }

        [Required(ErrorMessage = "Password is required.")]
        [XmlElement("password")]
        public string? Password { get; set; }

        [XmlElement("email")]
        public string? Email { get; set; }

        [XmlElement("phoneNumber")]
        public string? PhoneNumber { get; set; }

        [XmlElement("roles")]
        public ICollection<string>? Roles { get; set; }
    }
}


