using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

using System.Threading;
namespace IRCe
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            settings._add(this, settings.WindowType.MainWindows);
            
        }
        string[] Account;
        chatClient _newChat;

       private enum Write{
           connectionFailed,
           resetStatus
            

        }
      private void UIwriter(Write write)
        {
            Application.Current.Dispatcher.Invoke(new Action(() =>
                {

                    switch (write)
                    {

                        case Write.connectionFailed:
                            this.status.Visibility = Visibility.Visible;
                            status.Content = "isConnected = false";
                            break;

                        case Write.resetStatus:
                            this.status.Visibility = Visibility.Hidden;
                            status.Content = string.Empty;
                            break;
                    }





                
                }));
        }




        private void Button_PreviewMouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {

            
            Account = new string[] { "http://wisdom.com", "Wisdom" };
            if (server.State.Connected == server.Task(server._Try.Connect, Account))
            {
          

                settings.WindowsVisibility.Hide(settings.WindowType.MainWindows);
                _newChat = new chatClient();
                _newChat.Closed += (Sender_, Args_) => {

                  settings._nullChatClient(settings.WindowType.chatClient);//Relase some memory *for performance
                  settings.WindowsVisibility.Show(settings.WindowType.MainWindows);

                };
                settings._add(_newChat, settings.WindowType.chatClient);
                settings.WindowsVisibility.Show(settings.WindowType.chatClient);

            }
            else
            {
                (new Thread(() =>
                {
                    UIwriter(Write.connectionFailed);
                    Thread.Sleep(2000);
                    UIwriter(Write.resetStatus);
                })).Start();
            }




        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }







    }



}
