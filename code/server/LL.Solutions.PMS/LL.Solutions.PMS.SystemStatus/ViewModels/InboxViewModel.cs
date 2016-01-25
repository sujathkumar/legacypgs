using Prism.Commands;
using Prism.Mvvm;
using Prism.Regions;
using System;
using System.Linq;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.ComponentModel.Composition;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Windows.Input;
using LL.Solutions.PMS.SystemStatus.Model;
using LL.Solutions.PMS.Infrastructure;

namespace LL.Solutions.PMS.SystemStatus.ViewModels
{
    [Export]
    public class InboxViewModel : BindableBase
    {
        private const string ComposeSystemStatusViewKey = "ComposeSystemStatusView";
        private const string ReplyToKey = "ReplyTo";
        private const string SystemStatusViewKey = "SystemStatusView";
        private const string SystemStatusIdKey = "SystemStatusId";

        private readonly ISystemStatusService SystemStatusService;
        private readonly IRegionManager regionManager;
        private readonly DelegateCommand<object> composeMessageCommand;
        private readonly DelegateCommand<object> replyMessageCommand;
        private readonly DelegateCommand<SystemStatusDocument> openMessageCommand;
        private readonly ObservableCollection<SystemStatusDocument> messagesCollection;

        private static Uri ComposeSystemStatusViewUri = new Uri(ComposeSystemStatusViewKey, UriKind.Relative);

        [ImportingConstructor]
        public InboxViewModel(ISystemStatusService SystemStatusService, IRegionManager regionManager)
        {
            this.composeMessageCommand = new DelegateCommand<object>(this.ComposeMessage);
            this.replyMessageCommand = new DelegateCommand<object>(this.ReplyMessage, this.CanReplyMessage);
            this.openMessageCommand = new DelegateCommand<SystemStatusDocument>(this.OpenMessage);

            this.messagesCollection = new ObservableCollection<SystemStatusDocument>();
            this.Messages = new ListCollectionView(this.messagesCollection);
            this.Messages.CurrentChanged += (s, e) =>
                this.replyMessageCommand.RaiseCanExecuteChanged();

            this.SystemStatusService = SystemStatusService;
            this.regionManager = regionManager;

            var task = this.Initialize();
        }

        private async Task Initialize()
        {
            var messages = await this.SystemStatusService.GetSystemStatusDocumentsAsync();
            messages.ToList().ForEach(m => this.messagesCollection.Add(m));
        }

        public ICollectionView Messages { get; private set; }

        public ICommand ComposeMessageCommand
        {
            get { return this.composeMessageCommand; }
        }

        public ICommand ReplyMessageCommand
        {
            get { return this.replyMessageCommand; }
        }

        public ICommand OpenMessageCommand
        {
            get { return this.openMessageCommand; }
        }

        private void ComposeMessage(object ignored)
        {
            // todo: 02 - New SystemStatus: Navigating to a view in a region
            // Any region can be navigated by passing in a relative Uri for the SystemStatus view name.
            // By the default, the navigation service will look for an item already in the region
            // with a type name that matches the Uri.
            //
            // If an item is not found in the region, the navigation services uses the 
            // ServiceLocator to find an item that matches the Uri, in the example below it would
            // be ComposeSystemStatusView.
            this.regionManager.RequestNavigate(RegionNames.MainContentRegion, ComposeSystemStatusViewUri);
        }

        private void ReplyMessage(object ignored)
        {
            // todo: 03 - Reply SystemStatus: Navigating to a view in a region with context
            // When navigating, you can also supply context so the target view or
            // viewmodel can orient their data to something appropriate.  In this case,
            // we've chosen to pass the SystemStatus id in a name/value pairs.
            //
            // The recipient of the context can get access to this information by
            // implementing the INavigationAware or IConfirmNavigationRequest interface, as shown by the 
            // the ComposeSystemStatusViewModel.
            //
            var currentSystemStatus = this.Messages.CurrentItem as SystemStatusDocument;

            if (currentSystemStatus != null)
            {
                var parameters = new NavigationParameters();
                parameters.Add(ReplyToKey, currentSystemStatus.Id.ToString("N"));
                this.regionManager.RequestNavigate(RegionNames.MainContentRegion, ComposeSystemStatusViewKey + parameters);
            }

            
        }

        private bool CanReplyMessage(object ignored)
        {
            return this.Messages.CurrentItem != null;
        }

        private void OpenMessage(SystemStatusDocument document)
        {
            // todo: 04 - Open SystemStatus: Navigating to a view in a region with context
            // When navigating, you can also supply context so the target view or
            // viewmodel can orient their data to something appropriate.  In this case,
            // we've chosen to pass the SystemStatus id in a name/value pair using and handmade Uri.
            //
            // The SystemStatusViewModel retrieves this context by implementing the INavigationAware
            // interface.
            //
            NavigationParameters parameters = new NavigationParameters();
            parameters.Add(SystemStatusIdKey, document.Id.ToString("N"));

            this.regionManager.RequestNavigate(RegionNames.MainContentRegion, new Uri(SystemStatusViewKey + parameters, UriKind.Relative));
        }
    }
}
