using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IRCe
{
    public static class server
    {
        public static State state;
        public enum _Try
        {
            Connect,
            Disconnect,
        }

        public enum State
        {
            Connected,
            Disconnected

        }


        public static State Task(_Try try_, string[] Account)
        {
            string domain = Account[0], username = Account[1];

           //string fetch = "http://g"


            switch (try_)
            {

                case _Try.Connect:


                    
                    break;


                case _Try.Disconnect:

                    break;


                default:
                  state = State.Disconnected;
                    return state;
                 
            }



            state = State.Disconnected;
            return state;

        }


    }


}
