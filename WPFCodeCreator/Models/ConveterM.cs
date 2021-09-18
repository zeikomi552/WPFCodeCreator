using MVVMCore.BaseClass;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPFCodeCreator.Models
{
    public class ConveterM : ModelBase
	{
		#region バインドする型[BindingTypeName]プロパティ
		/// <summary>
		/// バインドする型[BindingTypeName]プロパティ用変数
		/// </summary>
		string _BindingTypeName = "int";
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
					NotifyPropertyChanged("SourceCode");
				}
			}
		}
		#endregion

		#region 変換する型[ConvertTypeName]プロパティ
		/// <summary>
		/// 変換する型[ConvertTypeName]プロパティ用変数
		/// </summary>
		string _ConvertTypeName = "bool";
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
					NotifyPropertyChanged("SourceCode");
				}
			}
		}
		#endregion

		#region コンバーター名[ConverterName]プロパティ
		/// <summary>
		/// コンバーター名[ConverterName]プロパティ用変数
		/// </summary>
		string _ConverterName = "IntToBoolean";
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
			code.AppendLine($"[System.Windows.Data.ValueConversion(typeof({this.BindingTypeName}), typeof({this.ConvertTypeName}))]");
			code.AppendLine($"public class {this.ConverterName}Converter : System.Windows.Data.IValueConverter");
			code.AppendLine($"{{");

			code.AppendLine($"");
			code.AppendLine($"	#region IValueConverter メンバ");
			code.AppendLine($"	public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)");
			code.AppendLine($"	{{");
			code.AppendLine($"		var target = ({this.BindingTypeName})value;");

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

			return code.ToString();
		}
		#endregion
	}
}
