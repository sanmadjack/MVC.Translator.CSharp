using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MVC.Communication;
namespace MVC.Translator {
    class TrenslateableProgressUpdatedEventArgs: MVC.Communication.ProgressUpdatedEventArgs {
        public string StringName;

    }
}
