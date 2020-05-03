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
			get { return IsPassword ? ThePasswordBox.Password : (string)GetValue(TextProperty); }
			set { SetValue(TextProperty, value); }
		}

		public static readonly DependencyProperty TextProperty
			= DependencyProperty.Register("Text", typeof(string), typeof(TextboxWithPlaceholder));

		public bool IsPassword
		{
			get { return (bool)GetValue(IsPasswordProperty); }
			set { SetValue(IsPasswordProperty, value); }
		}

		public static readonly DependencyProperty IsPasswordProperty
			= DependencyProperty.Register("IsPassword", typeof(bool), typeof(TextboxWithPlaceholder));

		public bool ShowTextbox => !IsPassword;

		private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
		{
			TextBox textBox = sender as TextBox;

			if (textBox != null && textBox.Visibility == Visibility.Visible)
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

		private void ThePasswordBox_PasswordChanged(object sender, RoutedEventArgs e)
		{
			PasswordBox passwordBox = sender as PasswordBox;

			if (passwordBox != null)
			{
				if (string.IsNullOrWhiteSpace(passwordBox.Password))
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
