﻿using AppCore.IServices;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace practicaDepreciacion
{
    public partial class Form1 : Form
    {
        IActivoServices activoServices;
        private int Seleccionado = -1;
        public Form1(IActivoServices ActivoServices)
        {
            this.activoServices = ActivoServices;
            InitializeComponent();
        }



        private void Form1_Load(object sender, EventArgs e)
        {
            FillDgv();
        }

        private void guna2ImageButton1_Click(object sender, EventArgs e)
        {
            this.Close();

        }

        private void guna2ImageButton2_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void dgvActivos_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                Seleccionado = int.Parse(dgvActivos.Rows[e.RowIndex].Cells[0].Value.ToString());
            }
            else
            {
                cmsOption.Visible = false;
            }
        }

        private void actualizarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }

        private void btnEnviar_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(txtNombre.Text) || string.IsNullOrEmpty(txtValor.Text)||string.IsNullOrEmpty(txtValorR.Text)|| string.IsNullOrEmpty(txtAU.Text))
            {
                MessageBox.Show("Rellene todo el formulario, por favor.","Información",MessageBoxButtons.OK,MessageBoxIcon.Information);
                return;
            }
            else
            {
                Activo activo = new Activo
                {
                    Nombre=txtNombre.Text,
                    Valor=double.Parse(txtValor.Text),
                    ValorResidual=double.Parse(txtValorR.Text),
                    VidaUtil=int.Parse(txtAU.Text)
                };
                activoServices.Add(activo);
                FillDgv();
                clearTxt();
            }


        }
        private void clearTxt()
        {
            txtAU.Clear();
            txtNombre.Clear();
            txtValor.Clear();
            txtValorR.Clear();
        }
        private void FillDgv()
        {
            dgvActivos.Rows.Clear();

            foreach(Activo activo in activoServices.Read())
            {
                dgvActivos.Rows.Add(activo.Id,activo.Nombre,activo.Valor,activo.ValorResidual,activo.VidaUtil);
            }
        }

        private void txtValor_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsLetter(e.KeyChar))
            {
                e.Handled = true;

                MessageBox.Show("NO SE PUEDEN LETRAS");

            }
        }

        private void txtValorR_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsLetter(e.KeyChar))
            {
                e.Handled = true;

                MessageBox.Show("NO SE PUEDEN LETRAS");

            }
        }

        private void txtAU_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsLetter(e.KeyChar))
            {
                e.Handled = true;

                MessageBox.Show("NO SE PUEDEN LETRAS");

            }
        }

        private void txtNombre_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsNumber(e.KeyChar))
            {
                e.Handled = true;

                MessageBox.Show("NO SE PUEDEN NUMEROS");

            }
        }

        private void depreciacionesToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void borrarToolStripMenuItem_Click(object sender, EventArgs e)
        {
          
           
        }
    }
}
