using DynamicForm.Core.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;

namespace DynamicForm.Core.Attribute
{
    [Serializable]
    [AttributeUsage(AttributeTargets.All, Inherited = true, AllowMultiple = false)]
    public abstract class BaseControlAttribute : System.Attribute
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string HtmlClass { get; set; }
        public FiledType FiledType { get; protected set; }

        public object Value { get; set; }

        public Dictionary<string, string> CustomerAttr { get; set; }

        /// <summary>
        /// 添加自定义属性
        /// </summary>
        /// <param name="tg"></param>
        public void AddCustomerAttribute(TagBuilder tg)
        {
            if (CustomerAttr != null)
            {
                foreach (var item in CustomerAttr)
                {
                    tg.Attributes.Add(item.Key, item.Value);
                    
                }
            }
        }

        /// <summary>
        /// 生成 HTML
        /// </summary>
        /// <returns></returns>
        public abstract MvcHtmlString Generate();
    }
}
