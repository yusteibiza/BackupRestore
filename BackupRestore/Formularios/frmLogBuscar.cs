using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace BackupRestore
{
    public partial class frmLogBuscar : Form
    {
        public delegate void DelegadoSalir(bool Saliendo);
        public event DelegadoSalir Saliendo;

        ToolStripMenuItem _tsmnuit;
        ListView _lsv;
        OrdenBusqueda ordenBuscar;

        public enum OrdenBusqueda
        {
            Atras, Adelante
        }

        public frmLogBuscar(ToolStripMenuItem tsMenuItem, ListView ListaEventos)
        {
            InitializeComponent();
            _tsmnuit = tsMenuItem;
            _tsmnuit.Enabled = false;
            _lsv = ListaEventos;
            _lsv.BackColor = Color.Tan;
            _lsv.Items[0].Focused = true;
            _lsv.FocusedItem.Selected = true;
            _lsv.FocusedItem.EnsureVisible();
            ordenBuscar = new OrdenBusqueda();
            ordenBuscar = OrdenBusqueda.Adelante;
        }

        private void frmLogBuscar_FormClosing(object sender, FormClosingEventArgs e)
        {
            _tsmnuit.Enabled = true;
            _lsv.BackColor = Color.Ivory;
            Saliendo(true);
        }

        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            if (txtBuscar.TextLength != 0)
            {
                if (_lsv.Items.Count != 0)
                {
                    if (_lsv.FocusedItem == null)
                        Buscar(0);
                    else
                        Buscar(_lsv.FocusedItem.Index);
                }
            }
            else
            {
                foreach (ListViewItem it in _lsv.SelectedItems)
                {
                    it.Selected = false;
                }

                _lsv.Items[0].Focused = true;
                _lsv.Items[_lsv.FocusedItem.Index].Selected = true;
                _lsv.EnsureVisible(0);
            }
        }

        private void Buscar(int Indice)
        {
            bool encontrado = false;

            try
            {
                if (_lsv.Items.Count != 0)
                {
                    foreach (ListViewItem it in _lsv.Items)
                    {
                        it.Selected = false;
                    }
                }

                if (ordenBuscar == OrdenBusqueda.Adelante)
                {
                    if (_lsv.FocusedItem.Index <= _lsv.Items.Count)
                    {
                        int indiceAhora = _lsv.FocusedItem.Index;

                        for (int x = Indice; x < _lsv.Items.Count; x++)
                        {
                            if (_lsv.Items[x].SubItems[2].Text.ToUpper().Contains(txtBuscar.Text.ToUpper()))
                            {
                                indiceAhora = _lsv.Items[x].Index;
                                encontrado = true;
                                break;
                            }
                        }
                        _lsv.Items[indiceAhora].Selected = true;
                        _lsv.Items[indiceAhora].Focused = true;
                        _lsv.EnsureVisible(_lsv.FocusedItem.Index);
                    }
                }
                else
                {
                    if (_lsv.FocusedItem.Index != 0)
                    {
                        int indiceAhora = _lsv.FocusedItem.Index;
                        if (_lsv.FocusedItem.Index != 0)
                        {
                            for (int x = Indice; x >= 0; x--)
                            {
                                if (_lsv.Items[x].SubItems[2].Text.ToUpper().Contains(txtBuscar.Text.ToUpper()))
                                {
                                    indiceAhora = _lsv.Items[x].Index;
                                    encontrado = true;
                                    break;
                                }
                            }
                        }
                        _lsv.Items[indiceAhora].Selected = true;
                        _lsv.Items[indiceAhora].Focused = true;
                        _lsv.EnsureVisible(_lsv.FocusedItem.Index);
                    }
                }

                if (encontrado == false)
                {
                    MessageBox.Show("No hay más coincidencias.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private void btnSiguiente_Click(object sender, EventArgs e)
        {
            if (_lsv.FocusedItem.Index <= _lsv.Items.Count)
            {
                ordenBuscar = OrdenBusqueda.Adelante;
                Buscar(_lsv.FocusedItem.Index + 1);
            }
        }

        private void btnAnterior_Click(object sender, EventArgs e)
        {
            if (_lsv.FocusedItem.Index != 0)
            {
                ordenBuscar = OrdenBusqueda.Atras;
                Buscar(_lsv.FocusedItem.Index - 1);
            }
        }

        private void frmLogBuscar_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.F3:
                    if (_lsv.FocusedItem.Index <= _lsv.Items.Count)
                    {
                        ordenBuscar = OrdenBusqueda.Adelante;
                        Buscar(_lsv.FocusedItem.Index + 1);
                    }
                    break;
                case Keys.F4:
                    if (_lsv.FocusedItem.Index != 0)
                    {
                        ordenBuscar = OrdenBusqueda.Atras;
                        Buscar(_lsv.FocusedItem.Index - 1);
                    }
                    break;
                case Keys.Escape:
                    this.Close();
                    break;
                default:
                    break;
            }
        }
    }
}

