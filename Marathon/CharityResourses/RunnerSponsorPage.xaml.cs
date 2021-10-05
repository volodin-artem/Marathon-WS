
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
using System.Linq.Expressions;

namespace Marathon
{
	/// <summary>
	/// Interaction logic for RunnerSponsorPage.xaml
	/// </summary>
	public partial class RunnerSponsorPage : Page
	{
		public RunnerSponsorPage()
		{
			InitializeComponent();

			Application.Current.MainWindow.Height = 530;

			List<Runner> runnersList = UsingContext.db.Runner.ToList();

			for (int i = 0; i < 50 /*UsingContext.db.Runner.Count()*/; i++) {
				ComboBoxItem newItem = new ComboBoxItem();
				if (runnersList[i].Registration.Count() != 0)
				{
					newItem.Tag = runnersList[i].Registration.First().RegistrationId;
				}
				newItem.Content = runnersList[i].User.FirstName + " " + runnersList[i].User.LastName + " " + runnersList[i].CountryCode;
				comboRunners.Items.Add(newItem);
			}
		}
		void ButtonBack_Click(object sender, RoutedEventArgs e)
		{
			Frames.mainFrame.GoBack();
		}
		void ButtonPlus_Click(object sender, RoutedEventArgs e)
		{
			int currentSumm = int.Parse(textSumm.Text) + 10;

			textSumm.Text = currentSumm.ToString();
		}
		void ButtonMinus_Click(object sender, RoutedEventArgs e)
		{
			int currentSumm = int.Parse(textSumm.Text) - 10;

			textSumm.Text = currentSumm.ToString();
		}
		void BoxSumm_PreviewTextInput(object sender, TextCompositionEventArgs e)
		{
			e.Handled = "1234567890".IndexOf(e.Text) < 0;
		}
		void BoxSumm_TextChanged(object sender, TextChangedEventArgs e)
		{
			textSumm.Text = boxSumm.Text;
		}
		void BoxCvc_PreviewTextInput(object sender, TextCompositionEventArgs e)
		{
			e.Handled = ((boxCvc.Text.Length > 2) || ("1234567890".IndexOf(e.Text) < 0));
		}
		void BoxYearCard_PreviewTextInput(object sender, TextCompositionEventArgs e)
		{
			e.Handled = ((boxYearCard.Text.Length > 1) || ("1234567890".IndexOf(e.Text) < 0));
		}
		void BoxMounthCard_PreviewTextInput(object sender, TextCompositionEventArgs e)
		{
			e.Handled = ((boxMounthCard.Text.Length > 1) || ("1234567890".IndexOf(e.Text) < 0));
		}
		void ComboRunners_SelectionChanged(object sender, SelectionChangedEventArgs e)
		{
			try {
				int runnerId = Convert.ToInt32(((((ComboBoxItem)comboRunners.SelectedItem).Tag)));

				string charityName = UsingContext.db.Registration.Where(x => x.Runner.RunnerId == runnerId).First().Charity.CharityName;

				textCharityName.Text = charityName;
			}
			catch (InvalidOperationException) {
				MessageBox.Show("У бегуна нет спонсора!", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
			}
		}
		void ContentControl_PreviewMouseDown(object sender, MouseButtonEventArgs e)
		{
			try {
				Charity currentCharity = UsingContext.db.Charity.Where(x => x.CharityName == textCharityName.Text).First();
				new CharityWatchWindow(currentCharity).ShowDialog();
			} catch (InvalidOperationException) {
				MessageBox.Show("Выберите бегуна!", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
			}
		}

		private void buttonPay_Click(object sender, RoutedEventArgs e)
		{
			if (!String.IsNullOrEmpty(boxSponsorName.Text) && (comboRunners.SelectedItem as ComboBoxItem).Tag != null) {
				int amount = int.Parse(textSumm.Text);
				int registrationId = Convert.ToInt32(((comboRunners.SelectedItem as ComboBoxItem).Tag));
				
				Sponsorship newSponsor = new Sponsorship()
				{
					Amount = amount,
					SponsorName = boxSponsorName.Text,
					RegistrationId = registrationId
				};
				User sponsorRunner = UsingContext.db.Registration.Where(x => x.RegistrationId == registrationId).First().Runner.User;
				UsingContext.db.Sponsorship.Add(newSponsor);
				UsingContext.db.SaveChanges();
				Frames.mainFrame.Navigate(new ThanksSponsorPage(sponsorRunner,textCharityName.Text,amount));

			}
			else
				MessageBox.Show("Заполните все поля и выберите бегуна со спонсором!", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
		}
	} 
}