﻿using ThreadedProject2.Helpers;
using ThreadedProject2.Models;

namespace ThreadedProject2
{
    public partial class AddEditPackageProduct : Form
    {
        //new database context
        Models.TravelExpertsContext context = new TravelExpertsContext();

        //SelectedItemId to get data provided from main form using Id.GetId(lstData)
        private int selectedItemId;

        //isAdd bool for add or edit controller
        private bool isAdd;

        /// <summary>
        /// Form Type to pass from Main form
        /// </summary>
        public string FormType { get; set; }

        /// <summary>
        /// Opens AddEditPackageProduct form with selectedItemId parameter to add or edit data
        /// </summary>
        /// <param name="formType"> Form type defined from main form</param>
        /// <param name="selectedItemId"> ID of selected item, if present</param>
        public AddEditPackageProduct(string formType, int selectedItemId = -1)
        {
            //Initialize form parts
            InitializeComponent();
            FormType = formType;
            SetForm(formType, selectedItemId);
        }

        /// <summary>
        /// Sets form state based on selectedItem
        /// </summary>
        /// <param name="formType"></param>
        /// <param name="selectedItem"></param>
        private void SetForm(string formType, int selectedItem)
        {
            //set selectedItem of data to modify form
            this.selectedItemId = selectedItem;
            //set form legend aka groupbox
            grbDetails.Text = $@"{formType} Details";

            //Set text of form based on selectedItem
            if (selectedItem == -1)
            {
                //set form Text and isAdd state
                this.Text = $@"Add {formType}";
                isAdd = true;
            }
            else
            {
                //Set form and isAdd state
                this.Text = $@"Edit {formType}";
                isAdd = false;
            }

            //Show Controls based on type
            switch (formType)
            {
                case "Supplier":
                    HideNonSupplierControls();
                    break;
                case "Product":
                    HideNonProductControls();
                    break;
                case "Product Supplier":
                    HidePSControls();
                    break;
            }
        }

        /// <summary>
        /// Hides the controls not related to Product and Supplier.
        /// </summary>
        /// <summary>
        /// Hides the controls not related to Product and Supplier.
        /// </summary>
        private void HidePSControls()
        {
            // Hide text boxes for Product and Supplier
            txtProduct.Enabled = false;
            txtProduct.Visible = false;
            txtSupplier.Enabled = false;
            txtSupplier.Visible = false;
            lblSupplierID.Enabled = false;
            lblSupplierID.Visible = false;
            txtSupplierID.Enabled = false;
            txtSupplierID.Visible = false;

            // Disable and hide buttons for adding new Product and Supplier
            // btnNewProduct.Enabled = false;
            // btnNewProduct.Visible = false;
            // btnNewSupplier.Enabled = false;
            // btnNewSupplier.Visible = false;
        }

        /// <summary>
        /// Hides the controls not related to Product.
        /// </summary>
        private void HideNonProductControls()
        {
            // Disable and hide controls related to Supplier
            lblSupplier.Enabled = false;
            lblSupplier.Visible = false;
            lblSupplierID.Enabled = false;
            lblSupplierID.Visible = false;
            cboSupplier.Enabled = false;
            cboSupplier.Visible = false;
            txtSupplier.Enabled = false;
            txtSupplier.Visible = false;
            txtSupplierID.Enabled = false;
            txtSupplierID.Visible = false;
            btnNewSupplier.Enabled = false;
            btnNewSupplier.Visible = false;

            // Disable and hide the controls related to Product
            btnNewProduct.Enabled = false;
            btnNewProduct.Visible = false;
        }


        /// <summary>
        /// Hides the controls not related to Supplier.
        /// </summary>
        private void HideNonSupplierControls()
        {
            // Disable and hide the label for Product
            lblProduct.Enabled = false;
            lblProduct.Visible = false;

            // Disable and hide the combo box for Product
            cboProduct.Enabled = false;
            cboProduct.Visible = false;

            // Disable and hide the text box for Product
            txtProduct.Enabled = false;
            txtProduct.Visible = false;

            // Disable and hide the button for adding a new Product
            btnNewProduct.Enabled = false;
            btnNewProduct.Visible = false;

            // Disable and hide the button for adding a new Supplier
            btnNewSupplier.Enabled = false;
            btnNewSupplier.Visible = false;
        }

