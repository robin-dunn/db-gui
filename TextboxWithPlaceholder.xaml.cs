using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace DbGui
{
	/// <summary>
	/// Interaction logic for TextboxWithPlaceholder.xaml
	/// </summary>
	public partial class TextboxWithPlaceholder : UserControl
	{
		public TextboxWithPlaceholder()
		{
			InitializeComponent();
		}

		public string PlaceholderText
		{
			get { return (string)GetValue(PlaceholderTextProperty); }
			set { SetValue(PlaceholderTextProperty, value); }
		}

		// Using a DependencyProperty as the backing store for Property1.  
		// This enables animation, styling, binding, etc...
		public static readonly DependencyProperty PlaceholderTextProperty
			= DependencyProperty.Register("PlaceholderText", typeof(string), typeof(TextboxWithPlaceholder));

		private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
		{
			TextBox textBox = sender as TextBox;

			if (textBox != null)
			{
				if (string.IsNullOrWhiteSpace(textBox.Text))
				{
					Placeholder.Visibility = Visibility.Visible;
				}
				else
				{
					Placeholder.Visibility = Visibility.Hidden;
				}
			}
		}
	}
}
