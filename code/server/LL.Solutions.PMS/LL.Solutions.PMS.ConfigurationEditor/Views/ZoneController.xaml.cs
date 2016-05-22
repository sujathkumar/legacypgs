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

namespace LL.Solutions.PMS.ConfigurationEditor.Views
{
    /// <summary>
    /// Interaction logic for ZoneController.xaml
    /// </summary>
    public partial class ZoneController : UserControl
    {
        #region Properties
        public string ZoneSpaces
        {
            get
            {
                return txtZoneSpaces.Text;
            }
            set
            {
                txtZoneSpaces.Text = value;
            }
        }

        public string ZoneEntry
        {
            get
            {
                return txtZoneEntry.Text;
            }
            set
            {
                txtZoneEntry.Text = value;
            }
        }

        public string ZoneExit
        {
            get
            {
                return txtZoneExit.Text;
            }
            set
            {
                txtZoneExit.Text = value;
            }
        }

        public string ZoneEntryDetector
        {
            get
            {
                return txtZoneEntryDetector.Text;
            }
            set
            {
                txtZoneEntryDetector.Text = value;
            }
        }

        public string ZoneExitDetector
        {
            get
            {
                return txtZoneExitDetector.Text;
            }
            set
            {
                txtZoneExitDetector.Text = value;
            }
        }
        #endregion

        #region Constructor
        public ZoneController()
        {
            InitializeComponent();
        } 
        #endregion
    }
}
