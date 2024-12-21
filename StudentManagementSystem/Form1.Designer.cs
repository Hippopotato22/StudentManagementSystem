namespace StudentManagementSystem
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            cmbGender = new ComboBox();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            txtFirstName = new TextBox();
            txtLastName = new TextBox();
            datePickerDOB = new DateTimePicker();
            btnAdd = new Button();
            btnUpdate = new Button();
            btnDelete = new Button();
            btnViewGrades = new Button();
            dataGridViewStudents = new DataGridView();
            Grade = new Label();
            btnCloseDataGridView = new Button();
            pictureBoxProfile = new PictureBox();
            btnUploadPicture = new Button();
            btnResetPicture = new Button();
            cmbGradeLevel = new ComboBox();
            ((System.ComponentModel.ISupportInitialize)dataGridViewStudents).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBoxProfile).BeginInit();
            SuspendLayout();
            // 
            // cmbGender
            // 
            cmbGender.BackColor = Color.FromArgb(243, 230, 204);
            cmbGender.ForeColor = Color.FromArgb(111, 78, 55);
            cmbGender.FormattingEnabled = true;
            cmbGender.Items.AddRange(new object[] { "Male", "Female", "other" });
            cmbGender.Location = new Point(118, 182);
            cmbGender.Name = "cmbGender";
            cmbGender.Size = new Size(121, 23);
            cmbGender.TabIndex = 0;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold);
            label1.Location = new Point(26, 32);
            label1.Name = "label1";
            label1.Size = new Size(75, 17);
            label1.TabIndex = 1;
            label1.Text = "First Name";
            label1.Click += label1_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold);
            label2.Location = new Point(26, 79);
            label2.Name = "label2";
            label2.Size = new Size(73, 17);
            label2.TabIndex = 2;
            label2.Text = "Last Name";
            label2.Click += label2_Click;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold);
            label3.Location = new Point(26, 136);
            label3.Name = "label3";
            label3.Size = new Size(88, 17);
            label3.TabIndex = 3;
            label3.Text = "Date of Birth";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold);
            label4.Location = new Point(26, 182);
            label4.Name = "label4";
            label4.Size = new Size(57, 17);
            label4.TabIndex = 4;
            label4.Text = "Gender:";
            // 
            // txtFirstName
            // 
            txtFirstName.BackColor = Color.FromArgb(243, 230, 204);
            txtFirstName.ForeColor = Color.FromArgb(111, 78, 55);
            txtFirstName.Location = new Point(118, 32);
            txtFirstName.Name = "txtFirstName";
            txtFirstName.Size = new Size(100, 23);
            txtFirstName.TabIndex = 5;
            txtFirstName.TextChanged += textBox1_TextChanged;
            // 
            // txtLastName
            // 
            txtLastName.BackColor = Color.FromArgb(243, 230, 204);
            txtLastName.ForeColor = Color.FromArgb(111, 78, 55);
            txtLastName.Location = new Point(118, 71);
            txtLastName.Name = "txtLastName";
            txtLastName.Size = new Size(100, 23);
            txtLastName.TabIndex = 6;
            txtLastName.TextChanged += textLastName_TextChanged;
            // 
            // datePickerDOB
            // 
            datePickerDOB.CalendarForeColor = Color.FromArgb(111, 78, 55);
            datePickerDOB.CalendarMonthBackground = Color.FromArgb(243, 230, 204);
            datePickerDOB.Location = new Point(118, 130);
            datePickerDOB.Name = "datePickerDOB";
            datePickerDOB.Size = new Size(200, 23);
            datePickerDOB.TabIndex = 7;
            // 
            // btnAdd
            // 
            btnAdd.BackColor = Color.FromArgb(181, 136, 99);
            btnAdd.ForeColor = Color.FromArgb(243, 230, 204);
            btnAdd.Location = new Point(439, 26);
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new Size(75, 23);
            btnAdd.TabIndex = 8;
            btnAdd.Text = "Add Student";
            btnAdd.UseVisualStyleBackColor = false;
            btnAdd.Click += btnAdd_Click;
            btnAdd.MouseEnter += btnAdd_MouseEnter;
            btnAdd.MouseLeave += btnAdd_MouseLeave;
            // 
            // btnUpdate
            // 
            btnUpdate.BackColor = Color.FromArgb(181, 136, 99);
            btnUpdate.ForeColor = Color.FromArgb(243, 230, 204);
            btnUpdate.Location = new Point(439, 79);
            btnUpdate.Name = "btnUpdate";
            btnUpdate.Size = new Size(75, 23);
            btnUpdate.TabIndex = 9;
            btnUpdate.Text = "Update Student";
            btnUpdate.UseVisualStyleBackColor = false;
            btnUpdate.Click += btnUpdate_Click;
            // 
            // btnDelete
            // 
            btnDelete.BackColor = Color.FromArgb(181, 136, 99);
            btnDelete.ForeColor = Color.FromArgb(243, 230, 204);
            btnDelete.Location = new Point(439, 130);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(75, 23);
            btnDelete.TabIndex = 10;
            btnDelete.Text = "Delete Student";
            btnDelete.UseVisualStyleBackColor = false;
            btnDelete.Click += btnDelete_Click;
            // 
            // btnViewGrades
            // 
            btnViewGrades.BackColor = Color.FromArgb(181, 136, 99);
            btnViewGrades.ForeColor = Color.FromArgb(243, 230, 204);
            btnViewGrades.Location = new Point(439, 176);
            btnViewGrades.Name = "btnViewGrades";
            btnViewGrades.Size = new Size(75, 23);
            btnViewGrades.TabIndex = 11;
            btnViewGrades.Text = "View Average Grades";
            btnViewGrades.UseVisualStyleBackColor = false;
            btnViewGrades.Click += btnViewGrades_Click;
            // 
            // dataGridViewStudents
            // 
            dataGridViewStudents.BackgroundColor = Color.FromArgb(243, 230, 204);
            dataGridViewStudents.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewStudents.Dock = DockStyle.Bottom;
            dataGridViewStudents.GridColor = SystemColors.WindowText;
            dataGridViewStudents.Location = new Point(0, 224);
            dataGridViewStudents.Name = "dataGridViewStudents";
            dataGridViewStudents.ReadOnly = true;
            dataGridViewStudents.Size = new Size(800, 226);
            dataGridViewStudents.TabIndex = 12;
            dataGridViewStudents.CellContentClick += dataGridViewStudents_CellContentClick;
            dataGridViewStudents.SelectionChanged += dataGridViewStudents_SelectionChanged;
            // 
            // Grade
            // 
            Grade.AutoSize = true;
            Grade.Location = new Point(265, 185);
            Grade.Name = "Grade";
            Grade.Size = new Size(38, 15);
            Grade.TabIndex = 13;
            Grade.Text = "Grade";
            Grade.Click += label5_Click;
            // 
            // btnCloseDataGridView
            // 
            btnCloseDataGridView.BackColor = Color.Red;
            btnCloseDataGridView.ForeColor = SystemColors.ControlLightLight;
            btnCloseDataGridView.Location = new Point(725, 224);
            btnCloseDataGridView.Name = "btnCloseDataGridView";
            btnCloseDataGridView.Size = new Size(75, 38);
            btnCloseDataGridView.TabIndex = 16;
            btnCloseDataGridView.Text = "Close";
            btnCloseDataGridView.UseVisualStyleBackColor = false;
            btnCloseDataGridView.Click += btnCloseDataGridView_Click;
            // 
            // pictureBoxProfile
            // 
            pictureBoxProfile.Location = new Point(603, 26);
            pictureBoxProfile.Name = "pictureBoxProfile";
            pictureBoxProfile.Size = new Size(170, 143);
            pictureBoxProfile.TabIndex = 17;
            pictureBoxProfile.TabStop = false;
            // 
            // btnUploadPicture
            // 
            btnUploadPicture.FlatStyle = FlatStyle.System;
            btnUploadPicture.ForeColor = SystemColors.ButtonHighlight;
            btnUploadPicture.Location = new Point(603, 177);
            btnUploadPicture.Name = "btnUploadPicture";
            btnUploadPicture.Size = new Size(88, 23);
            btnUploadPicture.TabIndex = 18;
            btnUploadPicture.Text = "Profile Picture";
            btnUploadPicture.UseVisualStyleBackColor = true;
            btnUploadPicture.Click += btnUploadPicture_Click;
            // 
            // btnResetPicture
            // 
            btnResetPicture.ForeColor = SystemColors.ActiveCaptionText;
            btnResetPicture.Location = new Point(698, 176);
            btnResetPicture.Name = "btnResetPicture";
            btnResetPicture.Size = new Size(75, 23);
            btnResetPicture.TabIndex = 19;
            btnResetPicture.Text = "Reset Profile";
            btnResetPicture.UseVisualStyleBackColor = true;
            btnResetPicture.Click += btnResetPicture_Click_1;
            // 
            // cmbGradeLevel
            // 
            cmbGradeLevel.DisplayMember = "GradeID";
            cmbGradeLevel.FormattingEnabled = true;
            cmbGradeLevel.Location = new Point(309, 181);
            cmbGradeLevel.Name = "cmbGradeLevel";
            cmbGradeLevel.Size = new Size(121, 23);
            cmbGradeLevel.TabIndex = 20;
            cmbGradeLevel.ValueMember = "GradeID";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.SaddleBrown;
            ClientSize = new Size(800, 450);
            Controls.Add(cmbGradeLevel);
            Controls.Add(btnResetPicture);
            Controls.Add(btnUploadPicture);
            Controls.Add(pictureBoxProfile);
            Controls.Add(btnCloseDataGridView);
            Controls.Add(Grade);
            Controls.Add(btnViewGrades);
            Controls.Add(btnDelete);
            Controls.Add(btnUpdate);
            Controls.Add(btnAdd);
            Controls.Add(datePickerDOB);
            Controls.Add(txtLastName);
            Controls.Add(txtFirstName);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(cmbGender);
            Controls.Add(dataGridViewStudents);
            ForeColor = SystemColors.ButtonHighlight;
            Name = "Form1";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Student Management System";
            Load += Form1_Load;
            Click += d;
            ((System.ComponentModel.ISupportInitialize)dataGridViewStudents).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBoxProfile).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ComboBox cmbGender;
        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private TextBox txtFirstName;
        private TextBox txtLastName;
        private DateTimePicker datePickerDOB;
        private Button btnAdd;
        private Button btnUpdate;
        private Button btnDelete;
        private Button btnViewGrades;
        private DataGridView dataGridViewStudents;
        private Label Grade;
        private Button btnCloseDataGridView;
        private PictureBox pictureBoxProfile;
        private Button btnUploadPicture;
        private Button btnResetPicture;
        private ComboBox cmbGradeLevel;
    }
}
