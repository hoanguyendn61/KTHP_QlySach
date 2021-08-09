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
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
            SetCbAuhor();
            LoadData();
        }
        public static int a_id { get; set; }
        public void SetCbAuhor()
        {
            cbAuthor.Items.Add(new CBBItem { Value = 0, Text = "All" });
            foreach(Author i in Author_BLL.Instance.GetListOfAuthors_BLL())
            {
                cbAuthor.Items.Add(new CBBItem
                {
                    Value = i.A_ID,
                    Text = i.A_Name
                });
            }
            cbAuthor.SelectedIndex = 0;
            a_id = ((CBBItem)cbAuthor.SelectedItem).Value;
        }
        public void LoadData(int a_id = 0)
        {
            if (a_id == 0)
            {
                dGVSach.DataSource = Book_BLL.Instance.GetListOfBooks_BLL();
            } else
            {
                dGVSach.DataSource = Book_BLL.Instance.GetListOfBooks_BLL(a_id);
            }
        }
        private void cbAuthor_SelectedIndexChanged(object sender, EventArgs e)
        {
            a_id = ((CBBItem)cbAuthor.SelectedItem).Value;
            LoadData(a_id);
        }
        private void btnAdd_Click(object sender, EventArgs e)
        {
            DetailForm f = new DetailForm();
            f.d = new DetailForm.MyDel(LoadData);
            f.ShowDialog();
        }
        private void btnEdit_Click(object sender, EventArgs e)
        {
            int b_id = Convert.ToInt32(dGVSach.CurrentRow.Cells[0].Value);
            DetailForm f = new DetailForm(b_id);
            f.d = new DetailForm.MyDel(LoadData);
            f.ShowDialog();
        }
        private void btnDel_Click(object sender, EventArgs e)
        {
            int b_id = Convert.ToInt32(dGVSach.CurrentRow.Cells[0].Value);
            if (Book_BLL.Instance.DeleteBook_BLL(b_id))
            {
                MessageBox.Show("Deleted successfully!", "Information", MessageBoxButtons.OK);
            } else
            {
                MessageBox.Show("Failed to delete", "Information", MessageBoxButtons.OK);
            }
            LoadData(((CBBItem)cbAuthor.SelectedItem).Value);
        }
        private void btnSearch_Click(object sender, EventArgs e)
        {
            if(txtSearch.Text != "")
            {
                List<Book> blist = dGVSach.DataSource as List<Book>;
                dGVSach.DataSource = Book_BLL.Instance.SearchForBook_BLL(blist,txtSearch.Text);
            }
        }
        private void cbSort_SelectedIndexChanged(object sender, EventArgs e)
        {
            List<Book> blist = new List<Book>();
            if (a_id == 0)
            {
                blist = Book_BLL.Instance.GetListOfBooks_BLL();
            }
            else
            {
                blist = Book_BLL.Instance.GetListOfBooks_BLL(a_id);
            }
            if (cbSort.SelectedIndex == 0)
            {
                dGVSach.DataSource = Book_BLL.Instance.SortBookList_BLL(blist, Book.Compare_NameAZ);
            } else
            {
                dGVSach.DataSource = Book_BLL.Instance.SortBookList_BLL(blist, Book.Compare_NameZA);
            }
        }
    }
}
