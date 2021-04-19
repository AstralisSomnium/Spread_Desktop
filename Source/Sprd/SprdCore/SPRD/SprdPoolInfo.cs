using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace SprdCore.SPRD
{
    public class SprdPoolInfo : INotifyPropertyChanged
    {
        public string _id { get; set; }
        
        string _pool_id;
        public string pool_id
        {
            get => _pool_id;
            set
            {
                _pool_id = value;
                OnPropertyChanged();
            }
        }
        public string wallet_id { get; set; }
        public decimal commited_ada { get; set; }
        public string commiter_email { get; set; }
        public DateTime timestamp { get; set; }
        public bool email_send { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;

        [Annotations.NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}