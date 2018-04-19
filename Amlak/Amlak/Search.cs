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
  
    public partial class Search : Form
    {
        MaklerEntities db = new MaklerEntities();
        public Search()
        {
            InitializeComponent();
            FillDgvSearch();
            FillType();
            FillCity();
            FillDistrict();
            FillSearchRoom();
            FillMakler();
            FillSearchClient();
            FillSearchMob();
        }

        private void FillType()
        {
            foreach (Model.Amlak item in db.Amlak.ToList())
            {
                cmbSearchType.Items.Add(item.Type);
            };
        }
        private void FillDgvSearch()
        {
            dgvSearch.Rows.Clear();
            //List<Elan> src = db.Elan.Where(m => m.Status == "Active").ToList();
            var list = db.Elan.Where(m=> m.Status=="Active").Select(e =>  new 
            {
                e.Id,
                Amlak = e.Amlak.Type,
                e.Condition,
                e.Request,
                City = e.Area.City,
                District = e.Area.District,
                e.Price,
                e.Room,
                e.Note,
                Makler = e.Personal.Makler,
                e.Status,
                AddDate = e.DateIn.Value.ToString(),
                SoldDate = e.DateOut.Value.ToString(),
                e.Client,
                e.C_Telefon
                //e.Buyer,
                //e.B_Telefon
            }).ToList();
            foreach (var item in list)
            {
                dgvSearch.Rows.Add(
                    item.Id,
                    item.Amlak,
                    item.Condition,
                    item.Request,
                    item.City,
                    item.District,
                    item.Price,
                    item.Room,
                    item.Note,
                    item.Makler,
                    item.Status,
                    item.AddDate.ToString(),
                    item.SoldDate.ToString(),
                    item.Client,
                    item.C_Telefon
                    //item.Buyer,
                    //item.B_Telefon
                    );
            }

            dgvSearch.Columns[0].Visible = false;

        }
        private void FillCity()
        {
            List<object> cty = new List<object>();

            foreach (Model.Area item in db.Area.ToList())
            {

                cty.Add(item.City);
            }

            List<object> DistinctCty = cty.Distinct().ToList();

            foreach (object i in DistinctCty)
            {
                cmbSearchCity.Items.Add(i);
            }
        }
        // District
        private void FillDistrict()
        {
            cmbSearchDistrict.Items.Clear();
            List<Area> SearchDistrict = db.Area.Where(a => a.City == cmbSearchCity.Text).ToList();
            foreach (var item in SearchDistrict)
            {
                cmbSearchDistrict.Items.Add(item.District);
            }
        }
        private void FillSearchRoom()
        {
            List<object> rm = new List<object>();

            foreach (Model.Elan item in db.Elan.Where(m => m.Status == "Active").ToList())
            {

                rm.Add(item.Room);
            }

            List<object> DistinctRm = rm.Distinct().ToList();

            foreach (object i in DistinctRm)
            {
                cmbSearchRoom.Items.Add(i);
            }
        }
        private void FillMakler()
        {
            List<Personal> SearchMakler = db.Personal.Where(m => m.Status == "Yes").ToList();
                       
            foreach (Model.Personal item in SearchMakler)
            {
                cmbSearchMakler.Items.Add(item.Makler);
            };

        }
        private void FillSearchClient()
        {
            List<object> cl = new List<object>();

            foreach (Model.Elan item in db.Elan.Where(m => m.Status == "Active").ToList())
            {

                cl.Add(item.Client);
            }

            List<object> DistinctCl = cl.Distinct().ToList();

            foreach (object i in DistinctCl)
            {
                cmbSearchClient.Items.Add(i);
            }
        }
        private void FillSearchMob()
        {
            List<object> mb = new List<object>();

            foreach (Model.Elan item in db.Elan.Where(m => m.Status == "Active").ToList())
            {
                mb.Add(item.C_Telefon);
            }

            List<object> Distinctmb = mb.Distinct().ToList();

            foreach (object m in Distinctmb)
            {
                cmbSearchMob.Items.Add(m);
                cmbSearchMob.Items.Remove(0);
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            List<Elan> src = db.Elan.Where(m=> m.Status=="Active").ToList();
            dgvSearch.Rows.Clear();
            if (cmbSearchType.Text != "")
            {
                src = src.Where(a => a.Amlak.Type == cmbSearchType.Text).ToList();
            }

            if (cmbSearchCondition.Text != "")
            {
                src = src.Where(a => a.Condition == cmbSearchCondition.Text).ToList();
            }

            if (cmbSearchRequest.Text != "")
            {
                src = src.Where(a => a.Request == cmbSearchRequest.Text).ToList();
            }
            if (cmbSearchCity.Text != "")
            {
                src = src.Where(a => a.Area.City == cmbSearchCity.Text).ToList();
            }
            if (cmbSearchDistrict.Text != "")
            {
                src = src.Where(a => a.Area.District == cmbSearchDistrict.Text).ToList();
            }
            if (cmbSearchRoom.Text != "")
            {
                src = src.Where(a => Convert.ToString(a.Room) == cmbSearchRoom.Text).ToList();
            }
            if (cmbSearchMakler.Text != "")
            {
                src = src.Where(a => a.Personal.Makler == cmbSearchMakler.Text).ToList();
            }
            
            if (cmbSearchClient.Text != "")
            {
               src = src.Where(a => a.Client == cmbSearchClient.Text).ToList();
            }

            if (cmbSearchMob.Text != "")
            {
                src = src.Where(a => Convert.ToString(a.C_Telefon) == cmbSearchMob.Text).ToList();
            }

            
            foreach (Elan item in src)
            {
                dgvSearch.Rows.Add(
                        item.Id,
                        item.Amlak.Type,
                        item.Condition,
                        item.Request,
                        item.Area.City,
                        item.Area.District,
                        item.Price,
                        item.Room,
                        item.Note,
                        item.Personal.Makler,
                        item.Status,
                        item.DateIn.ToString(),
                        item.DateOut.ToString(),
                        item.Client,
                        item.C_Telefon
                        //item.Buyer,
                        //item.B_Telefon
                    );
            }
           
        }

       
        private void btnShowAll_Click(object sender, EventArgs e)
        {
           FillDgvSearch();
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

        private void Search_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void cmbSearchCity_SelectedIndexChanged(object sender, EventArgs e)
        {
            FillDistrict();
        }

    
    }
}
