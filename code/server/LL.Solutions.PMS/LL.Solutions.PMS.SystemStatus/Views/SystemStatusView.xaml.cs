

using System.ComponentModel.Composition;
using System.Windows.Controls;
using LL.Solutions.PMS.SystemStatus.ViewModels;

namespace LL.Solutions.PMS.SystemStatus.Views
{
    [Export("SystemStatusView")]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    public partial class SystemStatusView : UserControl
    {
        public SystemStatusView()
        {
            InitializeComponent();
        }

        [Import]
        public SystemStatusViewModel ViewModel
        {
            set { this.DataContext = value; }
        }
    }
}
