﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using ArtWebApp.DataModels;
using System.Collections;
using System.Diagnostics;
using System.Globalization;


namespace ArtWebApp.Merchandiser.PO
{
    public partial class POAppend : System.Web.UI.Page
    {
        DBTransaction.ProcurementTransaction potrans = new DBTransaction.ProcurementTransaction();
        DataTable dt = new DataTable();
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {
                dt = (DataTable)Session["ItemforPO"];
                tbl_Podetails.DataSource = dt;
                tbl_Podetails.DataBind();
                PoSource.DataBind();
                drp_po.DataBind();
                Upd_Main.Update();
                upd_detail.Update();
            }
            else
            {
                if (ScriptManager.GetCurrent(this.Page).IsInAsyncPostBack)
                {
                    // partial (asynchronous) postback occured
                    // insert Ajax custom logic here
                }
            }

        }






        protected void tbl_Podetails_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            DBTransaction.ProcurementTransaction pctrans = new DBTransaction.ProcurementTransaction();
            DropDownList ddl_supcolor = (e.Row.FindControl("ddl_Supcolor") as DropDownList);
            DropDownList ddl_supSize = (e.Row.FindControl("ddl_SupSize") as DropDownList);
            DropDownList ddl_altuom = (e.Row.FindControl("ddl_AltUOM") as DropDownList);
            Label uom = (e.Row.FindControl("lbl_UOMCode") as Label);



            try
            {
                // string itemcolor = (e.Row.FindControl("lbl_itemcolor") as Label).Text.Trim();

                DataTable AltUOMData = new DataTable();

                AltUOMData = pctrans.GetAltUOM(uom.Text.Trim());
                ddl_altuom.DataSource = AltUOMData;
                ddl_altuom.DataTextField = "UomCode";
                ddl_altuom.DataValueField = "Uom_PK";
                ddl_altuom.DataBind();
                ddl_altuom.Items.Insert(0, new System.Web.UI.WebControls.ListItem("Select AltUOM"));

                try
                {

                    ddl_altuom.Items.FindByText(uom.Text.Trim()).Selected = true;
                }
                catch (Exception)
                {
                    ddl_altuom.Items.FindByText("Select AltUOM").Selected = true;
                }


            }
            catch (Exception)
            {

            }







