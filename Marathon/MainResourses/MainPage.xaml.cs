
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using Marathon.MainResourses;

namespace Marathon
{
	/// <summary>
	/// Interaction logic for MainPage.xaml
	/// </summary>
	public partial class MainPage : Page
	{
		public MainPage()
		{
			InitializeComponent();
		}
		void ButtonWannaBeSponsor_Click(object sender, RoutedEventArgs e)
		{
			Frames.mainFrame.Navigate(new RunnerSponsorPage());
		}
		void ButtonWannaKnowMore_Click(object sender, RoutedEventArgs e)
		{
			Frames.mainFrame.Navigate(new MoreInfoMarathonPage());
		}
		void ButtonLogin_Click(object sender, RoutedEventArgs e)
		{
			Frames.mainFrame.Navigate(new LoginPage());
		}
		void ButtonWannaBeRunner_Click(object sender, RoutedEventArgs e)
		{
			Frames.mainFrame.Navigate(new RegisterAsRunnerPage());
		}
	}
}