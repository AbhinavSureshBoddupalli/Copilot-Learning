using HRPortalAPI.Models;

namespace HRPortalAPI.Services;

public class CompanyPolicyService : ICompanyPolicyService
{
    private readonly List<CompanyPolicy> _policies = new();
    private int _nextId = 1;

    public Task<IEnumerable<CompanyPolicy>> GetAllPoliciesAsync()
    {
        return Task.FromResult<IEnumerable<CompanyPolicy>>(_policies);
    }

    public Task<CompanyPolicy?> GetPolicyByIdAsync(int id)
    {
        var policy = _policies.FirstOrDefault(p => p.Id == id);
        return Task.FromResult(policy);
    }

    public Task<CompanyPolicy> CreatePolicyAsync(CompanyPolicy policy)
    {
        policy.Id = _nextId++;
        policy.CreatedAt = DateTime.UtcNow;
        policy.UpdatedAt = DateTime.UtcNow;
        _policies.Add(policy);
        return Task.FromResult(policy);
    }

    public Task<CompanyPolicy?> UpdatePolicyAsync(int id, CompanyPolicy policy)
    {
        var existingPolicy = _policies.FirstOrDefault(p => p.Id == id);
        if (existingPolicy == null)
        {
            return Task.FromResult<CompanyPolicy?>(null);
        }

        existingPolicy.Title = policy.Title;
        existingPolicy.Description = policy.Description;
        existingPolicy.Category = policy.Category;
        existingPolicy.EffectiveDate = policy.EffectiveDate;
        existingPolicy.ExpiryDate = policy.ExpiryDate;
        existingPolicy.IsActive = policy.IsActive;
        existingPolicy.ApplicableTo = policy.ApplicableTo;
        existingPolicy.UpdatedAt = DateTime.UtcNow;

        return Task.FromResult<CompanyPolicy?>(existingPolicy);
    }

    public Task<bool> DeletePolicyAsync(int id)
    {
        var policy = _policies.FirstOrDefault(p => p.Id == id);
        if (policy == null)
        {
            return Task.FromResult(false);
        }

        _policies.Remove(policy);
        return Task.FromResult(true);
    }
}
