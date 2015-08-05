using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;

namespace DynamicForm.Core.Attribute
{
    public class FileAttribute : BaseControlAttribute
    {
        public bool _multiple = false;

        public FileAttribute(string id, string name, string htmlclass, bool mutiple = false)
        {
            _multiple = mutiple;
            base.Id = id;
            base.Name = name;
            base.HtmlClass = htmlclass;
        }

        public override System.Web.Mvc.MvcHtmlString Generate()
        {
            TagBuilder tg = new TagBuilder("input");
            tg.GenerateId(Id);
            tg.Attributes.Add("name", Name);
            tg.Attributes.Add("type", "file");
            tg.AddCssClass(HtmlClass);
            if (_multiple)
                tg.Attributes.Add("multiple", "multiple");
            return MvcHtmlString.Create(tg.ToString(TagRenderMode.SelfClosing));
        }
    }
}
