
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
	/// Interaction logic for ThanksSponsorPage.xaml
	/// </summary>
	public partial class ThanksSponsorPage : Page
	{
		public ThanksSponsorPage(User runner,string charityOrg,int amount)
		{
			InitializeComponent();
			
			runnerName.Text = runner.FirstName + " " + runner.LastName + " ";
			charityOrgName.Text = charityOrg;
			this.amount.Text += amount;
			runnerCountry.Text += runner.Runner.First().Country.CountryName;
			
		}
		void ButtonBack_Click(object sender, RoutedEventArgs e)
		{
			Frames.mainFrame.Navigate(new MainPage());
			
			Application.Current.MainWindow.Height=450;
			Application.Current.MainWindow.Width =764;
		}
	}
}