using System.Windows;
using System.Windows.Automation.Provider;
using System.Windows.Controls;

namespace EP_01___4
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void SelectionComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            PersonaFisicaPanel.Visibility = Visibility.Collapsed;
            EmpresaPanel.Visibility = Visibility.Collapsed;

            if (SelectionComboBox.SelectedItem is ComboBoxItem selectedItem)
            {
                switch (selectedItem.Content.ToString())
                {
                    case "Persona Física":
                        PersonaFisicaPanel.Visibility = Visibility.Visible;
                        break;
                    case "Empresa":
                        EmpresaPanel.Visibility = Visibility.Visible;
                        break;
                }
            }
            ValidateForm();
        }

        private void InputField_TextChanged(object sender, TextChangedEventArgs e)
        {
            emptyCamps();
            ValidateForm();
        }
        private void emptyCamps()
        {
            if (!string.IsNullOrWhiteSpace (NomTextBox.Text))
            {
                VacioNombre.Visibility = Visibility.Hidden;

            }
            else
            {
                VacioNombre.Visibility = Visibility.Visible;
            }
            if (!string.IsNullOrWhiteSpace(DNITextBox.Text))
            {
                VacioDNI.Visibility = Visibility.Hidden;

            }
            else
            {
                VacioDNI.Visibility = Visibility.Visible;
            }
            if (!string.IsNullOrWhiteSpace(NomEmpresaTextBox.Text))
            {
                VacioEmpresa.Visibility = Visibility.Hidden;
            }
            else
            {
                VacioEmpresa.Visibility = Visibility.Visible;
            }
            if (!string.IsNullOrWhiteSpace(CIFTextBox.Text))
            {
                VacioCIF.Visibility = Visibility.Hidden;
            }
            else
            {
                VacioCIF.Visibility = Visibility.Visible;

            }
        }
        private void ValidateForm()
        {
            bool isValid = false;

            if (PersonaFisicaPanel.Visibility == Visibility.Visible)
            {
                isValid = !string.IsNullOrWhiteSpace(NomTextBox.Text) &&
                          !string.IsNullOrWhiteSpace(DNITextBox.Text);
            }
            else if (EmpresaPanel.Visibility == Visibility.Visible)
            {
                isValid = !string.IsNullOrWhiteSpace(NomEmpresaTextBox.Text) &&
                          !string.IsNullOrWhiteSpace(CIFTextBox.Text);
            }

            SubmitButton.IsEnabled = isValid;
        }

        private void SubmitButton_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Formulario enviado correctamente!", "Exit", MessageBoxButton.OK, MessageBoxImage.Information);
        }
    }
}