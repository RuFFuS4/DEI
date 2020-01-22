using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using XamarinForms10Days.Models;
using SQLite;

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
            // added using TenDaysOfXamarin.Model;
            Experience newExperience = new Experience()
            {
                Title = titleEntry.Text,
                Content = contentEditor.Text,
                CreatedAt = DateTime.Now,
                UpdatedAt = DateTime.Now
            };

            int insertedItems = 0;
            // added using SQLite;
            using (SQLiteConnection conn = new SQLiteConnection(App.DatabasePath))
            {
                conn.CreateTable<Experience>();
                insertedItems = conn.Insert(newExperience);
            }
            // here the conn has been disposed of, hence closed
            if (insertedItems > 0)
            {
                titleEntry.Text = string.Empty;
                contentEditor.Text = string.Empty;
            }
            else
            {
                DisplayAlert("Error", "There was an error inserting the Experience, please try again", "Ok");
            }
        }

        private void contentEntry_Clicked(object sender, EventArgs e)
        {

        }
    }
}
