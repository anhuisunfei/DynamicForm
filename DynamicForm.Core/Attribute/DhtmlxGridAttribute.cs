using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DynamicForm.Core.Attribute
{
    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Field, AllowMultiple = false)]
    public class DhtmlxGridAttribute : System.Attribute
    {
        #region // 字段
        private string _title;
        private string _type;
        private string _align;
        private string _color;
        private string _sort;
        private int _width;
        private int _filedorder;
        #endregion

        #region // 属性
        public string Title
        {
            get { return _title; }
            set { _title = value; }
        }

        public string Type
        {
            get { return _type; }
            set { _type = value; }
        }


        public string Align
        {
            get { return _align; }
            set { _align = value; }
        }


        public string Color
        {
            get { return _color; }
            set { _color = value; }
        }


        public string Sort
        {
            get { return _sort; }
            set { _sort = value; }
        }


        public int Width
        {
            get { return _width; }
            set { _width = value; }
        }

        public int Filedorder
        {
            get { return _filedorder; }
            set { _filedorder = value; }
        }

        #endregion


    }
}
