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
    /// Interaction logic for ZoneView.xaml
    /// </summary>
    public partial class ZoneView : UserControl
    {
        public string ZoneName
        {
            get
            {
                return txtZoneName.Text;
            }
            set
            {
                txtZoneName.Text = value;
            }
        }

        public string TotalSlot
        {
            get
            {
                return txtZoneTotal.Text;
            }
            set
            {
                txtZoneTotal.Text = value;
            }
        }

        public string AvailableSlot
        {
            get
            {
                return txtZoneAvailable.Text;
            }
            set
            {
                txtZoneAvailable.Text = value;
            }
        }

        public string OccupiedSlot
        {
            get
            {
                return txtZoneOccupied.Text;
            }
            set
            {
                txtZoneOccupied.Text = value;
            }
        }

        public string ProgressValue
        {
            get
            {
                return pbZone.Value.ToString();
            }
            set
            {
                pbZone.Value = Convert.ToDouble(value);
                txtPBZone.Text = value + "%";
            }
        }

        public ZoneView()
        {
            InitializeComponent();
        }
    }
}
