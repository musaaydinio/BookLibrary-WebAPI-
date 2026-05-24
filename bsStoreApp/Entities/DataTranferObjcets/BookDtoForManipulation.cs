using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DataTranferObjcets
{
    public abstract record BookDtoForManipulation
    {
        [Required(ErrorMessage = "Price is a required field.")]
        [MinLength(2,ErrorMessage ="Title must of at least 2 characters")]
        [MaxLength(50, ErrorMessage = "Title must of at maximum 50 characters")]
        public string Title { get; init; }
        [Required(ErrorMessage ="Price is a required field.")]
        [Range(0,1000)]
        public decimal Price { get; init; }
    }
}
