﻿#pragma checksum "..\..\..\..\Views\MainWindow.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "D59DCBB2A447E57D08664E521635B8389A76D08A"
//------------------------------------------------------------------------------
// <auto-generated>
//     此代码由工具生成。
//     运行时版本:4.0.30319.42000
//
//     对此文件的更改可能会导致不正确的行为，并且如果
//     重新生成代码，这些更改将会丢失。
// </auto-generated>
//------------------------------------------------------------------------------

using MaterialDesignThemes.Wpf;
using MaterialDesignThemes.Wpf.Converters;
using MaterialDesignThemes.Wpf.Transitions;
using Prism.DryIoc;
using Prism.Interactivity;
using Prism.Interactivity.InteractionRequest;
using Prism.Mvvm;
using Prism.Regions;
using Prism.Regions.Behaviors;
using Prism.Services.Dialogs;
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
using System.Windows.Interactivity;
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


namespace ScriptGraphicHelper.Views {
    
    
    /// <summary>
    /// MainWindow
    /// </summary>
    public partial class MainWindow : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 1 "..\..\..\..\Views\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal ScriptGraphicHelper.Views.MainWindow _Window;
        
        #line default
        #line hidden
        
        
        #line 17 "..\..\..\..\Views\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Grid Panel_1;
        
        #line default
        #line hidden
        
        
        #line 18 "..\..\..\..\Views\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ScrollViewer Scroll;
        
        #line default
        #line hidden
        
        
        #line 20 "..\..\..\..\Views\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox EmulatorOptions;
        
        #line default
        #line hidden
        
        
        #line 35 "..\..\..\..\Views\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button ScreenShot;
        
        #line default
        #line hidden
        
        
        #line 36 "..\..\..\..\Views\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button Open;
        
        #line default
        #line hidden
        
        
        #line 37 "..\..\..\..\Views\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button Save;
        
        #line default
        #line hidden
        
        
        #line 38 "..\..\..\..\Views\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button TurnRight;
        
        #line default
        #line hidden
        
        
        #line 39 "..\..\..\..\Views\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button Test;
        
        #line default
        #line hidden
        
        
        #line 40 "..\..\..\..\Views\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox Sim;
        
        #line default
        #line hidden
        
        
        #line 54 "..\..\..\..\Views\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox Result;
        
        #line default
        #line hidden
        
        
        #line 61 "..\..\..\..\Views\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox Format;
        
        #line default
        #line hidden
        
        
        #line 84 "..\..\..\..\Views\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox Range;
        
        #line default
        #line hidden
        
        
        #line 90 "..\..\..\..\Views\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button Create;
        
        #line default
        #line hidden
        
        
        #line 91 "..\..\..\..\Views\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox ColorString;
        
        #line default
        #line hidden
        
        
        #line 97 "..\..\..\..\Views\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button Copy;
        
        #line default
        #line hidden
        
        
        #line 98 "..\..\..\..\Views\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button Clear;
        
        #line default
        #line hidden
        
        
        #line 104 "..\..\..\..\Views\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.StackPanel Panel_3;
        
        #line default
        #line hidden
        
        
        #line 106 "..\..\..\..\Views\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DataGrid Color_Info;
        
        #line default
        #line hidden
        
        
        #line 119 "..\..\..\..\Views\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal MaterialDesignThemes.Wpf.DataGridComboBoxColumn TheAnchors;
        
        #line default
        #line hidden
        
        
        #line 141 "..\..\..\..\Views\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Grid Panel_2;
        
        #line default
        #line hidden
        
        
        #line 142 "..\..\..\..\Views\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ScrollViewer Scroll_1;
        
        #line default
        #line hidden
        
        
        #line 143 "..\..\..\..\Views\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Image Img;
        
        #line default
        #line hidden
        
        
        #line 166 "..\..\..\..\Views\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.StackPanel Panel_4;
        
        #line default
        #line hidden
        
        
        #line 167 "..\..\..\..\Views\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Image Loupe;
        
        #line default
        #line hidden
        
        
        #line 175 "..\..\..\..\Views\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Shapes.Rectangle SelectRectangle;
        
        #line default
        #line hidden
        
        
        #line 177 "..\..\..\..\Views\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.StackPanel Panel_5;
        
        #line default
        #line hidden
        
        
        #line 178 "..\..\..\..\Views\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Image FindResult;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.8.1.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/ScriptGraphicHelper;component/views/mainwindow.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\Views\MainWindow.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.8.1.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            this._Window = ((ScriptGraphicHelper.Views.MainWindow)(target));
            
            #line 13 "..\..\..\..\Views\MainWindow.xaml"
            this._Window.Loaded += new System.Windows.RoutedEventHandler(this.Window_Loaded);
            
