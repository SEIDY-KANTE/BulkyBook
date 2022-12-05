using BulkyBook.DataAccess.Repository.IRepository;
using BulkyBook.Models;
<<<<<<< HEAD
using BulkyBook.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
=======
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
>>>>>>> 3de820c21389c1c2b5f339a188b16277d9983ee0

namespace BulkyBookWeb.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ProductController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
<<<<<<< HEAD
        //To access wwwroot, we need that web hosting environment, so we would have to get
        //that using dependency injection
        private readonly IWebHostEnvironment _hostEnvironment;
        public ProductController(IUnitOfWork unitOfWork, IWebHostEnvironment hostEnvironment)
        {
            _unitOfWork = unitOfWork;
            _hostEnvironment = hostEnvironment;
=======
        public ProductController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
>>>>>>> 3de820c21389c1c2b5f339a188b16277d9983ee0
        }

        public IActionResult Index()
        {
<<<<<<< HEAD

            return View();
        }

        //GET
        public IActionResult Upsert(int? id)
        {
            ProductVM productVM = new()
            {
                Product = new(),
                CategoryList = _unitOfWork.Category.GetAll().Select(
                     x => new SelectListItem
                     {
                         Text = x.Name,
                         Value = x.Id.ToString()
                     }
                  ),
                CoverTypeList = _unitOfWork.CoverType.GetAll().Select(
                     x => new SelectListItem
                     {
                         Text = x.Name,
                         Value = x.Id.ToString()
                     }
                  ),
            };
              
            if (id == null || id==0)
            {
                //create product
                //ViewBag.CategoryList=CategoryList;
                //ViewBag.CoverTypeList=CoverTypeList;
                //ViewData["CoverTypeList"] = CoverTypeList;
                
                return View(productVM);
=======
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
>>>>>>> 3de820c21389c1c2b5f339a188b16277d9983ee0
            }
            else{
                //update product
            }
<<<<<<< HEAD

            return View(productVM);
=======
           
            return View();
>>>>>>> 3de820c21389c1c2b5f339a188b16277d9983ee0
        }
        //POST
        [HttpPost]
        [ValidateAntiForgeryToken]
<<<<<<< HEAD
        public IActionResult Upsert(ProductVM obj, IFormFile? file)
        {
           
            if (ModelState.IsValid)
            {
                string wwwRootPath = _hostEnvironment.WebRootPath;
                if (file != null)
                {
                    //Generate a new file name
                    string fileName = Guid.NewGuid().ToString();
                    var uploads = Path.Combine(wwwRootPath, @"images\products");
                    var extension = Path.GetExtension(file.FileName); //Rename the file,but I want to keep the same extension

                    //And finally, I need to copy the file that was uploaded inside the product folder
                    using (var fileStreams = new FileStream(Path.Combine(uploads, fileName + extension), FileMode.Create))
                    {
                        //I want to copy that file to the location that we have inside the fileStreams
                        file.CopyTo(fileStreams);
                    }
                    obj.Product.ImageUrl = @"\images\products\" + fileName + extension;
                }

                _unitOfWork.Product.Add(obj.Product);
                _unitOfWork.Save();
                TempData["Success"] = "Product "+(obj.Product.Id!=0 ? "updated" : "created")+ " successfully";
                return RedirectToAction(nameof(Index));
            }
            return View(obj.Product);
=======
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
>>>>>>> 3de820c21389c1c2b5f339a188b16277d9983ee0
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
<<<<<<< HEAD
        #region API CALLS
        //He we will be calling our API calls first
        [HttpGet]
        public IActionResult GetAll()
        {
            var productList = _unitOfWork.Product.GetAll(includeProperties:"Category,CoverType");

            return Json(new { data = productList });
        }
        #endregion
=======
>>>>>>> 3de820c21389c1c2b5f339a188b16277d9983ee0
    }
}
