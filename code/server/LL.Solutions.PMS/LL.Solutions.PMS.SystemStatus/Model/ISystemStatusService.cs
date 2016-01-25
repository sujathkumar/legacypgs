using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LL.Solutions.PMS.SystemStatus.Model
{
    public interface ISystemStatusService
    {
        Task<IEnumerable<SystemStatusDocument>> GetSystemStatusDocumentsAsync();
        Task SendSystemStatusDocumentAsync(SystemStatusDocument SystemStatus);
        SystemStatusDocument GetSystemStatusDocument(Guid id);
    }
}
