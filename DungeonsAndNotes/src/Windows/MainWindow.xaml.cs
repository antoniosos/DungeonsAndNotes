using System.Windows;
using DungeonsAndNotes.Pages;

namespace DungeonsAndNotes.Windows;

public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();
        
        MainFrame.Navigate(new MainPage());
    } 
    
}