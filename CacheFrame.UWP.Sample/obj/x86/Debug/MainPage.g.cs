﻿#pragma checksum "C:\Users\HusseinHJ\documents\visual studio 2017\Projects\CacheFrame.UWP\CacheFrame.UWP.Sample\MainPage.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "0B30BCA2456239001EC61092D9F13616"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace CacheFrame.UWP.Sample
{
    partial class MainPage : 
        global::Windows.UI.Xaml.Controls.Page, 
        global::Windows.UI.Xaml.Markup.IComponentConnector,
        global::Windows.UI.Xaml.Markup.IComponentConnector2
    {
        /// <summary>
        /// Connect()
        /// </summary>
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Windows.UI.Xaml.Build.Tasks"," 14.0.0.0")]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        public void Connect(int connectionId, object target)
        {
            switch(connectionId)
            {
            case 1:
                {
                    this.MainCacheFrame = (global::CacheFrame.UWP.CacheFrame)(target);
                }
                break;
            case 2:
                {
                    this.BtnPage1 = (global::Windows.UI.Xaml.Controls.Button)(target);
                    #line 37 "..\..\..\MainPage.xaml"
                    ((global::Windows.UI.Xaml.Controls.Button)this.BtnPage1).Click += this.BtnPage1_OnClick;
                    #line default
                }
                break;
            case 3:
                {
                    this.BtnPage2 = (global::Windows.UI.Xaml.Controls.Button)(target);
                    #line 47 "..\..\..\MainPage.xaml"
                    ((global::Windows.UI.Xaml.Controls.Button)this.BtnPage2).Click += this.BtnPage2_OnClick;
                    #line default
                }
                break;
            case 4:
                {
                    this.BtnPage3 = (global::Windows.UI.Xaml.Controls.Button)(target);
                    #line 57 "..\..\..\MainPage.xaml"
                    ((global::Windows.UI.Xaml.Controls.Button)this.BtnPage3).Click += this.BtnPage3_OnClick;
                    #line default
                }
                break;
            default:
                break;
            }
            this._contentLoaded = true;
        }

        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Windows.UI.Xaml.Build.Tasks"," 14.0.0.0")]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        public global::Windows.UI.Xaml.Markup.IComponentConnector GetBindingConnector(int connectionId, object target)
        {
            global::Windows.UI.Xaml.Markup.IComponentConnector returnValue = null;
            return returnValue;
        }
    }
}

