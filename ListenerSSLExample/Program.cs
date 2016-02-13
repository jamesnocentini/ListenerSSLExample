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
            //Application.EnableVisualStyles();
            //Application.SetCompatibleTextRenderingDefault(false);
            //Application.Run(new Form1());

            Manager manager = Manager.SharedInstance;
            var database = manager.GetDatabase("kis-database");

            var cert = X509Manager.GetExistingPersistentCertificate("127.0.0.1", "123abc", System.IO.Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "unit_test.pfx"));
            Uri uri = new Uri(String.Format("http://localhost:{0}/{1}/", 3689, "kis-database"));
            CouchbaseLiteTcpListener listener = new CouchbaseLiteTcpListener(manager, 3689, CouchbaseLiteTcpOptions.UseTLS, cert);

            listener.Start();
        }
    }
}
