using AgencyManager.Models;
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
using System.Windows.Shapes;

namespace AgencyManager.Views
{
    /// <summary>
    /// Lógica interna para EditAgency.xaml
    /// </summary>
    public partial class EditAgency : Window
    {
        private readonly Agency _agency;

        public EditAgency(Agency agency)
        {
            InitializeComponent();
            _agency = agency ?? throw new ArgumentNullException(nameof(agency));
            UpdateControls();
            BindCommands();
        }

        private void UpdateControls()
        {
            TxtNome.Text = _agency.Nome;
            TxtDescricao.Text = _agency.Descricao;
            TxtEndereco.Text = _agency.Endereco;
            TxtNumero.Text = _agency.Numero;
            TxtTelefone.Text = _agency.Telefone;
        }

        private void BindCommands()
        {
            RoutedEventHandler dialogResultTrue = (sender, e) => DialogResult = true;
            RoutedEventHandler dialogResultFalse = (sender, e) => DialogResult = false;

            RoutedEventHandler okEventHandler = dialogResultTrue + CloseWindow;
            RoutedEventHandler cancelEventHandler = dialogResultFalse + CloseWindow;

            BtnOk.Click += okEventHandler;
            BtnCancelar.Click += cancelEventHandler;

            TxtNumero.TextChanged += NullInputValidator_TextChanged;
            TxtNumero.TextChanged += NumberInputValidator_TextChanged;

            TxtNome.TextChanged += NullInputValidator_TextChanged;
            TxtDescricao.TextChanged += NullInputValidator_TextChanged;
            TxtEndereco.TextChanged += NullInputValidator_TextChanged;
            TxtTelefone.TextChanged += NullInputValidator_TextChanged;
        }

        private void NumberInputValidator_TextChanged(object sender, TextChangedEventArgs e)
        {
            TextBox textBox = (TextBox)sender;

            textBox.Background = !string.IsNullOrEmpty(textBox.Text?.Trim()) && textBox.Text.All(char.IsDigit) ?
                new SolidColorBrush(Colors.White) :
                new SolidColorBrush(Colors.OrangeRed);
        }

        private void NullInputValidator_TextChanged(object sender, TextChangedEventArgs e)
        {
            TextBox textBox = (TextBox)sender;

            textBox.Background = string.IsNullOrEmpty(textBox.Text?.Trim()) ?
                new SolidColorBrush(Colors.OrangeRed) :
                new SolidColorBrush(Colors.White);
        }

        private void CloseWindow(object sender, RoutedEventArgs e)
            => Close();
    }
}
