using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AlertNotificationSystem
{
    public class AlertsManagement : IRequestAlerts
    {
        private List<Alert> receivedAlerts;

        public AlertsManagement()
        {

        }

        public void OnReceiveAlerts(List<Service> services, List<EscalationPolicy> escalationPolicies)
        {
            receivedAlerts = new List<Alert>();
            foreach(Service service in services)
            {
                Alert a = new Alert(service.GetId(), "alert message", false, escalationPolicies.Where(x => x.serviceId == service.GetId()).First());
                Console.WriteLine("Received an alert from service {0} with the following message : \"{1}\"", service.GetId(), a.GetMessage());
                receivedAlerts.Add(a);
                service.SetState(false);
            }
        }

        public List<Alert> GetAlerts()
        {
            return receivedAlerts;
        }
    }
}
