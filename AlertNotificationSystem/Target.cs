using System;
using System.Collections.Generic;
using System.Text;

namespace AlertNotificationSystem
{
    public class Target
    {
        string type;
        string content;
        bool acknowledged;

        public Target(string t, string c)
        {
            type = t;
            content = c;
        }

        public string GetContent()
        {
            return content;
        }

        public string GetType()
        {
            return type;
        }

        public void SetAcknowledged(bool a)
        {
            acknowledged = a;
        }

        public bool GetAcknowledged()
        {
            return acknowledged;
        }
    }
}
