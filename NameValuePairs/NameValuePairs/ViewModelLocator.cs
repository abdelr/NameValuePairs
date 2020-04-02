using NameValuePairs.ViewModels;
using Ninject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NameValuePairs
{
    public class ViewModelLocator
    {
        public MainViewModel MainViewModel
        {
            get
            {
                return IocKernel.Get<MainViewModel>();
            }
        }
    }
}