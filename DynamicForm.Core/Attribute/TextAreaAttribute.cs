using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;

namespace DynamicForm.Core.Attribute
{
    public class TextAreaAttribute : BaseControlAttribute
    {
        private int _rows = 0;
        private int _cols = 0;

        public TextAreaAttribute(int rows, int cols, string id, string htmlclass, string name)
        {
            base.Id = id;
            base.Name = name;
            base.HtmlClass = htmlclass;

            _rows = rows;
            _cols = cols;
        }

        public override System.Web.Mvc.MvcHtmlString Generate()
        {
            TagBuilder tg = new TagBuilder("textare");
            tg.AddCssClass(HtmlClass);
            tg.Attributes.Add("rows", _rows.ToString());
            tg.Attributes.Add("cols", _cols.ToString());
            tg.GenerateId(Id);
            tg.Attributes.Add("name", Name);
            if (Value != null)
                tg.InnerHtml = Value.ToString();
            return MvcHtmlString.Create(tg.ToString(TagRenderMode.EndTag));
        }
    }
}
