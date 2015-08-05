using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;

namespace DynamicForm.Core.Helper
{
    /// <summary>
    /// html
    /// </summary>
    public static class HtmlExtensions
    {
        /// <summary>
        /// 必填项标记
        /// </summary>
        /// <returns></returns>
        public static MvcHtmlString RequiredB()
        {
            TagBuilder b = new TagBuilder("b");
            b.AddCssClass("red");
            b.InnerHtml = "*";
            return new MvcHtmlString(b.ToString());
        }

        /// <summary>
        /// radio2
        /// </summary>
        /// <param name="text"></param>
        /// <param name="name"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        public static MvcHtmlString RadioButton(string text, string name, string id)
        {
            TagBuilder label = new TagBuilder("label");

            TagBuilder radio = new TagBuilder("input");
            radio.AddCssClass("ace");
            radio.Attributes.Add("type", "radio");
            radio.Attributes.Add("name", name);
            radio.GenerateId(id);

            TagBuilder span = new TagBuilder("span");
            span.AddCssClass("lbl");
            span.InnerHtml = text;

            label.InnerHtml += radio.ToString();
            label.InnerHtml += span.ToString();

            return new MvcHtmlString(label.ToString());
        }
    }
}
