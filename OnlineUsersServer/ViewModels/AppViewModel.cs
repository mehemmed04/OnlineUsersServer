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
        DispatcherTimer timer = new DispatcherTimer();
        DispatcherTimer timer2 = new DispatcherTimer();
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

        }


        public void LoadCommands()
        {
            ConnectCommand = new RelayCommand((o) =>
            {
                var ip = IPAddress.Parse(IPHelper.GetLocalIpAddress());
                var port = 80;



                timer.Interval = new TimeSpan(0, 0, 1);
                timer2.Interval = new TimeSpan(0, 0, 1);
                timer.Tick += CheckClients;
                timer2.Tick += CheckMessages;
                timer.Start();
                timer2.Start();


                var ep = new IPEndPoint(ip, port);
                listener = new TcpListener(ep);
                listener.Start();
                MessageBox.Show("Connected");

            });
        }

        private void CheckMessages(object sender, EventArgs e)
        {
            //try
            //{
            //    if (listener.Pending())
            //    {
            //        var client = listener.AcceptTcpClient();
            //        Clients.Add(client);
            //        MessageBox.Show($"{client.Client.RemoteEndPoint}  connected");



            Task.Run(() =>
            {
                var reader = Task.Run(() =>
                {
                    foreach (var item in Clients)
                    {
                        Task.Run(() =>
                        {
                            _mainvindow.Dispatcher.Invoke(() =>
                            {
                                try
                                {
                                    var stream = item.GetStream();
                                    br = new BinaryReader(stream);
                                    var msg = br.ReadString();
                                   // MessageBox.Show($"CLIENT : {item.Client.RemoteEndPoint} : {msg}");
                                    Messages.Add(new Message
                                    {
                                        Content = msg,
                                        Owner = item.Client.RemoteEndPoint.ToString(),
                                    });
                                }
                                catch (Exception)
                                {

                                }
                            });

                        }).Wait(50);
                    }

                });
            });






            //}
            //}

            //catch (Exception)
            //{
            //}
        }

        private void CheckClients(object sender, EventArgs e)
        {
            try
            {
                if (listener.Pending())
                {
                    var client = listener.AcceptTcpClient();
                    Clients.Add(client);
                    MessageBox.Show($"{client.Client.RemoteEndPoint}  connected");

                    Task.Run(() =>
                    {
                        var reader = Task.Run(() =>
                        {
                            foreach (var item in Clients)
                            {
                                Task.Run(() =>
                                {
                                    _mainvindow.Dispatcher.Invoke(() =>
                                    {
                                        try
                                        {
                                            var stream = item.GetStream();
                                            br = new BinaryReader(stream);
                                            var name = br.ReadString();
                                            MessageBox.Show($"CLIENT : {client.Client.RemoteEndPoint} : {name}");
                                            Users.Add(name);
                                        }
                                        catch (Exception)
                                        {

                                        }
                                    });

                                }).Wait(50);
                            }

                        });
                    });
                }
            }

            catch (Exception)
            {
            }
        }


    }
}
