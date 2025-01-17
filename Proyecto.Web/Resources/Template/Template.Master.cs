﻿using System;

namespace Proyecto.Web.Resources.Template
{
    public partial class Template : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string[] stEmail = null;
                if (Session["sessionEmail"] != null)
                {
                    stEmail = Session["sessionEmail"].ToString().Split('@');
                    lblUsuario.Text = stEmail[0];
                }
                else
                {
                    Response.Redirect("../../Views/Login/Login.aspx");
                }
            }
        }

        protected void lbSalir_Click(object sender, EventArgs e)
        {
            //Session.Remove("sessionEmail");//Elimina variable de sesión
            Session.RemoveAll();
            Response.Redirect("../../Views/Login/Login.aspx");
        }
    }
}