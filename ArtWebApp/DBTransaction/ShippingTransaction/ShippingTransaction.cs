﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace ArtWebApp.DBTransaction.ShippingTransaction
{
    public  static  class ShippingTransaction
    {
      static  String   connStr = ConfigurationManager.ConnectionStrings["ArtConnectionString"].ConnectionString;

        public static DataTable GetIncompletedShipmenthandover(int locPk)
        {
            DataTable dt = new DataTable();

            using (SqlConnection con = new SqlConnection(connStr))
            {
                con.Open();


                SqlCommand cmd = new SqlCommand(@"SELECT ShipmentHandMaster_PK, ShipmentHandOverCode, IsCompleted, Location_Pk
FROM ShipmentHandOverMaster
WHERE(Location_Pk = @Param1) AND (IsCompleted = N'N')", con);


                cmd.Parameters.AddWithValue("@Param1", locPk);

                SqlDataReader rdr = cmd.ExecuteReader();

                dt.Load(rdr);



            }
            return dt;
        }


        public static DataTable GetSDODataFromAtcWorld(String  Condition)
        {
            DataTable dt = new DataTable();

            using (SqlConnection con = new SqlConnection(connStr))
            {
                con.Open();


                SqlCommand cmd = new SqlCommand(@"SELECT       AtcDetails.OurStyleID, POPackDetails.POPackId,  AtcMaster.AtcNum, AtcDetails.OurStyle, AtcDetails.BuyerStyle, PoPackMaster.PoPacknum, PoPackMaster.BuyerPO, ATCWorldToArtShipData.SDONo, SUM(ATCWorldToArtShipData.ShipQty) AS ShipQty 
                        
FROM            POPackDetails INNER JOIN
                         PoPackMaster ON POPackDetails.POPackId = PoPackMaster.PoPackId INNER JOIN
                         ATCWorldToArtShipData ON POPackDetails.PoPack_Detail_PK = ATCWorldToArtShipData.PoPack_Detail_PK INNER JOIN
                         AtcDetails ON POPackDetails.OurStyleID = AtcDetails.OurStyleID INNER JOIN
                         AtcMaster ON AtcDetails.AtcId = AtcMaster.AtcId  
						"+ Condition + @"
  GROUP BY AtcMaster.AtcNum, AtcDetails.OurStyle, AtcDetails.BuyerStyle, PoPackMaster.PoPacknum, PoPackMaster.BuyerPO, ATCWorldToArtShipData.SDONo, AtcDetails.OurStyleID, POPackDetails.POPackId", con);



                SqlDataReader rdr = cmd.ExecuteReader();

                dt.Load(rdr);



            }
            return dt;
        }

    }
}