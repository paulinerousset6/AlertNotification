using System;
using System.Threading;
//using System.Timers;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AlertNotificationSystem
{
    public class PagerManagement
    {
        private static Timer aTimer;
        private static int cpt;
        private List<Alert> alerts;
        private List<EscalationPolicy> escalationPolicies;
        private static List<Level> CurrentLevels;
        private static Alert CurrentAlert;
        private int AcknowledgmentDelay = - 1;

        public PagerManagement(List<Alert> a, List<EscalationPolicy> e)
        {
            alerts = a;
            escalationPolicies = e;
            AcknowledgmentDelay = 900000;
        }

        public List<Alert> GetAlerts()
        {
            return alerts;
        }

        public int GetAcknowledgmentDelay()
        {
            return AcknowledgmentDelay;
        }

        public List<EscalationPolicy> GetEscalationPolicies()
        {
            return escalationPolicies;
        }

        public void Tick(Object stateInfo)
        {
            if (cpt < CurrentLevels.Count)
            {
                foreach (Level l in CurrentLevels)
                {
                    foreach (Target t in l.GetTargets())
                    {
                        Console.WriteLine("Sending via {0}: \"{1}\" to {2}", t.GetType(), CurrentAlert.GetMessage(), t.GetContent());
                    }

                    l.SetNotified(true);
                }

                cpt++;
            }
            else
            {
                aTimer.Change(Timeout.Infinite, Timeout.Infinite);
            }
        }

        //Send targets to SMS and Email Services
        public List<Level> SendTargets(Alert a, List<Level> levels)
        {
            cpt = 0;
            CurrentLevels = levels;
            CurrentAlert = a;
            while (cpt < levels.Count)
            {
                if (cpt >= levels.Count)
                    break;

                TimerCallback callback = new TimerCallback(Tick);
                aTimer = new System.Threading.Timer(callback, null, AcknowledgmentDelay, AcknowledgmentDelay);
            }

            return CurrentLevels;
        }
    }
}
