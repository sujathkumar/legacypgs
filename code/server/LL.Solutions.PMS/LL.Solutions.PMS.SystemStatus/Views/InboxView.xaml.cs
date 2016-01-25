

using System.ComponentModel.Composition;
using System.Windows.Controls;
using LL.Solutions.PMS.SystemStatus.ViewModels;

namespace LL.Solutions.PMS.SystemStatus.Views
{
    [Export("InboxView")]
    public partial class InboxView : UserControl
    {
        public InboxView()
        {
            InitializeComponent();
        }

        [Import]
        public InboxViewModel ViewModel
        {
            get { return this.DataContext as InboxViewModel; }
            set { this.DataContext = value; }
        }
    }
}
