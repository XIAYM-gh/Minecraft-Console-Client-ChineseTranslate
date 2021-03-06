﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MinecraftClient.ChatBots
{
    /// <summary>
    /// Example of message receiving.
    /// </summary>

    public class TestBot : ChatBot
    {
        public override void GetText(string text)
        {
            string message = "";
            string username = "";
            text = GetVerbatim(text);

            if (IsPrivateMessage(text, ref message, ref username))
            {
                LogToConsole("TestBot: " + username + " 告诉我 : " + message);
            }
            else if (IsChatMessage(text, ref message, ref username))
            {
                LogToConsole("TestBot: " + username + " 说 : " + message);
            }
        }
    }
}
