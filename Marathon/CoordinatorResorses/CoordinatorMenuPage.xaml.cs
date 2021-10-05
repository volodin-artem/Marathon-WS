
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;

namespace Marathon
{
	/// <summary>
	/// Interaction logic for CoordinatorMenuPage.xaml
	/// </summary>
	public partial class CoordinatorMenuPage : Page
	{
		public CoordinatorMenuPage()
		{
			InitializeComponent();
		}
		void ButtonLogout_Click(object sender, RoutedEventArgs e)
		{
			Frames.mainFrame.Navigate(new MainPage());
		}
		void ButtonBack_Click(object sender, RoutedEventArgs e)
		{
			Frames.mainFrame.Navigate(new MainPage());
		}
	}
}