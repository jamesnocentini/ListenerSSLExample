using Couchbase.Lite;
using Couchbase.Lite.Listener.Tcp;
using Couchbase.Lite.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ListenerSSLExample
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
           

            Manager manager = Manager.SharedInstance;
            var database = manager.GetDatabase("kis-database");

            var cert = X509Manager.GetPersistentCertificate("127.0.0.1", "123abc", System.IO.Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "unit_test.pfx"));
            Uri uri = new Uri(String.Format("http://localhost:{0}/{1}/", 3689, "kis-database"));
            CouchbaseLiteTcpOptions options = new CouchbaseLiteTcpOptions();

          
            CouchbaseLiteTcpListener listener = new CouchbaseLiteTcpListener(manager, 3689, CouchbaseLiteTcpOptions.UseTLS, cert);
            listener.SetPasswords(new Dictionary<string, string>() { { "user", "pass" } });
            


            listener.Start();

             Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }
    }
}
