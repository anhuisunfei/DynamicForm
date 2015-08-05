using DynamicForm.Core.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;

namespace DynamicForm.Core.Attribute
{
    public class SelectAttribute : BaseControlAttribute
    {
        private FiledType filedType = FiledType.Select;
        private List<SelectListItem> DataSource { get; set; }


        public SelectAttribute(string _id, string _class, string _name)
        {
            Name = _name;
            Id = _id;
            HtmlClass = _class;
            FiledType = filedType;
        }

        public SelectAttribute(string _id, string _class, string _name, List<SelectListItem> _dataSource)
        {
            Id = _id;
            HtmlClass = _class;
            FiledType = filedType;
            DataSource = _dataSource;
        }

        public override System.Web.Mvc.MvcHtmlString Generate()
        {
            TagBuilder tb = new TagBuilder("select");
            tb.GenerateId(Id);
            tb.AddCssClass(HtmlClass);

            if (DataSource != null)
            {
                foreach (var item in DataSource)
                {
                    TagBuilder option = new TagBuilder("option");
                    option.Attributes.Add("value", item.Value);
                    option.SetInnerText(item.Text);
                    if (item.Selected)
                    {
                        option.Attributes.Add("selected", "selected");
                    }
                    tb.InnerHtml += option;
                }
            } 
            return new MvcHtmlString(tb.ToString());
        }
    }
}
