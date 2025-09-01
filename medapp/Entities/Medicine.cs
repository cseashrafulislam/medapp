namespace medapp.Entities
{
    public class Medicine
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public ICollection<PrescriptionDetail> Prescriptions { get; set; } = new List<PrescriptionDetail>();
    }
}
