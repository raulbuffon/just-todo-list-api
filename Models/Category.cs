using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace just_todo_list_api.Models
{
    public interface ICategory
    {
        int Id { get; set; }
        string Name { get; set; }
    }

    public class Category : ICategory
    {
        public int Id { get; set; }

        public string Name { get; set; }

    }
}