﻿#pragma checksum "..\..\..\MainWindow.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "C6D13945EA4B37D3739F065D51B6606425037127"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using SCTUpdater;
using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Controls.Ribbon;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Forms.Integration;
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


namespace SCTUpdater {
    
    
    /// <summary>
    /// MainWindow
    /// </summary>
    public partial class MainWindow : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 116 "..\..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button PathButton;
        
        #line default
        #line hidden
        
        
        #line 150 "..\..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.CheckBox EdggNameCidCheckBox;
        
        #line default
        #line hidden
        
        
        #line 154 "..\..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.CheckBox EdggPasswordCheckBox;
        
        #line default
        #line hidden
        
        
        #line 159 "..\..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.CheckBox EdggPasswordCpdlc;
        
        #line default
        #line hidden
        
        
        #line 164 "..\..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.CheckBox EdggHdgDrawToolCheckBox;
        
        #line default
        #line hidden
        
        
        #line 173 "..\..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button EdggButtonProcessStart;
        
        #line default
        #line hidden
        
        
        #line 231 "..\..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox NameTextBox;
        
        #line default
        #line hidden
        
        
        #line 238 "..\..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox CidTextBox;
        
        #line default
        #line hidden
        
        
        #line 245 "..\..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox PasswordTextBox;
        
        #line default
        #line hidden
        
        
        #line 252 "..\..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox CpdlcTextBox;
        
        #line default
        #line hidden
        
        
        #line 292 "..\..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock DebugBox;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "7.0.7.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/SCTUpdater;component/mainwindow.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\MainWindow.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "7.0.7.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            
            #line 52 "..\..\..\MainWindow.xaml"
            ((System.Windows.Shapes.Rectangle)(target)).MouseLeftButtonDown += new System.Windows.Input.MouseButtonEventHandler(this.UIElement_OnMouseLeftButtonDown);
            
            #line default
            #line hidden
            return;
            case 2:
            
            #line 57 "..\..\..\MainWindow.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.ExitButton);
            
            #line default
            #line hidden
            return;
            case 3:
            this.PathButton = ((System.Windows.Controls.Button)(target));
            
            #line 118 "..\..\..\MainWindow.xaml"
            this.PathButton.Click += new System.Windows.RoutedEventHandler(this.folderButton);
            
            #line default
            #line hidden
            return;
            case 4:
            this.EdggNameCidCheckBox = ((System.Windows.Controls.CheckBox)(target));
            return;
            case 5:
            this.EdggPasswordCheckBox = ((System.Windows.Controls.CheckBox)(target));
            return;
            case 6:
            this.EdggPasswordCpdlc = ((System.Windows.Controls.CheckBox)(target));
            return;
            case 7:
            this.EdggHdgDrawToolCheckBox = ((System.Windows.Controls.CheckBox)(target));
            return;
            case 8:
            this.EdggButtonProcessStart = ((System.Windows.Controls.Button)(target));
            
            #line 175 "..\..\..\MainWindow.xaml"
            this.EdggButtonProcessStart.Click += new System.Windows.RoutedEventHandler(this.EdggButtonProcessStart_Click);
            
            #line default
            #line hidden
            return;
            case 9:
            this.NameTextBox = ((System.Windows.Controls.TextBox)(target));
            return;
            case 10:
            this.CidTextBox = ((System.Windows.Controls.TextBox)(target));
            return;
            case 11:
            this.PasswordTextBox = ((System.Windows.Controls.TextBox)(target));
            return;
            case 12:
            this.CpdlcTextBox = ((System.Windows.Controls.TextBox)(target));
            return;
            case 13:
            
            #line 261 "..\..\..\MainWindow.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.SaveCredsButton);
            
            #line default
            #line hidden
            return;
            case 14:
            this.DebugBox = ((System.Windows.Controls.TextBlock)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}

