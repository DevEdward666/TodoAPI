using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TodoAPI.Model.TodoModel;
using TodoAPI.Repository;

namespace TodoAPI.Controller
{
    [ApiController]
    public class TodoController : ControllerBase
    {
        TodoRepo _todo = new TodoRepo();
        [HttpGet]
        [Route("api/start")]
        public ActionResult start()
        {
            return Ok("The server has started successfully");
        }
        [HttpPost]
        [Route("api/task/insertNew")]
        public ActionResult InsertNewTask(TaskModel.inserttask inserttask)
        {
            return Ok(_todo.InserNewTask(inserttask));
        }
        [HttpPost]
        [Route("api/task/UpdateTask")]
        public ActionResult UpdateTask(TaskModel.updatetask updatetask)
        {
            return Ok(_todo.UpdateTask(updatetask));
        }    
        [HttpPost]
        [Route("api/task/uncheckedTask")]
        public ActionResult uncheckedTask(TaskModel.updatetask updatetask)
        {
            return Ok(_todo.uncheckedTask(updatetask));
        }
             
        [HttpGet]
        [Route("api/task/getAlltodolist")]
        public ActionResult getAlltodolist()
        {
            return Ok(_todo.getAlltodolist());
        }


    }
}
