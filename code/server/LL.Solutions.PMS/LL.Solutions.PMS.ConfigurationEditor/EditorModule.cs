

using System.ComponentModel.Composition;
using Prism.Mef.Modularity;
using Prism.Modularity;
using Prism.Regions;
using LL.Solutions.PMS.ConfigurationEditor.Views;
using LL.Solutions.PMS.Infrastructure;

namespace LL.Solutions.PMS.ConfigurationEditor
{
    [ModuleExport(typeof(EditorModule))]
    public class EditorModule : IModule
    {
        [Import]
        public IRegionManager RegionManager;

        public void Initialize()
        {
            // todo: 11 - Pre-populating regions with items
            // Items may be placed in regions prior to navigating to them.  In this case, since we're registering
            // the type EditorNavigationItemView, it will be created and added to the region when the MainNavigationRegion 
            // is loaded.  Even though it is created when the control associated with the region becomes visible,
            // the view itself won't be visible until it's navigated to. 
            //
            // Anything placed in a region in this manner will not be added to the navigation journal.
            this.RegionManager.RegisterViewWithRegion(RegionNames.MainNavigationRegion, typeof(EditorNavigationItemView));
        }
    }
}
