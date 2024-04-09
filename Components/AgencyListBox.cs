using AgencyManager.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace AgencyManager.Components
{
    public class AgencyListBox : ListBox
    {
        private readonly MainWindow _parentWindow;

        public AgencyListBox(MainWindow mainWindow)
        {
            _parentWindow = mainWindow ?? throw new ArgumentNullException(nameof(mainWindow));
        }

        public Agency SelectedAgency => (Agency)SelectedItem;

        protected override void OnSelectionChanged(SelectionChangedEventArgs e)
        {
            base.OnSelectionChanged(e);            

            Agency selectedAgency = (Agency)SelectedItem;

            _parentWindow.TxtNome.Text = selectedAgency.Nome;
            _parentWindow.TxtDescricao.Text = selectedAgency.Descricao;
            _parentWindow.TxtEndereco.Text = selectedAgency.Endereco;
            _parentWindow.TxtNumero.Text = selectedAgency.Numero;
            _parentWindow.TxtTelefone.Text = selectedAgency.Telefone;
        }
    }
}
