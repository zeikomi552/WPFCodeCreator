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
        public MainWindowViewModel(IRegionManager regionManager)
        {
            regionManager.RegisterViewWithRegion("PropertyRegion", typeof(ucPropertyV));
            regionManager.RegisterViewWithRegion("DependensyPropertyRegion", typeof(ucDependencyPropertyV));
            regionManager.RegisterViewWithRegion("ConverterRegion", typeof(ucConverterV));
            regionManager.RegisterViewWithRegion("ActionRegion", typeof(ucActionV));
            regionManager.RegisterViewWithRegion("BehaviorRegion", typeof(ucBehaviorV));
        }

    }
}
