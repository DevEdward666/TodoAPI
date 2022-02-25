using Dapper;
using ExecutiveAPI.Config;
using ExecutiveAPI.Model.Common;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TodoAPI.Model.TodoModel;

namespace TodoAPI.Repository
{
    public class TodoRepo
    {
        public ResponseModel getAlltodolist()
        {
            using (var con = new MySqlConnection(DatabaseConfig.GetConnection()))
            {
                con.Open();
                using (var tran = con.BeginTransaction())
                {
                    try
                    {
                        var data = con.Query($@"Select * from todolist",
                          null, transaction: tran
                            );

                        return new ResponseModel
                        {
                            success = true,
                            data = data
                        };
                    }
                    catch (Exception e)
                    {
                        return new ResponseModel
                        {
                            success = false,
                            message = $@"External server error. {e.Message.ToString()}",
                        };
                    }

                }
            }

        } 
        public ResponseModel InserNewTask(TaskModel.inserttask insertnewtask)
        {
            using (var con = new MySqlConnection(DatabaseConfig.GetConnection()))
            {
                con.Open();
                using (var tran = con.BeginTransaction())
                {
                    try
                    {
                        int insertask = con.Execute($@"Insert into todolist set task=@task,deadline=@deadline,createdAt=NOW()",
                          insertnewtask, transaction: tran
                            );

                        if(insertask <=0)
                        {
                            tran.Rollback();
                            return new ResponseModel
                            {
                                success = false,
                                message = "Error! Insertion of task failed"
                            };
                        }
                        tran.Commit();
                        return new ResponseModel
                        {
                            success = true,
                            message = "Task added successfully"
                        };

                    }
                    catch (Exception e)
                    {
                        return new ResponseModel
                        {
                            success = false,
                            message = $@"External server error. {e.Message.ToString()}",
                        };
                    }

                }
            }

        }
        public ResponseModel UpdateTask(TaskModel.updatetask updatenewtask)
        {
            using (var con = new MySqlConnection(DatabaseConfig.GetConnection()))
            {
                con.Open();
                using (var tran = con.BeginTransaction())
                {
                    try
                    {
                        int insertask = con.Execute($@"Update todolist set completedAt=NOW() where taskno=@taskno",
                          updatenewtask, transaction: tran
                            );

                        if(insertask <=0)
                        {
                            tran.Rollback();
                            return new ResponseModel
                            {
                                success = false,
                                message = "Error! Update of task failed"
                            };
                        }
                        tran.Commit();
                        return new ResponseModel
                        {
                            success = true,
                            message = "Task completed"
                        };

                    }
                    catch (Exception e)
                    {
                        return new ResponseModel
                        {
                            success = false,
                            message = $@"External server error. {e.Message.ToString()}",
                        };
                    }

                }
            }

        }  
        public ResponseModel uncheckedTask(TaskModel.updatetask updatenewtask)
        {
            using (var con = new MySqlConnection(DatabaseConfig.GetConnection()))
            {
                con.Open();
                using (var tran = con.BeginTransaction())
                {
                    try
                    {
                        int insertask = con.Execute($@"Update todolist set completedAt=NULL where taskno=@taskno",
                          updatenewtask, transaction: tran
                            );

                        if(insertask <=0)
                        {
                            tran.Rollback();
                            return new ResponseModel
                            {
                                success = false,
                                message = "Error! Update of task failed"
                            };
                        }
                        tran.Commit();
                        return new ResponseModel
                        {
                            success = true,
                            message = "Task completed"
                        };

                    }
                    catch (Exception e)
                    {
                        return new ResponseModel
                        {
                            success = false,
                            message = $@"External server error. {e.Message.ToString()}",
                        };
                    }

                }
            }

        }
    }
}
