using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace LL.Solutions.PMS.SystemStatus.Model
{
    public interface ISystemStatusService
    {
        Task<IEnumerable<SystemStatusDocument>> GetSystemStatusDocumentsAsync();
        Task<IEnumerable<XElement>> GetLevelConfigurationAsync();
        Task SendSystemStatusDocumentAsync(SystemStatusDocument SystemStatus);
        SystemStatusDocument GetSystemStatusDocument(Guid id);
    }
}
