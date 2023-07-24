using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace JWReport.PageModels.Base
{
    public class PageModelBase : ExtendedBindableObject
    {
        string _title;
        /// <summary>
        /// Title of the page, settable in the PageModel
        /// </summary>
        public string Title {
            get => _title;
            set => SetProperty(ref _title, value);
        }

        bool _isLoading;
        /// <summary>
        /// FLag to notify the Page on network activity
        /// </summary>

        public bool IsLoading
        {
            get => _isLoading;
            set => SetProperty(ref _isLoading, value);
        }

        /// <summary>
        /// Performs Page Model Initialization Asynchronously
        /// </summary>
        /// <param name="navigationData"></param>
        /// <returns></returns>
        public virtual Task InitializeAsync(object navigationData)
        {
            return Task.CompletedTask;
        }
    }
}
