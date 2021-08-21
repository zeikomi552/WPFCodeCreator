using MVVMCore.BaseClass;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPFCodeCreator.Models
{
    public class BehaviorM : ModelBase
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

		#region 親クラス名[ParentClassName]プロパティ
		/// <summary>
		/// 親クラス名[ParentClassName]プロパティ用変数
		/// </summary>
		string _ParentClassName = "Button";
		/// <summary>
		/// 親クラス名[ParentClassName]プロパティ
		/// </summary>
		public string ParentClassName
		{
			get
			{
				return _ParentClassName;
			}
			set
			{
				if (!_ParentClassName.Equals(value))
				{
					_ParentClassName = value;
					NotifyPropertyChanged("ParentClassName");
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
				return RefleshCode();
			}
		}
		#endregion

		#region ソースコードのリフレッシュ
		/// <summary>
		/// ソースコードのリフレッシュ
		/// </summary>
		/// <returns>ソースコード</returns>
		private string RefleshCode()
		{
			StringBuilder cmd = new StringBuilder();
			cmd.AppendLine($"#region {this.Description}");
			cmd.AppendLine($"public class {this.ClassName}Behavior : Behavior<{this.ParentClassName}>");
			cmd.AppendLine("{");
			cmd.AppendLine($"	public static readonly DependencyProperty {this.ValueName}Property");
			cmd.AppendLine($"		= DependencyProperty.Register(\"{this.ValueName}\", typeof({this.TypeName}), typeof({this.ClassName}Behavior), null);");
			cmd.AppendLine("");
			cmd.AppendLine("	public int SampleValue");
			cmd.AppendLine("	{");
			cmd.AppendLine($"		get {{ return (int)this.GetValue({this.ValueName}Property); }}");
			cmd.AppendLine($"		set {{ this.SetValue({this.ValueName}Property, value); }}");
			cmd.AppendLine("	}");
			cmd.AppendLine("");
			cmd.AppendLine("	protected override void OnAttached()");
			cmd.AppendLine("	{");
			cmd.AppendLine("		base.OnAttached();");
			cmd.AppendLine($"		this.AssociatedObject.Click += On{this.ValueName}Notify;");
			cmd.AppendLine("	}");
			cmd.AppendLine("");
			cmd.AppendLine("	protected override void OnDetaching()");
			cmd.AppendLine("	{");
			cmd.AppendLine("		base.OnDetaching();");
			cmd.AppendLine($"		this.AssociatedObject.Click -= On{this.ValueName}Notify;");
			cmd.AppendLine("	}");
			cmd.AppendLine("");
			cmd.AppendLine($"	public void On{this.ValueName}Notify(object sender,EventArgs e)");
			cmd.AppendLine("	{");
			cmd.AppendLine("		// ここに処理を書く");
			cmd.AppendLine("	}");
			cmd.AppendLine("}");
			cmd.AppendLine("#endregion");
			return cmd.ToString();
		}
		#endregion
	}
}
