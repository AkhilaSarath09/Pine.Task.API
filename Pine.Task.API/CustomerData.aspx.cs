using Pine.Task.BL;
using Pine.Task.BL.BLEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Security.Policy;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Pine.Task.API
{
    public partial class CustomerData : System.Web.UI.Page
    {
        HttpClient HttpClient;
        readonly string apibase = @"http://localhost:50028/api/customer/";
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                HttpClient = new HttpClient();
                HttpClient.BaseAddress = new Uri(apibase);
                if (!IsPostBack)
                {

                    RefreshData();
                }
            }
            catch
            {


            }
        }
        protected void CreateCustomer_Click(object sender, EventArgs e)
        {
            var createurl = apibase + "CreateCustomer";
            Customer customer = new Customer()
            {
                Name = customerName.Text,
                Address = Address.Text,
                City = city.Text,
                Mobile = mobile.Text
            };
            StringContent queryString = new StringContent(Newtonsoft.Json.JsonConvert.SerializeObject(customer), System.Text.Encoding.UTF8, "application/json");
            HttpResponseMessage response = HttpClient.PostAsync(createurl, queryString).Result;
            RefreshData();
        }

        protected void GridView1_RowEditing(object sender, System.Web.UI.WebControls.GridViewEditEventArgs e)
        {
            customergrid.EditIndex = e.NewEditIndex;
            RefreshData();
        }
        protected void GridView1_RowUpdating(object sender, System.Web.UI.WebControls.GridViewUpdateEventArgs e)
        {
            var updateurl = apibase + "UpdateCustomer";
            Label id = customergrid.Rows[e.RowIndex].FindControl("lbl_ID") as Label;
            TextBox name = customergrid.Rows[e.RowIndex].FindControl("txt_Name") as TextBox;
            TextBox city = customergrid.Rows[e.RowIndex].FindControl("txt_City") as TextBox;
            TextBox address = customergrid.Rows[e.RowIndex].FindControl("txt_Address") as TextBox;
            TextBox mobile = customergrid.Rows[e.RowIndex].FindControl("txt_Mobile") as TextBox;

            Customer customer = new Customer()
            {
                Id = Convert.ToInt32(id.Text),
                Name = name.Text,
                Address = address.Text,
                Mobile = mobile.Text
            };

            StringContent queryString = new StringContent(Newtonsoft.Json.JsonConvert.SerializeObject(customer), System.Text.Encoding.UTF8, "application/json");
            HttpResponseMessage response = HttpClient.PostAsync(updateurl, queryString).Result;
            customergrid.EditIndex = -1;
            RefreshData();
        }

        protected void GridView1_RowCancelingEdit(object sender, System.Web.UI.WebControls.GridViewCancelEditEventArgs e)
        {
            customergrid.EditIndex = -1;
            RefreshData();
        }
        void RefreshData()
        {
            var httpResponse = HttpClient.GetAsync("getAllCustomer").Result;
            var data = httpResponse.Content.ReadAsAsync<List<Customer>>().Result;
            customergrid.DataSource = data;
            customergrid.DataBind();
        }

        protected void customergrid_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            Label id = customergrid.Rows[e.RowIndex].FindControl("lbl_ID") as Label;
            var updateurl = $"{apibase}DeleteCustomer\\{id.Text}";
            StringContent queryString = new StringContent(Newtonsoft.Json.JsonConvert.SerializeObject(id.Text), System.Text.Encoding.UTF8, "application/json");
            HttpResponseMessage response = HttpClient.PostAsync(updateurl, queryString).Result;
            RefreshData();
        }
    }
}