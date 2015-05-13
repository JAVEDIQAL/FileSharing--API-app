using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.Net.Sockets;
using System.Net.NetworkInformation;
using System.Threading;
using System.IO;
using System.Runtime.InteropServices;
using FileSharing_Project.Properties;
namespace ReClient_ServerWinforms
{
      public partial class Form1 : Form
    {      

        private static string FileName = "";
        private static string path = "";            
        public int bufferSize = 100*1024*1024;
        public bool Cancellation=false;

        NetworkStream netstream;
        FileStream fs;

        //TcpClient clientSocket = new TcpClient();
        //Suffixes

        static readonly string[] SizeSuffixes = { "bytes", "KB", "MB", "GB", "TB", "PB", "EB", "ZB", "YB" };
       // public static bool CheckForIllegalCrossThreadCalls=false;
               
        public Form1()
        {
            InitializeComponent();
          
        }
        
        private void Form1_Load(object sender, EventArgs e)
        {
            //pictureBox.Image = Properties.Resources.Information;
            this.BackColor = System.Drawing.Color.BurlyWood;
            System.Windows.Forms.StatusStrip ss1 = new System.Windows.Forms.StatusStrip();
            ss1.Location= new System.Drawing.Point(0, 251);
            ss1.Name = "statusStrip2";
            ss1.Size = new System.Drawing.Size(292, 22);
            ss1.TabIndex = 0;
            ss1.Text = "statusStrip2";
            this.Controls.Add(ss1);
            this.PerformLayout();
            lstLocal.View = View.Details;
            lstLocal.Clear();
            lstLocal.GridLines = true;
            lstLocal.FullRowSelect = true;
            lstLocal.BackColor = System.Drawing.Color.Aquamarine;
            lstLocal.Columns.Add("IP",100);
            lstLocal.Columns.Add("HostName", 200);
            lstLocal.Columns.Add("MAC Address",500);
            lstLocal.Sorting = SortOrder.Descending;
            RefreshlstLocal();
            SS.Refresh();

          
        }

          public void RefreshlstLocal()
           {
              
             
              IPAddress ip_addr=IPAddress.None;
              PhysicalAddress mac=PhysicalAddress.None;
              IPNET_Table ipnt=new IPNET_Table();         
              Dictionary<IPAddress, PhysicalAddress> all = ipnt.GetAllDevicesOnLAN();             
              ListViewItem lv;
              string []arr=new string[3];
              foreach (KeyValuePair<IPAddress, PhysicalAddress> kvp in all)
              {
                 ip_addr=kvp.Key;
                 arr[0]=ip_addr.ToString();
                 string put_ip=ip_addr.ToString();
                 string get_mac  =GetMacAddress(put_ip);
                 string hostname = GetHostName(put_ip);
                // MessageBox.Show(hostname);
                arr[1] = hostname;
                arr[2]=get_mac;
                lv= new ListViewItem(arr);
                  lstLocal.Items.Add(lv);
                  int count = lstLocal.Items.Count;
                  toolStripStatusLabel4.Text = string.Format(count.ToString() + " Item(s)");
              }
                      
          }


          
          public string GetMacAddress(string ipAddress)
          {
              string macAddress = string.Empty;
              System.Diagnostics.Process Process = new System.Diagnostics.Process();
              Process.StartInfo.FileName = "arp";
              Process.StartInfo.Arguments = "-a " + ipAddress;
              Process.StartInfo.UseShellExecute = false;
              Process.StartInfo.RedirectStandardOutput = true;
              Process.StartInfo.CreateNoWindow = true;
              Process.Start();
              string strOutput = Process.StandardOutput.ReadToEnd();
              string[] substrings = strOutput.Split('-');
              if (substrings.Length >= 8)
              {
                  macAddress = substrings[3].Substring(Math.Max(0, substrings[3].Length - 2))
                           + "-" + substrings[4] + "-" + substrings[5] + "-" + substrings[6]
                           + "-" + substrings[7] + "-"
                           + substrings[8].Substring(0, 2);
                  return macAddress;
              }

              else
              {
                  return "OWN Machine";
              }
          }

