using System;
using System.Collections.Generic;
using Xunit;
using AppointmentSchedulingSystem; // ربط الـ Namespace الخاص بالكود الأساسي

namespace MathLibrary.Tests
{
    public class AppointmentSchedulerTests
    {
        [Fact]
        public void Reschedule_WhenValidAlternativeDeviceExists_ShouldRescheduleSuccessfully()
        {
            // Arrange (تجهيز البيانات المستهدفة بالاختبار)
            var scheduler = new Scheduler();
            
            var appointments = new List<Appointment> 
            { 
                new Appointment { PatientName = "Rayan", DeviceName = "CT_01", AppointmentTime = "09:00 AM" } 
            };
            
            var devices = new List<Device> 
            { 
                // جهاز متاح، اسمه مختلف، وفيه مواعيد فارغة
                new Device { DeviceName = "CT_02", Available = true, AvailableSlots = new List<string> { "11:00 AM" } } 
            };

            // Act (استدعاء التابع المراد اختباره)
            scheduler.RescheduleAffectedAppointments(appointments, "CT_01", devices);

            // Assert (التحقق من أن النتيجة مطابقة للمتوقع)
            Assert.Equal("CT_02", appointments[0].DeviceName); // يجب أن يتغير الجهاز إلى البديل
            Assert.Equal("11:00 AM", appointments[0].AppointmentTime); // يجب أن يأخذ الوقت الجديد
        }

        [Fact]
        public void Reschedule_WhenNoAlternativeDevicesAvailable_ShouldNotChangeAppointment()
        {
            // Arrange
            var scheduler = new Scheduler();
            
            var appointments = new List<Appointment> 
            { 
                new Appointment { PatientName = "Yousef", DeviceName = "CT_01", AppointmentTime = "09:00 AM" } 
            };
            
            var devices = new List<Device> 
            { 
                // جهاز يحمل نفس الاسم المعطل، أو غير متاح، أو ليس لديه فترات
                new Device { DeviceName = "CT_01", Available = true, AvailableSlots = new List<string> { "11:00 AM" } },
                new Device { DeviceName = "CT_03", Available = false, AvailableSlots = new List<string> { "12:00 PM" } }
            };

            // Act
            scheduler.RescheduleAffectedAppointments(appointments, "CT_01", devices);

            // Assert
            Assert.Equal("CT_01", appointments[0].DeviceName); // لم يتغير لأنه لا يوجد بديل متاح
            Assert.Equal("09:00 AM", appointments[0].AppointmentTime); // بقي الموعد القديم على حاله
        }
    }
}
