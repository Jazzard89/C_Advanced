﻿#pragma checksum "..\..\AddBird.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "1DF2C85BD4E86863F67415C62676CFC232AE6FA019B592FC77D8C89AE5CB454A"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using Pandapark_OrensJasper;
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


namespace Pandapark_OrensJasper {
    
    
    /// <summary>
    /// AddBird
    /// </summary>
    public partial class AddBird : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 33 "..\..\AddBird.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox TextBoxName;
        
        #line default
        #line hidden
        
        
        #line 36 "..\..\AddBird.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox TextBoxType;
        
        #line default
        #line hidden
        
        
        #line 40 "..\..\AddBird.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.CheckBox CheckBoxDanger;
        
        #line default
        #line hidden
        
        
        #line 45 "..\..\AddBird.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox ComboBoxDiet;
        
        #line default
        #line hidden
        
        
        #line 54 "..\..\AddBird.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox ComboBoxGender;
        
        #line default
        #line hidden
        
        
        #line 61 "..\..\AddBird.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox TextBoxCountry;
        
        #line default
        #line hidden
        
        
        #line 65 "..\..\AddBird.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DatePicker DatePickerBirth;
        
        #line default
        #line hidden
        
        
        #line 70 "..\..\AddBird.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox ComboBoxNestType;
        
        #line default
        #line hidden
        
        
        #line 80 "..\..\AddBird.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox TextBoxWingSpan;
        
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
            System.Uri resourceLocater = new System.Uri("/Pandapark_OrensJasper;component/addbird.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\AddBird.xaml"
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
            this.TextBoxName = ((System.Windows.Controls.TextBox)(target));
            return;
            case 2:
            this.TextBoxType = ((System.Windows.Controls.TextBox)(target));
            return;
            case 3:
            this.CheckBoxDanger = ((System.Windows.Controls.CheckBox)(target));
            return;
            case 4:
            this.ComboBoxDiet = ((System.Windows.Controls.ComboBox)(target));
            return;
            case 5:
            this.ComboBoxGender = ((System.Windows.Controls.ComboBox)(target));
            return;
            case 6:
            this.TextBoxCountry = ((System.Windows.Controls.TextBox)(target));
            return;
            case 7:
            this.DatePickerBirth = ((System.Windows.Controls.DatePicker)(target));
            return;
            case 8:
            this.ComboBoxNestType = ((System.Windows.Controls.ComboBox)(target));
            return;
            case 9:
            this.TextBoxWingSpan = ((System.Windows.Controls.TextBox)(target));
            return;
            case 10:
            
            #line 82 "..\..\AddBird.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.AddBird_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

