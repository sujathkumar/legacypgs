

using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Diagnostics;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Threading;
using System.Xml.Linq;
using LL.Solutions.PMS.Service;
using LL.Solutions.PMS.SystemStatus.Model;
using LL.Solutions.PMS.SystemStatus.ViewModels;

namespace LL.Solutions.PMS.SystemStatus.Views
{
    [Export("SystemView")]
    public partial class SystemView : UserControl
    {
        Type _type = null;
        Assembly _assembly = null;
        List<UserControl> _lvList = new List<UserControl>();
        List<UserControl> _zvList = new List<UserControl>();
        XElement _configdata = null;
        int totalSlot = 0;
        int availableSlot = 0;
        int occupiedSlot = 0;
        List<string> controllerList = new List<string>();
        Dictionary<string, int> zoneControllerList = new Dictionary<string, int>();

        public List<UserControl> LVList
        {
            get
            {
                return _zvList;
            }
            set
            {
                _zvList = value;
            }
        }

        public SystemView()
        {
            InitializeComponent();
            InitializeLevelController();
            LoadLevelStatus();
            Thread oThread = new Thread(new ThreadStart(ListenUDP));
            oThread.Start();
        }

        [Import]
        public SystemViewModel ViewModel
        {
            get { return this.DataContext as SystemViewModel; }
            set { this.DataContext = value; }
        }

        /// <summary>
        /// InitializeLevelController
        /// </summary>
        private void InitializeLevelController()
        {
            _type = this.GetType();
            _assembly = _type.Assembly;
        }

        /// <summary>
        /// LoadLevelStatus
        /// </summary>
        private void LoadLevelStatus()
        {
            try
            {
                _configdata = XElement.Load("config.xml");

                if (_configdata != null)
                {
                    IEnumerable<XElement> levelConfig = _configdata.Descendants("Level_configuration");
                    foreach (var levelElement in levelConfig.Elements())
                    {
                        AddLevelView(levelElement);
                    }
                }

                txtLvlAS.Text = totalSlot.ToString();
                txtLvlFS.Text = availableSlot.ToString();
                txtLvlBS.Text = occupiedSlot.ToString();
                pbLevel.Value = Convert.ToInt32(Convert.ToDouble(occupiedSlot) / Convert.ToDouble(totalSlot) * 100);
                txtPBLevel.Text = pbLevel.Value + "%";
            }
            catch (Exception ex)
            {

            }
        }

        /// <summary>
        /// AddLevelView
        /// </summary>
        public void AddLevelView(XElement level)
        {
            UserControl _lView = (UserControl)_assembly.CreateInstance(string.Format("{0}.LevelView", _type.Namespace));
            _lView.Name = "lView" + (_lvList.Count + 1).ToString();
            ((LevelView)_lView).LevelName = level.Name.ToString().Replace("_configuration", "").Replace("Level", "Controller-");

            if (level != null)
            {
                ((LevelView)_lView).LevelBackgroundColor = Brushes.Red;

                foreach (var levelElement in level.Elements())
                {
                    if (levelElement.FirstAttribute != null)
                    {
                        if (levelElement.FirstAttribute.Name.ToString().Contains("spaces"))
                        {
                            totalSlot += Convert.ToInt32(levelElement.FirstAttribute.Value);
                            availableSlot = totalSlot;
                            occupiedSlot = totalSlot - availableSlot;
                            ((LevelView)_lView).TotalSlot = levelElement.FirstAttribute.Value.ToString();
                            ((LevelView)_lView).AvailableSlot = levelElement.FirstAttribute.Value.ToString();
                            ((LevelView)_lView).OccupiedSlot = "0";
                        }
                    }
                }
            }

            spLevelController.Children.Add(_lView);
            _lvList.Add(_lView);
            controllerList.Add(level.Name.ToString().Replace("_configuration", " Alive").Replace("Level", "Controller-"));
        }

