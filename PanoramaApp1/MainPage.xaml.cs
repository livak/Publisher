using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using Microsoft.Phone.Controls;

namespace PanoramaApp1
{
    public class NoParalaxTitleLayer : Microsoft.Phone.Controls.Primitives.PanningTitleLayer
    {
        protected override double PanRate
        {
            get { return 1d; }
        }
    }

    public class NoParalaxBackgroundLayer : Microsoft.Phone.Controls.Primitives.PanningBackgroundLayer
    {
        protected override double PanRate
        {
            get { return 1d; }
        }
    }

    public partial class MainPage : PhoneApplicationPage
    {
        // Constructor
        public MainPage()
        {
            InitializeComponent();
            
            // Set the data context of the listbox control to the sample data
            DataContext = App.ViewModel;
            this.Loaded += new RoutedEventHandler(MainPage_Loaded);
        }

        // Load data for the ViewModel Items
        private void MainPage_Loaded(object sender, RoutedEventArgs e)
        {

            //if (!App.ViewModel.IsDataLoaded)
            //{
            //    App.ViewModel.LoadData();
            //}
        }

        private void ListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            // If selected index is -1 (no selection) do nothing
            if (((ListBox)sender).SelectedIndex == -1)
                return;

            // Navigate to the new page
            NavigationService.Navigate(new Uri("/DetailsPage.xaml?selectedItem=" + ((ListBox)sender).SelectedIndex, UriKind.Relative));


            // Reset selected index to -1 (no selection)
            ((ListBox)sender).SelectedIndex = -1;

        }

        //private void ListBox_SelectionChanged_1(object sender, SelectionChangedEventArgs e)
        //{
        //    if (e.AddedItems.Count == 0)
        //        return;

        //    WpfClient.TerminalViewModel alarm = e.AddedItems[0] as WpfClient.TerminalViewModel;

        //    if (alarm.Acknowledged)
        //    {
        //        alarm.Acknowledged = false;
        //        MessageBox.Show("UnAcnowlaged");

        //    }
        //    else
        //    {
        //        alarm.Acknowledged = true;
        //        MessageBox.Show("Acnowlaged");

        //    }

        //}

        private void ListBox_DoubleTap(object sender, GestureEventArgs e)
        {
            
            // If selected index is -1 (no selection) do nothing
            if (((ListBox)sender).SelectedIndex == -1)
                return;

            WpfClient.TerminalViewModel alarm = ((ListBox)sender).SelectedItem as WpfClient.TerminalViewModel;
            if (alarm == null)
                return;
            if (alarm.Acknowledged)
            {
                alarm.Acknowledged = false;
            }
            else
            {
                alarm.Acknowledged = true;
            }



            // Reset selected index to -1 (no selection)
            ((ListBox)sender).SelectedIndex = -1;

        }
    }
}