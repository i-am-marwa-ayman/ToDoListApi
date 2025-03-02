using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ToDoList.Models {
    public enum TaskPriority {
        Low,
        Medium,
        High
    }

    public class ToDoTask {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id {set; get;}
        [Required]
        public string? Title {set; get;}
        [Required]
        public DateTime DueDate {get; set;}
        [Required]
        public TaskPriority Priority {get; set;}
        public string? Description {set; get;}
        public List<string>? Tags {set; get;}
    }
}
