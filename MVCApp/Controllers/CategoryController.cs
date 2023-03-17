using Microsoft.AspNetCore.Mvc;
using MVCApp.Data;
using MVCApp.Models;

namespace MVCApp.Controllers
{
    public class CategoryController : Controller
    {
    private readonly ApplicationDbContext _db;
        public CategoryController(ApplicationDbContext db)
        {
            _db = db;
        }
    
        public IActionResult Index()
        {
            IEnumerable<Category> objcategorylist = _db.Categories; //can add  .ToList();    
            return View(objcategorylist);
        }
        //get method
        public IActionResult Create()
        {
            return View();
        }
        //post method
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create( Category obj)
        {
            if (obj.name == obj.displayorder.ToString())
            {
                ModelState.AddModelError("name", "The Name and Display Order can't be the same");
            }
            if (ModelState.IsValid)
            {
                _db.Categories.Add(obj);
                _db.SaveChanges();
                return RedirectToAction("Index");   //<==>  return RedirectToAction("Index","Category");

            }
            else
            {
                return View(obj);
            }
        }

        //get method
        public IActionResult Edit(int ? id)
        {
            if(id == null || id == 0)
            {
                return NotFound();
            }  
            var categoryfind = _db.Categories.Find(id);
            if (categoryfind == null)
            {
                return NotFound();
            }
            return View(categoryfind);
        }
        //post method
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Category obj)
        {
            if (obj.name == obj.displayorder.ToString())
            {
                ModelState.AddModelError("name", "The Name and Display Order can't be the same");
            }
            if (ModelState.IsValid)
            {
                _db.Categories.Update(obj);
                _db.SaveChanges();
                return RedirectToAction("Index");   //<==>  return RedirectToAction("Index","Category");

            }
            else
            {
                return View(obj);
            }
        }

        //get method
        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var obj = _db.Categories.Find(id);
            if (obj == null)
            {
                return NotFound();
            }
            _db.Categories.Remove(obj);
                  _db.SaveChanges();
            return RedirectToAction("Index");

            //return View(categoryfind);
        }
        //post method


        //[HttpPost,ActionName("Delete")]
        
        //[ValidateAntiForgeryToken]
        //public IActionResult DeletePost(int? id)
        //{
        //    var obj = _db.Categories.Find(id);
        //    if (obj == null)
        //    {
        //        return NotFound();
        //    }
        //        _db.Categories.Remove(obj);
        //        _db.SaveChanges();
        //        return RedirectToAction("Index");   //<==>  return RedirectToAction("Index","Category");

           
        //}
    }
}
