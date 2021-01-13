/*
 * On startup, this file will check the CnCNet Client itself for integrity.
 * If any files are missing or destroyed, the app will break with a standard Exception.
 * More methods will be added. Please kee an eye out for updates.
 */

using System;
using System.Diagnostics.Contracts;
using System.IO;
using System.Xml.XPath;

namespace DailyBattles
{
    public static class StartUp
    {
        // The string values from here until Run() are file names in DTA. You can make copies of this and change the filenames to apply to your mod.
        private static string[] IniIntegrity =
        {
            "AI.ini",
            "AIE.ini",
            "Art.ini",
            "ArtE.ini",
            "Battle.ini",
            "Des.ini",
            "Enhance.ini",
            "FSA.ini",
            "FSR.ini",
            "Keyboard.ini",
            "MapSel.ini",
            "MapSel01.ini",
            "Menu.ini",
            "MPMaps.ini",
            "Rules.ini",
            "Sounds.ini",
            "Tem.ini",
            "Theme.ini",
            "Tutorial.ini"
        };

        private static string[] MixIntegrity =
        {
            "Cache.mix",
            "Conquer.mix",
            "ECache01.mix",
            "ECache02.mix",
            "ECache03.mix",
            "ECache04.mix",
            "ECache05.mix",
            "Expand98.mix",
            "Expand99.mix",
            "GMenu.mix",
            "IsoDes.mix",
            "IsoTem.mix",
            "Local.mix",
            "Movies.mix",
            "Scores.mix",
            "Scores01.mix",
            "Side01.mix",
            "Side02.mix",
            "Side03.mix",
            "Side04.mix",
            "SideCD01.mix",
            "SideCD02.mix",
            "SideCD03.mix",
            "SideCD04.mix",
            "sidenc01.mix",
            "sidenc02.mix",
            "sidenc03.mix",
            "sidenc04.mix",
            "Sounds.mix",
            "Speech01.mix",
            "Speech02.mix",
            "Speech03.mix",
            "Speech04.mix"
        };

        private static string[] ExeIntegrity =
        {
            "clientdx.exe",
            "clientogl.exe",
            "clientxna.exe"
        };

        public static void Run ( )
        {
            Console.WriteLine("Checking Client Integrity, this might take some time...");
            string DefaultClientPath = @"%USERPROFILE%\Documents\Dawn of the Tiberium Age";
            string ClientPath = DefaultClientPath;
            Console.WriteLine("Checking INI Integrity...");
            if (CheckINIIntegrity(IniIntegrity, ClientPath) == true)
                Console.WriteLine("INI Integrity Check Complete. All Files Present.");
            Console.WriteLine("Checking Mix File Integrity");
            if (CheckMixIntegrity(MixIntegrity, ClientPath) == true)
                Console.WriteLine("Mix File Integrity Check Complete. All Files Present.");
            Console.WriteLine("Checking Exe Integrity");
            if (CheckExeIntegrity(ExeIntegrity, ClientPath) == true)
                Console.WriteLine("Exe Integrity Check Complete. All Files Present");
            Console.WriteLine("Integrity Check Complete.");
            
            /*
             * Additional Startup Propertires will show up here.
             */
        }

        // This function is meant to go to a directory and scan for file names. If the implementation is incorrect feel free to give me a few pointers. Thanks! -SteamsDev
        private static bool CheckINIIntegrity (string[] IniString, string ClientPath)
        {
            string IniPath = ClientPath + @"\INI";
            foreach (string i in IniString)
            {
                if (!File.Exists(IniPath + i)) return false;
            }
            return true;
        }

        // This function is meant to go to a directory and scan for file names. If the implementation is incorrect feel free to give me a few pointers. Thanks! -SteamsDev
        private static bool CheckMixIntegrity (string[] MixString, string ClientPath)
        {
            string MixPath = ClientPath + @"\MIX";
            foreach (string i in MixString)
            {
                if (!File.Exists(MixPath + i)) return false;
            }
            return true;
        }

        // This function is meant to go to a directory and scan for file names. If the implementation is incorrect feel free to give me a few pointers. Thanks! -SteamsDev
        private static bool CheckExeIntegrity (string[] ExeString, string ClientPath)
        {
            string ExePath = ClientPath + @"\INI";
            foreach (string i in ExeString)
            {
                if (!File.Exists(ExePath + i)) return false;
            }
            return true;
        }
    }
}
