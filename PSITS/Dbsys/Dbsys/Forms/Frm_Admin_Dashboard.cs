﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Dbsys.AppData;

namespace Dbsys.Forms
{
    public partial class Frm_Admin_Dashboard : Form
    {
        UserRepository userRepo;
        public Frm_Admin_Dashboard()
        {
            InitializeComponent();
            //
            userRepo = new UserRepository();

            loadEvents();
            loadMisc();
        }

        public void loadEvents()
        {
            dgvEvent.DataSource = userRepo.ShowEvents();
            dgvEvent.Columns["eventId"].Visible = false;
        }

        public void loadMisc()
        {
            dgvMisc.DataSource = userRepo.ShowMisc();
            dgvMisc.Columns["miscId"].Visible = false;
        }

        private void Frm_Admin_Dashboard_Load(object sender, EventArgs e)
        {
            dgv_main.DataSource = userRepo.AllUserRole();
            // Set User Login From Singleton
            toolStripUserText.Text = UserLogged.GetInstance().UserAccount.userName;
            //
        }

        private void createUserToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (var frm = new Frm_UserEntry())
            {
                frm.ShowDialog();
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void Frm_Admin_Dashboard_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void eventToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new Frm_Add_Event_For_Admin().Show();
            this.Hide();
        }

        private void miscToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new Frm_Add_Misc_For_Admin().Show();
            this.Hide();
        }

        private void studentStatusToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new Frm_Student_Status().Show();
        }

        private void dgvEvent_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void logoutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new Frm_Login().Show();
            this.Hide();
        }

        private void createToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void eventToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            new Frm_Edit_Event().Show();
            this.Hide();
        }

        private void miscToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            new Frm_Edit_Misc().Show();
            this.Hide();
        }
    }
}
