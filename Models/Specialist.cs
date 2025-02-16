
public class Specialist {
    public int Id { get; set; }
    public string Name { get; set; }
    public string Field { get; set; }
    public ICollection<Appointment> Appointments { get; set; }
}