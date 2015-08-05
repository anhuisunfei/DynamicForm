using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DynamicForm.Core.Attribute
{
    /// <summary>
    /// 表单Attribute
    /// </summary>
    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Field, AllowMultiple = false)]
    public class DynamicFormAttribute : System.Attribute
    {
        private int _order;
        private InputFiledType _inputType;
        private int _colSpan; 


        public InputFiledType InputType
        {
            get { return _inputType; }
            set { _inputType = value; }
        }


        public int Order
        {
            get { return _order; }
            set { _order = value; }
        }

        /// <summary>
        /// 横跨列数
        /// </summary>
        public int ColSpan
        {
            get { return _colSpan; }
            set { _colSpan = value; }
        }


    }

    /// <summary>
    /// Input type
    /// </summary>
    public enum InputFiledType
    {
        Text,
        Hidden,	
        Select,
        File,
        TextArea,
        CheckBox,
        Radion
    }

}
