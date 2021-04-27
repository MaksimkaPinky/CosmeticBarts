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
    public partial class Form3 : Form
    {
        public Model1 db { get; set; }
        public Product pr { get; set; }
        public Form3()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            textBox1.Text = pr.Title;
            textBox2.Text = pr.Cost.ToString();
            textBox3.Text = pr.Description;
            textBox5.Text = pr.ManufacturerID.ToString();
            checkBox1.Checked = pr.IsActive();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            pr.Title = textBox1.Text;
            pr.Cost = Convert.ToDecimal(textBox2.Text);
            pr.Description = textBox3.Text;
            pr.ManufacturerID = Convert.ToInt32(textBox5.Text);
            try
            {
                db.SaveChanges();
                DialogResult = DialogResult.OK;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.InnerException.InnerException.Message);
            }
        }
    }
}
