using System;
using System.Collections.Generic;
using System.Text;

namespace AlertNotificationSystem
{
    interface IRequestEscalationPolicy
    {
        public void OnReceiveEscalationPolicies(List<Level> levels);
    }
}
