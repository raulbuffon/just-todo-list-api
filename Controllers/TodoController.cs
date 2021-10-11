using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using just_todo_list_api.Models;
using just_todo_list_api.Repositories;

namespace just_todo_list_api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TodoController : ControllerBase
    {
        private readonly ILogger<TodoController> _logger;
        private readonly TodoItemRepository todoItemRepository;

        public TodoController(ILogger<TodoController> logger, TodoItemRepository todoItemRepository)
        {
            _logger = logger;
            this.todoItemRepository = todoItemRepository;
        }

        [HttpGet]
        //GET /api/Todo
        public ActionResult<ITodoItem> GetAll()
        {
            return null;
        }

        [HttpPost]
        //POST /api/Todo
        public async Task<ActionResult<TodoItem>> Post([FromBody]TodoItem todoItem)
        {
            var newTodoItem = await todoItemRepository.Post(todoItem);
            return newTodoItem;
        }
    }
}
