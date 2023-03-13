using ErrorReportSystem.MVVM.Models;
using ErrorReportSystem.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ErrorReportSystem.MVVM.Views
{
    /// <summary>
    /// Interaction logic for AddResidentView.xaml
    /// </summary>
    public partial class AddResidentView : UserControl
    {
        public AddResidentView()
        {
            InitializeComponent();
        }

        private void btn_add_Click(object sender, RoutedEventArgs e)
        {
            ResidentService.SaveResidentAsync(new ResidentModel
            {
                FirstName = tb_firstName.Text,
                LastName = tb_lastName.Text,
                Email= tb_email.Text,
                PhoneNumber= tb_phoneNumber.Text,
                UnitId = int.Parse(tb_unitId.Text)

            });

            ClearForm();

        }

        private void ClearForm()
        {
            tb_firstName.Text = string.Empty;
            tb_lastName.Text = string.Empty;
            tb_email.Text = string.Empty;
            tb_phoneNumber.Text = string.Empty;
            tb_unitId.Text = string.Empty;
        }
    }
}
