using System;
using System.Data;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

using StudentManagementSystem;

//private DatabaseManager dbManager = new DatabaseManager();


namespace StudentManagementSystem
{




    public partial class Form1 : Form
    {
        private DatabaseManager dbManager;


        public Form1()
        {
            InitializeComponent();
            dbManager = new DatabaseManager();

            dataGridViewStudents.SelectionChanged += DataGridViewStudents_SelectionChanged;


            // Hide the DataGridView and control buttons initially
            dataGridViewStudents.Visible = false;
            btnCloseDataGridView.Visible = false;

            pictureBoxProfile.Image = Image.FromFile(@"D:\VisualStudyo\StudentManagementSystem\StudentManagementSystem\Resources\default_profile_picture.jpg");
            // Default image on form load





        }






        private void btnViewGrades_Click(object sender, EventArgs e)
        {
            if (!dataGridViewStudents.Visible)
            {
                // Show the DataGridView and load the students
                ViewStudents();
                dataGridViewStudents.Visible = true;

                // Show the control buttons
                btnCloseDataGridView.Visible = true;



            }
            else
            {
                // The DataGridView is already visible, provide options to close it
                MessageBox.Show("Choose an option to proceed.");
            }
        }

        private void btnCloseDataGridView_Click(object sender, EventArgs e)
        {
            dataGridViewStudents.Visible = false;
            btnCloseDataGridView.Visible = false;

        }





