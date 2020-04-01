using MvvmDialogs;
using System;

namespace NameValuePairs.ViewModels
{
    class AboutViewModel : ViewModelBase, IModalDialogViewModel
    {
        public bool? DialogResult { get { return false; } }

        public string Content
        {
            get
            {
                return "NameValuePairs" + Environment.NewLine +
                        "Created by Abdel" + Environment.NewLine +
                        "abdelr1982@gmail.com" + Environment.NewLine +
                        "2020";
            }
        }

        public string VersionText
        {
            get
            {
                var version1 = System.Reflection.Assembly.GetExecutingAssembly().GetName().Version;

                return "NameValuePairs v" + version1.ToString();
            }
        }
    }
}
