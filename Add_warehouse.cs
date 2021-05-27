using System;
using System.Windows.Forms;

namespace CMAPIntegrator
{
    /// <summary>
    /// Форма для добавления склада
    /// </summary>
    public partial class Add_warehouse : Form
    {
        public Add_warehouse()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Только цифры
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void text_warehouse_KeyPress(object sender, KeyPressEventArgs e)
        {
            char number = e.KeyChar;
            if (!Char.IsDigit(number) && number != 8 && number != 127)
                e.Handled = true;
        }

        /// <summary>
        /// Добавление нового склада
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_add_wh_Click(object sender, EventArgs e)
        {
            Mainform mf = this.Owner as Mainform;
            if (String.IsNullOrWhiteSpace(text_warehouse.Text))
                MessageBox.Show("Не введен код склада", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else
            {
                mf.warehouses.Items.Add(text_warehouse.Text);
                Close();
            }
            
        }

        /// <summary>
        /// Отмена ввода склада
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_cansel_wh_Click(object sender, EventArgs e)
        {
            Close();
        }

    }
}
