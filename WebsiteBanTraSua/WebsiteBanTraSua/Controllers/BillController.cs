using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebsiteBanTraSua.Models;

namespace WebsiteBanTraSua.Controllers
{
    public class BillController : Controller
    {
        DataClasses1DataContext data = new DataClasses1DataContext();

        // Hiển thị hóa đơn -------------------------------------------------------------------------------
        public ActionResult Home()
        {
            List<BILL> dshd = data.BILLs.ToList();
            return View(dshd);
        }

        // Đếm sl, cthd, tổng thành tiền khi có mã hóa đơn, chọn partialView ------------------------------
        public ActionResult ThongKe(int mhd)
        {
            List<BILLDETAIL> dsct = data.BILLDETAILs.Where(c => c.maHD == mhd).ToList();

            // Thống kê thành tiền
            var thanhTien = dsct.Sum(ct => ct.soLuong * ct.PRODUCT.gia);
            ViewBag.tt = thanhTien;

            return View(dsct);
        }

        // Liệt kê các hóa đơn trong dropdown list --------------------------------------------------------
        public ActionResult LietKeHD(int mhd)
        {
            List<BILLDETAIL> dsct = data.BILLDETAILs.Where(c => c.maHD == mhd).ToList();

            return View(dsct);
        }

        // Cập nhật giao hàng -----------------------------------------------------------------------------
        [HttpPost]
        public ActionResult GiaoHang(FormCollection col)
        {
            int tong = int.Parse(col["tong"]);

            for (int i = 1; i <= tong; i++)
            {
                string tenckb = i.ToString();
                if (col[tenckb] != null) // Hóa đơn được chọn
                {
                    // Cập nhật tình trạng giao hàng tại hd có maHD la GT của nút checkbox
                    int mhd = int.Parse(col[tenckb]);
                    BILL hd = data.BILLs.SingleOrDefault(t => t.maHD == mhd);
                    hd.ngayMua = DateTime.Now;

                    UpdateModel(hd);
                    data.SubmitChanges(); // Lưu xuống db
                }
            }
            return RedirectToAction("Home", "Bill");
        }

        // Liệt kê các khách hàng -------------------------------------------------------------------------
        public ActionResult KhachHang()
        {
            List<CUSTOMER> dskh = data.CUSTOMERs.ToList();
            return View(dskh);
        }

        // Liệt kê các sản phẩm ---------------------------------------------------------------------------
        public ActionResult SanPham()
        {
            List<PRODUCT> dssp = data.PRODUCTs.ToList();
            return View(dssp);
        }

        // Trang chủ --------------------------------------------------------------------------------------
        public ActionResult TrangChu()
        {
            return View();
        }
    }
}