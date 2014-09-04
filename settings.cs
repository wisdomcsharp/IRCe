using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
namespace IRCe
{
    class settings
    {

       private string IPaddress;

       private static Window[] IRCeClients = new Window[2];
        public enum WindowType
        {
            MainWindows,
            chatClient
        }
        //window["0"] == MainWindow



        public static void _add(Window Windows, WindowType WindowsType)
        {
            switch (WindowsType)
            {
                case WindowType.MainWindows:
                    IRCeClients[0] = Windows;
                    break;

                case WindowType.chatClient:
                    IRCeClients[1] = Windows;
                    break;
            }
        }
        public static void _nullChatClient(WindowType WindowsType)
        {
            switch (WindowsType)
            {
                case WindowType.chatClient:
                  
                    IRCeClients[1] = null;
                    break;
            }
        }
        public struct WindowsVisibility
        {
            public static void Show(WindowType WindowsType)
            {
                switch (WindowsType)
                {
                 
                    case WindowType.MainWindows:
                        IRCeClients[0].Show();
                        break;
                    case WindowType.chatClient:
                        IRCeClients[1].Show();
                        break;

                }
            }

            public static void Hide(WindowType WindowsType)
            {
                switch (WindowsType)
                {

                    case WindowType.MainWindows:
                        IRCeClients[0].Hide();
                        break;
                    case WindowType.chatClient:
                        IRCeClients[1].Hide();
                        break;

                }
            }
        }


    }


}
