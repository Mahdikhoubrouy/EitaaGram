using EitaaGram.BotLib.Exceptions;
using EitaaGram.BotLib.Models;
using EitaaGram.BotLib.Network;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace EitaaGram.BotLib.Helpers
{
    internal static class JsonConvertation
    {
        public static Result<TModel> ConvertStringToObject<TModel>(this RequestSender req)
        {
            Result<TModel> Result;
            if (req.IsSuccess == true)
            {
                Result = JsonConvert.DeserializeObject<Result<TModel>>(req.Response.Content);
            }
            else
            {
                throw new OperationHasError(req.ErrorDetails.Description,req.ErrorDetails.ErrorCode);
            }


            return Result;
        }
    }

    public class Result<T>
    {
        public bool ok { get; set; }
        public T result { get; set; }
    }
}
