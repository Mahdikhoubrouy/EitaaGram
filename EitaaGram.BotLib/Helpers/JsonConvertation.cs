using EitaaGram.BotLib.Exceptions;
using EitaaGram.BotLib.Network;
using Newtonsoft.Json;

namespace EitaaGram.BotLib.Helpers
{
    internal static class JsonConvertation
    {
        public static TModel ConvertStringToObject<TModel>(this RequestSender req)
        {
            Result<TModel> Result = default;
            if (req.IsSuccess == true)
            {
                Result = JsonConvert.DeserializeObject<Result<TModel>>(req.Response.Content.ReadAsStringAsync().GetAwaiter().GetResult());
            }
            else
            {
                throw new OperationHasError(req.ErrorDetails.description, req.ErrorDetails.error_code);
            }

            return Result.result;
        }
    }

    public class Result<T>
    {
        public bool ok { get; set; }
        public T result { get; set; }
    }
}
