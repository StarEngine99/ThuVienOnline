<%@ Page Title="Đăng nhập" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="ThuVienOnline.Login" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <main class="auth-page">
        <section class="auth-card">
            <span class="eyebrow">CHÀO MỪNG TRỞ LẠI</span>
            <h1>Đăng nhập</h1>
            <p class="auth-description">Đăng nhập để tiếp tục hành trình đọc sách của bạn.</p>

            <asp:ValidationSummary ID="LoginValidationSummary" runat="server" ValidationGroup="Login"
                CssClass="validation-summary" />
            <asp:Label ID="MessageLabel" runat="server" EnableViewState="false" />

            <div class="mb-3">
                <asp:Label ID="UsernameLabel" runat="server" AssociatedControlID="UsernameTextBox"
                    CssClass="form-label" Text="Tên đăng nhập" />
                <asp:TextBox ID="UsernameTextBox" runat="server" CssClass="form-control"
                    MaxLength="50" autocomplete="username" />
                <asp:RequiredFieldValidator ID="UsernameRequired" runat="server"
                    ControlToValidate="UsernameTextBox" ErrorMessage="Vui lòng nhập tên đăng nhập."
                    CssClass="field-error" Display="Dynamic" ValidationGroup="Login" />
            </div>
            <div class="mb-3">
                <asp:Label ID="PasswordLabel" runat="server" AssociatedControlID="PasswordTextBox"
                    CssClass="form-label" Text="Mật khẩu" />
                <asp:TextBox ID="PasswordTextBox" runat="server" CssClass="form-control"
                    TextMode="Password" MaxLength="128" autocomplete="current-password" />
                <asp:RequiredFieldValidator ID="PasswordRequired" runat="server"
                    ControlToValidate="PasswordTextBox" ErrorMessage="Vui lòng nhập mật khẩu."
                    CssClass="field-error" Display="Dynamic" ValidationGroup="Login" />
            </div>
            <asp:Button ID="LoginButton" runat="server" Text="Đăng nhập"
                CssClass="btn btn-primary auth-submit" ValidationGroup="Login" OnClick="LoginButton_Click" />
            <p class="auth-switch">Chưa có tài khoản? <a href="Register.aspx">Đăng ký ngay</a></p>
        </section>
    </main>
</asp:Content>
