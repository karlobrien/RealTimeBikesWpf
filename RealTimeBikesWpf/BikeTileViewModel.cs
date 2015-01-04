using Common;
using Common.DataObjects;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace RealTimeBikesWpf
{
    public class BikeTileViewModel : INotifyPropertyChanged
    {
        public Model model = new Model();

        public BikeTileViewModel()
        {
            objCommand = new StartCommand(this);
        }

        public string Name
        {
            get { return model.station.Name; }
            set
            {
                model.station.Name = value;
                OnPropertyChanged("Name");
            }
        }

        public string AvailableBikes
        {
            get { return model.station.Available_Bikes; }
            set 
            { 
                model.station.Available_Bikes = value;
                OnPropertyChanged("AvailableBikes");
            }
        }

        public string AvailableBikeStands
        {
            get { return model.station.Available_Bike_Stands; }
            set
            {
                model.station.Available_Bike_Stands = value;
                OnPropertyChanged("AvailableBikeStands");
            }
        }

        public bool Banking
        {
            get { return model.station.Banking; }
            set
            {
                model.station.Banking = value;
                OnPropertyChanged("Banking");
            }
        }

        public string BikeStands
        {
            get { return model.station.Bike_Stands; }
            set
            {
                model.station.Bike_Stands = value;
                OnPropertyChanged("BikeStands");
            }
        }

        public string Address
        {
            get { return model.station.Address; }
            set
            {
                model.station.Address = value;
                OnPropertyChanged("Address");
            }
        }

        public DateTime LastUpdate
        {
            get { return model.station.TimeStamp; }
            set
            {
                model.station.TimeStamp = value;
                OnPropertyChanged("LastUpdate");
            }
        }

        private StartCommand objCommand;
        public ICommand btnStart
        {
            get
            {
                return objCommand;
            }
        }

        public async void GetStationData()
        {
            var walk = await model.GetStation("EXCISE WALK");
            ApplyUpdateToUi(walk);
        }

        private void ApplyUpdateToUi(Station walk)
        {
            Name = walk.Name;
            AvailableBikes = walk.Available_Bikes;
            AvailableBikeStands = walk.Available_Bike_Stands;
            Banking = walk.Banking;
            LastUpdate = walk.TimeStamp;
            BikeStands = walk.Bike_Stands;
            Address = walk.Address;
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

    }

    public class StartCommand : ICommand
    {
        private BikeTileViewModel _viewModel;
        public StartCommand(BikeTileViewModel view)
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
            _viewModel.GetStationData();
        }
    }
}
