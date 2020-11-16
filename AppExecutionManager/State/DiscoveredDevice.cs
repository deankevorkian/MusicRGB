﻿using Common;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Utils;

namespace AppExecutionManager.State
{
    public class DiscoveredDevice : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private bool isChecked;


        public DeviceMetadata Device { get; set; }

        public bool IsChecked
        {
            get => isChecked;
            set
            {
                isChecked = value;
                NotifyPropertyChangedUtils.OnPropertyChanged(PropertyChanged, this);
            }
        }
    }
}
