using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Amlak.Model;



namespace Amlak
{
    public partial class Admin : Form
    {
        MaklerEntities db = new MaklerEntities();
        Model.Amlak selected = new Model.Amlak();
        Area selectedarea = new Area();
        Personal selectedpers = new Personal();
        public Admin()
        {
            InitializeComponent();
            FillType();
            FillArea();
            FillMakler();
        }

        //Fill type
        private void FillType()
        {
            dgvType.DataSource = db.Amlak.Select(t => new
            {
                id = t.Id,
                Type = t.Type,
            }).ToList();
            dgvType.Columns[0].Visible = false;
        }
        // Fill Area
        private void FillArea()
        {
            dgvArea.DataSource = db.Area.Select(a => new
            {
                id = a.Id,
                City = a.City,
                District=a.District,

            }).ToList();
            dgvArea.Columns[0].Visible = false;
        }
        // Fill Makler name
        private void FillMakler()
        {
            dgvPersonal.DataSource = db.Personal.Select(p => new
            {
                id = p.Id,
                Name=p.Makler,
                Telefon = p.Telefon,
                Status=p.Status,

            }).ToList();
            dgvPersonal.Columns[0].Visible = false;
        }
        //Type
        private void btnAddType_Click(object sender, EventArgs e)
        {

            string type = txtType.Text;
            
            if (type == string.Empty)
            {
                lblErrorType.Text = "Columns should be fill";
                return;
            }
            Model.Amlak aml = new Model.Amlak
            {
                Type = type,
            };
            db.Amlak.Add(aml);
            db.SaveChanges();
            FillType();
            txtType.Text = "";
            }
        //Type
        private void btnUpdateType_Click(object sender, EventArgs e)
        {
            lblErrorType.Text = "";
            string type = txtType.Text;
           
            if (type == string.Empty)
            {
                lblErrorType.Text = "Columns should be fill";
                return;
            }
            selected.Type = type;
            
            db.SaveChanges();
            Reset();
        }
        //Type
        private void btnDeleteType_Click(object sender, EventArgs e)
        {
            DialogResult r = MessageBox.Show("Are you sure?", "Delete", MessageBoxButtons.OKCancel);
            if (r == DialogResult.OK)
            {
                db.Amlak.Remove(selected);
                db.SaveChanges();
                Reset();
            }
        }
        //Type
        private void dgvType_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
        
            int id = Convert.ToInt32(dgvType.Rows[e.RowIndex].Cells[0].Value.ToString());
            selected = db.Amlak.Find(id);
            txtType.Text = selected.Type;
            lblErrorType.Text = "";
            btnAddType.Visible = false;
            btnUpdateType.Visible = true;
            btnDeleteType.Visible = true;
    }
        private void dgvArea_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            int id = Convert.ToInt32(dgvArea.Rows[e.RowIndex].Cells[0].Value.ToString());
            selectedarea = db.Area.Find(id);
            txtCity.Text = selectedarea.City;
            txtDistrict.Text = selectedarea.District;
            lblErrorCity.Text = "";
            btnAddCity.Visible = false;
            btnUpdateCity.Visible = true;
            btnDeleteCity.Visible = true;
        }
        private void dgvPersonal_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            int id = Convert.ToInt32(dgvPersonal.Rows[e.RowIndex].Cells[0].Value.ToString());
            selectedpers = db.Personal.Find(id);
            txtMaklerName.Text = selectedpers.Makler;
            txtTelefon.Text = selectedpers.Telefon;
            cmbstatus.Text = selectedpers.Status;
            lblErrormakler.Text = "";
            btnAddmakler.Visible = false;
            btnUpdatemakler.Visible = true;
            btnDeletemakler.Visible = true;
        }
        private void Reset()
        {
            FillType();
            txtType.Text = "";
            btnAddType.Visible = true;
            btnUpdateType.Visible = false;
            btnDeleteType.Visible = false;
        }
        private void ResetArea()
        {
            FillArea();
            txtCity.Text = "";
            txtDistrict.Text = "";
            btnAddCity.Visible = true;
            btnUpdateCity.Visible = false;
            btnDeleteCity.Visible = false;
        }
        private void ResetPersonal()
        {
            FillMakler();
            txtMaklerName.Text = "";
            txtTelefon.Text = "";
            cmbstatus.Text = "";
            btnAddmakler.Visible = true;
            btnUpdatemakler.Visible = false;
            btnDeletemakler.Visible = false;
        }
        //City
        private void btnAddCity_Click(object sender, EventArgs e)
        {
            lblErrorCity.Text = "";
            string city = txtCity.Text;
            string district = txtDistrict.Text;

            if (city == string.Empty|| district == string.Empty)
            {
                lblErrorCity.Text = "Columns should be fill";
                return;
            }
            Model.Area ar = new Model.Area
            {
                City = city,
                District = district,
            };
            db.Area.Add(ar);
            db.SaveChanges();
            FillArea();
            txtCity.Text = "";
            txtDistrict.Text = "";
        }
        //City
        private void btnUpdateCity_Click(object sender, EventArgs e)
        {
            lblErrorCity.Text = "";
            string city = txtCity.Text;
            string district = txtDistrict.Text;

            if (city == string.Empty || district == string.Empty)
            {
                lblErrorCity.Text = "Columns should be fill";
                return;
            }
            selectedarea.City = city;
            selectedarea.District = district;

            db.SaveChanges();
            ResetArea();
        }
        //City
        private void btnDeleteCity_Click(object sender, EventArgs e)
        {
            DialogResult r = MessageBox.Show("Are you sure?", "Delete", MessageBoxButtons.OKCancel);
            if (r == DialogResult.OK)
            {
                db.Area.Remove(selectedarea);
                db.SaveChanges();
                ResetArea();
            }
        }
        //Makler
        private void btnAddmakler_Click(object sender, EventArgs e)
        {
            lblErrormakler.Text = "";
            string name = txtMaklerName.Text;
            string telefon = txtTelefon.Text;
            string status = cmbstatus.Text;

            if (name == string.Empty || telefon == string.Empty || status == string.Empty)
            {
                lblErrormakler.Text = "Columns should be fill";
                return;
            }
            Model.Personal prs = new Model.Personal
            {
                Makler = name,
                Telefon = telefon,
                Status=status,
            };
            db.Personal.Add(prs);
            db.SaveChanges();
            FillMakler();
            txtMaklerName.Text = "";
            txtTelefon.Text = "";
            cmbstatus.Text = "";
        }
        //Makler
        private void btnUpdatemakler_Click(object sender, EventArgs e)
        {
            lblErrormakler.Text = "";
            string name = txtMaklerName.Text;
            string telefon = txtTelefon.Text;
            string status = cmbstatus.Text;

            if (name == string.Empty || telefon == string.Empty || status == string.Empty)
            {
                lblErrormakler.Text = "Columns should be fill";
                return;
            }
            selectedpers.Makler = name;
            selectedpers.Telefon = telefon;
            selectedpers.Status = status;

            db.SaveChanges();
            ResetPersonal();
        }
        //Makler
        private void btnDeletemakler_Click(object sender, EventArgs e)
        {
            DialogResult r = MessageBox.Show("Are you sure?", "Delete", MessageBoxButtons.OKCancel);
            if (r == DialogResult.OK)
            {
                db.Personal.Remove(selectedpers);
                db.SaveChanges();
                ResetPersonal();
            }
        }

        private void btnMain_Click(object sender, EventArgs e)
        {
            Form1 menu = new Form1();
            menu.Show();
            this.Hide();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Form1 menu = new Form1();
            menu.Close();
            this.Close();
        }

        private void Admin_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
    }
}
