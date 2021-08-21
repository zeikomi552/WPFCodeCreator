using MVVMCore.BaseClass;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WPFCodeCreator.Models;

namespace WPFCodeCreator.ViewModels
{
    public class ucDependencyPropertyVM : ViewModelBase
    {

        #region パラメータ[Parameters]プロパティ
        /// <summary>
        /// パラメータ[Parameters]プロパティ用変数
        /// </summary>
        DependencyPropertyM _Parameters = new DependencyPropertyM();
        /// <summary>
        /// パラメータ[Parameters]プロパティ
        /// </summary>
        public DependencyPropertyM Parameters
        {
            get
            {
                return _Parameters;
            }
            set
            {
                if (_Parameters == null || !_Parameters.Equals(value))
                {
                    _Parameters = value;
                    NotifyPropertyChanged("Parameters");
                }
            }
        }
        #endregion

        /// <summary>
        /// コンストラクタ
        /// </summary>
        public ucDependencyPropertyVM()
		{
		}


		#region 初期化処理
		/// <summary>
		/// 初期化処理
		/// </summary>
		public void Init()
		{
		}
		#endregion


	}
}
