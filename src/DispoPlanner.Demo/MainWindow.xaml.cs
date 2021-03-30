using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using DispoPlanner;

namespace DispoPlanner.Demo
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            Random random = new Random();

            planner.Start = new DateTime(2021, 2, 17, 0, 0, 0);
            planner.End   = new DateTime(2021, 2, 20, 23, 0, 0);

            for (int i = 0; i < 20; i++)
            {
                Entity entity = new Entity() { Name = "Entity" + i };

                DateTime date = planner.Start;

                for (int j = 0; j < 10; j++)
                {
                    Appointment appointment = new Appointment() { Subject = "Appointment" };
                    appointment.Start = date = date.AddHours(random.NextDouble() * 4);
                    appointment.End = date = date.AddHours((random.NextDouble() + 0.5) * 4);
                    if (j >= 4)
                        appointment.Style = AppointmentStyle.StyleColorLight;
                    else if (j >= 2)
                        appointment.Style = AppointmentStyle.StyleColorMid;
                    else
                        appointment.Style = AppointmentStyle.StyleColorDark;

                    entity.Appointments.Add(appointment);
                }
                entityGroup.Entities.Add(entity);
            }
        }
    }

    public class Entity : IPlannerEntity, INotifyPropertyChanged
    {
        private string _name;
        private ObservableCollection<IAppointment> _appointments = new ObservableCollection<IAppointment>();

        public event PropertyChangedEventHandler PropertyChanged;

        public string Name
        {
            get { return _name; }
            set { _name = value; OnPropertyChanged(); }
        }

        public ObservableCollection<IAppointment> Appointments
        {
            get { return _appointments; }
            set { _appointments = value; OnPropertyChanged(); }
        }

        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }

    public class Appointment : IAppointment, INotifyPropertyChanged
    {
        private DateTime _start;
        private DateTime _end;
        private string _subject;
        private AppointmentStyle _style;

        public event PropertyChangedEventHandler PropertyChanged;

        public DateTime Start
        {
            get { return _start; }
            set { _start = value; OnPropertyChanged(); }
        }

        public DateTime End
        {
            get { return _end; }
            set { _end = value; OnPropertyChanged(); }
        }

        public string Subject
        {
            get { return _subject; }
            set { _subject = value; OnPropertyChanged(); }
        }

        public AppointmentStyle Style
        {
            get { return _style; }
            set { _style = value; OnPropertyChanged(); }
        }

        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
