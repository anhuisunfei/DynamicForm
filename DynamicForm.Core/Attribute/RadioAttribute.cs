using DynamicForm.Core.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;

namespace DynamicForm.Core.Attribute
{
    public class RadioAttribute : BaseControlAttribute
    {
        private FiledType filedType = FiledType.Radio;
        private List<String> TextList { get; set; }

        public RadioAttribute(string _id, string _name, string _class, string textList)
        {
            Id = _id;
            Name = _name;
            HtmlClass = _class;
            TextList = textList.Split(',').ToList();
            FiledType = filedType;
        }

        public override System.Web.Mvc.MvcHtmlString Generate()
        {
            //<label>
            //    <input class="ace" type="checkbox" disabled="" name="form-field-checkbox">
            //    <span class="lbl"> disabled</span>
            //</label>
            StringBuilder sb = new StringBuilder();

            if (TextList == null)
                throw new ArgumentNullException("TextList is null");

            foreach (var item in TextList)
            {
                TagBuilder label = new TagBuilder("label");
                label.AddCssClass(HtmlClass);

                TagBuilder aceCheckBox = new TagBuilder("input");
                aceCheckBox.AddCssClass("ace");
                aceCheckBox.Attributes.Add("type", "radio");
                aceCheckBox.Attributes.Add("name", Name);
                aceCheckBox.Attributes.Add("value", item);

                if (Value != null && item == Value.ToString())
                    aceCheckBox.Attributes.Add("checked", "checked");

                TagBuilder span = new TagBuilder("span");
                span.AddCssClass("lbl");
                span.SetInnerText(item);
                label.InnerHtml += aceCheckBox;
                label.InnerHtml += span;
                sb.AppendLine(label.ToString());
            }

            return MvcHtmlString.Create(sb.ToString());

        }
    }
}
