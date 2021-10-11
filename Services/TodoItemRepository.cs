using System.Threading.Tasks;
using just_todo_list_api.Models;

namespace just_todo_list_api.Repositories
{
    public class TodoItemRepository
    {
        private readonly TodoContext todoRepository;
        public TodoItemRepository(TodoContext todoRepository)
        {
            this.todoRepository = todoRepository;
        }

        public async Task<TodoItem> Post(TodoItem todoItem)
        {
            await todoRepository.TodoItems.AddAsync(todoItem);
            await todoRepository.SaveChangesAsync();
            
            return todoItem;
        }
    }
}