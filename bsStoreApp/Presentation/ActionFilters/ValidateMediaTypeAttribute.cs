using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Net.Http.Headers;

namespace Presentation.ActionFilters
{
    public class ValidateMediaTypeAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            var acceptHeaderPresernt = context.HttpContext
                .Request.Headers.ContainsKey("Accept");

            if (!acceptHeaderPresernt)
            {
                context.Result = new BadRequestObjectResult($"Accept header is missing!");
            }
            var mediaTypes=context.HttpContext.Request
                .Headers["Accept"].FirstOrDefault();
            if (!MediaTypeHeaderValue.TryParse(mediaTypes, out MediaTypeHeaderValue? outMediaType))
            {
                context.Result = new BadRequestObjectResult($"Media type not present." +
                    $"Plase add Accept header with required media type.");
                return;
            }
            context.HttpContext.Items.Add("AcceptHeaderMediaType",outMediaType);
        }
    }
}
