using Avalonia.Controls;
using Avalonia.Interactivity;
using OrderApplication.Services;

namespace OrderApplication;

public partial class MainWindow : Window
{
    private Client _client;
    public MainWindow()
    {
        _client = new Client("http://localhost", 5000, "admin", "admin");
        InitializeComponent();
    }

    private async void Button_OnClick(object? sender, RoutedEventArgs e)
    {
        TextBlock.Text = "Fetching...";
        TextBlock.Text = await _client.GetLogin().ConfigureAwait(true);
    }
}