﻿using ArtWebApp.DataModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Collections;
using System.Data.SqlClient;

using System.Configuration;


namespace ArtWebApp.BLL
{
    public class PoPackMasterData
    {
        public int PoPackId { get; set; }
        public String  PoPacknum { get; set; }
        public int AtcId { get; set; }
        public String BuyerPO { get; set; }
        public String Atcnum { get; set; }
        public String PackingInstruction { get; set; }
        public DateTime DeliveryDate { get; set; }
        public DateTime Inhousedate { get; set; }
        public DateTime AddedDate { get; set; }
        public String AddedBy { get; set; }

        public String POGroup{ get; set; }
        public String POTag{ get; set; }
        public String seasonName { get; set; }
        public int ChannelID { get; set; }
        public int BuyerDestination_PK { get; set; }

        /// <summary>
        /// Insert PO Pack Details
        /// </summary>
        public String insertpopack(PoPackMasterData pomdata)
        {
            String ponum = "";
            using (ArtEntitiesnew enty = new ArtEntitiesnew())
            {
                PoPackMaster pomstr = new PoPackMaster();
                pomstr.AtcId = pomdata.AtcId;
                pomstr.BuyerPO = pomdata.BuyerPO.Trim ();
                pomstr.DeliveryDate = pomdata.DeliveryDate;
                pomstr.Inhousedate = pomdata.Inhousedate;
                pomstr.PoPacknum = CreatePoPacknum(pomdata.AtcId, pomdata.Atcnum);
                ponum=pomstr.PoPacknum ;
                pomstr.ChannelID = pomdata.ChannelID;
                pomstr.BuyerDestination_PK = pomdata.BuyerDestination_PK;
                pomstr.AddedBy = HttpContext.Current.Session["Username"].ToString().Trim();
                pomstr.AddedDate = DateTime.Now;
                pomstr.SeasonName = pomdata.seasonName;
                pomstr.PoGroup = pomdata.POGroup;
                pomstr.TagGroup = pomdata.POTag;
                enty.PoPackMasters.Add(pomstr);

                enty.SaveChanges();
            }
            return ponum;
            
        }

        /// <summary>
        /// create the POPacknumber 
        /// </summary>
        /// <param name="atcid"></param>
        /// <param name="buyerid"></param>
        public String CreatePoPacknum(int atcid, String Atcnum)
        {
            String POPAcknum = "";
            using (ArtEntitiesnew enty = new ArtEntitiesnew())
            {
                var count = (from o in enty.PoPackMasters
                             where o.AtcId == atcid
                             select o).Count();


                POPAcknum = Atcnum.Trim() + "-" + (int.Parse(count.ToString()) + 1).ToString();
            }

            return POPAcknum;
        }



        public DataTable createdatatable(int ourstyleid,int popackid)
        {
            DataTable dt = new DataTable();
            int i = 0;
            dt.Columns.Add("Color", typeof(String));
            using (ArtEntitiesnew enty = new ArtEntitiesnew())
            {


                var sizedetails = (from size in enty.StyleSizes
                                   where size.OurStyleID == ourstyleid
                                   select new
                                   {
                                       size.SizeName
                                   }).Distinct();

                foreach (var sizedet in sizedetails)
                {
                    dt.Columns.Add(sizedet.SizeName.Trim(), typeof(String));
                }





                var Colordetails = (from color in enty.StyleColors
                                    where color.OurStyleID == ourstyleid
                                    select new
                                    {
                                        color.GarmentColor
                                    }).Distinct();

                foreach (var colordet in Colordetails)
                {
                    dt.Rows.Add();
                    dt.Rows[i]["Color"] = colordet.GarmentColor;
                    i++;


                }


                if (dt != null)
                {

                    var popackdetail = (from popackdetails in enty.POPackDetails
                                        where popackdetails.OurStyleID == ourstyleid && popackdetails.POPackId == popackid
                                        group popackdetails by new { popackdetails.ColorName, popackdetails.SizeName } into grp

                                        select new
                                        {
                                            grp.Key.ColorName,
                                            grp.Key.SizeName,


                                            Quantity = grp.Sum(popackdetails => popackdetails.PoQty)
                                            
                                        }).ToList();

                    if (dt.Rows.Count >= 1 )
                    {


                        for (int rowcount = 0; rowcount < dt.Rows.Count; rowcount++)
                        {
                            String Colorname = dt.Rows[rowcount]["Color"].ToString().Trim();
                            for (int coloumncount = 1; coloumncount < dt.Columns.Count; coloumncount++)
                            {
                                String Sizename = dt.Columns[coloumncount].ColumnName.ToString().Trim();

                               
                                var styleqty = popackdetail.Where(u => u.ColorName == Colorname && u.SizeName == Sizename).Select(u => u.Quantity ?? 0).Sum();
                                dt.Rows[rowcount][coloumncount] = styleqty;

                            }

                        }

                    }

                }



            }


            return addColumntotal(dt);

        //    return dt;
        }











