
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
using System.Text.RegularExpressions;

namespace Marathon.RunnerResourses
{
	/// <summary>
	/// Interaction logic for RegisterForEventPage.xaml
	/// </summary>
	public partial class RegisterForEventPage : Page
	{
		Runner currentRunner;
		public RegisterForEventPage(Runner currentRunner)
		{
			InitializeComponent();

			this.currentRunner = currentRunner;
			
			comboCharityOrgs.ItemsSource = UsingContext.db.Charity.ToList();
		}
		
		void ButtonBack_Click(object sender, RoutedEventArgs e)
		{
			Frames.mainFrame.GoBack();
		}
		void ButtonLogout_Click(object sender, RoutedEventArgs e)
		{
			Frames.mainFrame.Navigate(new MainPage());
		}
		void Border_PreviewMouseDown(object sender, MouseButtonEventArgs e)
		{
			Charity item = (Charity)comboCharityOrgs.SelectedItem;
			Charity selectedCharity = UsingContext.db.Charity.FirstOrDefault(x => x.CharityName == item.CharityName);
			new CharityWatchWindow(selectedCharity).ShowDialog();
		}
		void SummComputing_Checked(object sender, RoutedEventArgs e)
		{
			int summ = 0;
			
			if(checkBox20d != null && checkBox20d.IsChecked == true){
				summ += 20;
			}
			
						if(checkBox45d != null &&checkBox45d.IsChecked == true ){
				summ += 45;
			}
			
						if(checkBox75d != null && checkBox75d.IsChecked == true){
				summ += 75;
			}
			
			if(radio20d != null && radio20d.IsChecked == true ){
				summ += 20;
			}
			if(radio30d != null && radio30d.IsChecked == true ){
				summ += 30;
			}
			if(textSumm != null){
			textSumm.Text = summ.ToString();
			}
		}

        private void TextBoxSumm_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
			e.Handled = "1234567890$".IndexOf(e.Text) < 0;
        }

        private void buttonRegister_Click(object sender, RoutedEventArgs e)
        {
			string raceKitOption = "";
			try
			{
				if (radio0d.IsChecked == true)
				{
					raceKitOption = "A";
				}
				else if (radio20d.IsChecked == true)
				{
					raceKitOption = "B";
				}
				else if (radio30d.IsChecked == true)
				{
					raceKitOption = "C";
				}
				UsingContext.db.Runner.Add(currentRunner);
				UsingContext.db.SaveChanges();
				Charity charity = null;
				if (comboCharityOrgs.SelectedItem != null)
				{
					charity = comboCharityOrgs.SelectedItem as Charity;

					Registration runnerRegistration = new Registration
					{
						RunnerId = currentRunner.RunnerId,
						RegistrationDateTime = DateTime.Now,
						RaceKitOptionId = raceKitOption,
						RegistrationStatusId = 1,
						Cost = int.Parse(textSumm.Text),
						CharityId = charity.CharityId,
						SponsorshipTarget = int.Parse(textBoxSumm.Text.Replace("$", "")),
					};

					UsingContext.db.Registration.Add(runnerRegistration);
					UsingContext.db.SaveChanges();

					Sponsorship sponsorship = new Sponsorship
					{
						SponsorName = currentRunner.User.FirstName,
						RegistrationId = runnerRegistration.RegistrationId,
						Amount = int.Parse(textBoxSumm.Text.Replace("$", ""))
					};
					UsingContext.db.Sponsorship.Add(sponsorship);
					UsingContext.db.SaveChanges();
					Frames.mainFrame.Navigate(new RegistrationConfirmationPage(currentRunner));
				}
				else MessageBox.Show("Выберите благотворительную организацию");
			}
			catch (System.Reflection.TargetException)
			{
				MessageBox.Show("Выберите благотворительную организацию!");
			}
		}
    }
}