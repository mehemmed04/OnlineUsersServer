using OnlineUsersServer.Helpers;
using OnlineUsersServer.ViewModels;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace OnlineUsersServer
{
    public partial class MainWindow : Window
    {
       
        //public void SetListViewSource()
        //{
        //    ClientsListView.ItemsSource = null;
        //    ClientsListView.ItemsSource = Users;
        //    //  ClientsListView.DisplayMemberPath = "value";
        //}

        //private void CheckClients(object sender, EventArgs e)
        //{
        //    try
        //    {
        //        if (listener.Pending())
        //        {
        //            var client = listener.AcceptTcpClient();
        //            Clients.Add(client);
        //            MessageBox.Show($"{client.Client.RemoteEndPoint}  connected");
                    
        //            Task.Run(() =>
        //            {
        //                var reader = Task.Run(() =>
        //                {
        //                    foreach (var item in Clients)
        //                    {
        //                        Task.Run(() =>
        //                        {
        //                            try
        //                            {
        //                                var stream = item.GetStream();
        //                                br = new BinaryReader(stream);
        //                                var name = br.ReadString();
        //                                MessageBox.Show($"CLIENT : {client.Client.RemoteEndPoint} : {name}");
        //                                Users.Add(name);
        //                                SetListViewSource();
        //                            }
        //                            catch (Exception)
        //                            {

        //                            }
        //                            //while (true)
        //                            //{
        //                            //    try
        //                            //    {
        //                            //        //AllClients.Add(client, msg);
        //                            //       // SetListViewSource();

        //                            //    }
        //                            //    catch (Exception ex)
        //                            //    {
        //                            //        // Clients.Remove(item);
        //                            //    }
        //                            //}
        //                        }).Wait(50);
        //                    }

        //                });
        //            });
        //        }
        //    }

        //    catch (Exception)
        //    {
        //    }
        //}

        public MainWindow()
        {
            InitializeComponent();

            DataContext = new AppViewModel(this);

          


        }

        //private void ConnectBtn_Click(object sender, RoutedEventArgs e)
        //{
        //    //var ip = IPAddress.Parse(IPHelper.GetLocalIpAddress());
        //    //var port = 80;



        //    //timer.Interval = new TimeSpan(0, 0, 1);
        //    //timer.Tick += CheckClients;
        //    //timer.Start();


        //    //var ep = new IPEndPoint(ip, port);
        //    //listener = new TcpListener(ep);
        //    //listener.Start();
        //    //MessageBox.Show("Connected");



        //    //Task.Run(() =>
        //    //{
        //    //var reader = Task.Run(() =>
        //    //{
        //    //    foreach (var item in Clients)
        //    //    {
        //    //        //Task.Run(() =>
        //    //        //{
        //    //        //    var stream = item.GetStream();
        //    //        //    br = new BinaryReader(stream);
        //    //        //    while (true)
        //    //        //    {
        //    //        //        try
        //    //        //        {
        //    //        //            var msg = br.ReadString();
        //    //        //            MessageBox.Show($"CLIENT : {client.Client.RemoteEndPoint} : {msg}");
        //    //        //        }
        //    //        //        catch (Exception ex)
        //    //        //        {
        //    //        //            Clients.Remove(item);
        //    //        //        }
        //    //        //    }
        //    //        //}).Wait(50);
        //    //    }

        //    //});

        //    //var writer = Task.Run(() =>
        //    //{
        //    //    while (true)
        //    //    {
        //    //        //var msg = Console.ReadLine();
        //    //        //foreach (var item in Clients)
        //    //        //{
        //    //        //    var stream = item.GetStream();
        //    //        //    bw = new BinaryWriter(stream);
        //    //        //    bw.Write(msg);
        //    //        //}
        //    //        //foreach (var item in Clients)
        //    //        //{
        //    //        //    if (item.Connected)
        //    //        //    {
        //    //        //        Console.ForegroundColor = ConsoleColor.Green;
        //    //        //    }
        //    //        //    else
        //    //        //    {
        //    //        //        Console.ForegroundColor = ConsoleColor.Red;
        //    //        //    }
        //    //        //    //Console.WriteLine($"item : {item.Client.RemoteEndPoint}");
        //    //        //    //Console.ResetColor();
        //    //        //}
        //    //    }
        //    //});
        //    // });
        //}
    }
}
