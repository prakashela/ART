﻿<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeBehind="ExternalSales.aspx.cs" Inherits="ArtWebApp.Inventory.Sales.ExternalSales" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
      
        .NormalTD {
            width: 34px;
        }
      
        .NormalTD {
            height: 46px;
        }
        .NormalTD {
            width: 34px;
            height: 46px;
        }
      
    </style>
    
    <link href="../../css/style.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    
        <table class="FullTable">

            <tr>
                <td>
<table class="DataEntryTable">
                <tr>
                    <td class="RedHeadding" colspan="9">
                       Sales DO(general )(ww)</td>
                </tr>
                <tr>
                    <td class="NormalTD">
                        FROM</td>
                    <td class="NormalTD">
                             
                        <ucc:dropdownlistchosen ID="drp_fromWarehouse" runat="server"  TextField="name" ValueField="pk" Width="200px"  DataTextField="name" DataValueField="pk" DisableSearchThreshold="10">
                                        
                             
                    </ucc:dropdownlistchosen>
                    </td>
                    <td class="NormalTD" >
                        <asp:Button ID="btn_confirmAtc" runat="server" Text="S" Width="33px" OnClick="btn_confirmAtc_Click" CssClass="auto-style10" />
                    </td>
                    <td class="NormalTD" >
                        D O Date:</td>
                    <td class="NormalTD" >
                        <ig:WebDatePicker ID="dtp_dodate" runat="server" Height="26px" Width="191px">
                        </ig:WebDatePicker>
                    </td>
                    <td class="NormalTD" >
                        Container No:</td>
                    <td class="NormalTD">
                        <asp:TextBox ID="txt_containernum" runat="server" Height="20px" Width="164px" CssClass="auto-style10"></asp:TextBox>
                    </td>
                    <td c class="NormalTD">
                        </td>
                    <td class="NormalTD" >
                        </td>
                </tr>
                <tr>
                    <td >
                        &nbsp;</td>
                    <td >
                        
                    </td>
                    <td class="NormalTD" >
                        &nbsp;</td>
                    <td >
                        To</td>
                    <td >
                      

                          <ucc:dropdownlistchosen ID="drp_ToWarehouse" runat="server"  TextField="name" ValueField="pk" Width="200px"  DataTextField="name" DataValueField="pk" DisableSearchThreshold="10">
                             </ucc:dropdownlistchosen>           
                    </td>
                    <td >
                        BOE No</td>
                    <td >
                        <asp:TextBox ID="txt_BOE_no" runat="server" Height="20px" Width="164px" CssClass="auto-style10"></asp:TextBox>
                    </td>
                    <td >
                        Mode:</td>
                    <td >
                         <ucc:DropDownListChosen ID="drp_deliverymode" TextField="name" ValueField="pk" DataTextField="name" DataValueField="pk" runat="server" Width="200px">
                        </ucc:DropDownListChosen>
                    </td>
                </tr>
                <tr>
                    <td class="gridtable" colspan="9">
                        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                            <ContentTemplate>
                                <asp:GridView ID="tbl_InverntoryDetails" runat="server" AutoGenerateColumns="False" ShowHeaderWhenEmpty="True" style="font-size: small; font-family: Calibri; font-weight: 400;" Width="100%" BackColor="White" BorderColor="#CC9966" BorderStyle="None" BorderWidth="1px" CellPadding="4" DataKeyNames="SInventoryItem_PK" OnSelectedIndexChanged="tbl_InverntoryDetails_SelectedIndexChanged" >
                                    <Columns>
                                        <asp:TemplateField HeaderImageUrl="~/Image/tick.jpg">
                                            <ItemTemplate>
                                                <asp:CheckBox ID="chk_select" runat="server" />
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                          <asp:TemplateField HeaderText="II_PK">
                                            <ItemTemplate>
                                                <asp:Label ID="lblInventoryItem_PK" runat="server" Text='<%# Bind("SInventoryItem_PK") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        
                                        <asp:BoundField DataField="Description" HeaderText="Description" SortExpression="Description" />
                                        <asp:BoundField DataField="Composition" HeaderText="Composition" SortExpression="Composition" />
                                        <asp:BoundField DataField="Construct" HeaderText="Construct" SortExpression="Construct" />
                                        <asp:BoundField DataField="TemplateColor" HeaderText="TemplateColor" SortExpression="TemplateColor" />
                                        <asp:BoundField DataField="TemplateSize" HeaderText="TemplateSize" SortExpression="TemplateSize" />
                                        <asp:BoundField DataField="width" HeaderText="width" ReadOnly="True" SortExpression="width" />
                                        <asp:TemplateField HeaderText="CUrate" SortExpression="CUrate">
                                            
                                            <ItemTemplate>
                                                <asp:Label ID="lbl_curate" runat="server" Text='<%# Bind("CUrate") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                           <asp:BoundField DataField="UomName" HeaderText="UomName" SortExpression="UomName" />
                                        <asp:BoundField DataField="ReceivedQty" HeaderText="ReceivedQty" SortExpression="ReceivedQty" />
                                       
                                     
                                         <asp:TemplateField HeaderText="OnhandQty">
                                            
                                            <ItemTemplate>
                                                <asp:Label ID="lbl_onhandQty" runat="server" Text='<%# Bind("OnHandQty") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>

                                        <asp:TemplateField HeaderText="deliveryqty" SortExpression="deliveryqty">
                                           
                                            <ItemTemplate>
                                                <asp:TextBox ID="txt_deliveryQty" runat="server" Text='<%# Bind("deliveryqty") %>'></asp:TextBox>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                    </Columns>
                                    <FooterStyle BackColor="#FFFFCC" ForeColor="#330099" />
                                    <HeaderStyle BackColor="#990000" Font-Bold="True" ForeColor="#FFFFCC" />
                                    <PagerStyle BackColor="#FFFFCC" ForeColor="#330099" HorizontalAlign="Center" />
                                    <RowStyle BackColor="White" ForeColor="#330099" />
                                    <SelectedRowStyle BackColor="#FFCC66" Font-Bold="True" ForeColor="#663399" />
                                    <SortedAscendingCellStyle BackColor="#FEFCEB" />
                                    <SortedAscendingHeaderStyle BackColor="#AF0101" />
                                    <SortedDescendingCellStyle BackColor="#F6F0C0" />
                                    <SortedDescendingHeaderStyle BackColor="#7E0000" />
                                </asp:GridView>
                            </ContentTemplate>
                        </asp:UpdatePanel>
                    </td>
                </tr>
                <tr class="ButtonTR">
                    <td >
                        &nbsp;</td>
                    <td >
                        &nbsp;</td>
                    <td class="NormalTD" >
                        &nbsp;</td>
                    <td >
                        &nbsp;</td>
                    <td >
                        <asp:Button ID="btn_saveDO" runat="server" OnClick="btn_saveDO_Click" Text="Save DO" style="height: 26px" />
                    </td>
                    <td >
                        &nbsp;</td>
                    <td >
                        &nbsp;</td>
                    <td >
                        &nbsp;</td>
                    <td >
                        &nbsp;</td>
                </tr>
                <tr class="ButtonTR">
                    <td colspan="9" >
                        <div id="Messaediv" runat="server">
                 


                           <asp:Label ID="lbl_msg" runat="server" Text="*"></asp:Label>


                     
               </div></td>
                </tr>
            </table>

                </td>
            </tr>
        </table>
      
            
        
   
    <div class="footer">
        
               
                               
    </div>

    
</asp:Content>
