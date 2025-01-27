using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace drakaysa.Extensions
{
    public static class ModelStateExtensions
    {
        public static List<string> GetErrors(this ModelStateDictionary modelState)
        {
            var result = new List<string>();
            foreach (var item in modelState.Values)
            {
                foreach (var value in item.Errors)
                {
                    result.Add(value.ErrorMessage);
                }
            }

            return result;
        }
    }
}
