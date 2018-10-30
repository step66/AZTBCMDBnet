using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Models;
using WebApplication1.Repositories;

namespace WebApplication1.Controllers
{
    public class TodoController : Controller
    {
        // GET: Todo
        public ActionResult Index()
        {
            var repository = new TodoRepository();
            var entities = repository.All();

            var models = entities.Select(x => new TodoModel
            {
                Id = x.RowKey,
                Group = x.PartitionKey,
                Content = x.Content,
                Due = x.Due,
                Completed = x.Completed,
                Timestamp = x.Timestamp
            });

            return View(models);
        }
    }
}