          public string GetHostName(string ipAddress)
          {
              try
              {
                  IPHostEntry entry = Dns.GetHostEntry(ipAddress);
                  if (entry != null)
                  {
                      return entry.HostName;
                  }
              }
              catch (SocketException ex)
              {
                 //  MessageBox.Show(ex.Message.ToString());
              }

              return null;
          }




        private void lstLocal_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lstLocal.SelectedItems.Count > 0)
            {
                ListViewItem item = lstLocal.SelectedItems[0];
                IPAddr_Serv.Text = item.SubItems[0].Text;
                IPAddr_Client.Text = item.SubItems[0].Text;
               Random rand=new  Random();

               PortNo_Client.Text = (rand.Next(1023, 65536)).ToString();
               PortNo_serv.Text = PortNo_Client.Text;
            }
            else
            {
                IPAddr_Serv.Text = string.Empty;
                
            }
        }
        //}
        // toolStripStatusLabel3.Text = string.Format("Scanning: {0}",i);     
                
               

                //else
                //{
                //    //item = new ListViewItem(arr);
                //    lstLocal.Items.Add(item);
                //}

                // Logic for Ping Reply Success

                // Console.WriteLine(String.Format("Host: {0} ping successful", ip));
          



















              
        
        
    //---------------------------------------------CLIENT SIDE--------------------------------------------------------------------------------
        
        
        private void btnBrowse_Click_1(object sender, EventArgs e)
        {
            OpenFileDialog dlg = new OpenFileDialog();
            dlg.Title = "File Sharing Client";
            dlg.ShowDialog();           
            SelectFile.Text= dlg.FileName;
            path = SelectFile.Text;
            FileName = dlg.SafeFileName;

        }
        void TransmitFileName(Stream stream, string fileName)
        {
            byte[] fileNameBytes = Encoding.UTF8.GetBytes(fileName),
            fileNameLengthBytes = BitConverter.GetBytes(fileNameBytes.Length);
            stream.Write(fileNameLengthBytes, 0, 4);
            stream.Write(fileNameBytes, 0, fileNameBytes.Length);
        }



        private void btnSend_Click_1(object sender, EventArgs e)
        {

            // show animated image
            pictureBox.Image = FileSharing_Project.Properties.Resources.Animation;
            labelProgress.Text="Copying in Progress";
            // change button states
            btnSend.Enabled = false;
            btn_Cancel.Enabled = true;

            TcpClient clientSocket = new TcpClient();
            // client.Connect(IPAddr_Client.Text, 8004);
            IPAddress ipaddrcl = IPAddress.Parse(IPAddr_Client.Text);
            int port = Convert.ToInt32(PortNo_Client.Text);

            // Connect to server
            try
            {
                clientSocket.Connect(new IPEndPoint(ipaddrcl, port));

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);

            }
           
             netstream = clientSocket.GetStream();

            using (FileStream fs = new FileStream(path, FileMode.Open, FileAccess.Read))
            {

                try
                {
                   

                    TransmitFileName(netstream, Path.GetFileName(path));
                    int data_len = (int)fs.Length;
                    byte[] buffer = new byte[bufferSize];
                    int totalbytes = 0;
                    while (totalbytes < data_len)
                    {
                        pictureBox.Image = FileSharing_Project.Properties.Resources.Animation;
                        var bytesread = fs.Read(buffer, 0, buffer.Length);
                       
                        if (totalbytes == data_len)
                        {

                            pictureBox.Image = null;
                            break;
                        }
                        try
                        {

                                netstream.Write(buffer, 0, bytesread);
                                totalbytes += bytesread;
                          
                                                          

                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message);
                            pictureBox.Image = FileSharing_Project.Properties.Resources.Warning;
                            labelProgress.Text = "Error in transmission";

                        }
                    }

                }

                finally
                {

                    MessageBox.Show("Data transfer completed");
                    labelProgress.Text = "Copying Done";
                    pictureBox.Image = FileSharing_Project.Properties.Resources.Information;
                    fs.Close();
                    netstream.Close();
                    // change button states
                    btnSend.Enabled = true;
                    btn_Cancel.Enabled = false;
                }

            }
            
        }

        private void btn_Cancel_Click(object sender, EventArgs e)
        {
            if (Cancellation == true)
            {
                pictureBox.Image = FileSharing_Project.Properties.Resources.Warning;
                DialogResult dialogResult = MessageBox.Show("Are you Sure you want to cancel the copying?", "Copying Process", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    netstream.Close();
                   labelProgress.Text = "Operation Cancelled by User";
                    
                }
                else if (dialogResult == DialogResult.No)
                {
                    fs.Close();
                    //do nothing
                }
              

            }
        }   

       /* private void btnlisten_Click(object sender, EventArgs e)
        { }*/


