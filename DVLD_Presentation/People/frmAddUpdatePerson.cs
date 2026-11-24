using System;                                
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Cache;
using System.Net.Mail;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using DVLD_Buisness;
using static DVLD_Buisness.clsPerson;
using DVLD_Presentation.Properties;
using TheArtOfDevHtmlRenderer.Adapters;
using System.Security.Policy;
using DVLD_Presentation.Global_Classes;


namespace DVLD_Presentation.People

{
    public partial class frmAddUpdatePerson : Form
    {
        // Declare a delegate
        public delegate void DataBackEventHandler(object sender, int PersonID);

        // Declare an event using the delegate
        public event DataBackEventHandler DataBack;

        public enum enGendor { Male = 0, Female = 1 };
        public enum enMode { AddNew = 0, Update = 1 };

        private enGendor _Gendor;
        private enMode _Mode;

        private int _PersonID;
        private clsPerson _Person;

        public frmAddUpdatePerson()
        {
            InitializeComponent();
            _Mode = enMode.AddNew;
        }
        public frmAddUpdatePerson(int PersonID)
        {
            InitializeComponent();
            _Mode = enMode.Update;
            _PersonID = PersonID;
        }
        private void _FillCountriesInComoboBox()
        {
            DataTable CountryTable = clsCountry.GetAllCountries();
            foreach (DataRow row in CountryTable.Rows)
            {
                cbCountry.Items.Add(row["CountryName"]);
            }
        }
        private void _ResetDefualtValues()
        {
            //this will initialize the reset the defaule values

            _FillCountriesInComoboBox();

            if (_Mode == enMode.AddNew)
            {
                lblMode.Text = "Add New Person ";
                _Person = new clsPerson();
            }
            else
            {
                lblMode.Text = "Update Person ";
            }

            if (rbtnMale.Checked)
                //set default image for the person.
                pbPerson.Image = Resources.Male_512;
            else
                pbPerson.Image = Resources.Female_512;

            //hide/show the remove linke incase there is no image for the person.
            llRemove.Visible = pbPerson.ImageLocation != null;

            //we set the max date to 18 years from today, and set the default value the same.
            dtpDateOfBirth.MaxDate = DateTime.Now.AddYears(-18);
            dtpDateOfBirth.Value = dtpDateOfBirth.MaxDate;

            //should not allow adding age more than 100 years
            dtpDateOfBirth.MinDate = DateTime.Now.AddYears(-100);

            //this will set default country to jordan.
            cbCountry.SelectedIndex = cbCountry.FindString("Egypt");

            txtbFName.Text = "";
            txtbSecondName.Text = "";
            txtbThirdName.Text = "";
            txtbLastName.Text = "";
            txtbNationalNO.Text = "";
            rbtnMale.Checked = true;
            txtbAddress.Text = "";
            txtbPhone.Text = "";
            txtbEmail.Text = "";

        }
        private void _LoadData()
        {
            _Person = clsPerson.Find(_PersonID);

            if (_Person == null)
            {
                MessageBox.Show("No Person with ID = " + _PersonID, "Person Not Found", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                this.Close();
                return;
            }
            //the following code will not be executed if the person was not found

            lblPersonID.Text = _PersonID.ToString();
            txtbFName.Text = _Person.FirstName;
            txtbSecondName.Text = _Person.SecondName;
            txtbThirdName.Text = _Person.ThirdName;
            txtbLastName.Text = _Person.LastName;
            txtbNationalNO.Text = _Person.NationalNo;
            txtbAddress.Text = _Person.Address;
            txtbEmail.Text = _Person.Email;
            txtbPhone.Text = _Person.Phone;
            cbCountry.SelectedIndex = cbCountry.FindString(_Person.CountryInfo.CountryName);
            if (_Person.Gendor == 0)
            {
                rbtnMale.Checked = true;
            }
            else
            {
                rbtnFemale.Checked = true;
            }

            dtpDateOfBirth.Value = _Person.DateOfBirth;

            //load person image incase it was set.
            if (_Person.ImagePath != "")
            {
                pbPerson.ImageLocation = _Person.ImagePath;
            }

            //hide/show the remove linke incase there is no image for the person.
            llRemove.Visible = (_Person.ImagePath != "");
        }
        private void frmAddUpdatePerson_Load(object sender, EventArgs e)
        {
            _ResetDefualtValues();
            if (_Mode == enMode.Update)
                _LoadData();
        }
        private bool _HandlePersonImage()
        {

            //this procedure will handle the person image,
            //it will take care of deleting the old image from the folder
            //in case the image changed. and it will rename the new image with guid and 
            // place it in the images folder.


            //_Person.ImagePath contains the old Image, we check if it changed then we copy the new image
            if (_Person.ImagePath != pbPerson.ImageLocation)
            {
                if (_Person.ImagePath != "")
                {
                    //first we delete the old image from the folder in case there is any.

                    try
                    {
                        File.Delete(_Person.ImagePath);
                    }
                    catch (IOException)
                    {
                        // We could not delete the file.
                        //log it later   
                    }
                }

                if (pbPerson.ImageLocation != null)
                {
                    //then we copy the new image to the image folder after we rename it
                    string SourceImageFile = pbPerson.ImageLocation.ToString();

                    if (clsUtil.CopyImageToProjectImagesFolder(ref SourceImageFile))
                    {
                        pbPerson.ImageLocation = SourceImageFile;
                        return true;
                    }
                    else
                    {
                        MessageBox.Show("Error Copying Image File", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return false;
                    }
                }

            }
            return true;
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            //ValidateEmptyTextBox(); 

            if (!this.ValidateChildren())
            {
                //Here we dont continue becuase the form is not valid

                MessageBox.Show("Some fileds are not valide!, put the mouse over the red icon(s) to see the erro", "Validation Error"
                   , MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if  (!_HandlePersonImage())
              return;

            int NationalityCountryID = clsCountry.Find(cbCountry.Text).ID;

            _Person.FirstName = txtbFName.Text.Trim();
            _Person.SecondName = txtbSecondName.Text.Trim();
            _Person.ThirdName = txtbThirdName.Text.Trim();
            _Person.LastName = txtbLastName.Text.Trim();
            _Person.NationalNo = txtbNationalNO.Text.Trim();
            _Person.Email = txtbEmail.Text.Trim();
            _Person.Phone = txtbPhone.Text.Trim();
            _Person.Address = txtbAddress.Text.Trim();
            _Person.DateOfBirth = dtpDateOfBirth.Value;
            if (rbtnMale.Checked)
                _Person.Gendor = (short)enGendor.Male;
            else
                _Person.Gendor = (short)enGendor.Female;

            _Person.NationalityCountryID = NationalityCountryID;

            if (pbPerson.ImageLocation != null)
                _Person.ImagePath = pbPerson.ImageLocation;
            else
                _Person.ImagePath = "";

            if (_Person.Save())
            {
                //change form mode to update.

                _Mode = enMode.Update;
                lblMode.Text = "Update Person";
                MessageBox.Show("Data Saved Successfully.", "Saved", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Trigger the event to send data back to the caller form.
                DataBack?.Invoke(this, _Person.PersonID);
            }
            else
                MessageBox.Show("Error: Data Is not Saved Successfully.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        private void llSetImage_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            openFileDialog1.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.gif;*.bmp";
            openFileDialog1.FilterIndex = 1;
            openFileDialog1.RestoreDirectory = true;

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                // Process the selected file
                string selectedFilePath = openFileDialog1.FileName;
                pbPerson.Load(selectedFilePath);
                llRemove.Visible = true;
            }

        }
        private void llRemove_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            pbPerson.ImageLocation = null;

            if (rbtnMale.Checked)
                pbPerson.Image = Resources.Male_512;
            else
                pbPerson.Image = Resources.Female_512;

            llRemove.Visible = false;
        }
        private void rbtnFemale_CheckedChanged(object sender, EventArgs e)
        {
            //change the defualt image to female incase there is no image set.

            if (pbPerson.ImageLocation == null)
                pbPerson.Image = Resources.Female_512;
        }
        private void rbtnMale_CheckedChanged(object sender, EventArgs e)
        {
            //change the defualt image to male incase there is no image set.

            if (pbPerson.ImageLocation == null)
            {
                pbPerson.Image = Properties.Resources.Male_512;
            }
        }
        private void ValidateEmptyTextBox(object sender, CancelEventArgs e)
        {
            // First: set AutoValidate property of your Form to EnableAllowFocusChange in designer 

            TextBox temb = ((TextBox)sender);
            if (string.IsNullOrEmpty(temb.Text.Trim()))
            {
                e.Cancel = true;
                errorProvider1.SetError(temb, "This field is required!");
            }
            else
                //e.Cancel = false;
                errorProvider1.SetError(temb, null);
        }
        private void txtbEmail_Validating(object sender, CancelEventArgs e)
        {
            //no need to validate the email incase it's empty.
            if (txtbEmail.Text.Trim() == "")
                return;

            //validate email format
            if (!clsValidatoin.ValidateEmail(txtbEmail.Text))
            {
                e.Cancel = true;
                errorProvider1.SetError(txtbEmail, "Invalid Email Address Format!");
            }
            else
            {
                errorProvider1.SetError(txtbEmail, null);
            }
        }
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void txtbNationalNO_Validating_1(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(txtbNationalNO.Text.Trim()))
            {
                e.Cancel = true;
                errorProvider1.SetError(txtbNationalNO, "This field is required!");
            }
            else
            {
                errorProvider1.SetError(txtbNationalNO, null);
            }
            if (txtbNationalNO.Text.Trim() != _Person.NationalNo && clsPerson.isPersonExist(txtbNationalNO.Text.Trim()))
            {
                e.Cancel = true;
                errorProvider1.SetError(txtbNationalNO, "National Number is used for another person!");
            }
            else
                errorProvider1.SetError(txtbNationalNO, null);

        }
    }
}
