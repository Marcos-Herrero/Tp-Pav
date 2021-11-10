using System;

using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Forms;
using Pav2021.Entities;
using Pav2021.BusinessLayer;
using Pav2021.GUILayer.Usuarios;

namespace Pav2021.GUILayer.Permisoes
{
    public partial class frmPermisos : Form
    {

        private FormularioService oFormularioService;
        private PerfilService oPerfilService;
        private PermisoService oPermisoService;


        public frmPermisos()
        {
            InitializeComponent();
            oPermisoService = new PermisoService();
            oPerfilService= new PerfilService();
            oFormularioService = new FormularioService();

        }

        private void frmUsuarios_Load(object sender, EventArgs e)
        {
            LlenarCombo(cboPerfil, oPerfilService.ObtenerTodos(), "IdPerfil", "id_Perfil");
            LlenarCombo(cboIdFormulario, oFormularioService.ObtenerTodos(), "IdFormulario", "id_Formulario");
            this.CenterToParent();
        }

        private void LlenarCombo(ComboBox cbo, Object source, string display, String value)
        {
            cbo.DataSource = source;
            cbo.DisplayMember = display;
            cbo.ValueMember = value;
            cbo.SelectedIndex = -1;
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            frmABMPermisos Permiso = new frmABMPermisos();
            Permiso.ShowDialog();
            btnConsultar_Click(sender, e);
        }

        private void chkTodos_CheckedChanged(object sender, EventArgs e)
        {
            {
                if (chkTodos.Checked)
                {
                    cboIdFormulario.Enabled = false;
                    cboPerfil.Enabled = false;
                }
                else
                {
                    cboIdFormulario.Enabled = true;
                    cboPerfil.Enabled = true;
                }
            }
        }

        private void btnSalir_Click(System.Object sender, System.EventArgs e)
        {
            this.Close();
        }
     
        private void btnConsultar_Click(System.Object sender, System.EventArgs e)
        {
            var filters = new Dictionary<string, object>();

            if (!chkTodos.Checked)
            {
                // Validar si el combo 'Permisos' esta seleccionado.
                if (cboPerfil.Text != string.Empty)
                {
                    // Si el cbo tiene un texto no vacìo entonces recuperamos el valor de la propiedad ValueMember
                    filters.Add("nombre", cboPerfil.SelectedValue);
                }

                // Validar si el textBox 'Nombre' esta vacio.
                if (cboIdFormulario.Text != string.Empty)
                {
                    // Si el textBox tiene un texto no vacìo entonces recuperamos el valor del texto
                    filters.Add("idPermiso", cboIdFormulario.SelectedValue);
                }

                if (filters.Count > 0)
                    DgvPermisos.DataSource = oPermisoService.ObtenerPermisoesFiltro(filters);
                else
                    MessageBox.Show("Debe ingresar al menos un criterio", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else            
                DgvPermisos.DataSource = oPermisoService.ObtenerTodos();
         
        }

        private void btnEditar_Click(System.Object sender, System.EventArgs e)
        {
            frmABMPermisos Permiso = new frmABMPermisos();

            // Asi obtenemos el item seleccionado de la grilla.
            var frm= (Permiso) DgvPermisos.CurrentRow.DataBoundItem;
            Permiso.InicializarPermiso(frmABMPermisos.FormMode.actualizar, frm);
            Permiso.ShowDialog();

            //Forzamos el evento Click para actualizar el DataGridView.
            btnConsultar_Click(sender, e);
        }

        private void dgvUsers_CellClick(object sender, System.Windows.Forms.DataGridViewCellEventArgs e)
        {
            btnEditar.Enabled = true;
            btnQuitar.Enabled = true;
        }

        private void btnQuitar_Click(System.Object sender, System.EventArgs e)
        {
            frmABMPermisos Permiso = new frmABMPermisos();

            // Asi obtenemos el item seleccionado de la grilla.
            var frm = (Permiso)DgvPermisos.CurrentRow.DataBoundItem;

            Permiso.InicializarPermiso(frmABMPermisos.FormMode.eliminar, frm);
            Permiso.ShowDialog();

            //Forzamos el evento Click para actualizar el DataGridView.
            btnConsultar_Click(sender, e);
        }

        private void btnLimpiar_Click_1(object sender, EventArgs e)
        {
            cboPerfil.SelectedIndex = -1;
            cboIdFormulario.SelectedIndex = -1;
        }
    }
}
