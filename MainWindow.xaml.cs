using AgencyManager.Components;
using AgencyManager.DatabaseContext;
using AgencyManager.Models;
using Microsoft.EntityFrameworkCore;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace AgencyManager
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly AppDbContext _dbContext;
        private readonly AgencyListBox _agencyListBox;

        public MainWindow()
        {
            InitializeComponent();
            _dbContext = new();
            _agencyListBox = new(this)
            {
                Width = 350,
                Height = 350
            };

            Canvas.SetTop(_agencyListBox, 15);
            Canvas.SetLeft(_agencyListBox, 15);
        }

        private async Task AtualizarControles()
        {
            Container.Children.Add(_agencyListBox);

            _agencyListBox.Items.Clear();
            var agencies = await _dbContext.Agencies.ToListAsync();

            foreach (var agency in agencies)
                _agencyListBox.Items.Add(agency);
        }

        private async void Window_Loaded(object sender, RoutedEventArgs e)
            => await AtualizarControles();

        private async void BtnExcluir_Click(object sender, RoutedEventArgs e)
        {
            Agency selectedAgency = _agencyListBox.SelectedAgency;

            if (selectedAgency is null)
                return;

            MessageBoxResult result = MessageBox.Show("Você deseja realmente excluir este item?", "Confirmação", MessageBoxButton.YesNo);

            if (!result.Equals(MessageBoxResult.Yes))
                return;

            _dbContext.Remove(selectedAgency);
            await _dbContext.SaveChangesAsync();

            MessageBox.Show("Agência excluída com sucesso", "Aviso", MessageBoxButton.OK);

            await AtualizarControles();
        }
    }
}