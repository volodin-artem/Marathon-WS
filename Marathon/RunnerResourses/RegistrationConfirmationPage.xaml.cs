
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

namespace Marathon.RunnerResourses
{
	/// <summary>
	/// Interaction logic for RegistrationConfirmationPage.xaml
	/// </summary>
	public partial class RegistrationConfirmationPage : Page
	{
		Runner currentRunner;
		public RegistrationConfirmationPage(Runner currentRunner)
		{
			this.currentRunner = currentRunner;
			
			InitializeComponent();
		}
		void ButtonBack_Click(object sender, RoutedEventArgs e)
		{
			Frames.mainFrame.Navigate(new RunnerMenuPage(currentRunner));
		}
		void ButtonLogout_Click(object sender, RoutedEventArgs e)
		{
			Frames.mainFrame.Navigate(new MainPage());
		}
	}
}