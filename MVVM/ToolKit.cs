using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace MVVM;
public class ToolKit : INotifyPropertyChanged //Base pour toutes les vm
{
    public event PropertyChangedEventHandler? PropertyChanged;

    public void OnPropertyChanged([CallerMemberName] string name = null)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
    }
}

