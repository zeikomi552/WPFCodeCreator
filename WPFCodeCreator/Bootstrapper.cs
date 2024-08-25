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
            //container.Register<Items.Text>(/*オプション設定*/);

            // シングルトンクラスとして登録したい時
            containerRegistry.RegisterSingleton<PropetyItemCollectionM>();

            //// 同じIFとして登録したい時
            //// Items.Picture, Items.RichTextクラスはItems.IItemインターフェイスを継承している
            //container.Register<Items.IItem, Items.Picture>(ifAlreadyRegistered: IfAlreadyRegistered.AppendNotKeyed);
            //container.Register<Items.IItem, Items.RichText>(ifAlreadyRegistered: IfAlreadyRegistered.AppendNotKeyed);

            //// 同じインスタンスでkeyを登録したいとき
            //container.Register<Items.Text>(serviceKey: "1");
            //container.Register<Items.Text>(serviceKey: "2");

            //// containerRegistryからRegisterを実行するとDryIocコンテナ独自の機能は使えないため
            //// デフォルトコンストラクタのみ実装されているクラスのみしか使用することができない
            //// Items.Textクラスのコンストラクタはデフォルトコンストラクタのみ
            //containerRegistry.Register<Items.Text>();
        }

        protected override void ConfigureViewModelLocator()
        {
            base.ConfigureViewModelLocator();

            // type / type
            //ViewModelLocationProvider.Register(typeof(ucProperty).ToString(), typeof(ucPropertyViewModel));

            // type / factory
            //ViewModelLocationProvider.Register(typeof(ucProperty).ToString(), () => Container.Resolve<ucPropertyViewModel>());

            // generic factory
            //ViewModelLocationProvider.Register<ucProperty>(() => Container.Resolve<ucPropertyViewModel>());

            // generic type
            ViewModelLocationProvider.Register<ucProperty, ucPropertyViewModel>();
        }

        protected override void ConfigureModuleCatalog(IModuleCatalog moduleCatalog)
        {
            
        }
    }
}
