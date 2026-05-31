using CadParcial2iss;
using ClnParcial2iss;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CpParcial2iss
{
    public partial class FrmPrograma : Form
    {
        private bool esNuevo = false;
        public FrmPrograma()
        {
            InitializeComponent();
        }
        private void listar()
        {
            dgvLeer.DataSource = ProgramaCln.Leerpa(txtParametro.Text);
            var lista = ProgramaCln.Leerpa(txtParametro.Text);
            dgvLeer.DataSource = lista;
            dgvLeer.Columns["id"].Visible = false;
            dgvLeer.Columns["estado"].Visible = false;
            dgvLeer.Columns["idCanal"].Visible = false;
            dgvLeer.Columns["nombreCanal"].HeaderText = "Canal";
            dgvLeer.Columns["titulo"].HeaderText = "Titulo";
            dgvLeer.Columns["descripcion"].HeaderText = "Descripcion";
            dgvLeer.Columns["nombreProgramaControl"].HeaderText = "Programa Control";
            dgvLeer.Columns["duracion"].HeaderText = "Duracion";
            dgvLeer.Columns["productor"].HeaderText = "Productor";
            dgvLeer.Columns["fechaEstreno"].HeaderText = "Fecha de estreno";
            dgvLeer.Columns["idProgramaControl"].Visible = false;
            if (lista.Count > 0) dgvLeer.CurrentCell = dgvLeer.Rows[0].Cells["titulo"];
            btnEditar.Enabled = lista.Count > 0;
            btnEliminar.Enabled = lista.Count > 0;
        }
        private void cargar()
        {
            cbxIDCanal.DataSource = CanalCln.listar();
            cbxIDCanal.ValueMember = "id";
            cbxIDCanal.DisplayMember = "nombre";
            cbxIDCanal.SelectedIndex = -1;
        }
        private void cargarb()
        {
            cbxProgramaControl.DataSource = ProgramaControlCln.listar();
            cbxProgramaControl.ValueMember = "id";
            cbxProgramaControl.DisplayMember = "nombre";
            cbxProgramaControl.SelectedIndex = -1;
        }

        private void FrmPrograma_Load(object sender, EventArgs e)
        {
             Size = new Size(1084,390);
            listar();
            cargar();
            cargarb();
        }
        private void limpiar()
        {
            cbxIDCanal.SelectedIndex = -1;
            txtTitulo.Clear();
            txtDescripcion.Clear();
            nudDuracion.Value = 0;
            txtProductor.Clear();
            fFecha.Value = DateTime.Now;
            resetearErrores();
        }
        private void resetearErrores()
        {
            erpidCanal.Clear();
            erpTitulo.Clear();
            erpProductor.Clear();

        }

        private void txtParametro_TextChanged(object sender, EventArgs e)
        {
            listar();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            listar();
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            Size = new Size(1084, 604);
            esNuevo = true;
            pnlAcciones.Enabled = false;
            limpiar();
            Size = new Size(1059, 605);
            txtTitulo.Focus();
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            Size = new Size(1084, 604);
            esNuevo = false;
            pnlAcciones.Enabled = false;
            txtTitulo.Focus();
            limpiar();
            

            resetearErrores();
            int id = (int)dgvLeer.CurrentRow.Cells["id"].Value;
            var programa = ProgramaCln.obtenerUno(id);
            cbxIDCanal.SelectedValue = programa.idCanal;
            txtTitulo.Text = programa.titulo;
            txtDescripcion.Text = programa.descripcion;
            nudDuracion.Value = programa.duracion;
            txtProductor.Text = programa.productor;
            fFecha.Value = programa.fechaEstreno;
            cbxProgramaControl.SelectedValue = programa.idProgramaControl;
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            Size = new Size(1084, 390);

            int id = (int)dgvLeer.CurrentRow.Cells["id"].Value;
            string titulo = dgvLeer.CurrentRow.Cells["titulo"].Value.ToString();
            DialogResult dialog = MessageBox.Show($"Está seguro que desea eliminar el Programa {titulo}",
                "::: Mensaje - Programa :::", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dialog == DialogResult.Yes)
            {
                ProgramaCln.eliminar(id, "Admin");
                listar();
                MessageBox.Show("Programa dado de baja correctamente", "::: Mensaje - Parcial :::",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private bool validar()
        {
            bool esValido = true;
            resetearErrores();

            if (string.IsNullOrWhiteSpace(txtTitulo.Text))
            {
                erpTitulo.SetError(txtTitulo, "El Título es obligatorio");
                esValido = false;
            }
            if (cbxIDCanal.SelectedIndex == -1)
            {
                erpidCanal.SetError(cbxIDCanal, "La Id canal es obligatoria");
                esValido = false;
            }
            if (string.IsNullOrWhiteSpace(txtProductor.Text))
            {
                erpProductor.SetError(txtProductor, "El Productor es obligatorio");
                esValido = false;
            }
            return esValido;
        }
        private void btnGuartar_Click(object sender, EventArgs e)
        {
            if (validar())
            {
                var programa = new Programa()
                {
                    idCanal = (int)cbxIDCanal.SelectedValue,
                    titulo = txtTitulo.Text.Trim(),
                    descripcion = txtDescripcion.Text.Trim(),
                    duracion = (int)nudDuracion.Value,
                    productor = txtProductor.Text.Trim(),
                    fechaEstreno = fFecha.Value.Date,
                    idProgramaControl = (int)cbxProgramaControl.SelectedValue,
                    usuarioRegistro = "Admin"
                };

                if (esNuevo)
                {
                    programa.fechaRegistro = DateTime.Now;
                    programa.estado = 1;
                    ProgramaCln.crear(programa);
                }
                else
                {
                    programa.id = (int)dgvLeer.CurrentRow.Cells["id"].Value;
                    ProgramaCln.modificar(programa);
                }

                listar();
                btnCancelar.PerformClick();

                MessageBox.Show(
                    "Programa guardado correctamente",
                    "::: Mensaje - Programa :::",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Size = new Size(1084, 390);
            pnlAcciones.Enabled = true;
        }
    }
}