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
            BindCommands();
            UpdateControls();
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

            TxtNumero.ValidationEventHandler += NullInputValidator_TextChanged;
            TxtNumero.ValidationEventHandler += NumberInputValidator_TextChanged;

            TxtNome.ValidationEventHandler += NullInputValidator_TextChanged;
            TxtDescricao.ValidationEventHandler += NullInputValidator_TextChanged;
            TxtEndereco.ValidationEventHandler += NullInputValidator_TextChanged;
            TxtTelefone.ValidationEventHandler += NullInputValidator_TextChanged;
        }

        private bool NumberInputValidator_TextChanged(string text)
            => !string.IsNullOrEmpty(text?.Trim()) && text.All(char.IsDigit);

        private bool NullInputValidator_TextChanged(string text)
            => !string.IsNullOrEmpty(text?.Trim());

        private void CloseWindow(object sender, RoutedEventArgs e)
            => Close();
    }
}
