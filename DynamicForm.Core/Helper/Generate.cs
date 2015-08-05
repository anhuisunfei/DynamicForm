using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;

using System.ComponentModel.DataAnnotations;
using DynamicForm.Core.Attribute;
using System.Reflection;

namespace DynamicForm.Core.Helper
{
    public static class Generate
    {
        public static MvcHtmlString GenerateValidateEngineForm<TModel>(this HtmlHelper<TModel> helper)
        {
            if (helper.ViewData.ModelMetadata.ModelType == null)
            {
                return new MvcHtmlString(String.Empty);
            }
            // 获取所有属性
            var properties = typeof(TModel).GetProperties(BindingFlags.Public | BindingFlags.Instance);
            var formData = (typeof(TModel).GetCustomAttributes(typeof(FormDataAttribute), true).FirstOrDefault() as FormDataAttribute);
            int cols = formData == null ? 6 : formData.FormCols;
            properties = (from p in properties
                          let pAttr = (p.GetCustomAttributes(typeof(DynamicFormAttribute), true).FirstOrDefault() as DynamicFormAttribute)
                          orderby pAttr == null ? 0 : pAttr.Order
                          select p).ToArray();

            TagBuilder table = new TagBuilder("table");
            table.AddCssClass("table table-bordered table-striped");

            TagBuilder tr = new TagBuilder("tr");
            int fieldCount = (from p in properties
                              let pAttr = (p.GetCustomAttributes(typeof(DynamicFormAttribute), true).FirstOrDefault() as DynamicFormAttribute)
                              where pAttr != null && pAttr.InputType != InputFiledType.Hidden
                              select p
                             ).Count();
            int ros = fieldCount / cols + (fieldCount % cols) > 0 ? 1 : 0;
            //properties = properties.OrderBy(p =>
            //    (p.GetCustomAttributes(typeof(DynamicFormAttribute), true).FirstOrDefault() as DynamicFormAttribute).Order).ToArray();
            int index = 1;
            for (int i = 0; i < properties.Length; i++)
            {
                var item = properties[i];
                // 获取所有定制
                var attributes = item.GetCustomAttributes(true);
                InputFiledType filedType = InputFiledType.Text;
                string validation = string.Empty;
                bool isRequired = false;
                string displayName = item.Name;
                int colspan = 0;
                foreach (var attr in attributes)
                {
                    var attrType = attr.GetType();

                    if (attrType == typeof(DynamicFormAttribute))
                    {
                        filedType = ((DynamicFormAttribute)attr).InputType;
                        colspan = ((DynamicFormAttribute)attr).ColSpan;
                    }
                    if (attrType == typeof(RequiredAttribute))
                    {
                        validation += "required,";
                        isRequired = true;
                    }
                    if (attrType == typeof(RangeAttribute))
                    {
                        var proType = item.PropertyType;
                        string custom = "custom[integer]";
                        if (proType == typeof(decimal) || proType == typeof(float) || proType == typeof(double))
                            custom = "custom[number]";
                        var min = ((RangeAttribute)attr).Minimum;
                        var max = ((RangeAttribute)attr).Maximum;
                        validation += String.Format("{2},min[{0}],max[{1}],", min, max, custom);
                    }
                    if (attrType == typeof(StringLengthAttribute))
                    {
                        var minimumLength = ((StringLengthAttribute)attr).MinimumLength;
                        var maximumLength = ((StringLengthAttribute)attr).MaximumLength;
                        validation = String.Format("maxSize[{0}],minSize[{1}],", maximumLength, minimumLength);
                    }
                    if (attrType == typeof(DisplayAttribute))
                    {
                        displayName = ((DisplayAttribute)attr).Name;
                    }
                    if (!string.IsNullOrEmpty(validation))
                    {
                        validation = string.Format("validate[{0}]", validation.TrimEnd(','));
                    }
                }


                // 奇数列
                TagBuilder tdodd = new TagBuilder("td");
                if (isRequired)
                    tdodd.InnerHtml += HtmlExtensions.RequiredB();

                tdodd.InnerHtml += displayName;

                // 偶数列
                TagBuilder tdeven = new TagBuilder("td");
                tdeven.InnerHtml += BuilderHtmlFiled(filedType, validation, item.Name, item.Name, null);

                tr.InnerHtml += tdodd;
                tr.InnerHtml += tdeven;

                // 补全空白TD
                if (i == properties.Length - 1)
                {
                    int surplus = cols - index++ * 2;
                    for (int j = 0; j < surplus; j++)
                    {
                        TagBuilder td = new TagBuilder("td");
                        tr.InnerHtml += td;
                    }
                }
                if (index++ * 2 == cols || i == properties.Length - 1)
                {
                    table.InnerHtml += tr;
                    tr.InnerHtml = string.Empty;
                    index = 1;
                }
            }

            return new MvcHtmlString(table.ToString());
        }

        internal static string BuilderHtmlFiled(InputFiledType type, string cssClass, string id, string name, object attribute)
        {
            TagBuilder tg = new TagBuilder("input");
            tg.GenerateId(id);
            tg.Attributes.Add("name", name);
            tg.Attributes.Add("class", cssClass);
            switch (type)
            {
                case InputFiledType.Text:
                    tg.Attributes.Add("type", "text");
                    break;
                case InputFiledType.Hidden:
                    tg.Attributes.Add("type", "hidden");
                    break;
                case InputFiledType.Select:
                    tg = new TagBuilder("select");
                    break;
                case InputFiledType.File:
                    tg.Attributes.Add("type", "file");
                    break;
                case InputFiledType.TextArea:
                    tg = new TagBuilder("textarea");
                    break;
                case InputFiledType.CheckBox:
                    tg.Attributes.Add("type", "checkbox");
                    break;
                case InputFiledType.Radion:
                    tg.Attributes.Add("type", "radio");
                    break;
            }

            var otherAttribute = attribute as IDictionary<String, String>;
            if (otherAttribute != null)
            {
                foreach (var item in otherAttribute)
                {
                    tg.Attributes.Add(item.Key, item.Value);
                }
            }
            return tg.ToString();
        }
    }
}
