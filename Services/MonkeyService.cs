using MonkeyFinder.Model;
using System.Net.Http.Json;

namespace MonkeyFinder.Services;
public class MonkeyService
{
  public const string URL = "https://montemagno.com/monkeys.json";
  HttpClient client;
  public MonkeyService()
  {
    client = new();
  }
  List<Monkey> monkeyList = [];
  public async Task<List<Monkey>> GetMonkeys()
  {
    if (monkeyList.Count > 0)
    {
      return monkeyList;
    }

    var response = await client.GetAsync(URL);

    if (response.IsSuccessStatusCode)
    {
      var monkeys = await response.Content.ReadFromJsonAsync<List<Monkey>>();
      if (monkeys != null)
      {
        monkeyList = monkeys;
      }
    }

    return monkeyList;
  }
}
