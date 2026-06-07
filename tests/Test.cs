using Xunit;
using src;
using System.Collections.Generic;

namespace tests
{
    public class Test
    {
        [Fact]
        public void Reschedule_WhenDeviceFails_ShouldUpdateToNewDevice()
        {
            var scheduler = new AppointmentScheduler();
            var appointments = new List<Appointment> { new Appointment("Ali", "MRI-1", "10:00") };
            var devices = new List<Device> { 
                new Device("MRI-1", false), 
                new Device("MRI-2", true) { AvailableSlots = {"11:00"} } 
            };

            scheduler.RescheduleAffectedAppointments(appointments, "MRI-1", devices);

            Assert.Equal("MRI-2", appointments[0].DeviceName);
            Assert.Equal("11:00", appointments[0].AppointmentTime);
        }

        [Fact]
        public void Reschedule_WhenNoAvailableDevices_ShouldNotChangeAppointment()
        {
            var scheduler = new AppointmentScheduler();
            var appointments = new List<Appointment> { new Appointment("Ali", "MRI-1", "10:00") };
            var devices = new List<Device> { new Device("MRI-1", false) }; 

            scheduler.RescheduleAffectedAppointments(appointments, "MRI-1", devices);

            Assert.Equal("MRI-1", appointments[0].DeviceName); 
        }

        [Fact]
        public void Reschedule_WhenDeviceIsWorking_ShouldNotChangeAppointment()
        {
            var scheduler = new AppointmentScheduler();
            var appointments = new List<Appointment> { new Appointment("Sara", "MRI-2", "10:00") };
            var devices = new List<Device> { new Device("MRI-2", true) };

            scheduler.RescheduleAffectedAppointments(appointments, "MRI-2", devices);

            Assert.Equal("MRI-2", appointments[0].DeviceName); 
        }
    }
}