
namespace CMAPIntegrator
{
    partial class FormConnectKIS
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormConnectKIS));
            this.table_connect_CMAP = new System.Windows.Forms.TableLayoutPanel();
            this.label_IP_KIS = new System.Windows.Forms.Label();
            this.label_login_KIS = new System.Windows.Forms.Label();
            this.label_pass_KIS = new System.Windows.Forms.Label();
            this.label_path_KIS = new System.Windows.Forms.Label();
            this.text_IP_KIS = new System.Windows.Forms.TextBox();
            this.text_login_KIS = new System.Windows.Forms.TextBox();
            this.text_pass_KIS = new System.Windows.Forms.TextBox();
            this.text_path_KIS = new System.Windows.Forms.TextBox();
            this.btn_connect_KIS = new System.Windows.Forms.Button();
            this.table_connect_CMAP.SuspendLayout();
            this.SuspendLayout();
            // 
            // table_connect_CMAP
            // 
            this.table_connect_CMAP.ColumnCount = 2;
            this.table_connect_CMAP.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.table_connect_CMAP.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.table_connect_CMAP.Controls.Add(this.label_IP_KIS, 0, 0);
            this.table_connect_CMAP.Controls.Add(this.label_login_KIS, 0, 1);
            this.table_connect_CMAP.Controls.Add(this.label_pass_KIS, 0, 2);
            this.table_connect_CMAP.Controls.Add(this.label_path_KIS, 0, 3);
            this.table_connect_CMAP.Controls.Add(this.text_IP_KIS, 1, 0);
            this.table_connect_CMAP.Controls.Add(this.text_login_KIS, 1, 1);
            this.table_connect_CMAP.Controls.Add(this.text_pass_KIS, 1, 2);
            this.table_connect_CMAP.Controls.Add(this.text_path_KIS, 1, 3);
            this.table_connect_CMAP.Controls.Add(this.btn_connect_KIS, 0, 4);
            this.table_connect_CMAP.Dock = System.Windows.Forms.DockStyle.Fill;
            this.table_connect_CMAP.Location = new System.Drawing.Point(0, 0);
            this.table_connect_CMAP.Name = "table_connect_CMAP";
            this.table_connect_CMAP.RowCount = 5;
            this.table_connect_CMAP.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 28F));
            this.table_connect_CMAP.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 28F));
            this.table_connect_CMAP.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 28F));
            this.table_connect_CMAP.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 28F));
            this.table_connect_CMAP.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.table_connect_CMAP.Size = new System.Drawing.Size(314, 154);
            this.table_connect_CMAP.TabIndex = 1;
            // 
            // label_IP_KIS
            // 
            this.label_IP_KIS.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label_IP_KIS.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label_IP_KIS.Location = new System.Drawing.Point(3, 0);
            this.label_IP_KIS.Name = "label_IP_KIS";
            this.label_IP_KIS.Size = new System.Drawing.Size(151, 28);
            this.label_IP_KIS.TabIndex = 0;
            this.label_IP_KIS.Text = "IP адрес сервера";
            this.label_IP_KIS.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label_login_KIS
            // 
            this.label_login_KIS.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label_login_KIS.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label_login_KIS.Location = new System.Drawing.Point(3, 28);
            this.label_login_KIS.Name = "label_login_KIS";
            this.label_login_KIS.Size = new System.Drawing.Size(151, 28);
            this.label_login_KIS.TabIndex = 1;
            this.label_login_KIS.Text = "Логин";
            this.label_login_KIS.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label_pass_KIS
            // 
            this.label_pass_KIS.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label_pass_KIS.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label_pass_KIS.Location = new System.Drawing.Point(3, 56);
            this.label_pass_KIS.Name = "label_pass_KIS";
            this.label_pass_KIS.Size = new System.Drawing.Size(151, 28);
            this.label_pass_KIS.TabIndex = 2;
            this.label_pass_KIS.Text = "Пароль";
            this.label_pass_KIS.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label_path_KIS
            // 
            this.label_path_KIS.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label_path_KIS.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label_path_KIS.Location = new System.Drawing.Point(3, 84);
            this.label_path_KIS.Name = "label_path_KIS";
            this.label_path_KIS.Size = new System.Drawing.Size(151, 28);
            this.label_path_KIS.TabIndex = 3;
            this.label_path_KIS.Text = "Путь до базы";
            this.label_path_KIS.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // text_IP_KIS
            // 
            this.text_IP_KIS.Dock = System.Windows.Forms.DockStyle.Fill;
            this.text_IP_KIS.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.text_IP_KIS.Location = new System.Drawing.Point(160, 3);
            this.text_IP_KIS.Name = "text_IP_KIS";
            this.text_IP_KIS.Size = new System.Drawing.Size(151, 23);
            this.text_IP_KIS.TabIndex = 4;
            // 
            // text_login_KIS
            // 
            this.text_login_KIS.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.text_login_KIS.Dock = System.Windows.Forms.DockStyle.Fill;
            this.text_login_KIS.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.text_login_KIS.Location = new System.Drawing.Point(160, 31);
            this.text_login_KIS.Name = "text_login_KIS";
            this.text_login_KIS.Size = new System.Drawing.Size(151, 23);
            this.text_login_KIS.TabIndex = 5;
            // 
            // text_pass_KIS
            // 
            this.text_pass_KIS.Dock = System.Windows.Forms.DockStyle.Fill;
            this.text_pass_KIS.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.text_pass_KIS.Location = new System.Drawing.Point(160, 59);
            this.text_pass_KIS.Name = "text_pass_KIS";
            this.text_pass_KIS.PasswordChar = '*';
            this.text_pass_KIS.Size = new System.Drawing.Size(151, 23);
            this.text_pass_KIS.TabIndex = 6;
            // 
            // text_path_KIS
            // 
            this.text_path_KIS.Dock = System.Windows.Forms.DockStyle.Fill;
            this.text_path_KIS.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.text_path_KIS.Location = new System.Drawing.Point(160, 87);
            this.text_path_KIS.Name = "text_path_KIS";
            this.text_path_KIS.Size = new System.Drawing.Size(151, 23);
            this.text_path_KIS.TabIndex = 7;
            // 
            // btn_connect_KIS
            // 
            this.table_connect_CMAP.SetColumnSpan(this.btn_connect_KIS, 2);
            this.btn_connect_KIS.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btn_connect_KIS.Location = new System.Drawing.Point(3, 115);
            this.btn_connect_KIS.Name = "btn_connect_KIS";
            this.btn_connect_KIS.Size = new System.Drawing.Size(308, 36);
            this.btn_connect_KIS.TabIndex = 8;
            this.btn_connect_KIS.Text = "Проверить соединение";
            this.btn_connect_KIS.UseVisualStyleBackColor = true;
            this.btn_connect_KIS.Click += new System.EventHandler(this.btn_connect_KIS_Click);
            // 
            // FormConnectKIS
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(314, 154);
            this.Controls.Add(this.table_connect_CMAP);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "FormConnectKIS";
            this.Text = "Подключение к КИС";
            this.Load += new System.EventHandler(this.FormConnectKIS_Load);
            this.table_connect_CMAP.ResumeLayout(false);
            this.table_connect_CMAP.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel table_connect_CMAP;
        private System.Windows.Forms.Label label_IP_KIS;
        private System.Windows.Forms.Label label_login_KIS;
        private System.Windows.Forms.Label label_pass_KIS;
        private System.Windows.Forms.Label label_path_KIS;
        public System.Windows.Forms.TextBox text_IP_KIS;
        public System.Windows.Forms.TextBox text_login_KIS;
        public System.Windows.Forms.TextBox text_pass_KIS;
        public System.Windows.Forms.TextBox text_path_KIS;
        private System.Windows.Forms.Button btn_connect_KIS;
    }
}