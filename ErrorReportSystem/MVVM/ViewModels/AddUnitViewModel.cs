using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using ErrorReportSystem.MVVM.Models;
using ErrorReportSystem.Services;
using System.Collections.ObjectModel;

namespace ErrorReportSystem.MVVM.ViewModels;

public partial class AddUnitViewModel : ObservableObject
{
    [ObservableProperty]
    private string pageTitle = "Add unit";

    [ObservableProperty]
    private ObservableCollection<Unit> units = UnitService.Units();

    [ObservableProperty]
    private Unit unit = new Unit();

    [RelayCommand]
    public void Add()
    {
        UnitService.SaveUnitAsync(unit);
        unit = new Unit();
    }
}

