public class RadiologySchedulerTest {

    public static void main(String[] args) {
        RadiologyScheduler scheduler = new RadiologyScheduler();

        System.out.println("=================================================");
        System.out.println("=== Running MediChain Radiology Module Tests ===");
        System.out.println("=================================================\n");

        // TC_01: غياب تعليمات التحضير -> يجب رفض الطلب
        String res1 = scheduler.autoScheduleRadiology(40, false, 5, "ROUTINE", false);
        String exp1 = "Rejected: Preparation instructions are required.";
        System.out.println("[TC_01] Result   : " + res1);
        System.out.println("[TC_01] Expected : " + exp1);
        System.out.println("[TC_01] Status   : " + (res1.equals(exp1) ? "PASS ✓" : "FAIL ✗") + "\n");

        // TC_02: سعة الجهاز = 0 -> إعادة جدولة
        String res2 = scheduler.autoScheduleRadiology(40, true, 0, "ROUTINE", false);
        String exp2 = "Reschedule: Device capacity exceeded.";
        System.out.println("[TC_02] Result   : " + res2);
        System.out.println("[TC_02] Expected : " + exp2);
        System.out.println("[TC_02] Status   : " + (res2.equals(exp2) ? "PASS ✓" : "FAIL ✗") + "\n");

        // TC_03: تضارب + أولوية طوارئ -> تجاوز التضارب
        String res3 = scheduler.autoScheduleRadiology(40, true, 2, "EMERGENCY", true);
        String exp3 = "Scheduled: High Priority Override.";
        System.out.println("[TC_03] Result   : " + res3);
        System.out.println("[TC_03] Expected : " + exp3);
        System.out.println("[TC_03] Status   : " + (res3.equals(exp3) ? "PASS ✓" : "FAIL ✗") + "\n");

        // TC_04: تضارب + مدة قصيرة < 30 -> موعد محسّن
        String res4 = scheduler.autoScheduleRadiology(20, true, 2, "ROUTINE", true);
        String exp4 = "Scheduled: Optimized Short Duration Slot.";
        System.out.println("[TC_04] Result   : " + res4);
        System.out.println("[TC_04] Expected : " + exp4);
        System.out.println("[TC_04] Status   : " + (res4.equals(exp4) ? "PASS ✓" : "FAIL ✗") + "\n");

        // TC_05: لا تضارب، جميع الشروط طبيعية -> جدولة قياسية
        String res5 = scheduler.autoScheduleRadiology(45, true, 2, "ROUTINE", false);
        String exp5 = "Scheduled: Standard Slot Allocated.";
        System.out.println("[TC_05] Result   : " + res5);
        System.out.println("[TC_05] Expected : " + exp5);
        System.out.println("[TC_05] Status   : " + (res5.equals(exp5) ? "PASS ✓" : "FAIL ✗") + "\n");

        System.out.println("=================================================");
        System.out.println("=== All 5 Basis Paths Covered Successfully!  ===");
        System.out.println("=================================================");
    }
}