namespace HRPortalAPI.DTOs;

public record CreateCompanyPolicyRequest(
    string Title,
    string Description,
    string Category,
    DateTime EffectiveDate,
    DateTime? ExpiryDate,
    string ApplicableTo
);

public record UpdateCompanyPolicyRequest(
    string? Title,
    string? Description,
    string? Category,
    DateTime? EffectiveDate,
    DateTime? ExpiryDate,
    bool? IsActive,
    string? ApplicableTo
);

public record CompanyPolicyResponse(
    int Id,
    string Title,
    string Description,
    string Category,
    DateTime EffectiveDate,
    DateTime? ExpiryDate,
    bool IsActive,
    string ApplicableTo,
    DateTime CreatedAt,
    DateTime UpdatedAt
);
