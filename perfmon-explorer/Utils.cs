//
//  Utils.cs
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
using System.Collections.Generic;
using System.Text;

namespace perfmon_explorer
{
    class Utils
    {
        public static int[] IndexOfAll<T>(T[] list, T item)
            where T : IComparable
        {
            List<int> indexes = new List<int>();
            for (int i = 0; i < list.Length; i++)
            {
                if (list[i].CompareTo(item) == 0)
                    indexes.Add(i);
            }

            return indexes.ToArray();
        }
    }
}
