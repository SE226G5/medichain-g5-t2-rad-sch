namespace RadiologyClinic
{
    public class RadiationDoseCalculator
    {
        public string DetermineRadiationDose(string scanType, int patientAge,
                                              double patientWeight, bool isPregnant)
        {
            if (isPregnant)
                return "Scan not allowed: patient is pregnant";

            if (scanType == "CT")
            {
                if (patientAge < 18)
                {
                    if (patientWeight < 40)
                        return "CT dose: Low (pediatric lightweight protocol) - 20 mSv";
                    else
                        return "CT dose: Low (pediatric standard protocol) - 30 mSv";
                }
                else
                {
                    if (patientWeight > 100)
                        return "CT dose: High (obese adult protocol) - 80 mSv";
                    else
                        return "CT dose: Standard (adult protocol) - 50 mSv";
                }
            }
            else if (scanType == "XRAY")
            {
                if (patientAge < 18)
                    return "X-Ray dose: Minimal (pediatric protocol) - 0.1 mSv";
                else
                    return "X-Ray dose: Standard (adult protocol) - 0.2 mSv";
            }
            else
            {
                return "Unknown scan type: no dose assigned";
            }
        }
    }


    public class RadiationDoseCalculatorRefactored
    {
        public string DetermineRadiationDose(string scanType, int patientAge,
                                              double patientWeight, bool isPregnant)
        {
            if (isPregnant)
                return "Scan not allowed: patient is pregnant";

            if (scanType == "CT")
                return GetCtDose(patientAge, patientWeight);

            if (scanType == "XRAY")
                return GetXRayDose(patientAge);

            return "Unknown scan type: no dose assigned";
        }

        private string GetCtDose(int age, double weight)
        {
            if (age < 18)
                return weight < 40
                    ? "CT dose: Low (pediatric lightweight protocol) - 20 mSv"
                    : "CT dose: Low (pediatric standard protocol) - 30 mSv";

            return weight > 100
                ? "CT dose: High (obese adult protocol) - 80 mSv"
                : "CT dose: Standard (adult protocol) - 50 mSv";
        }

        private string GetXRayDose(int age)
        {
            return age < 18
                ? "X-Ray dose: Minimal (pediatric protocol) - 0.1 mSv"
                : "X-Ray dose: Standard (adult protocol) - 0.2 mSv";
        }
    }

}
