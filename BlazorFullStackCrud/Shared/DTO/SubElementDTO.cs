using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BlazorFullStackCrud.Shared.DTO
{
    public class SubElementDTO
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Element is required")]
        [StringLength(50, ErrorMessage = "Element cannot be longer than 50 characters")]
        public string Element { get; set; }
        [Required(ErrorMessage = "Type is required")]
        [StringLength(50, ErrorMessage = "Type cannot be longer than 50 characters")]
        public string Type { get; set; }
        [Range(1, int.MaxValue, ErrorMessage = "Width must be greater than 0")]
        public int Width { get; set; }
        [Range(1, int.MaxValue, ErrorMessage = "Height must be greater than 0")]
        public int Height { get; set; }
    }
}
