using APBD_Proj.Models;
using APBD_Proj.RequestModels;
using APBD_Proj.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace APBD_Proj.Endpoints;
[ApiController]
[Route("api/companies")]
public class CompanyEndpoints : ControllerBase
{
    private readonly IManageCompanyService _manageCompanyService;
    
    public CompanyEndpoints(IManageCompanyService manageCompanyService)
    {
        _manageCompanyService = manageCompanyService;
    }
    
    [HttpPost]
    [Authorize(Roles = "user")]
    public async Task<IActionResult> AddCompany(CompanyRequestModel companyRequestModel)
    {
        try
        {
            return Ok(await _manageCompanyService.AddCompany(companyRequestModel));
        }
        catch (NotFoundException e)
        {
            return NotFound(e.Message);
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }
    [Authorize(Roles = "admin")]
    [HttpPut("{krs:int}")]
    public async Task<IActionResult> UpdateCompany(int krs)
    {
        try
        {
            return Ok(await _manageCompanyService.UpdateCompany(krs));
        }
        catch (NotFoundException e)
        {
            return NotFound(e.Message);
        }
    }
    
}