using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SynchronousServer
{
    public partial class ServerManager : Form
    {
        public ServerManager()
        {
            InitializeComponent();
        }

        private void ServerManager_Load(object sender, EventArgs e)
        {
            CommonTool.ControlReflex.Reflex(new Model.ReflexModel()
            {
                ClassName = "ControlServer.KafkaClient",
                DomainName = "./ControlServer.dll",
                MethodName = "Test",
                Parameter = "ceshi"
            });
        }
    }
}
