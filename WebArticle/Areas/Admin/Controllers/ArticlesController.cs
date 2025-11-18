using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebArticle.ModelLayer;
using WebArticle.ModelLayer.Context;

namespace WebArticle.Areas.Admin.Controllers
{
    public class ArticlesController : Controller
    {
        private WebContext db = new WebContext();

        
        public ActionResult Index()
        {
            var articles = db.articles.Include(a => a.admin);
            return View(articles.ToList());
        }

        
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Article article = db.articles.Find(id);
            if (article == null)
            {
                return HttpNotFound();
            }
            return View(article);
        }

        
        public ActionResult Create()
        {
            ViewBag.AdminId = new SelectList(db.admins, "AdminId", "Name");
            return View();
        }

       
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ArticleId,Name,Content,ImageName,Like,Visit,RegisterDate,IsActive,AdminId")] Article article)
        {
            if (ModelState.IsValid)
            {
                db.articles.Add(article);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.AdminId = new SelectList(db.admins, "AdminId", "Name", article.AdminId);
            return View(article);
        }

       
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Article article = db.articles.Find(id);
            if (article == null)
            {
                return HttpNotFound();
            }
            ViewBag.AdminId = new SelectList(db.admins, "AdminId", "Name", article.AdminId);
            return View(article);
        }

       
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ArticleId,Name,Content,ImageName,Like,Visit,RegisterDate,IsActive,AdminId")] Article article)
        {
            if (ModelState.IsValid)
            {
                db.Entry(article).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.AdminId = new SelectList(db.admins, "AdminId", "Name", article.AdminId);
            return View(article);
        }

        
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Article article = db.articles.Find(id);
            if (article == null)
            {
                return HttpNotFound();
            }
            return View(article);
        }

        
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Article article = db.articles.Find(id);
            db.articles.Remove(article);
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
