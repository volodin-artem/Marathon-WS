
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
	/// Interaction logic for RunnerEditProfilePage.xaml
	/// </summary>
	public partial class RunnerEditProfilePage : Page
	{
		public RunnerEditProfilePage(Runner currentRunner)
		{
			InitializeComponent(); 
			
			this.DataContext = currentRunner;
			
			comboCountries.SelectedValuePath = "CountryCode";
			comboCountries.SelectedValue = currentRunner.Country.CountryCode;
			
			comboGenders.SelectedValuePath = "Gender1";
			comboGenders.SelectedValue = currentRunner.Gender;
		}
		
		void ButtonBack_Click(object sender, RoutedEventArgs e)
		{
			
		}
		void ButtonLogout_Click(object sender, RoutedEventArgs e)
		{
			
		}
		void ButtonSave_Click(object sender, RoutedEventArgs e)
		{
			UsingContext.db.SaveChanges();
		}
	}
}