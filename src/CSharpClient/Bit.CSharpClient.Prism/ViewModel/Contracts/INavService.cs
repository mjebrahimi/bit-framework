﻿using Prism.Navigation;
using System;
using System.Threading.Tasks;

namespace Bit.ViewModel.Contracts
{
    /// <summary>
    /// It can be easily mocked.
    /// Its go back async works better in popup pages.
    /// It throws an exception when navigation methods' result becomes unsuccessful.
    /// Its clear popup stack method clears popups which are not being managed with prism.
    /// It has GoBackToAsync which accepts a name in navigation stack on goes back till required.
    /// </summary>
    public interface INavService
    {
        Task NavigateAsync(string name, INavigationParameters parameters = null);
        Task NavigateAsync(string name, params (string, object)[] parameters);
        Task NavigateAsync(Uri uri, INavigationParameters parameters = null);
        Task NavigateAsync(Uri uri, params (string, object)[] parameters);

        Task GoBackAsync(params (string, object)[] parameters);
        Task GoBackAsync(INavigationParameters parameters = null);

        Task GoBackToRootAsync(params (string, object)[] parameters);
        Task GoBackToRootAsync(INavigationParameters parameters = null);

        string GetNavigationUriPath();

        Task ClearPopupStackAsync(params (string, object)[] parameters);
        Task ClearPopupStackAsync(INavigationParameters parameters = null);

        Task GoBackToAsync(string name, params (string, object)[] parameters);
        Task GoBackToAsync(string name, INavigationParameters parameters = null);

        INavigationService PrismNavigationService { get; }

        INavService AppNavService { get; }

        /// <summary>
        /// In a sample nav stack( Page1/Page2/Page3) which you're executing a code in page2, sometimes you need page3's nav service.
        /// </summary>
        INavService CurrentPageNavService { get; }
    }
}
