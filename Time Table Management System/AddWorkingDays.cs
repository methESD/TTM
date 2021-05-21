﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Time_Table_Management_System.Controller;
using Time_Table_Management_System.Model;
using Time_Table_Management_System.DBConnection;

namespace Time_Table_Management_System
{
    public partial class AddWorkingDays : Form
    {
        public AddWorkingDays()
        {
            InitializeComponent();
        }
        AddWorkingDaysControl addcontrol = new AddWorkingDaysControl();
        AddWorkingDaysModel AddWorkingDaysModel = new AddWorkingDaysModel();



        private void btnadd_Click_1(object sender, EventArgs e)
        {
            if (textBox1.Text == "")
            {
                MessageBox.Show("Enter Employee id");
                if (comboBox1.Text == "") MessageBox.Show("Select No of Working Days ");
                if (comboBox2.Text == "") MessageBox.Show("Working Days ");
                if (comboBox3.Text == "") MessageBox.Show("Working Time Per Dyas");
                if (comboBox4.Text == "") MessageBox.Show("Select No of Working Days ");
                if (comboBox5.Text == "") MessageBox.Show("Select No of Working Days ");




            }
            else
            {
                AddWorkingDaysModel.employeeId = int.Parse(textBox1.Text);
                AddWorkingDaysModel.noOfWorkingDays = int.Parse(comboBox1.Text);
                AddWorkingDaysModel.workingDays = comboBox2.Text;

                AddWorkingDaysModel.WorkingTimePerDay = comboBox3.Text;
                AddWorkingDaysModel.startTime = comboBox4.Text;
                AddWorkingDaysModel.timeSlot = comboBox5.Text;


                addcontrol.insertaddWorkingDetails(AddWorkingDaysModel);


                dataview.DataSource = addcontrol.getworkingdaysvalues();

                textBox1.Text = "";
                comboBox1.Text = "";
                comboBox2.Text = "";
                comboBox3.Text = "";
                comboBox4.Text = "";
                comboBox5.Text = "";

            }

        }

        private void btndelete_Click(object sender, EventArgs e)
        {
            int x = int.Parse(Aid.Text);
            addcontrol.deleteWorkingDetails(x);
            Aid.Text = "";

            dataview.DataSource = addcontrol.getworkingdaysvalues();

            textBox1.Text = "";
            comboBox1.Text = "";
            comboBox2.Text = "";
            comboBox3.Text = "";
            comboBox4.Text = "";
            comboBox5.Text = "";

        }

        private void btnupdate_Click(object sender, EventArgs e)
        {


            if (textBox1.Text == "") MessageBox.Show("Enter Employye id");
            if (comboBox1.Text == "") MessageBox.Show("Select No of Working Days ");
            if (comboBox2.Text == "") MessageBox.Show("Working Days ");
            if (comboBox3.Text == "") MessageBox.Show("Working Time Per Dyas");
            if (comboBox4.Text == "") MessageBox.Show("Select No of Working Days ");
            if (comboBox5.Text == "") MessageBox.Show("Select No of Working Days ");

            AddWorkingDaysModel.id = int.Parse(Aid.Text);
            AddWorkingDaysModel.employeeId = int.Parse(textBox1.Text);
            AddWorkingDaysModel.noOfWorkingDays = int.Parse(comboBox1.Text);
            AddWorkingDaysModel.workingDays = comboBox2.Text;

            AddWorkingDaysModel.WorkingTimePerDay = comboBox3.Text;
            AddWorkingDaysModel.startTime = comboBox4.Text;
            AddWorkingDaysModel.timeSlot = comboBox5.Text;

            addcontrol.updateworkingdaysDetails(AddWorkingDaysModel);

            dataview.DataSource = addcontrol.getworkingdaysvalues();

            Aid.Text = "";
            textBox1.Text = "";
            comboBox1.Text = "";
            comboBox2.Text = "";
            comboBox3.Text = "";
            comboBox4.Text = "";
            comboBox5.Text = "";

        }



        private void AddWorkingDays_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'tLMDataSet1.lecture' table. You can move, or remove it, as needed.
            this.lectureTableAdapter.Fill(this.tLMDataSet1.lecture);

            dataview.DataSource = addcontrol.getworkingdaysvalues();
        }


        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void comboBox5_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void bunifuDataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
          
        }

        private void dataview_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                {
                    if (e.RowIndex >= 0)
                    {

                        DataGridViewRow row = this.dataview.Rows[e.RowIndex];

                        Aid.Text = row.Cells["WorkId"].Value.ToString();
                        textBox1.Text = row.Cells["EmployeeId"].Value.ToString();
                        comboBox1.Text = row.Cells["NoOfWorkingDays"].Value.ToString();
                        comboBox2.Text = row.Cells["WorkingDays"].Value.ToString();
                        comboBox3.Text = row.Cells["WorkingTime"].Value.ToString();
                        comboBox4.Text = row.Cells["StratTime"].Value.ToString();
                        comboBox5.Text = row.Cells["TimeSlot"].Value.ToString();




                    }




                }
            }
        }
    }
}
    
