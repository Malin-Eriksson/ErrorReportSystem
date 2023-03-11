﻿using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using ErrorReportSystem.MVVM.Models;
using ErrorReportSystem.Services;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows;

namespace ErrorReportSystem.MVVM.ViewModels;

public partial class AddUnitViewModel : ObservableObject
{

    public AddUnitViewModel()
    {
        LoadUnitsAsync();
    }


    public async Task LoadUnitsAsync()
    {
        await UnitService.GetAllUnitsAsync();
    }




    [ObservableProperty]
    private string pageTitle = "Add unit";

    [ObservableProperty]
    private ObservableCollection<UnitModel> units = UnitService.Units();


    [ObservableProperty]
    private UnitModel unit = new UnitModel();

    [ObservableProperty]
    private UnitModel selectedUnit = null!;

    [RelayCommand]
    public async Task Add()
    {
        await UnitService.SaveUnitAsync(Unit); 
        foreach (var item in UnitService.Units()) 
            Units.Add(item);

        Unit = new UnitModel();
    }



    /*    [RelayCommand]
        public async Task Add()
        {
            await UnitService.SaveUnitAsync(Unit);
            Unit = new UnitModel();
        }*/







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

