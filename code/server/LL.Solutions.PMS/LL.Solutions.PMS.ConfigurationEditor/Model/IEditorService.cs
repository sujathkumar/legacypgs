using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LL.Solutions.PMS.ConfigurationEditor.Model
{
    public interface IEditorService
    {
        Task<IEnumerable<Editor>> GetMeetingsAsync();
    }
}
