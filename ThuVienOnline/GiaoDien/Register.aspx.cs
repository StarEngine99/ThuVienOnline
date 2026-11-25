using System;
using System.Data.Entity.Core;
using System.Data.Entity.Infrastructure;
using System.Data.SqlClient;
using System.Linq;
using System.Net.Mail;
using System.Web.UI;
using ThuVienOnline.model;

namespace ThuVienOnline
{
    public partial class Register : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack && Session["MaNguoiDung"] != null)
            {
                Response.Redirect("~/GiaoDien/Default.aspx", false);
                Context.ApplicationInstance.CompleteRequest();
            }
        }

        protected void RegisterButton_Click(object sender, EventArgs e)
        {
            if (!Page.IsValid)
            {
                return;
            }

            string fullName = FullNameTextBox.Text.Trim();
            string username = UsernameTextBox.Text.Trim();
            string email = EmailTextBox.Text.Trim();
            string password = PasswordTextBox.Text;

            if (string.IsNullOrWhiteSpace(fullName) || fullName.Length > 100
                || string.IsNullOrWhiteSpace(username) || username.Length > 50
                || email.Length > 100 || password.Length < 8 || password.Length > 128
                || password != ConfirmPasswordTextBox.Text)
            {
                ShowError("Kiểm tra lại thông tin đã nhập. Mật khẩu phải có từ 8 đến 128 ký tự.");
                return;
            }

            if (email.Length > 0)
            {
                try
                {
                    if (new MailAddress(email).Address != email)
                    {
                        ShowError("Địa chỉ email không hợp lệ.");
                        return;
                    }
                }
                catch (FormatException)
                {
                    ShowError("Địa chỉ email không hợp lệ.");
                    return;
                }
            }

            try
            {
                using (var db = new thuvien())
                {
                    if (db.NguoiDung.Any(u => u.TenDangNhap == username))
                    {
                        ShowError("Tên đăng nhập đã được sử dụng.");
                        return;
                    }

                    var user = new NguoiDung
                    {
                        HoTen = fullName,
                        TenDangNhap = username,
                        MatKhau = AuthHelper.HashPassword(password),
                        Email = string.IsNullOrWhiteSpace(email) ? null : email,
                        VaiTro = "DocGia",
                        TrangThai = "HoatDong",
                        NgayTao = DateTime.Now
                    };

                    db.NguoiDung.Add(user);
                    db.SaveChanges();

                    Session["MaNguoiDung"] = user.MaNguoiDung;
                    Session["HoTen"] = user.HoTen;
                }

                Response.Redirect("~/GiaoDien/Default.aspx", false);
                Context.ApplicationInstance.CompleteRequest();
            }
            catch (DbUpdateException)
            {
                ShowError("Không thể tạo tài khoản. Tên đăng nhập có thể đã được sử dụng.");
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
