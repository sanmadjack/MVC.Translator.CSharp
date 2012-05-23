using System.Collections.Generic;
using Translator;
namespace Communication.Translator {
    public class TranslatingRequestHandler : RequestHandler {

        public static RequestReply Request(RequestType type, string name, params string[] variables) {

            return TranslatingRequestHandler.Request(type, name, null, variables);
        }

        public static RequestReply Request(RequestType type, string name, List<string> choices, params string[] variables) {
            return TranslatingRequestHandler.Request(type, name, null, choices, variables);
        }

        public static RequestReply Request(RequestType type, string name, string default_choice, List<string> choices, params string[] variables) {
            StringCollection col = Strings.getStrings(name);

            return RequestHandler.Request(type, col[StringType.Title].interpret(), col[StringType.Message].interpret(variables), choices, default_choice);

        }
    }
}
