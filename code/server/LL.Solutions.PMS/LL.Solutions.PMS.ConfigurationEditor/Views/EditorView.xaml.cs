using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Reflection;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Threading;
using System.Xml.Linq;
using LL.Solutions.PMS.ConfigurationEditor.ViewModels;

namespace LL.Solutions.PMS.ConfigurationEditor.Views
{
    [Export("EditorView")]
    public partial class EditorView : UserControl
    {
        #region Members
        Type _type = null;
        Assembly _assembly = null;
        List<UserControl> _levelControllerList = new List<UserControl>();
        XElement _configdata = null;
        #endregion

        #region Properties
        public List<UserControl> LevelControllerList
        {
            get
            {
                return _levelControllerList;
            }
            set
            {
                _levelControllerList = value;
            }
        }

        [Import]
        public EditorViewModel ViewModel
        {
            set { this.DataContext = value; }
        }
        #endregion

        #region Constructor
        public EditorView()
        {
            InitializeComponent();
            InitializeLevelController();
            LoadConfigurationInfo();
        }
        #endregion

        #region Methods
        /// <summary>
        /// LoadConfigurationInfo
        /// </summary>
        private void LoadConfigurationInfo()
        {
            try
            {
                Constants.log.Info("Entering EditorView LoadConfigurationInfo Method!");

                Constants.log.Info("Loading config data...");
                _configdata = XElement.Load("config.xml");

                if (_configdata != null)
                {
                    IEnumerable<XElement> mConfig = _configdata.Descendants("Main_configuration");
                    foreach (var mainElement in mConfig.Elements())
                    {
                        if (mainElement.FirstAttribute.Name == "server_ip")
                        {
                            txtServerIP.Text = mainElement.FirstAttribute.Value;
                        }
                        else if (mainElement.FirstAttribute.Name == "port")
                        {
                            txtPortNumber.Text = mainElement.FirstAttribute.Value;
                        }
                        else if (mainElement.FirstAttribute.Name == "main_controller_ip")
                        {
                            txtControllerIP.Text = mainElement.FirstAttribute.Value;
                        }
                        else if (mainElement.FirstAttribute.Name == "total_spaces")
                        {
                            txtTotalSpace.Text = mainElement.FirstAttribute.Value;
                        }
                        else if (mainElement.FirstAttribute.Name == "total_levels")
                        {
                            txtTotalLevels.Text = mainElement.FirstAttribute.Value;

                            if (!string.IsNullOrEmpty(mainElement.FirstAttribute.Value))
                            {
                                IEnumerable<XElement> levelConfig = _configdata.Descendants("Level_configuration");
                                Constants.log.Info("Adding Levels...");
                                foreach (var levelElement in levelConfig.Elements())
                                {
                                    AddLevelController(levelElement);
                                }
                            }
                        }
                    }
                }

                Constants.log.Info("Exiting EditorView LoadConfigurationInfo Method!");
            }
            catch (Exception ex)
            {
                Constants.log.Error(ex.Message);
            }
        }

        /// <summary>
        /// InitializeLevelController
        /// </summary>
        private void InitializeLevelController()
        {
            Constants.log.Info("Entering EditorView InitializeLevelController Method!");
            _type = this.GetType();
            _assembly = _type.Assembly;
            Constants.log.Info("Exiting EditorView InitializeLevelController Method!");
        }

        /// <summary>
        /// AddLevelController
        /// </summary>
        /// <param name="level"></param>
        private void AddLevelController(XElement level)
        {
            try
            {
                Constants.log.Info("Entering EditorView AddLevelController Method!");
                UserControl levelController = (UserControl)_assembly.CreateInstance(string.Format("{0}.LevelController", _type.Namespace));
                levelController.Name = "levelController" + (_levelControllerList.Count + 1).ToString();

                Constants.log.Info("Checking if level is configured!");
                if (level != null)
                {
                    Constants.log.Info("Zone data available.");
                    foreach (var levelElement in level.Elements())
                    {
                        if (levelElement.FirstAttribute != null)
                        {
                            if (levelElement.FirstAttribute.Name.ToString().Contains("level_ontroller_no"))
                            {
                                ((LevelController)levelController).LevelControllerNumber = levelElement.FirstAttribute.Value;
                            }
                            else if (levelElement.FirstAttribute.Name.ToString().Contains("level_controller_ip"))
                            {
                                ((LevelController)levelController).LevelControllerIP = levelElement.FirstAttribute.Value;
                            }
                            else if (levelElement.FirstAttribute.Name.ToString().Contains("spaces"))
                            {
                                ((LevelController)levelController).LevelSpaces = levelElement.FirstAttribute.Value;
                            }
                            else if (levelElement.FirstAttribute.Name.ToString().Contains("zones"))
                            {
                                ((LevelController)levelController).TotalZones = levelElement.FirstAttribute.Value;

                                if (!string.IsNullOrEmpty(levelElement.FirstAttribute.Value))
                                {
                                    IEnumerable<XElement> zoneConfig = level.Descendants("Zone_configuration");
                                    foreach (var zoneElement in zoneConfig.Elements())
                                    {
                                        ((LevelController)levelController).AddZoneController(zoneElement);
                                    }
                                }
                            }
                            else if (levelElement.FirstAttribute.Name.ToString().Contains("detectors"))
                            {
                                ((LevelController)levelController).LevelDetectors = levelElement.FirstAttribute.Value;
                            }
                        }
                    }
                }

                spLevelContoller.Children.Add(new Label { Content = "Level " + (_levelControllerList.Count + 1).ToString(), FontWeight = FontWeights.Bold });
                spLevelContoller.Children.Add(levelController);
                _levelControllerList.Add(levelController);
                Constants.log.Info("Exiting EditorView AddLevelController Method!");
            }
            catch (Exception ex)
            {
                Constants.log.Error(ex.Message);
            }
        }

