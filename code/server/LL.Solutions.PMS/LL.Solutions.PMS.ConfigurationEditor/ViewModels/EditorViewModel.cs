

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
        private readonly DelegateCommand<Editor> openMeetingEmailCommand;
        private readonly IRegionManager regionManager;
        private readonly IEditorService EditorService;

        private const string GuidNumericFormatSpecifier = "N";
        private const string EmailViewName = "EmailView";
        private const string EmailIdName = "EmailId";

        private ObservableCollection<Editor> meetings;

        [ImportingConstructor]
        public EditorViewModel(IEditorService EditorService, IRegionManager regionManager)
        {
            this.openMeetingEmailCommand = new DelegateCommand<Editor>(this.OpenMeetingEmail);

            this.EditorService = EditorService;
            this.regionManager = regionManager;
            var task = this.LoadMeetings();
        }

        public ObservableCollection<Editor> Meetings
        {
            get { return meetings; }
            set { SetProperty(ref meetings, value); }
        }

        public ICommand OpenMeetingEmailCommand
        {
            get { return this.openMeetingEmailCommand; }
        }

        private async Task LoadMeetings()
        {
            this.meetings = new ObservableCollection<Editor>(await this.EditorService.GetMeetingsAsync());
        }

        private void OpenMeetingEmail(Editor meeting)
        {
            // todo: 12 - Opening an email
            //
            // This view initiates navigation using the RegionManager.
            // The RegionManager will find the region and delegate the
            // navigation request to the region specified.
            //
            // This navigation request also includes additional navigation context, an 'EmailId', to
            // allow the Email view to orient to the right item.
            var parameters = new NavigationParameters();
            parameters.Add(EmailIdName, meeting.EmailId.ToString(GuidNumericFormatSpecifier));

            this.regionManager.RequestNavigate(RegionNames.MainContentRegion, new Uri(EmailViewName + parameters, UriKind.Relative));
        }
    }
}
