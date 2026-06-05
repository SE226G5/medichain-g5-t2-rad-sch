using Radiology;

namespace Radiology
{

    public class AppointmentScheduler
    {

        public string ScheduleAppointment(string urgencyLevel, bool isSlotAvailable,
                                          string scanType, bool requiresPreparation)
        {
            if (urgencyLevel == "emergency")
            {
                if (isSlotAvailable)
                    return "Emergency appointment scheduled immediately";
                else
                    return "Emergency: redirected to on-call radiologist";
            }
            else if (urgencyLevel == "urgent")
            {
                if (isSlotAvailable)
                {
                    if (requiresPreparation)
                        return "Urgent appointment scheduled within 24 hours - preparation instructions sent";
                    else
                        return "Urgent appointment scheduled within 24 hours";
                }
                else
                    return "Urgent: added to priority waiting list";
            }
            else
            {
                if (isSlotAvailable)
                    return "Routine appointment scheduled for next available slot";
                else
                    return "Routine: added to standard waiting list";
            }
        }
    }


    public class AppointmentSchedulerRefactored
    {
        public string ScheduleAppointment(string urgencyLevel, bool isSlotAvailable,
                                          string scanType, bool requiresPreparation)
        {
            if (urgencyLevel == "emergency")
                return HandleEmergency(isSlotAvailable);

            if (urgencyLevel == "urgent")
                return HandleUrgent(isSlotAvailable, requiresPreparation);

            return HandleRoutine(isSlotAvailable);
        }

        private string HandleEmergency(bool isSlotAvailable)
        {
            return isSlotAvailable
                ? "Emergency appointment scheduled immediately"
                : "Emergency: redirected to on-call radiologist";
        }

        private string HandleUrgent(bool isSlotAvailable, bool requiresPreparation)
        {
            if (!isSlotAvailable)
                return "Urgent: added to priority waiting list";

            return requiresPreparation
                ? "Urgent appointment scheduled within 24 hours - preparation instructions sent"
                : "Urgent appointment scheduled within 24 hours";
        }

        private string HandleRoutine(bool isSlotAvailable)
        {
            return isSlotAvailable
                ? "Routine appointment scheduled for next available slot"
                : "Routine: added to standard waiting list";
        }
    }
}

