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
    public class BikeGridViewModel : INotifyPropertyChanged
    {
        public StationModel model = new StationModel();

        public ObservableCollection<Station> Station
         {
             get { return model.AllStations; }
             set { 
                    model.AllStations = value;
                    OnPropertyChanged("Station");
                 }
        }

        private StartCommand startCommand;
        private StopCommand stopCommand;
        public BikeGridViewModel()
        {
            startCommand = new StartCommand(this);
            stopCommand = new StopCommand(this);
        }

        public ICommand btnStart
        {
            get
            {
                return startCommand;
            }
        }

        public ICommand btnStop
        {
            get
            {
                return stopCommand;
            }
        }

        public async void GetBikeData()
        {
            Station = await model.GetAllStations();
        }

        public event PropertyChangedEventHandler PropertyChanged;

        // Create the OnPropertyChanged method to raise the event 
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
            private BikeGridViewModel _bikeGridViewModel;
            public StartCommand(BikeGridViewModel view)
            {
                _bikeGridViewModel = view;
            }

            public bool CanExecute(object parameter)
            {
                return true;
            }

            public event EventHandler CanExecuteChanged;

            public void Execute(object parameter)
            {
                _bikeGridViewModel.GetBikeData();
            }
        }

        public class StopCommand : ICommand
        {
            private BikeGridViewModel _bikeGridViewModel;
            public StopCommand(BikeGridViewModel view)
            {
                _bikeGridViewModel = view;
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
