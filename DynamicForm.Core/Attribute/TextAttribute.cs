using DynamicForm.Core.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;

namespace DynamicForm.Core.Attribute
{
    public class TextAttribute : BaseControlAttribute
    {
        private FiledType fileType = FiledType.Text;

        public TextAttribute(string _id, string _class, string _name)
        {
            Name = _name;
            Id = _id;
            HtmlClass = _class;
            FiledType = fileType;
        }

        public override System.Web.Mvc.MvcHtmlString Generate()
        {
            TagBuilder tg = new TagBuilder("input");
            tg.Attributes.Add("type", "text");
            tg.GenerateId(Id);
            tg.AddCssClass(HtmlClass);
            tg.Attributes.Add("name", Name);
            if (Value != null)
                tg.Attributes.Add("value", Value.ToString());

            return MvcHtmlString.Create(tg.ToString(TagRenderMode.SelfClosing));
        }
    }
}
