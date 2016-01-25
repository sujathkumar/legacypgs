

using Prism.Commands;
using Prism.Mvvm;
using Prism.Regions;
using System;
using System.ComponentModel.Composition;
using System.Windows.Input;
using LL.Solutions.PMS.SystemStatus.Model;

namespace LL.Solutions.PMS.SystemStatus.ViewModels
{
    [Export]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    public class SystemStatusViewModel : BindableBase, INavigationAware
    {
        private readonly DelegateCommand goBackCommand;
        private readonly ISystemStatusService SystemStatusService;
        private SystemStatusDocument SystemStatus;
        private IRegionNavigationJournal navigationJournal;
        private const string SystemStatusIdKey = "SystemStatusId";

        [ImportingConstructor]
        public SystemStatusViewModel(ISystemStatusService SystemStatusService)
        {
            this.goBackCommand = new DelegateCommand(this.GoBack);

            this.SystemStatusService = SystemStatusService;
        }

        public ICommand GoBackCommand
        {
            get { return this.goBackCommand; }
        }

        public SystemStatusDocument Status
        {
            get
            {
                return this.SystemStatus;
            }

            set
            {
                this.SetProperty(ref this.SystemStatus, value);
            }
        }


        private void GoBack()
        {
            // todo: 15 - Using the journal to navigate back.
            //
            // This view model offers a GoBack command and uses
            // the journal captured in OnNavigatedTo to
            // navigate back to the prior view.
            if (this.navigationJournal != null)
            {
                this.navigationJournal.GoBack();
            }
        }

        private Guid? GetRequestedSystemStatusId(NavigationContext navigationContext)
        {
            var SystemStatus = navigationContext.Parameters[SystemStatusIdKey];
            Guid SystemStatusId;
            if (SystemStatus != null)
            {
                if (SystemStatus is Guid)
                {
                    SystemStatusId = (Guid)SystemStatus;
                }
                else
                {
                    SystemStatusId = Guid.Parse(SystemStatus.ToString());
                }

                return SystemStatusId;
            }

            return null;
        }

        #region INavigationAware

        bool INavigationAware.IsNavigationTarget(NavigationContext navigationContext)
        {
            // todo: 13 - Determining if a view or view model handles the navigation request
            //
            // By implementing IsNavigationTarget, this view model can let the region
            // navigation service know that it is the item sought for navigation. 
            // 
            // If this view model is the one that was built to display the requested
            // SystemStatusId (as a result of a prior navigation request), then this
            // method will return true.  
            //
            // Otherwise, it will return false and if no other SystemStatusViewModel type returns true 
            // then the navigation service knows that no SystemStatusView is already available that 
            // shows that SystemStatus.  In this case, the navigation service will request a new one 
            // be constructed and added to the region.
            if (this.SystemStatus == null)
            {
                return true;
            }

            var requestedSystemStatusId = GetRequestedSystemStatusId(navigationContext);

            return requestedSystemStatusId.HasValue && requestedSystemStatusId.Value == this.SystemStatus.Id;
        }

        void INavigationAware.OnNavigatedFrom(NavigationContext navigationContext)
        {
            // Intentionally not implemented.
        }

        void INavigationAware.OnNavigatedTo(NavigationContext navigationContext)
        {
            // todo: 15 - Orient to the right context
            //
            // When this view model is navigated to, it gathers the
            // requested SystemStatusId from the navigation context's parameters.
            //
            // It also captures the navigation Journal so it
            // can offer a 'go back' command.
            var SystemStatusId = GetRequestedSystemStatusId(navigationContext);
            if (SystemStatusId.HasValue)
            {
                this.SystemStatus = this.SystemStatusService.GetSystemStatusDocument(SystemStatusId.Value);
            }

            this.navigationJournal = navigationContext.NavigationService.Journal;
        }

        #endregion
    }
}
