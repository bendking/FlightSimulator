﻿using FlightSimulator.Model;
using FlightSimulator.Model.Interface;
using FlightSimulator.Views;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
namespace FlightSimulator.ViewModels
{
    public class FlightBoardViewModel : BaseNotify
    {
        private FlightBoardModel model;

        // This ViewModel seems to be a middle-man and nothing more.
        // Oh well, just following the MVVM model...
        public FlightBoardViewModel(FlightBoardModel _model)
        {
            model = _model;
            // Add ViewModel as observer for property changes
            model.PropertyChanged += delegate(object sender, PropertyChangedEventArgs e)
            { NotifyPropertyChanged(e.PropertyName); };
        }

        private ICommand _openSettings;
        public ICommand OpenSettings
        {
            get
            {
                return _openSettings ?? (_openSettings = new CommandHandler(() => OnClick()));
            }
        }
        private void OnClick()
        {
            SettingsWindow settings = new SettingsWindow();
            settings.Show();
        }

        private ICommand _connect;
        public ICommand ConnectCommand
        {
            get
            {
                return _connect ?? (_connect = new CommandHandler(() => OnClick2()));
            }
        }
        private void OnClick2()
        {
            HostAndConnect();

        }

        public double Lat
        {
            get { return model.Lat; }
        }

        public double Lon
        {
            get { return model.Lon; }
        }

        public void HostAndConnect()
        {
            model.HostAndConnect();
        }

        public void Host()
        {
            model.Host();
        }

        public void Connect()
        {
            model.Connect();
        }

        public void ParseValues()
        {
            model.ParseValues();
        }



    }
}
