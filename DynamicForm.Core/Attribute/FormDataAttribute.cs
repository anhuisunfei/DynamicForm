using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DynamicForm.Core.Attribute
{
    /// <summary>
    /// 表单数据
    /// </summary>
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = false)]
    public class FormDataAttribute : System.Attribute
    {
        # region // 字段
        private string _gridHeader;
        private int _formCols;
        #endregion

        #region // 属性
        /// <summary>
        /// Grid Title
        /// </summary>
        public string GridHeader
        {
            get { return _gridHeader; }
            set { this._gridHeader = value; }
        }

        /// <summary>
        /// 表格行数  需是2的倍数
        /// </summary>
        public int FormCols
        {
            get { return _formCols; }
            set
            {
                if (value <= 0)
                    throw new ArgumentException("表格行数请输入整数!");

                if (value % 2 != 0)
                    throw new ArgumentException("表格行数请输入2的倍数!");

                this._formCols = value;
            }
        }

      
        #endregion
    }
}
