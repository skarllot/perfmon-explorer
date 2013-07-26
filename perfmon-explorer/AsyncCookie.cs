using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace perfmon_explorer
{
    class AsyncCookie : IAsyncResult
    {
        IState state;

        public AsyncCookie(IState asyncState)
        {
            state = asyncState;
        }

        public object AsyncState
        {
            get { return state; }
        }

        public System.Threading.WaitHandle AsyncWaitHandle
        {
            get { throw new NotImplementedException(); }
        }

        public bool CompletedSynchronously
        {
            get { return false; }
        }

        public bool IsCompleted
        {
            get { return state.IsCompleted; }
        }

        public interface IState
        {
            bool IsCompleted { get; }
        }
    }
}
