using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Pav2021.Reportes
{
    public partial class frmRepUsu : Form
    {
        public frmRepUsu()
        {
            InitializeComponent();
        }

        private void frmRepUsu_Load(object sender, EventArgs e)
        {
            this.reportViewer1.RefreshReport();
        }
    }
}
