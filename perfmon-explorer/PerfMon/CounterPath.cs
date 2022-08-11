//
//  CounterPath.cs
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

using Microsoft.Win32;
using System;

namespace perfmon_explorer.PerfMon
{
    internal struct CounterPath
    {
        private const string KeyPerflibCurlang = @"SOFTWARE\Microsoft\Windows NT\CurrentVersion\Perflib\CurrentLanguage";
        private const string KeyPerflibDefault = @"SOFTWARE\Microsoft\Windows NT\CurrentVersion\Perflib\009";
        private const string Separator = @"&";
        private static int[] idListEn, idListLang;
        private static string[] nameListEn, nameListLang;

        static CounterPath()
        {
            RegistryKey regKey;
            string[] strCounter;
            int pos = 0;

            // TODO: Heavy test both keys
            regKey = Registry.LocalMachine.OpenSubKey(KeyPerflibDefault);

            strCounter = regKey.GetValue("Counter") as string[];
            regKey.Close();

            idListEn = new int[strCounter.Length / 2];
            nameListEn = new string[strCounter.Length / 2];
            for (int i = 0; i < strCounter.Length; i += 2)
            {
                if (string.IsNullOrEmpty(strCounter[i]) ||
                    string.IsNullOrEmpty(strCounter[i + 1]))
                {
                    continue;
                }
                idListEn[pos] = int.Parse(strCounter[i]);
                nameListEn[pos] = strCounter[i + 1];
                pos++;
            }

            // Current Language
            try { regKey = Registry.LocalMachine.OpenSubKey(KeyPerflibCurlang); }
            catch { return; }

            strCounter = regKey.GetValue("Counter") as string[];
            regKey.Close();

            idListLang = new int[strCounter.Length / 2];
            nameListLang = new string[strCounter.Length / 2];
            pos = 0;
            for (int i = 0; i < strCounter.Length; i += 2)
            {
                if (string.IsNullOrEmpty(strCounter[i]) ||
                    string.IsNullOrEmpty(strCounter[i + 1]))
                {
                    continue;
                }
                idListLang[pos] = int.Parse(strCounter[i]);
                nameListLang[pos] = strCounter[i + 1];
                pos++;
            }
        }

        public int CategoryId { get; set; }

        public string CategoryName
        {
            get { return GetName(CategoryId); }
            set { CategoryId = GetId(value); }
        }

        public int CounterId { get; set; }

        public string CounterName
        {
            get { return GetName(CounterId); }
            set { CounterId = GetNearestCounterId(GetAllIds(value)); }
        }

        public string InstanceName { get; set; }

        private static int GetId(string name)
        {
            int idx = Array.IndexOf(nameListLang, name);
            if (idx != -1)
                return idListLang[idx];

            idx = Array.IndexOf(nameListEn, name);
            if (idx != -1)
                return idListEn[idx];

            return 0;
        }

        private static int[] GetAllIds(string name)
        {
            int[] ids;
            int pos = 0;
            int[] indexes = Utils.IndexOfAll(nameListLang, name);
            if (indexes.Length > 0)
            {
                ids = new int[indexes.Length];
                foreach (int item in indexes)
                {
                    ids[pos] = idListLang[item];
                    pos++;
                }
                return ids;
            }

            indexes = Utils.IndexOfAll(nameListEn, name);
            if (indexes.Length > 0)
            {
                ids = new int[indexes.Length];
                foreach (int item in indexes)
                {
                    ids[pos] = idListEn[item];
                    pos++;
                }
                return ids;
            }

            return new int[0];
        }

        public string GetIdPath()
        {
            string path = string.Empty;

            if (CategoryId > 0)
            {
                path = "\\" + CategoryId.ToString();
                if (InstanceName != null)
                    path += "(" + InstanceName + ")";
                if (CounterId > 0)
                    path += "\\" + CounterId.ToString();
            }

            return path;
        }

        private static string GetName(int id)
        {
            int idx = Array.IndexOf(idListLang, id);
            if (idx != -1)
                return nameListLang[idx];

            idx = Array.IndexOf(idListEn, id);
            if (idx != -1)
                return nameListEn[idx];

            return null;
        }

        private int GetNearestCounterId(int[] ids)
        {
            if (ids == null ||
                CategoryId == 0 ||
                ids.Length < 1)
                return -1;

            int minor = int.MaxValue;
            int idx = -1, diff;
            for (int i = 0; i < ids.Length; i++)
            {
                diff = Math.Abs(ids[i] - CategoryId);
                if (diff < minor)
                {
                    minor = diff;
                    idx = i;
                }
            }

            return ids[idx];
        }

        public string GetPath()
        {
            string path = string.Empty;

            if (CategoryId > 0)
            {
                path = "\\" + CategoryName;
                if (InstanceName != null)
                    path += "(" + InstanceName + ")";
                if (CounterId > 0)
                    path += "\\" + CounterName;
            }

            return path;
        }

        public override string ToString()
        {
            return GetPath();
        }
    }
}
