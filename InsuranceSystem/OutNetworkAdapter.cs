namespace Unit5_AdapterPatternPatient_Blazor.InsuranceSystem
{
    public class OutNetworkAdapter : InsuranceInterface
    {
        OutNetworkPatient patient;

        public OutNetworkAdapter(string newName, int newPolicyNumber) 
        { 
            patient = new OutNetworkPatient(newName, newPolicyNumber);
        }
        public decimal CoverageAmount(int ProcedureID, decimal ProcedureCost)
        {
            decimal coveragePercent = patient.CoveragePercent(ProcedureCost);
            return (coveragePercent * ProcedureCost); 
        }

        public string getPatientName()
        {
            return patient.getPatientName();
        }

        public string getPolicyNumber()
        {
           return patient.PolicyNumber.ToString();
        }

        //public bool IsCovered(string patientName, string policyNumber)
        //{
        //    int policyNum;

        //    if (int.TryParse(policyNumber, out policyNum))
        //    {
        //        string result = patient.IsCovered(patientName, policyNum);
        //        return bool.Parse(result);
        //    }

        //    return false;

        //}

        public bool IsCovered(string patientName, string policyNumber)
        {
            int policyNum;

            if (int.TryParse(policyNumber, out policyNum))
            {
                string isCoveredString = patient.IsCovered(patientName, policyNum);
                return bool.TryParse(isCoveredString, out bool isCovered) && isCovered;
            }

            return false;

        }
    }
}
