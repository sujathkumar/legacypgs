using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.Composition;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Xml.Linq;
using LL.Solutions.PMS.Infrastructure;

namespace LL.Solutions.PMS.SystemStatus.Model
{
    [Export(typeof(ISystemStatusService))]
    public class SystemStatusService : ISystemStatusService
    {
        private readonly List<SystemStatusDocument> SystemStatusDocuments;
        private List<XElement> LevelConfiguration;
        XElement _configdata = null;

        public SystemStatusService()
        {
            this.SystemStatusDocuments = LoadConfigurationInfo();
        }

        /// <summary>
        /// LoadControllerInfo
        /// </summary>
        private List<SystemStatusDocument> LoadConfigurationInfo()
        {
            List<SystemStatusDocument> levelControllerList = new List<SystemStatusDocument>();

            try
            {
                _configdata = XElement.Load("config.xml");

                if (_configdata != null)
                {
                    IEnumerable<XElement> levelConfig = _configdata.Descendants("Level_configuration");
                    this.LevelConfiguration = levelConfig.ToList();
                    foreach (var levelElement in levelConfig.Elements())
                    {
                        string levelName = levelElement.Name.ToString().Replace("_configuration", "");
                        levelControllerList.Add(new SystemStatusDocument { Name = levelName, Message = levelName + " is Alive" });
                    }
                }
            }
            catch (Exception ex)
            {

            }

            return levelControllerList;
        }

        public SystemStatusDocument GetSystemStatusDocument(Guid id)
        {
            return this.SystemStatusDocuments.FirstOrDefault(e => e.Id == id);
        }

        public Task<IEnumerable<SystemStatusDocument>> GetSystemStatusDocumentsAsync()
        {
            return Task.FromResult(new ReadOnlyCollection<SystemStatusDocument>(this.SystemStatusDocuments) as IEnumerable<SystemStatusDocument>);
        }

        public Task<IEnumerable<XElement>> GetLevelConfigurationAsync()
        {
            return Task.FromResult(new ReadOnlyCollection<XElement>(this.LevelConfiguration) as IEnumerable<XElement>);
        }

        public Task SendSystemStatusDocumentAsync(SystemStatusDocument SystemStatus)
        {
            return Task.Delay(500);
        }
    }
}
