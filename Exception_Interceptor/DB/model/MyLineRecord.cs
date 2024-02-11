using System.ComponentModel.DataAnnotations;

namespace Exception_Interceptor.DB.model
{
    public class MyLineRecord
    {
        [Key]
        public int Id { get; set; }
        public string Line { get; set; }
        public DateTime CreatedAt { get; set; }
        public int DuplicateCount { get; set; }
    }
}
