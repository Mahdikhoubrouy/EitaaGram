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
        public static TModel ConvertStringToObject<TModel>(this RequestSender req)
        {
            TModel Result;
            if (req.IsSuccess == true)
            {
                Result = JsonConvert.DeserializeObject<TModel>(req.Response.Content);
            }
            else
            {
                throw new OperationHasError(req.ErrorDetails.Message, req.ErrorDetails.Message);
            }

            return Result;
        }
    }
}
