using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities
{
    public class Order
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required(ErrorMessage = "Please enter a name for the order")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Please enter a state for the order")]
        public string State { get; set; }
        public List<Window> Windows { get; set; } = new List<Window>();

    }

}
