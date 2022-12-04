using BulkyBook.DataAccess.Repository.IRepository;
using BulkyBook.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace BulkyBookWeb.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ProductController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        public ProductController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public IActionResult Index()
        {
           IEnumerable<Product> productlist= _unitOfWork.Product.GetAll();

            return View(productlist);
        }

        ////GET
        //public IActionResult Create()
        //{
        //    return View();
        //}
        ////POST
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public IActionResult Create(Product obj)
        //{
          
        //    if (ModelState.IsValid)
        //    {
        //        _unitOfWork.Product.Add(obj);
        //        _unitOfWork.Save();
        //        TempData["Success"] = "Cover Type created successfully";
        //        return RedirectToAction(nameof(Index));
        //    }
        //    return View(obj);
        //}

        //GET
        public IActionResult Upsert(int? id)
        {
            Product product = new();
            IEnumerable<SelectListItem> CategoryList = _unitOfWork.Category.GetAll().Select(
                x => new SelectListItem
                {
                    Text = x.Name,
                    Value = x.Id.ToString()
                }
            );
            IEnumerable<SelectListItem> CoverTypeList = _unitOfWork.CoverType.GetAll().Select(
                x => new SelectListItem
                {
                    Text = x.Name,
                    Value = x.Id.ToString()
                }
            );
            if (id == null || id==0)
            {
                //create product
                ViewBag.CategoryList=CategoryList;
                ViewBag.CoverTypeList=CoverTypeList;
                return View(product);
            }
            else{
                //update product
            }
           
            return View();
        }
        //POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Upsert(Product obj)
        {

            if (ModelState.IsValid)
            {
                _unitOfWork.Product.Update(obj);
                _unitOfWork.Save();
                TempData["Success"] = "Cover Type updated successfully";
                return RedirectToAction(nameof(Index));
            }
            return View(obj);
        }

        //GET
        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                TempData["Error"] = "Id Null Error";
                //return View("Error");
                return NotFound();
            }
            var productFromDb = _unitOfWork.Product.GetFirstOrDefault(x=>x.Id==id);
            if(productFromDb == null)
            {
                TempData["Error"] = "This Cover Type is not found";
                //return View("Error");
                return NotFound();
            }
            return View(productFromDb);
        }

        //POST
        [HttpPost]
        public IActionResult Delete(Product obj)
        {
            _unitOfWork.Product.Remove(obj);
            _unitOfWork.Save();
            TempData["Success"] = "Cover Type deleted successfully";
            return RedirectToAction(nameof(Index));
        }
    }
}
