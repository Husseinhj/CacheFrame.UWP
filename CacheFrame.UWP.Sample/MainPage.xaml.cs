using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using CacheFrame.UWP.Sample.Pages;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace CacheFrame.UWP.Sample
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
        }

        private void BtnPage1_OnClick(object sender, RoutedEventArgs e)
        {
            MainCacheFrame.NavigateTo(new Page1(), null, null);
        }

        private void BtnPage2_OnClick(object sender, RoutedEventArgs e)
        {
            MainCacheFrame.NavigateTo(new Page2(), null, null);
        }

        private void BtnPage3_OnClick(object sender, RoutedEventArgs e)
        {
            MainCacheFrame.NavigateTo(new Page3(), null, null);
        }
    }
}
