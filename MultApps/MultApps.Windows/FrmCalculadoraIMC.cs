using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MultApps.Windows
{
    public partial class FrmCalculadoraIMC : Form
    {
        public FrmCalculadoraIMC()
        {
            InitializeComponent();
        }

        private void chkCrianca_CheckedChanged(object sender, EventArgs e)
        {
            chkCrianca.ForeColor = Color.DarkOrange;
            chkAdulto.ForeColor = Color.Gray;
            chkAdulto.Checked = false;
            lblIdade.Text = "Abaixo de 19 anos";
            cmbIdade.Visible = true;
            lblIdadeCmb.Visible = true;

        }

        private void chkAdulto_CheckedChanged(object sender, EventArgs e)
        {
            chkAdulto.ForeColor = Color.DarkOrange;
            chkCrianca.ForeColor = Color.Gray;
            chkCrianca.Checked = false;
            lblIdade.Text = "Acima de 19 anos";
            cmbIdade.Visible = false;
            lblIdadeCmb.Visible = false;
        }

        private void btnCalcular_Click(object sender, EventArgs e)
        {

            if (chkAdulto.Checked && chkMasculino.Checked)
            {
                #region Adulto Masculino

                //PRIMEIRO PASSO OBTER OS VALORES
                var peso = double.Parse(txtPeso.Text);
                var altura = double.Parse(txtAltura.Text);

                //FAZ O PROCESSAMENTO
                var imc = peso / (altura * altura);
                var textoBase = $@"Meu IMC: {imc:N2} é";

                if (imc <= 18.5)
                {
                    lblResultadoImc.Text = $@"{textoBase} abaixo do normal";
                    picBoxImc.Load(ImcImagem.MaculinoAbaixoDoNormal);
                }
                else if (imc < 24.9)
                {
                    lblResultadoImc.Text = $@"{textoBase} normal";
                    picBoxImc.Load(ManipuladorDeImagem("normal"));
                }
                else if (imc < 29.9)
                {
                    lblResultadoImc.Text = $@"{textoBase} sobrepeso";
                    picBoxImc.Load(ManipuladorDeImagem("sobrepeso"));
                }
                else if (imc < 34.9)
                {
                    lblResultadoImc.Text = $@"{textoBase} obesidade grau 1";
                    picBoxImc.Load(ManipuladorDeImagem("obesidade grau 1"));
                }
                else if (imc < 39.9)
                {
                    lblResultadoImc.Text = $@"{textoBase} obesidade grau 2";
                    picBoxImc.Load(ManipuladorDeImagem("obesidade grau 2"));
                }
                else
                {
                    lblResultadoImc.Text = $@"{textoBase} obesidade grau 3";
                    picBoxImc.Load(ManipuladorDeImagem("obesidade grau 3"));
                }

                #endregion
            }


        }

        private string ManipuladorDeImagem(string grau)
        {
            switch (grau)
            {
               case "abaixo do normal":
                   return "";
               case "normal":
                    return "https://abeso.org.br/wp-content/uploads/2019/12/imc_05.png";
               case "sobrepeso":
                    return "https://abeso.org.br/wp-content/uploads/2019/12/imc_04.png";
                case "obesidade grau 1":
                    return "https://abeso.org.br/wp-content/uploads/2019/12/imc_03.png";
                case "obesidade grau 2":
                    return "https://abeso.org.br/wp-content/uploads/2019/12/imc_02.png";
                case "obesidade grau 3":
                    return "https://abeso.org.br/wp-content/uploads/2019/12/imc_01.png";

                default:
                    var empty = "";
                    break;
            }

        }
        }

    }
}
