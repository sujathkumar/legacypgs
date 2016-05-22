

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
        private static Uri SystemViewUri = new Uri("/SystemView", UriKind.Relative);
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
                            SystemViewUri);
                    }
                };
        }
    }
}
