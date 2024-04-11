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

        protected override void OnTextChanged(TextChangedEventArgs e)
        {
            base.OnTextChanged(e);
            OnValidation();
        }

        private void OnValidation()
        {
            if (_validationEventHandler is null)
                return;

            bool isValid = true;
            Delegate[] delegates = _validationEventHandler.GetInvocationList();

            foreach (ValidationEventHandler validationDelegate in delegates )
            {
                if (!validationDelegate(Text))
                {
                    isValid = false;
                    break;
                }
            }
            

            Background = isValid
                ? new SolidColorBrush(Colors.White)
                : new SolidColorBrush(Colors.OrangeRed);
        }
    }
}
