using System;
using System.Collections.Generic;

namespace AppointmentSchedulingSystem
{
    // تعريف كلاس الموعد
    public class Appointment
    {
        public string PatientName { get; set; }
        public string DeviceName { get; set; }
        public string AppointmentTime { get; set; }
    }

    // تعريف كلاس الجهاز
    public class Device
    {
        public string DeviceName { get; set; }
        public bool Available { get; set; }
        public List<string> AvailableSlots { get; set; } = new List<string>();
    }

    // الكلاس الرئيسي الذي يحتوي على الدالة المطلوبة في الوظيفة
    public class Scheduler
    {
        // 3. إعادة الجدولة عند تعطل الجهاز
        public void RescheduleAffectedAppointments(List<Appointment> appointments, string failedDevice, List<Device> devices)
        {
            Console.WriteLine($"\nDevice Failure Detected: {failedDevice}");

            foreach (Appointment appointment in appointments)
            {
                if (appointment.DeviceName == failedDevice)
                {
                    Console.WriteLine($"\nRescheduling appointment for patient: {appointment.PatientName}");

                    bool rescheduled = false;

                    foreach (Device device in devices)
                    {
                        if (device.Available && device.DeviceName != failedDevice && device.AvailableSlots.Count > 0)
                        {
                            appointment.DeviceName = device.DeviceName;
                            appointment.AppointmentTime = device.AvailableSlots[0];

                            Console.WriteLine($"New Device: {appointment.DeviceName}");
                            Console.WriteLine($"New Time: {appointment.AppointmentTime}");

                            rescheduled = true;
                            break;
                        }
                    }

                    if (!rescheduled)
                    {
                        Console.WriteLine("No alternative slots available.");
                    }
                }
            }
        }
    }
}
