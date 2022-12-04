using BulkyBook.DataAccess.Repository.IRepository;
using BulkyBook.Models;
using BulkyBook.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace BulkyBookWeb.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ProductController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        //To access wwwroot, we need that web hosting environment, so we would have to get
        //that using dependency injection
        private readonly IWebHostEnvironment _hostEnvironment;
        public ProductController(IUnitOfWork unitOfWork, IWebHostEnvironment hostEnvironment)
        {
            _unitOfWork = unitOfWork;
            _hostEnvironment = hostEnvironment;
        }

        public IActionResult Index()
        {

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
            }
            else{
                //update product               
            }

            return View(productVM);
        }
        //POST
        [HttpPost]
        [ValidateAntiForgeryToken]
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
        #region API CALLS
        //He we will be calling our API calls first
        [HttpGet]
        public IActionResult GetAll()
        {
            var productList = _unitOfWork.Product.GetAll(includeProperties:"Category,CoverType");

            return Json(new { data = productList });
        }
        #endregion
    }
}
