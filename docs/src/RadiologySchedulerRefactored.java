

public class RadiologySchedulerRefactored {
    public String autoScheduleRadiologyRefactored(int duration, boolean prepDefined, int capacity, String priority, boolean hasConflict) {
        if (!prepDefined) return "Rejected: Preparation instructions are required.";
        if (capacity <= 0)  return "Reschedule: Device capacity exceeded.";
        if (!hasConflict)   return "Scheduled: Standard Slot Allocated.";

        if (priority.equals("EMERGENCY")) return "Scheduled: High Priority Override.";
        if (duration < 30) return "Scheduled: Optimized Short Duration Slot.";
        
        return "Queued: Waiting for next available slot.";
    }
}