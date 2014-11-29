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
    public class TaskStepsController : Controller
    {
        private TaskListDatabaseEntities db = new TaskListDatabaseEntities();

        // GET: TaskSteps
        public ActionResult Index(int? id)
        {
            //if (ViewBag.taskId != null)
            //{
            //     var taskSteps = db.TaskSteps.Where(ts => ts.taskId == id).Include(t => t.TaskToDo);
            //    //var Tools = db.TaskSteps.Include(v => v.Tools);
            //    return View(taskSteps.ToList());
            //}
            if (id == null)
            {
                var taskSteps = db.TaskSteps.Where(ts => ts.taskId == id).Include(t => t.TaskToDo);

                //var taskSteps = db.TaskSteps.Include(t => t.TaskToDo);
                var Tools = db.Tools.Include(v => v.TaskSteps);
                return View(taskSteps.ToList());
            }
            if (id != null)
            {
                var taskSteps = db.TaskSteps.Where(ts => ts.taskId == id).Include(t => t.TaskToDo);
                //var Tools = db.TaskSteps.Include(v => v.Tools);
                return View(taskSteps.ToList());
            }
            return View();
        }
        

        // GET: TaskSteps/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TaskStep taskStep = db.TaskSteps.Find(id);
            if (taskStep == null)
            {
                return HttpNotFound();
            }
            return View(taskStep);
        }

        // GET: TaskSteps/Create/id
        public ActionResult Create(int? id)
        {
            ViewBag.taskId = new SelectList(db.TaskToDoes, "id", "name", id);
            SelectList selectlist = new SelectList(db.Tools, "id", "name");
            ViewBag.tools = selectlist;
            ViewBag.tasktodoID = id;
            //ViewBag.tasktodoID = ViewBag.taskId;
            return View();
        }

        // POST: TaskSteps/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,name,description,timeRequired,isDone,taskId,stepPriority")] TaskStep taskStep)
        {
            if (ModelState.IsValid)
            {
                db.TaskSteps.Add(taskStep);
                db.SaveChanges();      
                //ViewBag.taskId = new SelectList(db.TaskToDoes, "id", "name", id);
                //ViewBag.tasktodoID = taskStep.TaskToDo;
                return RedirectToAction("Index", new { id = taskStep.taskId });
            }

            //ViewBag.tools = new SelectList(db.Tools, "id", "name", taskStep.Tools);
            return View(taskStep.taskId);
        }

        // GET: TaskSteps/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TaskStep taskStep = db.TaskSteps.Find(id);
            if (taskStep == null)
            {
                return HttpNotFound();
            }
            ViewBag.taskId = new SelectList(db.TaskToDoes, "id", "name", id);
            return View(taskStep);
        }

        // POST: TaskSteps/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,name,description,timeRequired,isDone,taskId,stepPriority,Tools")] TaskStep taskStep)
        {
            if (ModelState.IsValid)
            {
                db.Entry(taskStep).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index", new { id = taskStep.taskId });
            }
            ViewBag.taskId = new SelectList(db.TaskToDoes, "id", "name", taskStep.taskId);
            ViewBag.tools = new SelectList(db.Tools, "id", "name", taskStep.Tools);
            return View(taskStep);
        }

        // GET: TaskSteps/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TaskStep taskStep = db.TaskSteps.Find(id);
            if (taskStep == null)
            {
                return HttpNotFound();
            }
            return View(taskStep);
        }

        // POST: TaskSteps/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            TaskStep taskStep = db.TaskSteps.Find(id);
            db.TaskSteps.Remove(taskStep);
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
