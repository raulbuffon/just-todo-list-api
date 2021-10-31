using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace just_todo_list_api.Models
{
    public interface ICategory
    {
        int Id { get; set; }
        string Name { get; set; }
        ICollection<TodoItem> TodoItems { get; set; }
    }

    public class Category : ICategory
    {
        public int Id { get; set; }

        public string Name { get; set; }

        [JsonIgnore]
        public virtual ICollection<TodoItem> TodoItems { get; set; }

        Category()
        {
            this.TodoItems = new HashSet<TodoItem>();
        }
    }
}