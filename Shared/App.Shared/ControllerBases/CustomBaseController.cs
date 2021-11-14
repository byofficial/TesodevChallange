using System;
using System.Collections.Generic;
using System.Text;
using App.Shared.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace App.Shared.ControllerBases
{
    public class CustomBaseController:ControllerBase
    {
        public IActionResult CreateActionResultInstance<T>(Response<T> response)
        {
            return new ObjectResult(response)
            {
                StatusCode = response.StatusCode
            };
        }
    }
}
