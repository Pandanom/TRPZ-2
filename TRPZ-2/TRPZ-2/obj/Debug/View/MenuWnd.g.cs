﻿#pragma checksum "..\..\..\View\MenuWnd.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "AC81E69C6B1A07337BF7A3BC88A1F775BE3D03D6"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
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
using TRPZ_2.View;


namespace TRPZ_2.View {
    
    
    /// <summary>
    /// MenuWindow
    /// </summary>
    public partial class MenuWindow : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 27 "..\..\..\View\MenuWnd.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button InfoNavBtn;
        
        #line default
        #line hidden
        
        
        #line 43 "..\..\..\View\MenuWnd.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button ParkNavBtn;
        
        #line default
        #line hidden
        
        
        #line 59 "..\..\..\View\MenuWnd.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button CarManageNavBtn;
        
        #line default
        #line hidden
        
        
        #line 75 "..\..\..\View\MenuWnd.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button AdminMenuNavBtn;
        
        #line default
        #line hidden
        
        
        #line 91 "..\..\..\View\MenuWnd.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Shapes.Rectangle AnimRec;
        
        #line default
        #line hidden
        
        
        #line 94 "..\..\..\View\MenuWnd.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Media.RotateTransform noFreeze;
        
        #line default
        #line hidden
        
        
        #line 128 "..\..\..\View\MenuWnd.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Media.Animation.DoubleAnimation RotateAnim;
        
        #line default
        #line hidden
        
        
        #line 139 "..\..\..\View\MenuWnd.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label AnimLbl;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/TRPZ-2;component/view/menuwnd.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\View\MenuWnd.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            this.InfoNavBtn = ((System.Windows.Controls.Button)(target));
            
            #line 27 "..\..\..\View\MenuWnd.xaml"
            this.InfoNavBtn.Click += new System.Windows.RoutedEventHandler(this.InfoNavBtn_Click);
            
            #line default
            #line hidden
            return;
            case 2:
            this.ParkNavBtn = ((System.Windows.Controls.Button)(target));
            
            #line 43 "..\..\..\View\MenuWnd.xaml"
            this.ParkNavBtn.Click += new System.Windows.RoutedEventHandler(this.ParkNavBtn_Click);
            
            #line default
            #line hidden
            return;
            case 3:
            this.CarManageNavBtn = ((System.Windows.Controls.Button)(target));
            
            #line 59 "..\..\..\View\MenuWnd.xaml"
            this.CarManageNavBtn.Click += new System.Windows.RoutedEventHandler(this.CarManageNavBtn_Click);
            
            #line default
            #line hidden
            return;
            case 4:
            this.AdminMenuNavBtn = ((System.Windows.Controls.Button)(target));
            
            #line 75 "..\..\..\View\MenuWnd.xaml"
            this.AdminMenuNavBtn.Click += new System.Windows.RoutedEventHandler(this.AdminMenuNavBtn_Click);
            
            #line default
            #line hidden
            return;
            case 5:
            this.AnimRec = ((System.Windows.Shapes.Rectangle)(target));
            return;
            case 6:
            this.noFreeze = ((System.Windows.Media.RotateTransform)(target));
            return;
            case 7:
            this.RotateAnim = ((System.Windows.Media.Animation.DoubleAnimation)(target));
            return;
            case 8:
            this.AnimLbl = ((System.Windows.Controls.Label)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}

