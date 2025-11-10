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
using WebArticle.ServiceLayer;
using WebArticle.App_Start;
using WebArticle.Views.ViewModels;


namespace WebArticle.Areas.Admin.Controllers
{
    public class CategoriesController : Controller
    {
        private WebContext db = new WebContext();
        CategoryService _CategoryService;

        public CategoriesController()
        {
            _CategoryService = new CategoryService(db);
        }

        public ActionResult Index()
        {
            var categoryList = _CategoryService.GetAll().ToList();
            var categoryListViewModel = AutoMapperConfig.mapper.Map<List<Category>, List<CategoryViewModel>>(categoryList);
            return View(categoryListViewModel);

        }


        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Category category = _CategoryService.GetEntity(id.Value);
            if (category == null)
            {
                return HttpNotFound();
            }
            return View(category);
        }



        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "CategoryId,Title,ImageName")] CategoryViewModel categoryView)
        {
            if (ModelState.IsValid)
            {
                Category category = AutoMapperConfig.mapper.Map<CategoryViewModel,Category>(categoryView);

                _CategoryService.Add(category);
                _CategoryService.save();
                return RedirectToAction("Index");
            }

            return View(categoryView);
        }



        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Category category = _CategoryService.GetEntity(id.Value);
            if (category == null)
            {
                return HttpNotFound();
            }
            return View(category);
        }


        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "CategoryId,Title,ImageName")] Category category)
        {
            if (ModelState.IsValid)
            {
                _CategoryService.Update(category);
                _CategoryService.save();
                return RedirectToAction("Index");
            }
            return View(category);
        }


      
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Category category = _CategoryService.GetEntity(id.Value);
            if (category == null)
            {
                return HttpNotFound();
            }
            return View(category);
        }


      
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Category category = _CategoryService.GetEntity(id);
            _CategoryService.Delete(category);
            _CategoryService.save();
            return RedirectToAction("Index");
        }


        protected override void Dispose(bool disposing)
        {
            _CategoryService.Dispose();
        }
    }
}
