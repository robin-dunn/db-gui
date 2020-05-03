using Npgsql;
using System.Windows;

namespace DbGui
{
	/// <summary>
	/// Interaction logic for MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window
	{
		public MainWindow()
		{
			InitializeComponent();
		}

		private async void Button_Click(object sender, RoutedEventArgs e)
		{
			var connString = $"Host={host.Text};Username={username.Text};Password={password.Text};Database={database.Text}";

			await using var conn = new NpgsqlConnection(connString);
			await conn.OpenAsync();

			await using (var cmd = new NpgsqlCommand(query.Text, conn))
			{
				await cmd.ExecuteNonQueryAsync();
			}

			MessageBox.Show("Complete");
		}
	}
}
