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
    public partial class FrmCanal : Form
    {
        private bool esNuevo = false;
        public FrmCanal()
        {
            InitializeComponent();
        }
        private void listar()
        {
            dgvLeer.DataSource = CanalCln.Leerpa(txtParametro.Text);
            var lista = CanalCln.Leerpa(txtParametro.Text);
            dgvLeer.DataSource = lista;
            dgvLeer.Columns["id"].Visible = false;
            dgvLeer.Columns["estado"].Visible = false;
            dgvLeer.Columns["nombre"].HeaderText = "Nombre";
            dgvLeer.Columns["frecuencia"].HeaderText = "Frecuencia"; 
            dgvLeer.Columns["usuarioRegistro"].HeaderText = "Usuario Registro";
            dgvLeer.Columns["fechaRegistro"].HeaderText = "Fecha Registro";
            if (lista.Count > 0) dgvLeer.CurrentCell = dgvLeer.Rows[0].Cells["nombre"];
            btnEditar.Enabled = lista.Count > 0;
            btnEliminar.Enabled = lista.Count > 0;
        }
       

        private void FrmCanal_Load(object sender, EventArgs e)
        {
            Size = new Size(1059, 421);
            listar();
        }
        private void limpiar()
        {
            txtNombre.Clear();
            txtFrecuencia.Clear();
            resetearErrores();
        }
        private void resetearErrores()
        {
            erpNombre.Clear();
            erpFrecuencia.Clear();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            listar();
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            esNuevo = true;
            pnlAcciones.Enabled = false;
            limpiar();
            Size = new Size(1059, 605);
            txtNombre.Focus();
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            esNuevo = false;
            pnlAcciones.Enabled = false;
            limpiar();
            Size = new Size(1059, 605);
            resetearErrores();
            int id = (int)dgvLeer.CurrentRow.Cells["id"].Value;
            var canal = CanalCln.obtenerUno(id);
            txtNombre.Text = canal.nombre;
            txtFrecuencia.Text = canal.frecuencia;
            txtNombre.Focus();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            pnlAcciones.Enabled = true;
            Size = new Size(1059, 421);
        }

        private bool validar()
        {
            bool esValido = true;
            resetearErrores();

            if (string.IsNullOrWhiteSpace(txtNombre.Text))
            {
                erpNombre.SetError(txtNombre, "El Nombre es obligatorio");
                esValido = false;
            }
            if (string.IsNullOrWhiteSpace(txtFrecuencia.Text))
            {
                erpFrecuencia.SetError(txtFrecuencia, "La Frecuencia es obligatoria");
                esValido = false;
            }


            return esValido;
        }
        private void btnGuartar_Click(object sender, EventArgs e)
        {
            if (validar())
            {
                var canal = new Canal()
                {
                    nombre = txtNombre.Text.Trim(),
                    frecuencia = txtFrecuencia.Text.Trim(),
                    usuarioRegistro = "admin"
                };

                if (esNuevo)
                {
                    canal.fechaRegistro = DateTime.Now;
                    canal.estado = 1;
                    CanalCln.crear(canal);
                }
                else
                {
                    // Solo intentamos acceder si hay una fila seleccionada
                    if (dgvLeer.CurrentRow != null && dgvLeer.CurrentRow.Cells["id"].Value != null)
                    {
                        canal.id = (int)dgvLeer.CurrentRow.Cells["id"].Value;
                        CanalCln.modificar(canal);
                    }
                }

                listar();
                btnCancelar.PerformClick();
                MessageBox.Show("Canal guardado correctamente", "::: Mensaje - Parcial :::",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            int id = (int)dgvLeer.CurrentRow.Cells["id"].Value;
            string codigo = dgvLeer.CurrentRow.Cells["nombre"].Value.ToString();
            DialogResult dialog = MessageBox.Show($"Está seguro que desea eliminar el Canal {codigo}",
                "::: Mensaje - Canal :::", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dialog == DialogResult.Yes)
            {
                CanalCln.eliminar(id, "Admin");
                listar();
                MessageBox.Show("Canal dado de baja correctamente", "::: Mensaje - Parcial :::",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void txtParametro_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter) listar();
        }

        private void btnCerrar_Click_1(object sender, EventArgs e)
        {
            Close();
        }
    }
}
