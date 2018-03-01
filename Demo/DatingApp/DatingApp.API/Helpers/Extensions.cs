using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace DatingApp.API.Helpers
{
    public static class Extensions
    {
        /// <summary>
        /// Add application error to response, including appropriate header values
        /// </summary>
        /// <param name="response">HttpResponse object</param>
        /// <param name="message">Error message</param>
        /// <returns>Task of void</returns>
        public static async Task AddApplicationErrorcAsync(this HttpResponse response, string message)
        {
            response.Headers.Add("Application-Error", message);
            response.Headers.Add("Access-Control-Expose-Headers", "Application-Error");
            response.Headers.Add("Access-Control-Allow-Origin", "*");
            
            await response.WriteAsync(message);
        }
    }
}