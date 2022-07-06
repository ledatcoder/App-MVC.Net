using App.Services;
using Microsoft.AspNetCore.Mvc;

namespace App.Controllers
{
    public class FirstController : Controller
    {
        private readonly ILogger<FirstController> _logger;
        private readonly ProductService _productService;

        public FirstController(ILogger<FirstController> logger,ProductService productService)// xây dựng phương thức khởi tạo và inject dịch vụ logger cho FirstController
        {
            _logger = logger; // sau khi inject sẻ lưu trữ đối tượng logger vào biến _logger
            _productService = productService; // sau khi inject sẻ lưu trữ đối tượng productService vào biến _productService
        }

        public string Index()
        {
            // có thể lấy được
            // this.HttpContext
            // this.Request
            // this.Response
            // this.User
            // this.RouteData
            // this.ModelState
            // this.TempData
            // this.ViewBag
            // this.ViewData
            // this.ViewEngine
            // this.ViewEngines

            //LogLevel có 6 loại: Trace, Debug, Information, Warning, Error, Critical
            _logger.LogTrace("Trace message");
            _logger.LogDebug("Debug message");
            _logger.LogInformation("Information message");
            _logger.LogWarning("Warning message");
            _logger.LogError("Error message");
            _logger.LogCritical("Critical message");

            _logger.LogInformation("Log from FirstController"); // hiện thị log trong console
            return "Hello from FirstController";
        }

        // Action trong Controller nó có thể trả về bất kỳ kiễu dữ liệu gì nổi dung trả về sẻ được convert thành string

        public void Nothing()
        {
           _logger.LogInformation("Nothing Action"); 
           Response.Headers.Add("Hello", "World"); // thêm header vào Response
        }
                        //      Kiểu trả về                 | Phương thức
                        // ------------------------------------------------
                        // ContentResult               | Content()
                        // EmptyResult                 | new EmptyResult()
                        // FileResult                  | File()
                        // ForbidResult                | Forbid()
                        // JsonResult                  | Json()
                        // LocalRedirectResult         | LocalRedirect()
                        // RedirectResult              | Redirect()
                        // RedirectToActionResult      | RedirectToAction()
                        // RedirectToPageResult        | RedirectToRoute()
                        // RedirectToRouteResult       | RedirectToPage()
                        // PartialViewResult           | PartialView()
                        // ViewComponentResult         | ViewComponent()
                        // StatusCodeResult            | StatusCode()
                        // ViewResult                  | View()

        public IActionResult Readme()
        {
            var content = @"
            # Hello from FirstController
            - Hi from FirstController
            - Hi from FirstController";
            return Content(content,"text/plain"); // trả về nội dung content với kiểu trả về ContentResult
        }  

        // public IActionResult Iphone()
        // {
        //     string filePath = Path.Combine(Startup.ContentRootPath, "Images", "iphone.jpg");
        //     var bytes = System.IO.File.ReadAllBytes(filePath);
        //     return File(bytes, "image/jpg"); // trả về file với kiểu trả về FileResult
        // }   

        public IActionResult IphonePrice()
        {
            return Json(new { price = 1000000 }); // trả về nội dung json với kiểu trả về JsonResult
        }  
        
        public IActionResult Privacy()
        {
            var url = Url.Action("Privacy", "Home"); // trả về url với kiểu trả về LocalRedirectResult
            _logger.LogInformation(url); // hiện thị log trong console
            return LocalRedirect(url); // trả về url với kiểu trả về LocalRedirectResult
        }    


        // Importance 
        // ViewResult: trả về nội dung view với kiểu trả về ViewResult   

        public IActionResult HelloView()
        {
            // View() -> phương thức này yêu cầu sữ dụng Razor engine đọc và thi hành file .cshtml được gọi là template kết quả mỡ thi hành được lưu ở ViewResult

            if(string.IsNullOrEmpty(ViewBag.Name))
            {
                ViewBag.Name = "World";
            }

            // View(template) - template phải là đưởng dẫn tuyệt đối đến file .cshtml

            // trường hợp 2
            // View(template, model) - template phải là đưởng dẫn tuyệt đối đến file .cshtml, model là model của view
            return View("/MyView/xinchao1.cshtml"); // trả về nội dung view với kiểu trả về ViewResult

            //HelloView.cshtml -> /View/First/HelloView.cshtml
            // /View/Controller/Action.cshtml -> /View/Controller/Action.cshtml
            // return View();
        }   
        [TempData]
        public string message { get; set; }
        public IActionResult ViewProduct(int? id)
        {
            var product = _productService.Where(p => p.Id == id).FirstOrDefault();
            if (product== null)
            {
               // TempData["message"] = "Product not found"; // sữ dụng TempData để lưu dữ liệu trong 1 request

               message = "Product not found"; // sữ dụng TempData để lưu dữ liệu trong 1 request
                return Redirect(Url.Action("Index", "Home"));
            }
           
            // tiềm file theo đường dẫn template /View/First/ViewProduct.cshtml sau đó mở file truyền model là product vào
            // "/MyView/First/ViewProduct.cshtml"
           //return View(product); // trả về nội dung view với kiểu trả về ViewResult

           // truyền dữ liệu bằng ViewData
            //   this.ViewData["product"] = product;

            //   ViewData["title"] = product.Name;

            //   return View("ViewProduct2"); // trả về nội dung view với kiểu trả về ViewResult


            // truyen du lieu bang ViewBag
             this.ViewBag.product = product;
             return View("ViewProduct3"); // trả về nội dung view với kiểu trả về ViewResult
        } 
    }
}