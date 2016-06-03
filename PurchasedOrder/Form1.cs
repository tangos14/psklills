using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PurchasedOrder
{
    public partial class Form1 : Form
    {
        bool isUpdateMode = true;
        string oldPON = "";

        public Form1()
        {
            InitializeComponent();
            dataGridView1.AutoGenerateColumns = false;
            dataGridView2.AutoGenerateColumns = false;
            LoadData();
            LoadPurchasedOrderGenerator();
        }

        private void LoadData()
        {
            LoadCriticalItems();
            LoadPurchasedOrder();
        }

        private void LoadCriticalItems()
        {
            dataGridView1.DataSource = null;
            dataGridView1.DataSource = MySQLCommands.GetTable("Select * from tbl_items where ItemQuantity <= 10 ");
        }
        private void LoadPurchasedOrder()
        {
            dataGridView2.DataSource = null;
            dataGridView2.DataSource = MySQLCommands.GetTable("Select * from tbl_purchasedorder");
        }

        private void txtPON_TextChanged(object sender, EventArgs e)
        {

        }
        private void LoadPurchasedOrderGenerator()
        {
           
            try
            {
                txtPON.Text = (int.Parse(MySQLCommands.GetValue("Select max(PON) from tbl_purchasedorder")) + 1) + "";
            }
            catch (Exception)
            {
                txtPON.Text = "1";
            }
        }
     
        
        
    

        private void CreatePO()
        {
            txtPON.Text = (int.Parse(txtPON.Text) + 1).ToString();
            txtQuantity.ResetText();
            cmbUOM.SelectedItem = null;
            cmbsupplier.SelectedItem = null;
        }

        private void btncreate_Click(object sender, EventArgs e)
        {
            CreatePO();
        }

        private void btnbtnitemcreated_Click(object sender, EventArgs e)
        {
            object itemName = dataGridView1.Rows[dataGridView1.SelectedCells[0].RowIndex].Cells["ItemName"].Value;

            if (itemName != null)
            {
                string query = "insert into tbl_purchasedorder(Item,UOM,Supplier,PON,Quantity) Values ('" + itemName.ToString() + "','" + cmbUOM.SelectedItem.ToString() + "','" + cmbsupplier.SelectedItem.ToString() + "','" + txtPON.Text + "','" + txtQuantity.Text + "')";
                MySQLCommands.Insert(query);
                LoadPurchasedOrder();
                txtQuantity.ResetText();
                cmbUOM.SelectedItem = null;
                cmbsupplier.SelectedItem = null;

            }
            else
            {
                MessageBox.Show("Please select an item");
            }
        }

        private void btnitemupdate_Click(object sender, EventArgs e)
        {
            if (!isUpdateMode)
            {
                //enable save mode
                btnitemupdate.Text = "Edit";
                isUpdateMode = true;

                String POID = dataGridView2.Rows[dataGridView2.SelectedCells[0].RowIndex].Cells["POID"].Value.ToString();
                String PON = txtPON.Text;
                String QUAN = txtQuantity.Text;
                String UOM = cmbUOM.SelectedItem.ToString();
                String SUPP = cmbsupplier.SelectedItem.ToString();

                string query = "update tbl_purchasedorder set Quantity = '" + QUAN + "', UOM = '" + UOM + "',Supplier = '" + SUPP + "' where POID = '" + POID + "'";
                MySQLCommands.Update(query);

                //LoadPurchasedOrderGenerator();
                txtPON.Text = oldPON;
                txtQuantity.ResetText();
                cmbUOM.SelectedItem = null;
                cmbsupplier.SelectedItem = null;

                LoadPurchasedOrder();
                
                dataGridView2.Enabled = true;
            }
            else
            {
                //enable save mode
                btnitemupdate.Text = "Save";
                isUpdateMode = false;
                oldPON = txtPON.Text;
                String PON = dataGridView2.Rows[dataGridView2.SelectedCells[0].RowIndex].Cells["PON"].Value.ToString();
                String QUAN = dataGridView2.Rows[dataGridView2.SelectedCells[0].RowIndex].Cells["itemQuantity"].Value.ToString();
                String UOM = dataGridView2.Rows[dataGridView2.SelectedCells[0].RowIndex].Cells["UOM"].Value.ToString();
                String SUPP = dataGridView2.Rows[dataGridView2.SelectedCells[0].RowIndex].Cells["Supplier"].Value.ToString();
                dataGridView2.Enabled = false;

                txtPON.Text = PON;
                txtQuantity.Text = QUAN;
                cmbUOM.SelectedItem = UOM;
                cmbsupplier.SelectedItem = SUPP;
            }
        }

        private void btnItemDelete_Click(object sender, EventArgs e)
        {
            String POID = dataGridView2.Rows[dataGridView2.SelectedCells[0].RowIndex].Cells["POID"].Value.ToString();
            
            string query = "delete from tbl_purchasedorder where POID='" + POID + "';";
            MySQLCommands.Delete(query);
            LoadPurchasedOrder();
                
        }














    }
}
