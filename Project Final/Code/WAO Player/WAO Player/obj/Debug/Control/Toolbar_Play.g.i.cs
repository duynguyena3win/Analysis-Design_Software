﻿#pragma checksum "..\..\..\Control\Toolbar_Play.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "D5E429CF060326DFCE4D1396384CA37A"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.36241
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


namespace WAO_Player.Control {
    
    
    /// <summary>
    /// Toolbar_Play
    /// </summary>
    public partial class Toolbar_Play : System.Windows.Controls.UserControl, System.Windows.Markup.IComponentConnector {
        
        
        #line 30 "..\..\..\Control\Toolbar_Play.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button Button_Previous;
        
        #line default
        #line hidden
        
        
        #line 31 "..\..\..\Control\Toolbar_Play.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button Button_Play;
        
        #line default
        #line hidden
        
        
        #line 32 "..\..\..\Control\Toolbar_Play.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button Button_Next;
        
        #line default
        #line hidden
        
        /// <summary>
        /// Check_Again Name Field
        /// </summary>
        
        #line 33 "..\..\..\Control\Toolbar_Play.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        public System.Windows.Controls.CheckBox Check_Again;
        
        #line default
        #line hidden
        
        /// <summary>
        /// Check_Round Name Field
        /// </summary>
        
        #line 85 "..\..\..\Control\Toolbar_Play.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        public System.Windows.Controls.CheckBox Check_Round;
        
        #line default
        #line hidden
        
        
        #line 141 "..\..\..\Control\Toolbar_Play.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.CheckBox Check_SameAgain;
        
        #line default
        #line hidden
        
        
        #line 213 "..\..\..\Control\Toolbar_Play.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.CheckBox Check_Lyric;
        
        #line default
        #line hidden
        
        
        #line 274 "..\..\..\Control\Toolbar_Play.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Slider Slider_Volumne;
        
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
            System.Uri resourceLocater = new System.Uri("/WAO Player;component/control/toolbar_play.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\Control\Toolbar_Play.xaml"
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
            
            #line 7 "..\..\..\Control\Toolbar_Play.xaml"
            ((WAO_Player.Control.Toolbar_Play)(target)).Loaded += new System.Windows.RoutedEventHandler(this.UserControl_Loaded);
            
            #line default
            #line hidden
            return;
            case 2:
            this.Button_Previous = ((System.Windows.Controls.Button)(target));
            
            #line 30 "..\..\..\Control\Toolbar_Play.xaml"
            this.Button_Previous.Click += new System.Windows.RoutedEventHandler(this.Button_Previous_Click);
            
            #line default
            #line hidden
            return;
            case 3:
            this.Button_Play = ((System.Windows.Controls.Button)(target));
            
            #line 31 "..\..\..\Control\Toolbar_Play.xaml"
            this.Button_Play.Click += new System.Windows.RoutedEventHandler(this.Button_Play_Click);
            
            #line default
            #line hidden
            return;
            case 4:
            this.Button_Next = ((System.Windows.Controls.Button)(target));
            
            #line 32 "..\..\..\Control\Toolbar_Play.xaml"
            this.Button_Next.Click += new System.Windows.RoutedEventHandler(this.Button_Next_Click);
            
            #line default
            #line hidden
            return;
            case 5:
            this.Check_Again = ((System.Windows.Controls.CheckBox)(target));
            return;
            case 6:
            this.Check_Round = ((System.Windows.Controls.CheckBox)(target));
            return;
            case 7:
            this.Check_SameAgain = ((System.Windows.Controls.CheckBox)(target));
            
            #line 143 "..\..\..\Control\Toolbar_Play.xaml"
            this.Check_SameAgain.Checked += new System.Windows.RoutedEventHandler(this.Check_SameAgain_Checked);
            
            #line default
            #line hidden
            
            #line 143 "..\..\..\Control\Toolbar_Play.xaml"
            this.Check_SameAgain.Unchecked += new System.Windows.RoutedEventHandler(this.Check_SameAgain_Unchecked);
            
            #line default
            #line hidden
            return;
            case 8:
            this.Check_Lyric = ((System.Windows.Controls.CheckBox)(target));
            
            #line 215 "..\..\..\Control\Toolbar_Play.xaml"
            this.Check_Lyric.Unchecked += new System.Windows.RoutedEventHandler(this.Check_Lyric_Unchecked);
            
            #line default
            #line hidden
            
            #line 215 "..\..\..\Control\Toolbar_Play.xaml"
            this.Check_Lyric.Checked += new System.Windows.RoutedEventHandler(this.Check_Lyric_Checked);
            
            #line default
            #line hidden
            return;
            case 9:
            this.Slider_Volumne = ((System.Windows.Controls.Slider)(target));
            
            #line 275 "..\..\..\Control\Toolbar_Play.xaml"
            this.Slider_Volumne.ValueChanged += new System.Windows.RoutedPropertyChangedEventHandler<double>(this.Slider_Volumne_ValueChanged);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}
