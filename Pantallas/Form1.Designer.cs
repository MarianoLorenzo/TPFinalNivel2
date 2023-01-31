
namespace Pantallas
{
    partial class FrmCatalogo
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.dgvArticulos = new System.Windows.Forms.DataGridView();
            this.pbImagenArticulo = new System.Windows.Forms.PictureBox();
            this.btnAgregar = new System.Windows.Forms.Button();
            this.btnModificar = new System.Windows.Forms.Button();
            this.btnEliminar = new System.Windows.Forms.Button();
            this.lblFiltroRapido = new System.Windows.Forms.Label();
            this.txtbFiltroRapido = new System.Windows.Forms.TextBox();
            this.lblFiltroCampo = new System.Windows.Forms.Label();
            this.lblFiltroCriterio = new System.Windows.Forms.Label();
            this.lblFiltrar = new System.Windows.Forms.Label();
            this.cbFiltroCampo = new System.Windows.Forms.ComboBox();
            this.cbFiltroCriterio = new System.Windows.Forms.ComboBox();
            this.txtbFiltroAvanzado = new System.Windows.Forms.TextBox();
            this.btnFiltroAvanzado = new System.Windows.Forms.Button();
            this.lblCampoRequerido = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvArticulos)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbImagenArticulo)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvArticulos
            // 
            this.dgvArticulos.AllowUserToOrderColumns = true;
            this.dgvArticulos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvArticulos.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dgvArticulos.Location = new System.Drawing.Point(12, 41);
            this.dgvArticulos.MultiSelect = false;
            this.dgvArticulos.Name = "dgvArticulos";
            this.dgvArticulos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvArticulos.Size = new System.Drawing.Size(556, 201);
            this.dgvArticulos.TabIndex = 0;
            this.dgvArticulos.SelectionChanged += new System.EventHandler(this.dgvArticulos_SelectionChanged);
            // 
            // pbImagenArticulo
            // 
            this.pbImagenArticulo.Location = new System.Drawing.Point(586, 41);
            this.pbImagenArticulo.Name = "pbImagenArticulo";
            this.pbImagenArticulo.Size = new System.Drawing.Size(204, 201);
            this.pbImagenArticulo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbImagenArticulo.TabIndex = 1;
            this.pbImagenArticulo.TabStop = false;
            // 
            // btnAgregar
            // 
            this.btnAgregar.Location = new System.Drawing.Point(16, 346);
            this.btnAgregar.Name = "btnAgregar";
            this.btnAgregar.Size = new System.Drawing.Size(75, 23);
            this.btnAgregar.TabIndex = 2;
            this.btnAgregar.Text = "Agregar";
            this.btnAgregar.UseVisualStyleBackColor = true;
            this.btnAgregar.Click += new System.EventHandler(this.btnAgregar_Click);
            // 
            // btnModificar
            // 
            this.btnModificar.Location = new System.Drawing.Point(254, 346);
            this.btnModificar.Name = "btnModificar";
            this.btnModificar.Size = new System.Drawing.Size(75, 23);
            this.btnModificar.TabIndex = 3;
            this.btnModificar.Text = "Modificar";
            this.btnModificar.UseVisualStyleBackColor = true;
            this.btnModificar.Click += new System.EventHandler(this.btnModificar_Click);
            // 
            // btnEliminar
            // 
            this.btnEliminar.Location = new System.Drawing.Point(492, 346);
            this.btnEliminar.Name = "btnEliminar";
            this.btnEliminar.Size = new System.Drawing.Size(75, 23);
            this.btnEliminar.TabIndex = 4;
            this.btnEliminar.Text = "Eliminar";
            this.btnEliminar.UseVisualStyleBackColor = true;
            this.btnEliminar.Click += new System.EventHandler(this.btnEliminar_Click);
            // 
            // lblFiltroRapido
            // 
            this.lblFiltroRapido.AutoSize = true;
            this.lblFiltroRapido.Location = new System.Drawing.Point(13, 13);
            this.lblFiltroRapido.Name = "lblFiltroRapido";
            this.lblFiltroRapido.Size = new System.Drawing.Size(63, 13);
            this.lblFiltroRapido.TabIndex = 5;
            this.lblFiltroRapido.Text = "Filitro rápido";
            // 
            // txtbFiltroRapido
            // 
            this.txtbFiltroRapido.Location = new System.Drawing.Point(103, 10);
            this.txtbFiltroRapido.Name = "txtbFiltroRapido";
            this.txtbFiltroRapido.Size = new System.Drawing.Size(100, 20);
            this.txtbFiltroRapido.TabIndex = 6;
            this.txtbFiltroRapido.TextChanged += new System.EventHandler(this.txtbFiltroRapido_TextChanged);
            // 
            // lblFiltroCampo
            // 
            this.lblFiltroCampo.AutoSize = true;
            this.lblFiltroCampo.Location = new System.Drawing.Point(13, 262);
            this.lblFiltroCampo.Name = "lblFiltroCampo";
            this.lblFiltroCampo.Size = new System.Drawing.Size(89, 13);
            this.lblFiltroCampo.TabIndex = 7;
            this.lblFiltroCampo.Text = "Filtrar por campo*";
            // 
            // lblFiltroCriterio
            // 
            this.lblFiltroCriterio.AutoSize = true;
            this.lblFiltroCriterio.Location = new System.Drawing.Point(222, 262);
            this.lblFiltroCriterio.Name = "lblFiltroCriterio";
            this.lblFiltroCriterio.Size = new System.Drawing.Size(88, 13);
            this.lblFiltroCriterio.TabIndex = 8;
            this.lblFiltroCriterio.Text = "Filtrar por criterio*";
            // 
            // lblFiltrar
            // 
            this.lblFiltrar.AutoSize = true;
            this.lblFiltrar.Location = new System.Drawing.Point(427, 262);
            this.lblFiltrar.Name = "lblFiltrar";
            this.lblFiltrar.Size = new System.Drawing.Size(36, 13);
            this.lblFiltrar.TabIndex = 9;
            this.lblFiltrar.Text = "Filtrar*";
            // 
            // cbFiltroCampo
            // 
            this.cbFiltroCampo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbFiltroCampo.FormattingEnabled = true;
            this.cbFiltroCampo.Location = new System.Drawing.Point(109, 259);
            this.cbFiltroCampo.Name = "cbFiltroCampo";
            this.cbFiltroCampo.Size = new System.Drawing.Size(102, 21);
            this.cbFiltroCampo.TabIndex = 10;
            this.cbFiltroCampo.SelectedIndexChanged += new System.EventHandler(this.cbFiltroCampo_SelectedIndexChanged);
            // 
            // cbFiltroCriterio
            // 
            this.cbFiltroCriterio.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbFiltroCriterio.FormattingEnabled = true;
            this.cbFiltroCriterio.Location = new System.Drawing.Point(317, 259);
            this.cbFiltroCriterio.Name = "cbFiltroCriterio";
            this.cbFiltroCriterio.Size = new System.Drawing.Size(99, 21);
            this.cbFiltroCriterio.TabIndex = 11;
            // 
            // txtbFiltroAvanzado
            // 
            this.txtbFiltroAvanzado.Location = new System.Drawing.Point(470, 259);
            this.txtbFiltroAvanzado.Name = "txtbFiltroAvanzado";
            this.txtbFiltroAvanzado.Size = new System.Drawing.Size(100, 20);
            this.txtbFiltroAvanzado.TabIndex = 12;
            // 
            // btnFiltroAvanzado
            // 
            this.btnFiltroAvanzado.Location = new System.Drawing.Point(581, 257);
            this.btnFiltroAvanzado.Name = "btnFiltroAvanzado";
            this.btnFiltroAvanzado.Size = new System.Drawing.Size(75, 23);
            this.btnFiltroAvanzado.TabIndex = 13;
            this.btnFiltroAvanzado.Text = "Buscar";
            this.btnFiltroAvanzado.UseVisualStyleBackColor = true;
            this.btnFiltroAvanzado.Click += new System.EventHandler(this.btnFiltroAvanzado_Click);
            // 
            // lblCampoRequerido
            // 
            this.lblCampoRequerido.AutoSize = true;
            this.lblCampoRequerido.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCampoRequerido.Location = new System.Drawing.Point(13, 295);
            this.lblCampoRequerido.Name = "lblCampoRequerido";
            this.lblCampoRequerido.Size = new System.Drawing.Size(107, 13);
            this.lblCampoRequerido.TabIndex = 14;
            this.lblCampoRequerido.Text = "*Campo requerido";
            // 
            // FrmCatalogo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(802, 432);
            this.Controls.Add(this.lblCampoRequerido);
            this.Controls.Add(this.btnFiltroAvanzado);
            this.Controls.Add(this.txtbFiltroAvanzado);
            this.Controls.Add(this.cbFiltroCriterio);
            this.Controls.Add(this.cbFiltroCampo);
            this.Controls.Add(this.lblFiltrar);
            this.Controls.Add(this.lblFiltroCriterio);
            this.Controls.Add(this.lblFiltroCampo);
            this.Controls.Add(this.txtbFiltroRapido);
            this.Controls.Add(this.lblFiltroRapido);
            this.Controls.Add(this.btnEliminar);
            this.Controls.Add(this.btnModificar);
            this.Controls.Add(this.btnAgregar);
            this.Controls.Add(this.pbImagenArticulo);
            this.Controls.Add(this.dgvArticulos);
            this.Name = "FrmCatalogo";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Catálogo";
            this.Load += new System.EventHandler(this.FrmCatalogo_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvArticulos)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbImagenArticulo)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvArticulos;
        private System.Windows.Forms.PictureBox pbImagenArticulo;
        private System.Windows.Forms.Button btnAgregar;
        private System.Windows.Forms.Button btnModificar;
        private System.Windows.Forms.Button btnEliminar;
        private System.Windows.Forms.Label lblFiltroRapido;
        private System.Windows.Forms.TextBox txtbFiltroRapido;
        private System.Windows.Forms.Label lblFiltroCampo;
        private System.Windows.Forms.Label lblFiltroCriterio;
        private System.Windows.Forms.Label lblFiltrar;
        private System.Windows.Forms.ComboBox cbFiltroCampo;
        private System.Windows.Forms.ComboBox cbFiltroCriterio;
        private System.Windows.Forms.TextBox txtbFiltroAvanzado;
        private System.Windows.Forms.Button btnFiltroAvanzado;
        private System.Windows.Forms.Label lblCampoRequerido;
    }
}

