using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Threading;
using System.Web;
using System.Web.Mvc;
using WebMVC.App_Code;
using WebMVC.Models;
using WebMVC.Common;
namespace WebMVC.Controllers
{
    public class UserwwwsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        public void init()
        {
          var a=  new LLRequiredAttribute();
        }
        public UserwwwsController()
        {
            Thread.CurrentThread.CurrentCulture=new CultureInfo("zh");
            Thread.CurrentThread.CurrentUICulture=new CultureInfo("zh");
        }
        // GET: Userwwws
        public async Task<ActionResult> Index()
        {
            return View(await db.Userwwws.ToListAsync());
        }

        // GET: Userwwws/Details/5
        public async Task<ActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Userwww userwww = await db.Userwwws.FindAsync(id);
            if (userwww == null)
            {
                return HttpNotFound();
            }
            return View(userwww);
        }

        // GET: Userwwws/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Userwwws/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Id,Name,Age,CreateTime")] Userwww userwww)
        {
            if (ModelState.IsValid)
            {
                userwww.Id = Guid.NewGuid();
                db.Userwwws.Add(userwww);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(userwww);
        }

        // GET: Userwwws/Edit/5
        public async Task<ActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Userwww userwww = await db.Userwwws.FindAsync(id);
            if (userwww == null)
            {
                return HttpNotFound();
            }
            return View(userwww);
        }

        // POST: Userwwws/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Id,Name,Age,CreateTime")] Userwww userwww)
        {
            if (ModelState.IsValid)
            {
                db.Entry(userwww).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(userwww);
        }

        // GET: Userwwws/Delete/5
        public async Task<ActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Userwww userwww = await db.Userwwws.FindAsync(id);
            if (userwww == null)
            {
                return HttpNotFound();
            }
            return View(userwww);
        }

        // POST: Userwwws/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(Guid id)
        {
            Userwww userwww = await db.Userwwws.FindAsync(id);
            db.Userwwws.Remove(userwww);
            await db.SaveChangesAsync();
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
