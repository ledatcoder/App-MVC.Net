## Controller
 + là một lớp kế thừa từ lớp Controller: Microsoft.AspNetCore.Mvc.Controller
 + Action trong controller là một phương thức public (Không được static)
 + Action trả về bất kỳ dữ liệu nào , thường là IActionResult
 + các dịch vụ inject vào controller qua hàm tạo

 ## View
  + là file .cshtml
  + View cho Action lưu tại: /View/ControllerName/ActionName.cshtml
  + thêm thư muc lưu trữ:
  {0} -> tên action
  {1} -> tên controller
  {2} -> tên area
  options.ViewLocationFormats.Add("/MyView/{1}/{0}"+RazorViewEngine.ViewExtension);

  ## Truyền dữ liệu sang View
  -Model
  -ViewData
  -TeampData
  -ViewBag

  ## Areas
   + là tên dùng để routing
   +là cấu trúc thư mục chứa MVC
   + thiết lập Area cho controller bằng [Area("AreaName")]
   +dotnet aspnet-codegenerator area Product
## Route
 +enpoints.MapControllerRoute
 +enpoints.MapAreaControllerRoute
 +[AcceptVerbs("POST","GET")]
 +[Route("partern")]
 +[HttpGet] [HttpPost]
## Url Generation
## UrlHelper : Action, ActionLink, RouteUrl, Link
 +Url.Action("PlanetInfo", "Planet", 
            new {id = 1}, Context.Request.Scheme);

 +Url.RouteUrl("default", new {controller= "First", 
                             action="HelloView", 
                            id = 1, 
                            username =  "XuanThuLab"});
## HtmlTagHelper: <a> <button> <form>
Sử dụng thuộc tính:

 +asp-area="Area"
 +asp-action="Action"
 +asp-controller="Product"
 +asp-route...="123"
 +asp-route="default"