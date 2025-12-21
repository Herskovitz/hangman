using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace HangmanSystem
{
    public class Letter : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler? PropertyChanged;

        bool enabled = false;
        public string Text { get; set; }
        public bool Enabled
        {
            get => enabled;
            set
            {
                enabled = value;
                InvokePropertyChanged();
            }
        }
        private void InvokePropertyChanged([CallerMemberName] string propertyname = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyname));
        }
    }
}
