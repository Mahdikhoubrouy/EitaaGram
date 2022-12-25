using EitaaGram.BotLib.Exceptions;
using EitaaGram.BotLib.Network;
using Newtonsoft.Json;

namespace EitaaGram.BotLib.Helpers
{
    internal static class JsonConvertation
    {
        public static Result<TModel> ConvertStringToObject<TModel>(this RequestSender req)
        {
            bool error = false;
            Result<TModel> Result = default;
            if (req.IsSuccess == true)
            {
                Result = JsonConvert.DeserializeObject<Result<TModel>>(req.Response.Content);
            }
            else
            {
                error = true;
            }

            if(error == true)
                throw new OperationHasError(req.ErrorDetails.description, req.ErrorDetails.error_code);

            return Result;
        }
    }

    public class Result<T>
    {
        public bool ok { get; set; }
        public T result { get; set; }
    }
}
