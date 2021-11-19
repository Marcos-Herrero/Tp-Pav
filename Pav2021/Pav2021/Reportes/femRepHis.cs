using Microsoft.Reporting.WinForms;
using Pav2021.BusinessLayer;
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
        private PerfilService oPerfilService;
        private UsuarioService oUsuarioService;
        public femRepHis()
        {
            InitializeComponent();
            oPerfilService = new PerfilService();
            oUsuarioService = new UsuarioService();
        
        }

        private void femRepHis_Load(object sender, EventArgs e)
        {
            // TODO: esta línea de código carga datos en la tabla 'DsReportes.DataTable1' Puede moverla o quitarla según sea necesario.
            this.DataTable1TableAdapter.Fill(this.DsReportes.DataTable1);          
     
            LlenarCombo(cboPerfiles, oPerfilService.ObtenerTodos(), "Nombre", "id_perfil");
            LlenarCombo(cboUsuarios, oUsuarioService.getUsuariosList(), "UsuarioNombre", "id_usuario");
            this.reportViewer1.RefreshReport();
        }
        private void LlenarCombo(ComboBox cbo, Object source, string display, String value)
        {
            cbo.DataSource = source;
            cbo.DisplayMember = display;
            cbo.ValueMember = value;
            cbo.SelectedIndex = -1;
        }

        private void btnGenerar_Click(object sender, EventArgs e)
        {
            string strSql = "SELECT u.usuario , p.nombre , h.fecha_historico  " +
                           "FROM Usuarios u , HistoricoDeAsignaciones h, Perfiles p " +
                           "WHERE h.id_perfil = p.id_perfil " +
                           "AND u.id_usuario = h.id_usuario " +
                           "AND h.fecha_historico between @fechaDesde AND @fechaHasta ";


            // Dictionary: Representa una colección de claves y valores.
            Dictionary<string, object> parametros = new Dictionary<string, object>();

            DateTime fechaDesde;
            DateTime fechaHasta;
            if (DateTime.TryParse(txtFechaDesde.Text, out fechaDesde) &&
                DateTime.TryParse(txtFechaHasta.Text, out fechaHasta))
            {
                parametros.Add("fechaDesde", fechaDesde);
                parametros.Add("fechaHasta", fechaHasta);

                reportViewer1.LocalReport.SetParameters(new ReportParameter[] {
                    new ReportParameter("prFechaDesde", fechaDesde.ToString("dd/MM/yyyy")),
                    new ReportParameter("prFechaHasta", fechaHasta.ToString("dd/MM/yyyy"))
                });
                if (cboPerfiles.Text != "")
                {
                    strSql += " AND p.id_perfil= @id_perfil ";
                    parametros.Add("id_perfil", Convert.ToInt32(cboPerfiles.SelectedValue.ToString()));
                }
                if (cboUsuarios.Text != "")
                {
                    strSql += " AND u.id_usuario= @id_usuario ";
                    parametros.Add("id_usuario", Convert.ToInt32(cboUsuarios.SelectedValue.ToString()));
                }

                //DATASOURCE
                reportViewer1.LocalReport.DataSources.Clear();
                reportViewer1.LocalReport.DataSources.Add(new ReportDataSource("DataHistorico", DataManager.GetInstance().ConsultaSql(strSql, parametros)));
                reportViewer1.RefreshReport();
                
               
            }
            
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked) {
                cboUsuarios.Enabled = false;
                cboUsuarios.Text = "";
            }
            else
            {
                cboUsuarios.Enabled = true;
            }
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox2.Checked== true)
            {
                cboPerfiles.Enabled = false;
                cboPerfiles.Text = "";
            }
            else
            {
                cboPerfiles.Enabled = true;
            }

        }
    }
}
