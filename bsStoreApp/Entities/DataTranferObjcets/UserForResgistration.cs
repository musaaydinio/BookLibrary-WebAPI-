using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Entities.DataTranferObjcets
{
    public record UserForResgistrationDto
    {
        [XmlElement("firstName")]
        public string? FirstName { get; set; }
        [XmlElement("lastName")]
        public string? LastName { get; set; }

        [XmlElement("userName")]
        [Required(ErrorMessage ="Username is required.")]
        public string? UserName { get; set; }

        [XmlElement("password")]
        [Required(ErrorMessage = "Password is required.")]
        public string? Password { get; set; }

        [XmlElement("email")]
        public string? Email { get; set; }
        [XmlElement("phoneNumber")]
        public string? PhoneNumber { get; set; }
        [XmlElement("roles")]
        public ICollection<string>? Roles { get; set; }

    }
}


