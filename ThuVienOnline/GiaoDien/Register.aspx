<%@ Page Title="Đăng ký" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Register.aspx.cs" Inherits="ThuVienOnline.Register" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <main class="auth-page">
        <section class="auth-card">
            <span class="eyebrow">THAM GIA THƯ VIỆN</span>
            <h1>Tạo tài khoản</h1>
            <p class="auth-description">Đăng ký để bắt đầu khám phá thế giới sách.</p>

            <asp:ValidationSummary ID="RegisterValidationSummary" runat="server" ValidationGroup="Register"
                CssClass="validation-summary" />
            <asp:Label ID="MessageLabel" runat="server" EnableViewState="false" />

            <div class="mb-3">
                <asp:Label ID="FullNameLabel" runat="server" AssociatedControlID="FullNameTextBox"
                    CssClass="form-label" Text="Họ và tên" />
                <asp:TextBox ID="FullNameTextBox" runat="server" CssClass="form-control"
                    MaxLength="100" autocomplete="name" />
                <asp:RequiredFieldValidator ID="FullNameRequired" runat="server"
                    ControlToValidate="FullNameTextBox" ErrorMessage="Vui lòng nhập họ và tên."
                    CssClass="field-error" Display="Dynamic" ValidationGroup="Register" />
            </div>
            <div class="mb-3">
                <asp:Label ID="UsernameLabel" runat="server" AssociatedControlID="UsernameTextBox"
                    CssClass="form-label" Text="Tên đăng nhập" />
                <asp:TextBox ID="UsernameTextBox" runat="server" CssClass="form-control"
                    MaxLength="50" autocomplete="username" />
                <asp:RequiredFieldValidator ID="UsernameRequired" runat="server"
                    ControlToValidate="UsernameTextBox" ErrorMessage="Vui lòng nhập tên đăng nhập."
                    CssClass="field-error" Display="Dynamic" ValidationGroup="Register" />
            </div>
            <div class="mb-3">
                <asp:Label ID="EmailLabel" runat="server" AssociatedControlID="EmailTextBox"
                    CssClass="form-label" Text="Email (không bắt buộc)" />
                <asp:TextBox ID="EmailTextBox" runat="server" CssClass="form-control"
                    TextMode="Email" MaxLength="100" autocomplete="email" />
                <asp:RegularExpressionValidator ID="EmailValidator" runat="server"
                    ControlToValidate="EmailTextBox" ValidationExpression="^[^@\s]+@[^@\s]+\.[^@\s]+$"
                    ErrorMessage="Địa chỉ email không hợp lệ." CssClass="field-error"
                    Display="Dynamic" ValidationGroup="Register" />
            </div>
            <div class="mb-3">
                <asp:Label ID="PasswordLabel" runat="server" AssociatedControlID="PasswordTextBox"
                    CssClass="form-label" Text="Mật khẩu" />
                <asp:TextBox ID="PasswordTextBox" runat="server" CssClass="form-control"
                    TextMode="Password" MaxLength="128" autocomplete="new-password" />
                <small class="form-text text-muted">Mật khẩu cần có ít nhất 8 ký tự.</small>
                <asp:RequiredFieldValidator ID="PasswordRequired" runat="server"
                    ControlToValidate="PasswordTextBox" ErrorMessage="Vui lòng nhập mật khẩu."
                    CssClass="field-error" Display="Dynamic" ValidationGroup="Register" />
            </div>
            <div class="mb-3">
                <asp:Label ID="ConfirmPasswordLabel" runat="server" AssociatedControlID="ConfirmPasswordTextBox"
                    CssClass="form-label" Text="Nhập lại mật khẩu" />
                <asp:TextBox ID="ConfirmPasswordTextBox" runat="server" CssClass="form-control"
                    TextMode="Password" MaxLength="128" autocomplete="new-password" />
                <asp:CompareValidator ID="PasswordCompare" runat="server"
                    ControlToValidate="ConfirmPasswordTextBox" ControlToCompare="PasswordTextBox"
                    ErrorMessage="Mật khẩu nhập lại chưa khớp." CssClass="field-error"
                    Display="Dynamic" ValidationGroup="Register" />
            </div>
            <asp:Button ID="RegisterButton" runat="server" Text="Tạo tài khoản"
                CssClass="btn btn-primary auth-submit" ValidationGroup="Register" OnClick="RegisterButton_Click" />
            <p class="auth-switch">Đã có tài khoản? <a href="Login.aspx">Đăng nhập</a></p>
        </section>
    </main>
</asp:Content>
