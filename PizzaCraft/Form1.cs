using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PizzaCraft
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            rdoMedium.Checked = true;
            UpdateSizeLabel("Medium");
            rdoThinCrust.Checked = true;
            UpdateCrustLabel("Thin Crust");
            DefaultToppingsLabel();
            UpdateWhereToEatLabel("Eat In");
            UpdateTotalPrice();
        }

        void UpdateSizeLabel(string size)
        {
            lblSize.Text = size;
        }

        void UpdateCrustLabel(string type)
        {
            lblCrustType.Text = type;
        }

        void DefaultToppingsLabel()
        {
            lblToppings.Text = "No Toppings";
        }

        void UpdateWhereToEatLabel(string loc)
        {
            lblWhereToEat.Text = loc;
        }

        byte CalculateSize()
        {
            if (rdoSmall.Checked == true)
                return (Convert.ToByte(rdoSmall.Tag));
            else if (rdoMedium.Checked)
                return (Convert.ToByte(rdoMedium.Tag));
            else
                return (Convert.ToByte(rdoLarge.Tag));
        }

        byte CalculateCrustType()
        {
            if (rdoThickCrust.Checked == true)
                return (Convert.ToByte(rdoThickCrust.Tag));
            return (Convert.ToByte(rdoThinCrust.Tag)); // 0
        }

        float CalculateToppings()
        {
            float amount = 0;

            if (chkExtraCheese.Checked == true)
                amount += Convert.ToSingle(chkExtraCheese.Tag);
            if (chkOnion.Checked == true)
                amount += Convert.ToSingle(chkOnion.Tag);
            if (chkOlives.Checked == true)
                amount += Convert.ToSingle(chkOlives.Tag);
            if (chkMushrooms.Checked == true)
                amount += Convert.ToSingle(chkMushrooms.Tag);
            if (chkTomatoes.Checked == true)
                amount += Convert.ToSingle(chkTomatoes.Tag);
            if (chkGreenPeppers.Checked == true)
                amount += Convert.ToSingle(chkGreenPeppers.Tag);

            return (amount);
        }

        byte CalculateWhereToEat()
        {
            if (rdoTakeOut.Checked == true)
                return (Convert.ToByte(rdoTakeOut.Tag)); // 0
            return (Convert.ToByte(rdoEatIn.Tag)); 
        }

        float CalculateTotalPrice()
        {
            return (CalculateSize() + CalculateCrustType() + CalculateToppings() + CalculateWhereToEat());
        }

        void UpdateTotalPrice()
        {
            lblTotalPrice.Text = "$" + (CalculateTotalPrice()).ToString();
        }

        void UpdateToppingsDescription()
        {
            string Toppings = "";

            if (chkExtraCheese.Checked)
            {
                Toppings = "Extra Chees";
            }


            if (chkOnion.Checked)
            {
                Toppings += ", Onion";
            }

            if (chkMushrooms.Checked)
            {
                Toppings += ", Mushrooms";
            }

            if (chkOlives.Checked)
            {
                Toppings += ", Olives";
            }

            if (chkTomatoes.Checked)
            {
                Toppings += ", Tomatos";
            }

            if (chkGreenPeppers.Checked)
            {
                Toppings += ", Green Peppars";
            }

            if (Toppings.StartsWith(","))
            {
                Toppings = Toppings.Substring(1, Toppings.Length - 1).Trim();
            }

            if (Toppings == "")
                Toppings = "No Toppings";

            lblToppings.Text = Toppings;
        }

        void ResetForm()
        {

            //reset Groups
            grbSize.Enabled = true;
            grbToppings.Enabled = true;
            grbCrustType.Enabled = true;
            grbWhereToEat.Enabled = true;

            //reset Size
            rdoMedium.Checked = true;

            //reset Toppings.
            chkExtraCheese.Checked = false;
            chkOnion.Checked = false;
            chkMushrooms.Checked = false;
            chkOlives.Checked = false;
            chkTomatoes.Checked = false;
            chkGreenPeppers.Checked = false;

            //reset CrustType
            rdoThinCrust.Checked = true;

            //reset Where to Eat
            rdoEatIn.Checked = true;

            //Reset Order Button
            btnOrderPizza.Enabled = true;

        }

        private void rdoMedium_CheckedChanged_1(object sender, EventArgs e)
        {
            UpdateSizeLabel("Medium");
            UpdateTotalPrice();
        }

        private void rdoSmall_CheckedChanged_1(object sender, EventArgs e)
        {
            UpdateSizeLabel("Small");
            UpdateTotalPrice();
        }

        private void rdoLarge_CheckedChanged_1(object sender, EventArgs e)
        {
            UpdateSizeLabel("Large");
            UpdateTotalPrice();
        }

        private void rdoThinCrust_CheckedChanged(object sender, EventArgs e)
        {
            UpdateCrustLabel("Thin Crust");
            UpdateTotalPrice();
        }

        private void rdoThickCrust_CheckedChanged(object sender, EventArgs e)
        {
            UpdateCrustLabel("Thick Crust");
            UpdateTotalPrice();
        }

        private void rdoEatIn_CheckedChanged(object sender, EventArgs e)
        {
            UpdateWhereToEatLabel("Eat In");
            UpdateTotalPrice();
        }

        private void rdoTakeOut_CheckedChanged(object sender, EventArgs e)
        {
            UpdateWhereToEatLabel("Take Out");
            UpdateTotalPrice();
        }

        private void chkExtraCheese_CheckedChanged(object sender, EventArgs e)
        {
            UpdateToppingsDescription();
            UpdateTotalPrice();
        }

        private void chkOnion_CheckedChanged(object sender, EventArgs e)
        {
            UpdateToppingsDescription();
            UpdateTotalPrice();
        }

        private void chkMushrooms_CheckedChanged(object sender, EventArgs e)
        {
            UpdateToppingsDescription();
            UpdateTotalPrice();
        }

        private void chkOlives_CheckedChanged(object sender, EventArgs e)
        {
            UpdateToppingsDescription();
            UpdateTotalPrice();
        }

        private void chkTomatoes_CheckedChanged(object sender, EventArgs e)
        {
            UpdateToppingsDescription();
            UpdateTotalPrice();
        }

        private void chkGreenPeppers_CheckedChanged(object sender, EventArgs e)
        {
            UpdateToppingsDescription();
            UpdateTotalPrice();
        }

        private void btnOrderPizza_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Confirm Order", "Confirm",
                MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                MessageBox.Show("Order Placed Successfully", "Success",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);

                btnOrderPizza.Enabled = false;
                grbSize.Enabled = false;
                grbToppings.Enabled = false;
                grbCrustType.Enabled = false;
                grbWhereToEat.Enabled = false;

            }
            else

                MessageBox.Show("Update your order", "Update",
                    MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }

        private void btnResetForm_Click(object sender, EventArgs e)
        {
            ResetForm();
        }
    }
}
