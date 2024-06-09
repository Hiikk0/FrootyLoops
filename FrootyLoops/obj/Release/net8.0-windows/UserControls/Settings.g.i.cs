﻿#pragma checksum "..\..\..\..\UserControls\Settings.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "6784B7BDD78984E954DCFD4D7E939C614F2A791D"
//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан программой.
//     Исполняемая версия:4.0.30319.42000
//
//     Изменения в этом файле могут привести к неправильной работе и будут потеряны в случае
//     повторной генерации кода.
// </auto-generated>
//------------------------------------------------------------------------------

using FrootyLoops.UserControls;
using FrootyLoops.ViewModel;
using HandyControl.Controls;
using HandyControl.Data;
using HandyControl.Expression.Media;
using HandyControl.Expression.Shapes;
using HandyControl.Interactivity;
using HandyControl.Media.Animation;
using HandyControl.Media.Effects;
using HandyControl.Properties.Langs;
using HandyControl.Themes;
using HandyControl.Tools;
using HandyControl.Tools.Converter;
using HandyControl.Tools.Extension;
using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Controls.Ribbon;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Effects;
using System.Windows.Media.Imaging;
using System.Windows.Media.Media3D;
using System.Windows.Media.TextFormatting;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Shell;


namespace FrootyLoops.UserControls {
    
    
    /// <summary>
    /// Settings
    /// </summary>
    public partial class Settings : System.Windows.Controls.UserControl, System.Windows.Markup.IComponentConnector {
        
        
        #line 37 "..\..\..\..\UserControls\Settings.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.RadioButton UserSetBtn;
        
        #line default
        #line hidden
        
        
        #line 62 "..\..\..\..\UserControls\Settings.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.RadioButton ThemeSetBtn;
        
        #line default
        #line hidden
        
        
        #line 80 "..\..\..\..\UserControls\Settings.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.RadioButton LangSetBtn;
        
        #line default
        #line hidden
        
        
        #line 98 "..\..\..\..\UserControls\Settings.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.RadioButton WorkSetBtn;
        
        #line default
        #line hidden
        
        
        #line 116 "..\..\..\..\UserControls\Settings.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.RadioButton SysSetBtn;
        
        #line default
        #line hidden
        
        
        #line 142 "..\..\..\..\UserControls\Settings.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.RadioButton CLogBtn;
        
        #line default
        #line hidden
        
        
        #line 160 "..\..\..\..\UserControls\Settings.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.RadioButton HelpBtn;
        
        #line default
        #line hidden
        
        
        #line 178 "..\..\..\..\UserControls\Settings.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.RadioButton CheckUpdatesBtn;
        
        #line default
        #line hidden
        
        
        #line 203 "..\..\..\..\UserControls\Settings.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button ExitFromAccBtn;
        
        #line default
        #line hidden
        
        
        #line 271 "..\..\..\..\UserControls\Settings.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ContentPresenter Content;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "8.0.2.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/FrootyLoops;V0.2.5.0;component/usercontrols/settings.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\UserControls\Settings.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "8.0.2.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            this.UserSetBtn = ((System.Windows.Controls.RadioButton)(target));
            
            #line 39 "..\..\..\..\UserControls\Settings.xaml"
            this.UserSetBtn.Checked += new System.Windows.RoutedEventHandler(this.UserSetBtn_Checked);
            
            #line default
            #line hidden
            return;
            case 2:
            this.ThemeSetBtn = ((System.Windows.Controls.RadioButton)(target));
            
            #line 65 "..\..\..\..\UserControls\Settings.xaml"
            this.ThemeSetBtn.Checked += new System.Windows.RoutedEventHandler(this.Theme_Checked);
            
            #line default
            #line hidden
            return;
            case 3:
            this.LangSetBtn = ((System.Windows.Controls.RadioButton)(target));
            
            #line 83 "..\..\..\..\UserControls\Settings.xaml"
            this.LangSetBtn.Checked += new System.Windows.RoutedEventHandler(this.LangSetBtn_Checked);
            
            #line default
            #line hidden
            return;
            case 4:
            this.WorkSetBtn = ((System.Windows.Controls.RadioButton)(target));
            
            #line 101 "..\..\..\..\UserControls\Settings.xaml"
            this.WorkSetBtn.Checked += new System.Windows.RoutedEventHandler(this.WorkSetBtn_Checked);
            
            #line default
            #line hidden
            return;
            case 5:
            this.SysSetBtn = ((System.Windows.Controls.RadioButton)(target));
            
            #line 119 "..\..\..\..\UserControls\Settings.xaml"
            this.SysSetBtn.Checked += new System.Windows.RoutedEventHandler(this.SysSetBtn_Checked);
            
            #line default
            #line hidden
            return;
            case 6:
            this.CLogBtn = ((System.Windows.Controls.RadioButton)(target));
            
            #line 145 "..\..\..\..\UserControls\Settings.xaml"
            this.CLogBtn.Checked += new System.Windows.RoutedEventHandler(this.WhatsNew_Checked);
            
            #line default
            #line hidden
            return;
            case 7:
            this.HelpBtn = ((System.Windows.Controls.RadioButton)(target));
            
            #line 163 "..\..\..\..\UserControls\Settings.xaml"
            this.HelpBtn.Checked += new System.Windows.RoutedEventHandler(this.FAQ_Checked);
            
            #line default
            #line hidden
            return;
            case 8:
            this.CheckUpdatesBtn = ((System.Windows.Controls.RadioButton)(target));
            
            #line 181 "..\..\..\..\UserControls\Settings.xaml"
            this.CheckUpdatesBtn.Checked += new System.Windows.RoutedEventHandler(this.Update_Checked);
            
            #line default
            #line hidden
            return;
            case 9:
            this.ExitFromAccBtn = ((System.Windows.Controls.Button)(target));
            
            #line 208 "..\..\..\..\UserControls\Settings.xaml"
            this.ExitFromAccBtn.Click += new System.Windows.RoutedEventHandler(this.ExitFromAcc_Click);
            
            #line default
            #line hidden
            return;
            case 10:
            
            #line 251 "..\..\..\..\UserControls\Settings.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.ExitFromSet_Click);
            
            #line default
            #line hidden
            return;
            case 11:
            this.Content = ((System.Windows.Controls.ContentPresenter)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}

