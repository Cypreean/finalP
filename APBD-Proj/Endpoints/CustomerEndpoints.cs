﻿using APBD_Proj.RequestModels;
using APBD_Proj.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace APBD_Proj.Endpoints;
[ApiController]
[Route("api/customers")]
public class CustomerEndpoints : ControllerBase
{
    private readonly IManageCustomerService _manageCustomerService;
    
    public CustomerEndpoints(IManageCustomerService manageCustomerService)
    {
        _manageCustomerService = manageCustomerService;
    }
    
    [HttpPost]
    [Authorize(Roles = "user")]
    public async Task<IActionResult> AddCustomer(CustomerRequestModel customer)
    {
        try
        {
            return Ok(await _manageCustomerService.AddCustomer(customer));
        }
        catch (NotFoundException e)
        {
            return NotFound(e.Message);
        }
    }
    
    [HttpDelete("{pesel:int}")]
    [Authorize(Roles = "admin")]
    public async Task<IActionResult> DeleteCustomer(int pesel)
    {
        try
        {
            return Ok(await _manageCustomerService.DeleteCustomer(pesel));
        }
        catch (NotFoundException e)
        {
            return NotFound(e.Message);
        }
    }
    
    [HttpPut("{pesel:int}")]
    [Authorize(Roles = "admin")]
    public async Task<IActionResult> UpdateCustomer(int pesel, CustomerRequestModel customer)
    {
        try
        {
            return Ok(await _manageCustomerService.UpdateCustomer(pesel, customer));
        }
        catch (NotFoundException e)
        {
            return NotFound(e.Message);
        }
    }
}