        /// <summary>
        /// AddLevel
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AddLevel(object sender, RoutedEventArgs e)
        {
            try
            {
                Constants.log.Info("Entering EditorView AddLevel Method!");

                if (!string.IsNullOrEmpty(txtTotalLevels.Text))
                {
                    int totalLevels = Int32.Parse(txtTotalLevels.Text);

                    if (totalLevels > _levelControllerList.Count)
                    {
                        AddLevelController(null);

                        if (_levelControllerList.Count == totalLevels)
                        {
                            var bc = new BrushConverter();
                            btnLevel.Foreground = (Brush)bc.ConvertFrom("#616261");
                        }
                    }
                }

                Constants.log.Info("Exiting EditorView AddLevel Method!");
            }
            catch (Exception ex)
            {
                Constants.log.Error(ex.Message);
            }
        }

        /// <summary>
        /// EditMainConfiguration     
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void EditMainConfiguration(object sender, RoutedEventArgs e)
        {
            gridMain.IsEnabled = true;
            spLevelContoller.IsEnabled = true;
            btnLevel.IsEnabled = true;
        }

        /// <summary>
        /// SaveMainConfiguration       
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SaveMainConfiguration(object sender, RoutedEventArgs e)
        {
            try
            {
                Constants.log.Info("Entering EditorView SaveMainConfiguration Method!");

                Constants.log.Info("Calling GenerateConfigurationInfo!");
                GenerateConfigurationInfo();
                Application.Current.Dispatcher.BeginInvoke(DispatcherPriority.Background, new Action
                    (
                        () => UpdateStatus(100, "Saved successfully", Environment.CurrentDirectory + "\\config.xml")
                    ));

                Application.Current.Dispatcher.BeginInvoke(DispatcherPriority.Background, new Action
                    (
                        () => UpdateStatus(0, "", "")
                    ));

                Constants.log.Info("Exiting EditorView SaveMainConfiguration Method!");
            }
            catch (Exception ex)
            {
                Constants.log.Error(ex.Message);
            }
        }

        /// <summary>
        /// UpdateStatus
        /// </summary>
        private void UpdateStatus(int val, string method, string action)
        {
            System.Threading.Thread.Sleep(1000);
            lblMethod.Text = method;
            lblAction.Text = action;
            pbMain.Value = val;
        }

