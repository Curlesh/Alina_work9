using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Alina_work9
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {



            int col_vo = dataGridView1.Rows.Count - 1;
            int[] summa = new int[col_vo];
            string[] name = new string[col_vo];
            for (int i = 0; i < col_vo; i++)
            {
                summa[i] = int.Parse(dataGridView1.Rows[i].Cells[1].Value.ToString()) + int.Parse(dataGridView1.Rows[i].Cells[2].Value.ToString()) + int.Parse(dataGridView1.Rows[i].Cells[3].Value.ToString());
                name[i] = Convert.ToString(dataGridView1.Rows[i].Cells[0].Value);
            }
            Array.Sort(summa, name);
            Array.Reverse(name);
            using (StreamWriter file = new StreamWriter("chess.txt"))
            {
                for (int i = 0; i < name.Length; i++)
                {
                    if (i < 3)
                    {
                        file.WriteLine(name[i]);
                    }

                }
                file.Close();
            }


        }

        private void button3_Click(object sender, EventArgs e)
        {
            dataGridView2.Rows.Clear();
            dataGridView2.Visible = true;
            using (StreamReader file = new StreamReader("chess.txt"))
            {
                string[] all_line = new string[3];
                string line = "";
                int i = 0;
                while ((line = file.ReadLine()) != null)
                {

                    all_line[i] = line;
                    i++;
                }
                dataGridView2.Rows.Add(all_line);
                file.Close();
            }
        }

        private void dataGridView1_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
