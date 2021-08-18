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
		#region クラス名[ClassName]プロパティ
		/// <summary>
		/// クラス名[ClassName]プロパティ用変数
		/// </summary>
		string _ClassName = string.Empty;
		/// <summary>
		/// クラス名[ClassName]プロパティ
		/// </summary>
		public string ClassName
		{
			get
			{
				return _ClassName;
			}
			set
			{
				if (!_ClassName.Equals(value))
				{
					_ClassName = value;
					NotifyPropertyChanged("ClassName");
				}
			}
		}
		#endregion

		#region クラス表示フラグ[ClassVisible]プロパティ
		/// <summary>
		/// クラス表示フラグ[ClassVisible]プロパティ用変数
		/// </summary>
		bool _ClassVisible = false;
		/// <summary>
		/// クラス表示フラグ[ClassVisible]プロパティ
		/// </summary>
		public bool ClassVisible
		{
			get
			{
				return _ClassVisible;
			}
			set
			{
				if (!_ClassVisible.Equals(value))
				{
					_ClassVisible = value;
					NotifyPropertyChanged("ClassVisible");
				}
			}
		}
		#endregion

		#region プロパティ変数ソースコード[PropertyCode]プロパティ
		/// <summary>
		/// プロパティ変数ソースコード[PropertyCode]プロパティ用変数
		/// </summary>
		string _PropertyCode = string.Empty;
		/// <summary>
		/// プロパティ変数ソースコード[PropertyCode]プロパティ
		/// </summary>
		public string PropertyCode
		{
			get
			{
				return _PropertyCode;
			}
			set
			{
				if (!_PropertyCode.Equals(value))
				{
					_PropertyCode = value;
					NotifyPropertyChanged("PropertyCode");
				}
			}
		}
		#endregion

		#region プロパティ変数[PropertyItems]プロパティ
		/// <summary>
		/// プロパティ変数[PropertyItems]プロパティ用変数
		/// </summary>
		ModelList<PropertyM> _PropertyItems = new ModelList<PropertyM>();
		/// <summary>
		/// プロパティ変数[PropertyItems]プロパティ
		/// </summary>
		public ModelList<PropertyM> PropertyItems
		{
			get
			{
				return _PropertyItems;
			}
			set
			{
				if (_PropertyItems == null || !_PropertyItems.Equals(value))
				{
					_PropertyItems = value;
					NotifyPropertyChanged("PropertyItems");
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
				// ダイアログのインスタンスを生成
				var dialog = new SaveFileDialog();

				// ファイルの種類を設定
				dialog.Filter = "WPFCodeCreator用ファイル(*.wpfcc)|*.wpfcc";

				// ダイアログを表示する
				if (dialog.ShowDialog() == true)
				{
					XMLUtil.Seialize<ModelList<PropertyM>>(dialog.FileName, this.PropertyItems);
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
					this.PropertyItems = XMLUtil.Deserialize<ModelList<PropertyM>>(dialog.FileName);
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
				foreach (var tmp in this.PropertyItems.Items)
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

		#region コードの更新
		/// <summary>
		/// コードの更新
		/// </summary>
		public void RefleshCode()
        {
            try
            {
				StringBuilder code = new StringBuilder();

				if (this.ClassVisible)
                {
					code.AppendLine($"public class {this.ClassName} : INotifyPropertyChanged");
					code.AppendLine($"{{");
				}

				foreach (var tmp in this.PropertyItems)
				{
					if (tmp.IsVisible)
					{
						code.AppendLine(tmp.PropertyCode);
					}
				}

				if (this.ClassVisible)
				{
					code.AppendLine("	#region INotifyPropertyChanged");
					code.AppendLine("	public event PropertyChangedEventHandler PropertyChanged;");
					code.AppendLine("");
					code.AppendLine("	private void NotifyPropertyChanged(String info)");
					code.AppendLine("	{");
					code.AppendLine("		if (PropertyChanged != null)");
					code.AppendLine("		{");
					code.AppendLine("			PropertyChanged(this, new PropertyChangedEventArgs(info));");
					code.AppendLine("		}");
					code.AppendLine("	}");
					code.AppendLine("	#endregion");
					code.AppendLine($"}}");
				}
				this.PropertyCode = code.ToString();
			}
			catch
            {

            }
        }
		#endregion
	}
}
