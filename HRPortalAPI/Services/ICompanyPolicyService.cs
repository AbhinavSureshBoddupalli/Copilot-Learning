using HRPortalAPI.Models;

namespace HRPortalAPI.Services;

public interface ICompanyPolicyService
{
    Task<IEnumerable<CompanyPolicy>> GetAllPoliciesAsync();
    Task<CompanyPolicy?> GetPolicyByIdAsync(int id);
    Task<CompanyPolicy> CreatePolicyAsync(CompanyPolicy policy);
    Task<CompanyPolicy?> UpdatePolicyAsync(int id, CompanyPolicy policy);
    Task<bool> DeletePolicyAsync(int id);
}
