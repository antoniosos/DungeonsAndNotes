using System.Windows;
using System.Windows.Controls;

namespace DungeonsAndNotes.Pages;

public partial class RegistrationPage : Page
{
    public RegistrationPage()
    {
        InitializeComponent();
    }

    private void Register_Click(object sender, RoutedEventArgs e)
    {
        while (Validator.ValidateUserName(TxtUsername.Text) != Validator.UserNameValidity.IsValid ||
               Validator.ValidatePassword(TxtPassword.Password, TxtConfirmPassword.Password) != Validator.PasswordValidity.IsValid)
        {
            // 
        }
        
        
        
     
        
        
        throw new NotImplementedException();
    }

    private void ShowNameWarning(Validator.UserNameValidity validity)
    {
        
    }

    private void ShowPasswordWarning()
    {
        
    }
}