using System;
using System.Data.Entity.Core;
using System.Data.SqlClient;
using System.Linq;
using System.Web.UI;
using ThuVienOnline.model;

namespace ThuVienOnline
{
    public partial class Login : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack && Session["MaNguoiDung"] != null)
            {
                Response.Redirect("~/GiaoDien/Default.aspx", false);
                Context.ApplicationInstance.CompleteRequest();
            }
        }

        protected void LoginButton_Click(object sender, EventArgs e)
        {
            if (!Page.IsValid)
            {
                return;
            }

            string username = UsernameTextBox.Text.Trim();
            string password = PasswordTextBox.Text;
            if (string.IsNullOrWhiteSpace(username) || username.Length > 50 || password.Length > 128)
            {
                ShowError("Tên đăng nhập hoặc mật khẩu không chính xác.");
                return;
            }

            try
            {
                using (var db = new thuvien())
                {
                    NguoiDung user = db.NguoiDung.SingleOrDefault(u => u.TenDangNhap == username);
                    if (user == null || !AuthHelper.VerifyPassword(password, user.MatKhau))
                    {
                        ShowError("Tên đăng nhập hoặc mật khẩu không chính xác.");
                        return;
                    }

                    if (!string.Equals(user.TrangThai, "HoatDong", StringComparison.OrdinalIgnoreCase))
                    {
                        ShowError("Tài khoản hiện không hoạt động. Vui lòng liên hệ quản trị viên.");
                        return;
                    }

                    Session["MaNguoiDung"] = user.MaNguoiDung;
                    Session["HoTen"] = user.HoTen;
                }

                Response.Redirect("~/GiaoDien/Default.aspx", false);
                Context.ApplicationInstance.CompleteRequest();
            }
            catch (EntityException)
            {
                ShowError("Không thể kết nối cơ sở dữ liệu. Vui lòng kiểm tra cấu hình SQL Server LocalDB.");
            }
            catch (SqlException)
            {
                ShowError("Không thể kết nối cơ sở dữ liệu. Vui lòng kiểm tra cấu hình SQL Server LocalDB.");
            }
        }

        private void ShowError(string message)
        {
            MessageLabel.Text = Server.HtmlEncode(message);
            MessageLabel.CssClass = "field-error";
        }
    }
}
