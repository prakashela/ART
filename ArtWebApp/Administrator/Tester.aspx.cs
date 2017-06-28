﻿using ArtWebApp.DataModelAtcWorld;
using ArtWebApp.DataModels;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ArtWebApp.Administrator
{
    public partial class Tester : System.Web.UI.Page
    {
      
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            doactionSizetransfer();
        }



        public  void doactionSizetransfer()
        {

            DataTable Sizeonart = GetArtData();
            DataTable sizeonAtcwold = GetAtcWorldData();

            for (int i = 0; i < Sizeonart.Rows.Count; i++)
            {
                int stylesizeid = int.Parse(Sizeonart.Rows[i]["StyleSizeID"].ToString());
                string ourstyleid = Sizeonart.Rows[i]["OurStyleID"].ToString().Trim();
                string OurStyle = Sizeonart.Rows[i]["OurStyle"].ToString().Trim();
                string SizeName = Sizeonart.Rows[i]["SizeName"].ToString().Trim();
                string SizeCode = Sizeonart.Rows[i]["SizeCode"].ToString().Trim();
                string AtcId = Sizeonart.Rows[i]["AtcId"].ToString().Trim();
                string Orderof = Sizeonart.Rows[i]["Orderof"].ToString().Trim();
                try
                {
                    DataTable newresult = sizeonAtcwold.Select("StyleSizeID=" + stylesizeid.ToString()).CopyToDataTable();
                                    


                  

                    if (newresult.Rows.Count != 0)
                    {

                        string atcwordourstyleid = newresult.Rows[0]["StyleSizeID"].ToString().Trim();
                        string atcwordOurStyle = newresult.Rows[0]["OurStyle"].ToString().Trim();
                        string atcwordSizeName = newresult.Rows[0]["SizeName"].ToString().Trim();
                        string atcwordSizeCode = newresult.Rows[0]["SizeCode"].ToString().Trim();
                        string atcwordAtcId = newresult.Rows[0]["AtcId"].ToString().Trim();
                        string atcwordOrderof = newresult.Rows[0]["Orderof"].ToString().Trim();
                        if (ourstyleid== atcwordourstyleid && OurStyle== atcwordOurStyle && SizeName == atcwordSizeName && SizeCode == atcwordSizeCode && AtcId == atcwordAtcId && Orderof == atcwordOrderof)
                        {
                            using (AtcWorldEntities enty = new ArtWebApp.DataModelAtcWorld.AtcWorldEntities())
                            {
                                var q = from stymstr in enty.StyleSizeMasters
                                        where stymstr.StyleSizeID == stylesizeid
                                        select stymstr;
                                foreach(var element in q)
                                {
                                    element.OurStyle = OurStyle.ToString();
                                    element.OurStyleID = int.Parse(ourstyleid.ToString());
                                 

                                    element.SizeName = SizeName;
                                    element.SizeCode = SizeCode;
                                    element.AtcId = int.Parse(AtcId.ToString());
                                    element.Orderof = int.Parse(Orderof.ToString());
                                }

                                enty.SaveChanges();
                            }

                            }
                        else
                        {

                        }
                    }
                }
                catch (Exception)
                {
                    using (AtcWorldEntities enty = new ArtWebApp.DataModelAtcWorld.AtcWorldEntities())
                    {
                        if (!enty.StyleSizeMasters.Any(f => f.StyleSizeID == stylesizeid))
                        {
                            StyleSizeMaster stsz = new StyleSizeMaster();
                            stsz.OurStyleID = int.Parse(ourstyleid.ToString());
                            stsz.OurStyle = OurStyle.ToString();
                            stsz.StyleSizeID = stylesizeid;


                            stsz.SizeName = SizeName;
                            stsz.SizeCode = SizeCode;
                            stsz.AtcId = int.Parse(AtcId.ToString());
                            stsz.Orderof = int.Parse(Orderof.ToString());
                            enty.StyleSizeMasters.Add(stsz);
                           
                        }
                        else
                        {
                          
                        }


                        enty.SaveChanges();
                    }

                }
            }

        }



        public DataTable  GetAtcWorldData()
        {


            DateTime today = DateTime.Now.Date;
            DataTable datafromart = new DataTable();

            String Datepend = "";
                     
                String q3 = @"SELECT   StyleSizeMasterID,StyleSizeID, AtcId, OurStyle, OurStyleID, SizeName, SizeCode, isnull(Orderof, 0)  as Orderof
FROM StyleSizeMaster";



                //  cmd.CommandText = Query1;
     
            



           
            return  ReturnQueryResultDatatablefromAtcWorld(q3);
        }




        public DataTable GetArtData()
        {


            DateTime today = DateTime.Now.Date;
            DataTable datafromart = new DataTable();

          
          
              
              


                String q3 = @"SELECT        StyleSizeID, AtcId, OurStyle, OurStyleID, SizeName, SizeCode, isnull(Orderof, 0) as Orderof
FROM StyleSize";



                //  cmd.CommandText = Query1;
             

        return ReturnQueryResultDatatablefromArt(q3);



            
         
        }



        public  DataTable ReturnQueryResultDatatablefromArt(String Qry)
        {
            DataTable dt = new DataTable();
            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ArtConnectionString"].ConnectionString.ToString()))
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.CommandText = Qry;
                    cmd.CommandType = CommandType.Text;
                    cmd.Connection = con;
                    con.Open();

                    SqlDataReader rdr = cmd.ExecuteReader();

                    dt.Load(rdr);
                }
            }

            return dt;
        }

        public DataTable ReturnQueryResultDatatablefromAtcWorld(String Qry)
        {
            DataTable dt = new DataTable();
            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["AtcWorldConnectionString"].ConnectionString.ToString()))
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.CommandText = Qry;
                    cmd.CommandType = CommandType.Text;
                    cmd.Connection = con;
                    con.Open();

                    SqlDataReader rdr = cmd.ExecuteReader();

                    dt.Load(rdr);
                }
            }

            return dt;
        }










        #region EthiopiashipmentDO
        protected void btn_getethoipiadata_Click(object sender, EventArgs e)
        {
            DoActionTransferShipmentData();
        }

        /// <summary>
        /// Get the shipment document of Ethiopia in Main ATCWorldToArtShipData
        /// </summary>
        public DataTable GetArtDatafromMaintableforEthioipia()
        {


            DateTime today = DateTime.Now.Date;
            DataTable datafromart = new DataTable();







            String q3 = @"SELECT        ArtLocation_PK, SDONo, PoPack_Detail_PK, ShipQty, Country, PLID
FROM            ATCWorldToArtShipData
WHERE        (Country like 'Ethiopia')";



            //  cmd.CommandText = Query1;


            return ReturnQueryResultDatatablefromArt(q3);





        }


        /// <summary>
        /// Get the shipment document of Ethiopia in Main EthiopiaToARTShip_Tbl
        /// this will be now inserted in the new table
        /// </summary>
        /// <returns></returns>

        public DataTable GetEthipioadatafromEthipiaTable()
        {


            DateTime today = DateTime.Now.Date;
            DataTable datafromart = new DataTable();







            String q3 = @"SELECT        ArtLocation_PK, SDONo, PoPack_Detail_PK, ShipQty, Country, PLID
FROM            EthiopiaToARTShip_Tbl";



            //  cmd.CommandText = Query1;


            return ReturnQueryResultDatatablefromArt(q3);





        }






        public void DoActionTransferShipmentData()
        {
            // get the Ethiopia data from the main table
            DataTable Shipmentdoonart = GetArtDatafromMaintableforEthioipia();


            //get all data from the table for ethipia(sub)
            DataTable shipmentonEthiopia = GetEthipioadatafromEthipiaTable();

            for (int i = 0; i < shipmentonEthiopia.Rows.Count; i++)
            {
                int ArtLocation_PK = int.Parse(shipmentonEthiopia.Rows[i]["ArtLocation_PK"].ToString());
                int PoPack_Detail_PK = int.Parse(shipmentonEthiopia.Rows[i]["PoPack_Detail_PK"].ToString().Trim());
                string SDONo = shipmentonEthiopia.Rows[i]["SDONo"].ToString();
                int PLID = int.Parse(shipmentonEthiopia.Rows[i]["PLID"].ToString().Trim());
                Decimal ShipQty = Decimal.Parse(shipmentonEthiopia.Rows[i]["ShipQty"].ToString());
              
              
                try
                {

                    //check all the data on the shipment to ethiopia
                    DataTable newresult = Shipmentdoonart.Select("PoPack_Detail_PK=" + PoPack_Detail_PK.ToString()+ " && SDONo='" + SDONo+ "' && ArtLocation_PK= " + ArtLocation_PK+ "").CopyToDataTable();



                 
                 

                    if (newresult.Rows.Count != 0)
                    
                    {

                        int atcwordArtLocation_PK = int.Parse(newresult.Rows[0]["ArtLocation_PK"].ToString().Trim());
                        int atcwordPoPack_Detail_PK = int.Parse(newresult.Rows[0]["PoPack_Detail_PK"].ToString().Trim());
                        string atcwordSDONo = newresult.Rows[0]["SDONo"].ToString().Trim();
                        int atcwordPLID = int.Parse(newresult.Rows[0]["PLID"].ToString().Trim());
                        Decimal atcwordShipQty = Decimal.Parse(newresult.Rows[0]["ShipQty"].ToString().Trim());
                        if (ArtLocation_PK == atcwordArtLocation_PK && PoPack_Detail_PK == atcwordPoPack_Detail_PK && SDONo == atcwordSDONo && PLID == atcwordPLID && ShipQty == atcwordShipQty )
                        {
                          // if everything match donot do anything

                        }
                        else
                        {

                            // else call the item and update it 

                        }
                    }
                }
                catch (Exception)
                {
                    using (ArtEntitiesnew enty = new ArtEntitiesnew())
                    {

                        var q = (from shpethiopia in enty.EthiopiaToARTShip_Tbl
                                 where shpethiopia.ArtLocation_PK == ArtLocation_PK && shpethiopia.SDONo == SDONo && shpethiopia.PoPack_Detail_PK == PoPack_Detail_PK
                                 select shpethiopia).ToList();

                        foreach(var element in q)
                        {

                            if (!enty.ATCWorldToArtShipDatas.Any(f => f.ArtLocation_PK == ArtLocation_PK && f.SDONo == SDONo && f.PoPack_Detail_PK == PoPack_Detail_PK))
                            {

                                ATCWorldToArtShipData atcshpdata = new ATCWorldToArtShipData();

                                atcshpdata.ArtLocation_PK = element.ArtLocation_PK;
                                atcshpdata.ATCWorldLocation_PK = element.ATCWorldLocation_PK;
                                atcshpdata.LocationName = element.LocationName;
                                atcshpdata.PackingIns = element.PackingIns;
                                atcshpdata.SDONo = element.SDONo;
                                atcshpdata.Mode = element.Mode;
                                atcshpdata.PLID = element.PLID;
                                atcshpdata.ShipmentDate = element.ShipmentDate;
                                atcshpdata.HandOverDate = element.HandOverDate;
                                atcshpdata.BuyerID = element.BuyerID;
                                atcshpdata.Atc_Id = element.Atc_Id;
                                atcshpdata.Season_PK = element.Season_PK;
                                atcshpdata.OurStyleId = element.OurStyleId;
                                atcshpdata.BuyerStyle = element.BuyerStyle;
                                atcshpdata.CategoryID = element.CategoryID;
                                atcshpdata.POPackID = element.POPackID;
                                atcshpdata.PoPack_Detail_PK = element.PoPack_Detail_PK;
                                atcshpdata.ColorID = element.ColorID;
                                atcshpdata.SizeID = element.SizeID;
                                atcshpdata.Totalcarton = element.Totalcarton;
                                atcshpdata.ShipQty = element.ShipQty;
                                atcshpdata.IsBooked = element.IsBooked;
                                atcshpdata.BookedDate = element.BookedDate;
                                atcshpdata.BookedBy = element.BookedBy;
                                atcshpdata.Country = "Ethiopia";
                                                           


                                enty.ATCWorldToArtShipDatas.Add(atcshpdata);

                            }
                            else
                            {

                            }

                        }




                        


                        enty.SaveChanges();
                    }

                }
            }

        }








        #endregion















    }
}