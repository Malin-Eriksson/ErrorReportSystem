using ErrorReportSystem.MVVM.Models;
using ErrorReportSystem.Services;
using System.Windows;
using System.Windows.Controls;


namespace ErrorReportSystem.MVVM.Views
{
    /// <summary>
    /// Interaction logic for FaultReportView.xaml
    /// </summary>
    public partial class FaultReportView : UserControl
    {
        public FaultReportView()
        {
            InitializeComponent();
        }

        private void btn_add_Click(object sender, RoutedEventArgs e)
        {
            FaultReportService.SaveFaultReportAsync(new FaultReportModel
            {
                ResidentId = int.Parse(tb_residentId.Text),
                FaultDescription = tb_faultDescription.Text

            });

            ClearForm();

        }

        private void ClearForm()
        {
            tb_residentId.Text = string.Empty;
            tb_faultDescription.Text = string.Empty;
        }
    }
}
