using DynamicForm.Core.Attribute;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Web.Mvc;

using System.Xml;

namespace DynamicForm.Core.MyActionResult
{
    public class DhtmlxGridActionResult<T> : ActionResult where T : class
    {
        public List<T> Data{get;set;}

        public DhtmlxGridActionResult(){}

        public DhtmlxGridActionResult(List<T> listData)
        {
            Data = listData;
        }
        public override void ExecuteResult(ControllerContext context)
        {
            if (context == null)
                throw new ArgumentNullException();

            var response = context.HttpContext.Response;
            response.ContentType = "text/xml";
           
            if (Data != null)
            {
                Type type = typeof(T);
                // 获取所有公有属性
                var propertites = type.GetProperties(BindingFlags.Public | BindingFlags.Instance);
                propertites = (from p in propertites
                               let dhxAttr = (p.GetCustomAttributes(typeof(DhtmlxGridAttribute), true)
                                               .FirstOrDefault() as DhtmlxGridAttribute)
                               where dhxAttr != null
                               orderby dhxAttr.Filedorder
                               select p).ToArray();


                StringBuilder sb = new StringBuilder("<?xml version=\"1.0\" encoding=\"UTF-8\"?>");
                sb.Append("<rows>");
                var sbHeader = new StringBuilder("<head>");

                foreach (var item in propertites)
                {
                    var dhxmlAttr = item.GetCustomAttributes(typeof(DhtmlxGridAttribute), true)
                        .FirstOrDefault() as DhtmlxGridAttribute;
                    sbHeader.AppendFormat("<column width=\"{0}\" type=\"{1}\" align=\"{2}\" color=\"{3}\" sort=\"{4}\">{5}</column>",
                        dhxmlAttr.Width,
                        dhxmlAttr.Type,
                        dhxmlAttr.Align,
                        dhxmlAttr.Color,
                        dhxmlAttr.Sort,
                        dhxmlAttr.Title
                        );
                }
                sbHeader.Append("</head>");
                sb.Append(sbHeader);

                var sbRows = new StringBuilder();
                foreach (var item in Data)
                {
                    sbRows.Append("<row>");
                    foreach (var pro in propertites)
                    {
                        sbRows.AppendFormat("<cell>{0}</cell>", item.GetType().GetProperty(pro.Name).GetValue(item, null).ToString());
                    }
                    sbRows.Append("</row>");
                }
                sb.Append(sbRows);
                sb.Append("</rows>");

                response.Write(sb.ToString());
            }
        }
    }
}
