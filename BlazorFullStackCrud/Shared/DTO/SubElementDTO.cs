using System.ComponentModel.DataAnnotations.Schema;

namespace BlazorFullStackCrud.Shared.DTO
{
    public class SubElementDTO
    {
        public int Id { get; set; }
        public string Element { get; set; }
        public string Type { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }
    }
}