        public DataTable addColumntotal(DataTable dt)
        {
            dt.Columns.Add("ColorTotal", typeof(String));

            for ( int i=0;i<dt.Rows.Count;i++)
            {
                float rowsum = 0;

                for(int j=1;j<dt.Columns.Count-1;j++)
                {

                    rowsum = rowsum + float.Parse(dt.Rows[i][j].ToString());
                   
                }

                dt.Rows[i]["ColorTotal"] = rowsum.ToString();
            }





            return addRowtotal(dt);
        }


        public DataTable addRowtotal(DataTable dt)
        {
            DataRow row1 = dt.NewRow();
            row1[0] = "SizeTotal";
            for (int i = 1; i < dt.Columns.Count; i++)
            {
                row1[i] = 0;
            }

            dt.Rows.Add(row1);



            for (int j = 1; j < dt.Columns.Count ; j++)
                {
                float colsum = 0;
                for (int i = 0; i < dt.Rows.Count-1; i++)
                {
                    colsum = colsum + float.Parse(dt.Rows[i][j].ToString());

                }
                dt.Rows[dt.Rows.Count - 1][j] = colsum.ToString();
            }

              
            





            return dt;
        }





        public void updatePOpAck(PoPackMasterData pomdata)
        {


            using (ArtEntitiesnew enty = new ArtEntitiesnew())
            {




                var queryselecct = from pkmstr in enty.PoPackMasters
                                   where pkmstr.PoPackId == pomdata.PoPackId
                                   select pkmstr;




                foreach (var pomstr in queryselecct)
                {


                    pomstr.BuyerPO = pomdata.BuyerPO.Trim();
                    pomstr.DeliveryDate = pomdata.DeliveryDate;
                    pomstr.Inhousedate = pomdata.Inhousedate;
                    pomstr.ChannelID = pomdata.ChannelID;
                    pomstr.BuyerDestination_PK = pomdata.BuyerDestination_PK;
                    pomstr.AddedBy = HttpContext.Current.Session["Username"].ToString().Trim();
                    pomstr.PackingInstruction = pomdata.PackingInstruction;
                    pomstr.PoGroup = pomdata.POGroup;
                    pomstr.TagGroup = pomdata.POTag;
                    pomstr.SeasonName = pomdata.seasonName;
                }




                enty.SaveChanges();


            }




        }



        public DataTable GetAllPOPackData(int atcid)
        {
            DataTable dt = new DataTable();
        
           

            DBTransaction.PoPackTransaction pktrans= new DBTransaction.PoPackTransaction ();
            dt = pktrans.GetAllBuyerPoPack(atcid);



            return dt;
        }




        public DataTable  GetPOPACKDetailsofList( ArrayList Popackdetlist)
        {
            DataTable dt= new DataTable() ;
            string condition = "where";

            for(int i=0;i<Popackdetlist.Count;i++)
            {
               if(i==0)
               {
                   condition = condition + " PoPackMaster.PoPackId=" + Popackdetlist[i].ToString().Trim();
               }
               else
               {
                   condition = condition + "  or PoPackMaster.PoPackId=" + Popackdetlist[i].ToString().Trim();
               }
                   
               

            }

            if (condition != "where")
            {
                String query = @"SELECT        PoPackMaster.PoPackId, PoPackMaster.BuyerPO + ' / ' + PoPackMaster.PoPacknum AS POnum, AtcDetails.OurStyle,AtcDetails.OurStyleID ,
AtcMaster.AtcNum, isnulL(SUM(POPackDetails.PoQty),0) AS POQTY,(
SELECT        TOP (1) ISNULL(StyleCostingComponentDetails.CompValue, 0) 
FROM            StyleCostingMaster INNER JOIN
                         StyleCostingComponentDetails ON StyleCostingMaster.Costing_PK = StyleCostingComponentDetails.Costing_PK INNER JOIN
                         CostingComponentMaster ON StyleCostingComponentDetails.CostComp_PK = CostingComponentMaster.CostComp_PK
WHERE        (CostingComponentMaster.ComponentName = N'CM') AND (StyleCostingMaster.OurStyleID = AtcDetails.OurStyleID) AND  (StyleCostingMaster.IsApproved = N'A')) as Apprcm,isnull((						 
						 SELECT        JobContractMaster.JOBContractNUM
FROM            JobContractMaster INNER JOIN
                         JobContractDetail ON JobContractMaster.JobContract_pk = JobContractDetail.JobContract_pk
WHERE        (JobContractDetail.PoPackID = PoPackMaster.PoPackId) AND (JobContractDetail.OurStyleID = AtcDetails.OurStyleID )),'NA') as JOBCONTRACT
FROM            PoPackMaster INNER JOIN
                         POPackDetails ON PoPackMaster.PoPackId = POPackDetails.POPackId INNER JOIN
                         AtcDetails ON POPackDetails.OurStyleID = AtcDetails.OurStyleID INNER JOIN
                         AtcMaster ON PoPackMaster.AtcId = AtcMaster.AtcId " + condition + " GROUP BY PoPackMaster.BuyerPO + ' / ' + PoPackMaster.PoPacknum, PoPackMaster.PoPackId, AtcDetails.OurStyle, AtcDetails.OurStyleID,AtcMaster.AtcNum";
                DBTransaction.PoPackTransaction pktrans = new DBTransaction.PoPackTransaction();
                dt = pktrans.getPodetails(query);
            }
            return dt;
            
            }
      

        

    }






