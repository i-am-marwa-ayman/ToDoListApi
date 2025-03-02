using System.ComponentModel.DataAnnotations;

namespace ToDoList.Models {
    public enum TaskPriority {
        Low,
        Medium,
        High
    }

    public class Task {
        [Required]
        [Key]
        public int Id {set; get;}
        [Required]
        public string? Title {set; get;}
        public string? Description {set; get;}
        [Required]
        public TaskPriority Priority {get; set;}
        public List<string>? Tags {set; get;}
        [Required]
        public DateTime DueDate {get; set;}
    }
}
