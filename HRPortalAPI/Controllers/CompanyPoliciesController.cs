using Microsoft.AspNetCore.Mvc;
using HRPortalAPI.DTOs;
using HRPortalAPI.Models;
using HRPortalAPI.Services;

namespace HRPortalAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CompanyPoliciesController : ControllerBase
{
    private readonly ICompanyPolicyService _policyService;

    public CompanyPoliciesController(ICompanyPolicyService policyService)
    {
        _policyService = policyService;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<CompanyPolicyResponse>>> GetAllPolicies()
    {
        var policies = await _policyService.GetAllPoliciesAsync();
        var response = policies.Select(p => MapToResponse(p));
        return Ok(response);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<CompanyPolicyResponse>> GetPolicy(int id)
    {
        var policy = await _policyService.GetPolicyByIdAsync(id);
        if (policy == null)
        {
            return NotFound(new { message = $"Company policy with ID {id} not found" });
        }

        return Ok(MapToResponse(policy));
    }

    [HttpPost]
    public async Task<ActionResult<CompanyPolicyResponse>> CreatePolicy(CreateCompanyPolicyRequest request)
    {
        if (string.IsNullOrWhiteSpace(request.Title))
        {
            return BadRequest(new { message = "Title is required" });
        }

        if (string.IsNullOrWhiteSpace(request.Description))
        {
            return BadRequest(new { message = "Description is required" });
        }

        var policy = new CompanyPolicy
        {
            Title = request.Title,
            Description = request.Description,
            Category = request.Category,
            EffectiveDate = request.EffectiveDate,
            ExpiryDate = request.ExpiryDate,
            ApplicableTo = request.ApplicableTo,
            IsActive = true
        };

        var createdPolicy = await _policyService.CreatePolicyAsync(policy);
        return CreatedAtAction(nameof(GetPolicy), new { id = createdPolicy.Id }, MapToResponse(createdPolicy));
    }

    [HttpPut("{id}")]
    public async Task<ActionResult<CompanyPolicyResponse>> UpdatePolicy(int id, UpdateCompanyPolicyRequest request)
    {
        var existingPolicy = await _policyService.GetPolicyByIdAsync(id);
        if (existingPolicy == null)
        {
            return NotFound(new { message = $"Company policy with ID {id} not found" });
        }

        // Update only provided fields
        if (request.Title != null) existingPolicy.Title = request.Title;
        if (request.Description != null) existingPolicy.Description = request.Description;
        if (request.Category != null) existingPolicy.Category = request.Category;
        if (request.EffectiveDate.HasValue) existingPolicy.EffectiveDate = request.EffectiveDate.Value;
        if (request.ExpiryDate.HasValue) existingPolicy.ExpiryDate = request.ExpiryDate;
        if (request.IsActive.HasValue) existingPolicy.IsActive = request.IsActive.Value;
        if (request.ApplicableTo != null) existingPolicy.ApplicableTo = request.ApplicableTo;

        var updatedPolicy = await _policyService.UpdatePolicyAsync(id, existingPolicy);
        return Ok(MapToResponse(updatedPolicy!));
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeletePolicy(int id)
    {
        var result = await _policyService.DeletePolicyAsync(id);
        if (!result)
        {
            return NotFound(new { message = $"Company policy with ID {id} not found" });
        }

        return NoContent();
    }

    private static CompanyPolicyResponse MapToResponse(CompanyPolicy policy)
    {
        return new CompanyPolicyResponse(
            policy.Id,
            policy.Title,
            policy.Description,
            policy.Category,
            policy.EffectiveDate,
            policy.ExpiryDate,
            policy.IsActive,
            policy.ApplicableTo,
            policy.CreatedAt,
            policy.UpdatedAt
        );
    }
}
