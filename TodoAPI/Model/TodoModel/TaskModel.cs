using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TodoAPI.Model.TodoModel
{
    public class TaskModel
    {
        public class inserttask
        {
            public string task { get; set; }
            public short deadline { get; set; }
        }
        public class updatetask
        {
            public short taskno { get; set; }
        }
    }
}
