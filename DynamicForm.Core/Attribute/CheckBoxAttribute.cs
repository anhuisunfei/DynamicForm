using DynamicForm.Core.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;

namespace DynamicForm.Core.Attribute
{
    public class CheckBoxAttribute : BaseControlAttribute
    {
        private FiledType fileType = FiledType.CheckBox;
        private List<String> TextList { get; set; }

        public CheckBoxAttribute(string _id, string _class, string _name, List<string> textlist)
        {
            TextList = textlist;
            Name = _name;
            Id = _id;
            HtmlClass = _class;
            FiledType = fileType;
        }
        public override System.Web.Mvc.MvcHtmlString Generate()
        {
            // <label>
            //<input class="ace" type="checkbox" name="form-field-checkbox">
            //<span class="lbl"> choice 1</span>
            //</label>
            StringBuilder sb = new StringBuilder();

            if (TextList == null)
                throw new ArgumentNullException("TextList is null");


            foreach (var item in TextList)
            {
                TagBuilder label = new TagBuilder("label");

                TagBuilder aceCheckBox = new TagBuilder("input");
                aceCheckBox.AddCssClass("ace");
                aceCheckBox.Attributes.Add("type", "checkbox");
                aceCheckBox.Attributes.Add("name", Name);

                if (Value != null && item == Value.ToString())
                    aceCheckBox.Attributes.Add("checked", "checked");

                TagBuilder span = new TagBuilder("span");
                span.AddCssClass("lbl");
                span.SetInnerText(item);
                sb.AppendLine(span.ToString());
            }

            return MvcHtmlString.Create(sb.ToString());
        }
    }
}