        /// <summary>
        /// GenerateConfigurationInfo
        /// </summary>
        private void GenerateConfigurationInfo()
        {
            try
            {
                Constants.log.Info("Entering EditorView GenerateConfigurationInfo Method!");
                // Create a root node
                XElement configuration = new XElement("Configuration");

                // Add child nodes
                XElement mainConfiguration = new XElement("Main_configuration");

                XElement serverIP = new XElement("Server_ip");
                XAttribute attServerIP = new XAttribute("server_ip", txtServerIP.Text);
                serverIP.Add(attServerIP);

                XElement portNo = new XElement("Port_no");
                XAttribute attPortNo = new XAttribute("port", txtPortNumber.Text);
                portNo.Add(attPortNo);

                XElement mainControllerIP = new XElement("Main_controller_ip");
                XAttribute attMainControllerIP = new XAttribute("main_controller_ip", txtControllerIP.Text);
                mainControllerIP.Add(attMainControllerIP);

                XElement totalSpaces = new XElement("Total_spaces");
                XAttribute attTotalSpaces = new XAttribute("total_spaces", txtTotalSpace.Text);
                totalSpaces.Add(attTotalSpaces);

                XElement totalLevels = new XElement("Total_levels");
                XAttribute attTotalLevels = new XAttribute("total_levels", txtTotalLevels.Text);
                totalLevels.Add(attTotalLevels);

                mainConfiguration.Add(serverIP);
                mainConfiguration.Add(portNo);
                mainConfiguration.Add(mainControllerIP);
                mainConfiguration.Add(totalSpaces);
                mainConfiguration.Add(totalLevels);

                XElement levelConfiguration = new XElement("Level_configuration");

                for (int i = 0; i < _levelControllerList.Count; i++)
                {
                    XElement lConfiguration = new XElement("Level" + (i + 1).ToString() + "_configuration");

                    XElement controllerNo = new XElement("Controller_no");
                    XAttribute attcontrollerNo = new XAttribute("L" + (i + 1).ToString() + "-level_ontroller_no", ((LevelController)_levelControllerList[i]).LevelControllerNumber);
                    controllerNo.Add(attcontrollerNo);

                    XElement controllerIP = new XElement("Controller_ip");
                    XAttribute attcontrollerIP = new XAttribute("L" + (i + 1).ToString() + "-level_controller_ip", ((LevelController)_levelControllerList[i]).LevelControllerIP);
                    controllerIP.Add(attcontrollerIP);

                    XElement lSpaces = new XElement("L" + (i + 1).ToString() + "_spaces");
                    XAttribute attlSpaces = new XAttribute("L" + (i + 1).ToString() + "-spaces", ((LevelController)_levelControllerList[i]).LevelSpaces);
                    lSpaces.Add(attlSpaces);

                    XElement lZones = new XElement("L" + (i + 1).ToString() + "_zones");
                    XAttribute attlZones = new XAttribute("L" + (i + 1).ToString() + "-zones", ((LevelController)_levelControllerList[i]).TotalZones);
                    lZones.Add(attlZones);

                    XElement lDetectors = new XElement("L" + (i + 1).ToString() + "_detectors");
                    XAttribute attlDetectors = new XAttribute("L" + (i + 1).ToString() + "-detectors", ((LevelController)_levelControllerList[i]).LevelDetectors);
                    lDetectors.Add(attlDetectors);

                    XElement zoneConfiguration = new XElement("Zone_configuration");

                    List<UserControl> _zcList = ((LevelController)_levelControllerList[i]).ZoneControllerList;
                    for (int j = 0; j < _zcList.Count; j++)
                    {
                        XElement zConfiguration = new XElement("Zone" + (j + 1).ToString() + "_configuration");

                        XElement zoneSpaces = new XElement("l" + (i + 1).ToString() + "-Z" + (j + 1).ToString() + "_spaces");
                        XAttribute attZoneSpaces = new XAttribute("L" + (i + 1).ToString() + "-Z" + (j + 1).ToString() + "_spaces", ((ZoneController)_zcList[j]).ZoneSpaces);
                        zoneSpaces.Add(attZoneSpaces);

                        XElement zoneEntry = new XElement("L" + (i + 1).ToString() + "-Z" + (j + 1).ToString() + "_entry");
                        XAttribute attZoneEntry = new XAttribute("L" + (i + 1).ToString() + "-Z" + (j + 1).ToString() + "_entry", ((ZoneController)_zcList[j]).ZoneEntry);
                        zoneEntry.Add(attZoneEntry);

                        XElement zoneExit = new XElement("L" + (i + 1).ToString() + "-Z" + (j + 1).ToString() + "_exit");
                        XAttribute attZoneExit = new XAttribute("L" + (i + 1).ToString() + "-Z" + (j + 1).ToString() + "_exit", ((ZoneController)_zcList[j]).ZoneExit);
                        zoneExit.Add(attZoneExit);

                        XElement zoneEntryDetector = new XElement("L" + (i + 1).ToString() + "-Z" + (j + 1).ToString() + "_entry" + (j + 1).ToString() + "_detector");
                        XAttribute attZoneEntryDetector = new XAttribute("L" + (i + 1).ToString() + "-Z" + (j + 1).ToString() + "_entry" + (j + 1).ToString() + "_detector", ((ZoneController)_zcList[j]).ZoneEntryDetector);
                        zoneEntryDetector.Add(attZoneEntryDetector);

                        XElement zoneExitDetector = new XElement("L" + (i + 1).ToString() + "-Z" + (j + 1).ToString() + "_exit" + (j + 1).ToString() + "_detector");
                        XAttribute attZoneExitDetector = new XAttribute("L" + (i + 1).ToString() + "-Z" + (j + 1).ToString() + "_exit" + (j + 1).ToString() + "_detector", ((ZoneController)_zcList[j]).ZoneExitDetector);
                        zoneExitDetector.Add(attZoneExitDetector);

                        zConfiguration.Add(zoneSpaces);
                        zConfiguration.Add(zoneEntry);
                        zConfiguration.Add(zoneExit);
                        zConfiguration.Add(zoneEntryDetector);
                        zConfiguration.Add(zoneExitDetector);

                        zoneConfiguration.Add(zConfiguration);
                    }

                    lConfiguration.Add(controllerNo);
                    lConfiguration.Add(controllerIP);
                    lConfiguration.Add(lSpaces);
                    lConfiguration.Add(lZones);
                    lConfiguration.Add(lDetectors);
                    lConfiguration.Add(zoneConfiguration);

                    levelConfiguration.Add(lConfiguration);
                }

                configuration.Add(mainConfiguration);
                configuration.Add(levelConfiguration);
                configuration.Save("config.xml");

                Constants.log.Info("Exiting EditorView GenerateConfigurationInfo Method!");
            }
            catch (Exception ex)
            {
                Constants.log.Error(ex.Message);
            }
        }
    }
    #endregion
}
