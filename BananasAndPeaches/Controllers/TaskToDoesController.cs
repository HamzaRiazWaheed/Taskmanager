using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using BananasAndPeaches.Models;

namespace BananasAndPeaches.Controllers
{
    public class TaskToDoesController : Controller
    {
        private TaskListDatabaseEntities db = new TaskListDatabaseEntities();

        // GET: TaskToDoes
        public ActionResult Index()
        {
            var taskToDoes = db.TaskToDoes.Include(t => t.Category);
          // if (!String.IsNullOrEmpty(searchString))
          //{
          //      taskToDoes = taskToDoes.Where(s => s.Title.Constains(searchString));
          //}
            return View(taskToDoes.ToList());
        }

        // GET: TaskToDoes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TaskToDo taskToDo = db.TaskToDoes.Find(id);
            if (taskToDo == null)
            {
                return HttpNotFound();
            }
            return View(taskToDo);
        }

        // GET: TaskToDoes/Create
        public ActionResult Create()
        {
            ViewBag.categoryId = new SelectList(db.Categories, "id", "name");
            return View();
        }

        // POST: TaskToDoes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,name,description,dueDate,isDone,budgetEstimate,categoryId")] TaskToDo taskToDo)
        {
            if (ModelState.IsValid)
            {
                db.TaskToDoes.Add(taskToDo);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.categoryId = new SelectList(db.Categories, "id", "name", taskToDo.categoryId);
            return View(taskToDo);
        }

        // GET: TaskToDoes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TaskToDo taskToDo = db.TaskToDoes.Find(id);
            if (taskToDo == null)
            {
                return HttpNotFound();
            }
            ViewBag.categoryId = new SelectList(db.Categories, "id", "name", taskToDo.categoryId);
            return View(taskToDo);
        }

        // POST: TaskToDoes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,name,description,dueDate,isDone,budgetEstimate,categoryId")] TaskToDo taskToDo)
        {
            if (ModelState.IsValid)
            {
                db.Entry(taskToDo).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.categoryId = new SelectList(db.Categories, "id", "name", taskToDo.categoryId);
            return View(taskToDo);
        }

        // GET: TaskToDoes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TaskToDo taskToDo = db.TaskToDoes.Find(id);
            if (taskToDo == null)
            {
                return HttpNotFound();
            }
            return View(taskToDo);
        }

        // POST: TaskToDoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            TaskToDo taskToDo = db.TaskToDoes.Find(id);
            db.TaskToDoes.Remove(taskToDo);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
