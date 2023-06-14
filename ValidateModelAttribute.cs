using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc;

namespace CodeFirstApproach12
{
    public class ValidateModelAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            var param = context.ActionArguments.SingleOrDefault();
            if (param.Value == null)
            {
                context.Result = new BadRequestObjectResult("Model is null");
                return;
            }
            if (!context.ModelState.IsValid)
            {
                context.Result = new BadRequestObjectResult(context.ModelState);
            }
        }
        public override void OnActionExecuted(ActionExecutedContext context)
        {
        }
    }
}