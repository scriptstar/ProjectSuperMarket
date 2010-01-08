using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Ajax;
using ProjectSuperMarket.Data;
using ProjectSuperMarket.Data.Azure;


namespace ProjectSuperMarket.Web.Controllers
{
    public class CategoryController : Controller
    {
        //
        // GET: /Category/

        CategoryRepository catRep = new CategoryRepository();

        public ActionResult Index()
        {
            IEnumerable<ICategory> cat = catRep.GetCategories();
            ViewData.Model = cat;
            return View();            
        }


        //public ActionResult Home()
        //{
        //    CategoryRepository catRep = new CategoryRepository();
        //    IEnumerable<ICategory> category = catRep.GetCategories();
        //    ViewData.Model = category;
        //    return View();
        //}

        //
        // GET: /Category/Details/5

        public ActionResult Details(string PartitionKey, string RowKey)
        {
            //CategoryRepository catRep = new CategoryRepository();
            ICategory cat = catRep.GetCategory(PartitionKey, RowKey);
            return View(cat);
        }

        //
        // GET: /Category/Create

        public ActionResult Create()
        {
            //CategoryRepository catRep = new CategoryRepository();
            IEnumerable<ICategory> cat = catRep.GetCategories(string.Empty).ToList();
            ViewData.Model = cat;
            //ViewData["categories"]= cat;
            return View();
        } 

        //
        // POST: /Category/Create

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Create(FormCollection form)
        {
            try
            {
                //CategoryRepository catRep = new CategoryRepository();
                Category cat = new Category();
                cat.Name = form["Name"];
                cat.PartitionKey = String.IsNullOrEmpty(form["lstCategories"]) ? String.Empty : form["lstCategories"];
                catRep.AddCategory(cat);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /Category/Edit/5

        public ActionResult Edit(string PartitionKey, string RowKey)
        {
            ICategory cat = catRep.GetCategory(PartitionKey, RowKey);
            
            IEnumerable<ICategory> categories = catRep.GetCategories(string.Empty);

            //ViewData["category"] = categories;
                        
            ViewData["category"] = new SelectList(categories, "Name", "Name", cat.PartitionKey);

            ViewData.Model = cat;

            return View();
        }

        //
        // POST: /Category/Edit/5

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here
 
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        public ActionResult Delete(string partitionKey, string rowkey)
        {

            //CategoryRepository catRep = new CategoryRepository();
            ICategory categoryToDelete = catRep.GetCategory(partitionKey,rowkey);

            return View(categoryToDelete);
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Delete(Category categoryToDelete)
        {
           //CategoryRepository catRep = new CategoryRepository();
           try
           {
               catRep.DeleteCategory(categoryToDelete.RowKey);
           }
           catch
           {
               ViewData["Message"] = "Sorry, We are unable to delete the specified record";
               return RedirectToAction("Index");
           }
           ViewData["Message"] = "The specified category deleted successfully";
           return RedirectToAction("Index");
        }   

    }
}
