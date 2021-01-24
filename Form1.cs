using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Consultor_de_CEPs__final_
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnLimpar_Click(object sender, EventArgs e)
        {
            // pegando os buttons e limpando eles 
            txtBairro.Text = string.Empty;
            txtCidade.Text = string.Empty;
            txtEstado.Text = string.Empty;
            txtRua.Text = string.Empty;
            txtConsultarCeps.Text = string.Empty;

        }

        private void btnSair_Click(object sender, EventArgs e)
        {
            //evento que fecha todo o formulario 
            this.Close(); // evento que fechar todo o formulario 
        }

        private void txtConsultarCeps_TextChanged(object sender, EventArgs e)
        {
            // primeiramente testando se o campo CEPs esta vazio ou não 
            if (!string.IsNullOrWhiteSpace(txtConsultarCeps.Text))
            {
                using (var ws = new ServiceReference1.AtendeClienteClient())// referenciando os serviçõs dos correios 
                {
                    try
                    {
                        var endereco = ws.consultaCEP(txtConsultarCeps.Text.Trim());

                        txtEstado.Text = endereco.uf;
                        txtCidade.Text = endereco.cidade;
                        txtBairro.Text = endereco.bairro;
                        txtRua.Text = endereco.end;
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            else
            {
                MessageBox.Show("Informe um CEP válido...", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
