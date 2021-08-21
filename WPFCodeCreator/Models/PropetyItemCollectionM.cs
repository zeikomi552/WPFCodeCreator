using MVVMCore.BaseClass;
using MVVMCore.Common.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPFCodeCreator.Models
{
    public class PropetyItemCollectionM : ModelBase
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
					NotifyPropertyChanged("SourceCode");
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
					NotifyPropertyChanged("SourceCode");
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
					NotifyPropertyChanged("SourceCode");
				}
			}
		}
		#endregion

		#region ソースコード
		/// <summary>
		/// ソースコード
		/// </summary>
		public string SourceCode
		{
			get
			{
				return RefreshCode();
			}
		}
		#endregion

		#region コードの更新
		/// <summary>
		/// コードの更新
		/// </summary>
		public string RefreshCode()
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
			return code.ToString();
		}
		#endregion

		public void Refresh()
		{
			NotifyPropertyChanged("SourceCode");
		}
	}
}
