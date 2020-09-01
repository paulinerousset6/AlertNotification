using Microsoft.VisualStudio.TestTools.UnitTesting;
using AlertNotificationSystem;
using System.Collections.Generic;
using System.Linq;

namespace UnitTestAlertNotificationSystem
{
    [TestClass]
    public class PagerManagementUnitTest
    {
        [TestMethod]
        public void TestUseCaseScenario1()
        {
            //Creation of services 

            EscalationPolicyManagement escalationPolicyManagement = new EscalationPolicyManagement();
            escalationPolicyManagement.OnReceiveServicesInfo();

            //Creation of escalation policies

            List<Level> levels = new List<Level>();
            levels.Add(new Level(new List<Target> { new Target("SMS", "0606060606") }));
            levels.Add(new Level(new List<Target> { new Target("email", "toto@toto.fr") }));

            escalationPolicyManagement.OnReceiveEscalationPolicies(levels);

            //Check if service is healthy
            
            Assert.AreEqual(true, escalationPolicyManagement.GetServices().First().GetState());

            //Receiving alerts
            
            AlertsManagement alertsManagement = new AlertsManagement();
            alertsManagement.OnReceiveAlerts(new List<Service> { escalationPolicyManagement.GetServices().First() }, escalationPolicyManagement.GetEscalationPolicy());
            
            //Check if the service for which an alert has been raised has its state to "Unhealthy" (= false)
            
            Assert.AreEqual(false, escalationPolicyManagement.GetServices().First().GetState());
            

            //Sending notifications to the first level and sets a 15 mins acknowledgement delay
            
            PagerManagement pagerManagement = new PagerManagement(alertsManagement.GetAlerts(), escalationPolicyManagement.GetEscalationPolicy());

            foreach (Alert a in alertsManagement.GetAlerts())
            {
                EscalationPolicy e = pagerManagement.GetEscalationPolicies().Where(x => x.serviceId == a.GetServiceId()).ToList().First();
                List<Level> currentLevels = new List<Level> { e.GetLevels().First() };

                //Check if AcknowledgementDelay equals 15mins
                
                Assert.AreEqual(900000, pagerManagement.GetAcknowledgmentDelay());
                List<Level> levelsNotified = pagerManagement.SendTargets(a, currentLevels);

                //Check if first level is notified
                
                Assert.AreEqual(true, levelsNotified.First().GetNotified());
            }
        }
    }
}
