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
            // TODO: esta línea de código carga datos en la tabla 'DsReportes.DataTable1' Puede moverla o quitarla según sea necesario.
            this.DataTable1TableAdapter.Fill(this.DsReportes.DataTable1);

            this.reportViewer1.RefreshReport();
        }
    }
}
