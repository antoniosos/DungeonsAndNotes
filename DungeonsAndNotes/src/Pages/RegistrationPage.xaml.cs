using System.Net.Http;
using System.Windows;
using System.Windows.Controls;

namespace DungeonsAndNotes.Pages;

public partial class RegistrationPage : Page
{
    public RegistrationPage()
    {
        InitializeComponent();
    }

    private async void Register_Click(object sender, RoutedEventArgs e)
{
    if (Validator.ValidateUserName(TxtUsername.Text) != Validator.UserNameValidity.IsValid ||
           Validator.ValidatePassword(TxtPassword.Password, TxtConfirmPassword.Password) != Validator.PasswordValidity.IsValid)
    {
        Validator.UserNameValidity userNameValidity = Validator.ValidateUserName(TxtUsername.Text);
        ShowNameWarning(userNameValidity);

        Validator.PasswordValidity passwordValidity = Validator.ValidatePassword(TxtPassword.Password);
        ShowPasswordWarning(passwordValidity);

        return;
    }

    try
    {
        var registrationInfo = new Dictionary<string, string>()
        {
            { "username", TxtUsername.Text },
            { "password", TxtPassword.Password }
        };

        // Execute HTTP request asynchronously on a background thread
        HttpResponseMessage response = await Task.Run(async () =>
        {
            var content = new FormUrlEncodedContent(registrationInfo);
            return await Connection.GetConnection().Client.PostAsync("http://127.0.0.1:80/register", content);
        });

        // Ensure the response was successful before proceeding
        response.EnsureSuccessStatusCode();

        // Read and display the response content
        string responseContent = await response.Content.ReadAsStringAsync();
        Console.WriteLine(responseContent);
    }
    catch (Exception ex)
    {
        // Handle any exceptions
        Console.WriteLine("Exception: " + ex.Message);
    }
}


    private void ShowNameWarning(Validator.UserNameValidity validity)
    {
        switch (validity)
        {
            case Validator.UserNameValidity.TooShort:
                UserNameWarning.Content = "Too short!";
                break;
            case Validator.UserNameValidity.TooLong:
                UserNameWarning.Content = "Too long!";
                break;
            case Validator.UserNameValidity.Exists:
                UserNameWarning.Content = "Already exists!";
                break;
        }
    }

    private void ShowPasswordWarning(Validator.PasswordValidity validity)
    {
        switch (validity)
        {
            case Validator.PasswordValidity.TooShort:
                PasswordNameWarning.Content = "Too short!";
                break;
            case Validator.PasswordValidity.DontMatch:
                PasswordNameWarning.Content = "Password don't match!";
                break;
        }   
    }
}