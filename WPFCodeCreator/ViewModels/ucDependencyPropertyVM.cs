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

		#region プロパティ要素[PropertyItem]プロパティ
		/// <summary>
		/// プロパティ要素[PropertyItem]プロパティ用変数
		/// </summary>
		PropertyM _PropertyItem = new PropertyM();
		/// <summary>
		/// プロパティ要素[PropertyItem]プロパティ
		/// </summary>
		public PropertyM PropertyItem
		{
			get
			{
				return _PropertyItem;
			}
			set
			{
				if (_PropertyItem == null || !_PropertyItem.Equals(value))
				{
					_PropertyItem = value;
					NotifyPropertyChanged("PropertyItem");
				}
			}
		}
		#endregion

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

		public ucDependencyPropertyVM()
		{
			this.ClassName = "SampleClass";
			this.PropertyItem.TypeName = "int";
			this.PropertyItem.Description = "変数の説明";
			this.PropertyItem.ValueName = "ValueName";
		}


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
				code.AppendLine($"	#region {this.PropertyItem.Description}[{this.PropertyItem.ValueName}]依存プロパティ");
				code.AppendLine("	/// <summary>");
				code.AppendLine($"	/// {this.PropertyItem.Description}[{this.PropertyItem.ValueName}]依存プロパティ");
				code.AppendLine("	/// </summary>");
				code.AppendLine("	[Category(\"カスタムプロパティ\")]");
				code.AppendLine("	[Browsable(true)]");
				code.AppendLine($"	public static readonly DependencyProperty {this.PropertyItem.ValueName}Property =");
				code.AppendLine("	DependencyProperty.Register(");
				code.AppendLine($"	\"{this.PropertyItem.ValueName}\",     // プロパティ名");
				code.AppendLine($"	typeof({this.PropertyItem.TypeName}),    // プロパティの型");
				code.AppendLine($"	typeof({this.ClassName}),　 // コントロールの型");
				code.AppendLine("	new FrameworkPropertyMetadata(   // メタデータ");
				code.AppendLine("				0,");
				code.AppendLine($"				new PropertyChangedCallback({this.PropertyItem.ValueName}Changed)));");
				code.AppendLine("");
				code.AppendLine("");
				code.AppendLine("	/// <summary>");
				code.AppendLine("	/// 依存プロパティが変更された際の処理");
				code.AppendLine("	/// </summary>");
				code.AppendLine("	/// <param name=\"obj\">オブジェクト</param>");
				code.AppendLine("	/// <param name=\"e\">イベントオブジェクト</param>");
				code.AppendLine($"	private static void {this.PropertyItem.ValueName}Changed(");
				code.AppendLine("	DependencyObject obj, DependencyPropertyChangedEventArgs e)");
				code.AppendLine("	{");
				code.AppendLine($"		{this.ClassName} userControl = obj as {this.ClassName};");
				code.AppendLine("		if (userControl != null)");
				code.AppendLine("		{");
				code.AppendLine("			//////// 直接変更したいプロパティの処理を書く");
				code.AppendLine($"			{this.PropertyItem.TypeName} newValue = ({this.PropertyItem.TypeName})e.NewValue;");
				code.AppendLine("		}");
				code.AppendLine("	}");
				code.AppendLine("");
				code.AppendLine("	/// <summary>");
				code.AppendLine("	/// 依存プロパティのラッパー");
				code.AppendLine("	/// </summary>");
				code.AppendLine($"	public int {this.PropertyItem.ValueName}");
				code.AppendLine("	{");
				code.AppendLine($"		get {{ return (int)GetValue({this.PropertyItem.ValueName}Property); }}");
				code.AppendLine($"		set {{ SetValue({this.PropertyItem.ValueName}Property, value); }}");
				code.AppendLine("	}");
				code.AppendLine("	#endregion");

				this.SourceCode = code.ToString();
			}
			catch
			{

			}
		}
		#endregion

	}
}
