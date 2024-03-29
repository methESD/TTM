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

namespace Time_Table_Management_System
{
    public partial class manageSession : Form
    {
        public manageSession()
        {
            InitializeComponent();
        }

        addSessionControl review = new addSessionControl();

        private void manageSession_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'tLMDataSet4.subject' table. You can move, or remove it, as needed.
            this.subjectTableAdapter.Fill(this.tLMDataSet4.subject);
            // TODO: This line of code loads data into the 'tLMDataSet3.TagTB' table. You can move, or remove it, as needed.
            this.tagTBTableAdapter.Fill(this.tLMDataSet3.TagTB);
            // TODO: This line of code loads data into the 'tLMDataSet2.StudentGroup' table. You can move, or remove it, as needed.
            this.studentGroupTableAdapter.Fill(this.tLMDataSet2.StudentGroup);
            // TODO: This line of code loads data into the 'tLMDataSet1.lecture' table. You can move, or remove it, as needed.
            this.lectureTableAdapter.Fill(this.tLMDataSet1.lecture);

            subjectView.DataSource = review.GetSessionDetails();

            reset();

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void lec_2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void group_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void subject_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void duration_TextChanged(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void no_of_student_TextChanged(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void lec_1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void lec1_tag_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void lec2_tag_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label11_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {

        }

        private void subjectView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

            sessionId.Text = subjectView.SelectedRows[0].Cells[0].Value.ToString();
            lec_1.Text = subjectView.SelectedRows[0].Cells[1].Value.ToString();
            lec1_tag.Text = subjectView.SelectedRows[0].Cells[2].Value.ToString();
            group.Text = subjectView.SelectedRows[0].Cells[3].Value.ToString();
            subject.Text = subjectView.SelectedRows[0].Cells[4].Value.ToString();
            no_of_student.Text = subjectView.SelectedRows[0].Cells[5].Value.ToString();
            duration.Text = subjectView.SelectedRows[0].Cells[6].Value.ToString();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            addSessionControl delete = new addSessionControl();
            delete.deleteRow(int.Parse(sessionId.Text));
            reset();
            subjectView.DataSource = review.GetSessionDetails();

        }

        private void reset()
        {
            sessionId.Clear();
            lec_1.SelectedIndex = -1;
            lec_2.SelectedIndex = -1;
            lec1_tag.SelectedIndex = -1;
            group.SelectedIndex = -1;
            subject.SelectedIndex = -1;
            no_of_student.Clear();
            duration.Clear();

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            reset();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            addSessionControl edit_ses = new addSessionControl();

            edit_ses.updateSession(lec_1.Text, lec_2.Text, lec1_tag.Text, group.Text, subject.Text,int.Parse(no_of_student.Text),decimal.Parse(duration.Text),int.Parse(sessionId.Text));
            subjectView.DataSource = review.GetSessionDetails();
            reset();
        }

        private void search_value_TextChanged(object sender, EventArgs e)
        {
            addSessionControl srch = new addSessionControl();

            string srchValu = search_value.Text;

            if (srchValu == null)
            {


                subjectView.DataSource = review.GetSessionDetails();

            }
            else
            {

                subjectView.DataSource = srch.searchData(search_value.Text);

            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            addSessionControl srch = new addSessionControl();
            subjectView.DataSource = srch.searchData(search_value.Text);
        }
    }
}
