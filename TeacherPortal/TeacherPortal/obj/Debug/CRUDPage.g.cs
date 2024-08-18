﻿#pragma checksum "..\..\CRUDPage.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "DC50BCE9097FE0B3D8DB04310C376EA62725882514A7225453BEBC3445D9819E"
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
using TeacherPortal;


namespace TeacherPortal {
    
    
    /// <summary>
    /// CRUDPage
    /// </summary>
    public partial class CRUDPage : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 10 "..\..\CRUDPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Grid subjectList;
        
        #line default
        #line hidden
        
        
        #line 30 "..\..\CRUDPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button addBookBtn;
        
        #line default
        #line hidden
        
        
        #line 31 "..\..\CRUDPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button addSubjectBtn;
        
        #line default
        #line hidden
        
        
        #line 32 "..\..\CRUDPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ListView bookListView;
        
        #line default
        #line hidden
        
        
        #line 43 "..\..\CRUDPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ListView subjectListView;
        
        #line default
        #line hidden
        
        
        #line 53 "..\..\CRUDPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button editBookBtn;
        
        #line default
        #line hidden
        
        
        #line 54 "..\..\CRUDPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button editSubjectBtn;
        
        #line default
        #line hidden
        
        
        #line 56 "..\..\CRUDPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button BookRemoveBtn;
        
        #line default
        #line hidden
        
        
        #line 57 "..\..\CRUDPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button SubjectRemoveBtn;
        
        #line default
        #line hidden
        
        
        #line 58 "..\..\CRUDPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox userId;
        
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
            System.Uri resourceLocater = new System.Uri("/TeacherPortal;component/crudpage.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\CRUDPage.xaml"
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
            this.subjectList = ((System.Windows.Controls.Grid)(target));
            return;
            case 2:
            this.addBookBtn = ((System.Windows.Controls.Button)(target));
            
            #line 30 "..\..\CRUDPage.xaml"
            this.addBookBtn.Click += new System.Windows.RoutedEventHandler(this.addBookBtn_Click);
            
            #line default
            #line hidden
            return;
            case 3:
            this.addSubjectBtn = ((System.Windows.Controls.Button)(target));
            
            #line 31 "..\..\CRUDPage.xaml"
            this.addSubjectBtn.Click += new System.Windows.RoutedEventHandler(this.addSubjectBtn_Click);
            
            #line default
            #line hidden
            return;
            case 4:
            this.bookListView = ((System.Windows.Controls.ListView)(target));
            return;
            case 5:
            this.subjectListView = ((System.Windows.Controls.ListView)(target));
            return;
            case 6:
            this.editBookBtn = ((System.Windows.Controls.Button)(target));
            
            #line 53 "..\..\CRUDPage.xaml"
            this.editBookBtn.Click += new System.Windows.RoutedEventHandler(this.editBookBtn_Click);
            
            #line default
            #line hidden
            return;
            case 7:
            this.editSubjectBtn = ((System.Windows.Controls.Button)(target));
            
            #line 54 "..\..\CRUDPage.xaml"
            this.editSubjectBtn.Click += new System.Windows.RoutedEventHandler(this.editSubjectBtn_Click);
            
            #line default
            #line hidden
            return;
            case 8:
            
            #line 55 "..\..\CRUDPage.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.LogOut_Click);
            
            #line default
            #line hidden
            return;
            case 9:
            this.BookRemoveBtn = ((System.Windows.Controls.Button)(target));
            
            #line 56 "..\..\CRUDPage.xaml"
            this.BookRemoveBtn.Click += new System.Windows.RoutedEventHandler(this.BookRemoveBtn_Click);
            
            #line default
            #line hidden
            return;
            case 10:
            this.SubjectRemoveBtn = ((System.Windows.Controls.Button)(target));
            
            #line 57 "..\..\CRUDPage.xaml"
            this.SubjectRemoveBtn.Click += new System.Windows.RoutedEventHandler(this.SubjectRemoveBtn_Click);
            
            #line default
            #line hidden
            return;
            case 11:
            this.userId = ((System.Windows.Controls.TextBox)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}

