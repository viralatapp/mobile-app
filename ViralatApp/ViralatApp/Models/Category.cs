using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace ViralatApp.Models
{
    public class Category:INotifyPropertyChanged
    {
        public Category(string name, string image)
        {
            Name = name;
            Image = image;
        }

        public string Name { get; set; }
        public string Image { get; set; }
        public bool IsSelected { get; set; }
        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
    
}
