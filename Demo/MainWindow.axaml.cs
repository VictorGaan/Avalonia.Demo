using Avalonia.Controls;
using Avalonia.Interactivity;
using Demo.Helpers;
using System.Linq;

namespace Demo
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            LoadData();
        }
        public void LoadData()
        {
            var events = Helper.GetContext().Events.ToList();
            var selectedDateStart = DateStart.SelectedDate;
            var selectedDateFinish = DateFinish.SelectedDate;
            if (selectedDateFinish is not null && selectedDateStart is not null)
            {
                events = events.Where(x => x.Date > selectedDateStart && x.Date < selectedDateFinish).ToList();
            }

            EventsGrid.Items = events;
        }

        private void DateStart_OnSelectedDateChanged(object sender, DatePickerSelectedValueChangedEventArgs e)
        {
            LoadData();
        }

        private void DateFinish_OnSelectedDateChanged(object sender, DatePickerSelectedValueChangedEventArgs e)
        {
            LoadData();
        }

        private void BtnAuth_OnClick(object sender, RoutedEventArgs e)
        {
            new AuthWindow().ShowDialog(this);
        }
    }
}