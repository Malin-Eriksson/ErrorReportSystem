using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using ErrorReportSystem.MVVM.Models;
using ErrorReportSystem.Services;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;

namespace ErrorReportSystem.MVVM.ViewModels;

public partial class FaultReportViewModel : ObservableObject
{
    [ObservableProperty]
    private string pageTitle = "Add FaultReport";

    [ObservableProperty]
    private FaultReportModel faultReport = new FaultReportModel();



    public FaultReportViewModel()
    {
        LoadFaultReportsAsync();
    }


    [ObservableProperty]
    private ObservableCollection<FaultReportModel> faultReportList;


    public void LoadFaultReportsAsync()
    {
        IEnumerable<FaultReportModel> _faultReports = Task.Run(async () => await FaultReportService.GetAllFaultReportsAsync()).Result;
        FaultReportList = new ObservableCollection<FaultReportModel>(_faultReports);
    }

    [RelayCommand]
    public async Task Add()
    {
        await FaultReportService.SaveFaultReportAsync(FaultReport);
        foreach (var item in FaultReportService.FaultReports())
            FaultReportList.Add(item);

        FaultReport = new FaultReportModel();
    }


    [ObservableProperty]
    private FaultReportModel selectedFaultReport = null!;


    [RelayCommand]
    public async Task DeleteFaultReport()
    {
        await FaultReportService.DeleteFaultReportAsync(SelectedFaultReport.Id);
    }

}
