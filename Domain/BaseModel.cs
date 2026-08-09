using System.ComponentModel.DataAnnotations;

namespace Domain
{
    public class BaseModel
    {
        [Key]
        public Guid ID { get; set; }

        public BaseModel()
        {
            ID = Guid.NewGuid();
        }
    }
}
