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
            string Submenu =  this.textBox1.Text.Trim();

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
              return  Yes = false;
            }

            return Yes;
        }

 

        public static DataTable mdata(string emp_data ,string name_data ,int age_data)
        {

            DataTable dt = new DataTable();
            DataSet ds = new DataSet();

            dt.Rows.Add(dr);
            ds.Tables.Add(dt);//别忘记向ds中添加table

            return dt;
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
            int  age = Convert.ToInt32(this.age.Text.Trim());

          

            if (isnull(emp) || isnull(name))
            {

              //  this.dataGridView1.DataSource = mdata(emp,name,age);

            }

        }


        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button5_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = null;
        }
    }
}
