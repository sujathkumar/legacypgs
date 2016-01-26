

using System.ComponentModel.Composition;
using System.Windows.Controls;
using LL.Solutions.PMS.ConfigurationEditor.ViewModels;

namespace LL.Solutions.PMS.ConfigurationEditor.Views
{
    [Export("EditorView")]
    public partial class EditorView : UserControl
    {
        public EditorView()
        {
            InitializeComponent();
        }

        [Import]
        public EditorViewModel ViewModel
        {
            set { this.DataContext = value; }
        }
    }
}
