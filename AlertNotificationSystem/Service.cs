using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace AlertNotificationSystem
{
    public class Service
    {
        static int nextId;
        private bool state;
        private int id;
        
        //Service state is healthy when state is true
        public Service(bool s)
        {
            id = Interlocked.Increment(ref nextId);
            state = s;
        }

        public int GetId()
        {
            return id;
        }

        public bool GetState()
        {
            return state;
        }

        public void SetState(bool s)
        {
            state = s;
        }
    }
}
