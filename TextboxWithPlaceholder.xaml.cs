using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;

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

		public static readonly DependencyProperty PlaceholderTextProperty
			= DependencyProperty.Register("PlaceholderText", typeof(string), typeof(TextboxWithPlaceholder));

		public string Text
		{
			get { return (string)GetValue(TextProperty); }
			set { SetValue(TextProperty, value); }
		}

		public static readonly DependencyProperty TextProperty
			= DependencyProperty.Register("Text", typeof(string), typeof(TextboxWithPlaceholder));

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
