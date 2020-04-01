using MvvmDialogs;
using System.Windows.Input;
using NameValuePairs.Views;
using NameValuePairs.Utils;

namespace NameValuePairs.ViewModels
{
    class MainViewModel : ViewModelBase
    {
        #region Parameters
        private readonly IDialogService DialogService;

        /// <summary>
        /// Title of the application, as displayed in the top bar of the window
        /// </summary>
        public string Title
        {
            get { return "NameValuePairs"; }
        }
        #endregion

        #region Constructors
        public MainViewModel()
        {
            // DialogService is used to handle dialogs
            this.DialogService = new MvvmDialogs.DialogService();
        }

        #endregion

        #region Methods

        #endregion

        #region Commands
        public ICommand AddCmd { get { return new RelayCommand(OnAdd, AlwaysFalse); } }
        public ICommand DeleteCmd { get { return new RelayCommand(OnDelete, AlwaysFalse); } }
        public ICommand FilterCmd { get { return new RelayCommand(OnFilter, AlwaysFalse); } }
        public ICommand ClearFiltersCmd { get { return new RelayCommand(OnClearFilters, AlwaysFalse); } }
        public ICommand SortByNameCmd { get { return new RelayCommand(OnSortByName, AlwaysFalse); } }
        public ICommand SortByValueCmd { get { return new RelayCommand(OnSortByValue, AlwaysFalse); } }
        public ICommand ShowAboutDialogCmd { get { return new RelayCommand(OnShowAboutDialog, AlwaysTrue); } }
        public ICommand ExitCmd { get { return new RelayCommand(OnExitApp, AlwaysTrue); } }

        private bool AlwaysTrue() { return true; }
        private bool AlwaysFalse() { return false; }

        private void OnAdd()
        {
            // TODO
        }
        private void OnDelete()
        {
            // TODO
        }
        private void OnFilter()
        {
            // TODO
        }
        private void OnClearFilters()
        {
            // TODO
        }
        private void OnSortByName()
        {
            // TODO
        }
        private void OnSortByValue()
        {
            // TODO
        }
        private void OnShowAboutDialog()
        {
            Log.Info("Opening About dialog");
            AboutViewModel dialog = new AboutViewModel();
            var result = DialogService.ShowDialog<About>(this, dialog);
        }
        private void OnExitApp()
        {
            System.Windows.Application.Current.MainWindow.Close();
        }
        #endregion

        #region Events

        #endregion
    }
}