        private void btnAdd_Click(object sender, EventArgs e)
        {
            // Validate input fields
            if (string.IsNullOrWhiteSpace(txtFirstName.Text))
            {
                MessageBox.Show("Please enter the first name.", "Missing Information", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtFirstName.Focus();
                return;
            }

            if (string.IsNullOrWhiteSpace(txtLastName.Text))
            {
                MessageBox.Show("Please enter the last name.", "Missing Information", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtLastName.Focus();
                return;
            }

            if (cmbGender.SelectedItem == null || string.IsNullOrWhiteSpace(cmbGender.SelectedItem.ToString()))
            {
                MessageBox.Show("Please select a gender.", "Missing Information", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cmbGender.Focus();
                return;
            }

            if (cmbGradeLevel.SelectedValue == null || (int)cmbGradeLevel.SelectedValue <= 0)
            {
                MessageBox.Show("Please select a grade level.", "Missing Information", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cmbGradeLevel.Focus();
                return;
            }

            // If all fields are valid, proceed to add the student
            int gradeId = (int)cmbGradeLevel.SelectedValue; // Get the selected grade ID
            AddStudent(txtFirstName.Text, txtLastName.Text, datePickerDOB.Value.ToString("yyyy-MM-dd"), cmbGender.SelectedItem.ToString(), gradeId);
        }





        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (dataGridViewStudents.CurrentRow == null)
            {
                MessageBox.Show("Please select a student to update.");
                return;
            }

            int studentId = int.Parse(dataGridViewStudents.CurrentRow.Cells["StudentID"].Value.ToString());
            int gradeId = (int)cmbGradeLevel.SelectedValue; // Get the selected grade ID
            UpdateStudent(studentId, txtFirstName.Text, txtLastName.Text, datePickerDOB.Value.ToString("yyyy-MM-dd"), cmbGender.SelectedItem.ToString(), gradeId);
        }


        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dataGridViewStudents.CurrentRow == null)
            {
                MessageBox.Show("Please select a student to delete.");
                return;
            }

            int studentId = int.Parse(dataGridViewStudents.CurrentRow.Cells["StudentID"].Value.ToString());

            DialogResult result = MessageBox.Show("Are you sure you want to delete this student?", "Confirm Deletion", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (result == DialogResult.Yes)
            {
                DeleteStudent(studentId);
            }
        }


        private void Form1_Load(object sender, EventArgs e)
        {
            // Load the grades into the ComboBox
            LoadGradeLevels();

            // Load the students
            LoadStudents();


        }

        private void LoadGradeLevels()
        {
            string query = "SELECT GradeID, GradeLevel FROM Grades";

            try
            {
                DataTable gradesTable = dbManager.ExecuteQueryWithResults(query);
                cmbGradeLevel.DataSource = gradesTable;
                cmbGradeLevel.DisplayMember = "GradeLevel";  // Display grade level
                cmbGradeLevel.ValueMember = "GradeID";      // Use GradeID as the value
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred while loading grades: {ex.Message}");
            }
        }




        private void DataGridViewStudents_SelectionChanged(object sender, EventArgs e)
        {
            if (dataGridViewStudents.CurrentRow != null && dataGridViewStudents.CurrentRow.Index >= 0)
            {
                // Get the selected row
                DataGridViewRow selectedRow = dataGridViewStudents.CurrentRow;

                // Populate form fields with the selected row's values
                txtFirstName.Text = selectedRow.Cells["FirstName"].Value?.ToString();
                txtLastName.Text = selectedRow.Cells["LastName"].Value?.ToString();
                if (DateTime.TryParse(selectedRow.Cells["DOB"].Value?.ToString(), out DateTime parsedDate))
                {
                    datePickerDOB.Value = parsedDate;
                }
                else
                {
                    datePickerDOB.Value = DateTime.Now;
                }
                cmbGender.Text = selectedRow.Cells["Gender"].Value?.ToString();

                // Set ComboBox grade selection by matching GradeID
                string GradeID = selectedRow.Cells["GradeID"].Value?.ToString();
                if (!string.IsNullOrEmpty(GradeID))
                {
                    cmbGradeLevel.SelectedValue = GradeID;  // Match GradeID to select the grade
                }

                // Get the student ID
                string studentId = selectedRow.Cells["StudentID"].Value.ToString();

                // Display the profile picture for the selected student
                DisplayProfilePicture(studentId);
            }
        }





        private void LoadStudents()
        {
            // Modify the query to get GradeID from Enrollments and GradeLevel from Grades
            string query = @"SELECT s.StudentID, s.FirstName, s.LastName, s.DOB, s.Gender, 
                            e.GradeID, g.GradeLevel 
                     FROM Students s
                     INNER JOIN Enrollments e ON s.StudentID = e.StudentID
                     INNER JOIN Grades g ON e.GradeID = g.GradeID";

            try
            {
                // Execute the query and get the results
                DataTable dtStudents = dbManager.ExecuteQueryWithResults(query);
                dataGridViewStudents.DataSource = dtStudents;

                // Adjust column headers
                dataGridViewStudents.Columns["StudentID"].HeaderText = "ID";
                dataGridViewStudents.Columns["FirstName"].HeaderText = "First Name";
                dataGridViewStudents.Columns["LastName"].HeaderText = "Last Name";
                dataGridViewStudents.Columns["DOB"].HeaderText = "Date of Birth";
                dataGridViewStudents.Columns["Gender"].HeaderText = "Gender";
                dataGridViewStudents.Columns["GradeLevel"].HeaderText = "Grade";  // GradeLevel will be displayed

                // Optionally hide the GradeID column if not needed
                dataGridViewStudents.Columns["GradeID"].Visible = true;

            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred while loading students: {ex.Message}");
            }
        }



        private void PopulateGradeComboBox()
        {
            string query = "SELECT GradeID, GradeLevel FROM Grades";
            DataTable gradeTable = dbManager.ExecuteQueryWithResults(query);

            cmbGradeLevel.DisplayMember = "GradeLevel";  // The value to display in the ComboBox
            cmbGradeLevel.ValueMember = "GradeID";      // The value that represents the selected item

            cmbGradeLevel.DataSource = gradeTable;
        }






        private void AddStudent(string firstName, string lastName, string dob, string gender, int gradeId)
        {
            if (string.IsNullOrWhiteSpace(firstName) || string.IsNullOrWhiteSpace(lastName) || string.IsNullOrWhiteSpace(gender) || gradeId <= 0)
            {
                MessageBox.Show("Please fill in all the fields.");
                return;
            }

            // Check if the student already exists in the database
            string checkQuery = "SELECT COUNT(*) FROM Students WHERE FirstName = @FirstName AND LastName = @LastName AND DOB = @DOB";
            MySqlParameter[] checkParams = {
        new MySqlParameter("@FirstName", firstName),
        new MySqlParameter("@LastName", lastName),
        new MySqlParameter("@DOB", dob)
    };

            try
            {
                int studentExists = Convert.ToInt32(dbManager.ExecuteQueryWithResults(checkQuery, checkParams).Rows[0][0]);

                if (studentExists > 0)
                {
                    MessageBox.Show("This student already exists in the database.");
                    return;
                }

                // Proceed with adding the student if they don't already exist
                string query = "INSERT INTO Students (FirstName, LastName, DOB, Gender) VALUES (@FirstName, @LastName, @DOB, @Gender)";
                MySqlParameter[] parameters = {
            new MySqlParameter("@FirstName", firstName),
            new MySqlParameter("@LastName", lastName),
            new MySqlParameter("@DOB", dob),
            new MySqlParameter("@Gender", gender)
        };

                int result = dbManager.ExecuteQuery(query, parameters);

                if (result > 0)
                {
                    // Get the newly inserted student's ID
                    string selectIdQuery = "SELECT LAST_INSERT_ID()";
                    int studentId = Convert.ToInt32(dbManager.ExecuteQueryWithResults(selectIdQuery).Rows[0][0]);

                    // Insert into the Enrollments table
                    string enrollQuery = "INSERT INTO Enrollments (StudentID, GradeID) VALUES (@StudentID, @GradeID)";
                    MySqlParameter[] enrollParams = {
                new MySqlParameter("@StudentID", studentId),
                new MySqlParameter("@GradeID", gradeId)
            };

                    dbManager.ExecuteQuery(enrollQuery, enrollParams);

                    MessageBox.Show("Student added and enrolled successfully!");
                    LoadStudents(); // Refresh the DataGridView to reflect changes
                }
                else
                {
                    MessageBox.Show("Failed to add student.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}");
            }
        }



        private void UpdateStudent(int studentId, string firstName, string lastName, string dob, string gender, int gradeId)
        {
            if (studentId <= 0 || string.IsNullOrWhiteSpace(firstName) || string.IsNullOrWhiteSpace(lastName) || string.IsNullOrWhiteSpace(gender) || gradeId <= 0)
            {
                MessageBox.Show("Please provide valid input for all fields.");
                return;
            }

            string query = "UPDATE Students SET FirstName = @FirstName, LastName = @LastName, DOB = @DOB, Gender = @Gender WHERE StudentID = @StudentID";

            MySqlParameter[] parameters = {
        new MySqlParameter("@StudentID", studentId),
        new MySqlParameter("@FirstName", firstName),
        new MySqlParameter("@LastName", lastName),
        new MySqlParameter("@DOB", dob),
        new MySqlParameter("@Gender", gender)
    };

            try
            {
                int result = dbManager.ExecuteQuery(query, parameters);

                if (result > 0)
                {
                    // Update grade in Enrollments table
                    string enrollQuery = "UPDATE Enrollments SET GradeID = @GradeID WHERE StudentID = @StudentID";
                    MySqlParameter[] enrollParams = {
                new MySqlParameter("@StudentID", studentId),
                new MySqlParameter("@GradeID", gradeId)
            };

                    dbManager.ExecuteQuery(enrollQuery, enrollParams);

                    MessageBox.Show("Student updated successfully!");
                    LoadStudents(); // Refresh the DataGridView to reflect changes
                }
                else
                {
                    MessageBox.Show("Failed to update student. Please check the Student ID.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}");
            }
        }


        private void DeleteStudent(int studentId)
        {
            if (studentId <= 0)
            {
                MessageBox.Show("Invalid Student ID.");
                return;
            }

            string query = "DELETE FROM Students WHERE StudentID = @StudentID";

            MySqlParameter[] parameters = {
        new MySqlParameter("@StudentID", studentId)
    };

            try
            {
                int result = dbManager.ExecuteQuery(query, parameters);

                if (result > 0)
                {
                    MessageBox.Show("Student deleted successfully!");
                    LoadStudents(); // Refresh the DataGridView to reflect changes
                }
                else
                {
                    MessageBox.Show("Failed to delete the student. Please check the Student ID.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}");
            }
        }



        private void ViewStudents()
        {
            string query = "SELECT s.StudentID, s.FirstName, s.LastName, s.DOB, s.Gender, e.GradeID, g.GradeLevel " +
                           "FROM Students s " +
                           "INNER JOIN Enrollments e ON s.StudentID = e.StudentID " +
                           "INNER JOIN Grades g ON e.GradeID = g.GradeID";

            try
            {
                DataTable studentsData = dbManager.GetData(query);
                dataGridViewStudents.DataSource = studentsData;
                MessageBox.Show("Students loaded successfully!");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading students: " + ex.Message);
            }
        }


        private void btnResetPicture_Click_1(object sender, EventArgs e)
        {
            // Get the selected student's ID
            if (dataGridViewStudents.CurrentRow != null)
            {
                string studentId = dataGridViewStudents.CurrentRow.Cells["StudentID"].Value.ToString();

                try
                {
                    // Update the database to remove the custom profile picture path
                    string query = "UPDATE Students SET ProfilePicturePath = NULL WHERE StudentID = @StudentID";
                    MySqlParameter[] parameters = {
                new MySqlParameter("@StudentID", studentId)
            };

                    dbManager.ExecuteQuery(query, parameters);

                    // Reset to the default profile picture in the UI
                    LoadDefaultProfilePicture();
                    MessageBox.Show("Profile picture reset to default successfully!");
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error resetting profile picture: {ex.Message}");
                }
            }
            else
            {
                MessageBox.Show("Please select a student first.");
            }
        }


        private void btnUploadPicture_Click(object sender, EventArgs e)
        {
            // Open a file dialog for the user to select an image
            OpenFileDialog openFileDialog = new OpenFileDialog
            {
                Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp|All files|*.*"
            };

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                string picturePath = openFileDialog.FileName;

                // Get the selected student's ID
                if (dataGridViewStudents.CurrentRow != null)
                {
                    string studentId = dataGridViewStudents.CurrentRow.Cells["StudentID"].Value.ToString();

                    // Save the profile picture to the folder and update the database
                    SaveProfilePicture(studentId, picturePath);

                    // Refresh the profile picture display
                    DisplayProfilePicture(studentId);

                    MessageBox.Show("Profile picture updated successfully!");
                }
                else
                {
                    MessageBox.Show("Please select a student first.");
                }
            }
        }






        private void SaveProfilePicture(string studentId, string picturePath)
        {
            string targetDirectory = @"C:\StudentManagement\ProfilePictures\";

            // Ensure the directory exists
            DirectoryHelper.EnsureDirectoryExists(targetDirectory);

            // Generate the target file path
            string targetFilePath = Path.Combine(targetDirectory, studentId + Path.GetExtension(picturePath));

            try
            {
                // Save the image file to the target directory
                File.Copy(picturePath, targetFilePath, true); // Overwrites if the file already exists

                // Update the database with the file path
                string query = "UPDATE Students SET ProfilePicturePath = @ProfilePicturePath WHERE StudentID = @StudentID";
                MySqlParameter[] parameters = {
            new MySqlParameter("@ProfilePicturePath", targetFilePath),
            new MySqlParameter("@StudentID", studentId)
        };

                dbManager.ExecuteQuery(query, parameters);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error saving profile picture: {ex.Message}");
            }
        }


        private void DisplayProfilePicture(string studentId)
        {
            string query = "SELECT ProfilePicturePath FROM Students WHERE StudentID = @StudentID";
            MySqlParameter[] parameters = {
        new MySqlParameter("@StudentID", studentId)
    };

            try
            {
                DataTable result = dbManager.GetData(query, parameters);
                if (result.Rows.Count > 0)
                {
                    string profilePicturePath = result.Rows[0]["ProfilePicturePath"].ToString();
                    if (File.Exists(profilePicturePath))
                    {
                        pictureBoxProfile.SizeMode = PictureBoxSizeMode.Zoom;
                        pictureBoxProfile.Image = Image.FromFile(profilePicturePath);
                    }
                    else
                    {
                        LoadDefaultProfilePicture();
                    }
                }
                else
                {
                    LoadDefaultProfilePicture();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error displaying profile picture: {ex.Message}");
            }
        }

        private void LoadDefaultProfilePicture()
        {
            try
            {
                pictureBoxProfile.SizeMode = PictureBoxSizeMode.Zoom;
                pictureBoxProfile.Image = Image.FromFile(@"D:\VisualStudyo\StudentManagementSystem\StudentManagementSystem\Resources\default_profile_picture.jpg");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading default profile picture: {ex.Message}");
            }
        }







        private void textLastName_TextChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void dataGridViewStudents_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void dataGridViewStudents_SelectionChanged(object sender, EventArgs e)
        {

        }

        private void btnAdd_MouseEnter(object sender, EventArgs e)
        {
            // Change background color when the mouse enters
        }

        private void btnAdd_MouseLeave(object sender, EventArgs e)
        {
            // Revert to original color when the mouse leaves

        }

        private void d(object sender, EventArgs e)
        {

        }
        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}



