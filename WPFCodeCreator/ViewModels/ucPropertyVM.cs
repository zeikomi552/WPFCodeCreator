using Microsoft.Win32;
using MVVMCore.BaseClass;
using MVVMCore.Common.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WPFCodeCreator.Models;

namespace WPFCodeCreator.ViewModels
{
    public class ucPropertyVM : ViewModelBase
    {

		#region パラメータ[Parameters]プロパティ
		/// <summary>
		/// パラメータ[Parameters]プロパティ用変数
		/// </summary>
		PropetyItemCollectionM _Parameters = new PropetyItemCollectionM();
		/// <summary>
		/// パラメータ[Parameters]プロパティ
		/// </summary>
		public PropetyItemCollectionM Parameters
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
		#region 初期化処理
		/// <summary>
		/// 初期化処理
		/// </summary>
		public void Init()
		{

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
				// ダイアログのインスタンスを生成
				var dialog = new SaveFileDialog();

				// ファイルの種類を設定
				dialog.Filter = "WPFCodeCreator用ファイル(*.wpfcc)|*.wpfcc";

				// ダイアログを表示する
				if (dialog.ShowDialog() == true)
				{
					XMLUtil.Seialize<ModelList<PropertyM>>(dialog.FileName, this.Parameters.PropertyItems);
				}
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
				// ダイアログのインスタンスを生成
				var dialog = new OpenFileDialog();

				// ファイルの種類を設定
				dialog.Filter = "WPFCodeCreator用ファイル(*.wpfcc)|*.wpfcc";

				// ダイアログを表示する
				if (dialog.ShowDialog() == true)
				{
					this.Parameters.PropertyItems = XMLUtil.Deserialize<ModelList<PropertyM>>(dialog.FileName);
				}
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
				foreach (var tmp in this.Parameters.PropertyItems.Items)
				{
					tmp.IsVisible = false;
				}
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
