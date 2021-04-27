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
    public partial class Form1 : Form
    {
        Model1 db = new Model1();
        public Form1()
        {


            InitializeComponent();
            productBindingSource.DataSource = db.Product.ToList();

        }

        private void Form1_Load(object sender, EventArgs e)
        {
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form2 frmAdd = new Form2();
            frmAdd.db = db;
            DialogResult dr = frmAdd.ShowDialog();
            if (dr == DialogResult.OK)
            {
                productBindingSource.DataSource = db.Product.ToList();
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form3 frmChange = new Form3();
            Product pr = (Product)productBindingSource.Current;
            frmChange.db = db;
            frmChange.pr = pr;
            DialogResult dr = frmChange.ShowDialog();
            if (dr == DialogResult.OK)
            {
                productBindingSource.DataSource = db.Product.ToList();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Product pr = (Product)productBindingSource.Current;
            DialogResult dr = MessageBox.Show("Вы действительно хотите удалить данные?" + pr.ID, "Удаление записей", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == DialogResult.Yes)
            {
                db.Product.Remove(pr);
            }
            try
            {
                db.SaveChanges();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.InnerException.InnerException.Message);
            }
            productBindingSource.DataSource = db.Product.ToList();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            List <Product> prod = (List <Product>)productBindingSource.List;
            prod.Sort(ProdPriceSort);
            productBindingSource.DataSource = prod;
        }
        int ProdPriceSort(Product prd1, Product prd2)
        {
            if (prd1.Cost < prd2.Cost)
            {
                return -1;
            }
            else if (prd1.Cost == prd2.Cost)
            {
                return 0;
            }
            else
            {
                return 1;
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            productBindingSource.DataSource = null;
            productBindingSource.DataSource = db.Product.ToList<Product>();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            List<Product> prod = (List<Product>)productBindingSource.List;
            prod.Sort(ProdPriceSortM);
            productBindingSource.DataSource = prod;
        }
        int ProdPriceSortM(Product prd1, Product prd2)
        {
            if (prd1.Cost < prd2.Cost)
            {
                return 1;
            }
            else if (prd1.Cost == prd2.Cost)
            {
                return 0;
            }
            else
            {
                return -1;
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }
    }
}
