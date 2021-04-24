using System.ComponentModel;
using System.Runtime.CompilerServices;
using SprdCore.Cardano;

namespace Sprd.UI.ViewModels
{
    public class SprdSelection : INotifyPropertyChanged
    {
        StakePool _pool;
        public StakePool Pool
        {
            get
            {
                return _pool;
            }
            set
            {
                _pool = value;
                OnPropertyChanged();
            }
        }

        Wallet _wallet;

        public Wallet Wallet
        {
            get
            {
                return _wallet;
            }
            set
            {
                _wallet = value;
                OnPropertyChanged();
            }
        }
        public string NotifyEmail { get; set; }


        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
}