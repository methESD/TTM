﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Time_Table_Management_System.DBConnection;
using Time_Table_Management_System.Model;

namespace Time_Table_Management_System.Controller
{
    class AddWorkingDaysControl
    {
        DBcon DBConnection = new DBcon();
        SqlConnection con = new SqlConnection();

        public AddWorkingDaysControl()
        {
            con = DBConnection.getDBConnection();
        }

        //Insert queries

        public void insertaddWorkingDetails(AddWorkingDaysModel workingMod)
        {
            if (con.State.ToString() != "Open")
            {
                con.Open();
            }
           string query = "INSERT INTO WorkingDays(NoOfWorkingDays,StratTime,EndTime,TimeSlot)" + "VALUES ('" + workingMod.noOfWorkingDays + "','" + workingMod.startTime + "','" + workingMod.endTime + "','" + workingMod.timeSlot + "')";
            
            SqlCommand cmd = new SqlCommand(query, con);

            cmd.ExecuteNonQuery();

            MessageBox.Show("Successfully Inserted");
           
            con.Close(); 
        }

        //Retrive queries

        public DataTable getworkingdaysvalues( )
        {
            if (con.State.ToString() != "Open")
            {
                con.Open();
            }

            DataTable dtbuilding = new DataTable();

            string query = "select * from WorkingDays";

            SqlDataReader dr1 = new SqlCommand(query, con).ExecuteReader();

            dtbuilding.Load(dr1);
            return dtbuilding;
        }


        //Delete queries

        public void deleteWorkingDetails(string id)
        {
            if (con.State.ToString() != "Open")
            {
                con.Open();
            }

            string query = "DELETE FROM WorkingDays WHERE WorkId= '" + id + "' ";

            SqlCommand com = new SqlCommand(query, con);

            string ans = MessageBox.Show("Are sure to delete this record?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning).ToString();

            if (ans == "Yes")
            {
                com.ExecuteNonQuery();
                MessageBox.Show(" Records Successfully Deleted");

            }
            con.Close();


        }

        //Update queries

        public void updateworkingdaysDetails(AddWorkingDaysModel workingMod)
        {
            if (con.State.ToString() != "Open")
            {
                con.Open();
            }
            string query = "update WorkingDays set NoOfWorkingDays ='" + workingMod.noOfWorkingDays + "',StratTime='" + workingMod.startTime + "', EndTime ='" + workingMod.endTime + "',TimeSlot='" + workingMod.timeSlot + "'  where WorkId = '" + workingMod.id + "' ";

            SqlCommand com = new SqlCommand(query, con);
            com.ExecuteNonQuery();

            MessageBox.Show("Successfully Updated");

            con.Close();

        }


      
    }
}
