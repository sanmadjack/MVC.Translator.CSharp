using System;
using Translator;
namespace Communication.Translator {
    public class TranslatingProgressHandler : ProgressHandler {
        public static void setTranslatedMessage(string name, params string[] variables) {
            String line = Strings.getString(StringType.Message, name, variables);
            ProgressHandler.message = line;

        }
    }
}