            try
            {
                string itemcolor = (e.Row.FindControl("lbl_itemcolor") as Label).Text.Trim();
                ddl_supcolor.Items.FindByText(itemcolor).Selected = true;
            }
            catch (Exception)
            {

            }
            try
            {
                string itemsize = (e.Row.FindControl("lbl_itemsize") as Label).Text.Trim();
                ddl_supSize.Items.FindByText(itemsize).Selected = true;
            }
            catch (Exception)
            {

            }
        }


        protected void Btn_submit_Click(object sender, EventArgs e)
        {
            if (validationdata())
            {
                String msg = InsertPodata();
                tbl_Podetails.DataSource = null;
                tbl_Podetails.DataBind();
                upd_detail.Update();
                updateStatus(msg);


            }
            else
            {
                updateStatus("Check Unit rate or Qty Exceed Allowed");
            }

        }





        public void updateStatus(String msg)
        {
            lbl_mssg.Text = msg;
            upd_label.Update();
        }



        /// <summary>
        /// Insert the PO master and PODetails
        /// </summary>
        /// <returns></returns>
        public String InsertPodata()
        {
            String ponum = "";

            BLL.MerchandsingBLL.ProcurementBLL.ProcurementMasterData POmstr = new BLL.MerchandsingBLL.ProcurementBLL.ProcurementMasterData();




            POmstr.PO_Pk = int.Parse(drp_po.SelectedValue.ToString());
            POmstr.ProcurementDetailsCollection = GetPODetailsData();
            ponum = POmstr.AddnewContenttoPO(POmstr);
            String Msg = "Supplier Po  Updated Successfully  Sucessfully";

            return Msg;
        }










        /// <summary>
        /// gets Podetails from gridview
        /// </summary>
        /// <returns></returns>

        public List<BLL.MerchandsingBLL.ProcurementBLL.ProcurementDetails> GetPODetailsData()
        {


            List<BLL.MerchandsingBLL.ProcurementBLL.ProcurementDetails> rk = new List<BLL.MerchandsingBLL.ProcurementBLL.ProcurementDetails>();
            for (int i = 0; i < tbl_Podetails.Rows.Count; i++)
            {
                int skudet_pk = int.Parse(((tbl_Podetails.Rows[i].FindControl("lbl_skudet_pk") as Label).Text.ToString()));
                int UOMpk = int.Parse(((tbl_Podetails.Rows[i].FindControl("lbl_uomPK") as Label).Text.ToString()));
                float unitrate = float.Parse((tbl_Podetails.Rows[i].FindControl("txt_unitrate") as TextBox).Text.ToString());
                decimal poqty = decimal.Parse(((tbl_Podetails.Rows[i].FindControl("txt_poQty") as TextBox).Text.ToString()));
                // converted usd rate
                float CURate = 0;
                try
                {
                    //CURate = unitrate / float.Parse(convfact.Value.ToString());
                    CURate = unitrate / float.Parse(ViewState["convfact"].ToString());
                }
                catch (Exception)
                {
                    CURate = unitrate;

                }


                String Suppliercolor = ((tbl_Podetails.Rows[i].FindControl("ddl_Supcolor") as DropDownList).SelectedItem.Text.Trim());

                String SupplierSize = ((tbl_Podetails.Rows[i].FindControl("ddl_SupSize") as DropDownList).SelectedItem.Text.Trim());

                try
                {
                    String ddl_altuom = ((tbl_Podetails.Rows[i].FindControl("ddl_AltUOM") as DropDownList).SelectedValue.ToString().Trim());

                    if (ddl_altuom.Trim() == "" || ddl_altuom.Trim() == "Select AltUOM")
                    {

                    }
                    else
                    {
                        UOMpk = int.Parse(ddl_altuom.ToString());
                    }
                }
                catch (Exception)
                {


                }

                BLL.MerchandsingBLL.ProcurementBLL.ProcurementDetails pddetails = new BLL.MerchandsingBLL.ProcurementBLL.ProcurementDetails();
                pddetails.SkuDet_PK = skudet_pk;
                pddetails.POQty = poqty;
                pddetails.POUnitRate = unitrate;
                pddetails.SupplierColor = Suppliercolor;
                pddetails.SupplierSize = SupplierSize;
                pddetails.Uom_PK = UOMpk;
                pddetails.CURate = CURate;


                rk.Add(pddetails);
            }




            return rk;


        }



        public float convdatagenerator(int currencypk)
        {
            float convvalue = 1;
            DBTransaction.ProcurementTransaction pctrans = new DBTransaction.ProcurementTransaction(); ;
            convvalue = potrans.Getconversionfact(currencypk);
            return convvalue;
        }


        public Boolean validationdata()
        {
            Boolean isok = false;
            if (checkallRowsforRateAndQty() == true)
            {
                isok = true;
            }
            else
            {
                isok = false;
            }
            return isok;
        }





        /// <summary>
        /// checks whether all the user entered Unit price is below the 
        /// allowed unit price
        /// </summary>
        /// <returns></returns>
        public Boolean checkallRowsforRateAndQty()
        {
            BLL.MerchandsingBLL.ProcurementBLL.ProcurementMasterData POmstr = new BLL.MerchandsingBLL.ProcurementBLL.ProcurementMasterData();
            Boolean israteok = true;
            for (int i = 0; i < tbl_Podetails.Rows.Count; i++)
            {
                GridViewRow currentRow = tbl_Podetails.Rows[i];

                //  ConvertDollorUnitPricetoSupplier(currentRow);

                DoUOMAndCurrencyConversionConversion(currentRow);

                if (!validationPriceandQty(currentRow))
                {
                    israteok = false;
                }

            }
            return israteok;
        }





        public Boolean validationPriceandQty(GridViewRow currentRow)
        {
            Boolean isunderlimit = false;
            TextBox txtunitrate = (currentRow.FindControl("txt_unitrate") as TextBox);
            Label Supplierunitrate = (currentRow.FindControl("lbl_supunitrate") as Label);
            TextBox txt_poQty = (currentRow.FindControl("txt_poQty") as TextBox);

            float pounitrate = float.Parse(txtunitrate.Text.ToString());
            float allowedunitrate = float.Parse(Supplierunitrate.Text.ToString());




            float balanceqtyinalt = float.Parse((currentRow.FindControl("lbl_BalQtyinALTUOM") as Label).Text.ToString());
            float orderqty = float.Parse(txt_poQty.Text.ToString());






            if (orderqty > balanceqtyinalt)
            {
                isunderlimit = false;
                txt_poQty.BackColor = System.Drawing.ColorTranslator.FromHtml("#F2F0E1");
                lbl_mssg.Text = "PO Qty exceed bal qty";
            }
            else if (pounitrate > allowedunitrate)
            {
                isunderlimit = false;
                txtunitrate.BackColor = System.Drawing.ColorTranslator.FromHtml("#F2F0E1");
            }
            else
            {
                isunderlimit = true;
            }

            return isunderlimit;
        }





        public void DoUOMAndCurrencyConversionConversion(GridViewRow currentRow)
        {

            BLL.MerchandsingBLL.ProcurementBLL.ProcurementMasterData POmstr = new BLL.MerchandsingBLL.ProcurementBLL.ProcurementMasterData();
            float cuunitrate = float.Parse((currentRow.FindControl("lbl_costunitrate") as Label).Text.ToString());

            int CurrencyPk = 18;
            String CurrencyCode = "USD";
            try
            {
                CurrencyPk = int.Parse(drp_currency.SelectedValue.ToString());
                CurrencyCode = drp_currency.SelectedItem.Text.ToString();
            }
            catch (Exception)
            {

                updateStatus("Select Currency");
            }

            int baseuompk = int.Parse((currentRow.FindControl("lbl_uomPK") as Label).Text.ToString());
            float basebalanceqty = float.Parse((currentRow.FindControl("lbl_balqty") as Label).Text.ToString());
            int altuompk = 0;
            try
            {
                altuompk = int.Parse((currentRow.FindControl("ddl_AltUOM") as DropDownList).SelectedValue.ToString());
            }
            catch (Exception)
            {

                altuompk = baseuompk;
            }


            ArrayList QtyandPrice = POmstr.ConvertCurrencyAndUOM(baseuompk, altuompk, basebalanceqty, cuunitrate, CurrencyCode, CurrencyPk);


            (currentRow.FindControl("lbl_BalQtyinALTUOM") as Label).Text = QtyandPrice[0].ToString();


            (currentRow.FindControl("lbl_supunitrate") as Label).Text = QtyandPrice[1].ToString();


            //(currentRow.FindControl("txt_unitrate") as TextBox).Text = QtyandPrice[1].ToString();
            //(currentRow.FindControl("txt_poQty") as TextBox).Text = QtyandPrice[0].ToString();









            updateRowUpdatepanels(currentRow);
            //  upd_detail.Update();

        }




        public void updateRowUpdatepanels(GridViewRow currentRow)
        {
            UpdatePanel upd_lbl_supunitrate = (currentRow.FindControl("upd_lbl_supunitrate") as UpdatePanel);
            UpdatePanel Upd_txt_unitrate = (currentRow.FindControl("Upd_txt_unitrate") as UpdatePanel);
            UpdatePanel Upd_lbl_BalQtyinALTUOM = (currentRow.FindControl("Upd_lbl_BalQtyinALTUOM") as UpdatePanel);

            UpdatePanel Upd_txt_poQty = (currentRow.FindControl("Upd_txt_poQty") as UpdatePanel);



            upd_lbl_supunitrate.Update();
            Upd_txt_unitrate.Update();
            Upd_lbl_BalQtyinALTUOM.Update();
            Upd_txt_poQty.Update();


        }









        protected void ddl_AltUOM_SelectedIndexChanged(object sender, EventArgs e)
        {
            DropDownList ddluom = (DropDownList)sender;


            GridViewRow currentRow = ddluom.ClosestContainer<GridViewRow>();
            if (currentRow != null)
            {
                DoUOMAndCurrencyConversionConversion(currentRow);
                (currentRow.FindControl("txt_unitrate") as TextBox).Text = (currentRow.FindControl("lbl_supunitrate") as Label).Text;
                (currentRow.FindControl("txt_poQty") as TextBox).Text = (currentRow.FindControl("lbl_BalQtyinALTUOM") as Label).Text;


                UpdatePanel Upd_txt_unitrate = (currentRow.FindControl("Upd_txt_unitrate") as UpdatePanel);


                UpdatePanel Upd_txt_poQty = (currentRow.FindControl("Upd_txt_poQty") as UpdatePanel);

                Upd_txt_unitrate.Update();
                Upd_txt_poQty.Update();



            }




        }

        protected void txt_unitrate_TextChanged(object sender, EventArgs e)
        {
            TextBox txtcons = (TextBox)sender;
            GridViewRow currentRow = txtcons.ClosestContainer<GridViewRow>();

            DoUOMAndCurrencyConversionConversion(currentRow);
        }

        protected void txt_poQty_TextChanged(object sender, EventArgs e)
        {
            TextBox txtcons = (TextBox)sender;
            GridViewRow currentRow = txtcons.ClosestContainer<GridViewRow>();
            DoUOMAndCurrencyConversionConversion(currentRow);
        }



        protected void drp_currency_SelectedIndexChanged(object sender, EventArgs e)
        {
            checkallRowsforRateAndQty();

            ViewState["convfact"] = convfact.Value = (convdatagenerator(int.Parse(drp_currency.SelectedItem.Value.ToString()))).ToString();
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            int popk = int.Parse(drp_po.SelectedValue.ToString());
            int currencyid = 0;
            using (ArtEntitiesnew entry = new ArtEntitiesnew())
            {
                var prefix = entry.ProcurementMasters.Where(u => u.PO_Pk == popk).Select(u => u.CurrencyID).FirstOrDefault();
                currencyid = int.Parse(prefix.ToString());
                drp_currency.SelectedValue = currencyid.ToString();
                drp_currency.Enabled = false;
                upd_currency.Update();

            }
        }
    }
}