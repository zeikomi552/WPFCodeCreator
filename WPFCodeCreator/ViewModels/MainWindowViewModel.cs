using Prism.Mvvm;
using Prism.Navigation.Regions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WPFCodeCreator.Views.UserControls;

namespace WPFCodeCreator.ViewModels
{
    public class MainWindowViewModel : BindableBase
    {
        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="regionManager">RegionManager</param>
        public MainWindowViewModel(IRegionManager regionManager)
        {
            regionManager.RegisterViewWithRegion("PropertyRegion", typeof(ucProperty));
            regionManager.RegisterViewWithRegion("DependensyPropertyRegion", typeof(ucDependencyProperty));
            regionManager.RegisterViewWithRegion("ConverterRegion", typeof(ucConverter));
            regionManager.RegisterViewWithRegion("ActionRegion", typeof(ucAction));
            regionManager.RegisterViewWithRegion("BehaviorRegion", typeof(ucBehavior));
        }

    }
}
