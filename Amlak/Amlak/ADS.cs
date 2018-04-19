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
    public partial class ADS : Form
    {
        MaklerEntities db = new MaklerEntities();
        Model.Elan selected = new Model.Elan();
        int clickRow = 0;
        public ADS()
        {
            InitializeComponent();
            FillCity();
            FillDistrict();
            FillType();
            FillMakler();
            FillDgvAds();
            FillSearchRoom();
            FillSearchClient();
            FillSearchBuyer();
            FillSearchMob();
        }
        //City
        private void FillType()
        {
            foreach (Model.Amlak item in db.Amlak.ToList())
            {
                cmbType.Items.Add(item.Id + "-" + item.Type);
                cmbSearchType.Items.Add(item.Type);
            };
        }
        private void FillMakler()
        {

            List<Personal> Makler = db.Personal.Where(m => m.Status == "Yes").ToList();
            List<Personal> SearchMakler = db.Personal.ToList();
            foreach (Model.Personal item in Makler)
            {
                cmbMakler.Items.Add(item.Id+"-"+item.Makler);
            };
            foreach (Model.Personal item in SearchMakler)
            {
                cmbSearchMakler.Items.Add(item.Makler);
            };

        }
        // City
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
                cmbCity.Items.Add(i);
                cmbSearchCity.Items.Add(i);
            }
        }
        // District
        private void FillDistrict()
        {
            cmbDistrict.Items.Clear();
            cmbSearchDistrict.Items.Clear();
            List<Area> District = db.Area.Where(a => a.City == cmbCity.Text).ToList();
            List<Area> SearchDistrict = db.Area.Where(a => a.City == cmbSearchCity.Text).ToList();
            foreach (var item in District)
            {
                cmbDistrict.Items.Add(item.Id+"-"+item.District);
            }
            foreach (var item in SearchDistrict)
            {
                cmbSearchDistrict.Items.Add(item.District);
            }
        }
        private void cmbCity_SelectedIndexChanged(object sender, EventArgs e)
        {
            FillDistrict();
        }
        private void cmbSearchCity_SelectedIndexChanged(object sender, EventArgs e)
        {
            FillDistrict();
        }
        // Fill datagrade
        private void FillDgvAds()
        {
            dgvAds.Rows.Clear();
            var list = db.Elan.Select(e => new
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
                e.C_Telefon,
                e.Buyer,
                e.B_Telefon
            }).ToList();

            foreach (var item in list)
            {
                dgvAds.Rows.Add(
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
                    item.C_Telefon,
                    item.Buyer,
                    item.B_Telefon
                    
                    //item.AddDate.ToString("dd.MM.yyyy"),
                    //item.SoldDate.ToString("dd.MM.yyyy")
                    
                    //item.EnterDate.ToString("dd.MM.yyyy"),
                    //item.ExpireDate.ToString("dd.MM.yyyy")
                    );
            }
           
            dgvAds.Columns[0].Visible = false;
        }
        // Fill Room in Search
        private void FillSearchRoom()
        {
            List<object> rm = new List<object>();

            foreach (Model.Elan item in db.Elan.ToList())
            {

                rm.Add(item.Room);
            }

            List<object> DistinctRm = rm.Distinct().ToList();

            foreach (object i in DistinctRm)
            {
                cmbSearchRoom.Items.Add(i);
            }
        }
        private void FillSearchClient()
        {
            List<object> cl = new List<object>();

            foreach (Model.Elan item in db.Elan.ToList())
            {

                cl.Add(item.Client);
            }

            List<object> DistinctCl = cl.Distinct().ToList();

            foreach (object i in DistinctCl)
            {
                cmbSearchClient.Items.Add(i);
            }
        }
        private void FillSearchBuyer()
        {
            List<string> br = new List<string>();
            foreach (Model.Elan item in db.Elan.ToList())
            {

                br.Add(item.Buyer);
            }

            List<string> dtList = br.Where(s => !string.IsNullOrEmpty(s)).Distinct().ToList();
            foreach (object i in dtList)
            {

                cmbSearchBuyer.Items.Add(i);
            }
        }
        private void FillSearchMob()
        {
            List<object> mb = new List<object>();

            foreach (Elan item in db.Elan.ToList())
            {

                mb.Add(item.B_Telefon);
                mb.Add(item.C_Telefon);
            }
            List<object> Distinctmb = mb.Distinct().ToList();
           
            foreach (object m in Distinctmb)
            {
                cmbSearchMob.Items.Add(m);
                cmbSearchMob.Items.Remove(0); 
            }
        }
        private void Reset()
        {
            FillDgvAds();
            cmbType.Text = "";
            cmbCondition.Text = "";
            cmbRequest.Text = "";
            cmbCity.Text = "";
            cmbDistrict.Text = "";
            txtPrice.Text = "";
            txtRoom.Text = "";
            txtNote.Text = "";
            cmbMakler.Text = "";
            cmbStatus.Text = "";
            txtBuyer.Text = "";
            txtBuyerMob.Text = "";
            txtClient.Text = "";
            txtClientTel.Text = "";
            btnAddAds.Visible = true;
            btnUpdateAds.Visible = false;
            btnDeleteAds.Visible = false;
        }

        private void btnAddAds_Click(object sender, EventArgs e)
        {
            lblErrorAds.Text = "";
            string amlak = cmbType.Text;
            string condition = cmbCondition.Text;
            string request = cmbRequest.Text;
            string city = cmbCity.Text;
            string district = cmbDistrict.Text;
            string price = txtPrice.Text;
            string room = txtRoom.Text;
            string note = txtNote.Text;
            string makler = cmbMakler.Text;
            string status = cmbStatus.Text;
            string datein = dtDateAdd.Value.ToString("dd.MM.yyyy");
            string dateout = dtDateSold.Value.ToString("dd.MM.yyyy");
            string buyer = txtBuyer.Text;
            string buyermob = txtBuyerMob.Text;
            string client = txtClient.Text;
            string clientmob = txtClientTel.Text;

            if (amlak == string.Empty || condition == string.Empty || request == string.Empty ||
                city == string.Empty || district == string.Empty || price == string.Empty
                || room == string.Empty || note == string.Empty || makler == string.Empty
                || status == string.Empty || datein == string.Empty
                ||client==string.Empty||clientmob==string.Empty)
            {
                lblErrorAds.Text = "All Columns should be fill";
                return;
            }
            decimal Price = 0;
            Price.ToString("#.##");
            if (!decimal.TryParse(price, out Price))
            {
                lblErrorAds.Text = "Price should be only digital: #,##";
                return;
            }
            int Room = 0;
            if (!int.TryParse(room, out Room))
            {
                lblErrorAds.Text = "Room should be only digital";
                return;
            }

            int Clientmob = 0;
            if (!int.TryParse(clientmob, out Clientmob))
            {
                lblErrorAds.Text = "Client mobile should be only digital";
                return;
            }

            int Buyermob;
                        
            if (!int.TryParse(buyermob, out Buyermob))
            {
                lblErrorAds.Text = "Buyer mobile should be only digital";
                return;
            }
           
            

            Model.Elan eln = new Model.Elan
            {
                Amlakid = Convert.ToInt32(amlak.Split('-')[0]),
                Condition = condition,
                Request = request,
                Areaid = Convert.ToInt32(district.Split('-')[0]),
                Price=Price,
                Room = Room,
                Note = note,
                Personalid = Convert.ToInt32(makler.Split('-')[0]),
                Status = status,
                DateIn = dtDateAdd.Value,
                DateOut = dtDateSold.Value,
                Buyer=buyer,
                Client=client,
                B_Telefon=Buyermob,
                C_Telefon=Clientmob

            };

            //    //Elan eln = new Elan();


            //    //eln.Amlakid = Convert.ToInt32(cmbType.Text.Split('-')[0]);
            //    //eln.Condition = cmbCondition.Text;
            //    //eln.Request = request;
            //    //eln.Areaid = Convert.ToInt32(district.Split('-')[0]);
            //    //eln.Price = Convert.ToDecimal(txtPrice.Text);
            //    //eln.Room = Convert.ToInt32(txtRoom.Text);
            //    //Room=room,
            //    //eln.Note = note;


            db.Elan.Add(eln);
            db.SaveChanges();
            FillDgvAds();
            Reset();
        }

        private void dgvAds_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            tbcTab.SelectedTab = tabAdd;
            int id = Convert.ToInt32(dgvAds.Rows[e.RowIndex].Cells[0].Value.ToString());

            this.selected = db.Elan.Find(id);
            this.clickRow = e.RowIndex;
            cmbType.Text = this.selected.Amlakid + "-" + this.selected.Amlak.Type;
            cmbCondition.Text = selected.Condition;
            cmbRequest.Text = selected.Request;
            cmbCity.Text = this.selected.Area.City;
            cmbDistrict.Text = this.selected.Areaid+"-"+this.selected.Area.District;
            txtPrice.Text = this.selected.Price.ToString();
            txtRoom.Text = selected.Room.ToString();
            txtNote.Text = selected.Note;
            cmbMakler.Text = this.selected.Personalid+"-"+this.selected.Personal.Makler;
            cmbStatus.Text = selected.Status;
            dtDateAdd.Value = this.selected.DateIn.Value;
            dtDateSold.Value = this.selected.DateOut.Value;
            txtBuyer.Text = selected.Buyer;
            txtClient.Text = selected.Client;
            txtBuyerMob.Text = selected.B_Telefon.ToString();
            txtClientTel.Text = selected.C_Telefon.ToString();
            lblErrorAds.Text = "";
            btnAddAds.Visible = false;
            btnUpdateAds.Visible = true;
            btnDeleteAds.Visible = true;
        }

        private void btnUpdateAds_Click(object sender, EventArgs e)
        {
            lblErrorAds.Text = "";
            string amlak = cmbType.Text;
            string condition = cmbCondition.Text;
            string request = cmbRequest.Text;
            string city = cmbCity.Text;
            string district = cmbDistrict.Text;
            string price = txtPrice.Text;
            string room = txtRoom.Text;
            string note = txtNote.Text;
            string makler = cmbMakler.Text;
            string status = cmbStatus.Text;
            string datein = dtDateAdd.Value.ToString("dd.MM.yyyy");
            string dateout = dtDateSold.Value.ToString("dd.MM.yyyy");
            string buyer = txtBuyer.Text;
            string buyermob = txtBuyerMob.Text;
            string client = txtClient.Text;
            string clientmob = txtClientTel.Text;

            if (amlak == string.Empty || condition == string.Empty || request == string.Empty ||
                city == string.Empty || district == string.Empty || price == string.Empty
                || room == string.Empty || note == string.Empty || makler == string.Empty
                || status == string.Empty || datein == string.Empty|| client == string.Empty || clientmob == string.Empty)
            {
                lblErrorAds.Text = "All Columns should be fill";
                return;
            }
            decimal Price = 0;
            Price.ToString("#.##");
            if (!decimal.TryParse(price, out Price))
            {
                lblErrorAds.Text = "Price should be only digital: #,##";
                return;
            }
            int Room = 0;
            if (!int.TryParse(room, out Room))
            {
                lblErrorAds.Text = "Room should be only digital";
                return;
            }
            int Buyermob = 0;
            
            if (txtBuyerMob.Text != "")
            {
                if (!int.TryParse(buyermob, out Buyermob))
                {
                    lblErrorAds.Text = "Buyer mobile should be only digital";
                    return;
                }
                {
                     txtBuyerMob.Text = null;
                }
            }
            int Clientmob = 0;
            if (!int.TryParse(clientmob, out Clientmob))
            {
                lblErrorAds.Text = "Client mobile should be only digital";
                return;
            }

            selected.Amlakid = Convert.ToInt32(amlak.Split('-')[0]);
            selected.Condition = condition;
            selected.Request = request;
            selected.Areaid = Convert.ToInt32(district.Split('-')[0]);
            selected.Price = Price;
            selected.Room = Room;
            selected.Note = note;
            selected.Personalid = Convert.ToInt32(makler.Split('-')[0]);
            selected.Status = status;
            selected.DateIn = dtDateAdd.Value;
            selected.DateOut = dtDateSold.Value;
            selected.Buyer = buyer;
            selected.Client = client;
            selected.B_Telefon = Buyermob;
            selected.C_Telefon = Clientmob;

           
            db.SaveChanges();
            Reset();
        }

        private void btnDeleteAds_Click(object sender, EventArgs e)
        {
            DialogResult r = MessageBox.Show("Are you sure?", "Delete", MessageBoxButtons.OKCancel);
            if (r == DialogResult.OK)
            {
                db.Elan.Remove(selected);
                db.SaveChanges();
                Reset();
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

        private void ADS_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        //Search

        private void btnSearch_Click(object sender, EventArgs e)
        {
            //ShowAll();
            //var find = dgvAds.Rows.Cast<DataGridViewRow>();
            List<Elan> ads = db.Elan.ToList();
               
            dgvAds.Rows.Clear();
            if (cmbSearchType.Text != "")
            {
                ads = ads.Where(a => a.Amlak.Type == cmbSearchType.Text).ToList();
            }
            if (cmbSearchCondition.Text!="")
            {
                ads = ads.Where(a => a.Condition == cmbSearchCondition.Text).ToList();
            }
            
            if (cmbSearchRequest.Text != "")
            {
                ads = ads.Where(a => a.Request == cmbSearchRequest.Text).ToList();
            }
            if (cmbSearchCity.Text != "")
            {
                ads = ads.Where(a => a.Area.City == cmbSearchCity.Text).ToList();
            }
            if (cmbSearchDistrict.Text != "")
            {
                ads = ads.Where(a => a.Area.District == cmbSearchDistrict.Text).ToList();
            }
            if (cmbSearchRoom.Text != "")
            {
                ads = ads.Where(a => Convert.ToString(a.Room) == cmbSearchRoom.Text).ToList();
            }
            if (cmbSearchMakler.Text != "")
            {
                ads = ads.Where(a => a.Personal.Makler == cmbSearchMakler.Text).ToList();
            }
            if (cmbSearchStatus.Text != "")
            {
                ads = ads.Where(a => a.Status == cmbSearchStatus.Text).ToList();
            }
            if (cmbSearchClient.Text != "")
            {
                ads = ads.Where(a => a.Client == cmbSearchClient.Text).ToList();
            }
            if (cmbSearchBuyer.Text != "")
            {
                ads = ads.Where(a => a.Buyer == cmbSearchBuyer.Text).ToList();
            }
            if (cmbSearchMob.Text != "")
            {
                ads = ads.Where(a => Convert.ToString(a.B_Telefon)== cmbSearchMob.Text
                || Convert.ToString(a.C_Telefon) == cmbSearchMob.Text).ToList();
            }
            foreach (Elan item in ads)
            {
                dgvAds.Rows.Add(
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
                        item.C_Telefon,
                        item.Buyer,
                        item.B_Telefon
                    );
            }
 
            // if (cmbtest.Text != string.Empty)
            // {
            //     string Condition = cmbtest.Text;
            //     find = find.Where(r => r.Cells[2].Value.ToString() != Condition);
            //     MessageBox.Show(find.ToString());
            // }
            // //if (cmbSearchType.Text != string.Empty)
            // //{
            // //    string type = cmbSearchType.Text.Split('-')[1];
            // //    find = find.Where(r => r.Cells[0].Value.ToString() != type);
            // //    MessageBox.Show(type.ToString());
            // //}
            //foreach (DataGridViewRow item in find.ToList())
            // {
            //     dgvAds.Rows[item.Index].Visible = false;

            // }

        }
       
        //private void ShowAll()
        //{
        //    foreach (DataGridViewRow item in dgvAds.Rows)
        //    {
        //        dgvAds.Rows[item.Index].Visible = true;
        //        //MessageBox.Show(item.Cells[2].Value.ToString());
        //    }
        //}

        private void btnShowAll_Click(object sender, EventArgs e)
        {
            FillDgvAds();
        }

       
    }
}
