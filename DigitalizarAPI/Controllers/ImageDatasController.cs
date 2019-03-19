using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using DigitalizarAPI;
using DigitalizarAPI.Models;

namespace DigitalizarAPI.Controllers
{
    public class ImageDatasController : Controller
    {
        private DBModelcs db = new DBModelcs();

        // GET: ImageDatas
        public async Task<ActionResult> Index()
        {
            return View(await db.ImageDatas.ToListAsync());
        }

        // GET: ImageDatas/Details/5
        public async Task<ActionResult> Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ImageData imageData = await db.ImageDatas.FindAsync(id);
            if (imageData == null)
            {
                return HttpNotFound();
            }
            return View(imageData);
        }

        // GET: ImageDatas/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ImageDatas/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "ID,Name,Document,Phone,Email,Created")] ImageData imageData)
        {
            if (ModelState.IsValid)
            {
                db.ImageDatas.Add(imageData);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(imageData);
        }

        // GET: ImageDatas/Edit/5
        public async Task<ActionResult> Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ImageData imageData = await db.ImageDatas.FindAsync(id);
            if (imageData == null)
            {
                return HttpNotFound();
            }
            return View(imageData);
        }

        // POST: ImageDatas/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "ID,Name,Document,Phone,Email,Created")] ImageData imageData)
        {
            if (ModelState.IsValid)
            {
                db.Entry(imageData).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(imageData);
        }

        // GET: ImageDatas/Delete/5
        public async Task<ActionResult> Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ImageData imageData = await db.ImageDatas.FindAsync(id);
            if (imageData == null)
            {
                return HttpNotFound();
            }
            return View(imageData);
        }

        // POST: ImageDatas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(string id)
        {
            ImageData imageData = await db.ImageDatas.FindAsync(id);
            db.ImageDatas.Remove(imageData);
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