    public class POPackDetailData
    {


        public DataTable POPackdetcollection { get; set; }
        public List<POPackGDitems> POPackGDitemsDataCollection { get; set; }

        public int PoPackId { get; set; }
        public int Ourstyleid { get; set; }

        public int sizeid { get; set; }
        public int coloid { get; set; }

        public String Colorname { get; set; }

        public String Sizename { get; set; }
        public String AddedBy { get; set; }
        public String AddedDate { get; set; }
        public Decimal Poqty { get; set; }

        public String Colorcode { get; set; }
        public String Sizecode { get; set; }

        public String getColorcode(string Colorname)
        {


            var colorcode = "";
            using (ArtEntitiesnew enty = new ArtEntitiesnew())
            {
                colorcode = enty.ColorMasters.Where(u => u.ColorName == Colorname).Select(u => u.ColorCode).FirstOrDefault();
            }
            return colorcode.ToString();
        }



        public int getColorID(string Colorname)
        {


            var colorcode = "";
            using (ArtEntitiesnew enty = new ArtEntitiesnew())
            {
                colorcode = enty.ColorMasters.Where(u => u.ColorName == Colorname).Select(u => u.ColorId).Single().ToString();
            }
            return int.Parse(colorcode.ToString());
        }





        public int getSizeID(string sizename)
        {

            var Sizecode = "";
            using (ArtEntitiesnew enty = new ArtEntitiesnew())
            {
                Sizecode = enty.SizeMasters.Where(u => u.SizeName == sizename).Select(u => u.SizeID).FirstOrDefault().ToString();
            }
            return int.Parse(Sizecode.ToString());


        }

        public String getSizecode(string sizename)
        {

            var Sizecode = "";
            using (ArtEntitiesnew enty = new ArtEntitiesnew())
            {
                Sizecode = enty.SizeMasters.Where(u => u.SizeName == sizename).Select(u => u.SizeCode).FirstOrDefault();
            }
            return Sizecode.ToString();


        }

        public String Addeddate { get; set; }

        /// <summary>
        /// Insert the PO Pack details
        /// </summary>
        /// <param name="popackdata"></param>
        public void insertPOPackDetails(POPackDetailData popackdata)
        {
            DataTable podet = popackdata.POPackdetcollection;
            for (int i = 0; i < podet.Rows.Count - 1; i++)
            {
                for (int j = 1; j < podet.Columns.Count - 1; j++)
                {

                    POPackDetailData newpopackdetdata = new POPackDetailData();
                    newpopackdetdata.Ourstyleid = popackdata.Ourstyleid;
                    newpopackdetdata.PoPackId = popackdata.PoPackId;
                    newpopackdetdata.Colorname = podet.Rows[i]["Color"].ToString().Trim();
                    newpopackdetdata.Sizename = podet.Columns[j].ColumnName.ToString().Trim();
                    newpopackdetdata.Poqty = decimal.Parse(podet.Rows[i][j].ToString());
                    newpopackdetdata.Sizecode = getSizecode(newpopackdetdata.Sizename).Trim();
                    newpopackdetdata.Colorcode = getColorcode(newpopackdetdata.Colorname).Trim();
                    newpopackdetdata.sizeid = getSizeID(newpopackdetdata.Sizename);
                    newpopackdetdata.coloid = getColorID(newpopackdetdata.Colorname);

                    using (ArtEntitiesnew enty = new ArtEntitiesnew())
                    {
                        if (!enty.POPackDetails.Any(f => f.OurStyleID == newpopackdetdata.Ourstyleid && f.SizeName.Trim() == newpopackdetdata.Sizename && f.ColorName.Trim() == newpopackdetdata.Colorname.Trim() && f.POPackId == newpopackdetdata.PoPackId))
                        {
                            if (newpopackdetdata.Poqty > 0)
                            {
                                POPackDetail pcpkdet = new POPackDetail();
                                pcpkdet.OurStyleID = newpopackdetdata.Ourstyleid;
                                pcpkdet.POPackId = newpopackdetdata.PoPackId;
                                pcpkdet.SIzeCode = newpopackdetdata.Sizecode;
                                pcpkdet.SizeName = newpopackdetdata.Sizename;
                                pcpkdet.ColorCode = newpopackdetdata.Colorcode;
                                pcpkdet.ColorName = newpopackdetdata.Colorname;
                                pcpkdet.ColorId = newpopackdetdata.coloid; 
                                pcpkdet.SizeID= newpopackdetdata.sizeid;
                                pcpkdet.PoQty = newpopackdetdata.Poqty;
                                pcpkdet.IsCutable = "N";
                                pcpkdet.AddedBy = HttpContext.Current.Session["Username"].ToString().Trim();
                                pcpkdet.AddedDate = DateTime.Now;
                                enty.POPackDetails.Add(pcpkdet);
                            }

                        }
                        else
                        {

                            var q = from popackdata123 in enty.POPackDetails
                                    where popackdata123.OurStyleID == newpopackdetdata.Ourstyleid &&
                                    popackdata123.SizeName.Trim() == newpopackdetdata.Sizename
                                    && popackdata123.ColorName.Trim() == newpopackdetdata.Colorname.Trim()
                                    && popackdata123.POPackId == newpopackdetdata.PoPackId
                                    select popackdata123;


                            foreach (var element in q)
                            {
                                element.PoQty = newpopackdetdata.Poqty;
                            }



                        }

                        enty.SaveChanges();
                    }
                }


            }

        }


