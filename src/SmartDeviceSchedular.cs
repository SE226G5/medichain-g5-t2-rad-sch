using System;
using System.Collections.Generic;
using System.Linq;

namespace src
{
    public class Appointment
    {
        public string PatientName { get; set; }
        public string DeviceName { get; set; }
        public string AppointmentTime { get; set; }
        
        public Appointment(string patient, string device, string time)
        {
            PatientName = patient;
            DeviceName = device;
            AppointmentTime = time;
        }
    }

    public class Device
    {
        public string DeviceName { get; set; }
        public bool Available { get; set; }
        public List<string> AvailableSlots { get; set; } = new List<string>();
        
        public Device(string name, bool status)
        {
            DeviceName = name;
            Available = status;
        }
    }

    public class AppointmentScheduler
    {
        public void RescheduleAffectedAppointments_BeforeRefactor(List<Appointment> appointments, string failedDevice, List<Device> devices)
        {
            foreach (var appointment in appointments)
            {
                if (appointment.DeviceName == failedDevice)
                {
                    bool rescheduled = false;
                    foreach (var device in devices) 
                    {
                        if (device.Available && device.DeviceName != failedDevice && device.AvailableSlots.Count > 0)
                        {
                            appointment.DeviceName = device.DeviceName;
                            appointment.AppointmentTime = device.AvailableSlots[0];
                            rescheduled = true;
                            break;
                        }
                    }
                }
            }
        }

        public void RescheduleAffectedAppointments(List<Appointment> appointments, string failedDevice, List<Device> devices)
        {
            foreach (var appointment in appointments.Where(a => a.DeviceName == failedDevice))
            {
                var newDevice = FindAvailableDevice(devices, failedDevice);
                
                if (newDevice != null)
                {
                    appointment.DeviceName = newDevice.DeviceName;
                    appointment.AppointmentTime = newDevice.AvailableSlots[0];
                }
            }
        }

        private Device FindAvailableDevice(List<Device> devices, string failedDevice)
        {
            return devices.FirstOrDefault(d => d.Available 
                                            && d.DeviceName != failedDevice 
                                            && d.AvailableSlots.Count > 0);
        }
    }
}