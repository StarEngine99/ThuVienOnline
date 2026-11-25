<%@ Page Title="Trang chủ" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="ThuVienOnline._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <main class="home-page">
        <section class="home-hero">
            <div class="hero-copy">
                <span class="eyebrow">THƯ VIỆN TRỰC TUYẾN</span>
                <h1>Mở một cuốn sách,<br />mở ra một thế giới.</h1>
                <p>Tìm kiếm, khám phá và mượn những cuốn sách bạn yêu thích ngay tại thư viện của chúng tôi.</p>
                <a class="btn btn-primary btn-lg" href="Register.aspx">Bắt đầu khám phá</a>
            </div>
            <div class="hero-art" aria-hidden="true">
                <div class="book book-one"></div>
                <div class="book book-two"></div>
                <div class="book book-three"></div>
                <div class="book-spark">✦</div>
            </div>
        </section>

        <section class="home-intro">
            <span class="eyebrow">BẠN SẼ TÌM THẤY</span>
            <h2>Không gian dành cho người yêu sách</h2>
            <div class="row feature-row">
                <div class="col-md-4">
                    <article class="feature-card">
                        <span class="feature-icon">01</span>
                        <h3>Khám phá sách</h3>
                        <p>Tìm những tựa sách phù hợp với sở thích và nhu cầu học tập của bạn.</p>
                    </article>
                </div>
                <div class="col-md-4">
                    <article class="feature-card">
                        <span class="feature-icon">02</span>
                        <h3>Quản lý dễ dàng</h3>
                        <p>Đăng nhập để theo dõi tài khoản và những cuốn sách bạn đang mượn.</p>
                    </article>
                </div>
                <div class="col-md-4">
                    <article class="feature-card">
                        <span class="feature-icon">03</span>
                        <h3>Đọc mỗi ngày</h3>
                        <p>Bắt đầu hành trình đọc sách của bạn từ những trang sách đầu tiên.</p>
                    </article>
                </div>
            </div>
        </section>
    </main>
</asp:Content>
