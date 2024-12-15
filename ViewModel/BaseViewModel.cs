using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace MonkeyFinder.ViewModel;
public class BaseViewModel : INotifyPropertyChanged
{
  bool isBusy;
  //public bool IsBusy
  //{
  //  get => isBusy;
  //  set
  //  {
  //    if(isBusy == value)
  //      return;
  //    isBusy = value;
  //    // Notify the UI that the value has changed
  //    // compiler inserts the name of the property, but is still a string
  //    OnPropertyChanged(nameof(IsBusy));
  //  }
  //}
  public bool IsBusy
  {
    get => isBusy;
    set
    {
      if (isBusy == value)
        return;
      isBusy = value;
      // Notify the UI that the value has changed
      // compiler inserts the name of the property, but is still a string
      OnPropertyChanged();
      OnPropertyChanged(nameof(IsNotBusy));
    }
  }

  public bool IsNotBusy => !IsBusy;

  string title;
  public string Title
  {
    get => title;
    set
    {
      if (title == value)
        return;
      title = value;
      OnPropertyChanged();
    }
  }

  public event PropertyChangedEventHandler? PropertyChanged;

  /* this version uses string to get the member name which changed */
  //public void OnPropertyChanged(string name)
  //{
  //  PropertyChanged?.Invoke(
  //    this,
  //    new PropertyChangedEventArgs(name));

  //}
  public void OnPropertyChanged([CallerMemberName] string? name = null)
  {
    PropertyChanged?.Invoke(
      this,
      new PropertyChangedEventArgs(name));
  }
}