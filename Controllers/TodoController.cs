using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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
        public IEnumerable<TodoItem> GetAllOnRequest()
        {
            return todoItemRepository.GetAll();
        }

        [HttpGet("{id}")]
        //GET /api/Todo/id
        public async Task<ActionResult<TodoItem>> GetById(int id)
        {
            var todoItem = await todoItemRepository.GetById(id);

            if(todoItem == null) return NotFound();

            return Ok(todoItem);
        }

        [HttpPost]
        //POST /api/Todo
        public async Task<ActionResult<TodoItem>> Post([FromBody]TodoItem todoItem)
        {
            if(!ModelState.IsValid) return BadRequest();

            var newTodoItem = await todoItemRepository.Post(todoItem);
            return newTodoItem;
        }

        [HttpPut]
        //PUT /api/Todo
        public async Task<ActionResult<TodoItem>> Put([FromBody]TodoItem todoItem)
        {
            if(!ModelState.IsValid) return BadRequest();

            var newTodoItem = await todoItemRepository.Put(todoItem);
            return newTodoItem;
        }

        [HttpDelete("id")]
        //DELETE /api/Todo
        public async Task<ActionResult<TodoItem>> Delete(int id)
        {
            var newTodoItem = await todoItemRepository.Delete(id);
            return Ok();
        }
    }
}