        public void MarkASQCutable(Boolean iscutable)
        {



            using (ArtEntitiesnew enty = new ArtEntitiesnew())
            {

                var q = from ppc in enty.POPackDetails
                        where ppc.OurStyleID == this.Ourstyleid && ppc.POPackId == this.PoPackId
                        select ppc;
                foreach (var element in q)
                {
                    if (iscutable)
                    {
                        element.IsCutable = "Y";
                    }
                    else
                    {
                        element.IsCutable = "N";
                    }

                }
                enty.SaveChanges();
            }



        }

        public void MarkASQPackable(Boolean ispackable)
        {



            using (ArtEntitiesnew enty = new ArtEntitiesnew())
            {

                var q = from ppc in enty.POPackDetails
                        where ppc.OurStyleID == this.Ourstyleid && ppc.POPackId == this.PoPackId
                        select ppc;
                foreach (var element in q)
                {
                    if (ispackable)
                    {
                        element.IsPackable = "Y";
                    }
                    else
                    {
                        element.IsPackable = "N";
                    }

                }
                enty.SaveChanges();
            }



        }


    }

    public class POPackGDitems
    {
        public int PoPackId { get; set; }
        public int Ourstyleid { get; set; }

        public int skuPK { get; set; }


        public void InsertPoPackGDitems()
        {
            using (ArtEntitiesnew enty = new ArtEntitiesnew())
            {

                if (!enty.GroupDependantItems.Any(f => f.OurStyleID == this.Ourstyleid && f.POPackID == this.PoPackId && f.Sku_PK == this.skuPK))
                {
                    GroupDependantItem cddetail = new GroupDependantItem();
                    cddetail.OurStyleID = this.Ourstyleid;
                    cddetail.POPackID = this.PoPackId;
                    cddetail.Sku_PK = this.skuPK;
                    cddetail.IsDepenant = "Y";
                    enty.GroupDependantItems.Add(cddetail);
                    enty.SaveChanges();
                }

            }



        }
        public void RemovePoPackGDitems()
        {
            using (ArtEntitiesnew enty = new ArtEntitiesnew())
            {

                var q = from gditems in enty.GroupDependantItems
                        where gditems.OurStyleID == this.Ourstyleid && gditems.POPackID == this.PoPackId && gditems.Sku_PK == this.skuPK
                        select gditems;
                foreach (var element in q)
                {
                    element.IsDepenant = "N";
                }
                enty.SaveChanges();
                //if (!enty.GroupDependantItems.Any(f => f.OurStyleID == this.Ourstyleid && f.POPackID == this.PoPackId && f.Sku_PK == this.skuPK))
                //{
                //    GroupDependantItem cddetail = new GroupDependantItem();
                //    cddetail.OurStyleID = this.Ourstyleid;
                //    cddetail.POPackID = this.PoPackId;
                //    cddetail.Sku_PK = this.skuPK;

                //    enty.GroupDependantItems.Add(cddetail);
                //    
                //}

            }



        }

        public void CheckCheckbox(System.Web.UI.WebControls.CheckBoxList chklist, int popackid, int ourstyleid)
        {
            using (ArtEntitiesnew enty = new ArtEntitiesnew())
            {
                var q = from asqitem in enty.GroupDependantItems
                        where asqitem.POPackID == popackid && asqitem.OurStyleID == ourstyleid && asqitem.IsDepenant=="Y"
                        select asqitem;
                foreach (var element in q)
                {
                    foreach (System.Web.UI.WebControls.ListItem item in chklist.Items)
                    {
                        if (item.Value.ToString().Trim() == element.Sku_PK.ToString().Trim())
                        {
                            item.Selected = true;
                        }
                    }

                }


            }
        }
    }
    public static class popackupdater
    {
        static String connStr = ConfigurationManager.ConnectionStrings["ArtConnectionString"].ConnectionString;


