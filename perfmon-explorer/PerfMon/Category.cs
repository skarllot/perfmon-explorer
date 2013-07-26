//
//  Category.cs
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
using System.Diagnostics;
using System.Threading;

namespace perfmon_explorer.PerfMon
{
    class Category : IComparable
    {
        PerformanceCounterCategory perfCat;

        Category(PerformanceCounterCategory inner)
        {
            perfCat = inner;
        }

        public string Help
        {
            get { return perfCat.CategoryHelp; }
        }

        public static IAsyncResult BeginGetCategories()
        {
            ParameterizedThreadStart thStart = new ParameterizedThreadStart(_getCategories);
            Thread th = new Thread(thStart);
            AsyncState<object, Category[]> state = new AsyncState<object, Category[]>(th);
            th.Start(state);

            return new AsyncCookie(state);
        }

        public IAsyncResult BeginGetCounters(string instance)
        {
            ParameterizedThreadStart thStart = new ParameterizedThreadStart(_getCounters);
            Thread th = new Thread(thStart);
            AsyncState<string, Counter[]> state = new AsyncState<string, Counter[]>(th, instance);
            th.Start(state);

            return new AsyncCookie(state);
        }

        public IAsyncResult BeginGetInstancesNames()
        {
            ParameterizedThreadStart thStart = new ParameterizedThreadStart(_getInstancesNames);
            Thread th = new Thread(thStart);
            AsyncState<object, string[]> state = new AsyncState<object, string[]>(th);
            th.Start(state);

            return new AsyncCookie(state);
        }

        public static Category[] EndGetCategories(IAsyncResult asyncResult)
        {
            AsyncState<object, Category[]> state = (AsyncState<object, Category[]>)asyncResult.AsyncState;
            state.Thread.Join();

            return state.Result;
        }

        public Counter[] EndGetCounters(IAsyncResult asyncResult)
        {
            AsyncState<string, Counter[]> state = (AsyncState<string, Counter[]>)asyncResult.AsyncState;
            state.Thread.Join();

            return state.Result;
        }

        public string[] EndGetInstancesNames(IAsyncResult asyncResult)
        {
            AsyncState<object, string[]> state = (AsyncState<object, string[]>)asyncResult.AsyncState;
            state.Thread.Join();

            return state.Result;
        }

        public static Category[] GetCategories()
        {
            AsyncState<object, Category[]> state = new AsyncState<object, Category[]>(null);
            _getCategories(state);
            return state.Result;
        }

        public Counter[] GetCounters(string instance)
        {
            AsyncState<string, Counter[]> state = new AsyncState<string, Counter[]>(null, instance);
            _getCounters(state);
            return state.Result;
        }

        public string[] GetInstancesNames()
        {
            AsyncState<object, string[]> state = new AsyncState<object, string[]>(null);
            _getInstancesNames(state);
            return state.Result;
        }

        public override string ToString()
        {
            return perfCat.CategoryName;
        }

        int IComparable.CompareTo(object obj)
        {
            return this.perfCat.CategoryName.CompareTo(obj.ToString());
        }

        private static void _getCategories(object obj)
        {
            AsyncState<object, Category[]> state = (AsyncState<object, Category[]>)obj;

            PerformanceCounterCategory[] perfCats = PerformanceCounterCategory.GetCategories();
            Category[] ret = new Category[perfCats.Length];

            for (int i = 0; i < ret.Length; i++)
            {
                ret[i] = new Category(perfCats[i]);
            }

            state.Result = ret;
        }

        private void _getCounters(object obj)
        {
            AsyncState<string, Counter[]> state = (AsyncState<string, Counter[]>)obj;

            PerformanceCounter[] counters = perfCat.GetCounters(state.Parameter ?? "");
            Counter[] ret = new Counter[counters.Length];

            for (int i = 0; i < ret.Length; i++)
            {
                ret[i] = new Counter(counters[i]);
            }

            state.Result = ret;
        }

        private void _getInstancesNames(object obj)
        {
            AsyncState<object, string[]> state = (AsyncState<object, string[]>)obj;
            state.Result = perfCat.GetInstanceNames();
        }

        private class AsyncState<T, U> : AsyncCookie.IState
            where T : class
            where U : class
        {
            Thread thread;
            T param;
            U result;

            public AsyncState(Thread thread)
            {
                this.thread = thread;
                param = null;
                result = null;
            }

            public AsyncState(Thread thread, T param)
            {
                this.thread = thread;
                this.param = param;
                result = null;
            }

            public T Parameter
            {
                get { return param; }
            }

            public Thread Thread
            {
                get { return thread; }
                set { thread = value; }
            }

            public U Result
            {
                get { return result; }
                set { result = value; }
            }

            bool AsyncCookie.IState.IsCompleted
            {
                get { return thread.ThreadState == System.Threading.ThreadState.Stopped; }
            }
        }
    }
}
