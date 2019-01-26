namespace DatenakquirierungsServiceModels.Surgeries.PatientData
{
    public abstract class APatientData : AEntity
    {
        public int age { get; set; }
        public float weight { get; set; }
        public float waistCircumference { get; set; }
        public float height { get; set; }
        public float bmi { get; set; }
    }
}
