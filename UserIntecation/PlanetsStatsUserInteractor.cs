﻿public class PlanetsStatsUserInteractor : IPlanetsStatsUserInteractor
{
    private readonly IUserInteractor _userInteractor;

    public PlanetsStatsUserInteractor(
        IUserInteractor userInteractor)
    {
        _userInteractor = userInteractor;
    }

    public void Show(IEnumerable<Planet> planets)
    {
        TablePrinter.Print(planets);
       
    }

    public void ShowMessage(string message)
    {
        _userInteractor.ShowMessage(message);
    }

    public string? ChooseStaticticsToBeShown(
        IEnumerable<string> propertiesThatCanBeChosen)
    {
        _userInteractor.ShowMessage(
            Environment.NewLine +
            "The statistics of which property would you " +
            "like to see?");
        _userInteractor.ShowMessage(
            string.Join(
                Environment.NewLine,
                propertiesThatCanBeChosen));

        return _userInteractor.ReadFromUser();
    }
}

public static class TablePrinter
{
    public static void Print<T>(IEnumerable<T> items)
    {
        const int columnWidth = 15;
        var properties = typeof(T).GetProperties();

        foreach (var property in properties)  
        {
            Console.Write($"{{0,-{columnWidth}}}|",property.Name);

        }
        Console.WriteLine();
        Console.WriteLine(new string('-',properties.Length*(columnWidth+1)));
        
        foreach (var item in items)
        {
            foreach (var property in properties)
            {
                Console.Write($"{{0,-{columnWidth}}}|", property.GetValue(item));
            }
            Console.WriteLine();
        }
    }

}
