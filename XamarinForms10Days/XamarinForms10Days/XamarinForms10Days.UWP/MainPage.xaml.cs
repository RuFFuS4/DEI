using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

namespace XamarinForms10Days.UWP
{
    public sealed partial class MainPage
    {
        public MainPage()
        {
            this.InitializeComponent();

            String dbName = "CustomersDb.db3";
            String personalFolder = System.Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            String libraryFolder = Path.Combine(personalFolder, "..", "Library");
            String path = Path.Combine(libraryFolder, dbName);
            LoadApplication(new XamarinForms10Days.App(path));
        }
    }
}
