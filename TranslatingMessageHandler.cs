using System;
using System.Collections.Generic;
using Translator;
using MVC.Communication;
namespace MVC.Translator {
    public class TranslatingMessageHandler : MessageHandler {
        public new static ResponseType SendException(Exception e) {
            while (e.GetType() == typeof(TypeInitializationException)) {
                e = e.InnerException;
            }

            if (e.GetType() == typeof(TranslateableException)) {
                try {
                    TranslateableException ex = e as TranslateableException;
                    StringCollection strings = Strings.getStrings(e.Message);
                    return SendMessage(strings[StringType.Title].interpret(ex.variables),
                        strings[StringType.Message].interpret(ex.variables), MessageTypes.Error, e,false);
                } catch (KeyNotFoundException) {
                    return SendMessage("Translater error", "The string " + e.Message + " could not be found", MessageTypes.Error, e, false);
                }
            } else {
                return MessageHandler.SendException(e);
            }
        }


        public static ResponseType SendInfo(string name, params string[] variables) {
            StringCollection strings = Strings.getStrings(name);

            return MessageHandler.SendInfo(strings[StringType.Title].interpret(),
                strings[StringType.Message].interpret(variables));
        }
        public static ResponseType SendWarning(string name, params string[] variables) {
            return SendWarning(name, null, false, variables);
        }
        public static ResponseType SendWarning(string name, bool suppressable, params string[] variables) {
            return SendWarning(name, null, suppressable, variables);
        }
        public static ResponseType SendWarning(string name, Exception e, params string[] variables) {
            return SendWarning(name, e, false, variables);
        }
        public static ResponseType SendWarning(string name, Exception e, bool suppressable, params string[] variables) {
            StringCollection col = Strings.getStrings(name);
            string title, message;
            if (col.ContainsKey(StringType.Title))
                title = col[StringType.Title].interpret(variables);
            else
                title = name;

            if (col.ContainsKey(StringType.Message))
                message = col[StringType.Message].interpret(variables);
            else
                message = name;

            return MessageHandler.SendWarning(title, message, e, suppressable);
        }
        public static ResponseType SendError(string name, params string[] variables) {
            return SendError(name, null, variables);
        }
        public static ResponseType SendError(string name, Exception e, params string[] variables) {
            StringCollection col = Strings.getStrings(name);
            string title, message;
            if (col.ContainsKey(StringType.Title))
                title = col[StringType.Title].interpret(variables);
            else
                title = name;

            if (col.ContainsKey(StringType.Message))
                message = col[StringType.Message].interpret(variables);
            else
                message = name;

            return MessageHandler.SendError(title, message, e);
        }
    }
}
