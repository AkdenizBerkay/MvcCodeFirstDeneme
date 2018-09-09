using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MvcCodeFirst.Models
{
    public class Kullanici
    {
        
        public int KullaniciId { get; set; }
        [DisplayName("Adınız:"), Required()]
        public string Ad { get; set; }
        [DisplayName("Soyadınız:"), Required()]
        public string Soyad { get; set; }
        [DisplayName("Yaş:"),Required(),Range(1,100)]
        public int Yas { get; set; }
        [DisplayName("Şifre:"), MinLength(3,ErrorMessage ="{0} en az {1} karakter olmalı"),MaxLength(8),DataType(DataType.Password), Required()]
        public string Sifre { get; set; }
        [Compare(nameof(Sifre))]
        public string SifreTekrar { get; set; }
        [DisplayName("Mail Adresiniz:"),DataType(DataType.EmailAddress)]
        public string Eposta { get; set; }
        [DisplayName("Mail Adresiniz:"), EmailAddress(),Compare(nameof(Eposta))]
        public string EpostaTekrar { get; set; }

    }
}