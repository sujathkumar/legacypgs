

using System;

namespace LL.Solutions.PMS.SystemStatus.Model
{
    public class SystemStatusDocument
    {
        public SystemStatusDocument()
            : this(Guid.NewGuid())
        {
        }

        public SystemStatusDocument(Guid id)
        {
            this.Id = id;
        }

        public string Name { get; set;}

        public string Message { get; set;}

        public Guid Id { get; private set;}
    }
}
