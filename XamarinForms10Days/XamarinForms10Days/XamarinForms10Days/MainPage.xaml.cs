using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace XamarinForms10Days
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }
        private void CheckIfShouldBeEnabled()
        {
            saveButton.IsEnabled = false;
            if (!string.IsNullOrWhiteSpace(titleEntry.Text) && !string.IsNullOrWhiteSpace(contentEditor.Text))
                saveButton.IsEnabled = true;
        }
        void TitleEntry_TextChanged(object sender, Xamarin.Forms.TextChangedEventArgs e)
        {
            CheckIfShouldBeEnabled();
        }

        void ContentEditor_TextChanged(object sender, Xamarin.Forms.TextChangedEventArgs e)
        {
            CheckIfShouldBeEnabled();
        }

        private void saveButton_Clicked(object sender, EventArgs e)
        {
            titleEntry.Text = string.Empty;
            contentEditor.Text = string.Empty;
        }

        private void contentEntry_Clicked(object sender, EventArgs e)
        {

        }
    }
}
