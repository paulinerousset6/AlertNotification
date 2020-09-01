using System;
using System.Collections.Generic;
using System.Text;

namespace AlertNotificationSystem
{
    interface IRequestAlerts
    {
        void OnReceiveAlerts(List<Service> services, List<EscalationPolicy> escalationPolicies);
    }
}
