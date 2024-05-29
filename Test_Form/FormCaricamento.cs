using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Test_Form
{
    public partial class Caricamento : Form
    {
        public Caricamento()
        {
            InitializeComponent();
        }

        public Control Get_loadingBar()
        {
            return progBMainPanel;
        }

        private void Caricamento_Load(object sender, EventArgs e)
        {

        }
    }
}
