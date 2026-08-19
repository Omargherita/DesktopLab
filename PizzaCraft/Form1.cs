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
    public partial class Main : Form
    {
        public Main()
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
            if (rdoEatIn.Checked == true)
                return (Convert.ToByte(rdoThickCrust.Tag));
            return (Convert.ToByte(rdoEatIn.Tag)); // 0
        }

        float CalculateTotalPrice()
        {
            return (CalculateSize() + CalculateCrustType() + CalculateToppings() + CalculateWhereToEat());
        }

        void UpdateTotalPrice()
        {
            lblTotalPrice.Text = "$" + (CalculateTotalPrice()).ToString();
        }

        void UpdateToppingsDescription(string Topping, byte status = 0)
        {
            if (status == 1)
            {
                lblToppings.Text = lblToppings.Text.Replace(", " + Topping, "");
                lblToppings.Text = lblToppings.Text.Replace(Topping, "");
                if (string.IsNullOrEmpty(lblToppings.Text))
                    DefaultToppingsLabel();
                return;
            }

            if (lblToppings.Text == "No Toppings")
                lblToppings.Text = Topping;
            else
                lblToppings.Text += (", " + Topping);
        }

        private void rdoSmall_CheckedChanged(object sender, EventArgs e)
        {
            UpdateSizeLabel("Small");
            UpdateTotalPrice();
        }

        private void rdoMedium_CheckedChanged(object sender, EventArgs e)
        {
            UpdateSizeLabel("Medium");
            UpdateTotalPrice();
        }

        private void rdoLarge_CheckedChanged(object sender, EventArgs e)
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
            if (!chkExtraCheese.Checked == true)
                UpdateToppingsDescription("Extra Cheese", 1);
            else
                UpdateToppingsDescription("Extra Cheese");

            UpdateTotalPrice();
        }

        private void chkOnion_CheckedChanged(object sender, EventArgs e)
        {
            if (!chkOnion.Checked == true)
                UpdateToppingsDescription("Onion", 1);
            else
                UpdateToppingsDescription("Onion");

            UpdateTotalPrice();
        }

        private void chkMushrooms_CheckedChanged(object sender, EventArgs e)
        {
            if (!chkMushrooms.Checked == true)
                UpdateToppingsDescription("Mushrooms", 1);
            else
                UpdateToppingsDescription("Mushrooms");

            UpdateTotalPrice();
        }

        private void chkOlives_CheckedChanged(object sender, EventArgs e)
        {
            if (!chkOlives.Checked == true)
                UpdateToppingsDescription("Olives", 1);
            else
                UpdateToppingsDescription("Olives");

            UpdateTotalPrice();
        }

        private void chkTomatoes_CheckedChanged(object sender, EventArgs e)
        {
            if (!chkTomatoes.Checked == true)
                UpdateToppingsDescription("Tomatoes", 1);
            else
                UpdateToppingsDescription("Tomatoes");

            UpdateTotalPrice();
        }

        private void chkGreenPeppers_CheckedChanged(object sender, EventArgs e)
        {
            if (!chkGreenPeppers.Checked == true)
                UpdateToppingsDescription("Green Peppers", 1);
            else
                UpdateToppingsDescription("Green Peppers");
            
            UpdateTotalPrice();
        }
    }
}
