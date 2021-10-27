using System;
using System.ComponentModel.DataAnnotations;

namespace just_todo_list_api.Models
{
        public interface ITodoItem
    {
        int Id { get; set; }
        string Name { get; set; }
        string Description { get; set; }
        bool IsComplete { get; set; }
        DateTime? CreatedDate { get; set; }
        DateTime? FinishDate { get; set; }
        int CategoryId { get; set; }
        Category Category { get; set; }
    }

    public class TodoItem : ITodoItem
    {
        public int Id { get; set; }

        [Required]
        [StringLength(80, ErrorMessage = "Name lenght can't be more than 80.")]
        public string Name { get; set; }
        
        [StringLength(200, ErrorMessage = "Name lenght can't be more than 200.")]
        public string Description { get; set; }

        [Required]
        public bool IsComplete { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? FinishDate { get; set; }
        public int CategoryId { get; set; }
        public Category Category { get; set; }
    }
}