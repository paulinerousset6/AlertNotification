using System;
using System.Collections.Generic;
using System.Text;

namespace AlertNotificationSystem
{
    public class Alert
    {
        private string message;
        private int serviceId;
        private bool state;
        private EscalationPolicy escalationPolicy;

        public Alert(int s, string m, bool st, EscalationPolicy e)
        {
            serviceId = s;
            message = m;
            state = st;
            escalationPolicy = e;
        }

        public string GetMessage()
        {
            return message;
        }

        public bool GetState()
        {
            return state;
        }

        public int GetServiceId()
        {
            return serviceId;
        }

        public EscalationPolicy GetEscalationPolicy()
        {
            return escalationPolicy;
        }
    }
}
