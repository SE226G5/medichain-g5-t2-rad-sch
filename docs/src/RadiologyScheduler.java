

public class RadiologyScheduler {
    public String autoScheduleRadiology(int duration, boolean prepDefined, int capacity, String priority, boolean hasConflict) {
        if (!prepDefined) {
            return "Rejected: Preparation instructions are required.";
        }
        if (capacity <= 0) {
            return "Reschedule: Device capacity exceeded.";
        }
        if (hasConflict) {
            if (priority.equals("EMERGENCY")) {
                return "Scheduled: High Priority Override.";
            } else if (duration < 30) {
                return "Scheduled: Optimized Short Duration Slot.";
            } else {
                return "Queued: Waiting for next available slot.";
            }
        }
        return "Scheduled: Standard Slot Allocated.";
    }
}