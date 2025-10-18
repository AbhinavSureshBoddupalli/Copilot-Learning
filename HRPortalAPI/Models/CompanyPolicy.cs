namespace HRPortalAPI.Models;

public class CompanyPolicy
{
    public int Id { get; set; }
    public string Title { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public string Category { get; set; } = string.Empty; // Leave, Attendance, Code of Conduct, Benefits, etc.
    public DateTime EffectiveDate { get; set; }
    public DateTime? ExpiryDate { get; set; }
    public bool IsActive { get; set; } = true;
    public string ApplicableTo { get; set; } = "All"; // All, Department-specific, Position-specific
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
}
