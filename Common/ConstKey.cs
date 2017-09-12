using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Common
{
    public class ConstKey
    {
        public const string DbConnectionName = "Qlxd";
        public const string EncryptingKey = "jdsg432387#";
        public enum EnumDonViTinh
        {
            [Description("Lít")]
            Lit = 1,
            [Description("Mét khối")]
            m3 = 2,
            [Description("Gallon")]
            Gal = 3,
        }
        public static List<SelectListItem> DonViTinhList
        {
            get
            {
                List<SelectListItem> objListItems = new List<SelectListItem>();

                var enumData = from ConstKey.EnumDonViTinh e in Enum.GetValues(typeof(ConstKey.EnumDonViTinh))
                               select new
                               {
                                   ID = (int)e,
                                   Name = e.ToString()
                               };
                var lists = enumData.Select(s => new SelectListItem { Value = s.ID.ToString(), Text = s.Name });
                foreach (var o in lists)
                {
                    switch (o.Value.ToString())
                    {
                        case "1":
                            o.Text = "Lít";
                            break;
                        case "2":
                            o.Text = "Mét khối";
                            break;
                        case "3":
                            o.Text = "Gallon";
                            break;
                        default:
                            o.Value = "1";
                            break;
                    }
                    objListItems.Add(new SelectListItem { Value = o.Value, Text = o.Text });
                }
                return objListItems;
            }
        }
    }
}
