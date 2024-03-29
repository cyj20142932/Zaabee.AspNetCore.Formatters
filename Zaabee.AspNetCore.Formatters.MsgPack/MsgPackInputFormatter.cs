using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Formatters;
using Microsoft.Net.Http.Headers;
using Zaabee.MsgPack;

namespace Zaabee.AspNetCore.Formatters.MsgPack
{
    public class MsgPackInputFormatter : InputFormatter
    {
        public MsgPackInputFormatter(MediaTypeHeaderValue contentType) => SupportedMediaTypes.Add(contentType);

        public override Task<InputFormatterResult> ReadRequestBodyAsync(InputFormatterContext context)
        {
            var result = context.HttpContext.Request.Body.FromMsgPak(context.ModelType);
            return InputFormatterResult.SuccessAsync(result);
        }
    }
}