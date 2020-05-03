using Npgsql;
using System;
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

			uint countResults = 0;
			string queryResultString = string.Empty;

			await using (var cmd = new NpgsqlCommand(query.Text, conn))
			{
				var dataReader = await cmd.ExecuteReaderAsync();

				while (await dataReader.ReadAsync())
				{
					if (dataReader.FieldCount > 0)
					{
						countResults++;

						for (int i = 0; i < dataReader.FieldCount; i++)
						{
							queryResultString += dataReader[i].ToString();

							if (i == dataReader.FieldCount - 2)
							{
								queryResultString += ", ";
							}
						}

						queryResultString += Environment.NewLine;
					}
				}
			}

			labelQueryStatus.Content = "Query completed.";
			labelCountResults.Content = countResults.ToString() + " results.";
			results.Text = queryResultString;
		}
	}
}
