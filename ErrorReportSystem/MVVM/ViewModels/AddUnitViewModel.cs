using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using ErrorReportSystem.MVVM.Models;
using ErrorReportSystem.Services;
using System.Collections.ObjectModel;
using System.Windows;

namespace ErrorReportSystem.MVVM.ViewModels;

public partial class AddUnitViewModel : ObservableObject
{
    [ObservableProperty]
    private string pageTitle = "Add unit";

    [ObservableProperty]
    private ObservableCollection<Unit> units = UnitService.Units();


    [ObservableProperty]
    private Unit unit = new Unit();

    [ObservableProperty]
    private Unit selectedUnit = null!;



    [RelayCommand]
    public void Add()
    {
        UnitService.SaveUnitAsync(unit);
        unit = new Unit();
    }

    





/*    [RelayCommand]
    public void DeleteUnitAsync()
    {
        string mb_message = "Are you sure you want to delete this contact?";
        string mb_title = "Delete contact";
        MessageBoxButton buttons = MessageBoxButton.YesNo;
        MessageBoxImage mb_icon = MessageBoxImage.Question;
        MessageBoxResult result;


        result = MessageBox.Show(mb_message, mb_title, buttons, mb_icon, MessageBoxResult.Yes);

        if (result == MessageBoxResult.Yes)
        {
            UnitService.DeleteUnitAsync(SelectedUnit);
        }
        else { }

    }*/
}

