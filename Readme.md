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