        /// <summary>
        /// AddZoneView
        /// </summary>
        public void AddZoneView(XElement level)
        {
            if (level != null)
            {
                IEnumerable<XElement> zoneConfig = level.Descendants("Zone_configuration");
                foreach (var zoneElement in zoneConfig.Elements())
                {
                    UserControl zView = (UserControl)_assembly.CreateInstance(string.Format("{0}.ZoneView", _type.Namespace));
                    zView.Name = "zView" + (_zvList.Count + 1).ToString();
                    ((ZoneView)zView).ZoneName = level.Name.ToString().Replace("_configuration", "") + "-" + zoneElement.Name.ToString().Replace("_configuration", "") + " Details";

                    foreach (var ze in zoneElement.Elements())
                    {
                        if (ze.FirstAttribute != null)
                        {
                            if (ze.FirstAttribute.Name.ToString().Contains("spaces"))
                            {
                                ((ZoneView)zView).TotalSlot = ze.FirstAttribute.Value.ToString();
                                ((ZoneView)zView).AvailableSlot = ze.FirstAttribute.Value.ToString();
                                ((ZoneView)zView).OccupiedSlot = "0";
                                ((ZoneView)zView).ProgressValue = Convert.ToInt32((0 / Convert.ToDouble(ze.FirstAttribute.Value) * 100)).ToString();
                                break;
                            }
                        }
                    }

                    spZoneController.Children.Add(zView);
                    _zvList.Add(zView);
                }
            }

            if (zoneControllerList.Count > 0)
            {
                foreach (KeyValuePair<string, int> kv in zoneControllerList)
                {
                    for (int j = 0; j < _zvList.Count; j++)
                    {
                        if (((ZoneView)_zvList[j]).ZoneName.Contains(kv.Key))
                        {
                            var zView = _zvList[j];
                            ((ZoneView)zView).AvailableSlot = kv.Value.ToString();
                            ((ZoneView)zView).OccupiedSlot = (Convert.ToInt32(((ZoneView)zView).TotalSlot) - Convert.ToInt32(((ZoneView)zView).AvailableSlot)).ToString();
                            ((ZoneView)zView).ProgressValue = Convert.ToInt32((Convert.ToDouble(Convert.ToInt32(((ZoneView)zView).OccupiedSlot)) / Convert.ToDouble(Convert.ToInt32(((ZoneView)zView).TotalSlot)) * 100)).ToString();
                            break;
                        }
                    }
                }
            }
        }

        /// <summary>
        /// AddLevelController
        /// </summary>
        public void RemoveZoneView()
        {
            spZoneController.Children.Clear();
            _zvList.Clear();
        }

        /// <summary>
        /// MessagesListBox_SelectionChanged
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MessagesListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                _configdata = XElement.Load("config.xml");

