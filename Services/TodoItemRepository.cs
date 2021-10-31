using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
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

        public IEnumerable<TodoItem> GetAll()
        {
            var result = todoRepository.TodoItems.Include(x => x.Category).ToList();
            
            return result;
        }

        public async Task<TodoItem> GetById(int id)
        {
            var result = await todoRepository.TodoItems.Include(x => x.Category).Where(item => item.Id == id).FirstAsync();
            return result;
        }

        public async Task<TodoItem> Post(TodoItem todoItem)
        {
            if(!CategoryExists(todoItem.CategoryId))
                return null;

            await todoRepository.TodoItems.AddAsync(todoItem);
            await todoRepository.SaveChangesAsync();
            
            return await GetById(todoItem.Id);
        }

        public async Task<TodoItem> Put(TodoItem todoItem)
        {
            if(!CategoryExists(todoItem.CategoryId))
                return null;

            var existingItem = todoRepository.TodoItems.Find(todoItem.Id);

            todoRepository.TodoItems.Remove(existingItem);
            await todoRepository.TodoItems.AddAsync(todoItem);

            await todoRepository.SaveChangesAsync();
            
            return await GetById(todoItem.Id);
        }

        public async Task<TodoItem> Delete(int id)
        {
            var existingItem = todoRepository.TodoItems.Find(id);
            todoRepository.TodoItems.Remove(existingItem);
            await todoRepository.SaveChangesAsync();
            
            return null;
        }

        private bool CategoryExists(int categoryId)
        {
            bool existsInDb = todoRepository.Categories.Where(x => x.Id == categoryId).Any();

            return existsInDb;
        }
    }
}