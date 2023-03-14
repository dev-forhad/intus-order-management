using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorFullStackCrud.Shared.DTO
{

    public class WindowDTO
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Name is required")]
        [StringLength(50, ErrorMessage = "Name cannot be longer than 50 characters")]
        public string Name { get; set; }
        [Range(1, int.MaxValue, ErrorMessage = "Quantity of windows must be greater than 0")]
        public int QuantityOfWindows { get; set; }
        public int TotalSubElements { get; set; }
        public List<SubElementDTO> SubElements { get; set; } = new List<SubElementDTO>();
    }
}
