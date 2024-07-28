using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ThreadedProject2.Models;
using ThreadedProject2.Helpers;
using Microsoft.EntityFrameworkCore;

namespace ThreadedProject2
{
    public partial class AddEditSupplierContact : Form
    {
        TravelExpertsContext context = new TravelExpertsContext();
        private int ContactId { get; set; }
        private bool isAdd { get; set; }
        private int lastId { get; set; }
        SupplierContact contact;

        public AddEditSupplierContact(bool isAdd, int lastId = 0, int id = 0)
        {
            InitializeComponent();
            this.ContactId = id;
            this.isAdd = isAdd;
            this.lastId = lastId;
        }

        private void AddEditSupplierContact_Load(object sender, EventArgs e)
        {
            this.Text = isAdd ? "Add Contact" : "Edit Contact";

            if (ContactId != 0)
            {
                contact = context.SupplierContacts.Include(sc => sc.Affiliation).Where(sc => sc.SupplierContactId == ContactId).FirstOrDefault();
            }

            SupplierContact supplierContact = DB.Get.SupplierContacts(lastId).FirstOrDefault();

            if (supplierContact != null)
            {
                txtSCAddress.Text = supplierContact.SupConAddress;
                txtSCCity.Text = supplierContact.SupConCity;
                txtSCPostalCode.Text = supplierContact.SupConPostal;
                txtSCCountry.Text = supplierContact.SupConCountry;
                txtSCFax.Text = supplierContact.SupConFax;
                txtSCURL.Text = supplierContact.SupConUrl;
                txtSCCompany.Text = supplierContact.SupConCompany;
            }

            if (!isAdd)
            {
                UpdateTextBoxes(contact);
            }

            setAffiliation(contact);
        }

        private void UpdateTextBoxes(SupplierContact? contact = null)
        {
            txtSCFirstName.Text = contact?.SupConFirstName ?? "";
            txtSCLastName.Text = contact?.SupConLastName ?? "";
            txtSCAddress.Text = contact?.SupConAddress ?? "";
            txtSCCity.Text = contact?.SupConCity ?? "";
            txtSCProvince.Text = contact?.SupConProv ?? "";
            txtSCPostalCode.Text = contact?.SupConPostal ?? "";
            txtSCCountry.Text = contact?.SupConCountry ?? "";
            txtSCCompany.Text = contact?.SupConCompany ?? "";
            txtSCBusinessPhone.Text = contact?.SupConBusPhone ?? "";
            txtSCEmail.Text = contact?.SupConEmail ?? "";
            txtSCURL.Text = contact?.SupConUrl ?? "";
            txtSCFax.Text = contact?.SupConFax ?? "";
        }

        private bool isValid()
        {
            bool success = false;

            if (Validation.IsSentence(txtSCFirstName) &&
                Validation.IsSentence(txtSCLastName) &&
                Validation.IsAddress(txtSCAddress) &&
                Validation.IsSentence(txtSCCity) &&
                Validation.IsProvince(txtSCProvince) &&
                Validation.IsPostalCode(txtSCPostalCode) &&
                Validation.IsSentence(txtSCCountry) &&
                Validation.ItemSelected(cboAffiliation) &&
                Validation.IsSentence(txtSCCompany) &&
                Validation.IsPhoneNumber(txtSCBusinessPhone) &&
                Validation.IsEmail(txtSCEmail) &&
                Validation.IsURL(txtSCURL) &&
                Validation.IsPhoneNumber(txtSCFax)
                )
            {
                success = true;
            }
            else
            {
                success = false;
            }

            return success;
        }

        private void setAffiliation(SupplierContact contact = null)
        {
            var affiliations = context.Affiliations;
            foreach (var affiliation in affiliations)
            {
                cboAffiliation.Items.Add(affiliation.AffilitationId);
                if (contact != null && affiliation.AffilitationId == contact.AffiliationId)
                {
                    cboAffiliation.SelectedItem = affiliation.AffilitationId;
                }
            }
        }

        private void btnAccept_Click(object sender, EventArgs e)
        {
            if (isValid())
            {
                List<SupplierContact> supplierContacts = DB.Get.SupplierContacts(lastId);

                if (isAdd)
                {
                    SupplierContact contact = new SupplierContact()
                    {
                        SupConFirstName = StringFormats.FormatString(txtSCFirstName.Text),
                        SupConLastName = StringFormats.FormatString(txtSCLastName.Text),
                        SupConCompany = StringFormats.FormatString(txtSCCompany.Text),
                        SupConAddress = txtSCAddress.Text,
                        SupConCity = txtSCCity.Text,
                        SupConProv = txtSCProvince.Text,
                        SupConPostal = txtSCPostalCode.Text,
                        SupConCountry = StringFormats.FormatString(txtSCCountry.Text),
                        SupConBusPhone = StringFormats.FormatPhone(txtSCBusinessPhone.Text),
                        SupConFax = StringFormats.FormatPhone(txtSCFax.Text),
                        SupConEmail = txtSCEmail.Text,
                        SupConUrl = txtSCURL.Text,
                        AffiliationId = cboAffiliation.SelectedItem.ToString(),
                        SupplierId = lastId
                    };

                    context.SupplierContacts.Add(contact);

                    context.SaveChanges();

                    MessageBox.Show($"Contact has been {(isAdd ? "added" : "edited")}");
                }
                else
                {
                    contact.SupConFirstName = StringFormats.FormatString(txtSCFirstName.Text);
                    contact.SupConLastName = StringFormats.FormatString(txtSCLastName.Text);
                    contact.SupConCompany = StringFormats.FormatString(txtSCCompany.Text);
                    contact.SupConAddress = txtSCAddress.Text;
                    contact.SupConCity = txtSCCity.Text;
                    contact.SupConProv = txtSCProvince.Text;
                    contact.SupConPostal = txtSCPostalCode.Text;
                    contact.SupConCountry = StringFormats.FormatString(txtSCCountry.Text);
                    contact.SupConBusPhone = StringFormats.FormatPhone(txtSCBusinessPhone.Text);
                    contact.SupConFax = StringFormats.FormatPhone(txtSCFax.Text);
                    contact.SupConEmail = txtSCEmail.Text;
                    contact.SupConUrl = txtSCURL.Text;
                    contact.AffiliationId = cboAffiliation.SelectedItem.ToString();

                    context.SupplierContacts.Update(contact);

                    context.SaveChanges();

                    MessageBox.Show($"Contact has been {(isAdd ? "added" : "edited")}");
                }
            }
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            UpdateTextBoxes();
        }
    }
}
