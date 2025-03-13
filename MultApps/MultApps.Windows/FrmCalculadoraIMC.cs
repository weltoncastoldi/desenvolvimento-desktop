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
                CalcularImcAdultoMasculino();
                return;
            }

            if (chkAdulto.Checked && chkFeminino.Checked)
            {
                CalcularImcAdultoFeminino();
                return;
            }

            if (chkCrianca.Checked)
            {
                CalcularImcCrianca();
                return;
            }
        }
        private void CalcularImcAdultoMasculino()
        {
            var peso = double.Parse(txtPeso.Text);
            var altura = double.Parse(txtAltura.Text);
            var imc = CalcularImc(peso, altura);
            ExibirResultadoImc(imc, GeneroEnum.Masculino, false);
        }

        private void CalcularImcAdultoFeminino()
        {
            var peso = double.Parse(txtPeso.Text);
            var altura = double.Parse(txtAltura.Text);
            var imc = CalcularImc(peso, altura);
            ExibirResultadoImc(imc, GeneroEnum.Feminino, false);
        }

        private void CalcularImcCrianca()
        {
            var peso = double.Parse(txtPeso.Text);
            var altura = double.Parse(txtAltura.Text);
            var imc = CalcularImc(peso, altura);

            var genero = chkMasculino.Checked ? GeneroEnum.Masculino : GeneroEnum.Feminino;

            ExibirResultadoImc(imc, genero, true);
        }


        private double CalcularImc(double peso, double altura)
        {
            return peso / (altura * altura);
        }

        private void ExibirResultadoImc(double imc, GeneroEnum genero, bool ehCrianca)
        {
            var textoBase = $@"Meu IMC: {imc:N2} é";
            string imageUrl = string.Empty;

            if (ehCrianca)
            {
                // Lógica específica para crianças
                if (imc <= 18.5)
                {
                    lblResultadoImc.Text = $@"{textoBase} abaixo do normal (criança)";
                    imageUrl = ImcImagem.CriancaAbaixoDoNormal;
                }
                else if (imc < 24.9)
                {
                    lblResultadoImc.Text = $@"{textoBase} normal (criança)";
                    imageUrl = ImcImagem.CriancaNormal;
                }
                else if (imc < 29.9)
                {
                    lblResultadoImc.Text = $@"{textoBase} sobrepeso (criança)";
                    imageUrl = ImcImagem.CriancaSobrepeso;
                }
                else if (imc < 34.9)
                {
                    lblResultadoImc.Text = $@"{textoBase} obesidade grau 1 (criança)";
                    imageUrl = ImcImagem.CriancaSobrepeso;
                }
                else if (imc < 39.9)
                {
                    lblResultadoImc.Text = $@"{textoBase} obesidade grau 2 (criança)";
                    imageUrl = ImcImagem.CriancaSobrepeso;
                }
                else
                {
                    lblResultadoImc.Text = $@"{textoBase} obesidade grau 3 (criança)";
                    imageUrl = ImcImagem.CriancaSobrepeso;
                }
            }
            else
            {
                // Lógica para adultos
                if (imc <= 18.5)
                {
                    lblResultadoImc.Text = $@"{textoBase} abaixo do normal";
                    imageUrl = genero == GeneroEnum.Masculino ? ImcImagem.MasculinoAbaixoDoNormal : ImcImagem.FemininoAbaixoDoNormal;
                }
                else if (imc < 24.9)
                {
                    lblResultadoImc.Text = $@"{textoBase} normal";
                    imageUrl = genero == GeneroEnum.Masculino ? ImcImagem.MasculinoNormal : ImcImagem.FemininoNormal;
                }
                else if (imc < 29.9)
                {
                    lblResultadoImc.Text = $@"{textoBase} sobrepeso";
                    imageUrl = genero == GeneroEnum.Masculino ? ImcImagem.MasculinoSobrepeso : ImcImagem.FemininoSobrepeso;
                }
                else if (imc < 34.9)
                {
                    lblResultadoImc.Text = $@"{textoBase} obesidade grau 1";
                    imageUrl = genero == GeneroEnum.Masculino ? ImcImagem.MasculinoObesidadeGrau1 : ImcImagem.FemininoObesidadeGrau1;
                }
                else if (imc < 39.9)
                {
                    lblResultadoImc.Text = $@"{textoBase} obesidade grau 2";
                    imageUrl = genero == GeneroEnum.Masculino ? ImcImagem.MasculinoObesidadeGrau2 : ImcImagem.FemininoObesidadeGrau2;
                }
                else
                {
                    lblResultadoImc.Text = $@"{textoBase} obesidade grau 3";
                    imageUrl = genero == GeneroEnum.Masculino ? ImcImagem.MasculinoObesidadeGrau3 : ImcImagem.FemininoObesidadeGrau3;
                }
            }

            if (!string.IsNullOrEmpty(imageUrl))
            {
                picBoxImc.Load(imageUrl);
            }
        }
    }
}
