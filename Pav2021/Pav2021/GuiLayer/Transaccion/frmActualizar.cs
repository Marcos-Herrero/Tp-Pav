using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using Pav2021.BusinessLayer;
using Pav2021.Entities;

namespace Pav2021
{
    public partial class frmActualizar : Form
    {

        private FormMode formMode = FormMode.nuevo;
        private readonly BindingList<Permiso> listaPermisos;
        private UsuarioService oUsuarioService;
        private PerfilService oPerfilService;
        private PermisoService oPermisoService;
        private FormularioService oFormularioService;
        private Perfil oPerfilSelected;

        public frmActualizar()
        {
            InitializeComponent();
            oUsuarioService = new UsuarioService();
            oPerfilService = new PerfilService();
            oFormularioService = new FormularioService();
            listaPermisos = new BindingList<Permiso>();
            oPermisoService = new PermisoService();
        }
        public enum FormMode
        {
            nuevo,
            actualizar,            
        }


        private void frmActualizar_Load(object sender, EventArgs e)
        {
            switch (formMode)           
            {
                case FormMode.nuevo:
                    {
                        this.Text = "Nuevo permiso";
                        LlenarCombo(_cboFormularios, oFormularioService.ObtenerTodos(), "Nombre", "id_Formulario");
                        dgvDetalle.DataSource = listaPermisos;
                        this.txtPerfil.TextChanged += new System.EventHandler(this.txtPerfil_TextChanged);
                        break;
                    }

                case FormMode.actualizar:
                    {
                        this.Text = "Actualizar permiso";
                        // Recuperar permiso seleccionado en la grilla 
                        LlenarCombo(_cboFormularios, oFormularioService.ObtenerTodos(), "Nombre", "id_Formulario");
                        dgvDetalle.DataSource = listaPermisos;
                        MostrarDatos();                        
                        txtPerfil.Enabled = true;
                        dpbDetalle.Enabled = true;
                        btnNuevo.Enabled = false;
                        break;
                    }
           
            }
                  

        }
        public void InicializarFormulario(FormMode op, Perfil perfilSelected)
        {
            formMode = op;
            oPerfilSelected = perfilSelected;
        }
        private void MostrarDatos()
        {
            if (oPerfilSelected != null)
            {
                txtPerfil.Text = oPerfilSelected.Nombre;
                List<Permiso> lst = new List<Permiso>();
                lst= (List<Permiso>)oPermisoService.GetPermisosByIdPerfil(oPerfilSelected.Id_Perfil);
                foreach(Permiso per in lst)
                {
                    listaPermisos.Add(per);
                }
                
            }
        }

        private void _btnAgregar_Click(object sender, EventArgs e)
        {

            var form = (Formulario)_cboFormularios.SelectedItem;
            Perfil per = new Perfil();
            per.Nombre = txtPerfil.Text;
            per.borrado = false;

            listaPermisos.Add(new Permiso()            
            {
                Formulario = form,
                Perfil = per
                            
        }) ;
            InicializarDetalle();

        }

        private void BtnGrabar_Click(object sender, EventArgs e)
        {
            try
            {
                var perfil = new Perfil
                {
                    Nombre = txtPerfil.Text,
                    DetallePermisos = listaPermisos                  
                };
                if (formMode.Equals(FormMode.nuevo))
                {
                    oPerfilService.CrearPerfil(perfil);

                    MessageBox.Show(string.Concat("El detalle nro: ", perfil.Id_Perfil, " se generó correctamente."), "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);


                    InicializarFormulario();
                }
                else
                {
                    

                    oPerfilService.ActualizarPerfil(perfil, oPerfilSelected.Id_Perfil);

                    MessageBox.Show(string.Concat("El detalle nro: ", perfil.Id_Perfil, " se actualizó correctamente."), "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);


                    InicializarFormulario();
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al registrar el perfil! " + ex.Message + ex.StackTrace, "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            this.Close();

        }
        private bool ValidarDatos()
        {
            return true;
        }

        private void BtnNuevo_Click(object sender, EventArgs e)
        {
            InicializarFormulario();
            txtPerfil.Enabled = true;
        }

        private void InicializarFormulario()
        {
                     
            InicializarDetalle();

            

        }
        private void InicializarDetalle()
        {
            _cboFormularios.SelectedIndex = -1;
            txtPerfil.Text = "";
            
        }
        private void _cboFormularios_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_cboFormularios.SelectedItem != null)
            {
                var form = (Formulario)_cboFormularios.SelectedItem;                
                _btnAgregar.Enabled = true;
            }
            else
            {
                _btnAgregar.Enabled = false;                
            }
        }
        private void _btnQuitar_Click(object sender, EventArgs e)
        {
            if (dgvDetalle.CurrentRow != null)
            {
                var permisoSeleccionado = (Permiso)dgvDetalle.CurrentRow.DataBoundItem;
                listaPermisos.Remove(permisoSeleccionado);
            }
        }     
      
        private void LlenarCombo(ComboBox cbo, Object source, string display, String value)
        {
            cbo.DataSource = source;
            cbo.DisplayMember = display;
            cbo.ValueMember = value;
            cbo.SelectedIndex = -1;
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
            
        }
        private void _btnCancelar_Click(object sender, EventArgs e)
        {
            InicializarDetalle();
        }

        private void txtPerfil_TextChanged(object sender, EventArgs e)
        {
            dpbDetalle.Enabled = true;
            _cboFormularios.Enabled = true;
        }

        private void _cboFormularios_Click(object sender, EventArgs e)
        {
            if (formMode.Equals(FormMode.nuevo)) { txtPerfil.Enabled = false; }
            else { txtPerfil.Enabled = true; }
            
        }
    }
}
