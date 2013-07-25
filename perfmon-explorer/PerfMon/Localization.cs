//
//  Localization.cs
//
//  Author:
//       Fabricio Godoy <skarllot@gmail.com>
//
//  Copyright (c) 2013 Fabricio Godoy
//
//  This program is free software: you can redistribute it and/or modify
//  it under the terms of the GNU General Public License as published by
//  the Free Software Foundation, either version 3 of the License, or
//  (at your option) any later version.
//
//  This program is distributed in the hope that it will be useful,
//  but WITHOUT ANY WARRANTY; without even the implied warranty of
//  MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
//  GNU General Public License for more details.
//
//  You should have received a copy of the GNU General Public License
//  along with this program.  If not, see <http://www.gnu.org/licenses/>.

using System;
using Microsoft.Win32;
using System.Collections.Generic;

namespace perfmon_explorer.PerfMon
{
    public class Localization
    {
        const string KEY_PERFLIB_CURLANG = @"SOFTWARE\Microsoft\Windows NT\CurrentVersion\Perflib\CurrentLanguage";
        const string KEY_PERFLIB_DEFAULT = @"SOFTWARE\Microsoft\Windows NT\CurrentVersion\Perflib\009";
        static Dictionary<string, string> counterList, counterListCurr;
        static Dictionary<string, string> reverseCounterList, reverseCounterListCurr;

        static Localization()
        {
            RegistryKey regKey, regKeyCurr = null;
            string[] strCounter;

            // TODO: Heavy test both keys
            regKey = Registry.LocalMachine.OpenSubKey(KEY_PERFLIB_DEFAULT);

            strCounter = regKey.GetValue("Counter") as string[];
            regKey.Close();

            counterList = new Dictionary<string, string>(strCounter.Length / 2);
            reverseCounterList = new Dictionary<string, string>(strCounter.Length / 2);
            for (int i = 0; i < strCounter.Length; i += 2)
            {
                if (string.IsNullOrEmpty(strCounter[i]) ||
                    string.IsNullOrEmpty(strCounter[i + 1]))
                {
                    continue;
                }
                counterList.Add(strCounter[i], strCounter[i + 1]);

                if (reverseCounterList.ContainsKey(strCounter[i+1]))
                    reverseCounterList[strCounter[i + 1]] += "&" + strCounter[i];
                else
                    reverseCounterList.Add(strCounter[i + 1], strCounter[i]);
            }

            // Current Language
            try { regKeyCurr = Registry.LocalMachine.OpenSubKey(KEY_PERFLIB_CURLANG); }
            catch { }

            if (regKeyCurr != null)
            {
                strCounter = regKeyCurr.GetValue("Counter") as string[];
                regKeyCurr.Close();

                counterListCurr = new Dictionary<string, string>(strCounter.Length / 2);
                reverseCounterListCurr = new Dictionary<string, string>(strCounter.Length / 2);
                for (int i = 0; i < strCounter.Length; i += 2)
                {
                    if (string.IsNullOrEmpty(strCounter[i]) ||
                        string.IsNullOrEmpty(strCounter[i + 1]))
                    {
                        continue;
                    }
                    counterListCurr.Add(strCounter[i], strCounter[i + 1]);

                    if (reverseCounterListCurr.ContainsKey(strCounter[i + 1]))
                        reverseCounterListCurr[strCounter[i + 1]] += "&" + strCounter[i];
                    else
                        reverseCounterListCurr.Add(strCounter[i + 1], strCounter[i]);
                }
            }
        }

        public static string GetName(string id)
        {
            if (counterList.ContainsKey(id))
                return counterList[id];
            else if (counterListCurr.ContainsKey(id))
                return counterListCurr[id];
            return null;
        }

        public static string GetId(string name)
        {
            if (reverseCounterList.ContainsKey(name))
                return reverseCounterList[name];
            else if (reverseCounterListCurr.ContainsKey(name))
                return reverseCounterListCurr[name];
            return null;
        }
    }
}

