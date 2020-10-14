/**
 * This file holds the main portion if the DaliyBattles system.
 * More methods are to be added. Please check for updates regarding this file.
 * Also if you want to send tips regarding CnCNet, This file or other files in this repository, I would greatly appreciate it.
 * 
 * -SteamsDev
 */

using System;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Resources;
using Rampastring.Tools;

namespace DailyBattles
{
	public class DailyBattles
	{
		private string[] currentDate;
		private string[] startDate;
		private IniFile IniDailyBattles;

		// Constructor for the class file
		public DailyBattles()
		{
			currentDate = getCurrentDate();
			startDate = getStartDate();
			IniDailyBattles = new IniFile("DailyBattles.ini");
		}

		// This is for debugging purposes only. This uses the Microsoft VS Debugger.
		private void DebugMode()
        {
			if (IniDailyBattles.GetStringValue("DebugMode", "Enabled", "false") == "true")
            {
				Console.WriteLine("DEBUG MODE ENABLED! Will output debug information to logfile.");
				Debugger.Launch();
				if (Debugger.IsLogging() == true)
					Console.WriteLine("Debugger Launch Successful.");
				else
					throw new Exception ("Debugger failed to launch; Check to make sure the debugger is enabled and it can be attached to the program, and that is outputting information to logfile.");
			}
		}

		// Ends Debug Mode.
		private void EndDebugMode()
        {
			if (Debugger.IsLogging())
				Debugger.Break();
        }

		// Check if the INI value for the implementation of Daily Battles is set to "true"
		public bool dailyGameCheck => IniDailyBattles.GetStringValue("DailyBattles", "Enabled", "false") == "false";

		// Check to see if the daily battle is played.
		public bool IsPlayed()
		{
			int j = 0;
			for (int i = 0; i < startDate.Length; ++i)
				if (currentDate[i] == startDate[i])
					++j;
			return (j == 3);
		}

		// Get the current date using DateTime.
		public string[] getCurrentDate()
		{
			int day = DateTime.Today.Day;
			int month = DateTime.Today.Month;
			int year = DateTime.Today.Year;
			string[] currentDate = { day.ToString(), month.ToString(), year.ToString() };
			return currentDate;
		}

		// Get the start date from the INI file.
		public string[] getStartDate()
        {
			string currentStartDate = IniDailyBattles.GetStringValue("startDate", "1", "XX-XX-XXXX");
			string[] startDate = currentStartDate.Split('-');
			return startDate;
		}

		// Replacee the new start date with that of the current date.
		public string[] newStartDate()
		{
			int[] newDate = { DateTime.Today.Day, DateTime.Today.Month, DateTime.Today.Year };
			for (int i = 0; i < newDate.Length; ++i)
				startDate[i] = newDate[i].ToString();
			return startDate;
		}


	}
}

