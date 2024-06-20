using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace DRAKaysa.Services
{
    public static class ModelStateExtensions
    {
        public static List<string> GetErrors(this ModelStateDictionary modelState)
        {
            return modelState.Values.SelectMany(v => v.Errors)
                                    .Select(e => e.ErrorMessage)
                                    .ToList();
        }
    }
}
