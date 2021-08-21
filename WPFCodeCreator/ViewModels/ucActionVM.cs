using MVVMCore.BaseClass;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WPFCodeCreator.Models;

namespace WPFCodeCreator.ViewModels
{
    public class ucActionVM : ViewModelBase
    {

        #region パラメータ[Parameters]プロパティ
        /// <summary>
        /// パラメータ[Parameters]プロパティ用変数
        /// </summary>
        ActionM _Parameters = new ActionM();
        /// <summary>
        /// パラメータ[Parameters]プロパティ
        /// </summary>
        public ActionM Parameters
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
        public ucActionVM()
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
