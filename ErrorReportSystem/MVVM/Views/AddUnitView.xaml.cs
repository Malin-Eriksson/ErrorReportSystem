using ErrorReportSystem.MVVM.Models;
using ErrorReportSystem.Services;
using System.Windows;
using System.Windows.Controls;

namespace ErrorReportSystem.MVVM.Views;

/// <summary>
/// Interaction logic for AddUnitView.xaml
/// </summary>
public partial class AddUnitView : UserControl
{
    public AddUnitView()
    {
        InitializeComponent();
    }

    private void btn_add_Click(object sender, RoutedEventArgs e)
    {
        UnitService.SaveUnitAsync(new UnitModel
        {
            Street = tb_street.Text,
            StreetNumber = tb_streetNumber.Text,
            ApartmentNo = tb_apartmentNo.Text,
            PostalCode = tb_postalCode.Text,
            City = tb_city.Text
        });

        ClearForm();

    }

    private void ClearForm()
    {

        tb_street.Text = string.Empty;
        tb_streetNumber.Text = string.Empty;
        tb_apartmentNo.Text = string.Empty;
        tb_postalCode.Text = string.Empty;
        tb_city.Text = string.Empty;
    }
}
