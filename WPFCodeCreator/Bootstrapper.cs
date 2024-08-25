using DryIoc;
using Prism.Container.DryIoc;
using Prism.DryIoc;
using Prism.Ioc;
using Prism.Modularity;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using WPFCodeCreator.Models;
using WPFCodeCreator.Models.Interface;
using WPFCodeCreator.ViewModels;
using WPFCodeCreator.Views;
using WPFCodeCreator.Views.UserControls;

namespace WPFCodeCreator
{
    public class Bootstrapper : PrismBootstrapper
    {
        protected override DependencyObject CreateShell()
        {
            return Container.Resolve<MainWindow>();
        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            // オプションの設定などDryIocコンテナ独自の機能を使いたい場合
            var container = containerRegistry.GetContainer();

            // シングルトンクラスとして登録したい時
            containerRegistry.Register<IPropetyItemCollectionM, PropetyItemCollectionM>();
        }

        protected override void ConfigureViewModelLocator()
        {
            base.ConfigureViewModelLocator();

            // generic type
            ViewModelLocationProvider.Register<ucProperty, ucPropertyViewModel>();
            ViewModelLocationProvider.Register<ucDependencyProperty, ucDependencyPropertyViewModel>();
            ViewModelLocationProvider.Register<ucConverter, ucConverterViewModel>();
            ViewModelLocationProvider.Register<ucBehavior, ucBehaviorViewModel>();
            ViewModelLocationProvider.Register<ucAction, ucActionViewModel>();
        }

        protected override void ConfigureModuleCatalog(IModuleCatalog moduleCatalog)
        {
            
        }
    }
}
