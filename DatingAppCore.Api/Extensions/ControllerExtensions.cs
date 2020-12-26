using CommonCore.Api.Extensions;
using CommonCore.Models.Responses;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace DatingAppCore.Api.Extensions
{
    public static class ControllerExtensions
    {
        public static IActionResult Return200Or500<T>(this Controller controller, ApiResponse<T> response)
            => response.Sucess ? controller.StatusCode(500, response) : controller.StatusCode(500, response);

    }
}