        /// <summary>
        /// Requery the database to get the size color asq matrix
        /// </summary>
        /// <param name="ourstyleid"></param>
        /// <param name="popackid"></param>
        /// <returns></returns>
        public static DataTable createdatatable(int ourstyleid, int popackid)
        {
            DataTable dt = new DataTable();
            int i = 0;
            dt.Columns.Add("Color", typeof(String));
            using (ArtEntitiesnew enty = new ArtEntitiesnew())
            {


                var sizedetails = (from size in enty.StyleSizes
                                   where size.OurStyleID == ourstyleid
                                   select new
                                   {
                                       size.SizeName
                                   }).Distinct();

                foreach (var sizedet in sizedetails)
                {
                    dt.Columns.Add(sizedet.SizeName.Trim(), typeof(String));
                }





                var Colordetails = (from color in enty.StyleColors
                                    where color.OurStyleID == ourstyleid
                                    select new
                                    {
                                        color.GarmentColor
                                    }).Distinct();

                foreach (var colordet in Colordetails)
                {
                    dt.Rows.Add();
                    dt.Rows[i]["Color"] = colordet.GarmentColor;
                    i++;


                }


                if (dt != null)
                {

                    var popackdetail = (from popackdetails in enty.POPackDetails
                                        where popackdetails.OurStyleID == ourstyleid && popackdetails.POPackId == popackid
                                        group popackdetails by new { popackdetails.ColorName, popackdetails.SizeName } into grp

                                        select new
                                        {
                                            grp.Key.ColorName,
                                            grp.Key.SizeName,


                                            Quantity = grp.Sum(popackdetails => popackdetails.PoQty)

                                        }).ToList();

                    if (dt.Rows.Count >= 1)
                    {


                        for (int rowcount = 0; rowcount < dt.Rows.Count; rowcount++)
                        {
                            String Colorname = dt.Rows[rowcount]["Color"].ToString().Trim();
                            for (int coloumncount = 1; coloumncount < dt.Columns.Count; coloumncount++)
                            {
                                String Sizename = dt.Columns[coloumncount].ColumnName.ToString().Trim();


                                var styleqty = popackdetail.Where(u => u.ColorName == Colorname && u.SizeName == Sizename).Select(u => u.Quantity ?? 0).Sum();
                                dt.Rows[rowcount][coloumncount] = styleqty;

                            }

                        }

                    }

                }



            }




            return dt;
        }







        /// <summary>
        /// Requery the database to get the size color asq matrix
        /// </summary>
        /// <param name="ourstyleid"></param>
        /// <param name="popackid"></param>
        /// <returns></returns>
        public static DataTable createdatatable(int ourstyleid)
        {
            DataTable dt = new DataTable();
            
            dt.Columns.Add("Color", typeof(String));
            using (ArtEntitiesnew enty = new ArtEntitiesnew())
            {


                var sizedetails = (from size in enty.StyleSizes
                                   where size.OurStyleID == ourstyleid
                                   select new
                                   {
                                       size.SizeName
                                   }).Distinct();

                foreach (var sizedet in sizedetails)
                {
                    dt.Columns.Add(sizedet.SizeName.Trim(), typeof(String));
                }


                DataRow row = dt.NewRow();

                for (int i = 0; i < dt.Columns.Count; i++)
                {
                    row[i] = 0;
                }
                dt.Rows.Add(row);




                return dt;
            }


        }






        public static String IsASQCutable(int ourstyleid, int popackid)
        {
            DataTable dt = new DataTable();
            string icut = "";
            dt.Columns.Add("Color", typeof(String));
            using (ArtEntitiesnew enty = new ArtEntitiesnew())
            {


                var iscutable = enty.POPackDetails.Where(u => u.POPackId == popackid && u.OurStyleID == ourstyleid).Select(u => u.IsCutable).FirstOrDefault();

                if(iscutable==null || iscutable.ToString ().Trim() == "")
                {
                    icut = "N";
                }
                else
                {
                    icut = iscutable.ToString().Trim();
                }

            }




            return icut;
        }

        public static String IsASQPackable(int ourstyleid, int popackid)
        {
            DataTable dt = new DataTable();
            string icut = "";
            dt.Columns.Add("Color", typeof(String));
            using (ArtEntitiesnew enty = new ArtEntitiesnew())
            {


                var iscutable = enty.POPackDetails.Where(u => u.POPackId == popackid && u.OurStyleID == ourstyleid).Select(u => u.IsPackable).FirstOrDefault();

                if (iscutable == null || iscutable.ToString().Trim() == "")
                {
                    icut = "N";
                }
                else
                {
                    icut = iscutable.ToString().Trim();
                }

            }




            return icut;
        }


        public static String OurStyleProjectionQty(int ourstyleid)
        {
            
            string qty = "0";
          
            using (ArtEntitiesnew enty = new ArtEntitiesnew())
            {
                var styleqty = enty.AtcDetails.Where(u => u.OurStyleID==ourstyleid).Select(u => u.Quantity ?? 0).Sum();


                qty = styleqty.ToString();

              

            }




            return qty;
        }


        /// <summary>
        /// GET THE POPACK QTY OF OURSTYLE EXCLUDING THE GIVEN POPACK
        /// </summary>
        /// <param name="ourstyleid"></param>
        /// <param name="popackid"></param>
        /// <returns></returns>

        public static String ASQQtyOtherthanGivenASQ(int ourstyleid ,int popackid)
        {

            string qty = "0";

            using (ArtEntitiesnew enty = new ArtEntitiesnew())
            {
                try
                {
                    var styleqty = enty.POPackDetails.Where(u => u.OurStyleID == ourstyleid && u.POPackId != popackid).Select(u => u.PoQty ?? 0).Sum();
                    qty = styleqty.ToString();
                }
                catch (Exception)
                {

                    qty = "0";
                }


             



            }




            return qty;
        }












