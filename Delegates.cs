using Fooxboy.FusionBot.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Fooxboy.FusionBot
{
    public class Delegates
    {
        public delegate void NewMessage(MessageVK message);
        public delegate void MessageAllowOrDeny(Models.MessageAllowModel model);
        public delegate void NewError(Exception e);

    }
}
