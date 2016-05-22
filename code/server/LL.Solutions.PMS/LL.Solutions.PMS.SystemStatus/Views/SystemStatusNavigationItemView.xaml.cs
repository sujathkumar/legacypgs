

using System;
using System.ComponentModel.Composition;
using System.Windows;
using System.Windows.Controls;
using Prism.Regions;
using LL.Solutions.PMS.Infrastructure;

namespace LL.Solutions.PMS.SystemStatus.Views
{
    [Export]
    [ViewSortHint("01")]
    public partial class SystemStatusNavigationItemView : UserControl, IPartImportsSatisfiedNotification
    {
        private static Uri SystemStatussViewUri = new Uri("/SystemView", UriKind.Relative);

        [Import]
        public IRegionManager regionManager;

        public SystemStatusNavigationItemView()
        {
            InitializeComponent();
        }

        void IPartImportsSatisfiedNotification.OnImportsSatisfied()
        {
            IRegion mainContentRegion = this.regionManager.Regions[RegionNames.MainContentRegion];
            if (mainContentRegion != null && mainContentRegion.NavigationService != null)
            {
                mainContentRegion.NavigationService.Navigated += this.MainContentRegion_Navigated;
            }
        }

        public void MainContentRegion_Navigated(object sender, RegionNavigationEventArgs e)
        {
            this.UpdateNavigationButtonState(e.Uri);
        }

        private void UpdateNavigationButtonState(Uri uri)
        {
            this.NavigateToSystemStatusRadioButton.IsChecked = (uri == SystemStatussViewUri);
        }

        private void NavigateToSystemStatusRadioButton_Click(object sender, RoutedEventArgs e)
        {
            this.regionManager.RequestNavigate(RegionNames.MainContentRegion, SystemStatussViewUri);
        }
    }
}
