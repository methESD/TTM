﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Time_Table_Management_System.DBConnection;
using Time_Table_Management_System.Model;
using Time_Table_Management_System.Controller;
using System.Data.SqlClient;

namespace Time_Table_Management_System
{
    public partial class nonOverlap : Form
    {
        DBcon DBConnection = new DBcon();
        SqlConnection con = new SqlConnection();

        public nonOverlap()
        {
            InitializeComponent();
            con = DBConnection.getDBConnection();
        }

        SessionController sesControl = new SessionController();
        SessionModel sesMode = new SessionModel();


        public void RetrieveDetails()
        {
            con.Open();

            String RetrieveQuery = "select N.Nid as NID, S.* from session S, NonOverlapTB N WHERE N.Sid = S.sesId";
            SqlCommand cmd = new SqlCommand(RetrieveQuery, con);
            cmd.CommandType = CommandType.Text;

            SqlDataAdapter DA = new SqlDataAdapter(cmd);
            DataTable DT = new DataTable();
            DA.Fill(DT);
            this.NonTb.DataSource = DT;

            con.Close();



        }


        public void DeleteDB(String Id, String sts)
        {
            sesControl.deleteSessionData(Id, sts);
            RetrieveDetails();
        }


        private void dlt_Click(object sender, EventArgs e)
        {
            this.DeleteDB(this.NOID.Text, "NonOverlapping");
        }

        private void nonOverlap_Load(object sender, EventArgs e)
        {
            this.RetrieveDetails();
        }

        private void back_Click(object sender, EventArgs e)
        {
            
        }
    }
}
