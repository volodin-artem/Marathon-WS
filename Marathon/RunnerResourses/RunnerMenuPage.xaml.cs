
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Linq;
using Marathon.ModelContext;

namespace Marathon
{
	/// <summary>
	/// Interaction logic for RunnerMenuPage.xaml
	/// </summary>
	public partial class RunnerMenuPage : Page
	{
		Runner currentRunner;
		public RunnerMenuPage(Runner currentRunner)
		{
			this.currentRunner = currentRunner;
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
		void ButtonContacts_Click(object sender, RoutedEventArgs e)
		{
			new ContactsInfoWindow().ShowDialog();
		}
		void ButtonEditProfile_Click(object sender, RoutedEventArgs e)
		{
			Frames.mainFrame.Navigate(new RunnerResourses.RunnerEditProfilePage(currentRunner));
		}
		void ButtonMyResults_Click(object sender, RoutedEventArgs e)
		{
			Frames.mainFrame.Navigate(new RunnerResourses.RunnerRaceResultsPage(currentRunner));
		}
	}
}