                if (_configdata != null)
                {
                    IEnumerable<XElement> levelConfig = _configdata.Descendants("Level_configuration");
                    RemoveZoneView();
                    foreach (var levelElement in levelConfig.Elements())
                    {
                        if (levelElement.Name.ToString().Replace("Level", "Controller-").Contains(((SystemStatusDocument)e.AddedItems[0]).Name.ToString()))
                        {
                            AddZoneView(levelElement);
                        }
                    }
                }
            }
            catch (Exception ex)
            {

            }
        }

        /// <summary>
        /// ListenUDP
        /// </summary>
        private void ListenUDP()
        {
            try
            {
                bool done = false;

                //Hardcoding Controllers
                ControllerService _controllerService = new ControllerService();
                _controllerService.Controllers = controllerList;

                //Listening UDP Server
                ListenerService _listenerService = new ListenerService();
                _listenerService.StartService("UDP", port: 8888);

                string sb = string.Empty;
                long ticks = 10 * 1000;
                Stopwatch sw = new Stopwatch();
                sw.Start();

                while (!done)
                {
                    string content = _listenerService.ListenService();
                    if (content.Contains("Exception"))
                    {
                        for (int i = 0; i < controllerList.Count; i++)
                        {
                            Publish(i, Brushes.Red);
                        }
                    }
                    else
                    {
                        if (content.LastIndexOf('-') == content.Length - 3)
                        {
                            string[] data = content.Split('-');
                            if (data.Length == 3)
                            {
                                //Level based statistics
                                UpdateLevelStatistics(Convert.ToInt32(data[0]), Convert.ToInt32(data[1]));
                            }
                            else
                            {
                                //Zone based statistics
                                UpdateZoneStatistics(Convert.ToInt32(data[0]), Convert.ToInt32(data[1]), Convert.ToInt32(data[2]));
                            }
                        }
                        else
                        {
                            sb += content;

                            if (sw.ElapsedMilliseconds >= ticks)
                            {
                                for (int i = 0; i < _controllerService.Controllers.Count; i++)
                                {
                                    if (!sb.ToString().Contains(_controllerService.Controllers[i]))
                                    {
                                        Publish(i, Brushes.Red);
                                    }
                                    else
                                    {
                                        Publish(i, Brushes.LightGreen);
                                    }
                                }

                                sb = string.Empty;
                                sw.Restart();
                            }
                        }
                    }
                }

                sw.Stop();
                _listenerService.StopService();
            }
            catch (Exception ex)
            {

            }
        }

        /// <summary>
        /// Publish
        /// </summary>
        /// <param name="index"></param>
        /// <param name="brush"></param>
        private void Publish(int index, Brush brush)
        {
            Application.Current.Dispatcher.BeginInvoke(DispatcherPriority.Background,
                new Action(() =>
                ((LevelView)_lvList[index]).LevelBackgroundColor = brush)
                );
        }

        /// <summary>
        /// UpdateLevelStatistics
        /// </summary>
        /// <param name="level"></param>
        /// <param name="value"></param>
        private void UpdateLevelStatistics(int level, int value)
        {
            Application.Current.Dispatcher.BeginInvoke(DispatcherPriority.Background,
                new Action(() => UpdateLevel(level, value))
                );
        }

        /// <summary>
        /// UpdateLevel
        /// </summary>
        /// <param name="level"></param>
        /// <param name="value"></param>
        private void UpdateLevel(int level, int value)
        {
            ((LevelView)_lvList[level - 1]).AvailableSlot = value.ToString();
            ((LevelView)_lvList[level - 1]).OccupiedSlot = (Convert.ToInt32(((LevelView)_lvList[level - 1]).TotalSlot) - value).ToString();

            availableSlot = 0;
            occupiedSlot = 0;
            for (int i = 0; i < _lvList.Count; i++)
            {
                availableSlot += Convert.ToInt32(((LevelView)_lvList[i]).AvailableSlot);
                occupiedSlot += Convert.ToInt32(((LevelView)_lvList[i]).OccupiedSlot);
            }

            txtLvlFS.Text = availableSlot.ToString();
            txtLvlBS.Text = occupiedSlot.ToString();
            pbLevel.Value = Convert.ToInt32(Convert.ToDouble(occupiedSlot) / Convert.ToDouble(totalSlot) * 100);
            txtPBLevel.Text = pbLevel.Value + "%";
        }

        /// <summary>
        /// UpdateZoneStatistics
        /// </summary>
        /// <param name="level"></param>
        /// <param name="zone"></param>
        /// <param name="value"></param>
        private void UpdateZoneStatistics(int level, int zone, int value)
        {
            Application.Current.Dispatcher.BeginInvoke(DispatcherPriority.Background,
                new Action(() => UpdateZone(level, zone, value))
                );
        }

        /// <summary>
        /// UpdateZone
        /// </summary>
        /// <param name="level"></param>
        /// <param name="zone"></param>
        /// <param name="value"></param>
        private void UpdateZone(int level, int zone, int value)
        {
            string key = "Level" + level.ToString() + "-Zone" + zone.ToString();

            if (zoneControllerList.ContainsKey(key))
            {
                zoneControllerList["Level" + level.ToString() + "-Zone" + zone.ToString()] = value;
            }
            else
            {
                zoneControllerList.Add("Level" + level.ToString() + "-Zone" + zone.ToString(), value);
            }

            if (zoneControllerList.Count > 0)
            {
                foreach (KeyValuePair<string, int> kv in zoneControllerList)
                {
                    for (int j = 0; j < _zvList.Count; j++)
                    {
                        if (((ZoneView)_zvList[j]).ZoneName.Contains(kv.Key))
                        {
                            var zView = _zvList[j];
                            ((ZoneView)zView).AvailableSlot = kv.Value.ToString();
                            ((ZoneView)zView).OccupiedSlot = (Convert.ToInt32(((ZoneView)zView).TotalSlot) - Convert.ToInt32(((ZoneView)zView).AvailableSlot)).ToString();
                            ((ZoneView)zView).ProgressValue = Convert.ToInt32((Convert.ToDouble(Convert.ToInt32(((ZoneView)zView).OccupiedSlot)) / Convert.ToDouble(Convert.ToInt32(((ZoneView)zView).TotalSlot)) * 100)).ToString();
                            break;
                        }
                    }
                }
            }
        }
    }
}
