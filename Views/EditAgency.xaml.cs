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
            BtnOk.Click += new RoutedEventHandler(BtnOk_Click);
            BtnOk.Click += new RoutedEventHandler(CloseWindow);

            BtnCancelar.Click += new RoutedEventHandler(BtnCancelar_Click);
            BtnCancelar.Click += new RoutedEventHandler(CloseWindow);
        }

        private void BtnOk_Click(object sender, RoutedEventArgs e)
            => DialogResult = true;        

        private void BtnCancelar_Click(object sender, RoutedEventArgs e)
            => DialogResult = false;        

        private void CloseWindow(object sender, RoutedEventArgs e)
            => Close();
    }
}
