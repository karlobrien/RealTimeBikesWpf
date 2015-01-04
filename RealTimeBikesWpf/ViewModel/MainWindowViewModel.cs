using Common.DataObjects;
using RealTimeBikesWpf.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace RealTimeBikesWpf.ViewModel
{
    public class MainWindowViewModel : INotifyPropertyChanged
    {
        public StationModel bikeModel = new StationModel();

        public ObservableCollection<Station> Station
        {
            get { return bikeModel.AllStations; }
            set
            {
                bikeModel.AllStations = value;
                OnPropertyChanged("Station");
            }
        }

        private StartCommand startCommand;
        private StopCommand stopCommand;

        public MainWindowViewModel()
        {
            startCommand = new StartCommand(this);
            stopCommand = new StopCommand(this);
        }

        public async void GetBikeData()
        {
            Station = await bikeModel.GetAllStations();
        }

        public ICommand btnStart
        {
            get
            {
                return startCommand;
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged(string name)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(name));
            }
        }

        public class StartCommand : ICommand
        {
            private MainWindowViewModel _viewModel;
            public StartCommand(MainWindowViewModel view)
            {
                _viewModel = view;
            }

            public bool CanExecute(object parameter)
            {
                return true;
            }

            public event EventHandler CanExecuteChanged;

            public void Execute(object parameter)
            {
                _viewModel.GetBikeData();
            }
        }

        public class StopCommand : ICommand
        {
            private MainWindowViewModel _viewModel;
            public StopCommand(MainWindowViewModel view)
            {
                _viewModel = view;
            }

            public bool CanExecute(object parameter)
            {
                return true;
            }

            public event EventHandler CanExecuteChanged;

            public void Execute(object parameter)
            {
                //
            }
        }

    }
}
