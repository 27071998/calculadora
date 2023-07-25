using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics.Eventing.Reader;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Text;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace calculadora
{
    public partial class calculadora : Form
    {


        private Operacao OperacaoSelecionada;
        enum Operacao
        {
            adicao,
            subtracao,
            multiplicacao,
            divisao,

        }
        float coleta = 0;
        float coleta2 = 0;
        float coletaTotal = 0;
        Single coleta3 = 0;
        string coletaresultado = "";
        Single Total = 0;   



        public calculadora()
        {
            InitializeComponent();
            lblMostraOperacao.Text = "";

        }

        private void calculadora_Load(object sender, EventArgs e)
        {

        }

        // botão numero 0
        private void btnNumero0_Click(object sender, EventArgs e)


        {
            txtResultado.Text += "0";
            lblMostraOperacao.Text += "0";
        }
        // botão numero 1

        private void btnNumero1_Click(object sender, EventArgs e)
        {
            limpanumero();


            lblMostraOperacao.Text += "1";
            txtResultado.Text += "1";


        }
        // botão numero 2
        private void btnNumero2_Click(object sender, EventArgs e)
        {
            limpanumero();
            txtResultado.Text += "2";
            lblMostraOperacao.Text += "2";
        }

        // botão numero 3
        private void btnNumero3_Click(object sender, EventArgs e)
        {
            limpanumero();
            txtResultado.Text += "3";
            lblMostraOperacao.Text += "3";
        }

        // botão numero 4
        private void btnNumero4_Click(object sender, EventArgs e)
        {
            limpanumero();
            txtResultado.Text += "4";
            lblMostraOperacao.Text += "4";
        }
        // botão numero 5
        private void btnNumero5_Click(object sender, EventArgs e)
        {
            limpanumero();
            txtResultado.Text += "5";
            lblMostraOperacao.Text += "5";
        }
        // botão numero 6
        private void btnNumero6_Click(object sender, EventArgs e)
        {
            limpanumero();
            txtResultado.Text += "6";
            lblMostraOperacao.Text += "6";
        }
        // botão numero 7
        private void btnNumero7_Click(object sender, EventArgs e)
        {
            limpanumero();
            txtResultado.Text += "7";
            lblMostraOperacao.Text += "7";
        }
        // botão numero 8
        private void btnNumero8_Click(object sender, EventArgs e)
        {
            limpanumero();
            txtResultado.Text += "8";
            lblMostraOperacao.Text += "8";

        }
        // botão numero 9
        private void btnNumero9_Click(object sender, EventArgs e)
        {
            limpanumero();
            txtResultado.Text += "9";
            lblMostraOperacao.Text += "9";

        }
        // botão VIRGULA
        private void btnVirgula_Click(object sender, EventArgs e)
        {
            try
            {
                txtResultado.Text += ",";
                lblMostraOperacao.Text += ",";

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Informação", MessageBoxButtons.AbortRetryIgnore);
            }
        }

        // botão ADIÇÃO
        private void btnAdicao_Click(object sender, EventArgs e)
        {
            try
            {
                txtResultado.BackColor = Color.White;
                txtResultado.ForeColor = Color.Black;
                string valor = txtResultado.Text;

                Continuacao();
                somar();


                OperacaoSelecionada = Operacao.adicao;
                coleta = Convert.ToSingle(txtResultado.Text);
                txtResultado.Text = "";
                lblMostraOperacao.Text = lblMostraOperacao.Text + " " + "+" + " ";
            }
            catch (Exception ex)
            {
            }


        }

        // botão SUBTRAÇÃO
        private void btnSubtracao_Click(object sender, EventArgs e)
        {
            try
            {
                subtrair();
                Continuacao();

                OperacaoSelecionada = Operacao.subtracao;
                coleta = Convert.ToSingle(txtResultado.Text);
                txtResultado.Text = "";
                lblMostraOperacao.Text = lblMostraOperacao.Text + " " + "-" + " ";
            }
            catch
            {

            }
        }

        // botão MULTIPLICAÇÃO
        private void btnMultiplicacao_Click(object sender, EventArgs e)
        {
            try
            {
                multiplicacao();
                Continuacao();

                OperacaoSelecionada = Operacao.multiplicacao;
                coleta = Convert.ToSingle(txtResultado.Text);
                txtResultado.Text = "";
                lblMostraOperacao.Text = lblMostraOperacao.Text + " " + "x" + " ";
            }
            catch
            {

            }
        }

        // botão DIVISÃO
        private void btnDivisao_Click(object sender, EventArgs e)
        {
            try
            {
                divisao();
                Continuacao();

                OperacaoSelecionada = Operacao.divisao;
                coleta = Convert.ToSingle(txtResultado.Text);
                txtResultado.Text = "";
                lblMostraOperacao.Text = lblMostraOperacao.Text + " " + "/" + " ";
            }
            catch (Exception)
            {
            }
        }

        // botão LIMPAR
        private void btnLimpar_Click(object sender, EventArgs e)
        {
            limpaTudo();
        }

        // botão APAGAR
        private void btnApagar_Click(object sender, EventArgs e)
        {
            try
            {

                string Apagar = txtResultado.Text;
                Apagar = Apagar.Remove(Apagar.Length - 1);
                txtResultado.Text = Apagar;


                string apagar = lblMostraOperacao.Text;
                apagar = apagar.Remove(apagar.Length - 1);
                lblMostraOperacao.Text = apagar;
            }
            catch
            {

            }
        }

        // botão IGUAL

        private void btnIgual_Click(object sender, EventArgs e)
        {
            try
            {

                coleta2 = Convert.ToSingle(txtResultado.Text);

                switch (OperacaoSelecionada)
                {
                    case Operacao.adicao:
                        coleta3 = coleta2 + coletaTotal;
                        coletaTotal = coleta + coleta2;
                        txtResultado.Text = Convert.ToString(coletaTotal);
                        lblMostraOperacao.Text = lblMostraOperacao.Text + " " + "=" + " " + Convert.ToString(coletaTotal);
                        if(txtResultado.Text.Contains("-"))
                        {
                            txtResultado.BackColor = Color.Red;
                            txtResultado.ForeColor = Color.White;
                        }
                        else if (lblMostraOperacao.Text.Contains("-") &&  txtResultado.Text != "-")
                        {
                            txtResultado.Text = "+" + txtResultado.Text;
                            txtResultado.BackColor = Color.Green;
                            txtResultado.ForeColor = Color.White;
                        }
                        break;
                    case Operacao.subtracao:
                        coletaTotal = coleta - coleta2;
                        txtResultado.Text = Convert.ToString(coletaTotal);
                        negativo();
                        lblMostraOperacao.Text = lblMostraOperacao.Text + " " + "=" + " " + Convert.ToString(coletaTotal);
                        break;
                    case Operacao.multiplicacao:
                        coletaTotal = coleta * coleta2;
                        txtResultado.Text = Convert.ToString(coletaTotal);
                        lblMostraOperacao.Text = lblMostraOperacao.Text + " " + "=" + " " + Convert.ToString(coletaTotal);
                        break;
                    case Operacao.divisao:
                        coletaTotal = coleta / coleta2;
                        txtResultado.Text = Convert.ToString(coletaTotal);
                        lblMostraOperacao.Text = lblMostraOperacao.Text + " " + "=" + " " + Convert.ToString(coletaTotal);
                        break;
                    default:
                        break;

                }


            }

            catch
            {

            }


        }
        #region limpar
        //LIMPA NUMERO  
        private void limpanumero()
        {
            string igual = lblMostraOperacao.Text;
            if (igual.Contains("="))
            {
                lblMostraOperacao.Text = "";
                txtResultado.Text = "";
                txtResultado.BackColor = Color.White;
            }

        }
         
        //SUB PARA LIMPAR TUDO  
        private void limpaTudo()
        {

            lblMostraOperacao.Text = "";
            txtResultado.Text = "";
            coleta = 0;
            coleta2 = 0;
            coletaTotal = 0;
            coleta3 = 0;
            coletaresultado = "";

            txtResultado.BackColor = Color.White;


        }

        // CONTINUAÇÃO DA CONTA DE MULTIPLICAÇÃO

        private void Continuacao()
        {
            string continua = lblMostraOperacao.Text;
            if (continua.Contains("="))
            {
                lblMostraOperacao.Text = "";
                lblMostraOperacao.Text = Convert.ToString(coletaTotal);

            }

        }

        // SOMAR SÓ APERTANDO A TECLA MAIS 

        private void somar()
        {
            string continua2 = lblMostraOperacao.Text;

            if (continua2.Contains("+") && coletaresultado == "")
            {

                coleta3 = Convert.ToSingle(txtResultado.Text);
                Total = coleta + coleta3;
                lblMostraOperacao.Text = "";
                lblMostraOperacao.Text = Convert.ToString(Total);
                coletaresultado = Convert.ToString(Total);
            }
            else if (continua2.Contains("+") && coletaresultado != "")
            {
                lblMostraOperacao.Text = "";
                float coleta5 = Convert.ToSingle(coletaresultado);
                float coleta6 = Convert.ToSingle(txtResultado.Text);
                float total = coleta5 + coleta6;
                lblMostraOperacao.Text = Convert.ToString(total);
                coletaresultado = Convert.ToString(total);
            }
            
        }
        #endregion

        // SUBTRAIR SO APERTANDO O BOTÃO MAIS 
        private void subtrair()
        {
            string continua2 = lblMostraOperacao.Text;
            if (continua2.Contains("-"))
            {
                coleta3 = Convert.ToSingle(txtResultado.Text);
                Single Total = coleta - coleta3;
                lblMostraOperacao.Text = "";
                lblMostraOperacao.Text = Convert.ToString(Total);
                coletaresultado = Convert.ToString(Total);
            }
            else if (continua2.Contains("-") && continua2 != "")
            {
                lblMostraOperacao.Text = "";
                float coleta5 = Convert.ToSingle(coletaresultado);
                float coleta6 = Convert.ToSingle(txtResultado.Text);
                float total = coleta5 - coleta6;
                lblMostraOperacao.Text = Convert.ToString(total);
                coletaresultado = Convert.ToString(total);
            }
        }

        // MULTIPLICAR SO APERTANDO O BOTÃO DE MULTIPLICAÇÃO
        private void multiplicacao()
        {
            string continua2 = lblMostraOperacao.Text;
            if (continua2.Contains("x"))
            {
                coleta3 = Convert.ToSingle(txtResultado.Text);
                Single Total = coleta * coleta3;
                lblMostraOperacao.Text = "";
                lblMostraOperacao.Text = Convert.ToString(Total);
                coletaresultado = Convert.ToString(Total);
            }
            else if (continua2.Contains("x") && coletaresultado != "")
            {
                lblMostraOperacao.Text = "";
                float coleta5 = Convert.ToSingle(coletaresultado);
                float coleta6 = Convert.ToSingle(txtResultado.Text);
                float total = coleta5 + coleta6;
                lblMostraOperacao.Text = Convert.ToString(total);
                coletaresultado = Convert.ToString(total);
            }
        }

        // DIVIDIR SO APERTANDO O BOTÃO DE DIVISÃO 
        private void divisao()
        {
            string continua2 = lblMostraOperacao.Text;
            if (continua2.Contains("/"))
            {
                coleta3 = Convert.ToSingle(txtResultado.Text);
                Single Total = coleta / coleta3;
                lblMostraOperacao.Text = "";
                lblMostraOperacao.Text = Convert.ToString(Total);

            }

        }
        // SE FOR NEGATIVO MUDAR A COR DO CAMPO 

        private void negativo()
        {
            if (txtResultado.Text.Contains("-"))
            {
                txtResultado.BackColor = Color.Red;
                txtResultado.ForeColor = Color.White;
            }

            
        }

    }

}