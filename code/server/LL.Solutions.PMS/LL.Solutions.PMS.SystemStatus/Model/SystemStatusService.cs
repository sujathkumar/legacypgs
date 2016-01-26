using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.Composition;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using LL.Solutions.PMS.Infrastructure;

namespace LL.Solutions.PMS.SystemStatus.Model
{
    [Export(typeof(ISystemStatusService))]
    public class SystemStatusService : ISystemStatusService
    {
        private readonly List<SystemStatusDocument> SystemStatusDocuments;

        public SystemStatusService()
        {
            this.SystemStatusDocuments =
                new List<SystemStatusDocument>
                {
                    new SystemStatusDocument { Name = "Level 1", Message = "Controller 1 is Alive" },
                    new SystemStatusDocument { Name = "Level 2", Message = "Controller 2 is Alive" },
                    new SystemStatusDocument { Name = "Level 3", Message = "Controller 3 is Alive" },
                    new SystemStatusDocument { Name = "Level 4", Message = "Controller 4 is Alive" },
                    new SystemStatusDocument { Name = "Level 5", Message = "Controller 5 is Alive" },
                    new SystemStatusDocument { Name = "Level 6", Message = "Controller 6 is Alive" },
                    new SystemStatusDocument { Name = "Level 7", Message = "Controller 7 is Alive" },
                    new SystemStatusDocument { Name = "Level 8", Message = "Controller 8 is Alive" },
                    new SystemStatusDocument { Name = "Level 9", Message = "Controller 9 is Alive" },
                    new SystemStatusDocument { Name = "Level 10", Message = "Controller 10 is Alive" }
                };
        }

        public SystemStatusDocument GetSystemStatusDocument(Guid id)
        {
            return this.SystemStatusDocuments.FirstOrDefault(e => e.Id == id);
        }

        public Task<IEnumerable<SystemStatusDocument>> GetSystemStatusDocumentsAsync()
        {
            return Task.FromResult(new ReadOnlyCollection<SystemStatusDocument>(this.SystemStatusDocuments) as IEnumerable<SystemStatusDocument>);
        }

        public Task SendSystemStatusDocumentAsync(SystemStatusDocument SystemStatus)
        {
            return Task.Delay(500);
        }
    }
}
