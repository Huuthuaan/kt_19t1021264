using kt_19T1021264.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace kt_19T1021264.View
{
    public class NhomView
    {
        public int ID { get; set; }
        public string TenNhom { get; set; }

        public NhomView()
        {

        }

        public static void AddNhom(Nhom nhom)
        {
            var db = new Model1();
            var rs = db.Nhoms.Add(nhom);
            db.SaveChanges();
        }

        public static List<NhomView> Getlist()
        {


            var db = new Model1();
            var rs = db.Nhoms.Select(e => new NhomView
            {
                ID = e.ID,
                TenNhom = e.TenNhom,
            }).ToList();
            return rs;
        }
        public static void DeleteNhom(int id)
        {
            var db = new Model1();
            var sinhvien = db.Nhoms.Where(e => e.ID == id).FirstOrDefault();
            var rs = db.Nhoms.Remove(sinhvien);
            db.SaveChanges();
        }
    }
}
