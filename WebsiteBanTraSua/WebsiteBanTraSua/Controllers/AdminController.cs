using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebsiteBanTraSua.Models;

namespace WebsiteBanTraSua.Controllers
{
    public class AdminController : Controller
    {
        DataClasses1DataContext data = new DataClasses1DataContext();

        // Hiển thị danh sách sản phẩm nổi bật ------------------------------------------------------------
        public ActionResult Home()
        {
            List<PRODUCT> dsSach = data.PRODUCTs.Take(12).ToList();
            return View(dsSach);
        }

        // Liên hệ ----------------------------------------------------------------------------------------
        public ActionResult Contact()
        {
            return View();
        }

        // Xử lý đăng ký
        [HttpPost]
        public ActionResult XLLienHe(CONTACT ct)
        {
            data.CONTACTs.InsertOnSubmit(ct);
            data.SubmitChanges();
            return RedirectToAction("Contact", "Admin");
        }

        // Hiển thị loại sản phẩm -------------------------------------------------------------------------
        public ActionResult HTLoai()
        {
            List<CATEGORY> dsLoai = data.CATEGORies.ToList(); // Truyền sang view
            return PartialView(dsLoai);
        }

        // Hiển thị sản phẩm theo loại --------------------------------------------------------------------
        public ActionResult HTSPTheoLoai(string maL)
        {
            List<PRODUCT> dsSP = data.PRODUCTs.Where(t => t.maLoai == maL).ToList();

            // Trả về cùng 1 view với view Home
            return View("Products", dsSP);
        }

        // Hiển thị danh sách tất cả sản phẩm -------------------------------------------------------------
        public ActionResult Products()
        {
            List<PRODUCT> dsSach = data.PRODUCTs.ToList();
            return View(dsSach);
        }

        // Trả về chi tiết 1 sản phẩm theo mã loại --------------------------------------------------------
        public ActionResult ChiTietSP(string id)
        {
            // Trả về 1 sản phẩm
            PRODUCT sp = data.PRODUCTs.FirstOrDefault(t => t.maSP == id);

            // Lấy ds sản phẩm cùng mã loại với cuốn sách có mã id
            List<PRODUCT> dsSachCCD = data.PRODUCTs.Where(i => i.maLoai == sp.maLoai).ToList();

            // Truyền qua view bag
            ViewBag.dsSCCD = dsSachCCD;

            return View(sp);
        }

        // Tìm kiếm ---------------------------------------------------------------------------------------
        public ActionResult TimKiem()
        {
            ViewBag.maLoai = new SelectList(data.CATEGORies.ToList(), "maLoai", "tenLoai");
            return View();
        }

        // Xử lý tìm kiếm
        [HttpPost]
        public ActionResult XuLyTimKiem(FormCollection fct)
        {
            string tuKhoa = fct["txtTuKhoa"].ToString();
            string maLoai = fct["maLoai"].ToString();

            List<PRODUCT> dsS = data.PRODUCTs.Where(t => t.tenSP.Contains(tuKhoa) == true 
                && t.maLoai == maLoai).ToList();

            return View("Products", dsS);
        }

        // View error 404 ---------------------------------------------------------------------------------
        public ActionResult Error()
        {
            return View();
        }

        // Đăng nhập --------------------------------------------------------------------------------------
        [HttpGet]
        public ActionResult DangNhap()
        {
            return View();
        }

        // Xử lý đăng nhập 
        [HttpPost]
        public ActionResult XuLyDangNhap(FormCollection col)
        {
            string ten = col["txtTenDN"];
            string mk = col["txtPassword"];

            CUSTOMER kh = data.CUSTOMERs.SingleOrDefault(k => k.userName == ten && k.pass == mk);
            if (kh == null) // Đăng nhập không thành công, hiển thị thông báo
                return RedirectToAction("Error", "Admin");

            if (ten == "Admin" || ten == "admin") // Tài khoản quản trị chuyển hướng sang trang quản lý
                return RedirectToAction("TrangChu", "Bill");

            Session["KhachHang"] = kh; // Kiểu đối tượng khách hàng
            return RedirectToAction("Home", "Admin");
        }

        // Đăng xuất --------------------------------------------------------------------------------------
        public ActionResult DangXuat()
        {
            Session["KhachHang"] = null;
            return RedirectToAction("Home", "Admin");
        }

