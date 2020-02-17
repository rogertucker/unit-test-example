using System.ComponentModel.DataAnnotations;

namespace DBLayer.Models{

    public class BaseModel
    {
        public BaseModel() { }
        [Key]
        [Required]
        public int ID { get; set; }
    }

}