﻿#pragma checksum "..\..\..\..\..\UserControls\WorkplaceContent\MIDIList.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "95DA1A14006BA41A3E6EC149D65DBE30EDB4F71F"
//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан программой.
//     Исполняемая версия:4.0.30319.42000
//
//     Изменения в этом файле могут привести к неправильной работе и будут потеряны в случае
//     повторной генерации кода.
// </auto-generated>
//------------------------------------------------------------------------------

using FrootyLoops.UserControls.WorkplaceContent;
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


namespace FrootyLoops.UserControls.WorkplaceContent {
    
    
    /// <summary>
    /// MIDIList
    /// </summary>
    public partial class MIDIList : System.Windows.Controls.UserControl, System.Windows.Markup.IComponentConnector {
        
        
        #line 12 "..\..\..\..\..\UserControls\WorkplaceContent\MIDIList.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Grid MIDI;
        
        #line default
        #line hidden
        
        
        #line 19 "..\..\..\..\..\UserControls\WorkplaceContent\MIDIList.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ScrollViewer timeRulerScrollViewer;
        
        #line default
        #line hidden
        
        
        #line 33 "..\..\..\..\..\UserControls\WorkplaceContent\MIDIList.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ScrollViewer noteScrollViewer;
        
        #line default
        #line hidden
        
        
        #line 37 "..\..\..\..\..\UserControls\WorkplaceContent\MIDIList.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Grid NoteGrid;
        
        #line default
        #line hidden
        
        
        #line 40 "..\..\..\..\..\UserControls\WorkplaceContent\MIDIList.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ScrollViewer contentScrollViewer;
        
        #line default
        #line hidden
        
        
        #line 47 "..\..\..\..\..\UserControls\WorkplaceContent\MIDIList.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Grid DynamicGrid;
        
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
            System.Uri resourceLocater = new System.Uri("/FrootyLoops;component/usercontrols/workplacecontent/midilist.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\..\UserControls\WorkplaceContent\MIDIList.xaml"
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
            this.MIDI = ((System.Windows.Controls.Grid)(target));
            return;
            case 2:
            this.timeRulerScrollViewer = ((System.Windows.Controls.ScrollViewer)(target));
            
            #line 23 "..\..\..\..\..\UserControls\WorkplaceContent\MIDIList.xaml"
            this.timeRulerScrollViewer.ScrollChanged += new System.Windows.Controls.ScrollChangedEventHandler(this.OnScrollChanged);
            
            #line default
            #line hidden
            return;
            case 3:
            this.noteScrollViewer = ((System.Windows.Controls.ScrollViewer)(target));
            
            #line 36 "..\..\..\..\..\UserControls\WorkplaceContent\MIDIList.xaml"
            this.noteScrollViewer.ScrollChanged += new System.Windows.Controls.ScrollChangedEventHandler(this.OnScrollChanged);
            
            #line default
            #line hidden
            return;
            case 4:
            this.NoteGrid = ((System.Windows.Controls.Grid)(target));
            return;
            case 5:
            this.contentScrollViewer = ((System.Windows.Controls.ScrollViewer)(target));
            
            #line 44 "..\..\..\..\..\UserControls\WorkplaceContent\MIDIList.xaml"
            this.contentScrollViewer.ScrollChanged += new System.Windows.Controls.ScrollChangedEventHandler(this.OnScrollChanged);
            
            #line default
            #line hidden
            return;
            case 6:
            this.DynamicGrid = ((System.Windows.Controls.Grid)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}

