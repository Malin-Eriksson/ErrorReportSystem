using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using ErrorReportSystem.MVVM.Models;
using ErrorReportSystem.Services;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;

namespace ErrorReportSystem.MVVM.ViewModels;

public partial class AddUnitViewModel : ObservableObject
{

    [ObservableProperty]
    private string pageTitle = "Add unit";

    [ObservableProperty]
    private UnitModel unit = new UnitModel();



    public AddUnitViewModel()
    {
        LoadUnitsAsync();
    }


    [ObservableProperty]
    private ObservableCollection<UnitModel> unitList;             


    public void LoadUnitsAsync()
    {
        IEnumerable<UnitModel> _units = Task.Run(async () => await UnitService.GetAllUnitsAsync()).Result;
        UnitList = new ObservableCollection<UnitModel>(_units);
    }



    [RelayCommand]
    public async Task Add()
    {
        await UnitService.SaveUnitAsync(Unit);
        foreach (var item in UnitService.Units())
            /*foreach (var item in await UnitService.GetAllUnitsAsync());*/
            UnitList.Add(item);

        Unit = new UnitModel();
    }

    [ObservableProperty]
    public UnitModel selectedUnit = null!;


       [RelayCommand]
       public async Task DeleteUnit()
       {
        await UnitService.DeleteUnitAsync(SelectedUnit.Id);
       }



/*    [RelayCommand]
    public async Task DeleteUnitAsync()
    {
        string mb_message = "Are you sure you want to delete this unit?";
        string mb_title = "Delete unit";
        MessageBoxButton buttons = MessageBoxButton.YesNo;
        MessageBoxImage mb_icon = MessageBoxImage.Question;
        MessageBoxResult result;


        result = MessageBox.Show(mb_message, mb_title, buttons, mb_icon, MessageBoxResult.Yes);

        if (result == MessageBoxResult.Yes)
        {
            await UnitService.DeleteUnitAsync(SelectedUnit.Id);
        }
        else { }

    }*/
}

