
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
	/// Interaction logic for RunnerRaceResultsPage.xaml
	/// </summary>
	public partial class RunnerRaceResultsPage : Page
	{
		public RunnerRaceResultsPage(Runner currentRunner)
		{
			InitializeComponent();
			
			List<Registration> registr = currentRunner.Registration.ToList();
			
			List<RegistrationEvent> events = new List<RegistrationEvent>();
			
			for (int i = 0; i < registr.Count(); i++) {
				events.Add(registr[i].RegistrationEvent.First());
			}
			
			for (int i = 0; i < events.Count(); i++) {
				string eventId = events[i].EventId;
				List<RegistrationEvent> events1 = UsingContext.db.RegistrationEvent.Where(x => x.EventId == eventId).ToList().OrderBy(x => x.RaceTime).ToList();
				int ass = Convert.ToInt32(events[i].RaceTime);
				events[i].Place = (events1.FindIndex(x => x.RaceTime == ass).ToString());
				MessageBox.Show(events1.FindIndex(x => x.RaceTime == events[i].RaceTime).ToString());
			}
						dataGridEvents.ItemsSource = events;
		}
	}
}