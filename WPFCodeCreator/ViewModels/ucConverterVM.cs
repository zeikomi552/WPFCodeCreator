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
    public class ucConverterVM : ViewModelBase
    {
		#region ソースコード[SourceCode]プロパティ
		/// <summary>
		/// ソースコード[SourceCode]プロパティ用変数
		/// </summary>
		string _SourceCode = string.Empty;
		/// <summary>
		/// ソースコード[SourceCode]プロパティ
		/// </summary>
		public string SourceCode
		{
			get
			{
				return _SourceCode;
			}
			set
			{
				if (!_SourceCode.Equals(value))
				{
					_SourceCode = value;
					NotifyPropertyChanged("SourceCode");
				}
			}
		}
		#endregion

		#region バインドする型[BindingTypeName]プロパティ
		/// <summary>
		/// バインドする型[BindingTypeName]プロパティ用変数
		/// </summary>
		string _BindingTypeName = string.Empty;
		/// <summary>
		/// バインドする型[BindingTypeName]プロパティ
		/// </summary>
		public string BindingTypeName
		{
			get
			{
				return _BindingTypeName;
			}
			set
			{
				if (!_BindingTypeName.Equals(value))
				{
					_BindingTypeName = value;
					NotifyPropertyChanged("BindingTypeName");
				}
			}
		}
		#endregion

		#region 変換する型[ConvertTypeName]プロパティ
		/// <summary>
		/// 変換する型[ConvertTypeName]プロパティ用変数
		/// </summary>
		string _ConvertTypeName = string.Empty;
		/// <summary>
		/// 変換する型[ConvertTypeName]プロパティ
		/// </summary>
		public string ConvertTypeName
		{
			get
			{
				return _ConvertTypeName;
			}
			set
			{
				if (!_ConvertTypeName.Equals(value))
				{
					_ConvertTypeName = value;
					NotifyPropertyChanged("ConvertTypeName");
				}
			}
		}
		#endregion

		#region コンバーター名[ConverterName]プロパティ
		/// <summary>
		/// コンバーター名[ConverterName]プロパティ用変数
		/// </summary>
		string _ConverterName = string.Empty;
		/// <summary>
		/// コンバーター名[ConverterName]プロパティ
		/// </summary>
		public string ConverterName
		{
			get
			{
				return _ConverterName;
			}
			set
			{
				if (!_ConverterName.Equals(value))
				{
					_ConverterName = value;
					NotifyPropertyChanged("ConverterName");
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
			RefleshCode();
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
				code.AppendLine($"[System.Windows.Data.ValueConversion(typeof({this.BindingTypeName}), typeof({this.ConvertTypeName}))]");
				code.AppendLine($"public class {this.ConverterName}Converter : System.Windows.Data.IValueConverter");
				code.AppendLine($"{{");

				code.AppendLine($"");
				code.AppendLine($"	#region IValueConverter メンバ");
				code.AppendLine($"	public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)");
				code.AppendLine($"	{{");
				code.AppendLine($"		({this.BindingTypeName}) target = ({this.BindingTypeName})value;");

				bool tmp = false;
				var init_value = PropertyM.GetInitialValue(this.ConvertTypeName, out tmp);
				code.AppendLine($"		// ここに処理を記述する");
				code.AppendLine($"		return {init_value};");
				code.AppendLine($"	}}");
				code.AppendLine($"");
				code.AppendLine($"	// TwoWayの場合に使用する");
				code.AppendLine($"	public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)");
				code.AppendLine($"	{{");
				code.AppendLine($"		throw new NotImplementedException();");
				code.AppendLine($"	}}");
				code.AppendLine($"	#endregion");
				code.AppendLine($"}}");

				this.SourceCode = code.ToString();
			}
			catch(Exception e)
			{
				ShowMessage.ShowErrorOK(e.Message, "Error");
			}
		}
		#endregion
	}
}
