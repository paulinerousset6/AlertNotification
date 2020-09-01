using System;
using System.Collections.Generic;
using System.Text;

namespace AlertNotificationSystem
{
    public class EscalationPolicy
    {
        public int serviceId;
        private List<Level> levels;

        public EscalationPolicy(int sId, List<Level> l)
        {
            serviceId = sId;
            levels = l;
        }

        public int GetServiceId()
        {
            return serviceId;
        }

        public List<Level> GetLevels()
        {
            return levels;
        }
    }
}
