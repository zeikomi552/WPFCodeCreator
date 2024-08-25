using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.Win32;
using MVVMCore.BaseClass;
using MVVMCore.Common.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using WPFCodeCreator.Models.Interface;
using System.IO;

namespace WPFCodeCreator.Models
{
    public class PropetyItemCollectionM : ModelBase, IPropetyItemCollectionM
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
				code.AppendLine("	public event PropertyChangedEventHandler? PropertyChanged;");
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

        #region コードの更新
        /// <summary>
        /// コードの更新
        /// </summary>
        public void Refresh()
		{
			NotifyPropertyChanged("SourceCode");
		}
        #endregion

        #region 保存処理
        /// <summary>
        /// 保存処理
        /// </summary>
        public void FileSave()
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
            catch (Exception e)
            {
                ShowMessage.ShowErrorOK(e.Message, "Error");
            }
        }
        #endregion


        #region 読込処理
        /// <summary>
        /// 読込処理
        /// </summary>
        public void FileLoad()
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

        #region 読込処理
        /// <summary>
        /// 読込処理
        /// </summary>
        public void LoadCS()
        {
            try
            {
                // ダイアログのインスタンスを生成
                var dialog = new OpenFileDialog();

                // ファイルの種類を設定
                dialog.Filter = "C#ソースコードファイル(*.cs)|*.cs";
                dialog.Multiselect = true;

                // ダイアログを表示する
                if (dialog.ShowDialog() == true)
                {
                    foreach (var filename in dialog.FileNames)
                    {
                        var text = File.ReadAllText(filename);
                        var tree = CSharpSyntaxTree.ParseText(text);
                        var root = tree.GetCompilationUnitRoot();
                        var fields = root.DescendantNodes().OfType<PropertyDeclarationSyntax>();


                        foreach (var field in fields)
                        {
                            var trivia = field.GetLeadingTrivia().ToString();

                            // コメント抜き出し
                            var match = Regex.Match(trivia, @"<summary>[\s\S]*?</summary>");
                            // 不要な文字列削除
                            var comment = match.Value.Replace("<summary>", "").Replace("</summary>", "").Replace("\r\n", "").Replace("///", "").Replace(" ", "").Replace("\t", "");
                            var type = field.Type.ToString();
                            var value = field.Identifier.Text;
                            this.PropertyItems.Items.Add(new PropertyM() { IsVisible = true, TypeName = type, ValueName = value, Description = comment });
                        }
                    }
                }
            }
            catch (Exception e)
            {
                ShowMessage.ShowErrorOK(e.Message, "Error");
            }
        }
        #endregion
    }
}
