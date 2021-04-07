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





        //---------------------------  实现datagridview 分页效果  获取dataTable拆封多个table显示

        /// <summary>
        ///  查询显示数据到datagridview2 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>

        DataTable dt1 = new DataTable("a");
        DataTable dt2 = new DataTable("b");
        DataTable dt3 = new DataTable("c");
        DataTable dt4 = new DataTable("d");


        private void button7_Click(object sender, EventArgs e)
        {
            DataSet ds = new DataSet();
           


            dt2.Columns.Add("Name");
            dt2.Columns.Add("age");
            dt2.Columns.Add("test");
            dt2.Columns.Add("CustAcct");

            dt1.Columns.Add("Name");
            dt1.Columns.Add("age");
            dt1.Columns.Add("test");
            dt1.Columns.Add("CustAcct");

            dt3.Columns.Add("Name");
            dt3.Columns.Add("age");
            dt3.Columns.Add("test");
            dt3.Columns.Add("CustAcct");

            dt4.Columns.Add("Name");
            dt4.Columns.Add("age");
            dt4.Columns.Add("test");
            dt4.Columns.Add("CustAcct");


            for (int i=0; i<18; i++) 
            {
                dt1.Rows.Add(new object[] { "James Bond, LLC", 120, "Garrison Neely", "1234" });
     
            }


            for (int i = 0; i < 18; i++)
            {
                dt2.Rows.Add(new object[] { "two", 22, "Garrison Neely", "7890" });

            }

            for (int i = 0; i < 18; i++)
            {
                dt3.Rows.Add(new object[] { "danC", 13, "nan", "4567" });

            }


            for (int i = 0; i < 18; i++)
            {
                dt4.Rows.Add(new object[] { "jack", 44, "nv", "2468" });

            }
            ds.Tables.Add(dt1); 
            int count =  dt1.Rows.Count;

           
            
            this.dataGridView2.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;  //DataGridView自动调整列宽
            dataGridView2.DataSource = dt1;
            if(dataGridView2.Rows!= null)
            {
               
                label6.Text = "1";
            }

        }

    


        /// <summary>
        /// 减
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button8_Click(object sender, EventArgs e)
        {

            if (label6.Text == "4")
            {
                label6.Text = "3";
                dataGridView2.DataSource = dt3;
            }
            else if (label6.Text == "3")
            {
                label6.Text = "2";
                dataGridView2.DataSource = dt2;
            }
            else if (label6.Text == "2")
            {
                label6.Text = "1";
                dataGridView2.DataSource = dt1;
            }

        }

        /// <summary>
        /// 加
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button9_Click(object sender, EventArgs e)
        {
            if (label6.Text == "1")
            {
                label6.Text = "2";
                dataGridView2.DataSource = dt2;
            }
            else if (label6.Text == "2")
            {
                label6.Text = "3";
                dataGridView2.DataSource = dt3;
            }
            else if (label6.Text == "3")
            {
                label6.Text = "4";
                dataGridView2.DataSource = dt4;
            }
       
        }











    }
}
