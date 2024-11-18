using System.Security.Claims;

namespace ASMCshrp4_12345.MiddleWare
{
    public class CustomAuthenticationMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly List<string> listPaths = new List<string>
        {
            "/Khachhangs",
            "/Sanphams",
            "/Hoadons",
            "/NhaCungCap",
            "/Nhanviens",
            "/ThongKe",
            "/ThuongHieu",
            "/PhanHoiBinhLuan"
        };
        private readonly List<string> listPathsforUsers = new List<string>
        {
            "/CuaHang",
            "/Cart",
            "/Home",
        };

        public CustomAuthenticationMiddleware(RequestDelegate _next)
        {
            this._next = _next;
        }
        public async Task InvokeAsync(HttpContext context)
        {
            var path = context.Request.Path.Value.ToLower();
            var roleClaim = context.User.Claims?.FirstOrDefault(p => p.Type == ClaimTypes.Role)?.Value;
            bool islistPaths = false;
            bool islistPathsForUsers = false;
            foreach (var listPath in listPaths)
            {
                if (path.Contains(listPath.ToLower()))
                {
                    islistPaths = true;
                    break;
                }
            }
            foreach (var listPath in listPathsforUsers)
            {
                if (path.Contains(listPath.ToLower()))
                {
                    islistPathsForUsers = true;
                    break;
                }
            }
            if (islistPaths && roleClaim != "Admin" && roleClaim != "Nhân viên")
            {
                context.Response.Redirect("/Home/Error404");
                return;
            }

            if (islistPathsForUsers && roleClaim == "Admin")
            {
                context.Response.Redirect("/ThongKe/Index");
                return;
            }

            if (islistPathsForUsers && roleClaim == "Nhân viên")
            {
                context.Response.Redirect("/Hoadons/Index");
                return;
            }
            await _next(context);
        }
    }
}
