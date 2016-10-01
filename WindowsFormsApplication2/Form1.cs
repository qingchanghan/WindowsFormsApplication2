using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication2
{
    public partial class Form1 : Form
    {
        Subway subSys;
        Dictionary<string,Button> Sta_Buttons;
        List<Button> ButtonPath;
        int clickFlag = 0;

        public Form1(Subway sub)
        {
            subSys = sub;
            Sta_Buttons = new Dictionary<string, Button>();
            ButtonPath = new List<Button>();
            InitializeComponent();
            InitialStationButton();
            pictureBox1.SendToBack();

        }

        private void InitialStationButton()
        {
            int p_x = pictureBox1.Location.X;
            int p_y = pictureBox1.Location.Y;
            for (int i = 0; i < subSys.StaCollection.Count; i++)
            {
                Station temp = subSys.StaCollection.ElementAt(i).Value;
                Button tmp = new Button();

                this.splitContainer1.Panel2.Controls.Add(tmp);

                tmp.BackColor = System.Drawing.Color.White;
                tmp.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
                tmp.FlatAppearance.BorderColor = System.Drawing.Color.Black;
                tmp.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Black;
                tmp.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
                tmp.ForeColor = System.Drawing.Color.Transparent;
                tmp.Location = new System.Drawing.Point(temp.position.Item1+p_x,temp.position.Item2+p_y );
                tmp.Name = temp.StationName;
                tmp.TabIndex = 1;
                tmp.Text = "";
                tmp.UseVisualStyleBackColor = false;
                tmp.Click += new System.EventHandler(this.button_Click);
                if(temp.isTrans)
                    tmp.Size = new System.Drawing.Size(18, 18);
                else
                    tmp.Size = new System.Drawing.Size(12, 12);

                Sta_Buttons.Add(tmp.Name,tmp);//cichuyixiugai
            }
        }
        private void ReSetStationButtonColor()
        {
            foreach (Button a in ButtonPath)
            {
                a.BackColor = System.Drawing.Color.White;
            }
        }
        private void splitContainer1_SplitterMoved(object sender, SplitterEventArgs e)
        {

        }

        private void splitContainer1_Panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void splitContainer1_Panel2_Paint_1(object sender, PaintEventArgs e)
        {

        }

        private void Form1_Resize(object sender, EventArgs e)
        {
            
        }

        private void button_Click(object sender, EventArgs e)
        {
            Button b = sender as Button;
           
            if (clickFlag == 0)
            {
                textBox1.Text = b.Name;
                clickFlag = 1;
                MessageBox.Show("已选择起始站点 :" + b.Name);
            }
            else
            {
                textBox2.Text = b.Name;
                clickFlag = 0;
                MessageBox.Show("已选择目标站点 :" + b.Name);
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void buttonqc_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            clickFlag = 0;
            textBox1.Clear();
            textBox2.Clear();
            ReSetStationButtonColor();

        }

        private void buttoncx_Click(object sender, EventArgs e)
        {
            ReSetStationButtonColor();

            if (textBox1.Text == "" && textBox2.Text != "")
            {
                MessageBox.Show("请输入起始站！");
                return;
            }
            else if(textBox2.Text == "" && textBox1.Text != "")
            {
                MessageBox.Show("请输入终点站！");
                return;
            }
            else if(textBox1.Text==""&&textBox2.Text=="")
            {
                MessageBox.Show("EXCUSE ME???");
                return;
            }

            Tuple<string, int> Result_Path;
            if(!(radioButton1.Checked || radioButton2.Checked || radioButton3.Checked))
            {
                MessageBox.Show("请选择功能！");
                return;
            }

            if(radioButton1.Checked)
            {
                Result_Path = subSys.DjistraPath(textBox1.Text, textBox2.Text);
            }
            else if(radioButton2.Checked)
            {
                Result_Path = subSys.BFSPath(textBox1.Text, textBox2.Text);
            }
            else
            {
                MessageBox.Show("功能待开发。。");
                return;
            }


            if(Result_Path.Item2 == 0)
            {
                MessageBox.Show(Result_Path.Item1);
            }
            else
            {
                listBox1.Items.Clear();
                Button a =null;
                string[] p = Result_Path.Item1.Split('\n');
                foreach(string t in p)
                {
                    listBox1.Items.Add(t);
                    if (t.Contains("换乘"))
                        continue;
                    Sta_Buttons.TryGetValue(t, out a);a.BackColor = System.Drawing.Color.LightGreen;
                    ButtonPath.Add(a);
                    
                }

            }
            //TODO: 根据ButtonPath实现闪烁的功能。


        }
    }
}
