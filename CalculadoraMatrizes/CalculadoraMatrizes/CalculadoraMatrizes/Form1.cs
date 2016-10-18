using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace CalculadoraMatrizes
{
    public partial class Form1 : Form
    {
        private TextBox[,] MatrizA;
        private TextBox[,] MatrizB;
        private TextBox[,] MatrizR;
        private float determinante;

        int linhaA, colunaA;
        int linhaB, colunaB;
        public Form1()
        {
            InitializeComponent();
        }

        #region CriarMatriz
        private void btnCriarMatriz_Click(object sender, EventArgs e)
        {
            groupBoxMatriz1.Controls.Clear();

            if (!int.TryParse(textBox1.Text, out linhaA))
            {
                MessageBox.Show("A linha da matriz A é nula.", "Erro");
                return;
            } 
            if (!int.TryParse(textBox3.Text, out colunaA))
            {
                MessageBox.Show("A coluna da matriz A é nula.", "Erro");
                return;
            }

            MatrizA = new TextBox[linhaA, colunaA];
            int TamanhoText = groupBoxMatriz1.Width / colunaA;
            for (int x = 0; x < MatrizA.GetLength(0); x++)
            {
                for (int y = 0; y < MatrizA.GetLength(1); y++)
                {
                    MatrizA[x, y] = new TextBox();
                    MatrizA[x, y].Text = "0";
                    MatrizA[x, y].Top = (x * MatrizA[x, y].Height) + 20;
                    MatrizA[x, y].Left = y * TamanhoText + 6;
                    MatrizA[x, y].Width = TamanhoText;
                    groupBoxMatriz1.Controls.Add(MatrizA[x, y]);
                }
            }
        }
        private void btnCriarMatriz2_Click(object sender, EventArgs e)
        {
            groupBoxMatriz2.Controls.Clear();

            if (!int.TryParse(textBox2.Text, out linhaB))
            {
                MessageBox.Show("A linha da matriz B é nula.", "Erro");
                return;
            }
            if (!int.TryParse(textBox4.Text, out colunaB))
            {
                MessageBox.Show("A coluna da matriz B é nula.", "Erro");
                return;
            }
            int TamanhoText = groupBoxMatriz2.Width / colunaB;
            MatrizB = new TextBox[linhaB, colunaB];
            TamanhoText = groupBoxMatriz2.Width / colunaB;
            for (int x = 0; x < MatrizB.GetLength(0); x++)
            {
                for (int y = 0; y < MatrizB.GetLength(1); y++)
                {
                    MatrizB[x, y] = new TextBox();
                    MatrizB[x, y].Text = "0";
                    MatrizB[x, y].Top = (x * MatrizB[x, y].Height) + 20;
                    MatrizB[x, y].Left = y * TamanhoText + 6;
                    MatrizB[x, y].Width = TamanhoText;
                    groupBoxMatriz2.Controls.Add(MatrizB[x, y]);
                }
            }
        }
        #endregion
        #region Operações entre Matrizes
        private void btnSomar_Click(object sender, EventArgs e)
        {
            if (MatrizA == null || MatrizB == null)
            {
                MessageBox.Show("Matriz nula !", "Error - Matriz");
                return;
            }
            float[,] tempMatriz1 = new float[MatrizA.GetLength(0), MatrizA.GetLength(1)];
            float[,] tempMatriz2 = new float[MatrizB.GetLength(0), MatrizB.GetLength(1)];
            if (tempMatriz1.GetLength(0) != tempMatriz2.GetLength(0) || tempMatriz1.GetLength(1) != tempMatriz2.GetLength(1))
            {
                MessageBox.Show("So e possivel a soma de matrizes de mesma ordem !", "Erro - Soma Matrizes");
                return;
            }

            for (int x = 0; x < MatrizA.GetLength(0); x++)
            {
                for (int y = 0; y < MatrizA.GetLength(1); y++)
                {
                    float n = 0;
                    float.TryParse(MatrizA[x, y].Text, out n);
                    tempMatriz1[x, y] = n;
                }
            } 
            for (int x = 0; x < MatrizB.GetLength(0); x++)
            {
                for (int y = 0; y < MatrizB.GetLength(1); y++)
                {
                    float n = 0;
                    float.TryParse(MatrizB[x, y].Text, out n);
                    tempMatriz2[x, y] = n;
                }
            }

            float[,] tempMatrizR = CalculosMatrizes.SomarMatrizes(tempMatriz1, tempMatriz2);
            MatrizR = new TextBox[tempMatrizR.GetLength(0), tempMatrizR.GetLength(1)];
            int TamanhoText = groupBoxMatrizResultante.Width / MatrizR.GetLength(1);
            groupBoxMatrizResultante.Controls.Clear();
            for (int x = 0; x < MatrizR.GetLength(0); x++)
            {
                for (int y = 0; y < MatrizR.GetLength(1); y++)
                {
                    MatrizR[x, y] = new TextBox();
                    MatrizR[x, y].Text = tempMatrizR[x, y].ToString();
                    MatrizR[x, y].Top = (x * MatrizR[x, y].Height) + 20;
                    MatrizR[x, y].Left = y * TamanhoText + 6;
                    MatrizR[x, y].Width = TamanhoText;
                    groupBoxMatrizResultante.Controls.Add(MatrizR[x, y]);
                }
            }

        }
        private void btnDiminuir_Click(object sender, EventArgs e)
        {
            if (MatrizA == null || MatrizB == null)
            {
                MessageBox.Show("Matriz nula !", "Error - Matriz");
                return;
            }
            float[,] tempMatrizA = new float[MatrizA.GetLength(0), MatrizA.GetLength(1)];
            float[,] tempMatrizB = new float[MatrizB.GetLength(0), MatrizB.GetLength(1)];
            if (tempMatrizA.GetLength(0) != tempMatrizB.GetLength(0) || tempMatrizA.GetLength(1) != tempMatrizB.GetLength(1))
            {
                MessageBox.Show("So e possivel a subtracao de matrizes de mesma ordem !", "Erro - Soma Matrizes");
                return;
            }

            for (int x = 0; x < MatrizA.GetLength(0); x++)
            {
                for (int y = 0; y < MatrizA.GetLength(1); y++)
                {
                    float n = 0;
                    float.TryParse(MatrizA[x, y].Text, out n);
                    tempMatrizA[x, y] = n;
                }
            }
            for (int x = 0; x < MatrizB.GetLength(0); x++)
            {
                for (int y = 0; y < MatrizB.GetLength(1); y++)
                {
                    float n = 0;
                    float.TryParse(MatrizB[x, y].Text, out n);
                    tempMatrizB[x, y] = n;
                }
            }

            float[,] tempMatrizR = CalculosMatrizes.SubtrairMatrizes(tempMatrizA, tempMatrizB);
            MatrizR = new TextBox[tempMatrizR.GetLength(0), tempMatrizR.GetLength(1)];
            int TamanhoText = groupBoxMatrizResultante.Width / MatrizR.GetLength(1);
            groupBoxMatrizResultante.Controls.Clear();
            for (int x = 0; x < MatrizR.GetLength(0); x++)
            {
                for (int y = 0; y < MatrizR.GetLength(1); y++)
                {
                    MatrizR[x, y] = new TextBox();
                    MatrizR[x, y].Text = tempMatrizR[x, y].ToString();
                    MatrizR[x, y].Top = (x * MatrizR[x, y].Height) + 20;
                    MatrizR[x, y].Left = y * TamanhoText + 6;
                    MatrizR[x, y].Width = TamanhoText;
                    groupBoxMatrizResultante.Controls.Add(MatrizR[x, y]);
                }
            }
        }
        private void btnMultiplicar_Click(object sender, EventArgs e)
        {
            if (MatrizA == null || MatrizB == null)
            {
                MessageBox.Show("Matriz nula !", "Error - Matriz");
                return;
            }
            float[,] tempMatrizA = new float[MatrizA.GetLength(0), MatrizA.GetLength(1)];
            float[,] tempMatrizB = new float[MatrizB.GetLength(0), MatrizB.GetLength(1)];
            if (tempMatrizA.GetLength(1) != tempMatrizB.GetLength(0))
            {
                MessageBox.Show("So e possivel a multiplicacao de matrizes onde a coluna da matriz A e igual a linha da matriz B  !", "Erro - Multiplicacao Matrizes");
                return;
            }

            for (int x = 0; x < MatrizA.GetLength(0); x++)
            {
                for (int y = 0; y < MatrizA.GetLength(1); y++)
                {
                    float n = 0;
                    float.TryParse(MatrizA[x, y].Text, out n);
                    tempMatrizA[x, y] = n;
                }
            }
            for (int x = 0; x < MatrizB.GetLength(0); x++)
            {
                for (int y = 0; y < MatrizB.GetLength(1); y++)
                {
                    float n = 0;
                    float.TryParse(MatrizB[x, y].Text, out n);
                    tempMatrizB[x, y] = n;
                }
            }

            float[,] tempMatrizR = CalculosMatrizes.MultiplicarMatrizes(tempMatrizA, tempMatrizB);
            MatrizR = new TextBox[tempMatrizR.GetLength(0), tempMatrizR.GetLength(1)];
            int TamanhoText = groupBoxMatrizResultante.Width / MatrizR.GetLength(1);
            for (int x = 0; x < MatrizR.GetLength(0); x++)
            {
                for (int y = 0; y < MatrizR.GetLength(1); y++)
                {
                    MatrizR[x, y] = new TextBox();
                    MatrizR[x, y].Text = tempMatrizR[x, y].ToString();
                    MatrizR[x, y].Top = (x * MatrizR[x, y].Height) + 20;
                    MatrizR[x, y].Left = y * TamanhoText + 6;
                    MatrizR[x, y].Width = TamanhoText;
                    groupBoxMatrizResultante.Controls.Add(MatrizR[x, y]);
                }
            }
        }
        #endregion
        #region Matriz Resultante
        private void btnGerarOposta_Click(object sender, EventArgs e)
        {
            if (MatrizR == null)
            {
                MessageBox.Show("Matriz nula !", "Error - Matriz");
                return;
            }
            float[,] tempResultante = new float[MatrizR.GetLength(0), MatrizR.GetLength(1)];

            for (int x = 0; x < MatrizR.GetLength(0); x++)
            {
                for (int y = 0; y < MatrizR.GetLength(1); y++)
                {
                    float n = 0;
                    float.TryParse(MatrizR[x, y].Text, out n);
                    tempResultante[x, y] = n;
                }
            }

            float[,] tempMatrizResultante = CalculosMatrizes.GerarOposta(tempResultante);
            int TamanhoText = groupBoxMatrizResultante.Width / MatrizR.GetLength(1);
            for (int x = 0; x < MatrizR.GetLength(0); x++)
            {
                for (int y = 0; y < MatrizR.GetLength(1); y++)
                {
                    MatrizR[x, y].Text = tempMatrizResultante[x, y].ToString();
                }
            }
        }
        private void btnGerarTransposta_Click(object sender, EventArgs e)
        {
            if (MatrizR == null)
            {
                MessageBox.Show("Matriz nula !", "Error - Matriz");
                return;
            }
            float[,] tempResultante = new float[MatrizR.GetLength(0), MatrizR.GetLength(1)];

            for (int x = 0; x < MatrizR.GetLength(0); x++)
            {
                for (int y = 0; y < MatrizR.GetLength(1); y++)
                {
                    float n = 0;
                    float.TryParse(MatrizR[x, y].Text, out n);
                    tempResultante[x, y] = n;
                }
            }

            float[,] tempMatrizR = CalculosMatrizes.GerarTransposta(tempResultante);
            int TamanhoText = groupBoxMatrizResultante.Width / MatrizR.GetLength(1);
            MatrizR = new TextBox[tempMatrizR.GetLength(0), tempMatrizR.GetLength(1)];
            groupBoxMatrizResultante.Controls.Clear();
            for (int x = 0; x < MatrizR.GetLength(0); x++)
            {
                for (int y = 0; y < MatrizR.GetLength(1); y++)
                {   
                    MatrizR[x, y] = new TextBox();
                    MatrizR[x, y].Text = tempMatrizR[x, y].ToString();
                    MatrizR[x, y].Top = (x * MatrizR[x, y].Height) + 20;
                    MatrizR[x, y].Left = y * TamanhoText + 6;
                    MatrizR[x, y].Width = TamanhoText;
                    groupBoxMatrizResultante.Controls.Add(MatrizR[x, y]);
                }
            }
        }
        private void btnGerarDeterminante_Click(object sender, EventArgs e)
        {
            if (MatrizR == null)
            {
                MessageBox.Show("Matriz nula !", "Error - Matriz");
                return;
            }
            float[,] tempResultante = new float[MatrizR.GetLength(0), MatrizR.GetLength(1)];

            for (int x = 0; x < MatrizR.GetLength(0); x++)
            {
                for (int y = 0; y < MatrizR.GetLength(1); y++)
                {
                    float n = 0;
                    float.TryParse(MatrizR[x, y].Text, out n);
                    tempResultante[x, y] = n;
                }
            }
                if (tempResultante.GetLength(0) == 2 && tempResultante.GetLength(1) == 2)
                {
                    determinante = CalculosMatrizes.GerarDeterminante2x2(tempResultante);
                    MessageBox.Show("" + determinante, "Determinante...");
                }
                else if (tempResultante.GetLength(0) == 3 && tempResultante.GetLength(1) == 3)
                {
                    determinante = CalculosMatrizes.GerarDeterminante3x3(tempResultante);
                    MessageBox.Show("" + determinante, "Determinante...");
                }
                else
                {
                    MessageBox.Show("O determinante é o próprio elemento da matriz !", "Propriedade");
                }
        }
        private void btnGerarInversa_Click(object sender, EventArgs e)
        {
            if (MatrizR == null)
            {
                MessageBox.Show("Matriz nula !", "Error - Matriz");
                return;
            }
            float[,] tempResultante = new float[MatrizR.GetLength(0), MatrizR.GetLength(1)];
            float[,] matrizAdjunta = new float[MatrizR.GetLength(0), MatrizR.GetLength(1)];
            float[,] matrizCofatora = new float[MatrizR.GetLength(0), MatrizR.GetLength(1)];
            float determinante = 0; 
            if (tempResultante.GetLength(0) != 2 || tempResultante.GetLength(1) != 2)
            {
                if (tempResultante.GetLength(0) != 3 || tempResultante.GetLength(1) != 3)
                {
                    MessageBox.Show("Matriz invalida !", "Error - Matriz");
                    return;
                }
            }

            for (int x = 0; x < MatrizR.GetLength(0); x++)
            {
                for (int y = 0; y < MatrizR.GetLength(1); y++)
                {
                    float n = 0;
                    float.TryParse(MatrizR[x, y].Text, out n);
                    tempResultante[x, y] = n;
                }
            }
            if (tempResultante.GetLength(0) == 2 && tempResultante.GetLength(1) == 2)
            {
                matrizCofatora = CalculosMatrizes.GerarCofatora2x2(tempResultante);
                matrizAdjunta = CalculosMatrizes.GerarTransposta(matrizCofatora);
                determinante = CalculosMatrizes.GerarDeterminante2x2(tempResultante);
            }
            else if (tempResultante.GetLength(0) == 3 && tempResultante.GetLength(1) == 3)
            {
                matrizCofatora = CalculosMatrizes.GerarCofatora3x3(tempResultante);
                matrizAdjunta = CalculosMatrizes.GerarTransposta(matrizCofatora);
                determinante = CalculosMatrizes.GerarDeterminante3x3(tempResultante);
            }
            else
            {
                MessageBox.Show("Matriz invalida B!", "Error - Matriz");
                return;
            }
            if (determinante == 0)
            {
                MessageBox.Show("Matriz invalida, determinante igual a 0 !", "Error - Matriz");
                return;
            }
            float[,] tempMatrizResultante = CalculosMatrizes.GerarInversa(determinante, matrizAdjunta);
            int TamanhoText = groupBoxMatrizResultante.Width / MatrizR.GetLength(1);
            for (int x = 0; x < MatrizR.GetLength(0); x++)
            {
                for (int y = 0; y < MatrizR.GetLength(1); y++)
                {
                    MatrizR[x, y].Text = tempMatrizResultante[x, y].ToString();
                }
            }
        }
        #endregion
        #region Matriz A
        private void btnGerarOpostaM1_Click(object sender, EventArgs e)
        {
            if (MatrizA == null)
            {
                MessageBox.Show("Matriz nula !", "Error - Matriz");
                return;
            }
            float[,] tempResultante = new float[MatrizA.GetLength(0), MatrizA.GetLength(1)];

            for (int x = 0; x < MatrizA.GetLength(0); x++)
            {
                for (int y = 0; y < MatrizA.GetLength(1); y++)
                {
                    float n = 0;
                    float.TryParse(MatrizA[x, y].Text, out n);
                    tempResultante[x, y] = n;
                }
            }

            float[,] tempMatrizResultante = CalculosMatrizes.GerarOposta(tempResultante);
            int TamanhoText = groupBoxMatriz1.Width / MatrizA.GetLength(1);
            for (int x = 0; x < MatrizA.GetLength(0); x++)
            {
                for (int y = 0; y < MatrizA.GetLength(1); y++)
                {
                    MatrizA[x, y].Text = tempMatrizResultante[x, y].ToString();
                }
            }
        }
        private void btnGerarTranspostM1_Click(object sender, EventArgs e)
        {
            if (MatrizA == null)
            {
                MessageBox.Show("Matriz nula !", "Error - Matriz");
                return;
            }
            float[,] tempResultante = new float[MatrizA.GetLength(0), MatrizA.GetLength(1)];

            for (int x = 0; x < MatrizA.GetLength(0); x++)
            {
                for (int y = 0; y < MatrizA.GetLength(1); y++)
                {
                    float n = 0;
                    float.TryParse(MatrizA[x, y].Text, out n);
                    tempResultante[x, y] = n;
                }
            }

            float[,] tempMatrizResultante = CalculosMatrizes.GerarTransposta(tempResultante);
            int TamanhoText = groupBoxMatriz1.Width / MatrizA.GetLength(1);
            MatrizA = new TextBox[tempMatrizResultante.GetLength(0), tempMatrizResultante.GetLength(1)];
            groupBoxMatriz1.Controls.Clear();
            for (int x = 0; x < MatrizA.GetLength(0); x++)
            {
                for (int y = 0; y < MatrizA.GetLength(1); y++)
                {
                    MatrizA[x, y] = new TextBox();
                    MatrizA[x, y].Text = tempMatrizResultante[x, y].ToString();
                    MatrizA[x, y].Top = (x * MatrizA[x, y].Height) + 20;
                    MatrizA[x, y].Left = y * TamanhoText + 6;
                    MatrizA[x, y].Width = TamanhoText;
                    groupBoxMatriz1.Controls.Add(MatrizA[x, y]);
                }
            }
        }
        private void btnGerarDeterminanteM1_Click(object sender, EventArgs e)
        {
            if (MatrizA == null)
            {
                MessageBox.Show("Matriz nula !", "Error - Matriz");
                return;
            }
            float[,] tempResultante = new float[MatrizA.GetLength(0), MatrizA.GetLength(1)];

            for (int x = 0; x < MatrizA.GetLength(0); x++)
            {
                for (int y = 0; y < MatrizA.GetLength(1); y++)
                {
                    float n = 0;
                    float.TryParse(MatrizA[x, y].Text, out n);
                    tempResultante[x, y] = n;
                }
            }
            if (tempResultante.GetLength(0) == 2 && tempResultante.GetLength(1) == 2)
            {
                determinante = CalculosMatrizes.GerarDeterminante2x2(tempResultante);
                MessageBox.Show("" + determinante, "Determinante...");
            }
            else if (tempResultante.GetLength(0) == 3 && tempResultante.GetLength(1) == 3)
            {
                determinante = CalculosMatrizes.GerarDeterminante3x3(tempResultante);
                MessageBox.Show("" + determinante, "Determinante...");
            }
            else
            {
                MessageBox.Show("Nao e possivel gerar determinante !", "Error - Matriz invalida ");
            }
        }
        private void btnGerarInversaM1_Click(object sender, EventArgs e)
        {
            if (MatrizA == null)
            {
                MessageBox.Show("Matriz nula !", "Error - Matriz");
                return;
            }
            float[,] tempResultante = new float[MatrizA.GetLength(0), MatrizA.GetLength(1)];
            float[,] matrizAdjunta = new float[MatrizA.GetLength(0), MatrizA.GetLength(1)];
            float[,] matrizCofatora = new float[MatrizA.GetLength(0), MatrizA.GetLength(1)];
            float determinante = 0;
            if (tempResultante.GetLength(0) != 2 || tempResultante.GetLength(1) != 2)
            {
                if (tempResultante.GetLength(0) != 3 || tempResultante.GetLength(1) != 3)
                {
                    MessageBox.Show("Matriz invalida !", "Error - Matriz");
                    return;
                }
            }
            for (int x = 0; x < MatrizA.GetLength(0); x++)
            {
                for (int y = 0; y < MatrizA.GetLength(1); y++)
                {
                    float n = 0;
                    float.TryParse(MatrizA[x, y].Text, out n);
                    tempResultante[x, y] = n;
                }
            }
            if (tempResultante.GetLength(0) == 2 && tempResultante.GetLength(1) == 2)
            {
                matrizCofatora = CalculosMatrizes.GerarCofatora2x2(tempResultante);
                matrizAdjunta = CalculosMatrizes.GerarTransposta(matrizCofatora);
                determinante = CalculosMatrizes.GerarDeterminante2x2(tempResultante);
            }
            else if (tempResultante.GetLength(0) == 3 && tempResultante.GetLength(1) == 3)
            {
                matrizCofatora = CalculosMatrizes.GerarCofatora3x3(tempResultante);
                matrizAdjunta = CalculosMatrizes.GerarTransposta(matrizCofatora);
                determinante = CalculosMatrizes.GerarDeterminante3x3(tempResultante);
            }
            else
            {
                MessageBox.Show("Matriz invalida !", "Error - Matriz");
                return;
            }
            if (determinante == 0)
            {
                MessageBox.Show("Matriz invalida, determinante igual a 0 !", "Error - Matriz");
                return;
            }
            float[,] tempMatrizResultante = CalculosMatrizes.GerarInversa(determinante, matrizAdjunta);
            int TamanhoText = groupBoxMatriz1.Width / MatrizA.GetLength(1);
            for (int x = 0; x < MatrizA.GetLength(0); x++)
            {
                for (int y = 0; y < MatrizA.GetLength(1); y++)
                {
                    MatrizA[x, y].Text = tempMatrizResultante[x, y].ToString();
                }
            }
        }
        #endregion
        #region Matriz B
        private void btnGerarOpostaM2_Click(object sender, EventArgs e)
        {
            if (MatrizB == null)
            {
                MessageBox.Show("Matriz nula !", "Error - Matriz");
                return;
            }
            float[,] tempResultante = new float[MatrizB.GetLength(0), MatrizB.GetLength(1)];

            for (int x = 0; x < MatrizB.GetLength(0); x++)
            {
                for (int y = 0; y < MatrizB.GetLength(1); y++)
                {
                    float n = 0;
                    float.TryParse(MatrizB[x, y].Text, out n);
                    tempResultante[x, y] = n;
                }
            }

            float[,] tempMatrizResultante = CalculosMatrizes.GerarOposta(tempResultante);
            int TamanhoText = groupBoxMatriz2.Width / MatrizB.GetLength(1);
            for (int x = 0; x < MatrizB.GetLength(0); x++)
            {
                for (int y = 0; y < MatrizB.GetLength(1); y++)
                {
                    MatrizB[x, y].Text = tempMatrizResultante[x, y].ToString();
                }
            }
        }
        private void btnGerarTranspostM2_Click(object sender, EventArgs e)
        {
            if (MatrizB == null)
            {
                MessageBox.Show("Matriz nula !", "Error - Matriz");
                return;
            }
            float[,] tempResultante = new float[MatrizB.GetLength(0), MatrizB.GetLength(1)];

            for (int x = 0; x < MatrizB.GetLength(0); x++)
            {
                for (int y = 0; y < MatrizB.GetLength(1); y++)
                {
                    float n = 0;
                    float.TryParse(MatrizB[x, y].Text, out n);
                    tempResultante[x, y] = n;
                }
            }

            float[,] tempMatrizResultante = CalculosMatrizes.GerarTransposta(tempResultante);
            int TamanhoText = groupBoxMatriz2.Width / MatrizB.GetLength(1);
            MatrizB = new TextBox[tempMatrizResultante.GetLength(0), tempMatrizResultante.GetLength(1)];
            groupBoxMatriz2.Controls.Clear();
            for (int x = 0; x < MatrizB.GetLength(0); x++)
            {
                for (int y = 0; y < MatrizB.GetLength(1); y++)
                {
                    MatrizB[x, y] = new TextBox();
                    MatrizB[x, y].Text = tempMatrizResultante[x, y].ToString();
                    MatrizB[x, y].Top = (x * MatrizB[x, y].Height) + 20;
                    MatrizB[x, y].Left = y * TamanhoText + 6;
                    MatrizB[x, y].Width = TamanhoText;
                    groupBoxMatriz2.Controls.Add(MatrizB[x, y]);
                }
            }
        }
        private void btnGerarDeterminanteM2_Click(object sender, EventArgs e)
        {
            if (MatrizB == null)
            {
                MessageBox.Show("Matriz nula !", "Error - Matriz");
                return;
            }
            float[,] tempResultante = new float[MatrizB.GetLength(0), MatrizB.GetLength(1)];

            for (int x = 0; x < MatrizB.GetLength(0); x++)
            {
                for (int y = 0; y < MatrizB.GetLength(1); y++)
                {
                    float n = 0;
                    float.TryParse(MatrizB[x, y].Text, out n);
                    tempResultante[x, y] = n;
                }
            }
            if (tempResultante.GetLength(0) == 2 && tempResultante.GetLength(1) == 2)
            {
                determinante = CalculosMatrizes.GerarDeterminante2x2(tempResultante);
                MessageBox.Show("" + determinante, "Determinante...");
            }
            else if (tempResultante.GetLength(0) == 3 && tempResultante.GetLength(1) == 3)
            {
                determinante = CalculosMatrizes.GerarDeterminante3x3(tempResultante);
                MessageBox.Show("" + determinante, "Determinante...");
            }
            else
            {
                MessageBox.Show("Nao e possivel gerar determinante !", "Error - Matriz invalida ");
            }
        }
        private void btnGerarInversaM2_Click(object sender, EventArgs e)
        {
            if (MatrizB == null)
            {
                MessageBox.Show("Matriz nula !", "Error - Matriz");
                return;
            }
            float[,] tempResultante = new float[MatrizB.GetLength(0), MatrizB.GetLength(1)];
            float[,] matrizAdjunta = new float[MatrizB.GetLength(0), MatrizB.GetLength(1)];
            float[,] matrizCofatora = new float[MatrizB.GetLength(0), MatrizB.GetLength(1)];
            float determinante = 0;
            if (tempResultante.GetLength(0) != 2 || tempResultante.GetLength(1) != 2)
            {
                if (tempResultante.GetLength(0) != 3 || tempResultante.GetLength(1) != 3)
                {
                    MessageBox.Show("Matriz invalida !", "Error - Matriz");
                    return;
                }
            }

            for (int x = 0; x < MatrizB.GetLength(0); x++)
            {
                for (int y = 0; y < MatrizB.GetLength(1); y++)
                {
                    float n = 0;
                    float.TryParse(MatrizB[x, y].Text, out n);
                    tempResultante[x, y] = n;
                }
            }
            if (tempResultante.GetLength(0) == 2 && tempResultante.GetLength(1) == 2)
            {
                matrizCofatora = CalculosMatrizes.GerarCofatora2x2(tempResultante);
                matrizAdjunta = CalculosMatrizes.GerarTransposta(matrizCofatora);
                determinante = CalculosMatrizes.GerarDeterminante2x2(tempResultante);
            }
            else if (tempResultante.GetLength(0) == 3 && tempResultante.GetLength(1) == 3)
            {
                matrizCofatora = CalculosMatrizes.GerarCofatora3x3(tempResultante);
                matrizAdjunta = CalculosMatrizes.GerarTransposta(matrizCofatora);
                determinante = CalculosMatrizes.GerarDeterminante3x3(tempResultante);
            }
            else
            {
                MessageBox.Show("Matriz invalida !", "Error - Matriz");
                return;
            }
            if (determinante == 0)
            {
                MessageBox.Show("Matriz invalida, determinante igual a 0 !", "Error - Matriz");
                return;
            }
            float[,] tempMatrizResultante = CalculosMatrizes.GerarInversa(determinante, matrizAdjunta);
            int TamanhoText = groupBoxMatriz2.Width / MatrizB.GetLength(1);
            for (int x = 0; x < MatrizB.GetLength(0); x++)
            {
                for (int y = 0; y < MatrizB.GetLength(1); y++)
                {
                    MatrizB[x, y].Text = tempMatrizResultante[x, y].ToString();
                }
            }
        }
        #endregion

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != 08 && e.KeyChar != ',')
            {
                e.Handled = true;
            }
        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != 08 && e.KeyChar != ',')
            {
                e.Handled = true;
            }
        }

        private void textBox3_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != 08 && e.KeyChar != ',')
            {
                e.Handled = true;
            }
        }

        private void textBox4_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != 08 && e.KeyChar != ',')
            {
                e.Handled = true;
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            textBox1.MaxLength = 2;
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            textBox3.MaxLength = 2;
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            textBox2.MaxLength = 2;
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {
            textBox4.MaxLength = 2;
        }

        private void buttonClear_Click(object sender, EventArgs e)
        {
            groupBoxMatrizResultante.Controls.Clear();
            groupBoxMatriz1.Controls.Clear();
            groupBoxMatriz2.Controls.Clear();

        }
    }
}