        /// <summary>
        /// Create the Size color Matrix from the popackdetails provided  without query
        /// </summary>
        /// <param name="AsqData"></param>
        /// <param name="popackid"></param>
        /// <returns></returns>
        public static DataTable createdatatable(DataTable AsqData, int popackid)
        {
            DataTable dt = new DataTable();
            try
            {
                AsqData = AsqData.Select("PoPackId=" + popackid + "").CopyToDataTable();
                DataTable UniqueSize = AsqData.DefaultView.ToTable(true, "SizeName");
                DataTable UniqueColor = AsqData.DefaultView.ToTable(true, "ColorName");
              

                dt.Columns.Add("Color", typeof(String));


                for (int i = 0; i < UniqueSize.Rows.Count; i++)
                {
                    dt.Columns.Add(UniqueSize.Rows[i][0].ToString(), typeof(String));
                }
                for (int i = 0; i < UniqueColor.Rows.Count; i++)
                {
                    dt.Rows.Add();
                    for (int j = 0; j < dt.Columns.Count; j++)
                    {


                        if (j == 0)
                        {
                            dt.Rows[i][j] = UniqueColor.Rows[i][0].ToString();
                        }
                        else
                        {
                            try
                            {
                                object poqty = AsqData.Compute("Sum(PoQty)", "ColorName= '" + dt.Rows[i][0].ToString() + "' and  SizeName ='" + dt.Columns[j].ColumnName.ToString() + "'");

                                if (poqty.ToString().Trim() == "")
                                {
                                    poqty = "0";
                                }

                                dt.Rows[i][j] = poqty.ToString();
                            }
                            catch
                            {

                            }

                        }

                    }



                }
            }
            catch (Exception)
            {

               
            }

            
            

            


            return dt;
        }

        /// <summary>
        /// get the PO and POdetails of a Style and Color
        /// </summary>
        /// <param name="ourstyleid"></param>
        /// <param name="colorcode"></param>
        /// <returns></returns>
        public static DataTable GetASQofAStyleAndColor(int ourstyleid, String colorcode)
        {
            DataTable dt = new DataTable();
            int i = 0;
            using (SqlConnection con = new SqlConnection(connStr))
            {
                con.Open();
                string query = "";
       
                if (colorcode == "CM")
                {
                    query = @"SELECT        PoPackMaster.PoPacknum + ' / ' + PoPackMaster.BuyerPO AS ASQ, PoPackMaster.PoPacknum, PoPackMaster.BuyerPO, PoPackMaster.PoPackId, POPackDetails.OurStyleID, AtcDetails.OurStyle, 
                         AtcDetails.BuyerStyle, PoPackMaster.AtcId, POPackDetails.ColorName, POPackDetails.SizeName, POPackDetails.PoQty,POPackDetails.ColorCode, PoPackMaster.SeasonName
FROM            PoPackMaster INNER JOIN
                         POPackDetails ON PoPackMaster.PoPackId = POPackDetails.POPackId INNER JOIN
                         AtcDetails ON POPackDetails.OurStyleID = AtcDetails.OurStyleID
GROUP BY PoPackMaster.PoPacknum + ' / ' + PoPackMaster.BuyerPO, PoPackMaster.PoPacknum, PoPackMaster.BuyerPO, PoPackMaster.PoPackId, POPackDetails.OurStyleID, AtcDetails.OurStyle, AtcDetails.BuyerStyle, 
                         PoPackMaster.AtcId, POPackDetails.ColorName, POPackDetails.SizeName, POPackDetails.PoQty,POPackDetails.ColorCode,PoPackMaster.SeasonName, POPackDetails.IsCutable
HAVING        (POPackDetails.OurStyleID = @OurStyleID)   AND (POPackDetails.IsCutable = N'Y')
ORDER BY PoPackMaster.PoPackId";
                }
                else
                {
                    query = @"SELECT        PoPackMaster.PoPacknum + ' / ' + PoPackMaster.BuyerPO AS ASQ, PoPackMaster.PoPacknum, PoPackMaster.BuyerPO, PoPackMaster.PoPackId, POPackDetails.OurStyleID, AtcDetails.OurStyle, 
                         AtcDetails.BuyerStyle, PoPackMaster.AtcId, POPackDetails.ColorName, POPackDetails.SizeName, POPackDetails.PoQty,POPackDetails.ColorCode, PoPackMaster.SeasonName
FROM            PoPackMaster INNER JOIN
                         POPackDetails ON PoPackMaster.PoPackId = POPackDetails.POPackId INNER JOIN
                         AtcDetails ON POPackDetails.OurStyleID = AtcDetails.OurStyleID
GROUP BY PoPackMaster.PoPacknum + ' / ' + PoPackMaster.BuyerPO, PoPackMaster.PoPacknum, PoPackMaster.BuyerPO, PoPackMaster.PoPackId, POPackDetails.OurStyleID, AtcDetails.OurStyle, AtcDetails.BuyerStyle, 
                         PoPackMaster.AtcId, POPackDetails.ColorName, POPackDetails.SizeName, POPackDetails.PoQty,POPackDetails.ColorCode,PoPackMaster.SeasonName, POPackDetails.IsCutable
HAVING        (POPackDetails.OurStyleID = @OurStyleID) AND (POPackDetails.ColorCode = @ColorCode)  AND (POPackDetails.IsCutable = N'Y')
ORDER BY PoPackMaster.PoPackId";
                }

                    SqlCommand cmd = new SqlCommand(query, con);

                if (colorcode != "CM")
                {
                    cmd.Parameters.AddWithValue("@ColorCode", colorcode);
                }
                cmd.Parameters.AddWithValue("@OurStyleID", ourstyleid);
          
                SqlDataReader rdr = cmd.ExecuteReader();

                dt.Load(rdr);



            }



            return dt;
        }


