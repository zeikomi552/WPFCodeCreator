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

		#region [PropertyItems]プロパティ
		/// <summary>
		/// [PropertyItems]プロパティ用変数
		/// </summary>
		ModelList<PropertyM> _PropertyItems = new ModelList<PropertyM>();
		/// <summary>
		/// [PropertyItems]プロパティ
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

		#region コードの更新
		/// <summary>
		/// コードの更新
		/// </summary>
		public void RefleshCode()
        {
            try
            {
				StringBuilder code = new StringBuilder();

				foreach (var tmp in this.PropertyItems)
				{
					if (tmp.IsVisible)
					{
						code.AppendLine(tmp.PropertyCode);
					}
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
