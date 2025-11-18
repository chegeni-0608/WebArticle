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
using System.IO;


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

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "CategoryId,Title")] CategoryViewModel categoryView, HttpPostedFileBase imageUpload)
        {
            if (ModelState.IsValid)
            {

                string newImageName = "nophoto.png";
                if (imageUpload != null)
                {
                    if (imageUpload.ContentType != "image/jpeg" && imageUpload.ContentType != "image/png")
                    {
                        ModelState.AddModelError("imageUpload", "تصویر شما فقط باید با فرمت png یا jpg یا jpeg باشد!");
                        return View();
                    }
                    if (imageUpload.ContentLength > 300000)
                    {
                        ModelState.AddModelError("imageUpload", "سایز تصویر شما نباید بیشتر از 300 کیلوبایت باشد!");
                        return View();
                    }

                    newImageName = Guid.NewGuid().ToString().Replace("-", "") + Path.GetExtension(imageUpload.FileName);
                    imageUpload.SaveAs(Server.MapPath("~/images/Category/" + newImageName));
                }
                categoryView.ImageName = newImageName;
                Category category = AutoMapperConfig.mapper.Map<CategoryViewModel, Category>(categoryView);
                _CategoryService.Add(category);
                _CategoryService.save();
                return RedirectToAction("Index");
            }

            return View(categoryView);
        }


    

        [HttpGet]
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

          var  categoryViewModel = AutoMapperConfig.mapper.Map<Category, CategoryViewModel>(category);
            return View(categoryViewModel);
        }


        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "CategoryId,Title,ImageName")] CategoryViewModel categoryView, HttpPostedFileBase imageUpload)
        {
            if (ModelState.IsValid)
            {
                if(imageUpload != null)
                {
                  if(categoryView.ImageName != "nophoto.png")
                    {
                       System.IO.File.Delete(Server.MapPath("~/images/Category/") + categoryView.ImageName);
                    }
                  else
                    {
                        System.IO.File.Delete(Server.MapPath("~/images/Category/") + categoryView.ImageName);
                        categoryView.ImageName = Guid.NewGuid().ToString().Replace("-", "") + Path.GetExtension(imageUpload.FileName);
                    }
                    imageUpload.SaveAs(Server.MapPath("~/images/Category/" + categoryView.ImageName));
                }

                var category = AutoMapperConfig.mapper.Map<CategoryViewModel, Category>(categoryView);

                _CategoryService.Update(category);
                _CategoryService.save();
                return RedirectToAction("Index");
            }
            return View(categoryView);
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
            var categoryView = AutoMapperConfig.mapper.Map<Category, CategoryViewModel>(category);
            return View(categoryView);
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
            var categoryView = AutoMapperConfig.mapper.Map < Category , CategoryViewModel > (category);
            return View(categoryView);
        }


      
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Category category = _CategoryService.GetEntity(id);
            _CategoryService.Delete(category);
            _CategoryService.save();
            if (category.ImageName != "nophoto.png")
            {
                System.IO.File.Delete(Server.MapPath("~/images/Category/" + category.ImageName));
            }
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            _CategoryService.Dispose();
        }
    }
}
