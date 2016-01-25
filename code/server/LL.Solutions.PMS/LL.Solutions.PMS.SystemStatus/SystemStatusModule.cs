

using System.ComponentModel.Composition;
using Prism.Mef.Modularity;
using Prism.Modularity;
using Prism.Regions;
using LL.Solutions.PMS.SystemStatus.Views;
using LL.Solutions.PMS.Infrastructure;

namespace LL.Solutions.PMS.SystemStatus
{
    [ModuleExport(typeof(SystemStatusModule))]
    public class SystemStatusModule : IModule
    {
        [Import]
        public IRegionManager regionManager;

        public void Initialize()
        {
            this.regionManager.RegisterViewWithRegion(RegionNames.MainNavigationRegion, typeof(SystemStatusNavigationItemView));
        }
    }
}
