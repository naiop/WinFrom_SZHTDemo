using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }


        /// <summary>
        /// 动态增加菜单事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, EventArgs e)
        {
            string Submenu = this.textBox1.Text.Trim();

            if (isnull(Submenu))
            {
                edit.DropDownItems.Add(Submenu);
            }

        }


        /// <summary>
        /// 动态增加主菜单
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button2_Click(object sender, EventArgs e)
        {
            string mainmenu = this.textBox2.Text.Trim();
            if (isnull(mainmenu))
            {
                menuStrip1.Items.Add(mainmenu);
            }

        }

        /// <summary>
        /// 判断字符串是否为空
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static bool isnull(string str)
        {
            bool Yes = true;

            if (String.IsNullOrEmpty(str))
            {
                return Yes = false;
            }

            return Yes;
        }



        /// <summary>
        /// 保存
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button3_Click(object sender, EventArgs e)
        {

            string emp = this.emp.Text.Trim();
            string name = this.name.Text.Trim();
            string age = this.age.Text.Trim();


            if (isnull(emp) || isnull(name) || isnull(age))
            {

                dataGridView1.Rows.Add(emp, name, age);
                undo();

            }

        }

        /// <summary>
        ///修改
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// 
        /// dataGridView1.Rows[a].Cells[0].Value.ToString();  行：Rows[0] 列Cells[0]  ;下标都是0 开始

        private void button4_Click(object sender, EventArgs e)
        {
            int a = dataGridView1.CurrentRow.Index;  //获得当前选中行的索引


            dataGridView1.Rows[a].Cells[0].Value = emp.Text.Trim();
            dataGridView1.Rows[a].Cells[1].Value = name.Text.Trim();
            dataGridView1.Rows[a].Cells[2].Value = age.Text.Trim();

            dataGridView1.Rows[a].DefaultCellStyle.BackColor = Color.Red;  //设置某一行颜色


        }


        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button5_Click(object sender, EventArgs e)
        {

            int a = dataGridView1.CurrentRow.Index;  //获得当前选中行的索引
            dataGridView1.Rows.RemoveAt(a);
        }



        /// <summary>
        /// 计算平均年龄
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button6_Click(object sender, EventArgs e)
        {
            double b = 0;
            for (int i = 0; i < dataGridView1.Rows.Count - 1; i++)
            {
                b = Convert.ToInt32(dataGridView1.Rows[i].Cells[2].Value.ToString()) + b;
                if (i == dataGridView1.Rows.Count - 2)
                {
                    b = b / (dataGridView1.Rows.Count - 1);
                    textBox6.Text = Convert.ToString(b);
                }
            }

        }



        private void undo()
        {

            textBox1.Text = "";
            textBox2.Text = "";

            emp.Text = "";
            name.Text = "";
            age.Text = "";
        }



        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int a = dataGridView1.CurrentRow.Index;  //获得当前选中行的索引

            emp.Text = dataGridView1.Rows[a].Cells[0].Value.ToString();  // 行：Rows[0]  列 ：Cells[0]  ， 下标0 开始
            name.Text = dataGridView1.Rows[a].Cells[1].Value.ToString();
            age.Text = dataGridView1.Rows[a].Cells[2].Value.ToString();
        }

     
    }
}
