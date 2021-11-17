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
    public partial class femRepHis : Form
    {
        public femRepHis()
        {
            InitializeComponent();
        }

        private void femRepHis_Load(object sender, EventArgs e)
        {
            // TODO: esta línea de código carga datos en la tabla 'dsReportes.DataTable2' Puede moverla o quitarla según sea necesario.
            this.dataTable2TableAdapter.Fill(this.dsReportes.DataTable2);
            this.reportViewer1.RefreshReport();
        }
    }
}
