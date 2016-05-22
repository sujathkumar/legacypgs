using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
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
using System.Xml.Linq;

namespace LL.Solutions.PMS.ConfigurationEditor.Views
{
    /// <summary>
    /// Interaction logic for LevelController.xaml
    /// </summary>
    public partial class LevelController : UserControl
    {
        #region Members
        Type _type = null;
        Assembly _assembly = null;
        List<UserControl> _zoneControllerList = new List<UserControl>();
        #endregion

        #region Properties
        public List<UserControl> ZoneControllerList
        {
            get
            {
                return _zoneControllerList;
            }
            set
            {
                _zoneControllerList = value;
            }
        }

        public string LevelControllerNumber
        {
            get
            {
                return txtLevelControllerNumber.Text;
            }
            set
            {
                txtLevelControllerNumber.Text = value;
            }
        }

        public string LevelControllerIP
        {
            get
            {
                return txtLevelControllerIP.Text;
            }
            set
            {
                txtLevelControllerIP.Text = value;
            }
        }

        public string LevelSpaces
        {
            get
            {
                return txtLevelSpaces.Text;
            }
            set
            {
                txtLevelSpaces.Text = value;
            }
        }

        public string TotalZones
        {
            get
            {
                return txtTotalZones.Text;
            }
            set
            {
                txtTotalZones.Text = value;
            }
        }

        public string LevelDetectors
        {
            get
            {
                return txtLevelDetectors.Text;
            }
            set
            {
                txtLevelDetectors.Text = value;
            }
        }
        #endregion

        #region Constructor
        public LevelController()
        {
            InitializeComponent();
        }
        #endregion

        #region Methods
        /// <summary>
        /// InitializeZoneController
        /// </summary>
        private void InitializeZoneController()
        {
            Constants.log.Info("Entering LevelController InitializeZoneController Method!");
            _type = this.GetType();
            _assembly = _type.Assembly;
            Constants.log.Info("Exiting LevelController InitializeZoneController Method!");
        }

        /// <summary>
        /// AddZoneController
        /// </summary>
        /// <param name="zone"></param>
        public void AddZoneController(XElement zone)
        {
            try
            {
                Constants.log.Info("Entering LevelController AddZoneController Method!");
                if (_type == null && _assembly == null)
                {
                    Constants.log.Info("Calling InitializeZoneController Method!");
                    InitializeZoneController();
                }

                UserControl zoneController = (UserControl)_assembly.CreateInstance(string.Format("{0}.ZoneController", _type.Namespace));
                zoneController.Name = "zoneController" + (_zoneControllerList.Count + 1).ToString();

                Constants.log.Info("Checking if zone is configured!");
                if (zone != null)
                {
                    Constants.log.Info("Zone data available.");
                    foreach (var zoneElement in zone.Elements())
                    {
                        if (zoneElement.FirstAttribute != null)
                        {
                            if (zoneElement.FirstAttribute.Name.ToString().Contains("spaces"))
                            {
                                ((ZoneController)zoneController).ZoneSpaces = zoneElement.FirstAttribute.Value;
                            }
                            else if (zoneElement.FirstAttribute.Name.ToString().Contains("entry") && !zoneElement.FirstAttribute.Name.ToString().Contains("detector"))
                            {
                                ((ZoneController)zoneController).ZoneEntry = zoneElement.FirstAttribute.Value;
                            }
                            else if (zoneElement.FirstAttribute.Name.ToString().Contains("exit") && !zoneElement.FirstAttribute.Name.ToString().Contains("detector"))
                            {
                                ((ZoneController)zoneController).ZoneExit = zoneElement.FirstAttribute.Value;
                            }
                            else if (zoneElement.FirstAttribute.Name.ToString().Contains("entry") && zoneElement.FirstAttribute.Name.ToString().Contains("detector"))
                            {
                                ((ZoneController)zoneController).ZoneEntryDetector = zoneElement.FirstAttribute.Value;
                            }
                            else if (zoneElement.FirstAttribute.Name.ToString().Contains("exit") && zoneElement.FirstAttribute.Name.ToString().Contains("detector"))
                            {
                                ((ZoneController)zoneController).ZoneExitDetector = zoneElement.FirstAttribute.Value;
                            }
                        }
                    }
                }

                spZoneContoller.Children.Add(new Label { Content = "Zone " + (_zoneControllerList.Count + 1).ToString(), FontWeight = FontWeights.Bold });
                spZoneContoller.Children.Add(zoneController);
                _zoneControllerList.Add(zoneController);
                Constants.log.Info("Exiting LevelController AddZoneController Method!");
            }
            catch (Exception ex)
            {
                Constants.log.Error(ex.Message);
            }
        }

        /// <summary>
        /// AddZone
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AddZone(object sender, RoutedEventArgs e)
        {
            try
            {
                Constants.log.Info("Entering LevelController AddZone Method!");

                if (!string.IsNullOrEmpty(txtTotalZones.Text))
                {
                    int totalZones = Int32.Parse(txtTotalZones.Text);

                    if (totalZones > _zoneControllerList.Count)
                    {
                        AddZoneController(null);

                        if (_zoneControllerList.Count == totalZones)
                        {
                            btnZone.Foreground = Brushes.White;
                        }
                    }
                }

                Constants.log.Info("Exiting LevelController AddZone Method!");
            }
            catch(Exception ex)
            {
                Constants.log.Error(ex.Message);
            }
        }
        #endregion
    }
}
