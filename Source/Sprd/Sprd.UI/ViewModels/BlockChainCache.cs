using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using JetBrains.Annotations;
using SprdCore.Cardano;

namespace Sprd.UI.ViewModels
{
    public class BlockChainCache : INotifyPropertyChanged
    {
        ObservableCollection<StakePool> _stakePools;

        public ObservableCollection<StakePool> StakePools
        {
            get
            {
                return _stakePools;
            }
            set
            {
                _stakePools = value;
                OnPropertyChanged();
            }
        }

        public DateTime CacheDate { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}