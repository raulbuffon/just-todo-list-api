using System;

namespace just_todo_list_api.Models
{
    public interface ITodoItem
    {
        int Id { get; set; }
        string Name { get; set; }
        string Description { get; set; }
        bool IsComplete { get; set; }
        DateTime CreatedDate { get; set; }
        DateTime FinishDate { get; set; }
    }
}