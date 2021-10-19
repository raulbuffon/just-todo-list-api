using System.Linq;
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

        public IQueryable<TodoItem> GetAll()
        {
            IQueryable<TodoItem> result = todoRepository.TodoItems;
            
            return result;
        }

        public async Task<TodoItem> GetById(int id)
        {
            var result = await todoRepository.TodoItems.FindAsync(id);
            return result;
        }

        public async Task<TodoItem> Post(TodoItem todoItem)
        {
            await todoRepository.TodoItems.AddAsync(todoItem);
            await todoRepository.SaveChangesAsync();
            
            return todoItem;
        }

        public async Task<TodoItem> Put(TodoItem todoItem)
        {
            var existingItem = todoRepository.TodoItems.Find(todoItem.Id);
            todoRepository.TodoItems.Remove(existingItem);
            await todoRepository.TodoItems.AddAsync(todoItem);
            await todoRepository.SaveChangesAsync();
            
            return todoItem;
        }

        public async Task<TodoItem> Delete(int id)
        {
            var existingItem = todoRepository.TodoItems.Find(id);
            todoRepository.TodoItems.Remove(existingItem);
            await todoRepository.SaveChangesAsync();
            
            return null;
        }
    }
}