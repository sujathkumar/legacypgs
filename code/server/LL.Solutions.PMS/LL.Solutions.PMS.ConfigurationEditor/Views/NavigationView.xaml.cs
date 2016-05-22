

using System;
using System.ComponentModel.Composition;
using System.Windows;
using System.Windows.Controls;
using Prism.Regions;
using LL.Solutions.PMS.Infrastructure;

namespace LL.Solutions.PMS.ConfigurationEditor.Views
{
    [Export]
    [ViewSortHint("02")]
    public partial class NavigationView : UserControl, IPartImportsSatisfiedNotification
    {
        private static Uri EditorViewUri = new Uri("/EditorView", UriKind.Relative);

        [Import]
        public IRegionManager regionManager;

        public NavigationView()
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
            this.NavigateToEditorRadioButton.IsChecked = (uri == EditorViewUri);
        }

        private void RequestToNavigate(object sender, RoutedEventArgs e)
        {
            this.regionManager.RequestNavigate(RegionNames.MainContentRegion, EditorViewUri);
        }
    }
}
