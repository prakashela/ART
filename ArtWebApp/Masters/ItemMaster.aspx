﻿<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" Inherits="Masters_ItemMaster" Codebehind="ItemMaster.aspx.cs" %>

<%@ Register assembly="Infragistics35.Web.v12.1, Version=12.1.20121.2236, Culture=neutral, PublicKeyToken=7dd5c3163f2cd0cb" namespace="Infragistics.Web.UI.GridControls" tagprefix="ig" %>

<%@ Register assembly="Infragistics35.Web.v12.1, Version=12.1.20121.2236, Culture=neutral, PublicKeyToken=7dd5c3163f2cd0cb" namespace="Infragistics.Web.UI" tagprefix="ig" %>

<%@ Register assembly="Infragistics35.Web.v12.1, Version=12.1.20121.2236, Culture=neutral, PublicKeyToken=7dd5c3163f2cd0cb" namespace="Infragistics.Web.UI.ListControls" tagprefix="ig1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style type="text/css">
     


    </style>
    <link href="../css/style.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table class="DataEntryTable">
        
        <tr>
            <td>
               
              
                <asp:MultiView ID="MultiView1" runat="server">
                    <asp:View ID="View1"  runat="server">
                     
                            <table class="DataEntryTable">
                                 <tr>
            <td class="RedHeadding">
                Item Group
            </td>
        </tr>
                                <tr class="gridtable">
                                    <td>
                                        <ig:WebDataGrid ID="WebDataGrid2" runat="server" AutoGenerateColumns="False" DataSourceID="SqlDataSource1" Height="350px" Width="100%">
                                            <Columns>
                                                <ig:BoundDataField DataFieldName="ItemGroupID" Key="ItemGroupID"><header text="ItemGroupID"></header></ig:BoundDataField>
                                                <ig:BoundDataField DataFieldName="ItemGroupName" Key="ItemGroupName"><header text="ItemGroupName"></header></ig:BoundDataField>
                                                <ig:BoundDataField DataFieldName="ItemGroupDescription" Key="ItemGroupDescription"><header text="ItemGroupDescription"></header></ig:BoundDataField>
                                            </Columns>
                                            <editorproviders>
                                            <ig:TextBoxProvider ID="WebDataGrid1_TextBoxProvider2"></ig:TextBoxProvider>
                                            </editorproviders>
                                            <behaviors>
                                            <ig:ColumnMoving></ig:ColumnMoving>
                                            <ig:ColumnResizing></ig:ColumnResizing>
                                            <ig:EditingCore><behaviors><ig:RowAdding Alignment="Top"><columnsettings><ig:RowAddingColumnSetting ColumnKey="ItemGroupName" DefaultValueAsString="EnterNew " /><ig:RowAddingColumnSetting ColumnKey="ItemGroupDescription" DefaultValueAsString="Desc" /></columnsettings></ig:RowAdding><ig:CellEditing></ig:CellEditing><ig:RowDeleting /><ig:RowEditingTemplate></ig:RowEditingTemplate></behaviors></ig:EditingCore>
                                            <ig:Selection CellClickAction="Row" RowSelectType="Single"></ig:Selection>
                                            <ig:RowSelectors></ig:RowSelectors>
                                            <ig:Filtering></ig:Filtering>
                                            <ig:Paging></ig:Paging>
                                            <ig:Sorting></ig:Sorting>
                                            <ig:SummaryRow></ig:SummaryRow>
                                            <ig:VirtualScrolling></ig:VirtualScrolling>
                                            <ig:Activation></ig:Activation>
                                            <ig:Clipboard></ig:Clipboard>
                                            </behaviors>
                                        </ig:WebDataGrid>
                                    </td>
                                </tr>
                            </table>
                            <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConflictDetection="CompareAllValues" ConnectionString="<%$ ConnectionStrings:ArtConnectionString %>" DeleteCommand="DELETE FROM [ItemGroupMaster] WHERE [ItemGroupID] = @original_ItemGroupID AND (([ItemGroupName] = @original_ItemGroupName) OR ([ItemGroupName] IS NULL AND @original_ItemGroupName IS NULL)) AND (([ItemGroupDescription] = @original_ItemGroupDescription) OR ([ItemGroupDescription] IS NULL AND @original_ItemGroupDescription IS NULL))" InsertCommand="INSERT INTO [ItemGroupMaster] ([ItemGroupName], [ItemGroupDescription]) VALUES (@ItemGroupName, @ItemGroupDescription)" OldValuesParameterFormatString="original_{0}" SelectCommand="SELECT * FROM [ItemGroupMaster]" UpdateCommand="UPDATE [ItemGroupMaster] SET [ItemGroupName] = @ItemGroupName, [ItemGroupDescription] = @ItemGroupDescription WHERE [ItemGroupID] = @original_ItemGroupID AND (([ItemGroupName] = @original_ItemGroupName) OR ([ItemGroupName] IS NULL AND @original_ItemGroupName IS NULL)) AND (([ItemGroupDescription] = @original_ItemGroupDescription) OR ([ItemGroupDescription] IS NULL AND @original_ItemGroupDescription IS NULL))">
                                <DeleteParameters>
                                    <asp:Parameter Name="original_ItemGroupID" Type="Decimal" />
                                    <asp:Parameter Name="original_ItemGroupName" Type="String" />
                                    <asp:Parameter Name="original_ItemGroupDescription" Type="String" />
                                </DeleteParameters>
                                <InsertParameters>
                                    <asp:Parameter Name="ItemGroupName" Type="String" />
                                    <asp:Parameter Name="ItemGroupDescription" Type="String" />
                                </InsertParameters>
                                <UpdateParameters>
                                    <asp:Parameter Name="ItemGroupName" Type="String" />
                                    <asp:Parameter Name="ItemGroupDescription" Type="String" />
                                    <asp:Parameter Name="original_ItemGroupID" Type="Decimal" />
                                    <asp:Parameter Name="original_ItemGroupName" Type="String" />
                                    <asp:Parameter Name="original_ItemGroupDescription" Type="String" />
                                </UpdateParameters>
                            </asp:SqlDataSource>
                            <br />
                       
                        
                    </asp:View>


                     <asp:View ID="View2"  runat="server">
                          <div>
    
        <br />
        <table class="FullTable">
            <tr>
                <td class="RedHeadding">New Item</td>
            </tr>
            <tr>
                <td>
                    <table class="DataEntryTable">
                        <tr>
                            <td class="NormalTD">Item Code</td>
                            <td class="NormalTD">
                                <asp:TextBox ID="txt_itemcode" runat="server"></asp:TextBox>
                            </td>
                            <td class="NormalTD">Item Name : </td>
                            <td class="NormalTD">
                                <asp:TextBox ID="txt_itemname" runat="server"></asp:TextBox>
                            </td>
                            <td class="auto-style6">Item Group</td>
                            <td>
                                <ig1:WebDropDown ID="cmb_itemgroup" runat="server" DataSourceID="itemgroup" Width="188px" TextField="ItemGroupName" ValueField="ItemGroupID"><DropDownItemBinding TextField="ItemGroupName" ValueField="ItemGroupID" /></ig1:WebDropDown>
                            </td>
                        </tr>
                        <tr>
                            <td class="NormalTD">HC Code&nbsp; :</td>
                            <td class="NormalTD">
                                <asp:TextBox ID="txt_hscode" runat="server"></asp:TextBox>
                            </td>
                            <td class="NormalTD">UOM :</td>
                            <td class="NormalTD">
                                <ig1:WebDropDown ID="cmb_uom" runat="server" Width="180px" Height="20px" TextField="Uomname" ValueField="Uom_pk" DataSourceID="Uomdata"><DropDownItemBinding TextField="Uomname" ValueField="Uom_pk" /></ig1:WebDropDown>
                            </td>
                            <td class="auto-style6" >Wastage :</td>
                            <td>
                                <asp:TextBox ID="txt_wastage" runat="server"></asp:TextBox>

                            </td>




                        </tr>
                       
                        <tr>
                            <td class="NormalTD"></td>
                            <td class="NormalTD">
                                <asp:CheckBox ID="CheckBox1" runat="server" Text="Color Dependant" />
                            </td>
                            <td class="NormalTD0">
                                <asp:CheckBox ID="CheckBox2" runat="server" Text="Size Dependant" />
                            </td>
                            <td class="NormalTD"></td>
                            <td class="NormalTD"></td>
                            <td class="NormalTD"></td>
                        </tr>
                       
                    </table>
                </td>
            </tr>
            <tr class="SmallSearchButton" >
                <td>
                    <asp:Button ID="Button1" runat="server" Text="Save" OnClick="Button1_Click" />
                </td>
            </tr>
            <tr>
                <td class="NormalTD">
                    <asp:SqlDataSource ID="itemgroup" runat="server" ConnectionString="<%$ ConnectionStrings:ArtConnectionString %>" SelectCommand="SELECT [ItemGroupName], [ItemGroupID] FROM [ItemGroupMaster] ORDER BY [ItemGroupName], [ItemGroupID]"></asp:SqlDataSource>
                    <asp:SqlDataSource ID="Uomdata" runat="server" ConnectionString="<%$ ConnectionStrings:ArtConnectionString %>" SelectCommand="SELECT [UomName], [Uom_PK] FROM [UOMMaster ]"></asp:SqlDataSource>
                    <asp:SqlDataSource ID="SqlDataSource4" runat="server" ConnectionString="<%$ ConnectionStrings:ArtConnectionString %>" SelectCommand="SELECT Template_Master.Template_PK AS Id, Template_Master.TemplateCode AS Code, Template_Master.Description AS Name, ItemGroupMaster.ItemGroupDescription AS [Item Group], Template_Master.HCCode AS HCcode, UOMMaster .UomName AS UOM, Template_Master.Wastage, Template_Master.IsStock FROM Template_Master INNER JOIN UOMMaster  ON Template_Master.Uom_PK = UOMMaster .Uom_PK INNER JOIN ItemGroupMaster ON Template_Master.ItemGroup_PK = ItemGroupMaster.ItemGroupID"></asp:SqlDataSource>
                </td>
            </tr>
            <tr>
                <td class="gridtable">
                    <ig:WebDataGrid ID="WebDataGrid3" runat="server" AutoGenerateColumns="False" DataSourceID="SqlDataSource4" Height="350px" Width="100%">
                        <Columns>
                            <ig:BoundDataField DataFieldName="Id" Key="Id"><header text="Id"></header></ig:BoundDataField>
                            <ig:BoundDataField DataFieldName="Code" Key="Code"><header text="Code"></header></ig:BoundDataField>
                            <ig:BoundDataField DataFieldName="Name" Key="Name"><header text="Name"></header></ig:BoundDataField>
                            <ig:BoundDataField DataFieldName="Item Group" Key="Item Group"><header text="Item Group"></header></ig:BoundDataField>
                            <ig:BoundDataField DataFieldName="HCcode" Key="HCcode"><header text="HCcode"></header></ig:BoundDataField>
                            <ig:BoundDataField DataFieldName="UOM" Key="UOM"><header text="UOM"></header></ig:BoundDataField>
                            <ig:BoundDataField DataFieldName="Wastage" Key="Wastage"><header text="Wastage"></header></ig:BoundDataField>
                            <ig:BoundDataField DataFieldName="IsStock" Key="IsStock"><header text="IsStock"></header></ig:BoundDataField>
                        </Columns>
                        <behaviors>
                        <ig:Filtering></ig:Filtering>
                        <ig:Sorting></ig:Sorting>
                        </behaviors>
                    </ig:WebDataGrid>
                </td>
            </tr>
            <tr>
                <td class="NormalTD">&nbsp;</td>
            </tr>
        </table>
    
    </div>
   
                         </asp:View>

                     <asp:View ID="View3" runat="server">
                         <table class="FullTable">
                             <tr>
                                 <td>
                                     <table class="DataEntryTable">
                                         <tr>
                                             <td class="RedHeadding" colspan="5">Item Composition</td>
                                         </tr>
                                         <tr>
                                             <td class="NormalTD">Item</td>
                                             <td class="auto-style10">
                                                 <ig1:WebDropDown ID="drp_templateforComp" runat="server" Width="200px" CurrentValue="Select Item" DataSourceID="ItemMasterData" TextField="Description" ValueField="Template_Pk"><DropDownItemBinding TextField="Description" ValueField="Template_Pk" /></ig1:WebDropDown>
                                             </td>
                                             <td>
                                                 <asp:SqlDataSource ID="ItemMasterData" runat="server" ConnectionString="<%$ ConnectionStrings:ArtConnectionString %>" SelectCommand="SELECT Template_PK, TemplateCode, Description FROM Template_Master ORDER BY TemplateCode"></asp:SqlDataSource>
                                                 <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="drp_templateforComp" ErrorMessage="Select  Item" ForeColor="#FF3300" InitialValue="Select Item" ValidationGroup="comp">*</asp:RequiredFieldValidator>
                                             </td>
                                             <td>&nbsp;</td>
                                             <td>&nbsp;</td>
                                         </tr>
                                         <tr>
                                             <td class="NormalTD">Composition</td>
                                             <td class="auto-style10">
                                                 <asp:TextBox ID="txt_Composition" runat="server" Width="197px"></asp:TextBox>
                                             </td>
                                             <td>
                                                 <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txt_Composition" ErrorMessage="Enter Composition" ForeColor="#FF3300" ValidationGroup="comp">*</asp:RequiredFieldValidator>
                                             </td>
                                             <td>&nbsp;</td>
                                             <td>
                                                 <asp:SqlDataSource ID="composition" runat="server" ConnectionString="<%$ ConnectionStrings:ArtConnectionString %>" SelectCommand="SELECT TemplateComposition.TemplateCom_Pk, Template_Master.TemplateCode, Template_Master.Description, TemplateComposition.Composition FROM Template_Master INNER JOIN TemplateComposition ON Template_Master.Template_PK = TemplateComposition.Template_Pk ORDER BY Template_Master.TemplateCode"></asp:SqlDataSource>
                                             </td>
                                         </tr>
                                         <tr>
                                             <td class="NormalTD">&nbsp;</td>
                                             <td class="auto-style10">
                                                 <asp:Button ID="btn_SaveComp" runat="server" Text="Save" OnClick="btn_SaveComp_Click" ValidationGroup="comp" />
                                             </td>
                                             <td>
                                                 <asp:ValidationSummary ID="ValidationSummary1" runat="server" ValidationGroup="comp" />
                                             </td>
                                             <td>&nbsp;</td>
                                             <td>&nbsp;</td>
                                         </tr>
                                     </table>
                                 </td>
                             </tr>
                             <tr class="gridtable">
                                 <td>
                                     <ig:WebDataGrid ID="WebDataGrid4" runat="server" Height="100%" Width="100%" AutoGenerateColumns="False" DataSourceID="composition" >
                                         <Columns>
                                             <ig:BoundDataField DataFieldName="TemplateCom_Pk" Key="TemplateCom_Pk"><header text="TemplateCom_Pk" /></ig:BoundDataField>
                                             <ig:BoundDataField DataFieldName="TemplateCode" Key="TemplateCode"><header text="TemplateCode" /></ig:BoundDataField>
                                             <ig:BoundDataField DataFieldName="Description" Key="Description"><header text="Description" /></ig:BoundDataField>
                                             <ig:BoundDataField DataFieldName="Composition" Key="Composition">
                                                 <Header Text="Composition">
                                                 </Header>
                                             </ig:BoundDataField>
                                         </Columns>
                                         <behaviors>
                                         <ig:Filtering></ig:Filtering>
                                         </behaviors>
                                     </ig:WebDataGrid>
                                 </td>
                             </tr>
                         </table>
                         </asp:View>
                      <asp:View ID="View4" runat="server">
                         <table class="FullTable">
                             <tr>
                                 <td>
                                     <table class="DataEntryTable">
                                         <tr>
                                             <td class="RedHeadding" colspan="5">item construction</td>
                                         </tr>
                                         <tr>
                                             <td class="NormalTD">Item </td>
                                             <td class="auto-style10">
                                                 <ig1:WebDropDown ID="drp_templateforcon" runat="server" Width="200px" CurrentValue="Select Item" DataSourceID="ItemMasterData" TextField="Description" ValueField="Template_pk"><DropDownItemBinding TextField="Description" ValueField="Template_pk" /></ig1:WebDropDown>
                                             </td>
                                             <td>
                                                 <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="drp_templateforcon" ErrorMessage="Select  Item" ForeColor="#FF3300" InitialValue="Select Item" ValidationGroup="con">*</asp:RequiredFieldValidator>
                                             </td>
                                             <td>&nbsp;</td>
                                             <td>&nbsp;</td>
                                         </tr>
                                         <tr>
                                             <td class="auto-style11">Construction</td>
                                             <td class="auto-style12">
                                                 <asp:TextBox ID="txt_construction" runat="server" Width="197px"></asp:TextBox>
                                             </td>
                                             <td class="auto-style13">
                                                 <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="txt_construction" ErrorMessage="Enter Construction" ForeColor="#FF3300" ValidationGroup="con">*</asp:RequiredFieldValidator>
                                             </td>
                                             <td class="auto-style13"></td>
                                             <td class="auto-style13"></td>
                                         </tr>
                                         <tr>
                                             <td class="NormalTD">&nbsp;</td>
                                             <td class="auto-style10">
                                                 <asp:Button ID="btn_SaveCon" runat="server" Text="Save" OnClick="btn_SaveCon_Click" ValidationGroup="con" />
                                                 <asp:SqlDataSource ID="Construction" runat="server" ConnectionString="<%$ ConnectionStrings:ArtConnectionString %>" SelectCommand="SELECT TemplateConstruction.TemplateCon_Pk, Template_Master.TemplateCode, Template_Master.Description, TemplateConstruction.Construct FROM Template_Master INNER JOIN TemplateConstruction ON Template_Master.Template_PK = TemplateConstruction.Template_Pk ORDER BY Template_Master.TemplateCode"></asp:SqlDataSource>
                                             </td>
                                             <td>
                                                 <asp:ValidationSummary ID="ValidationSummary2" runat="server" ValidationGroup="con" />
                                             </td>
                                             <td>&nbsp;</td>
                                             <td>&nbsp;</td>
                                         </tr>
                                     </table>
                                 </td>
                             </tr>
                             <tr class="gridtable">
                                 <td>
                                     <ig:WebDataGrid ID="WebDataGrid1" runat="server"  AutoGenerateColumns="False" DataSourceID="Construction" >
                                         <Columns>
                                             <ig:BoundDataField DataFieldName="TemplateCon_Pk" Key="TemplateCon_Pk">
                                                 <Header Text="TemplateCon_Pk">
                                                 </Header>
                                             </ig:BoundDataField>
                                             <ig:BoundDataField DataFieldName="TemplateCode" Key="TemplateCode">
                                                 <Header Text="TemplateCode">
                                                 </Header>
                                             </ig:BoundDataField>
                                             <ig:BoundDataField DataFieldName="Description" Key="Description">
                                                 <Header Text="Description">
                                                 </Header>
                                             </ig:BoundDataField>
                                             <ig:BoundDataField DataFieldName="Construct" Key="Construct">
                                                 <Header Text="Construct">
                                                 </Header>
                                             </ig:BoundDataField>
                                         </Columns>
                                         <Behaviors>
                                             <ig:Filtering>
                                             </ig:Filtering>
                                         </Behaviors>
                                     </ig:WebDataGrid>
                                 </td>
                             </tr>
                         </table>
                         </asp:View>


                    
                      <asp:View ID="View5" runat="server">
                         <table class="FullTable">
                             <tr>
                                 <td>
                                     <table class="DataEntryTable">
                                         <tr>
                                             <td class="RedHeadding" colspan="5">item weight</td>
                                         </tr>
                                         <tr>
                                             <td class="auto-style16">Item </td>
                                             <td class="auto-style17">
                                                 <ig1:WebDropDown ID="drp_templateweight" runat="server" Width="200px" CurrentValue="Select Item" DataSourceID="ItemMasterData" TextField="Description" ValueField="Template_pk"><DropDownItemBinding TextField="Description" ValueField="Template_pk" /></ig1:WebDropDown>
                                             </td>
                                             <td class="auto-style18">
                                                 <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="drp_templateweight" ErrorMessage="Select  Item" ForeColor="#FF3300" InitialValue="Select Item" ValidationGroup="weight">*</asp:RequiredFieldValidator>
                                             </td>
                                             <td class="auto-style18"></td>
                                             <td class="auto-style18"></td>
                                         </tr>
                                         <tr>
                                             <td class="auto-style11">Weight</td>
                                             <td class="auto-style12">
                                                 <asp:TextBox ID="txt_weight" runat="server" Width="197px"></asp:TextBox>
                                             </td>
                                             <td class="auto-style13">
                                                 <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txt_weight" ErrorMessage="Enter Construction" ForeColor="#FF3300" ValidationGroup="weight">*</asp:RequiredFieldValidator>
                                             </td>
                                             <td class="auto-style13"></td>
                                             <td class="auto-style13"></td>
                                         </tr>
                                         <tr>
                                             <td class="NormalTD">&nbsp;</td>
                                             <td class="auto-style10">
                                                 <asp:Button ID="btn_weight" runat="server" Text="Save" OnClick="btn_weight_Click" ValidationGroup="con" />
                                                 <asp:SqlDataSource ID="Weightdata" runat="server" ConnectionString="<%$ ConnectionStrings:ArtConnectionString %>" SelectCommand="SELECT TemplateWeight.TemplateWeight_Pk, Template_Master.Description, TemplateWeight.Weight, Template_Master.TemplateCode FROM Template_Master INNER JOIN TemplateWeight ON Template_Master.Template_PK = TemplateWeight.Template_Pk ORDER BY Template_Master.TemplateCode"></asp:SqlDataSource>
                                             </td>
                                             <td>
                                                 <asp:ValidationSummary ID="ValidationSummary3" runat="server" ValidationGroup="weight" />
                                             </td>
                                             <td>&nbsp;</td>
                                             <td>&nbsp;</td>
                                         </tr>
                                     </table>
                                 </td>
                             </tr>
                             <tr class="gridtable">
                                 <td>
                                     <ig:WebDataGrid ID="WebDataGrid5" runat="server" AutoGenerateColumns="False" DataSourceID="Weightdata" >
                                         <Columns>
                                             <ig:BoundDataField DataFieldName="TemplateWeight_Pk" Key="TemplateWeight_Pk">
                                                 <Header Text="TemplateWeight_Pk">
                                                 </Header>
                                             </ig:BoundDataField>
                                             <ig:BoundDataField DataFieldName="Description" Key="Description">
                                                 <Header Text="Description">
                                                 </Header>
                                             </ig:BoundDataField>
                                             <ig:BoundDataField DataFieldName="Weight" Key="Weight">
                                                 <Header Text="Weight">
                                                 </Header>
                                             </ig:BoundDataField>
                                             <ig:BoundDataField DataFieldName="TemplateCode" Key="TemplateCode">
                                                 <Header Text="TemplateCode">
                                                 </Header>
                                             </ig:BoundDataField>
                                         </Columns>
                                     </ig:WebDataGrid>
                                 </td>
                             </tr>
                         </table>
                         </asp:View>

                    
                      <asp:View ID="View6" runat="server">
                         <table class="FullTable">
                             <tr>
                                 <td>
                                     <table class="DataEntryTable">
                                         <tr>
                                             <td class="RedHeadding" colspan="5">Item Width</td>
                                         </tr>
                                         <tr>
                                             <td class="NormalTD">Item </td>
                                             <td class="auto-style10">
                                                 <ig1:WebDropDown ID="drp_templatewidth" runat="server" Width="200px" CurrentValue="Select Item" DataSourceID="ItemMasterData" TextField="Description" ValueField="Template_pk"><DropDownItemBinding TextField="Description" ValueField="Template_pk" /></ig1:WebDropDown>
                                             </td>
                                             <td>
                                                 <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ControlToValidate="drp_templatewidth" ErrorMessage="Select  Item" ForeColor="#FF3300" InitialValue="Select Item" ValidationGroup="width">*</asp:RequiredFieldValidator>
                                             </td>
                                             <td>&nbsp;</td>
                                             <td>&nbsp;</td>
                                         </tr>
                                         <tr>
                                             <td class="auto-style11">Width</td>
                                             <td class="auto-style12">
                                                 <asp:TextBox ID="txt_width" runat="server" Width="197px"></asp:TextBox>
                                             </td>
                                             <td class="auto-style13">
                                                 <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" ControlToValidate="txt_width" ErrorMessage="Enter Construction" ForeColor="#FF3300" ValidationGroup="con">*</asp:RequiredFieldValidator>
                                             </td>
                                             <td class="auto-style13"></td>
                                             <td class="auto-style13"></td>
                                         </tr>
                                         <tr>
                                             <td class="NormalTD">&nbsp;</td>
                                             <td class="auto-style10">
                                                 <asp:Button ID="btn_width" runat="server" Text="Save" OnClick="btn_width_Click" ValidationGroup="con" />
                                                 <asp:SqlDataSource ID="Widthdata" runat="server" ConnectionString="<%$ ConnectionStrings:ArtConnectionString %>" SelectCommand="SELECT TemplateWidth.TemplateWidth_Pk, Template_Master.Description, Template_Master.TemplateCode, TemplateWidth.Width FROM Template_Master INNER JOIN TemplateWidth ON Template_Master.Template_PK = TemplateWidth.Template_Pk ORDER BY Template_Master.TemplateCode"></asp:SqlDataSource>
                                             </td>
                                             <td>
                                                 <asp:ValidationSummary ID="ValidationSummary4" runat="server" ValidationGroup="con" />
                                             </td>
                                             <td>&nbsp;</td>
                                             <td>&nbsp;</td>
                                         </tr>
                                     </table>
                                 </td>
                             </tr>
                             <tr class="gridtable">
                                 <td>
                                     <ig:WebDataGrid ID="WebDataGrid6" runat="server" AutoGenerateColumns="False" DataSourceID="Widthdata" >
                                         <Columns>
                                             <ig:BoundDataField DataFieldName="TemplateWidth_Pk" Key="TemplateWidth_Pk">
                                                 <Header Text="TemplateWidth_Pk">
                                                 </Header>
                                             </ig:BoundDataField>
                                             <ig:BoundDataField DataFieldName="Description" Key="Description">
                                                 <Header Text="Description">
                                                 </Header>
                                             </ig:BoundDataField>
                                             <ig:BoundDataField DataFieldName="TemplateCode" Key="TemplateCode">
                                                 <Header Text="TemplateCode">
                                                 </Header>
                                             </ig:BoundDataField>
                                             <ig:BoundDataField DataFieldName="Width" Key="Width">
                                                 <Header Text="Width">
                                                 </Header>
                                             </ig:BoundDataField>
                                         </Columns>
                                         <Behaviors>
                                             <ig:Filtering>
                                             </ig:Filtering>
                                         </Behaviors>
                                     </ig:WebDataGrid>
                                 </td>
                             </tr>
                         </table>
                         </asp:View>

                      <asp:View ID="View7" runat="server">
                         <table class="FullTable">
                             <tr>
                                 <td>
                                     <table class="DataEntryTable">
                                         <tr>
                                             <td class="RedHeadding" colspan="5">Item Color</td>
                                         </tr>
                                         <tr>
                                             <td class="NormalTD">Item </td>
                                             <td class="auto-style10">
                                                 <ig1:WebDropDown ID="drp_Color" runat="server" Width="200px" CurrentValue="Select Item" DataSourceID="ItemMasterData" TextField="Description" ValueField="Template_pk"><DropDownItemBinding TextField="Description" ValueField="Template_pk" /></ig1:WebDropDown>
                                             </td>
                                             <td>
                                                 <asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server" ControlToValidate="drp_Color" ErrorMessage="Select  Item" ForeColor="#FF3300" InitialValue="Select Item" ValidationGroup="color">*</asp:RequiredFieldValidator>
                                             </td>
                                             <td>&nbsp;</td>
                                             <td>&nbsp;</td>
                                         </tr>
                                         <tr>
                                             <td class="auto-style11">Color</td>
                                             <td class="auto-style12">
                                                 <asp:TextBox ID="txt_color" runat="server" Width="197px"></asp:TextBox>
                                             </td>
                                             <td class="auto-style13">
                                                 <asp:RequiredFieldValidator ID="RequiredFieldValidator10" runat="server" ControlToValidate="txt_color" ErrorMessage="Enter Construction" ForeColor="#FF3300" ValidationGroup="color">*</asp:RequiredFieldValidator>
                                             </td>
                                             <td class="auto-style13"></td>
                                             <td class="auto-style13"></td>
                                         </tr>
                                         <tr>
                                             <td class="NormalTD">&nbsp;</td>
                                             <td class="auto-style10">
                                                 <asp:Button ID="Btn_Color" runat="server" Text="Save" OnClick="Btn_Color_Click" ValidationGroup="con" />
                                                 <asp:SqlDataSource ID="colordata" runat="server" ConnectionString="<%$ ConnectionStrings:ArtConnectionString %>" SelectCommand="SELECT TemplateColor.TemplateColor_PK, Template_Master.TemplateCode, Template_Master.Description, TemplateColor.TemplateColor FROM Template_Master INNER JOIN TemplateColor ON Template_Master.Template_PK = TemplateColor.Template_PK"></asp:SqlDataSource>
                                             </td>
                                             <td>
                                                 <asp:ValidationSummary ID="ValidationSummary5" runat="server" ValidationGroup="color" />
                                             </td>
                                             <td>&nbsp;</td>
                                             <td>&nbsp;</td>
                                         </tr>
                                     </table>
                                 </td>
                             </tr>
                             <tr class="gridtable">
                                 <td>
                                     <ig:WebDataGrid ID="WebDataGrid7" runat="server" AutoGenerateColumns="False" DataSourceID="colordata" >
                                         <Columns>
                                             <ig:BoundDataField DataFieldName="TemplateColor_PK" Key="TemplateColor_PK">
                                                 <Header Text="TemplateColor_PK">
                                                 </Header>
                                             </ig:BoundDataField>
                                             <ig:BoundDataField DataFieldName="TemplateCode" Key="TemplateCode">
                                                 <Header Text="TemplateCode">
                                                 </Header>
                                             </ig:BoundDataField>
                                             <ig:BoundDataField DataFieldName="Description" Key="Description">
                                                 <Header Text="Description">
                                                 </Header>
                                             </ig:BoundDataField>
                                             <ig:BoundDataField DataFieldName="TemplateColor" Key="TemplateColor">
                                                 <Header Text="TemplateColor">
                                                 </Header>
                                             </ig:BoundDataField>
                                         </Columns>
                                         <Behaviors>
                                             <ig:Filtering>
                                             </ig:Filtering>
                                         </Behaviors>
                                     </ig:WebDataGrid>
                                 </td>
                             </tr>
                         </table>
                         </asp:View>

                      <asp:View ID="View8" runat="server">
                         <table class="FullTable">
                             <tr>
                                 <td>
                                     <table class="DataEntryTable">
                                         <tr>
                                             <td class="RedHeadding" colspan="5">item size</td>
                                         </tr>
                                         <tr>
                                             <td class="NormalTD">Item </td>
                                             <td class="auto-style10">
                                                 <ig1:WebDropDown ID="drp_Size" runat="server" Width="200px" CurrentValue="Select Item" DataSourceID="ItemMasterData" TextField="Description" ValueField="Template_pk"><DropDownItemBinding TextField="Description" ValueField="Template_pk" /></ig1:WebDropDown>
                                             </td>
                                             <td>
                                                 <asp:RequiredFieldValidator ID="RequiredFieldValidator11" runat="server" ControlToValidate="drp_Size" ErrorMessage="Select  Item" ForeColor="#FF3300" InitialValue="Select Item" ValidationGroup="size">*</asp:RequiredFieldValidator>
                                             </td>
                                             <td>&nbsp;</td>
                                             <td>&nbsp;</td>
                                         </tr>
                                         <tr>
                                             <td class="auto-style11">Size</td>
                                             <td class="auto-style12">
                                                 <asp:TextBox ID="txt_size" runat="server" Width="197px"></asp:TextBox>
                                             </td>
                                             <td class="auto-style13">
                                                 <asp:RequiredFieldValidator ID="RequiredFieldValidator12" runat="server" ControlToValidate="txt_size" ErrorMessage="Enter Construction" ForeColor="#FF3300" ValidationGroup="size">*</asp:RequiredFieldValidator>
                                             </td>
                                             <td class="auto-style13"></td>
                                             <td class="auto-style13"></td>
                                         </tr>
                                         <tr>
                                             <td class="NormalTD">&nbsp;</td>
                                             <td class="auto-style10">
                                                 <asp:Button ID="btn_size" runat="server" Text="Save" OnClick="btn_size_Click" ValidationGroup="con" />
                                                 <asp:SqlDataSource ID="sizedata" runat="server" ConnectionString="<%$ ConnectionStrings:ArtConnectionString %>" SelectCommand="SELECT Template_Master.TemplateCode, Template_Master.Description, TemplateSize.TemplateSize FROM Template_Master INNER JOIN TemplateSize ON Template_Master.Template_PK = TemplateSize.Template_PK"></asp:SqlDataSource>
                                             </td>
                                             <td>
                                                 <asp:ValidationSummary ID="ValidationSummary6" runat="server" ValidationGroup="size" />
                                             </td>
                                             <td>&nbsp;</td>
                                             <td>&nbsp;</td>
                                         </tr>
                                     </table>
                                 </td>
                             </tr>
                             <tr class="gridtable">
                                 <td>
                                     <ig:WebDataGrid ID="WebDataGrid8" runat="server" AutoGenerateColumns="False" DataSourceID="sizedata" >
                                         <Columns>
                                             <ig:BoundDataField DataFieldName="TemplateCode" Key="TemplateCode">
                                                 <Header Text="TemplateCode">
                                                 </Header>
                                             </ig:BoundDataField>
                                             <ig:BoundDataField DataFieldName="Description" Key="Description">
                                                 <Header Text="Description">
                                                 </Header>
                                             </ig:BoundDataField>
                                             <ig:BoundDataField DataFieldName="TemplateSize" Key="TemplateSize">
                                                 <Header Text="TemplateSize">
                                                 </Header>
                                             </ig:BoundDataField>
                                         </Columns>
                                         <Behaviors>
                                             <ig:Filtering>
                                             </ig:Filtering>
                                         </Behaviors>
                                     </ig:WebDataGrid>
                                 </td>
                             </tr>
                         </table>
                         </asp:View>
                    <asp:View ID="View9" runat="server">
                         <table class="FullTable">
                             <tr>
                                 <td>
                                     <table class="DataEntryTable">
                                         <tr>
                                             <td class="RedHeadding" colspan="5">applicable uom</td>
                                         </tr>
                                         <tr>
                                             <td class="NormalTD">Item </td>
                                             <td class="auto-style10">
                                                 <ig1:WebDropDown ID="WebDropDown1" runat="server" Width="200px" CurrentValue="Select Item" DataSourceID="ItemMasterData" TextField="Description" ValueField="Template_pk"><DropDownItemBinding TextField="Description" ValueField="Template_pk" /></ig1:WebDropDown>
                                             </td>
                                             <td>
                                                 <asp:RequiredFieldValidator ID="RequiredFieldValidator13" runat="server" ControlToValidate="drp_Size" ErrorMessage="Select  Item" ForeColor="#FF3300" InitialValue="Select Item" ValidationGroup="size">*</asp:RequiredFieldValidator>
                                             </td>
                                             <td>&nbsp;</td>
                                             <td>&nbsp;</td>
                                         </tr>
                                         <tr>
                                             <td class="auto-style11">Applicable UOM</td>
                                             <td class="auto-style12" colspan="4">
                                                 <asp:CheckBoxList ID="CheckBoxList1" runat="server" DataSourceID="Uomdata" DataTextField="UomName" DataValueField="Uom_PK" RepeatColumns="10" Width="100%">
                                                 </asp:CheckBoxList>
                                             </td>
                                         </tr>
                                         <tr>
                                             <td class="NormalTD">&nbsp;</td>
                                             <td class="auto-style10">
                                                 <asp:Button ID="Button2" runat="server" Text="Save" OnClick="btn_size_Click" ValidationGroup="con" />
                                                 <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:ArtConnectionString %>" SelectCommand="SELECT Template_Master.TemplateCode, Template_Master.Description, TemplateSize.TemplateSize FROM Template_Master INNER JOIN TemplateSize ON Template_Master.Template_PK = TemplateSize.Template_PK"></asp:SqlDataSource>
                                             </td>
                                             <td>
                                                 <asp:ValidationSummary ID="ValidationSummary7" runat="server" ValidationGroup="size" />
                                             </td>
                                             <td>&nbsp;</td>
                                             <td>&nbsp;</td>
                                         </tr>
                                     </table>
                                 </td>
                             </tr>
                             <tr class="gridtable">
                                 <td>
                                     <ig:WebDataGrid ID="WebDataGrid9" runat="server" Height="350px" Width="400px">
                                         <Behaviors>
                                             <ig:Filtering>
                                             </ig:Filtering>
                                         </Behaviors>
                                     </ig:WebDataGrid>
                                 </td>
                             </tr>
                         </table>
                         </asp:View>
                </asp:MultiView>

                  
            </td>
        </tr>
        <tr>
            <td >
                &nbsp;</td>
        </tr>
        <tr>
            <td>
              
             
            </td>
        </tr>
    </table>
</asp:Content>

