
public class Appointment {
    public int Id { get; set; }
    public int UserId { get; set; }
    public User User { get; set; }
    public int SpecialistId { get; set; }
    public Specialist Specialist { get; set; }
    public DateTime Date { get; set; }
}