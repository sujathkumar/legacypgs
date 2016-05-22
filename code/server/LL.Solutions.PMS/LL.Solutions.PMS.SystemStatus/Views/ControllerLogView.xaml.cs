

using System.ComponentModel.Composition;
using System.Windows.Controls;
using LL.Solutions.PMS.SystemStatus.ViewModels;

namespace LL.Solutions.PMS.SystemStatus.Views
{
    [Export("ControllerLogView")]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    public partial class ControllerLogView : UserControl
    {
        public ControllerLogView()
        {
            InitializeComponent();
        }

        [Import]
        public ControllerLogViewModel ViewModel
        {
            set
            {
                this.DataContext = value;
            }
        }

        private void UserControl_Loaded(object sender, System.Windows.RoutedEventArgs e)
        {
            txtTitle.Text = "Log Message for " + ((ControllerLogViewModel)DataContext).Status.Name + ":";
            txtLog.Text = ((ControllerLogViewModel)DataContext).Status.Message;
        }
    }
}
