using Autofac;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Unity;

namespace WindowsFormsApplication1
{
    public partial class Form1 : Form
    {

        private Autofac.IContainer _container;
        private UnityContainer _unityContainer = new Unity.UnityContainer();


        private void Form1_Load_1(object sender, EventArgs e) {
            var builder = new ContainerBuilder();
            builder.RegisterType<Cliente>().As<ICliente>().InstancePerDependency();
            _container = builder.Build();

            _unityContainer.RegisterType<ICliente, Cliente>();
        }



        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Cliente c = new Cliente();
            MessageBox.Show(c.GetNombreCliente());
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                ICliente c2 = _container.Resolve<ICliente>();
                MessageBox.Show(c2.GetNombreCliente());
            }
            catch (Exception e1) {
                Console.WriteLine("An error occurred: '{0}'", e1);
            }
    }

        private void button3_Click(object sender, EventArgs e)
        {
            ICliente c3 = _unityContainer.Resolve<ICliente>();
            MessageBox.Show(c3.GetNombreCliente());
        }
    }
}
