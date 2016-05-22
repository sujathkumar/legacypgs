

using System;
using System.Collections.ObjectModel;
using System.ComponentModel.Composition;
using System.Text;
using System.Threading;
using System.Windows.Input;
using Prism.Common;
using Prism.Commands;
using Prism.Regions;
using LL.Solutions.PMS.ConfigurationEditor.Model;
using LL.Solutions.PMS.Infrastructure;
using System.Collections.Generic;
using System.Threading.Tasks;
using Prism.Mvvm;

namespace LL.Solutions.PMS.ConfigurationEditor.ViewModels
{
    [Export]
    public class EditorViewModel : BindableBase
    {
        private readonly IRegionManager regionManager;
        private readonly IEditorService EditorService;

        [ImportingConstructor]
        public EditorViewModel(IEditorService EditorService, IRegionManager regionManager)
        {
            this.EditorService = EditorService;
            this.regionManager = regionManager;
        }
    }
}
