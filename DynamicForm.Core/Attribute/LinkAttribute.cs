using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;

namespace DynamicForm.Core.Attribute
{
    public class LinkAttribute : BaseControlAttribute
    {
        private string _href = "javascript:;";
        private string _text = string.Empty;

        public LinkAttribute(string id, string name, string htmlclass, string href, string text)
        {
            base.Id = id;
            base.Name = name;
            base.HtmlClass = htmlclass;
            _href = href;
            _text = text;
        }

        public override System.Web.Mvc.MvcHtmlString Generate()
        {
            TagBuilder tg = new TagBuilder("a");
            tg.GenerateId(Id);
            tg.Attributes.Add("name", Name);
            tg.Attributes.Add("href", _href);
            tg.SetInnerText(_text);
            tg.AddCssClass(HtmlClass);
            return MvcHtmlString.Create(tg.ToString(TagRenderMode.EndTag));
        }
    }
}
