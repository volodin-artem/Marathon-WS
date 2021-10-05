
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
using System.Windows.Automation.Peers;

namespace Marathon
{
	/// <summary>
	/// Interaction logic for CharityListPage.xaml
	/// </summary>
	public partial class CharityListPage : Page
	{
		public CharityListPage()
		{
			InitializeComponent();
			
			List<Charity> charityList = UsingContext.db.Charity.ToList();

			for (int i = 0; i < charityList.Count(); i++) {
				charityList[i].CharityLogo = @"..\Images\" + charityList[i].CharityLogo;
			}
			
			listCharity.ItemsSource = charityList;
		}
		void ButtonBack_Click(object sender, RoutedEventArgs e)
		{
			Frames.mainFrame.GoBack();
		}
	}
}