       /// <summary>
       /// Get All the PO containing a Style and Color
       /// </summary>
       /// <param name="ourstyleid"></param>
       /// <param name="colorcode"></param>
       /// <returns></returns>

        public static DataTable GetASQMasterofAStyleAndColor(int ourstyleid, String colorcode)
        {
            DataTable dt = new DataTable();
            int i = 0;
            using (SqlConnection con = new SqlConnection(connStr))
            {
                string query = "";
                con.Open();
                if (colorcode == "CM")
                {
                    query = @"SELECT        PoPackMaster.PoPacknum + ' / ' + PoPackMaster.BuyerPO AS ASQ, PoPackMaster.PoPacknum, PoPackMaster.BuyerPO, PoPackMaster.PoPackId, POPackDetails.OurStyleID, AtcDetails.OurStyle, 
                         AtcDetails.BuyerStyle, PoPackMaster.AtcId,   SUM(POPackDetails.PoQty) AS poqTY, PoPackMaster.SeasonName
FROM            PoPackMaster INNER JOIN
                         POPackDetails ON PoPackMaster.PoPackId = POPackDetails.POPackId INNER JOIN
                         AtcDetails ON POPackDetails.OurStyleID = AtcDetails.OurStyleID
						 WHERE        (POPackDetails.OurStyleID = @OurStyleID) 
GROUP BY PoPackMaster.PoPacknum + ' / ' + PoPackMaster.BuyerPO, PoPackMaster.PoPacknum, PoPackMaster.BuyerPO, PoPackMaster.PoPackId, POPackDetails.OurStyleID, AtcDetails.OurStyle, AtcDetails.BuyerStyle, 
                         PoPackMaster.AtcId, PoPackMaster.SeasonName HAVING        (MAX(POPackDetails.IsCutable) = N'Y')

ORDER BY PoPackMaster.PoPackId";
                }
                else
                {
                    query = @"SELECT        PoPackMaster.PoPacknum + ' / ' + PoPackMaster.BuyerPO AS ASQ, PoPackMaster.PoPacknum, PoPackMaster.BuyerPO, PoPackMaster.PoPackId, POPackDetails.OurStyleID, AtcDetails.OurStyle, 
                         AtcDetails.BuyerStyle, PoPackMaster.AtcId,   SUM(POPackDetails.PoQty) AS poqTY, PoPackMaster.SeasonName
FROM            PoPackMaster INNER JOIN
                         POPackDetails ON PoPackMaster.PoPackId = POPackDetails.POPackId INNER JOIN
                         AtcDetails ON POPackDetails.OurStyleID = AtcDetails.OurStyleID
						 WHERE        (POPackDetails.OurStyleID = @OurStyleID) AND (POPackDetails.ColorCode = @ColorCode)
GROUP BY PoPackMaster.PoPacknum + ' / ' + PoPackMaster.BuyerPO, PoPackMaster.PoPacknum, PoPackMaster.BuyerPO, PoPackMaster.PoPackId, POPackDetails.OurStyleID, AtcDetails.OurStyle, AtcDetails.BuyerStyle, 
                         PoPackMaster.AtcId, PoPackMaster.SeasonName HAVING        (MAX(POPackDetails.IsCutable) = N'Y')

ORDER BY PoPackMaster.PoPackId";
                }
                SqlCommand cmd = new SqlCommand(query, con);

                if (colorcode != "")
                {
                    cmd.Parameters.AddWithValue("@ColorCode", colorcode);
                }

              


                cmd.Parameters.AddWithValue("@OurStyleID", ourstyleid);
              
                SqlDataReader rdr = cmd.ExecuteReader();

                dt.Load(rdr);



            }



            return dt;
        }


        public static DataTable GetCutPlanmarkerdetails(int cutplan_PK)
        {
            DataTable dt = new DataTable();
            int i = 0;
            using (SqlConnection con = new SqlConnection(connStr))
            {
                string query = "";
                con.Open();
             
                    query = @"SELECT        CutPlanMarkerSizeDetails.Size, CutPlanMarkerSizeDetails.Ratio, CutPlanMarkerSizeDetails.Qty, CutPlanMarkerSizeDetails.CutPlanSize_PK, CutPlanMarkerSizeDetails.CutPlan_PK, 
                         CutPlanMarkerSizeDetails.CutPlanMarkerDetails_PK, CutPlanMarkerDetails.MarkerNo, CutPlanMarkerDetails.NoOfPc, CutPlanMarkerDetails.LayLength, CutPlanMarkerDetails.NoOfPlies, 
                         CutPlanMarkerDetails.CutPerPlies, CutPlanMarkerDetails.Cutreq
FROM            CutPlanMarkerSizeDetails INNER JOIN
                         CutPlanMarkerDetails ON CutPlanMarkerSizeDetails.CutPlanMarkerDetails_PK = CutPlanMarkerDetails.CutPlanMarkerDetails_PK
WHERE        (CutPlanMarkerSizeDetails.CutPlan_PK = @cutplan_PK)";
                
                SqlCommand cmd = new SqlCommand(query, con);

               


                cmd.Parameters.AddWithValue("@cutplan_PK", cutplan_PK);

                SqlDataReader rdr = cmd.ExecuteReader();

                dt.Load(rdr);



            }



            return dt;
        }


