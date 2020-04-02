using MvvmDialogs;
using System.Windows.Input;
using NameValuePairs.Views;
using NameValuePairs.Utils;
using System.Collections.ObjectModel;
using NameValuePairs.Core.Entities;
using System.Collections.Generic;
using NameValuePairs.Models;
using System;
using System.Windows;

namespace NameValuePairs.ViewModels
{
    public class MainViewModel : ViewModelBase
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

        private string _pairName { get; set; }
        /// <summary>
        /// PairName as typed by the user
        /// </summary>
        public string PairName
        {
            get { return _pairName; }
            set
            {
                if (_pairName != value)
                {
                    _pairName = value;
                    NotifyPropertyChanged();
                }
            }
        }

        private string _pairValue { get; set; }
        /// <summary>
        /// PairValue as typed by the user
        /// </summary>
        public string PairValue
        {
            get { return _pairValue; }
            set
            {
                if (_pairValue != value)
                {
                    _pairValue = value;
                    NotifyPropertyChanged();
                }
            }
        }

        /// <summary>
        /// Filter type as Selected by the user
        /// </summary>
        public string FilterType { get; set; }

        private string _filterValue { get; set; }
        /// <summary>
        /// Filter criteria as typed by the user
        /// </summary>
        public string FilterValue
        {
            get { return _filterValue; }
            set
            {
                if (_filterValue != value)
                {
                    _filterValue = value;
                    NotifyPropertyChanged();
                }
            }
        }

        public ObservableCollection<NameValuePair> PairList { get; set; }

        public ObservableCollection<NameValuePair> SelectedItems { get; set; }

        private readonly MainModel Model;

        #endregion

        #region Constructors
        public MainViewModel(MainModel model)
        {
            // DialogService is used to handle dialogs
            this.DialogService = new MvvmDialogs.DialogService();
            PairName = "Name";
            PairValue = "Value";
            FilterValue = "";
            FilterType = "Name";
            PairList = new ObservableCollection<NameValuePair>();
            SelectedItems = new ObservableCollection<NameValuePair>();
            Model = model;
        }

        #endregion

        #region Methods
        private void ResetPairList(IEnumerable<NameValuePair> list)
        {
            PairList.Clear();
            foreach (var x in list)
            {
                PairList.Add(x);
            }
        }
        #endregion

        #region Commands
        public ICommand AddCmd { get { return new RelayCommand(OnAdd, AddEnabled); } }
        public ICommand DeleteCmd { get { return new RelayCommand(OnDelete, SortEnabled); } }
        public ICommand FilterCmd { get { return new RelayCommand(OnFilter, FilterEnabled); } }
        public ICommand ClearFiltersCmd { get { return new RelayCommand(OnClearFilters, FilterEnabled); } }
        public ICommand SortByNameCmd { get { return new RelayCommand(OnSortByName, SortEnabled); } }
        public ICommand SortByValueCmd { get { return new RelayCommand(OnSortByValue, SortEnabled); } }
        public ICommand ShowAboutDialogCmd { get { return new RelayCommand(OnShowAboutDialog, AlwaysTrue); } }
        public ICommand ExitCmd { get { return new RelayCommand(OnExitApp, AlwaysTrue); } }

        private bool AlwaysTrue() { return true; }
        private bool AlwaysFalse() { return false; }

        private bool AddEnabled() { return !(string.IsNullOrEmpty(PairName) || string.IsNullOrEmpty(PairValue)); }

        private bool FilterEnabled() { return !(string.IsNullOrEmpty(FilterValue)); }

        private bool SortEnabled() { return PairList.Count > 0; }

        private void OnAdd()
        {
            try
            {
                ResetPairList(Model.Add(new NameValuePair { Name = PairName, Value = PairValue }));
                PairValue = "";
                PairName = "";
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
            }
        }
        private void OnDelete()
        {
            ResetPairList(Model.Delete(SelectedItems));
        }
        private void OnFilter()
        {
            ResetPairList(Model.Filter(new FilterSetting
            {
                Type = ((FilterType == "Name") ? FilterSetting.ValueType.NAME : FilterSetting.ValueType.VALUE),
                Value = FilterValue
            }));
        }
        private void OnClearFilters()
        {
            ResetPairList(Model.ClearFilter());
        }
        private void OnSortByName()
        {
            ResetPairList(Model.SortByName());
        }
        private void OnSortByValue()
        {
            ResetPairList(Model.SortByValue());
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
