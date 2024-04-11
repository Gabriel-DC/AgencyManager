using AgencyManager.EventsArgs;
using System.Windows.Controls;
using System.Windows.Media;

namespace AgencyManager.Components
{
    public delegate void ValidationEventHandler(object sender, ValidationEventArgs e);

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

            ValidationEventArgs eventArgs = new(Text);
            bool isValid = true;
            
            Delegate[] delegates = _validationEventHandler.GetInvocationList();

            foreach (ValidationEventHandler validationDelegate in delegates)
            {
                 validationDelegate(this, eventArgs);

                if (!eventArgs.IsValid)
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
