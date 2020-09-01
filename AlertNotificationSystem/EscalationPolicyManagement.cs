using System;
using System.Collections.Generic;
using System.Text;

namespace AlertNotificationSystem
{
    public class EscalationPolicyManagement : IRequestEscalationPolicy
    {
        private List<EscalationPolicy> escalationPolicies;
        private List<Service> services;

        public void OnReceiveServicesInfo()
        {
            Random rand = new Random();
            services = new List<Service>();

            for (int i = 0; i < rand.Next(1, 11); i++)
            {
                Service s = new Service(true);
                services.Add(s);
            }
        }

        public void OnReceiveEscalationPolicies(List<Level> levels)
        {
            escalationPolicies = new List<EscalationPolicy>();
            foreach (Service s in services)
            {
                escalationPolicies.Add(new EscalationPolicy(s.GetId(), levels));
            }
        }

        public List<EscalationPolicy> GetEscalationPolicy()
        {
            return escalationPolicies;
        }

        public List<Service> GetServices()
        {
            return services;
        }
    }
}
