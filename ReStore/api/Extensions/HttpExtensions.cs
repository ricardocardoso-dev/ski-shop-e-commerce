using System.Text.Json;
using api.RequestHelpers;

namespace api.Extensions
{
    public static class HttpExtensions
	{
        public static void AddPaginationHeader(this HttpResponse response, MetaData metaData)
		{
			var options = new JsonSerializerOptions{PropertyNamingPolicy = JsonNamingPolicy.CamelCase};
			
			response.Headers.Append("Pagination", JsonSerializer.Serialize(metaData, options));
			response.Headers.Append("Access-Control-Expose-Headers", "Pagination");
		}
	}
}