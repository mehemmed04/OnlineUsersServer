using OnlineUsersServer.Commands;
using OnlineUsersServer.Helpers;
using OnlineUsersServer.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Threading;

namespace OnlineUsersServer.ViewModels
{
    public class AppViewModel : BaseViewModel
    {
        static TcpListener listener = null;
        static BinaryWriter bw = null;
        static BinaryReader br = null;
        public MainWindow _mainvindow { get; set; }
        public ListView UsersListView { get; set; }

        private ObservableCollection<Message> messages;

        public ObservableCollection<Message> Messages
        {
            get { return messages; }
            set { messages = value; OnPropertyChanged(); }
        }



        private ObservableCollection<string> users;

        public ObservableCollection<string> Users
        {
            get { return users; }
            set { users = value; OnPropertyChanged(); }
        }


        public RelayCommand ConnectCommand { get; set; }
        public static List<TcpClient> Clients { get; set; }
        public AppViewModel(MainWindow vindow)
        {
            Clients = new List<TcpClient>();
            Users = new ObservableCollection<string>();
            Messages = new ObservableCollection<Message>();
            _mainvindow = vindow;
            LoadCommands();


            
            Task.Run(() =>
            {
                while (true)
                {

                    foreach (var item in Clients)
                    {
                        while (true)
                        {
                            try
                            {
                                NetworkStream stream = item.GetStream();
                                byte[] data = new byte[item.ReceiveBufferSize];
                                int bytesRead = stream.Read(data, 0, data.Length);
                                string message = Encoding.ASCII.GetString(data, 0, bytesRead);
                                Message msg = JsonHelper.GetMessageFromString(message);
                                MessageBox.Show($"{msg.Owner} : {msg.Client}");
                                Messages.Add(msg);
                                Users.Add(msg.Owner);
                                break;
                            }
                            catch (Exception)
                            {

                            }
                        Task.Delay(2000);
                        }
                    }
                }
            });


        }


        public void LoadCommands()
        {
            ConnectCommand = new RelayCommand((o) =>
            {
                var ip = IPAddress.Parse(IPHelper.GetLocalIpAddress());
                var port = 80;

                var ep = new IPEndPoint(ip, port);
                listener = new TcpListener(ep);
                listener.Start();
                MessageBox.Show("Connected");

                Task.Run(() =>
                {
                    while (true)
                    {
                        try
                        {
                            if (listener.Pending())
                            {
                                var client = listener.AcceptTcpClient();
                                Clients.Add(client);
                                MessageBox.Show("Client Added");
                            }
                        }
                        catch (Exception)
                        {

                        }
                    }
                });


            });
        }



    }
}
