using System;
using System.Collections.Generic;
using System.Text;

namespace AlertNotificationSystem
{
    interface IRequestServiceState
    {
        void GetServiceState(Service s);
    }
}
