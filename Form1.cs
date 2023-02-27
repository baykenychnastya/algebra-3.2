using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;


namespace matrix_algerba
{
    public partial class Form1 : Form
    {
        Matrix resultForOperation;
        double resultForEuclid;
        bool f_open1, f_save1; // визначають чи вибрано файл і чи файл збережено
        bool f_open2, f_save2; // визначають чи вибрано файл і чи файл збережено

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            f_open1 = false; // файл не відкрито
            f_save1 = false;
            label1.Text = "-";
            richTextBox1.Text = "";
        }
        private void openFileDialog1_FileOk(object sender, CancelEventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (label1.Text == "-")
            {
                MessageBox.Show("Не вибрано файл для запису матриці!", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (!f_open1) return;

            if (f_save1) return;

            StreamWriter sw = File.CreateText(openFileDialog1.FileName);

            string line;
            for (int i = 0; i < richTextBox1.Lines.Length; i++)
            {
                line = richTextBox1.Lines[i].ToString();

                sw.WriteLine(line);
            }

            sw.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (label1.Text == "-" && label1.Text=="-")
            {
                MessageBox.Show("Не вибрано файли!", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            string fileName = "result.txt";
            Matrix matrixFromFile1 = Matrix.ReadMatrixFromFile(openFileDialog1.FileName);
            Matrix matrixFromFile2 = Matrix.ReadMatrixFromFile(openFileDialog2.FileName);
            try {
                resultForOperation = matrixFromFile1 + matrixFromFile2;
                return;
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            label5.Text = fileName;
            resultForOperation.WriteMatrixToFile(fileName);

            richTextBox3.Clear();

            StreamReader sr = File.OpenText(fileName);

            string line = null;
            line = sr.ReadLine();

            while (line != null)
            {
                richTextBox3.AppendText(line);

                richTextBox3.AppendText("\r\n");

                line = sr.ReadLine();
            }

            sr.Close();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            if (label3.Text == "-")
            {
                MessageBox.Show("Не вибрано файл для запису матриці!", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            string fileName = "result.txt";
            Matrix matrixFromFile1 = Matrix.ReadMatrixFromFile(openFileDialog2.FileName);
            label5.Text = fileName;
            Matrix.WriteEuclideanNormToFile(matrixFromFile1, fileName);

            richTextBox3.Clear();

            StreamReader sr = File.OpenText(fileName);

            string line = null;
            line = sr.ReadLine();

            while (line != null)
            {
                richTextBox3.AppendText(line);

                richTextBox3.AppendText("\r\n");

                line = sr.ReadLine();
            }
            sr.Close();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            if (label3.Text == "-")
            {
                MessageBox.Show("Не вибрано файл для запису матриці!", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (!f_open2) return;

            if (f_save2) return;

            StreamWriter sw = File.CreateText(openFileDialog2.FileName);

            string line;
            for (int i = 0; i < richTextBox2.Lines.Length; i++)
            {
                line = richTextBox2.Lines[i].ToString();

                sw.WriteLine(line);
            }

            sw.Close();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (label1.Text == "-" && label1.Text == "-")
            {
                MessageBox.Show("Не вибрано файли!", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            string fileName = "result.txt";
            Matrix matrixFromFile1 = Matrix.ReadMatrixFromFile(openFileDialog1.FileName);
            Matrix matrixFromFile2 = Matrix.ReadMatrixFromFile(openFileDialog2.FileName);
            try
            {
                resultForOperation = matrixFromFile1 - matrixFromFile2;
                return;
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            label5.Text = fileName;
            resultForOperation.WriteMatrixToFile(fileName);

            richTextBox3.Clear();

            StreamReader sr = File.OpenText(fileName);

            string line = null;
            line = sr.ReadLine();

            while (line != null)
            {
                richTextBox3.AppendText(line);

                richTextBox3.AppendText("\r\n");

                line = sr.ReadLine();
            }

            sr.Close();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (label1.Text == "-" && label1.Text == "-")
            {
                MessageBox.Show("Не вибрано файли!", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            string fileName = "result.txt";
            Matrix matrixFromFile1 = Matrix.ReadMatrixFromFile(openFileDialog1.FileName);
            Matrix matrixFromFile2 = Matrix.ReadMatrixFromFile(openFileDialog2.FileName);
            try
            {
                resultForOperation = matrixFromFile1 * matrixFromFile2;
                return;
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            label5.Text = fileName;
            resultForOperation.WriteMatrixToFile(fileName);

            richTextBox3.Clear();

            StreamReader sr = File.OpenText(fileName);

            string line = null;
            line = sr.ReadLine();

            while (line != null)
            {
                richTextBox3.AppendText(line);

                richTextBox3.AppendText("\r\n");

                line = sr.ReadLine();
            }

            sr.Close();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            if (label1.Text == "-")
            {
                MessageBox.Show("Не вибрано файл для запису матриці!", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            string fileName = "result.txt";
            Matrix matrixFromFile1 = Matrix.ReadMatrixFromFile(openFileDialog1.FileName);
            label5.Text = fileName;
            Matrix.WriteEuclideanNormToFile(matrixFromFile1, fileName);

            richTextBox3.Clear();

            StreamReader sr = File.OpenText(fileName);

            string line = null;
            line = sr.ReadLine();

            while (line != null)
            {
                richTextBox3.AppendText(line);

                richTextBox3.AppendText("\r\n");

                line = sr.ReadLine();
            }
            sr.Close();

        }

        private void button10_Click(object sender, EventArgs e)
        {
            if (label1.Text == "-")
            {
                MessageBox.Show("Не вибрано файл для запису матриці!", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            string value1 = "";
            string value2 = "";
            string value3 = "";
            string value4 = "";
            InputBox(ref value1, ref value2, ref value3, ref value4);
            Matrix a;
            try
            {
                a = Matrix.GenerateRandomMatrix(int.Parse(value1), int.Parse(value2), int.Parse(value3), int.Parse(value4));
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            a.WriteMatrixToFile(openFileDialog1.FileName);

            richTextBox1.Clear();

            StreamReader sr = File.OpenText(openFileDialog1.FileName);

            string line = null;
            line = sr.ReadLine();

            while (line != null)
            {
                richTextBox1.AppendText(line);

                richTextBox1.AppendText("\r\n");

                line = sr.ReadLine();
            }

            sr.Close();
        }

        public static DialogResult InputBox(ref string value1, ref string value2, ref string value3, ref string value4)
        {
            Form form = new Form();

            Label labelCountOfRow = new Label();
            Label labelCountOfColomn = new Label();
            Label labelBoxRenge = new Label();
            Label labelBoxRenge2 = new Label();

            TextBox textBoxCountOfRow = new TextBox();
            TextBox textBoxCountOfColomn = new TextBox();
            TextBox textBoxRenge = new TextBox();
            TextBox textBoxRenge2 = new TextBox();

            Button buttonOk = new Button();

            form.Text = "Random generation";
            labelCountOfRow.Text = "Enter count of row in matrix";
            labelCountOfColomn.Text = "Enter count of colomn in matrix";
            labelBoxRenge.Text = "Enter the data generation limit";
            labelBoxRenge2.Text = "Enter the next data generation limit";


            buttonOk.Text = "OK";
            buttonOk.DialogResult = DialogResult.OK;

            labelCountOfRow.SetBounds(20, 36, 200, 13);
            labelCountOfColomn.SetBounds(20, 72, 200, 13);
            labelBoxRenge.SetBounds(20, 108, 200, 13);
            labelBoxRenge2.SetBounds(20, 144, 200, 13);

            textBoxCountOfRow.SetBounds(300, 36, 372, 13);
            textBoxCountOfColomn.SetBounds(300, 72, 372, 13);
            textBoxRenge.SetBounds(300, 108, 372, 13);
            textBoxRenge2.SetBounds(300, 144, 372, 13);

            buttonOk.SetBounds(20, 200, 80, 30);

            textBoxCountOfRow.AutoSize = true;
            textBoxCountOfColomn.AutoSize = true;
            textBoxRenge.AutoSize = true;
            textBoxRenge2.AutoSize = true;

            form.ClientSize = new Size(796, 307);
            form.FormBorderStyle = FormBorderStyle.FixedDialog;
            form.StartPosition = FormStartPosition.CenterScreen;
            form.MinimizeBox = false;
            form.MaximizeBox = false;
            form.Controls.AddRange(new Control[] { labelCountOfRow, textBoxCountOfRow, buttonOk });
            form.Controls.AddRange(new Control[] { labelCountOfColomn, textBoxCountOfColomn, buttonOk });
            form.Controls.AddRange(new Control[] { labelBoxRenge, textBoxRenge, buttonOk });
            form.Controls.AddRange(new Control[] { labelBoxRenge2, textBoxRenge2, buttonOk });

            form.AcceptButton = buttonOk;

            DialogResult dialogResult = form.ShowDialog();

            value1 = textBoxCountOfRow.Text;
            value2 = textBoxCountOfColomn.Text;
            value3 = textBoxRenge.Text;
            value4 = textBoxRenge2.Text;

            return dialogResult;

        }

        private void button11_Click(object sender, EventArgs e)
        {
            if (label3.Text == "-")
            {
                MessageBox.Show("Не вибрано файл для запису матриці!", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            string value1 = "";
            string value2 = "";
            string value3 = "";
            string value4 = "";
            InputBox(ref value1, ref value2, ref value3, ref value4);
            Matrix a;
            try
            {
                a = Matrix.GenerateRandomMatrix(int.Parse(value1), int.Parse(value2), int.Parse(value3), int.Parse(value4));
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            a.WriteMatrixToFile(openFileDialog2.FileName);

            richTextBox2.Clear();

            StreamReader sr = File.OpenText(openFileDialog2.FileName);

            string line = null;
            line = sr.ReadLine();

            while (line != null)
            {
                richTextBox2.AppendText(line);

                richTextBox2.AppendText("\r\n");

                line = sr.ReadLine();
            }

            sr.Close();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button7_Click(object sender, EventArgs e)
        {
            if (openFileDialog2.ShowDialog() == DialogResult.OK)
            {
                label3.Text = openFileDialog2.FileName;

                f_open2 = true;
                f_save2 = false;

                richTextBox2.Clear();

                StreamReader sr = File.OpenText(openFileDialog2.FileName);

                string line = null;
                line = sr.ReadLine();

                while (line != null)
                {
                    richTextBox2.AppendText(line);

                    richTextBox2.AppendText("\r\n");

                    line = sr.ReadLine();
                }

                sr.Close();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                label1.Text = openFileDialog1.FileName;

                f_open1 = true;
                f_save1 = false;

                richTextBox1.Clear();

                StreamReader sr = File.OpenText(openFileDialog1.FileName);

                string line = null;
                line = sr.ReadLine(); 

                while (line != null)
                {
                    richTextBox1.AppendText(line);

                    richTextBox1.AppendText("\r\n");

                    line = sr.ReadLine();
                }

                sr.Close();
            }
        }
    }
}
