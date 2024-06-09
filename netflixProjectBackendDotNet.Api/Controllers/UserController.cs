﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using netflixProjectBackendDotNet.Api.Extensions;
using netflixProjectBackendDotNet.Api.Models.Request.User;
using netflixProjectBackendDotNet.Api.Models.Responses.User;
using netflixProjectBackendDotNet.Domain.Repositories;
using System.Security.Claims;

namespace netflixProjectBackendDotNet.Api.Controllers;
[ApiController]
[Route("/[controller]")]
public class UserController : ControllerBase
{
    private readonly IUserRepository _userRepository;

    public UserController(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    [HttpGet("show")]
    [Authorize]
    public async Task<IActionResult> GetUserAsync()
    {
        var user = new UserResponse
        {
            Birth = HttpContext.User.FindFirstValue(ClaimTypes.DateOfBirth),
            Email = HttpContext.User.FindFirstValue(ClaimTypes.Email),
            FirstName = HttpContext.User.FindFirstValue(ClaimTypes.Name),
            LastName = HttpContext.User.FindFirstValue(ClaimTypes.Surname),
            Phone = HttpContext.User.FindFirstValue(ClaimTypes.MobilePhone),
            Id = HttpContext.GetUserId().Value,
        };

        return Ok(user);
    }

    [HttpPut("current")]
    [Authorize]
    public async Task<IActionResult> UpdateUserAsync([FromBody] UpdateUserRequest request)
    {
        var userId = HttpContext.GetUserId();

        if (userId is null)
        {
            return BadRequest("UserNotFound");
        }

        var result = await _userRepository.UpdateAsync(request.ToUserEntity(userId.Value));

        return result is null ?
            BadRequest("User not found") :
            Ok(UserResponse.ToResponse(result));
    }

    [HttpPut("current/password")]
    [Authorize]
    public async Task<IActionResult> UpdatePasswordAsync([FromBody] UpdatePasswordRequest request)
    {
        var userId = HttpContext.GetUserId();

        if (userId is null)
        {
            return BadRequest("UserNotFound");
        }

        var passwordMatch = await _userRepository.CheckPasswordAsync(userId.Value, request.CurrentPassword);

        if (passwordMatch)
        {
            var updated = await _userRepository.UpdatePasswordAsync(userId.Value, request.NewPassword);

            return updated is null ?
                BadRequest("Cannot update user password") :
                Ok();
        }

        return BadRequest("Password does not match");

    }

}
