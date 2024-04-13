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
							var comment = match.Value.Replace("<summary>", "").Replace("</summary>", "").Replace("\r\n", "").Replace("///", "").Replace(" ", "").Replace("\t","");
							var type = field.Type.ToString();
							var value = field.Identifier.Text;
                            this.Parameters.PropertyItems.Items.Add(new PropertyM() { IsVisible = true, TypeName = type, ValueName = value, Description = comment });
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