        //On form load display selected data, if anything was selected
        private void AddEditPackageProduct_Load(object sender, EventArgs e)
        {
            //if selectedItemId is not -1 aka product was selected, display selected data in fields
            try
            {
                //If selectedItemId is not -1 aka product was selected
                if (selectedItemId != -1)
                {
                    switch (FormType)
                    {
                        //Set what to get based on FormType//Get product by that selectedItemId
                        //Then display data
                        case "Product":
                        {
                            Product? product = DB.Get.Products(selectedItemId).FirstOrDefault();
                            txtProduct.Text = product?.ProdName;
                            break;
                        }
                        case "Supplier":
                        {
                            Supplier? supplier = DB.Get.Suppliers(selectedItemId).FirstOrDefault();
                            txtSupplier.Text = supplier?.SupName;
                            txtSupplierID.Text = supplier?.SupplierId.ToString();
                            txtSupplierID.ReadOnly = true;
                            break;
                        }

                        case "Product Supplier":
                        {
                            //Get Product Supplier ID
                            ProductsSupplier? productSupplier =
                                DB.Get.ProductSuppliers(selectedItemId).FirstOrDefault();

                            // Populate both ComboBoxes for Product and Supplier and select the current product and supplier based on selectedItemId
                            if (productSupplier != null)
                            {
                                var products = DB.Get.Products();
                                cboProduct.DataSource = products;
                                cboProduct.DisplayMember = "ProdName";
                                cboProduct.ValueMember = "ProductId";
                                cboProduct.SelectedValue = productSupplier.ProductId;

                                var suppliers = DB.Get.Suppliers();
                                cboSupplier.DataSource = suppliers;
                                cboSupplier.DisplayMember = "SupName";
                                cboSupplier.ValueMember = "SupplierId";
                                cboSupplier.SelectedValue = productSupplier.SupplierId;
                            }

                            break;
                        }
                    }
                }
                //When Adding and cbo controls are enables(Still loads even when not displayed??)
                else
                {
                    var products = DB.Get.Products();
                    cboProduct.DataSource = products;
                    cboProduct.DisplayMember = "ProdName";
                    cboProduct.ValueMember = "ProductId";

                    var suppliers = DB.Get.Suppliers();
                    cboSupplier.DataSource = suppliers;
                    cboSupplier.DisplayMember = "SupName";
                    cboSupplier.ValueMember = "SupplierId";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Sql Server Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void btnAccept_Click(object sender, EventArgs e)
        {
            try
            {
                //Check if fields are valid BASED on FormType
                if (isValid(FormType))
                {
                    switch (FormType)
                    {
                        case "Product":
                            HandleProductSave();
                            break;
                        case "Supplier":
                            HandleSupplierSave();
                            break;
                        case "Product Supplier":
                            HandleProductSupplierSave();
                            break;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Sql Server Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Handles saving a product based on whether it is an add or update operation.
        /// </summary>
        private void HandleProductSave()
        {
            // Check if it's an addition operation
            if (isAdd)
            {
                // Create a new product object with the name from the text box
                Product product = new Product
                {
                    ProdName = txtProduct.Text
                };

                // Add the product to the context and save changes
                context.Products.Add(product);
                context.SaveChanges();
                MessageBox.Show("Product Added", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                // Get the product by its ID
                Product? product = context.Products.FirstOrDefault(p => p.ProductId == selectedItemId);

                // If product is not found, throw an exception
                if (product == null)
                {
                    throw new Exception("There was an error accessing the database");
                }

                // Update the product name with the text from the textbox
                product.ProdName = txtProduct.Text;

                // Save changes to the context
                context.SaveChanges();
                MessageBox.Show("Product Updated", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            // Set the dialog result to OK
            DialogResult = DialogResult.OK;
        }

        /// <summary>
        /// Handles the save operation for suppliers.
        /// </summary>
        private void HandleSupplierSave()
        {
            // Check if the current operation is an addition
            if (isAdd)
            {
                // Create a new supplier object with the name from the text box
                Supplier supplier = new Supplier
                {
                    SupName = txtSupplier.Text,
                    SupplierId = int.Parse(txtSupplierID.Text)
                };

                // Add the supplier to the context
                context.Suppliers.Add(supplier);

                // Save the changes to the context
                context.SaveChanges();

                // Show a success message
                MessageBox.Show("Supplier Added", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                // Get the supplier by its ID
                Supplier? supplier = context.Suppliers.FirstOrDefault(s => s.SupplierId == selectedItemId);

                // If the supplier is not found, throw an exception
                if (supplier == null)
                {
                    throw new Exception("There was an error accessing the database");
                }

                // Update the supplier name with the text from the textbox
                supplier.SupName = txtSupplier.Text;

                // Update the supplier ID with the text from the textbox
                supplier.SupplierId = int.Parse(txtSupplierID.Text);

                // Save the changes to the context
                context.SaveChanges();

                // Show a success message
                MessageBox.Show("Supplier Updated", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            // Set the dialog result to OK
            DialogResult = DialogResult.OK;
        }

        /// <summary>
        /// Handles the save operation for a product supplier.
        /// </summary>
        private void HandleProductSupplierSave()
        {
            // Check if it's an add operation
            if (isAdd)
            {
                // Create a new product supplier object with the selected product and supplier IDs
                //with isValid Method shouldn't be possible to pass null values, so suppress
                ProductsSupplier productSupplier = new ProductsSupplier
                {
                    ProductId = (int)cboProduct.SelectedValue!,
                    SupplierId = (int)cboSupplier.SelectedValue!
                };

                // Add the product supplier to the context
                context.ProductsSuppliers.Add(productSupplier);

                // Save the changes to the context
                context.SaveChanges();

                // Show a success message
                MessageBox.Show("Product Supplier Added", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                // Get the existing product supplier by its ID
                ProductsSupplier productSupplier =
                    context.ProductsSuppliers.FirstOrDefault(ps => ps.ProductSupplierId == selectedItemId)!;

                // If the product supplier is not found, throw an exception
                if (productSupplier == null)
                {
                    throw new Exception("There was an error accessing the database");
                }

                // Update the product and supplier IDs
                productSupplier.ProductId = (int)cboProduct.SelectedValue!;
                productSupplier.SupplierId = (int)cboSupplier.SelectedValue!;

                // Save the changes to the context
                context.SaveChanges();

                // Show a success message
                MessageBox.Show("Product Supplier Updated", "Success", MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
            }

            // Set the dialog result to OK
            DialogResult = DialogResult.OK;
        }

        /// <summary>
        /// Validates the data in the text fields
        /// </summary>
        /// <param name="formType"></param>
        /// <returns>True if all the data is valid, false otherwise</returns>
        private bool isValid(string formType)
        {
            bool success = true;

            try
            {
                switch (formType)
                {
                    case "Product":
                        // Check if the product name is a valid sentence and within the specified length
                        if (!Validation.IsSentence(txtProduct.Text, "Product") ||
                            !Validation.CheckLength(txtProduct, 50) ||
                            !Validation.IsPresent(txtProduct))
                        {
                            success = false;
                        }

                        break;
                    case "Supplier":
                        // Check if the supplier name is a valid sentence and within the specified length
                        if (!Validation.IsPresent(txtSupplier) ||
                            !Validation.IsSentence(txtSupplier.Text, "Supplier") ||
                            !Validation.CheckLength(txtSupplier, 255) ||
                            !Validation.IsPresent(txtSupplierID) ||
                            !Validation.IsNonNegativeInteger(txtSupplierID))
                        {
                            success = false;
                        }

                        break;
                    case "Product Supplier":
                        // Check if both product and supplier are selected
                        if (cboProduct.SelectedValue == null || cboSupplier.SelectedValue == null)
                        {
                            MessageBox.Show("Please select both a product and a supplier.");
                            success = false;
                        }

                        break;
                }
            }
            catch (Exception ex)
            {
                // If an exception occurs, display the error message and set success to false
                MessageBox.Show(ex.Message);
                success = false;
            }

            return success;
        }

        private void btnNewProduct_Click(object sender, EventArgs e)
        {
            AddEditPackageProduct form = new AddEditPackageProduct("Product", selectedItemId = -1);
            if (form.ShowDialog() == DialogResult.OK)
            {
                // Refresh ComboBoxes in current form after dialog is closed
                RefreshComboBoxes();
            }
        }

        private void btnNewSupplier_Click(object sender, EventArgs e)
        {
            AddEditPackageProduct form = new AddEditPackageProduct("Supplier", selectedItemId = -1);
            if (form.ShowDialog() == DialogResult.OK)
            {
                // Refresh ComboBoxes in current form after dialog is closed
                RefreshComboBoxes();
            }
        }

        // Method to refresh ComboBoxes
        private void RefreshComboBoxes()
        {
            if (FormType == "Product Supplier")
            {
                // Refresh products ComboBox
                var products = DB.Get.Products();
                cboProduct.DataSource = products;
                cboProduct.DisplayMember = "ProdName";
                cboProduct.ValueMember = "ProductId";

                // Refresh suppliers ComboBox
                var suppliers = DB.Get.Suppliers();
                cboSupplier.DataSource = suppliers;
                cboSupplier.DisplayMember = "SupName";
                cboSupplier.ValueMember = "SupplierId";
            }
        }
    }
}