using MonkeyFinder.Model;
using MonkeyFinder.Services;
using System.Collections.ObjectModel;
using System.Diagnostics;

namespace MonkeyFinder.ViewModel;
public partial class MonkeyViewModel : BaseViewModel
{
  private MonkeyService monkeyService = new();
  public ObservableCollection<Monkey> Monkeys { get; set; } = [];

  public Command GetMonkeysCommand { get; }

  public MonkeyViewModel(MonkeyService monkeyService)
  {
    Title = "Monkey Finder";
    this.monkeyService = monkeyService;
    GetMonkeysCommand = new Command(
      async () => await GetMonkeysAsync());
  }

  private async Task GetMonkeysAsync()
  {
    if (IsBusy)
      return;
    try
    {
      IsBusy = true;
      var monkeys = await monkeyService.GetMonkeys();

      if (monkeys.Count != 0)
        Monkeys.Clear();

      foreach (var monkey in monkeys)
        Monkeys.Add(monkey);
    }
    catch (Exception ex)
    {
      Debug.WriteLine($"Unable to get monkeys: {ex.Message}");
      await Shell.Current.DisplayAlert("Error", $"Unable to get monkeys: {ex.Message}", "OK");
    }
    finally
    {
      IsBusy = false;
    }
  }
}
