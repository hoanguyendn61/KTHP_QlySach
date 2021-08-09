using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BusinessLayerLogic;
using DataTransferObject;
namespace KTHP_NET
{
    public partial class DetailForm : Form
    {
        public delegate void MyDel(int id = 0);
        public MyDel d { get; set; }
        public int bookID;
        public DetailForm()
        {
            InitializeComponent();
            SetCBAuthor();
            rbAvailable.Checked = true;
        }
        public DetailForm(int b_id)
        {
            InitializeComponent();
            SetCBAuthor();
            bookID = b_id;
            SetGUI();
        }
        public void SetGUI()
        {
            txtbID.Enabled = false;
            Book b = Book_BLL.Instance.GetBookByID_BLL(bookID);
            txtbID.Text = b.B_ID.ToString();
            txtbName.Text = b.B_Name;
            cbAuthor.SelectedIndex = b.A_ID - 1;
            if (b.B_Status)
            {
                rbAvailable.Checked = true;
            } else
            {
                rbUnavailable.Checked = true;
            }
            dtpPub.Value = b.B_PublishDate;
        }
        public void SetCBAuthor(int a_id = 1)
        {
            foreach(Author i in Author_BLL.Instance.GetListOfAuthors_BLL())
            {
                cbAuthor.Items.Add(new CBBItem
                {
                    Value = i.A_ID,
                    Text = i.A_Name,
                });
            }
            cbAuthor.SelectedIndex = 1;
        }
        private void btnOK_Click(object sender, EventArgs e)
        {
            Book b = new Book();
            b.B_ID = Convert.ToInt32(txtbID.Text);
            b.B_Name = txtbName.Text;
            b.A_ID = ((CBBItem)cbAuthor.SelectedItem).Value;
            b.B_PublishDate = dtpPub.Value;
            b.B_Status = rbAvailable.Checked;
            if (Book_BLL.Instance.SaveBook_BLL(b))
            {
                MessageBox.Show("Saved successfully!", "Information", MessageBoxButtons.OK);
            } else
            {
                MessageBox.Show("Failed to save", "Information", MessageBoxButtons.OK);
            }
            d(MainForm.a_id);
            this.Dispose();
        }
        private void btnCancel_Click(object sender, EventArgs e)
        {
            d(MainForm.a_id);
            this.Dispose();
        }
    }
}
