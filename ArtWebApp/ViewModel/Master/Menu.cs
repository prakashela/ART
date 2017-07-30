﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ArtWebApp.ViewModel.Master
{
    public class Menu
    {
    }

    public class UserMenu
    {
        public Decimal itemmenupk { get; set; }

        public SubMenusiewModal SubMenusiewModal
        {
            get
            {
                return new SubMenusiewModal(this.itemmenupk);
            }

            set
            {
                subMenusiewModal = value;
            }
        }

        private SubMenusiewModal subMenusiewModal;




    }

    public class MenuViewModal
    {

        public decimal Menu_PK { get; set; }
        public string MenuText { get; set; }
        public string MenuURL { get; set; }
        public Nullable<decimal> ParentID { get; set; }
        public string isEnable { get; set; }
        public string IsNormal { get; set; }
        public string MVCURL { get; set; }
        public string Description { get; set; }
    }

    public class SubMenusiewModal
    {
        public SubMenusiewModal(Decimal parentid)
        {
            this.Menu_PK = parentid;

        }

        public decimal? Menu_PK { get; set; }

        public IEnumerable<MenuViewModal> MenuList
        {
            get
            {
                return GetSubMenuofItem(this.Menu_PK);
            }

            set
            {
                menuList = value;
            }
        }

        private IEnumerable<MenuViewModal> menuList;

        public IEnumerable<MenuViewModal> GetSubMenuofItem(Decimal? menu_pk)
        {
            List<MenuViewModal> menuViewModalList = new List<MenuViewModal>();


            foreach (var element in ArtDAL.Masters.MenuDal.GetsubMenulist(menu_pk))
            {


                MenuViewModal menuViewModel = new MenuViewModal();

                menuViewModel.Menu_PK = element.Menu_PK;
                menuViewModel.MenuText = element.MenuText;
                menuViewModel.MenuURL = element.MenuURL;
                menuViewModel.ParentID = element.ParentID;
                menuViewModel.isEnable = element.isEnable;
                menuViewModel.IsNormal = element.IsNormal;
                menuViewModel.Description = element.Description;
                menuViewModel.MVCURL = element.MVCURL;
                menuViewModalList.Add(menuViewModel);
            }


            return menuViewModalList;
        }

    }
}