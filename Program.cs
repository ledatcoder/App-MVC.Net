


using App.ExtendMethods;
using App.Services;
using Microsoft.AspNetCore.Mvc.Razor;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddRazorPages(); // đăng ký các dịch vụ của trang Razor

builder.Services.AddSingleton(typeof(PlanetService)); // đăng ký dịch vụ của trang Razor

builder.Services.Configure<RazorViewEngineOptions>(options =>
{

    //{0} -> tên Action
    //{1} -> tên Controller
    //{2} -> tên file view
    options.ViewLocationFormats.Add("/MyView/{1}/{0}.cshtml"); //lưu trử các view theo thư mục riêng của controller
});

builder.Services.AddSingleton<ProductService>(); // đăng ký dịch vụ ProductService
// builder.Services.AddSingleton<ProductService, ProductService>(); // đăng ký dịch vụ ProductService
// builder.Services.AddSingleton<typeof (ProductService)>(); // đăng ký dịch vụ ProductService
// builder.Services.AddSingleton<typeof(ProductService0,typeof(ProductService)>(); // đăng ký dịch vụ ProductService
var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.AddStatusCodePage(); // hiện thị lỗi từ 400 - 599

app.UseRouting();


app.UseAuthorization();

app.UseAuthentication(); // xác định danh tính

app.UseAuthorization(); // xác thực quyền truy cập



app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

// đăng ký các dịch vụ của trang Razor
app.UseEndpoints(endpoints =>
{

    // đoạn code này tạo ra các điểm enpoint bằng việt tạo ra 1 root đặt tên là default
    // nó phân tích địa chỉ truy cập URL: {controller=Home}/{action=Index}/{id?} 
    // thì nó sẻ khởi tạo ra controller theo tên sau đó truyễn request cho controller thi hành phương thức action
    //vd: khi truy địa chỉ là ABC/Xyz
    // =>tìm và tạo ra controller ABC và gọi phương thức Xyz
    // nếu không thiết lập thì sẻ khởi tạo ra controller Home và gọi phương thức Index
    // endpoints.MapControllerRoute(
    //     name: "default",
    //     pattern: "{controller=Home}/{action=Index}/{id?}");
    // endpoints.MapRazorPages(); // kích hoạt các điểm enpoint cho Razor Pages => vừa có thể truy cập đến các trang Razor Pages và các controller


    // /sayhi
    endpoints.MapGet("/sayhi", async (context) =>
    {
        await context.Response.WriteAsync($"Hello ASP.NET MVC {DateTime.Now}");
    });

    // endpoints.MapControllers
    // endpoints.MapControllerRoute
    // endpoints.MapDefaultControllerRoute
    // endpoints.MapAreaControllerRoute

    // [AcceptVerbs]

    // [Route]

    // [HttpGet]
    // [HttpPost]
    // [HttpPut]
    // [HttpDelete]
    // [HttpHead]
    // [HttpPatch]

    // Area

    endpoints.MapControllers();

    endpoints.MapControllerRoute(
        name: "first",
        pattern: "{url:regex(^((xemsanpham)|(viewproduct))$)}/{id:range(2,4)}",
        defaults: new
        {
            controller = "First",
            action = "ViewProduct"
        }

    );

    endpoints.MapAreaControllerRoute(
        name: "product",
        pattern: "/{controller}/{action=Index}/{id?}",
        areaName: "ProductManage"
    );

    // Controller khong co Area
    endpoints.MapControllerRoute(
        name: "default",
        pattern: "/{controller=Home}/{action=Index}/{id?}"
    );

    endpoints.MapRazorPages();

 });


app.Run();
