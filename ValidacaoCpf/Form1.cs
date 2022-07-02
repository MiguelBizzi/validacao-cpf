using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ValidacaoCpf
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnLimpar_Click(object sender, EventArgs e)
        {
            txtCpf.Clear();
            txtSituacao.Clear();
            txtUf.Clear();
            txtCpf.Focus();
        }

        private void btnVerificar_Click(object sender, EventArgs e)
        {
            string cpf = txtCpf.Text;
            if (cpf.Length == 11 || cpf.Length == 14)
            {
                cpf = cpf.Replace(".", "");
                cpf = cpf.Replace("-", "");

                int[] d = new int[11];
                int soma = 0;
                int somasegundo = 0;
                for (int i = 0; i < 11; i++)
                {
                    d[i] = int.Parse(cpf.Substring(i, 1));
                }
                for (int i = 10; i >= 2; i--)
                {
                    soma += d[10 - i] * i;
                }

                int resto;
                resto = soma % 11;
                int digito;

                if (resto < 2)
                {
                    digito = 0;
                }
                else
                {
                    digito = 11 - resto;
                }
              

                // SEGUNDO DIGITO 

                
                int resto2;
                int soma2 = 0;
                
                int digito2;

                if(digito == d[9])
                {
                    for (int i = 0; i < 11; i++)
                    {
                        d[i] = int.Parse(cpf.Substring(i, 1));
                    }
                    for (int i = 11; i >= 2; i--)
                    {
                        soma2 += d[11 - i] * i;

                    }
                    resto2 = soma2 % 11;

                    if (resto2 < 2)
                    {
                        digito2 = 0;
                    }
                    else
                    {
                        digito2 = 11 - resto2;
                    }
                    txtSituacao.Text = soma.ToString() + " Digito1:" + digito + " Digito2:" + digito2;

                    switch (d[8])
                    {
                        case 1:
                            txtUf.Text = "Distrito Federal, Goiás, Mato Grosso do Sul e Tocantins;";
                            break;
                        case 2:
                            txtUf.Text = "Pará, Amazonas, Acre, Amapá, Rondônia e Roraima;";
                            break;
                        case 3:
                            txtUf.Text = "Ceará, Maranhão e Piauí;";
                            break;
                        case 4:
                            txtUf.Text = "Pernambuco, Rio Grande do Norte, Paraíba e Alagoas;";
                            break;
                        case 5:
                            txtUf.Text = "Bahia e Sergipe;";
                            break;
                        case 6:
                            txtUf.Text = "Minas Gerais;";
                            break;
                        case 7:
                            txtUf.Text = "Rio de Janeiro e Espírito Santo;";
                            break;
                        case 8:
                            txtUf.Text = "São Paulo;";
                            break;
                        case 9:
                            txtUf.Text = "Paraná e Santa Catarina;";
                            break;
                        case 0:
                            txtUf.Text = "Rio Grande do Sul.";
                            break;
                    }

                }
                




            }
            else
            {
                txtCpf.Text = "CPF INVALIDO";
            }

          


            }
        }
    }

