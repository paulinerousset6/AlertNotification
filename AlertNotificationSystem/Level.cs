using System;
using System.Collections.Generic;
using System.Text;

namespace AlertNotificationSystem
{
    public class Level
    {
        private List<Target> targets;
        private bool notified;

        public Level(List<Target> t)
        {
            targets = t;
        }

        public List<Target> GetTargets()
        {
            return targets;
        }

        public bool GetNotified()
        {
            return notified;
        }

        public void SetNotified(bool n)
        {
            notified = n;
        }
    }
}
