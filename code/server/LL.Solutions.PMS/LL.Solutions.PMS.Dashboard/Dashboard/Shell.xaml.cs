

using System;
using System.ComponentModel.Composition;
using System.Windows.Controls;
using Prism.Modularity;
using Prism.Regions;
using LL.Solutions.PMS.Infrastructure;
using System.Windows;

namespace LL.Solutions.PMS
{
    [Export]
    public partial class Shell : Window, IPartImportsSatisfiedNotification
    {
        private const string SystemStatusModuleName = "SystemStatusModule";
                
        public Shell()
        {
            InitializeComponent();
        }

        [Import(AllowRecomposition = false)]
        public IModuleManager ModuleManager;

        [Import(AllowRecomposition = false)]
        public IRegionManager RegionManager;

        public void OnImportsSatisfied()
        {
            this.ModuleManager.LoadModuleCompleted +=
                (s, e) =>
                {
                    // todo: 01 - Navigation on when modules are loaded.
                    // When using region navigation, be sure to use it consistently
                    // to ensure you get proper journal behavior.  If we mixed
                    // usage of adding views directly to regions, such as through
                    // RegionManager.AddToRegion, and then use RegionManager.RequestNavigate,
                    // we may not be able to navigate back correctly.
                    // 
                    // Here, we wait until the module we want to start with is
                    // loaded and then navigate to the view we want to display
                    // initially.
                    //     
                    if (e.ModuleInfo.ModuleName == SystemStatusModuleName)
                    {
                        this.RegionManager.RequestNavigate(
                            RegionNames.MainContentRegion,
                            Property.SystemViewUri);
                    }
                };
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            lblUserName.Content = String.Format("{0} {1}!", lblUserName.Content, Property.UserName);
        }

        private void menuComponents_Click(object sender, RoutedEventArgs e)
        {
            MenuItem menu = (MenuItem)sender;
            switch (menu.Name)
            {
                case "ControllerStatus":
                    this.RegionManager.RequestNavigate(RegionNames.MainContentRegion, Property.SystemViewUri);
                    break;
                case "SystemConfiguration":
                    this.RegionManager.RequestNavigate(RegionNames.MainContentRegion, Property.EditorViewUri);
                    break;
                case "Exit":
                    this.Close();
                    break;
            }
        }
    }
}
