using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MvcCodeFirst.Models
{
    [Table("Logs")]
    public class Log
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [DisplayName("İşlem Tarihi"), Required()]
        public DateTime Tarih { get; set; }

        [StringLength(25), Required(), DisplayName("Kişi")]
        public string KisiAdi { get; set; }

        [StringLength(100), DisplayName("Action")]
        public string ActionName { get; set; }
        [StringLength(100), DisplayName("Controller")]
        public string ControllerName { get; set; }
        [StringLength(100), DisplayName("Bilgi")]
        public string Bilgi { get; set; }
    }
}