//-----------------------------------------------SERVER SIDE----------------------------------------------------------------------------------------------------------------
        private void btnlisten_Click_1(object sender, EventArgs e)
        {
            ThreadStart threaddelegate = new ThreadStart(Thread);
            Thread newthread = new Thread(threaddelegate);
            newthread.Start();

        }
        string DecodeFileName(Stream stream)
        {
            byte[] fileNameLengthBuffer = new byte[4];

            FillBufferFromStream(stream, fileNameLengthBuffer);
            int fileNameLength = BitConverter.ToInt32(fileNameLengthBuffer, 0);
            byte[] fileNameBuffer = new byte[fileNameLength];
            FillBufferFromStream(stream, fileNameBuffer);
            return Encoding.UTF8.GetString(fileNameBuffer);
        }

        void FillBufferFromStream(Stream stream, byte[] buffer)
        {
            int cbTotal = 0;
            while (cbTotal < buffer.Length)
            {
                int cbRead = stream.Read(buffer, cbTotal, buffer.Length - cbTotal);

                if (cbRead == 0)
                {
                    throw new InvalidDataException("premature end-of-stream");
                }

                cbTotal += cbRead;
            }
        }

        public void Thread()
        {
            IPAddress ipaddr = IPAddress.Parse(IPAddr_Serv.Text);
            var port = Convert.ToInt32(PortNo_serv.Text);          
            ConnectionState(ipaddr,port);
       
        }
        private void btnClear_Click(object sender, EventArgs e)
        {
            IPAddr_Serv.Text = null;
            PortNo_serv.Text = null;
            labelProgress.Text = null;
        }

        public void ConnectionState(IPAddress ipaddr,Int32 port) 
        {
           TcpClient client = new TcpClient();
            // Accept client
           TcpListener tcpListener = new TcpListener(ipaddr, port);
           tcpListener.Start();
           MessageBox.Show("Listening on port " + port);
           client = tcpListener.AcceptTcpClient();
           NetworkStream netStream = client.GetStream();
           string DirName = @"D:\Javed\Test\";
           string fileloc = Path.Combine(DirName, DecodeFileName(netStream));
           Directory.CreateDirectory(Path.GetDirectoryName(fileloc));
          
           try
            {
                pictureBox2.Image = FileSharing_Project.Properties.Resources.philips;
                using (fs = new FileStream(fileloc, FileMode.OpenOrCreate, FileAccess.Write))
                {
                    
                    netStream.CopyTo(fs);               
                   // label_server.Text = "Receiving Data";
                }


            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message.ToString());


            }
            finally
            {

                //check the size of file recieved 
                FileInfo fi = new FileInfo(fileloc);
                long siz = fi.Length;
                MessageBox.Show("Data Recieved: File Size is " + SizeSuffix(siz));
                pictureBox2.Image = null;
               // Thread();

          }             
        }
        

        //method to get size in Kb/Mb/Gb etc.
        static string SizeSuffix(Int64 value)
        {
            if (value < 0) { return "-" + SizeSuffix(-value); }
            if (value == 0) { return "0.0 bytes"; }

            int mag = (int)Math.Log(value, 1024);
            decimal adjustedSize = (decimal)value / (1L << (mag * 10));

            return string.Format("{0:n1} {1}", adjustedSize, SizeSuffixes[mag]);
        }

   //     private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        //{}

       
        
            

        private void Refresh_button_Click(object sender, EventArgs e)
        {

            lstLocal.Clear();
            lstLocal.View = View.Details;           
            lstLocal.GridLines = true;
            lstLocal.FullRowSelect = true;
            lstLocal.Columns.Add("IP", 100);
            lstLocal.Columns.Add("HostName", 200);
            lstLocal.Columns.Add("MAC Address", 300);
            RefreshlstLocal();

        }




        private void CLear_Click(object sender, EventArgs e)
        {
            IPAddr_Client.Text = null;
            PortNo_Client.Text = null;
           
        }

        private void SS_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void toolStripStatusLabel2_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("http://www.puretechh.com");
        }

        private void toolStripProgressBar2_Click(object sender, EventArgs e)
        {

        }

        private void toolStripStatusLabel4_Click(object sender, EventArgs e)
        {

        }

        

        //private void button1_Click(object sender, EventArgs e)
        //{

        //}








        //private void IPAddr_Serv_TextChanged(object sender, EventArgs e)
        //{

        //}





        //private void textBox2_TextChanged(object sender, EventArgs e)
        //{

        //}

    
