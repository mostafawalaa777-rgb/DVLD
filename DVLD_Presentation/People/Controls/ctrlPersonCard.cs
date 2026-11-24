
using System.IO;
using System.Windows.Forms;
using DVLD_Buisness;
using DVLD_Presentation.Properties;
namespace DVLD_Presentation.People.Controls
{
    public partial class ctrlPersonCard : UserControl
    {
        private clsPerson _Person;
        private  int _PersonID = -1;
        public int PersonID
        {
            get { return _PersonID; }
        }
        public clsPerson SelectedPersonInfo
        {
            get {  return _Person; }
        }
        public ctrlPersonCard()
        {
            InitializeComponent();
        }      
        public void LoadPersonInfo(int PersonID)
        {
            _Person = clsPerson.Find(PersonID);
            if (_Person == null)
            {
                ResetPersonInfo();
                MessageBox.Show("No Person with PersonID = " + PersonID.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);   
                return;
            }

            _FillPersonInfo();
        }
        public void LoadPersonInfo(string NationalNo)
        {
           _Person = clsPerson.Find(NationalNo);
            if (_Person == null)
            {
                ResetPersonInfo();
                MessageBox.Show("No Person with NationalNo = " + NationalNo.ToString(), "error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                return;
            }
            _FillPersonInfo();
        }
        private void _LoadPersonImage()
        {
            if (_Person.Gendor == 0)
                pbPerson.Image = Resources.Male_512;
            else
                pbPerson.Image = Resources.Female_512;

            string ImagePath = _Person.ImagePath;
            if (ImagePath != "")
            {
                if(File.Exists(ImagePath))
                     pbPerson.ImageLocation = ImagePath;
                 else
                    MessageBox.Show("Could not find this image: = " + ImagePath, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void _FillPersonInfo()
        {   
            llEditPersonInfo.Enabled = true;
            _PersonID = _Person.PersonID;
            lblPersonID.Text = _PersonID.ToString();
            lblFullName.Text = _Person.FullName;
            lblNationalNo.Text = _Person.NationalNo;
            lblGendor.Text = _Person.Gendor == 0 ? "Male" : "Female";
            pbGendor.Image = _Person.Gendor == 0 ?  Resources.Man_32 :  Resources.Woman_32;
            lblAddress.Text = _Person.Address;
            lblEmail.Text = _Person.Email;
            lblPhon.Text = _Person.Phone;
            lblCountryNam.Text = clsCountry.Find(_Person.NationalityCountryID).CountryName;
            lblBirthDay.Text = _Person.DateOfBirth.ToShortDateString();
            _LoadPersonImage();
        }
        public void ResetPersonInfo()
        {

            _PersonID = -1;
            lblPersonID.Text = "[????]";
            lblNationalNo.Text = "[????]";
            lblFullName.Text = "[????]";
            pbGendor.Image = Resources.Man_32;
            lblGendor.Text = "[????]";
            lblEmail.Text = "[????]";
            lblPhon.Text = "[????]";
            lblBirthDay.Text = "[????]";
            lblCountryNam.Text = "[????]";
            lblAddress.Text = "[????]";
            pbPerson.Image = Resources.Male_512;
         }
        private void llEditPersonInfo_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmAddUpdatePerson frm = new frmAddUpdatePerson(_PersonID);
            frm.ShowDialog();

            //refresh
            LoadPersonInfo(_PersonID);
        }

        private void label5_Click(object sender, System.EventArgs e)
        {

        }
    }
}
