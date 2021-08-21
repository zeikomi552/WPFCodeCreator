using MVVMCore.BaseClass;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPFCodeCreator.Models
{
    public class DependencyPropertyM : ModelBase
    {
		#region クラス名[ClassName]プロパティ
		/// <summary>
		/// クラス名[ClassName]プロパティ用変数
		/// </summary>
		string _ClassName = "SampleClass";
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

		#region 型名[TypeName]プロパティ
		/// <summary>
		/// 型名[TypeName]プロパティ用変数
		/// </summary>
		string _TypeName = "int";
		/// <summary>
		/// 型名[TypeName]プロパティ
		/// </summary>
		public string TypeName
		{
			get
			{
				return _TypeName;
			}
			set
			{
				if (!_TypeName.Equals(value))
				{
					_TypeName = value;
					NotifyPropertyChanged("TypeName");
					NotifyPropertyChanged("SourceCode");
				}
			}
		}
		#endregion

		#region 変数名[ValueName]プロパティ
		/// <summary>
		/// 変数名[ValueName]プロパティ用変数
		/// </summary>
		string _ValueName = "SampleValue";
		/// <summary>
		/// 変数名[ValueName]プロパティ
		/// </summary>
		public string ValueName
		{
			get
			{
				return _ValueName;
			}
			set
			{
				if (!_ValueName.Equals(value))
				{
					_ValueName = value;
					NotifyPropertyChanged("ValueName");
					NotifyPropertyChanged("SourceCode");
				}
			}
		}
		#endregion

		#region 説明[Description]プロパティ
		/// <summary>
		/// 説明[Description]プロパティ用変数
		/// </summary>
		string _Description = "説明";
		/// <summary>
		/// 説明[Description]プロパティ
		/// </summary>
		public string Description
		{
			get
			{
				return _Description;
			}
			set
			{
				if (!_Description.Equals(value))
				{
					_Description = value;
					NotifyPropertyChanged("Description");
					NotifyPropertyChanged("SourceCode");
				}
			}
		}
		#endregion

		#region ソースコード[SourceCode]プロパティ
		/// <summary>
		/// ソースコード[SourceCode]プロパティ
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
			code.AppendLine($"	#region {this.Description}[{this.ValueName}]依存プロパティ");
			code.AppendLine("	/// <summary>");
			code.AppendLine($"	/// {this.Description}[{this.ValueName}]依存プロパティ");
			code.AppendLine("	/// </summary>");
			code.AppendLine("	[Category(\"カスタムプロパティ\")]");
			code.AppendLine("	[Browsable(true)]");
			code.AppendLine($"	public static readonly DependencyProperty {this.ValueName}Property =");
			code.AppendLine("	DependencyProperty.Register(");
			code.AppendLine($"	\"{this.ValueName}\",     // プロパティ名");
			code.AppendLine($"	typeof({this.TypeName}),    // プロパティの型");
			code.AppendLine($"	typeof({this.ClassName}),　 // コントロールの型");
			code.AppendLine("	new FrameworkPropertyMetadata(   // メタデータ");
			code.AppendLine("				0,");
			code.AppendLine($"				new PropertyChangedCallback({this.ValueName}Changed)));");
			code.AppendLine("");
			code.AppendLine("");
			code.AppendLine("	/// <summary>");
			code.AppendLine("	/// 依存プロパティが変更された際の処理");
			code.AppendLine("	/// </summary>");
			code.AppendLine("	/// <param name=\"obj\">オブジェクト</param>");
			code.AppendLine("	/// <param name=\"e\">イベントオブジェクト</param>");
			code.AppendLine($"	private static void {this.ValueName}Changed(");
			code.AppendLine("	DependencyObject obj, DependencyPropertyChangedEventArgs e)");
			code.AppendLine("	{");
			code.AppendLine($"		{this.ClassName} userControl = obj as {this.ClassName};");
			code.AppendLine("		if (userControl != null)");
			code.AppendLine("		{");
			code.AppendLine("			//////// 直接変更したいプロパティの処理を書く");
			code.AppendLine($"			{this.TypeName} newValue = ({this.TypeName})e.NewValue;");
			code.AppendLine("		}");
			code.AppendLine("	}");
			code.AppendLine("");
			code.AppendLine("	/// <summary>");
			code.AppendLine("	/// 依存プロパティのラッパー");
			code.AppendLine("	/// </summary>");
			code.AppendLine($"	public int {this.ValueName}");
			code.AppendLine("	{");
			code.AppendLine($"		get {{ return (int)GetValue({this.ValueName}Property); }}");
			code.AppendLine($"		set {{ SetValue({this.ValueName}Property, value); }}");
			code.AppendLine("	}");
			code.AppendLine("	#endregion");

			return code.ToString();
		}
		#endregion
	}
}
