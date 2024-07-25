using System.ComponentModel.DataAnnotations;

namespace My_Little_Dictionary___Anniversary_Edition.Model
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
