using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Mvc;

namespace DRS.Enums
{
    public static class EnumsToSelectList
    {
        public static SelectList ToSelectList(this Type enumType, string selectedValue)
        {
            var items = new List<SelectListItem>();
            var selectedValueId = 0;
            foreach (var item in Enum.GetValues(enumType))
            {
                FieldInfo fi = enumType.GetField(item.ToString());
                DescriptionAttribute[] attributes = (DescriptionAttribute[])fi.GetCustomAttributes(typeof(DescriptionAttribute), false);
                var title = "";
                if (attributes != null && attributes.Length > 0)
                {
                    title = attributes[0].Description;
                }
                else
                {
                    title = item.ToString();
                }

                var listItem = new SelectListItem
                {
                    Value = ((int)item).ToString(),
                    Text = title,
                    Selected = selectedValue == ((int)item).ToString(),
                };
                items.Add(listItem);
            }

            return new SelectList(items, "Value", "Text", selectedValueId);
        }
    }
}