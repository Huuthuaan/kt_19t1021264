using kt_19T1021264.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace kt_19T1021264.View
{ 
    public class NguoiView
{
    public int ID { get; set; }

    public string TenGoi { get; set; }

    public string Email { get; set; }

    public string DiaChi { get; set; }

    public string Phonenumber { get; set; }

    public int? IDNhom { get; set; }

    public NguoiView()
{

}

    public static void AddSinhVien(Nguoi nguoi)
    {
        var db = new Model1();
        var rs = db.Nguois.Add(nguoi);
        db.SaveChanges();
    }


    public static List<NguoiView> Getlist(int ID)
    {

        var db = new Model1();
        var rs = db.Nguois.Where(e => e.IDNhom == ID).Select(e => new NguoiView
        {
            ID = e.ID,
            TenGoi = e.TenGoi,
            Email = e.Email,
            Phonenumber = e.PhoneNumber,
            
            IDNhom = e.IDNhom,
        }).ToList();
        return rs;
    }

    public static List<NguoiView> GetlistAll()
    {

        var db = new Model1();
        var rs = db.Nguois.Select(e => new NguoiView
        {
            ID = e.ID,
            TenGoi = e.TenGoi,
            Email = e.Email,
            Phonenumber = e.PhoneNumber,
            
            IDNhom = e.IDNhom,
        }).ToList();
        return rs;
    }


    public static void DeleteSinhVien(int id)
    {
        var db = new Model1();
        var nguoi = db.Nguois.Where(e => e.ID == id).FirstOrDefault();
        var rs = db.Nguois.Remove(nguoi);
        db.SaveChanges();
    }
}
}
