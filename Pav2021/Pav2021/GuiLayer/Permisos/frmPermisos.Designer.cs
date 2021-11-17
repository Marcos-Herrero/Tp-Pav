namespace Pav2021.GUILayer.Permisoes
{
    partial class frmPermisos
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.btnQuitar = new System.Windows.Forms.Button();
            this.btnSalir = new System.Windows.Forms.Button();
            this.btnEditar = new System.Windows.Forms.Button();
            this.btnNuevo = new System.Windows.Forms.Button();
            this.chkTodos = new System.Windows.Forms.CheckBox();
            this.lblId = new System.Windows.Forms.Label();
            this.btnConsultar = new System.Windows.Forms.Button();
            this.cboPerfil = new System.Windows.Forms.ComboBox();
            this.lblIdPerfil = new System.Windows.Forms.Label();
            this.pnlFiltros = new System.Windows.Forms.GroupBox();
            this.DgvPermisos = new System.Windows.Forms.DataGridView();
            this.btnLimpiar = new System.Windows.Forms.Button();
            this.cboIdFormulario = new System.Windows.Forms.ComboBox();
            this.pnlFiltros.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DgvPermisos)).BeginInit();
            this.SuspendLayout();
            // 
            // btnQuitar
            // 
            this.btnQuitar.Enabled = false;
            this.btnQuitar.Image = global::Pav2021.Properties.Resources.eliminar;
            this.btnQuitar.Location = new System.Drawing.Point(104, 393);
            this.btnQuitar.Name = "btnQuitar";
            this.btnQuitar.Size = new System.Drawing.Size(40, 40);
            this.btnQuitar.TabIndex = 11;
            this.btnQuitar.UseVisualStyleBackColor = true;
            this.btnQuitar.Click += new System.EventHandler(this.btnQuitar_Click);
            // 
            // btnSalir
            // 
            this.btnSalir.Image = global::Pav2021.Properties.Resources.salir;
            this.btnSalir.Location = new System.Drawing.Point(385, 393);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(40, 40);
            this.btnSalir.TabIndex = 12;
            this.btnSalir.UseVisualStyleBackColor = true;
            this.btnSalir.Click += new System.EventHandler(this.btnSalir_Click);
            // 
            // btnEditar
            // 
            this.btnEditar.Enabled = false;
            this.btnEditar.Image = global::Pav2021.Properties.Resources.editar;
            this.btnEditar.Location = new System.Drawing.Point(58, 393);
            this.btnEditar.Name = "btnEditar";
            this.btnEditar.Size = new System.Drawing.Size(40, 40);
            this.btnEditar.TabIndex = 10;
            this.btnEditar.UseVisualStyleBackColor = true;
            this.btnEditar.Click += new System.EventHandler(this.btnEditar_Click);
            // 
            // btnNuevo
            // 
            this.btnNuevo.Image = global::Pav2021.Properties.Resources.agregar;
            this.btnNuevo.Location = new System.Drawing.Point(12, 393);
            this.btnNuevo.Name = "btnNuevo";
            this.btnNuevo.Size = new System.Drawing.Size(40, 40);
            this.btnNuevo.TabIndex = 9;
            this.btnNuevo.UseVisualStyleBackColor = true;
            this.btnNuevo.Click += new System.EventHandler(this.btnNuevo_Click);
            // 
            // chkTodos
            // 
            this.chkTodos.AutoSize = true;
            this.chkTodos.Location = new System.Drawing.Point(105, 77);
            this.chkTodos.Name = "chkTodos";
            this.chkTodos.Size = new System.Drawing.Size(56, 17);
            this.chkTodos.TabIndex = 2;
            this.chkTodos.Text = "Todos";
            this.chkTodos.UseVisualStyleBackColor = true;
            this.chkTodos.CheckedChanged += new System.EventHandler(this.chkTodos_CheckedChanged);
            // 
            // lblId
            // 
            this.lblId.AutoSize = true;
            this.lblId.Location = new System.Drawing.Point(23, 25);
            this.lblId.Name = "lblId";
            this.lblId.Size = new System.Drawing.Size(70, 13);
            this.lblId.TabIndex = 17;
            this.lblId.Text = "Id Formulario:";
            // 
            // btnConsultar
            // 
            this.btnConsultar.BackgroundImage = global::Pav2021.Properties.Resources.BUSCAR01;
            this.btnConsultar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnConsultar.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btnConsultar.Location = new System.Drawing.Point(332, 58);
            this.btnConsultar.Name = "btnConsultar";
            this.btnConsultar.Size = new System.Drawing.Size(50, 29);
            this.btnConsultar.TabIndex = 3;
            this.btnConsultar.UseVisualStyleBackColor = true;
            this.btnConsultar.Click += new System.EventHandler(this.btnConsultar_Click);
            // 
            // cboPerfil
            // 
            this.cboPerfil.FormattingEnabled = true;
            this.cboPerfil.Location = new System.Drawing.Point(105, 45);
            this.cboPerfil.Name = "cboPerfil";
            this.cboPerfil.Size = new System.Drawing.Size(181, 21);
            this.cboPerfil.TabIndex = 1;
            // 
            // lblIdPerfil
            // 
            this.lblIdPerfil.AutoSize = true;
            this.lblIdPerfil.Location = new System.Drawing.Point(52, 51);
            this.lblIdPerfil.Name = "lblIdPerfil";
            this.lblIdPerfil.Size = new System.Drawing.Size(45, 13);
            this.lblIdPerfil.TabIndex = 0;
            this.lblIdPerfil.Text = "Id Perfil:";
            // 
            // pnlFiltros
            // 
            this.pnlFiltros.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.pnlFiltros.BackColor = System.Drawing.Color.Transparent;
            this.pnlFiltros.Controls.Add(this.DgvPermisos);
            this.pnlFiltros.Controls.Add(this.btnLimpiar);
            this.pnlFiltros.Controls.Add(this.cboIdFormulario);
            this.pnlFiltros.Controls.Add(this.chkTodos);
            this.pnlFiltros.Controls.Add(this.lblId);
            this.pnlFiltros.Controls.Add(this.btnConsultar);
            this.pnlFiltros.Controls.Add(this.cboPerfil);
            this.pnlFiltros.Controls.Add(this.lblIdPerfil);
            this.pnlFiltros.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.pnlFiltros.Location = new System.Drawing.Point(12, 12);
            this.pnlFiltros.Name = "pnlFiltros";
            this.pnlFiltros.Size = new System.Drawing.Size(413, 375);
            this.pnlFiltros.TabIndex = 8;
            this.pnlFiltros.TabStop = false;
            this.pnlFiltros.Text = "Filtros";
            // 
            // DgvPermisos
            // 
            this.DgvPermisos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DgvPermisos.Location = new System.Drawing.Point(17, 123);
            this.DgvPermisos.Name = "DgvPermisos";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.ButtonFace;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.InfoText;
            dataGridViewCellStyle3.Selectio
                ckColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.Desktop;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.DgvPermisos.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle4.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.White;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.Color.Black;
            this.DgvPermisos.RowsDefaultCellStyle = dataGridViewCellStyle4;
            this.DgvPermisos.Size = new System.Drawing.Size(390, 246);
            this.DgvPermisos.TabIndex = 0;
            // 
            // btnLimpiar
            // 
            this.btnLimpiar.BackgroundImage = global::Pav2021.Properties.Resources.Empty_Recycle_Bin_2000;
            this.btnLimpiar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnLimpiar.Location = new System.Drawing.Point(332, 23);
            this.btnLimpiar.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.btnLimpiar.Name = "btnLimpiar";
            this.btnLimpiar.Size = new System.Drawing.Size(50, 29);
            this.btnLimpiar.TabIndex = 19;
            this.btnLimpiar.UseVisualStyleBackColor = true;
            this.btnLimpiar.Click += new System.EventHandler(this.btnLimpiar_Click_1);
            // 
            // cboIdFormulario
            // 
            this.cboIdFormulario.FormattingEnabled = true;
            this.cboIdFormulario.Location = new System.Drawing.Point(105, 23);
            this.cboIdFormulario.Name = "cboIdFormulario";
            this.cboIdFormulario.Size = new System.Drawing.Size(181, 21);
            this.cboIdFormulario.TabIndex = 18;
            // 
            // frmPermisos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::Pav2021.Properties.Resources.prueba;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(441, 445);
            this.Controls.Add(this.btnQuitar);
            this.Controls.Add(this.btnSalir);
            this.Controls.Add(this.btnEditar);
            this.Controls.Add(this.btnNuevo);
            this.Controls.Add(this.pnlFiltros);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmPermisos";
            this.Text = "Permisos";
            this.Load += new System.EventHandler(this.frmUsuarios_Load);
            this.pnlFiltros.ResumeLayout(false);
            this.pnlFiltros.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DgvPermisos)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        internal System.Windows.Forms.Button btnQuitar;
        internal System.Windows.Forms.Button btnSalir;
        internal System.Windows.Forms.Button btnEditar;
        internal System.Windows.Forms.Button btnNuevo;
        internal System.Windows.Forms.CheckBox chkTodos;
        internal System.Windows.Forms.Label lblId;
        internal System.Windows.Forms.Button btnConsultar;
        internal System.Windows.Forms.ComboBox cboPerfil;
        internal System.Windows.Forms.Label lblIdPerfil;
        internal System.Windows.Forms.GroupBox pnlFiltros;
        internal System.Windows.Forms.ComboBox cboIdFormulario;
        private System.Windows.Forms.Button btnLimpiar;
        private System.Windows.Forms.DataGridView DgvPermisos;
    }
}