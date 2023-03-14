using System.ComponentModel.DataAnnotations;

namespace BlazorFullStackCrud.Shared.DTO
{
    public class OrderDTO
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Name is required")]
        [StringLength(50, ErrorMessage = "Name cannot be longer than 50 characters")]
        public string Name { get; set; }
        [Required(ErrorMessage = "State is required")]
        [StringLength(50, ErrorMessage = "State cannot be longer than 50 characters")]
        public string State { get; set; }
        public List<WindowDTO> Windows { get; set; } = new List<WindowDTO>();
    }

}