        public static DataTable GetCutPlanmarkerSizedetails(int cutplan_PK)
        {
            DataTable dt = new DataTable();
            int i = 0;
            using (SqlConnection con = new SqlConnection(connStr))
            {
                string query = "";
                con.Open();

                query = @"SELECT        CutPlanMarkerSizeDetails.CutPlanSize_PK, CutPlanMarkerSizeDetails.Size, CutPlanMarkerSizeDetails.Ratio, CutPlanMarkerSizeDetails.Qty, CutPlanMarkerSizeDetails.CutPlanMarkerDetails_PK, 
                         CutPlanMarkerDetails.CutPlan_PK, CutPlanMarkerDetails.MarkerNo, CutPlanMarkerDetails.NoOfPc, CutPlanMarkerDetails.MarkerLength, CutPlanMarkerDetails.LayLength, CutPlanMarkerDetails.NoOfPlies, 
                         CutPlanMarkerDetails.CutPerPlies, CutPlanMarkerDetails.Cutreq
FROM            CutPlanMarkerSizeDetails INNER JOIN
                         CutPlanMarkerDetails ON CutPlanMarkerSizeDetails.CutPlanMarkerDetails_PK = CutPlanMarkerDetails.CutPlanMarkerDetails_PK
WHERE        (CutPlanMarkerDetails.CutPlan_PK = @cutplan_PK)";

                SqlCommand cmd = new SqlCommand(query, con);




                cmd.Parameters.AddWithValue("@cutplan_PK", cutplan_PK);

                SqlDataReader rdr = cmd.ExecuteReader();

                dt.Load(rdr);



            }



            return dt;
        }

        /// <summary>
        /// Requery the database to get the size color asq matrix
        /// </summary>
        /// <param name="ourstyleid"></param>
        /// <param name="popackid"></param>
        /// <returns></returns>
        public static DataTable createdatatableofCutPlan(int cutplanpk)
        {
            DataTable dt = new DataTable();

            dt.Columns.Add("Color", typeof(String));
            using (ArtEntitiesnew enty = new ArtEntitiesnew())
            {


                var sizedetails = (from size in enty.CutPlanMarkerSizeDetails

                                   where size.CutPlan_PK == cutplanpk
                                   select new
                                   {
                                       size.Size
                                   }).Distinct();

                foreach (var sizedet in sizedetails)
                {
                    dt.Columns.Add(sizedet.Size.Trim(), typeof(String));
                }

                dt.Columns.Add("Total", typeof(String));
                DataRow row = dt.NewRow();

                for (int i = 0; i < dt.Columns.Count; i++)
                {
                    row[i] = 0;
                }
                dt.Rows.Add(row);

                DataRow row1 = dt.NewRow();

                for (int i = 0; i < dt.Columns.Count; i++)
                {
                    row[i] = 0;
                }
                dt.Rows.Add(row1);


                return dt;
            }


        }






        /// <summary>
        /// Create the Size color Matrix from the popackdetails provided  without query
        /// </summary>
        /// <param name="AsqData"></param>
        /// <param name="popackid"></param>
        /// <returns></returns>
        public static DataTable createdatatableforCutplanASQ(DataTable AsqData, int popackid, int OurStyleID)
        {
            AsqData = AsqData.Select("PoPackId=" + popackid + "").CopyToDataTable();


            DataTable UniqueSize = AsqData.DefaultView.ToTable(true, "SizeName");
            DataTable UniqueColor = AsqData.DefaultView.ToTable(true, "ColorName");
            DataTable dt = new DataTable();

            dt.Columns.Add("Color", typeof(String));


            for (int i = 0; i < UniqueSize.Rows.Count; i++)
            {
                dt.Columns.Add(UniqueSize.Rows[i][0].ToString(), typeof(String));
            }



            for (int i = 0; i < UniqueColor.Rows.Count; i++)
            {
                dt.Rows.Add();
                for (int j = 0; j < dt.Columns.Count; j++)
                {


                    if (j == 0)
                    {
                        dt.Rows[i][j] = UniqueColor.Rows[i][0].ToString();
                    }
                    else
                    {
                        try
                        {

                            object poqty = AsqData.Compute("Sum(CutQty)", "ColorName= '" + dt.Rows[i][0].ToString() + "' and  SizeName ='" + dt.Columns[j].ColumnName.ToString() + "'and OurStyleID =" + OurStyleID + " and PoPackId =" + popackid + "");

                            if (poqty.ToString().Trim() == "")
                            {
                                poqty = "0";
                            }

                            dt.Rows[i][j] = poqty.ToString();
                        }
                        catch (Exception)
                        {
                            dt.Rows[i][j] = 0;
                        }

                    }

                }



            }


            return dt;
        }

    }
}