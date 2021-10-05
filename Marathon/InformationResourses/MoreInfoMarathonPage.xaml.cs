
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
	/// Interaction logic for MoreInfoMarathonPage.xaml
	/// </summary>
	public partial class MoreInfoMarathonPage : Page
	{
		public MoreInfoMarathonPage()
		{
			InitializeComponent();
		}
		void ButtonBack_Click(object sender, RoutedEventArgs e)
		{
			Frames.mainFrame.GoBack();
		}
		void ButtonCharityList_Click(object sender, RoutedEventArgs e)
		{
			Frames.mainFrame.Navigate(new CharityListPage());
		}
	}
}