            #line default
            #line hidden
            
            #line 13 "..\..\..\..\Views\MainWindow.xaml"
            this._Window.SizeChanged += new System.Windows.SizeChangedEventHandler(this.Window_SizeChanged);
            
            #line default
            #line hidden
            
            #line 13 "..\..\..\..\Views\MainWindow.xaml"
            this._Window.PreviewKeyDown += new System.Windows.Input.KeyEventHandler(this.Window_PreviewKeyDown);
            
            #line default
            #line hidden
            return;
            case 2:
            this.Panel_1 = ((System.Windows.Controls.Grid)(target));
            return;
            case 3:
            this.Scroll = ((System.Windows.Controls.ScrollViewer)(target));
            return;
            case 4:
            this.EmulatorOptions = ((System.Windows.Controls.ComboBox)(target));
            return;
            case 5:
            this.ScreenShot = ((System.Windows.Controls.Button)(target));
            return;
            case 6:
            this.Open = ((System.Windows.Controls.Button)(target));
            return;
            case 7:
            this.Save = ((System.Windows.Controls.Button)(target));
            return;
            case 8:
            this.TurnRight = ((System.Windows.Controls.Button)(target));
            return;
            case 9:
            this.Test = ((System.Windows.Controls.Button)(target));
            return;
            case 10:
            this.Sim = ((System.Windows.Controls.ComboBox)(target));
            return;
            case 11:
            this.Result = ((System.Windows.Controls.TextBox)(target));
            return;
            case 12:
            this.Format = ((System.Windows.Controls.ComboBox)(target));
            return;
            case 13:
            this.Range = ((System.Windows.Controls.TextBox)(target));
            return;
            case 14:
            this.Create = ((System.Windows.Controls.Button)(target));
            return;
            case 15:
            this.ColorString = ((System.Windows.Controls.TextBox)(target));
            return;
            case 16:
            this.Copy = ((System.Windows.Controls.Button)(target));
            
            #line 97 "..\..\..\..\Views\MainWindow.xaml"
            this.Copy.Click += new System.Windows.RoutedEventHandler(this.Copy_Click);
            
            #line default
            #line hidden
            return;
            case 17:
            this.Clear = ((System.Windows.Controls.Button)(target));
            return;
            case 18:
            this.Panel_3 = ((System.Windows.Controls.StackPanel)(target));
            
            #line 104 "..\..\..\..\Views\MainWindow.xaml"
            this.Panel_3.SizeChanged += new System.Windows.SizeChangedEventHandler(this.Window_SizeChanged);
            
            #line default
            #line hidden
            return;
            case 19:
            this.Color_Info = ((System.Windows.Controls.DataGrid)(target));
            return;
            case 20:
            this.TheAnchors = ((MaterialDesignThemes.Wpf.DataGridComboBoxColumn)(target));
            return;
            case 21:
            
            #line 132 "..\..\..\..\Views\MainWindow.xaml"
            ((System.Windows.Controls.MenuItem)(target)).Click += new System.Windows.RoutedEventHandler(this.CopyPoint_Click);
            
            #line default
            #line hidden
            return;
            case 22:
            
            #line 133 "..\..\..\..\Views\MainWindow.xaml"
            ((System.Windows.Controls.MenuItem)(target)).Click += new System.Windows.RoutedEventHandler(this.CopyColor_Click);
            
            #line default
            #line hidden
            return;
            case 23:
            this.Panel_2 = ((System.Windows.Controls.Grid)(target));
            return;
            case 24:
            this.Scroll_1 = ((System.Windows.Controls.ScrollViewer)(target));
            return;
            case 25:
            this.Img = ((System.Windows.Controls.Image)(target));
            
            #line 144 "..\..\..\..\Views\MainWindow.xaml"
            this.Img.SizeChanged += new System.Windows.SizeChangedEventHandler(this.Window_SizeChanged);
            
            #line default
            #line hidden
            return;
            case 26:
            this.Panel_4 = ((System.Windows.Controls.StackPanel)(target));
            return;
            case 27:
            this.Loupe = ((System.Windows.Controls.Image)(target));
            return;
            case 28:
            this.SelectRectangle = ((System.Windows.Shapes.Rectangle)(target));
            return;
            case 29:
            this.Panel_5 = ((System.Windows.Controls.StackPanel)(target));
            
            #line 177 "..\..\..\..\Views\MainWindow.xaml"
            this.Panel_5.IsVisibleChanged += new System.Windows.DependencyPropertyChangedEventHandler(this.Panel_5_IsVisibleChanged);
            
            #line default
            #line hidden
            return;
            case 30:
            this.FindResult = ((System.Windows.Controls.Image)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}

