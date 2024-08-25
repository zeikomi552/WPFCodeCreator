using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.Win32;
using MVVMCore.BaseClass;
using MVVMCore.Common.Utilities;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WPFCodeCreator.Models;
using Microsoft.CodeAnalysis.Operations;
using System.Text.RegularExpressions;
using WPFCodeCreator.Models.Interface;

namespace WPFCodeCreator.ViewModels
{
    public class ucPropertyViewModel : ViewModelBase
    {
		public ucPropertyViewModel(IPropetyItemCollectionM paramters)
		{
			this.Parameters = paramters;
		}
        #region パラメータ[Parameters]プロパティ
        /// <summary>
        /// パラメータ[Parameters]プロパティ用変数
        /// </summary>
        IPropetyItemCollectionM _Parameters;
		/// <summary>
		/// パラメータ[Parameters]プロパティ
		/// </summary>
		public IPropetyItemCollectionM Parameters
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

		#region 保存処理
		/// <summary>
		/// 保存処理
		/// </summary>
		public void Save()
		{
			try
			{
				this.Parameters.FileSave();
            }
			catch(Exception e)
            {
				ShowMessage.ShowErrorOK(e.Message, "Error");
            }
		}
        #endregion

        #region 読込処理
        /// <summary>
        /// 読込処理
        /// </summary>
        public void Load()
		{
			try
			{
                this.Parameters.FileLoad();
            }
			catch (Exception e)
			{
				ShowMessage.ShowErrorOK(e.Message, "Error");
			}
		}
        #endregion

        #region C#コードの読込処理
        /// <summary>
        /// C#コードの読込処理
        /// </summary>
        public void LoadCS()
        {
            try
            {
                this.Parameters.LoadCS();
            }
            catch (Exception e)
            {
                ShowMessage.ShowErrorOK(e.Message, "Error");
            }
        }
        #endregion

        #region チェック解除
        /// <summary>
        /// チェック解除
        /// </summary>
        public void ResetCheck()
		{
			try
			{
				this.Parameters.ResetCheck();
			}
			catch (Exception e)
			{
				ShowMessage.ShowErrorOK(e.Message, "Error");
			}
		}
		#endregion

		/// <summary>
		/// ソースコードの更新
		/// </summary>
		public void RefreshCode()
		{
			try
			{
				this.Parameters.Refresh();
			}
			catch (Exception e)
			{
				ShowMessage.ShowErrorOK(e.Message, "Error");
			}
		}

	}
}
