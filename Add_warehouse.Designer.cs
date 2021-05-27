
namespace CMAPIntegrator
{
    partial class Add_warehouse
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Add_warehouse));
            this.text_warehouse = new System.Windows.Forms.TextBox();
            this.btn_add_wh = new System.Windows.Forms.Button();
            this.btn_cansel_wh = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // text_warehouse
            // 
            this.text_warehouse.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.text_warehouse.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.text_warehouse.Location = new System.Drawing.Point(12, 12);
            this.text_warehouse.Name = "text_warehouse";
            this.text_warehouse.Size = new System.Drawing.Size(243, 23);
            this.text_warehouse.TabIndex = 0;
            this.text_warehouse.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.text_warehouse_KeyPress);
            // 
            // btn_add_wh
            // 
            this.btn_add_wh.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btn_add_wh.Location = new System.Drawing.Point(12, 41);
            this.btn_add_wh.Name = "btn_add_wh";
            this.btn_add_wh.Size = new System.Drawing.Size(80, 30);
            this.btn_add_wh.TabIndex = 1;
            this.btn_add_wh.Text = "Добавить";
            this.btn_add_wh.UseVisualStyleBackColor = true;
            this.btn_add_wh.Click += new System.EventHandler(this.btn_add_wh_Click);
            // 
            // btn_cansel_wh
            // 
            this.btn_cansel_wh.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btn_cansel_wh.Location = new System.Drawing.Point(180, 40);
            this.btn_cansel_wh.Name = "btn_cansel_wh";
            this.btn_cansel_wh.Size = new System.Drawing.Size(75, 30);
            this.btn_cansel_wh.TabIndex = 2;
            this.btn_cansel_wh.Text = "Отмена";
            this.btn_cansel_wh.UseVisualStyleBackColor = true;
            this.btn_cansel_wh.Click += new System.EventHandler(this.btn_cansel_wh_Click);
            // 
            // Add_warehouse
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(267, 82);
            this.Controls.Add(this.btn_cansel_wh);
            this.Controls.Add(this.btn_add_wh);
            this.Controls.Add(this.text_warehouse);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "Add_warehouse";
            this.ShowInTaskbar = false;
            this.Text = "Код склада";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox text_warehouse;
        private System.Windows.Forms.Button btn_add_wh;
        private System.Windows.Forms.Button btn_cansel_wh;
    }
}