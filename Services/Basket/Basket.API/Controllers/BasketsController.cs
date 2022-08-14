﻿using Basket.API.Dtos;
using Basket.API.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Shared.BaseController;
using Shared.Interfaces;

namespace Basket.API.Controllers;

public class BasketsController : BaseController
{
    private readonly IBasketService _basketService;
    private readonly ISharedIdentityService _sharedIdentityService;
    
    public BasketsController(IBasketService basketService, ISharedIdentityService sharedIdentityService)
    {
        _basketService = basketService;
        _sharedIdentityService = sharedIdentityService;
    }
    
    [HttpGet]
    public async Task<IActionResult> Get()
    {
        return CreateActionResultInstance(await _basketService.GetBasket(_sharedIdentityService.GetUserId));
    }
    
    [HttpPost]
    public async Task<IActionResult> SaveOrUpdate(BasketDto basketDto)
    {
       var response = await _basketService.SaveOrUpdate(basketDto);
       return CreateActionResultInstance(response);
    }
    
    [HttpDelete]
    public async Task<IActionResult> Delete()
    {
        return CreateActionResultInstance(await _basketService.Delete(_sharedIdentityService.GetUserId));
    }
}