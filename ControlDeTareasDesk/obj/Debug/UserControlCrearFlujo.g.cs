﻿#pragma checksum "..\..\UserControlCrearFlujo.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "28E4ACA08A760AE2115F979E4846E4DBCB43801DDB226521B44E3A85B5448C90"
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
    /// UserControlCrearFlujo
    /// </summary>
    public partial class UserControlCrearFlujo : System.Windows.Controls.UserControl, System.Windows.Markup.IComponentConnector {
        
        
        #line 31 "..\..\UserControlCrearFlujo.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label lblProceso;
        
        #line default
        #line hidden
        
        
        #line 32 "..\..\UserControlCrearFlujo.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox cmbProceso;
        
        #line default
        #line hidden
        
        
        #line 33 "..\..\UserControlCrearFlujo.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label lblUnidad;
        
        #line default
        #line hidden
        
        
        #line 34 "..\..\UserControlCrearFlujo.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox cmbUnidad;
        
        #line default
        #line hidden
        
        
        #line 35 "..\..\UserControlCrearFlujo.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label lblTarea;
        
        #line default
        #line hidden
        
        
        #line 36 "..\..\UserControlCrearFlujo.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ListBox lstTareas;
        
        #line default
        #line hidden
        
        
        #line 37 "..\..\UserControlCrearFlujo.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label lblUsuario;
        
        #line default
        #line hidden
        
        
        #line 38 "..\..\UserControlCrearFlujo.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ListBox lstUsuarios;
        
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
            System.Uri resourceLocater = new System.Uri("/ControlDeTareasDesk;component/usercontrolcrearflujo.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\UserControlCrearFlujo.xaml"
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
            this.lblProceso = ((System.Windows.Controls.Label)(target));
            return;
            case 2:
            this.cmbProceso = ((System.Windows.Controls.ComboBox)(target));
            
            #line 32 "..\..\UserControlCrearFlujo.xaml"
            this.cmbProceso.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.cmbProceso_SelectionChanged);
            
            #line default
            #line hidden
            return;
            case 3:
            this.lblUnidad = ((System.Windows.Controls.Label)(target));
            return;
            case 4:
            this.cmbUnidad = ((System.Windows.Controls.ComboBox)(target));
            
            #line 34 "..\..\UserControlCrearFlujo.xaml"
            this.cmbUnidad.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.cmbUnidad_SelectionChanged);
            
            #line default
            #line hidden
            return;
            case 5:
            this.lblTarea = ((System.Windows.Controls.Label)(target));
            return;
            case 6:
            this.lstTareas = ((System.Windows.Controls.ListBox)(target));
            return;
            case 7:
            this.lblUsuario = ((System.Windows.Controls.Label)(target));
            return;
            case 8:
            this.lstUsuarios = ((System.Windows.Controls.ListBox)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}

