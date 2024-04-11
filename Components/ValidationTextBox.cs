using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media;

namespace AgencyManager.Components
{
    public delegate bool ValidationEventHandler(string text);

    public class ValidationTextBox : TextBox
    {
        private ValidationEventHandler? _validationEventHandler;

        public event ValidationEventHandler ValidationEventHandler
        {
            add
            {
                _validationEventHandler += value;
                OnValidation();
            }
            remove => _validationEventHandler -= value;            
        }

        public ValidationTextBox()
        {
            TextChanged += ValidationTextBox_TextChanged;
        }

        private void ValidationTextBox_TextChanged(object sender, TextChangedEventArgs e)
            => OnValidation();

        private void OnValidation()
        {
            if (_validationEventHandler is null)
                return;

            bool isValid = _validationEventHandler(Text);

            Background = isValid
                ? new SolidColorBrush(Colors.White)
                : new SolidColorBrush(Colors.OrangeRed);
        }
    }
}
