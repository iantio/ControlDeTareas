﻿#pragma checksum "..\..\UserControlInicio.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "1197CA8C19C0C1D143838BAD4CC054B29E054948EE808A1343AEDD01BA4099FD"
//------------------------------------------------------------------------------
// <auto-generated>
//     Este código fue generado por una herramienta.
//     Versión de runtime:4.0.30319.42000
//
//     Los cambios en este archivo podrían causar un comportamiento incorrecto y se perderán si
//     se vuelve a generar el código.
// </auto-generated>
//------------------------------------------------------------------------------

using ControlDeTareasDesk;
using MaterialDesignThemes.Wpf;
using MaterialDesignThemes.Wpf.Converters;
using MaterialDesignThemes.Wpf.Transitions;
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


namespace ControlDeTareasDesk {
    
    
    /// <summary>
    /// UserControlInicio
    /// </summary>
    public partial class UserControlInicio : System.Windows.Controls.UserControl, System.Windows.Markup.IComponentConnector {
        
        
        #line 23 "..\..\UserControlInicio.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label lblTitle;
        
        #line default
        #line hidden
        
        
        #line 32 "..\..\UserControlInicio.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ProgressBar pbProgreso;
        
        #line default
        #line hidden
        
        
        #line 34 "..\..\UserControlInicio.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock tbProgreso;
        
        #line default
        #line hidden
        
        
        #line 35 "..\..\UserControlInicio.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DataGrid dgProgreso;
        
        #line default
        #line hidden
        
        
        #line 43 "..\..\UserControlInicio.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnRefrescar;
        
        #line default
        #line hidden
        
        
        #line 44 "..\..\UserControlInicio.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal MaterialDesignThemes.Wpf.PackIcon iconRefrescar;
        
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
            System.Uri resourceLocater = new System.Uri("/ControlDeTareasDesk;component/usercontrolinicio.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\UserControlInicio.xaml"
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
            this.lblTitle = ((System.Windows.Controls.Label)(target));
            return;
            case 2:
            this.pbProgreso = ((System.Windows.Controls.ProgressBar)(target));
            return;
            case 3:
            this.tbProgreso = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 4:
            this.dgProgreso = ((System.Windows.Controls.DataGrid)(target));
            return;
            case 5:
            this.btnRefrescar = ((System.Windows.Controls.Button)(target));
            
            #line 43 "..\..\UserControlInicio.xaml"
            this.btnRefrescar.Click += new System.Windows.RoutedEventHandler(this.btnRefrescar_Click);
            
            #line default
            #line hidden
            return;
            case 6:
            this.iconRefrescar = ((MaterialDesignThemes.Wpf.PackIcon)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}