        // Đăng ký ----------------------------------------------------------------------------------------
        [HttpGet]
        public ActionResult DangKy()
        {
            return View();
        }

        // Xử lý đăng ký
        [HttpPost]
        public ActionResult XLDangKy(CUSTOMER kh)
        {
            data.CUSTOMERs.InsertOnSubmit(kh);
            data.SubmitChanges();
            return RedirectToAction("DangNhap", "Admin");
        }

        // Button chọn mua --------------------------------------------------------------------------------
        public ActionResult ChonMua(string id)
        {
            GioHang gh = Session["gio"] as GioHang;
            if (gh == null)
                gh = new GioHang();

            // Thêm mặt hàng vào giỏ
            gh.Them(id);

            Session["gio"] = gh;

            return RedirectToAction("Home", "Admin");
        }

        // Hiển thị giỏ hàng ------------------------------------------------------------------------------
        public ActionResult HTGioHang()
        {
            GioHang gh = Session["gio"] as GioHang;

            return View(gh);
        }

        // View xác nhận thông tin ------------------------------------------------------------------------
        public ActionResult XacNhanThongTin()
        {
            CUSTOMER khach = Session["KhachHang"] as CUSTOMER;

            if (khach == null) // Chưa đăng nhập
                return RedirectToAction("DangNhap", "Admin");

            // Đã tồn tại khách hàng (Đăng nhập thành công)
            return View(khach);
        }

        // Lưu thông tin đặt hàng -------------------------------------------------------------------------
        [HttpPost]
        public ActionResult LuuDatHang(FormCollection col)
        {
            try
            {
                GioHang gh = (GioHang)Session["gio"];
                CUSTOMER kh = (CUSTOMER)Session["KhachHang"];
                if (Session["KhachHang"] == null)
                    return RedirectToAction("DangNhap", "Admin");
                if (Session["gio"] == null || gh.lst.Count == 0) // Giỏ hàng rỗng
                    return RedirectToAction("HTGioHang", "Admin");

                // Lấy thông tin ngày giao
                string ngayGiao = col["txtNgay"];
                DateTime ngayGiao_dateTime = Convert.ToDateTime(ngayGiao);

                // Lưu vào bảng đặt hàng
                BILL hd = new BILL();
                hd.userName = kh.userName;
                hd.ngayMua = DateTime.Now;
                hd.ngayHenGiao = ngayGiao_dateTime;
                data.BILLs.InsertOnSubmit(hd);
                data.SubmitChanges();

                // Lưu thông tin vào bản chi tiết đặt hàng
                foreach (CartItem sp in gh.lst)
                {
                    BILLDETAIL cthd = new BILLDETAIL();
                    cthd.maHD = hd.maHD;
                    cthd.maSP = sp.iMaSP;
                    cthd.soLuong = sp.iSoLuong;
                    data.BILLDETAILs.InsertOnSubmit(cthd);
                }
                data.SubmitChanges();
                gh.XoaGioHang();
                ViewBag.tb = "Đặt hàng thành công!";
            }
            catch
            {
                ViewBag.tb = "Bạn chưa lưu được đơn hàng!";
            }
            return View();
        }

        // Lấy giỏ hàng 
        public List<CartItem> layGioHang()
        {
            List<CartItem> lstGH = Session["gio"] as List<CartItem>;
            if (lstGH == null)
            {
                // Nếu lstGH chưa tồn tại thì khởi tạo
                lstGH = new List<CartItem>();
                Session["gio"] = lstGH;
            }
            return lstGH;
        }

        // Xóa giỏ hàng -----------------------------------------------------------------------------------
        public ActionResult XoaGioHang(string maSP)
        {
            // Lấy giỏ hàng
            List<CartItem> lstGH = layGioHang();
            // Kiểm tra xem sách cần xóa có trong giỏ hàng không?
            CartItem sp = lstGH.Single(s => s.iMaSP == maSP);

            // Nếu có thì tiến hành xóa
            if (sp != null)
            {
                lstGH.RemoveAll(s => s.iMaSP == maSP);
                return RedirectToAction("gio", "gio");
            }
            // Nếu giỏ hàng rỗng
            if (lstGH.Count == 0)
                return RedirectToAction("Home", "Admin");
            return RedirectToAction("gio", "gio");
        }
    }
}