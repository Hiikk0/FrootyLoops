﻿#pragma checksum "..\..\..\..\..\UserControls\SettingsContent\UserSettings.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "661280A5D6519F396E1150B2B530073CDB6A6933"
//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан программой.
//     Исполняемая версия:4.0.30319.42000
//
//     Изменения в этом файле могут привести к неправильной работе и будут потеряны в случае
//     повторной генерации кода.
// </auto-generated>
//------------------------------------------------------------------------------

using FrootyLoops.UserControls.SettingsContent;
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


namespace FrootyLoops.UserControls.SettingsContent {
    
    
    /// <summary>
    /// UserSettings
    /// </summary>
    public partial class UserSettings : System.Windows.Controls.UserControl, System.Windows.Markup.IComponentConnector {
        
        
        #line 50 "..\..\..\..\..\UserControls\SettingsContent\UserSettings.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal HandyControl.Controls.ImageSelector UserPic;
        
        #line default
        #line hidden
        
        
        #line 59 "..\..\..\..\..\UserControls\SettingsContent\UserSettings.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal HandyControl.Controls.TextBox Username;
        
        #line default
        #line hidden
        
        
        #line 119 "..\..\..\..\..\UserControls\SettingsContent\UserSettings.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal HandyControl.Controls.TextBox UserEmail;
        
        #line default
        #line hidden
        
        
        #line 139 "..\..\..\..\..\UserControls\SettingsContent\UserSettings.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal HandyControl.Controls.TextBox UserPassword;
        
        #line default
        #line hidden
        
        
        #line 163 "..\..\..\..\..\UserControls\SettingsContent\UserSettings.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal HandyControl.Controls.TextBox NewPassword;
        
        #line default
        #line hidden
        
        
        #line 187 "..\..\..\..\..\UserControls\SettingsContent\UserSettings.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal HandyControl.Controls.TextBox UserPasswordHint;
        
        #line default
        #line hidden
        
        
        #line 215 "..\..\..\..\..\UserControls\SettingsContent\UserSettings.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button CancelButton;
        
        #line default
        #line hidden
        
        
        #line 224 "..\..\..\..\..\UserControls\SettingsContent\UserSettings.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button AcceptButton;
        
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
            System.Uri resourceLocater = new System.Uri("/FrootyLoops;V0.2.7.0;component/usercontrols/settingscontent/usersettings.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\..\UserControls\SettingsContent\UserSettings.xaml"
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
            this.UserPic = ((HandyControl.Controls.ImageSelector)(target));
            return;
            case 2:
            this.Username = ((HandyControl.Controls.TextBox)(target));
            return;
            case 3:
            this.UserEmail = ((HandyControl.Controls.TextBox)(target));
            return;
            case 4:
            this.UserPassword = ((HandyControl.Controls.TextBox)(target));
            
            #line 150 "..\..\..\..\..\UserControls\SettingsContent\UserSettings.xaml"
            this.UserPassword.TextChanged += new System.Windows.Controls.TextChangedEventHandler(this.UserPassword_TextChanged);
            
            #line default
            #line hidden
            return;
            case 5:
            this.NewPassword = ((HandyControl.Controls.TextBox)(target));
            return;
            case 6:
            this.UserPasswordHint = ((HandyControl.Controls.TextBox)(target));
            return;
            case 7:
            
            #line 201 "..\..\..\..\..\UserControls\SettingsContent\UserSettings.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.DelAccBtn_Click);
            
            #line default
            #line hidden
            return;
            case 8:
            this.CancelButton = ((System.Windows.Controls.Button)(target));
            
            #line 220 "..\..\..\..\..\UserControls\SettingsContent\UserSettings.xaml"
            this.CancelButton.Click += new System.Windows.RoutedEventHandler(this.CancelButton_Click);
            
            #line default
            #line hidden
            return;
            case 9:
            this.AcceptButton = ((System.Windows.Controls.Button)(target));
            
            #line 230 "..\..\..\..\..\UserControls\SettingsContent\UserSettings.xaml"
            this.AcceptButton.Click += new System.Windows.RoutedEventHandler(this.Accept_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

