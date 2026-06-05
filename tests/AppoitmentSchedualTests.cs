using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Radiology.Tests
{
    
        [TestFixture]
        public class AppointmentSchedulerTests
        {
            private AppointmentScheduler _scheduler;
            private AppointmentSchedulerRefactored _refactored;

            [SetUp]
            public void Setup()
            {
                _scheduler = new AppointmentScheduler();
                _refactored = new AppointmentSchedulerRefactored();
            }

            [Test]
            public void ScheduleAppointment_EmergencySlotAvailable()
            {
                string result = _scheduler.ScheduleAppointment("emergency", true, "CT", false);

                Assert.That(result,
                    Is.EqualTo("Emergency appointment scheduled immediately"));
            }

            [Test]
            public void ScheduleAppointment_EmergencyNoSlot()
            {
                string result = _scheduler.ScheduleAppointment("emergency", false, "CT", false);

                Assert.That(result,
                    Is.EqualTo("Emergency: redirected to on-call radiologist"));
            }

            [Test]
            public void ScheduleAppointment_UrgentWithPreparation()
            {
                string result = _scheduler.ScheduleAppointment("urgent", true, "CT", true);

                Assert.That(result,
                    Is.EqualTo("Urgent appointment scheduled within 24 hours - preparation instructions sent"));
            }
        }
    }

