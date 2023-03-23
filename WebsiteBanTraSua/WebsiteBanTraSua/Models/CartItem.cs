using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebsiteBanTraSua.Models
{
    public class CartItem
    {
        public string iMaSP { get; set; }
        public string sTenSP { get; set; }
        public string sAnhBia { get; set; }
        public double dDonGia { get; set; }
        public int iSoLuong { get; set; }
        public double ThanhTien
        {
            get
            {
                return iSoLuong * dDonGia;
            }
        }

        DataClasses1DataContext data = new DataClasses1DataContext();

        // Hàm tạo cho giỏ hàng ---------------------------------------------------------------------------
        public CartItem(string maSP)
        {
            PRODUCT sp = data.PRODUCTs.Single(n => n.maSP == maSP);

            if (sp != null) // Tìm được sản phẩm
            {
                iMaSP = maSP;
                sTenSP = sp.tenSP;
                sAnhBia = sp.hinhAnh;
                dDonGia = double.Parse(sp.gia.ToString());
                iSoLuong = 1;
            }
        }
    }
}