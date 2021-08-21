using MVVMCore.BaseClass;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WPFCodeCreator.Models;

namespace WPFCodeCreator.ViewModels
{
    public class ucBehaviorVM : ViewModelBase
    {
        #region パラメータ[Parameters]プロパティ
        /// <summary>
        /// パラメータ[Parameters]プロパティ用変数
        /// </summary>
        BehaviorM _Parameters = new BehaviorM();
        /// <summary>
        /// パラメータ[Parameters]プロパティ
        /// </summary>
        public BehaviorM Parameters
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

        #region コンストラクタ
        /// <summary>
        /// コンストラクタ
        /// </summary>
        public ucBehaviorVM()
        {

        }
        #endregion

        #region 初期化処理
        public void Init()
        {

        }
        #endregion
    }
}