public  string arr { get; set; }}
    class IPNET_Table
    {
     [StructLayout(LayoutKind.Sequential)]
        struct MIB_IPNETROW
        {
            [MarshalAs(UnmanagedType.U4)]
            public int dwIndex;
            [MarshalAs(UnmanagedType.U4)]
            public int dwPhysAddrLen;
            [MarshalAs(UnmanagedType.U1)]
            public byte mac0;
            [MarshalAs(UnmanagedType.U1)]
            public byte mac1;
            [MarshalAs(UnmanagedType.U1)]
            public byte mac2;
            [MarshalAs(UnmanagedType.U1)]
            public byte mac3;
            [MarshalAs(UnmanagedType.U1)]
            public byte mac4;
            [MarshalAs(UnmanagedType.U1)]
            public byte mac5;
            [MarshalAs(UnmanagedType.U1)]
            public byte mac6;
            [MarshalAs(UnmanagedType.U1)]
            public byte mac7;
            [MarshalAs(UnmanagedType.U4)]
            public int dwAddr;
            [MarshalAs(UnmanagedType.U4)]
            public int dwType;
        }

      /// <returns></returns>
        [DllImport("IpHlpApi.dll")]
        [return: MarshalAs(UnmanagedType.U4)]
        static extern int GetIpNetTable(IntPtr pIpNetTable,
              [MarshalAs(UnmanagedType.U4)] ref int pdwSize, bool bOrder);
        const int ERROR_INSUFFICIENT_BUFFER = 122;
    public  Dictionary<IPAddress, PhysicalAddress> GetAllDevicesOnLAN()
        {
            Dictionary<IPAddress, PhysicalAddress> all = new Dictionary<IPAddress, PhysicalAddress>();
            // Add this PC to the list...
            all.Add(GetIPAddress(), GetMacAddress());
            int spaceForNetTable = 0;
            // Get the space needed
            // We do that by requesting the table, but not giving any space at all.
            // The return value will tell us how much we actually need.
            GetIpNetTable(IntPtr.Zero, ref spaceForNetTable, false);
            // Allocate the space
            // We use a try-finally block to ensure release.
            IntPtr rawTable = IntPtr.Zero;
            try
            {
                rawTable = Marshal.AllocCoTaskMem(spaceForNetTable);
                // Get the actual data
                int errorCode = GetIpNetTable(rawTable, ref spaceForNetTable, false);
                if (errorCode != 0)
                {
                    // Failed for some reason - can do no more here.
                    throw new Exception(string.Format(
                      "Unable to retrieve network table. Error code {0}", errorCode));
                }
                // Get the rows count
                int rowsCount = Marshal.ReadInt32(rawTable);
                IntPtr currentBuffer = new IntPtr(rawTable.ToInt64() + Marshal.SizeOf(typeof(Int32)));
                // Convert the raw table to individual entries
                MIB_IPNETROW[] rows = new MIB_IPNETROW[rowsCount];
                for (int index = 0; index < rowsCount; index++)
                {
                    rows[index] = (MIB_IPNETROW)Marshal.PtrToStructure(new IntPtr(currentBuffer.ToInt64() +
                                                (index * Marshal.SizeOf(typeof(MIB_IPNETROW)))
                                               ),
                                                typeof(MIB_IPNETROW));
                }
                // Define the dummy entries list (we can discard these)
                PhysicalAddress virtualMAC = new PhysicalAddress(new byte[] { 0, 0, 0, 0, 0, 0 });
                PhysicalAddress broadcastMAC = new PhysicalAddress(new byte[] { 255, 255, 255, 255, 255, 255 });
                foreach (MIB_IPNETROW row in rows)
                {
                    IPAddress ip = new IPAddress(BitConverter.GetBytes(row.dwAddr));
                    byte[] rawMAC = new byte[] { row.mac0, row.mac1, row.mac2, row.mac3, row.mac4, row.mac5 };
                    PhysicalAddress pa = new PhysicalAddress(rawMAC);
                    if (!pa.Equals(virtualMAC) && !pa.Equals(broadcastMAC) && !IsMulticast(ip))
                    {
                        //Console.WriteLine("IP: {0}\t\tMAC: {1}", ip.ToString(), pa.ToString());
                        if (!all.ContainsKey(ip))
                        {
                            all.Add(ip, pa);
                        }
                    }
                }
            }
            finally
            {
                // Release the memory.
                Marshal.FreeCoTaskMem(rawTable);
            }
            return all;
        }

        /// <summary>
        /// Gets the IP address of the current PC
        /// </summary>
        /// <returns></returns>
        public static IPAddress GetIPAddress()
        {
            String strHostName = Dns.GetHostName();
            IPHostEntry ipEntry = Dns.GetHostEntry(strHostName);
            IPAddress[] addr = ipEntry.AddressList;
            foreach (IPAddress ip in addr)
            {
                if (!ip.IsIPv6LinkLocal)
                {
                    return (ip);
                }
            }
            return addr.Length > 0 ? addr[0] : null;
        }

        /// <summary>
        /// Gets the MAC address of the current PC.
        /// </summary>
        /// <returns></returns>
        public static PhysicalAddress GetMacAddress()
        {
            foreach (NetworkInterface nic in NetworkInterface.GetAllNetworkInterfaces())
            {
                // Only consider Ethernet network interfaces
                if (nic.NetworkInterfaceType == NetworkInterfaceType.Ethernet &&
                    nic.OperationalStatus == OperationalStatus.Up)
                {
                    return nic.GetPhysicalAddress();
                }
            }
            return null;
        }

        /// <summary>
        /// Returns true if the specified IP address is a multicast address
        /// </summary>
        /// <param name="ip"></param>
        /// <returns></returns>
        public static bool IsMulticast(IPAddress ip)
        {
            bool result = true;
            if (!ip.IsIPv6Multicast)
            {
                byte highIP = ip.GetAddressBytes()[0];
                if (highIP < 224 || highIP > 239)
                {
                    result = false;
                }
            }
            return result;
        }
        //static void Main(string[] args)
        //{
        //    // Get my PC IP address
        //    Console.WriteLine("My IP : {0}", GetIPAddress());
        //    // Get My PC MAC address
        //    Console.WriteLine("My MAC: {0}", GetMacAddress());
        //    // Get all devices on network
        //    Dictionary<IPAddress, PhysicalAddress> all = GetAllDevicesOnLAN();
        //    foreach (KeyValuePair<IPAddress, PhysicalAddress> kvp in all)
        //    {
        //        Console.WriteLine("IP : {0}\n MAC {1}", kvp.Key, kvp.Value);
        //    }



        //    Console.ReadKey();

        //}



    }











}
