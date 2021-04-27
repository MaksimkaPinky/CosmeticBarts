using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CosmeticBarts
{
    public partial class Form2 : Form
    {
        public Model1 db { get; set; }
        public Form2()
        {
            InitializeComponent();
            
        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == " " || textBox2.Text == " " || textBox3.Text == " " || textBox5.Text == " ")
            {
                MessageBox.Show("Заполните все поля!");
                    return;
            }
            Product pr = new Product();
            pr.Title = textBox1.Text;
            pr.Cost = Convert.ToDecimal(textBox2.Text);
            pr.Description = textBox3.Text;
            pr.ManufacturerID = Convert.ToInt32(textBox5.Text);
            //pr.IsActive = checkBox1.Checked;
            db.Product.Add(pr);
            try
            {
                db.SaveChanges();
                DialogResult = DialogResult.OK;
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.InnerException.InnerException.Message);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {

        }
    }
}
