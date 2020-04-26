using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Shop_Demo
{
    public partial class ShopForm : Form
    {
        public BindingSource bindingSourceForMenu = new BindingSource();
        public BindingSource bindingSourceForShoppingCart = new BindingSource();
        public ShopForm()
        {
            InitializeComponent();

            UpdateUI();

            initializeMenuGridCollums();

            SetDataMenu();


        }

        private void AddProductToShoppingCart(Product product)
        {
            Product productToAdd = new Product()
            {
                Name = product.Name,
                Price = product.Price,
                Qty = product.Qty
            };

            shoppingCart.Products.Add(productToAdd);
            bindingSourceForShoppingCart.ResetBindings(false);

            product.Qty = 0;
            bindingSourceForMenu.ResetBindings(false);
        }
        private void UpdateUI()
        {
            gvListArticle.AutoGenerateColumns = false;
            gvShoppingCart.AutoGenerateColumns = false;
        }

        private void SetDataMenu()
        {
            bindingSourceForMenu.DataSource = Product.GetProducts();
            gvListArticle.DataSource = bindingSourceForMenu;

            bindingSourceForShoppingCart.DataSource = shoppingCart.Products;

            gvShoppingCart.DataSource = bindingSourceForShoppingCart;
        }

        private void initializeMenuGridCollums()
        {
            DataGridViewColumn col = new DataGridViewColumn();
            col.CellTemplate = new DataGridViewTextBoxCell();
            col.HeaderText = "Име";
            col.DataPropertyName = "Name";
            col.ReadOnly = true;
            gvListArticle.Columns.Add(col);

            col = new DataGridViewColumn();
            col.CellTemplate = new DataGridViewTextBoxCell();
            col.HeaderText = "Цена";
            col.DataPropertyName = "Price";
            col.ReadOnly = true;
            gvListArticle.Columns.Add(col);

            col = new DataGridViewColumn();
            col.CellTemplate = new DataGridViewTextBoxCell();
            col.HeaderText = "К-во";
            col.DataPropertyName = "Qty";
            col.ReadOnly = true;
            gvListArticle.Columns.Add(col);

            col = new DataGridViewColumn();
            col.CellTemplate = new DataGridViewTextBoxCell();
            col.HeaderText = "Име";
            col.DataPropertyName = "Name";
            col.ReadOnly = true;
            gvShoppingCart.Columns.Add(col);

            col = new DataGridViewColumn();
            col.CellTemplate = new DataGridViewTextBoxCell();
            col.HeaderText = "Цена";
            col.DataPropertyName = "Price";
            col.ReadOnly = true;
            gvShoppingCart.Columns.Add(col);

            col = new DataGridViewColumn();
            col.CellTemplate = new DataGridViewTextBoxCell();
            col.HeaderText = "к-во";
            col.DataPropertyName = "Qty";
            col.ReadOnly = false;
            gvShoppingCart.Columns.Add(col);

            col = new DataGridViewColumn();
            col.CellTemplate = new DataGridViewTextBoxCell();
            col.HeaderText = "Обща цена";
            col.DataPropertyName = "Sum";
            col.ReadOnly = false;
            gvShoppingCart.Columns.Add(col);

        }

        private void ClearShoppingCart()
        {
            shoppingCart.Products.Clear();
            bindingSourceForShoppingCart.ResetBindings(false);
            tbCashBox.Text = "0";
        }

    }
}
