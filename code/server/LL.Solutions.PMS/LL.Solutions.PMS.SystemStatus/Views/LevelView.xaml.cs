using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace LL.Solutions.PMS.SystemStatus.Views
{
    /// <summary>
    /// Interaction logic for LevelView.xaml
    /// </summary>
    public partial class LevelView : UserControl
    {
        public string LevelName
        {
            get
            {
                return txtLevelName.Text;
            }
            set
            {
                txtLevelName.Text = value;
            }
        }

        public Brush LevelBackgroundColor
        {
            get
            {
                return txtLevelBackgroundColor.Background;
            }
            set
            {
                txtLevelBackgroundColor.Background = value;
            }
        }

        public string TotalSlot
        {
            get
            {
                return txtLevelTotal.Text;
            }
            set
            {
                txtLevelTotal.Text = value;
            }
        }

        public string AvailableSlot
        {
            get
            {
                return txtLevelAvailable.Text;
            }
            set
            {
                txtLevelAvailable.Text = value;
            }
        }

        public string OccupiedSlot
        {
            get
            {
                return txtLevelOccupied.Text;
            }
            set
            {
                txtLevelOccupied.Text = value;
            }
        }

        public LevelView()
        {
            InitializeComponent();
        }
    }
}
