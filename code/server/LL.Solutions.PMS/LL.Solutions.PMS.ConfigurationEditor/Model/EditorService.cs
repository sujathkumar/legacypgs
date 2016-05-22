using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.Composition;
using System.Threading.Tasks;

namespace LL.Solutions.PMS.ConfigurationEditor.Model
{
    [Export(typeof(IEditorService))]
    public class EditorService : IEditorService
    {
        private readonly Editor configurationInfo;

        public EditorService()
        {
            configurationInfo = new Editor();
        }

        public Task<Editor> GetConfigurationInfoAsync()
        {
            return Task.FromResult(configurationInfo);
        }
    }
}
