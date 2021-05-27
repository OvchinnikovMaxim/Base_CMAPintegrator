
namespace CMAPIntegrator
{
    partial class Mainform
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Mainform));
            this.table_copyright = new System.Windows.Forms.TableLayoutPanel();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.split_copy = new System.Windows.Forms.SplitContainer();
            this.label3 = new System.Windows.Forms.Label();
            this.link = new System.Windows.Forms.LinkLabel();
            this.progress_sinhronization = new System.Windows.Forms.ProgressBar();
            this.tab_connect = new System.Windows.Forms.TabPage();
            this.table_connect = new System.Windows.Forms.TableLayoutPanel();
            this.gr_connect_CMAP = new System.Windows.Forms.GroupBox();
            this.table_connect_CMAP = new System.Windows.Forms.TableLayoutPanel();
            this.label_IP_CMAP = new System.Windows.Forms.Label();
            this.label_login_CMAP = new System.Windows.Forms.Label();
            this.label_pass_CMAP = new System.Windows.Forms.Label();
            this.label_path_CMAP = new System.Windows.Forms.Label();
            this.text_IP_CMAP = new System.Windows.Forms.TextBox();
            this.text_login_CMAP = new System.Windows.Forms.TextBox();
            this.text_pass_CMAP = new System.Windows.Forms.TextBox();
            this.text_path_CMAP = new System.Windows.Forms.TextBox();
            this.btn_connect_CMAP = new System.Windows.Forms.Button();
            this.table_conKIS_save = new System.Windows.Forms.TableLayoutPanel();
            this.btn_form_connect_KIS = new System.Windows.Forms.Button();
            this.btn_save_settings = new System.Windows.Forms.Button();
            this.check_log_extended = new System.Windows.Forms.CheckBox();
            this.text_path_save_settings = new System.Windows.Forms.TextBox();
            this.text_path_log = new System.Windows.Forms.TextBox();
            this.tab_sinhron = new System.Windows.Forms.TabPage();
            this.table_total_sinhr = new System.Windows.Forms.TableLayoutPanel();
            this.panel_total_sinhr = new System.Windows.Forms.Panel();
            this.btn_prods_sinhr = new System.Windows.Forms.Button();
            this.btn_client_sinhr = new System.Windows.Forms.Button();
            this.btn_total_sinhr = new System.Windows.Forms.Button();
            this.btn_totalDocs_sinhr = new System.Windows.Forms.Button();
            this.rich_log_text = new System.Windows.Forms.RichTextBox();
            this.tabControl = new System.Windows.Forms.TabControl();
            this.tab_sales_zakaz = new System.Windows.Forms.TabPage();
            this.table_docs_sinhr = new System.Windows.Forms.TableLayoutPanel();
            this.rich_log_text_sales = new System.Windows.Forms.RichTextBox();
            this.table_sales_orders = new System.Windows.Forms.TableLayoutPanel();
            this.group_sales = new System.Windows.Forms.GroupBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.date_docs_to = new System.Windows.Forms.DateTimePicker();
            this.date_docs_from = new System.Windows.Forms.DateTimePicker();
            this.btn_sales = new System.Windows.Forms.Button();
            this.group_orders = new System.Windows.Forms.GroupBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.date_order_to = new System.Windows.Forms.DateTimePicker();
            this.date_order_from = new System.Windows.Forms.DateTimePicker();
            this.btn_orders = new System.Windows.Forms.Button();
            this.tab_ost = new System.Windows.Forms.TabPage();
            this.table_ost_sinhr = new System.Windows.Forms.TableLayoutPanel();
            this.rich_log_text_ost = new System.Windows.Forms.RichTextBox();
            this.panel_ost = new System.Windows.Forms.Panel();
            this.btn_ost = new System.Windows.Forms.Button();
            this.btn_clear_w_hoses = new System.Windows.Forms.Button();
            this.btn_del_warehouse = new System.Windows.Forms.Button();
            this.btn_add_warehouse = new System.Windows.Forms.Button();
            this.warehouses = new System.Windows.Forms.ListBox();
            this.table_progress = new System.Windows.Forms.TableLayoutPanel();
            this.label_info = new System.Windows.Forms.Label();
            this.bg_CLN = new System.ComponentModel.BackgroundWorker();
            this.bg_PROD = new System.ComponentModel.BackgroundWorker();
            this.bg_DOCS = new System.ComponentModel.BackgroundWorker();
            this.bg_OST = new System.ComponentModel.BackgroundWorker();
            this.bg_ORDERS = new System.ComponentModel.BackgroundWorker();
            this.bg_Sinh_DOC = new System.ComponentModel.BackgroundWorker();
            this.bg_FULL = new System.ComponentModel.BackgroundWorker();
            this.table_copyright.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.split_copy)).BeginInit();
            this.split_copy.Panel1.SuspendLayout();
            this.split_copy.Panel2.SuspendLayout();
            this.split_copy.SuspendLayout();
            this.tab_connect.SuspendLayout();
            this.table_connect.SuspendLayout();
            this.gr_connect_CMAP.SuspendLayout();
            this.table_connect_CMAP.SuspendLayout();
            this.table_conKIS_save.SuspendLayout();
            this.tab_sinhron.SuspendLayout();
            this.table_total_sinhr.SuspendLayout();
            this.panel_total_sinhr.SuspendLayout();
            this.tabControl.SuspendLayout();
            this.tab_sales_zakaz.SuspendLayout();
            this.table_docs_sinhr.SuspendLayout();
            this.table_sales_orders.SuspendLayout();
            this.group_sales.SuspendLayout();
            this.group_orders.SuspendLayout();
            this.tab_ost.SuspendLayout();
            this.table_ost_sinhr.SuspendLayout();
            this.panel_ost.SuspendLayout();
            this.table_progress.SuspendLayout();
            this.SuspendLayout();
            // 
            // table_copyright
            // 
            this.table_copyright.ColumnCount = 3;
            this.table_copyright.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.table_copyright.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.table_copyright.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.table_copyright.Controls.Add(this.label1, 0, 0);
            this.table_copyright.Controls.Add(this.label2, 1, 0);
            this.table_copyright.Controls.Add(this.split_copy, 2, 0);
            this.table_copyright.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.table_copyright.Location = new System.Drawing.Point(0, 405);
            this.table_copyright.Name = "table_copyright";
            this.table_copyright.RowCount = 1;
            this.table_copyright.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.table_copyright.Size = new System.Drawing.Size(409, 63);
            this.table_copyright.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(3, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(130, 63);
            this.label1.TabIndex = 0;
            this.label1.Text = "MAP Distributor Solution";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            this.label2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label2.Image = ((System.Drawing.Image)(resources.GetObject("label2.Image")));
            this.label2.Location = new System.Drawing.Point(139, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(130, 63);
            this.label2.TabIndex = 1;
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // split_copy
            // 
            this.split_copy.Dock = System.Windows.Forms.DockStyle.Fill;
            this.split_copy.Location = new System.Drawing.Point(275, 3);
            this.split_copy.Name = "split_copy";
            this.split_copy.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // split_copy.Panel1
            // 
            this.split_copy.Panel1.Controls.Add(this.label3);
            // 
            // split_copy.Panel2
            // 
            this.split_copy.Panel2.Controls.Add(this.link);
            this.split_copy.Size = new System.Drawing.Size(131, 57);
            this.split_copy.SplitterDistance = 28;
            this.split_copy.TabIndex = 2;
            // 
            // label3
            // 
            this.label3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label3.Location = new System.Drawing.Point(0, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(131, 28);
            this.label3.TabIndex = 0;
            this.label3.Text = "Copyright © 2021 \r\nАО \"Нэфис Косметикс\"";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // link
            // 
            this.link.Dock = System.Windows.Forms.DockStyle.Fill;
            this.link.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.link.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline;
            this.link.Location = new System.Drawing.Point(0, 0);
            this.link.Name = "link";
            this.link.Size = new System.Drawing.Size(131, 25);
            this.link.TabIndex = 0;
            this.link.TabStop = true;
            this.link.Text = "http://www.nefco.ru";
            this.link.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.link.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.link_LinkClicked);
            // 
            // progress_sinhronization
            // 
            this.table_progress.SetColumnSpan(this.progress_sinhronization, 2);
            this.progress_sinhronization.Dock = System.Windows.Forms.DockStyle.Fill;
            this.progress_sinhronization.ForeColor = System.Drawing.Color.LightGreen;
            this.progress_sinhronization.Location = new System.Drawing.Point(3, 3);
            this.progress_sinhronization.Name = "progress_sinhronization";
            this.progress_sinhronization.Size = new System.Drawing.Size(262, 13);
            this.progress_sinhronization.Step = 1;
            this.progress_sinhronization.TabIndex = 2;
            // 
            // tab_connect
            // 
            this.tab_connect.Controls.Add(this.table_connect);
            this.tab_connect.Location = new System.Drawing.Point(4, 22);
            this.tab_connect.Name = "tab_connect";
            this.tab_connect.Padding = new System.Windows.Forms.Padding(3);
            this.tab_connect.Size = new System.Drawing.Size(401, 360);
            this.tab_connect.TabIndex = 1;
            this.tab_connect.Text = "Подключение";
            this.tab_connect.UseVisualStyleBackColor = true;
            // 
            // table_connect
            // 
            this.table_connect.ColumnCount = 1;
            this.table_connect.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.table_connect.Controls.Add(this.gr_connect_CMAP, 0, 0);
            this.table_connect.Controls.Add(this.table_conKIS_save, 0, 1);
            this.table_connect.Dock = System.Windows.Forms.DockStyle.Fill;
            this.table_connect.Location = new System.Drawing.Point(3, 3);
            this.table_connect.Name = "table_connect";
            this.table_connect.RowCount = 2;
            this.table_connect.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 170F));
            this.table_connect.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.table_connect.Size = new System.Drawing.Size(395, 354);
            this.table_connect.TabIndex = 0;
            // 
            // gr_connect_CMAP
            // 
            this.gr_connect_CMAP.Controls.Add(this.table_connect_CMAP);
            this.gr_connect_CMAP.Location = new System.Drawing.Point(3, 3);
            this.gr_connect_CMAP.Margin = new System.Windows.Forms.Padding(3, 3, 3, 1);
            this.gr_connect_CMAP.Name = "gr_connect_CMAP";
            this.gr_connect_CMAP.Size = new System.Drawing.Size(389, 166);
            this.gr_connect_CMAP.TabIndex = 0;
            this.gr_connect_CMAP.TabStop = false;
            this.gr_connect_CMAP.Text = "Подключение к базе МАП";
            // 
            // table_connect_CMAP
            // 
            this.table_connect_CMAP.ColumnCount = 2;
            this.table_connect_CMAP.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.table_connect_CMAP.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.table_connect_CMAP.Controls.Add(this.label_IP_CMAP, 0, 0);
            this.table_connect_CMAP.Controls.Add(this.label_login_CMAP, 0, 1);
            this.table_connect_CMAP.Controls.Add(this.label_pass_CMAP, 0, 2);
            this.table_connect_CMAP.Controls.Add(this.label_path_CMAP, 0, 3);
            this.table_connect_CMAP.Controls.Add(this.text_IP_CMAP, 1, 0);
            this.table_connect_CMAP.Controls.Add(this.text_login_CMAP, 1, 1);
            this.table_connect_CMAP.Controls.Add(this.text_pass_CMAP, 1, 2);
            this.table_connect_CMAP.Controls.Add(this.text_path_CMAP, 1, 3);
            this.table_connect_CMAP.Controls.Add(this.btn_connect_CMAP, 0, 4);
            this.table_connect_CMAP.Dock = System.Windows.Forms.DockStyle.Fill;
            this.table_connect_CMAP.Location = new System.Drawing.Point(3, 16);
            this.table_connect_CMAP.Name = "table_connect_CMAP";
            this.table_connect_CMAP.RowCount = 5;
            this.table_connect_CMAP.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 28F));
            this.table_connect_CMAP.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 28F));
            this.table_connect_CMAP.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 28F));
            this.table_connect_CMAP.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 28F));
            this.table_connect_CMAP.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.table_connect_CMAP.Size = new System.Drawing.Size(383, 147);
            this.table_connect_CMAP.TabIndex = 0;
            // 
            // label_IP_CMAP
            // 
            this.label_IP_CMAP.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label_IP_CMAP.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label_IP_CMAP.Location = new System.Drawing.Point(3, 0);
            this.label_IP_CMAP.Name = "label_IP_CMAP";
            this.label_IP_CMAP.Size = new System.Drawing.Size(185, 28);
            this.label_IP_CMAP.TabIndex = 0;
            this.label_IP_CMAP.Text = "IP адрес сервера";
            this.label_IP_CMAP.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label_login_CMAP
            // 
            this.label_login_CMAP.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label_login_CMAP.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label_login_CMAP.Location = new System.Drawing.Point(3, 28);
            this.label_login_CMAP.Name = "label_login_CMAP";
            this.label_login_CMAP.Size = new System.Drawing.Size(185, 28);
            this.label_login_CMAP.TabIndex = 1;
            this.label_login_CMAP.Text = "Логин";
            this.label_login_CMAP.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label_pass_CMAP
            // 
            this.label_pass_CMAP.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label_pass_CMAP.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label_pass_CMAP.Location = new System.Drawing.Point(3, 56);
            this.label_pass_CMAP.Name = "label_pass_CMAP";
            this.label_pass_CMAP.Size = new System.Drawing.Size(185, 28);
            this.label_pass_CMAP.TabIndex = 2;
            this.label_pass_CMAP.Text = "Пароль";
            this.label_pass_CMAP.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label_path_CMAP
            // 
            this.label_path_CMAP.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label_path_CMAP.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label_path_CMAP.Location = new System.Drawing.Point(3, 84);
            this.label_path_CMAP.Name = "label_path_CMAP";
            this.label_path_CMAP.Size = new System.Drawing.Size(185, 28);
            this.label_path_CMAP.TabIndex = 3;
            this.label_path_CMAP.Text = "Путь до базы";
            this.label_path_CMAP.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // text_IP_CMAP
            // 
            this.text_IP_CMAP.Dock = System.Windows.Forms.DockStyle.Fill;
            this.text_IP_CMAP.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.text_IP_CMAP.Location = new System.Drawing.Point(194, 3);
            this.text_IP_CMAP.Name = "text_IP_CMAP";
            this.text_IP_CMAP.Size = new System.Drawing.Size(186, 23);
            this.text_IP_CMAP.TabIndex = 4;
            // 
            // text_login_CMAP
            // 
            this.text_login_CMAP.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.text_login_CMAP.Dock = System.Windows.Forms.DockStyle.Fill;
            this.text_login_CMAP.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.text_login_CMAP.Location = new System.Drawing.Point(194, 31);
            this.text_login_CMAP.Name = "text_login_CMAP";
            this.text_login_CMAP.Size = new System.Drawing.Size(186, 23);
            this.text_login_CMAP.TabIndex = 5;
            // 
            // text_pass_CMAP
            // 
            this.text_pass_CMAP.Dock = System.Windows.Forms.DockStyle.Fill;
            this.text_pass_CMAP.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.text_pass_CMAP.Location = new System.Drawing.Point(194, 59);
            this.text_pass_CMAP.Name = "text_pass_CMAP";
            this.text_pass_CMAP.PasswordChar = '*';
            this.text_pass_CMAP.Size = new System.Drawing.Size(186, 23);
            this.text_pass_CMAP.TabIndex = 6;
            // 
            // text_path_CMAP
            // 
            this.text_path_CMAP.Dock = System.Windows.Forms.DockStyle.Fill;
            this.text_path_CMAP.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.text_path_CMAP.Location = new System.Drawing.Point(194, 87);
            this.text_path_CMAP.Name = "text_path_CMAP";
            this.text_path_CMAP.Size = new System.Drawing.Size(186, 23);
            this.text_path_CMAP.TabIndex = 7;
            // 
            // btn_connect_CMAP
            // 
            this.table_connect_CMAP.SetColumnSpan(this.btn_connect_CMAP, 2);
            this.btn_connect_CMAP.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btn_connect_CMAP.Location = new System.Drawing.Point(3, 115);
            this.btn_connect_CMAP.Name = "btn_connect_CMAP";
            this.btn_connect_CMAP.Size = new System.Drawing.Size(377, 29);
            this.btn_connect_CMAP.TabIndex = 8;
            this.btn_connect_CMAP.Text = "Проверить соединение";
            this.btn_connect_CMAP.UseVisualStyleBackColor = true;
            this.btn_connect_CMAP.Click += new System.EventHandler(this.btn_connect_CMAP_Click);
            // 
            // table_conKIS_save
            // 
            this.table_conKIS_save.ColumnCount = 3;
            this.table_conKIS_save.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.table_conKIS_save.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33334F));
            this.table_conKIS_save.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33334F));
            this.table_conKIS_save.Controls.Add(this.btn_form_connect_KIS, 0, 0);
            this.table_conKIS_save.Controls.Add(this.btn_save_settings, 1, 0);
            this.table_conKIS_save.Controls.Add(this.check_log_extended, 2, 0);
            this.table_conKIS_save.Controls.Add(this.text_path_save_settings, 0, 2);
            this.table_conKIS_save.Controls.Add(this.text_path_log, 0, 1);
            this.table_conKIS_save.Dock = System.Windows.Forms.DockStyle.Top;
            this.table_conKIS_save.Location = new System.Drawing.Point(3, 173);
            this.table_conKIS_save.Name = "table_conKIS_save";
            this.table_conKIS_save.RowCount = 3;
            this.table_conKIS_save.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 60F));
            this.table_conKIS_save.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 27F));
            this.table_conKIS_save.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 13F));
            this.table_conKIS_save.Size = new System.Drawing.Size(389, 117);
            this.table_conKIS_save.TabIndex = 1;
            // 
            // btn_form_connect_KIS
            // 
            this.btn_form_connect_KIS.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btn_form_connect_KIS.Location = new System.Drawing.Point(3, 3);
            this.btn_form_connect_KIS.Name = "btn_form_connect_KIS";
            this.btn_form_connect_KIS.Size = new System.Drawing.Size(123, 54);
            this.btn_form_connect_KIS.TabIndex = 0;
            this.btn_form_connect_KIS.Text = "Подключение к КИС дистрибьютора";
            this.btn_form_connect_KIS.UseVisualStyleBackColor = true;
            this.btn_form_connect_KIS.Click += new System.EventHandler(this.btn_form_connect_KIS_Click);
            // 
            // btn_save_settings
            // 
            this.btn_save_settings.Location = new System.Drawing.Point(132, 3);
            this.btn_save_settings.Name = "btn_save_settings";
            this.btn_save_settings.Size = new System.Drawing.Size(123, 54);
            this.btn_save_settings.TabIndex = 1;
            this.btn_save_settings.Text = "Сохранить настройки";
            this.btn_save_settings.UseVisualStyleBackColor = true;
            this.btn_save_settings.Click += new System.EventHandler(this.btn_save_settings_Click);
            // 
            // check_log_extended
            // 
            this.check_log_extended.Dock = System.Windows.Forms.DockStyle.Fill;
            this.check_log_extended.Location = new System.Drawing.Point(261, 3);
            this.check_log_extended.Name = "check_log_extended";
            this.check_log_extended.Size = new System.Drawing.Size(125, 54);
            this.check_log_extended.TabIndex = 2;
            this.check_log_extended.Text = "Расширенный лог";
            this.check_log_extended.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.check_log_extended.UseVisualStyleBackColor = true;
            // 
            // text_path_save_settings
            // 
            this.table_conKIS_save.SetColumnSpan(this.text_path_save_settings, 3);
            this.text_path_save_settings.Dock = System.Windows.Forms.DockStyle.Fill;
            this.text_path_save_settings.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.text_path_save_settings.Location = new System.Drawing.Point(3, 90);
            this.text_path_save_settings.Name = "text_path_save_settings";
            this.text_path_save_settings.ReadOnly = true;
            this.text_path_save_settings.Size = new System.Drawing.Size(383, 23);
            this.text_path_save_settings.TabIndex = 3;
            this.text_path_save_settings.Text = "Путь к файлу настроек";
            // 
            // text_path_log
            // 
            this.table_conKIS_save.SetColumnSpan(this.text_path_log, 3);
            this.text_path_log.Dock = System.Windows.Forms.DockStyle.Fill;
            this.text_path_log.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.text_path_log.Location = new System.Drawing.Point(3, 63);
            this.text_path_log.Name = "text_path_log";
            this.text_path_log.ReadOnly = true;
            this.text_path_log.Size = new System.Drawing.Size(383, 23);
            this.text_path_log.TabIndex = 4;
            this.text_path_log.Text = "Путь к файлу лога";
            // 
            // tab_sinhron
            // 
            this.tab_sinhron.Controls.Add(this.table_total_sinhr);
            this.tab_sinhron.Location = new System.Drawing.Point(4, 22);
            this.tab_sinhron.Name = "tab_sinhron";
            this.tab_sinhron.Padding = new System.Windows.Forms.Padding(3);
            this.tab_sinhron.Size = new System.Drawing.Size(401, 360);
            this.tab_sinhron.TabIndex = 0;
            this.tab_sinhron.Text = "Синхронизация данных";
            this.tab_sinhron.UseVisualStyleBackColor = true;
            // 
            // table_total_sinhr
            // 
            this.table_total_sinhr.ColumnCount = 1;
            this.table_total_sinhr.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.table_total_sinhr.Controls.Add(this.panel_total_sinhr, 0, 0);
            this.table_total_sinhr.Controls.Add(this.rich_log_text, 0, 1);
            this.table_total_sinhr.Dock = System.Windows.Forms.DockStyle.Fill;
            this.table_total_sinhr.Location = new System.Drawing.Point(3, 3);
            this.table_total_sinhr.Name = "table_total_sinhr";
            this.table_total_sinhr.RowCount = 2;
            this.table_total_sinhr.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.table_total_sinhr.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.table_total_sinhr.Size = new System.Drawing.Size(395, 354);
            this.table_total_sinhr.TabIndex = 0;
            // 
            // panel_total_sinhr
            // 
            this.panel_total_sinhr.Controls.Add(this.btn_prods_sinhr);
            this.panel_total_sinhr.Controls.Add(this.btn_client_sinhr);
            this.panel_total_sinhr.Controls.Add(this.btn_total_sinhr);
            this.panel_total_sinhr.Controls.Add(this.btn_totalDocs_sinhr);
            this.panel_total_sinhr.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel_total_sinhr.Location = new System.Drawing.Point(3, 3);
            this.panel_total_sinhr.Name = "panel_total_sinhr";
            this.panel_total_sinhr.Size = new System.Drawing.Size(389, 171);
            this.panel_total_sinhr.TabIndex = 0;
            // 
            // btn_prods_sinhr
            // 
            this.btn_prods_sinhr.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_prods_sinhr.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btn_prods_sinhr.Location = new System.Drawing.Point(229, 34);
            this.btn_prods_sinhr.Name = "btn_prods_sinhr";
            this.btn_prods_sinhr.Size = new System.Drawing.Size(157, 35);
            this.btn_prods_sinhr.TabIndex = 3;
            this.btn_prods_sinhr.Text = "Выгрузка номенклатуры";
            this.btn_prods_sinhr.UseVisualStyleBackColor = true;
            this.btn_prods_sinhr.Click += new System.EventHandler(this.btn_prods_sinhr_Click);
            // 
            // btn_client_sinhr
            // 
            this.btn_client_sinhr.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btn_client_sinhr.Location = new System.Drawing.Point(3, 34);
            this.btn_client_sinhr.Name = "btn_client_sinhr";
            this.btn_client_sinhr.Size = new System.Drawing.Size(154, 35);
            this.btn_client_sinhr.TabIndex = 2;
            this.btn_client_sinhr.Text = "Выгрузка контрагентов";
            this.btn_client_sinhr.UseVisualStyleBackColor = true;
            this.btn_client_sinhr.Click += new System.EventHandler(this.btn_client_sinhr_Click);
            // 
            // btn_total_sinhr
            // 
            this.btn_total_sinhr.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.btn_total_sinhr.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btn_total_sinhr.Location = new System.Drawing.Point(0, 102);
            this.btn_total_sinhr.Name = "btn_total_sinhr";
            this.btn_total_sinhr.Size = new System.Drawing.Size(389, 37);
            this.btn_total_sinhr.TabIndex = 1;
            this.btn_total_sinhr.Text = "Полная синхронизация";
            this.btn_total_sinhr.UseVisualStyleBackColor = true;
            this.btn_total_sinhr.Click += new System.EventHandler(this.btn_total_sinhr_Click);
            // 
            // btn_totalDocs_sinhr
            // 
            this.btn_totalDocs_sinhr.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.btn_totalDocs_sinhr.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btn_totalDocs_sinhr.Location = new System.Drawing.Point(0, 139);
            this.btn_totalDocs_sinhr.Name = "btn_totalDocs_sinhr";
            this.btn_totalDocs_sinhr.Size = new System.Drawing.Size(389, 32);
            this.btn_totalDocs_sinhr.TabIndex = 0;
            this.btn_totalDocs_sinhr.Text = "Синхронизация документов";
            this.btn_totalDocs_sinhr.UseVisualStyleBackColor = true;
            this.btn_totalDocs_sinhr.Click += new System.EventHandler(this.btn_totalDocs_sinhr_Click);
            // 
            // rich_log_text
            // 
            this.rich_log_text.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rich_log_text.Location = new System.Drawing.Point(3, 180);
            this.rich_log_text.Name = "rich_log_text";
            this.rich_log_text.ReadOnly = true;
            this.rich_log_text.Size = new System.Drawing.Size(389, 171);
            this.rich_log_text.TabIndex = 1;
            this.rich_log_text.Text = "";
            // 
            // tabControl
            // 
            this.tabControl.Controls.Add(this.tab_sinhron);
            this.tabControl.Controls.Add(this.tab_sales_zakaz);
            this.tabControl.Controls.Add(this.tab_ost);
            this.tabControl.Controls.Add(this.tab_connect);
            this.tabControl.Location = new System.Drawing.Point(0, 0);
            this.tabControl.Margin = new System.Windows.Forms.Padding(3, 3, 3, 0);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(409, 386);
            this.tabControl.TabIndex = 4;
            // 
            // tab_sales_zakaz
            // 
            this.tab_sales_zakaz.Controls.Add(this.table_docs_sinhr);
            this.tab_sales_zakaz.Location = new System.Drawing.Point(4, 22);
            this.tab_sales_zakaz.Name = "tab_sales_zakaz";
            this.tab_sales_zakaz.Size = new System.Drawing.Size(401, 360);
            this.tab_sales_zakaz.TabIndex = 2;
            this.tab_sales_zakaz.Text = "Продажи и заказы";
            this.tab_sales_zakaz.UseVisualStyleBackColor = true;
            // 
            // table_docs_sinhr
            // 
            this.table_docs_sinhr.ColumnCount = 1;
            this.table_docs_sinhr.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.table_docs_sinhr.Controls.Add(this.rich_log_text_sales, 0, 1);
            this.table_docs_sinhr.Controls.Add(this.table_sales_orders, 0, 0);
            this.table_docs_sinhr.Dock = System.Windows.Forms.DockStyle.Fill;
            this.table_docs_sinhr.Location = new System.Drawing.Point(0, 0);
            this.table_docs_sinhr.Name = "table_docs_sinhr";
            this.table_docs_sinhr.RowCount = 2;
            this.table_docs_sinhr.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.table_docs_sinhr.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.table_docs_sinhr.Size = new System.Drawing.Size(401, 360);
            this.table_docs_sinhr.TabIndex = 0;
            // 
            // rich_log_text_sales
            // 
            this.rich_log_text_sales.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rich_log_text_sales.Location = new System.Drawing.Point(3, 183);
            this.rich_log_text_sales.Name = "rich_log_text_sales";
            this.rich_log_text_sales.ReadOnly = true;
            this.rich_log_text_sales.Size = new System.Drawing.Size(395, 174);
            this.rich_log_text_sales.TabIndex = 2;
            this.rich_log_text_sales.Text = "";
            // 
            // table_sales_orders
            // 
            this.table_sales_orders.ColumnCount = 2;
            this.table_sales_orders.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.table_sales_orders.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.table_sales_orders.Controls.Add(this.group_sales, 0, 0);
            this.table_sales_orders.Controls.Add(this.group_orders, 1, 0);
            this.table_sales_orders.Dock = System.Windows.Forms.DockStyle.Fill;
            this.table_sales_orders.Location = new System.Drawing.Point(3, 3);
            this.table_sales_orders.Name = "table_sales_orders";
            this.table_sales_orders.RowCount = 1;
            this.table_sales_orders.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.table_sales_orders.Size = new System.Drawing.Size(395, 174);
            this.table_sales_orders.TabIndex = 3;
            // 
            // group_sales
            // 
            this.group_sales.Controls.Add(this.label5);
            this.group_sales.Controls.Add(this.label4);
            this.group_sales.Controls.Add(this.date_docs_to);
            this.group_sales.Controls.Add(this.date_docs_from);
            this.group_sales.Controls.Add(this.btn_sales);
            this.group_sales.Dock = System.Windows.Forms.DockStyle.Fill;
            this.group_sales.Location = new System.Drawing.Point(3, 3);
            this.group_sales.Name = "group_sales";
            this.group_sales.Size = new System.Drawing.Size(191, 168);
            this.group_sales.TabIndex = 0;
            this.group_sales.TabStop = false;
            this.group_sales.Text = "Продажи";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label5.Location = new System.Drawing.Point(18, 85);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(30, 17);
            this.label5.TabIndex = 4;
            this.label5.Text = "По:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label4.Location = new System.Drawing.Point(27, 33);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(21, 17);
            this.label4.TabIndex = 3;
            this.label4.Text = "С:";
            // 
            // date_docs_to
            // 
            this.date_docs_to.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.date_docs_to.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.date_docs_to.Location = new System.Drawing.Point(54, 80);
            this.date_docs_to.Name = "date_docs_to";
            this.date_docs_to.Size = new System.Drawing.Size(100, 23);
            this.date_docs_to.TabIndex = 2;
            // 
            // date_docs_from
            // 
            this.date_docs_from.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.date_docs_from.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.date_docs_from.Location = new System.Drawing.Point(54, 28);
            this.date_docs_from.Name = "date_docs_from";
            this.date_docs_from.Size = new System.Drawing.Size(100, 23);
            this.date_docs_from.TabIndex = 1;
            // 
            // btn_sales
            // 
            this.btn_sales.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.btn_sales.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btn_sales.Location = new System.Drawing.Point(3, 134);
            this.btn_sales.Name = "btn_sales";
            this.btn_sales.Size = new System.Drawing.Size(185, 31);
            this.btn_sales.TabIndex = 0;
            this.btn_sales.Text = "Выгрузить накладные";
            this.btn_sales.UseVisualStyleBackColor = true;
            this.btn_sales.Click += new System.EventHandler(this.btn_sales_Click);
            // 
            // group_orders
            // 
            this.group_orders.Controls.Add(this.label7);
            this.group_orders.Controls.Add(this.label6);
            this.group_orders.Controls.Add(this.date_order_to);
            this.group_orders.Controls.Add(this.date_order_from);
            this.group_orders.Controls.Add(this.btn_orders);
            this.group_orders.Dock = System.Windows.Forms.DockStyle.Fill;
            this.group_orders.Location = new System.Drawing.Point(200, 3);
            this.group_orders.Name = "group_orders";
            this.group_orders.Size = new System.Drawing.Size(192, 168);
            this.group_orders.TabIndex = 1;
            this.group_orders.TabStop = false;
            this.group_orders.Text = "Заказы";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label7.Location = new System.Drawing.Point(16, 85);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(30, 17);
            this.label7.TabIndex = 4;
            this.label7.Text = "По:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label6.Location = new System.Drawing.Point(25, 33);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(21, 17);
            this.label6.TabIndex = 3;
            this.label6.Text = "С:";
            // 
            // date_order_to
            // 
            this.date_order_to.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.date_order_to.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.date_order_to.Location = new System.Drawing.Point(52, 80);
            this.date_order_to.Name = "date_order_to";
            this.date_order_to.Size = new System.Drawing.Size(100, 23);
            this.date_order_to.TabIndex = 2;
            // 
            // date_order_from
            // 
            this.date_order_from.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.date_order_from.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.date_order_from.Location = new System.Drawing.Point(52, 28);
            this.date_order_from.Name = "date_order_from";
            this.date_order_from.Size = new System.Drawing.Size(100, 23);
            this.date_order_from.TabIndex = 1;
            // 
            // btn_orders
            // 
            this.btn_orders.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.btn_orders.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btn_orders.Location = new System.Drawing.Point(3, 134);
            this.btn_orders.Name = "btn_orders";
            this.btn_orders.Size = new System.Drawing.Size(186, 31);
            this.btn_orders.TabIndex = 0;
            this.btn_orders.Text = "Загрузить заказы";
            this.btn_orders.UseVisualStyleBackColor = true;
            this.btn_orders.Click += new System.EventHandler(this.btn_orders_Click);
            // 
            // tab_ost
            // 
            this.tab_ost.Controls.Add(this.table_ost_sinhr);
            this.tab_ost.Location = new System.Drawing.Point(4, 22);
            this.tab_ost.Name = "tab_ost";
            this.tab_ost.Size = new System.Drawing.Size(401, 360);
            this.tab_ost.TabIndex = 3;
            this.tab_ost.Text = "Остатки";
            this.tab_ost.UseVisualStyleBackColor = true;
            // 
            // table_ost_sinhr
            // 
            this.table_ost_sinhr.ColumnCount = 1;
            this.table_ost_sinhr.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.table_ost_sinhr.Controls.Add(this.rich_log_text_ost, 0, 1);
            this.table_ost_sinhr.Controls.Add(this.panel_ost, 0, 0);
            this.table_ost_sinhr.Dock = System.Windows.Forms.DockStyle.Fill;
            this.table_ost_sinhr.Location = new System.Drawing.Point(0, 0);
            this.table_ost_sinhr.Name = "table_ost_sinhr";
            this.table_ost_sinhr.RowCount = 2;
            this.table_ost_sinhr.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.table_ost_sinhr.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.table_ost_sinhr.Size = new System.Drawing.Size(401, 360);
            this.table_ost_sinhr.TabIndex = 0;
            // 
            // rich_log_text_ost
            // 
            this.rich_log_text_ost.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rich_log_text_ost.Location = new System.Drawing.Point(3, 183);
            this.rich_log_text_ost.Name = "rich_log_text_ost";
            this.rich_log_text_ost.ReadOnly = true;
            this.rich_log_text_ost.Size = new System.Drawing.Size(395, 174);
            this.rich_log_text_ost.TabIndex = 3;
            this.rich_log_text_ost.Text = "";
            // 
            // panel_ost
            // 
            this.panel_ost.Controls.Add(this.btn_ost);
            this.panel_ost.Controls.Add(this.btn_clear_w_hoses);
            this.panel_ost.Controls.Add(this.btn_del_warehouse);
            this.panel_ost.Controls.Add(this.btn_add_warehouse);
            this.panel_ost.Controls.Add(this.warehouses);
            this.panel_ost.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel_ost.Location = new System.Drawing.Point(3, 3);
            this.panel_ost.Name = "panel_ost";
            this.panel_ost.Size = new System.Drawing.Size(395, 174);
            this.panel_ost.TabIndex = 4;
            // 
            // btn_ost
            // 
            this.btn_ost.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.btn_ost.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btn_ost.Location = new System.Drawing.Point(0, 136);
            this.btn_ost.Name = "btn_ost";
            this.btn_ost.Size = new System.Drawing.Size(395, 38);
            this.btn_ost.TabIndex = 4;
            this.btn_ost.Text = "Выгрузить остатки";
            this.btn_ost.UseVisualStyleBackColor = true;
            this.btn_ost.Click += new System.EventHandler(this.btn_ost_Click);
            // 
            // btn_clear_w_hoses
            // 
            this.btn_clear_w_hoses.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btn_clear_w_hoses.Location = new System.Drawing.Point(284, 13);
            this.btn_clear_w_hoses.Name = "btn_clear_w_hoses";
            this.btn_clear_w_hoses.Size = new System.Drawing.Size(106, 50);
            this.btn_clear_w_hoses.TabIndex = 3;
            this.btn_clear_w_hoses.Text = "Очистить список";
            this.btn_clear_w_hoses.UseVisualStyleBackColor = true;
            this.btn_clear_w_hoses.Click += new System.EventHandler(this.btn_clear_w_hoses_Click);
            // 
            // btn_del_warehouse
            // 
            this.btn_del_warehouse.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btn_del_warehouse.Location = new System.Drawing.Point(135, 41);
            this.btn_del_warehouse.Name = "btn_del_warehouse";
            this.btn_del_warehouse.Size = new System.Drawing.Size(127, 31);
            this.btn_del_warehouse.TabIndex = 2;
            this.btn_del_warehouse.Text = "Удалить склад";
            this.btn_del_warehouse.UseVisualStyleBackColor = true;
            this.btn_del_warehouse.Click += new System.EventHandler(this.btn_del_warehouse_Click);
            // 
            // btn_add_warehouse
            // 
            this.btn_add_warehouse.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btn_add_warehouse.Location = new System.Drawing.Point(135, 3);
            this.btn_add_warehouse.Name = "btn_add_warehouse";
            this.btn_add_warehouse.Size = new System.Drawing.Size(127, 32);
            this.btn_add_warehouse.TabIndex = 1;
            this.btn_add_warehouse.Text = "Добавить склад";
            this.btn_add_warehouse.UseVisualStyleBackColor = true;
            this.btn_add_warehouse.Click += new System.EventHandler(this.btn_add_warehouse_Click);
            // 
            // warehouses
            // 
            this.warehouses.FormattingEnabled = true;
            this.warehouses.Location = new System.Drawing.Point(6, 3);
            this.warehouses.Name = "warehouses";
            this.warehouses.Size = new System.Drawing.Size(120, 95);
            this.warehouses.TabIndex = 0;
            // 
            // table_progress
            // 
            this.table_progress.ColumnCount = 3;
            this.table_progress.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33F));
            this.table_progress.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33F));
            this.table_progress.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 34F));
            this.table_progress.Controls.Add(this.progress_sinhronization, 0, 0);
            this.table_progress.Controls.Add(this.label_info, 2, 0);
            this.table_progress.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.table_progress.Location = new System.Drawing.Point(0, 386);
            this.table_progress.Margin = new System.Windows.Forms.Padding(3, 0, 3, 3);
            this.table_progress.Name = "table_progress";
            this.table_progress.RowCount = 1;
            this.table_progress.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.table_progress.Size = new System.Drawing.Size(409, 19);
            this.table_progress.TabIndex = 3;
            // 
            // label_info
            // 
            this.label_info.AutoSize = true;
            this.label_info.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label_info.Location = new System.Drawing.Point(271, 0);
            this.label_info.Name = "label_info";
            this.label_info.Size = new System.Drawing.Size(135, 19);
            this.label_info.TabIndex = 3;
            this.label_info.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // bg_CLN
            // 
            this.bg_CLN.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bg_CLN_DoWork);
            // 
            // bg_PROD
            // 
            this.bg_PROD.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bg_PROD_DoWork);
            // 
            // bg_DOCS
            // 
            this.bg_DOCS.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bg_DOCS_DoWork);
            // 
            // bg_OST
            // 
            this.bg_OST.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bg_OST_DoWork);
            // 
            // bg_ORDERS
            // 
            this.bg_ORDERS.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bg_ORDERS_DoWork);
            // 
            // bg_Sinh_DOC
            // 
            this.bg_Sinh_DOC.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bg_Sinh_DOC_DoWork);
            // 
            // bg_FULL
            // 
            this.bg_FULL.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bg_FULL_DoWork);
            // 
            // Mainform
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(409, 468);
            this.Controls.Add(this.table_progress);
            this.Controls.Add(this.tabControl);
            this.Controls.Add(this.table_copyright);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Mainform";
            this.Text = "CMAPintegrator";
            this.Load += new System.EventHandler(this.Mainform_Load);
            this.table_copyright.ResumeLayout(false);
            this.split_copy.Panel1.ResumeLayout(false);
            this.split_copy.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.split_copy)).EndInit();
            this.split_copy.ResumeLayout(false);
            this.tab_connect.ResumeLayout(false);
            this.table_connect.ResumeLayout(false);
            this.gr_connect_CMAP.ResumeLayout(false);
            this.table_connect_CMAP.ResumeLayout(false);
            this.table_connect_CMAP.PerformLayout();
            this.table_conKIS_save.ResumeLayout(false);
            this.table_conKIS_save.PerformLayout();
            this.tab_sinhron.ResumeLayout(false);
            this.table_total_sinhr.ResumeLayout(false);
            this.panel_total_sinhr.ResumeLayout(false);
            this.tabControl.ResumeLayout(false);
            this.tab_sales_zakaz.ResumeLayout(false);
            this.table_docs_sinhr.ResumeLayout(false);
            this.table_sales_orders.ResumeLayout(false);
            this.group_sales.ResumeLayout(false);
            this.group_sales.PerformLayout();
            this.group_orders.ResumeLayout(false);
            this.group_orders.PerformLayout();
            this.tab_ost.ResumeLayout(false);
            this.table_ost_sinhr.ResumeLayout(false);
            this.panel_ost.ResumeLayout(false);
            this.table_progress.ResumeLayout(false);
            this.table_progress.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.TableLayoutPanel table_copyright;
        private System.Windows.Forms.Label label1;
        public System.Windows.Forms.Label label2;
        private System.Windows.Forms.SplitContainer split_copy;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.LinkLabel link;
        public System.Windows.Forms.ProgressBar progress_sinhronization;
        private System.Windows.Forms.TabPage tab_connect;
        private System.Windows.Forms.TableLayoutPanel table_connect;
        private System.Windows.Forms.GroupBox gr_connect_CMAP;
        private System.Windows.Forms.TableLayoutPanel table_connect_CMAP;
        private System.Windows.Forms.Label label_IP_CMAP;
        private System.Windows.Forms.Label label_login_CMAP;
        private System.Windows.Forms.Label label_pass_CMAP;
        private System.Windows.Forms.Label label_path_CMAP;
        public System.Windows.Forms.TextBox text_IP_CMAP;
        public System.Windows.Forms.TextBox text_login_CMAP;
        public System.Windows.Forms.TextBox text_pass_CMAP;
        public System.Windows.Forms.TextBox text_path_CMAP;
        private System.Windows.Forms.Button btn_connect_CMAP;
        private System.Windows.Forms.TableLayoutPanel table_conKIS_save;
        private System.Windows.Forms.Button btn_form_connect_KIS;
        private System.Windows.Forms.Button btn_save_settings;
        public System.Windows.Forms.CheckBox check_log_extended;
        public System.Windows.Forms.TextBox text_path_save_settings;
        private System.Windows.Forms.TabPage tab_sinhron;
        private System.Windows.Forms.TableLayoutPanel table_total_sinhr;
        private System.Windows.Forms.Panel panel_total_sinhr;
        private System.Windows.Forms.Button btn_total_sinhr;
        private System.Windows.Forms.Button btn_totalDocs_sinhr;
        public System.Windows.Forms.RichTextBox rich_log_text;
        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.Button btn_prods_sinhr;
        private System.Windows.Forms.Button btn_client_sinhr;
        private System.Windows.Forms.TabPage tab_sales_zakaz;
        private System.Windows.Forms.TableLayoutPanel table_docs_sinhr;
        public System.Windows.Forms.RichTextBox rich_log_text_sales;
        private System.Windows.Forms.TableLayoutPanel table_sales_orders;
        private System.Windows.Forms.GroupBox group_sales;
        private System.Windows.Forms.GroupBox group_orders;
        private System.Windows.Forms.DateTimePicker date_docs_to;
        private System.Windows.Forms.DateTimePicker date_docs_from;
        private System.Windows.Forms.Button btn_sales;
        private System.Windows.Forms.Button btn_orders;
        private System.Windows.Forms.DateTimePicker date_order_to;
        private System.Windows.Forms.DateTimePicker date_order_from;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TabPage tab_ost;
        private System.Windows.Forms.TableLayoutPanel table_ost_sinhr;
        public System.Windows.Forms.RichTextBox rich_log_text_ost;
        private System.Windows.Forms.Panel panel_ost;
        private System.Windows.Forms.Button btn_ost;
        private System.Windows.Forms.Button btn_clear_w_hoses;
        private System.Windows.Forms.Button btn_del_warehouse;
        private System.Windows.Forms.Button btn_add_warehouse;
        public System.Windows.Forms.ListBox warehouses;
        private System.Windows.Forms.TextBox text_path_log;
        private System.Windows.Forms.TableLayoutPanel table_progress;
        private System.Windows.Forms.Label label_info;
        private System.ComponentModel.BackgroundWorker bg_CLN;
        private System.ComponentModel.BackgroundWorker bg_PROD;
        private System.ComponentModel.BackgroundWorker bg_DOCS;
        private System.ComponentModel.BackgroundWorker bg_OST;
        private System.ComponentModel.BackgroundWorker bg_ORDERS;
        private System.ComponentModel.BackgroundWorker bg_Sinh_DOC;
        private System.ComponentModel.BackgroundWorker bg_FULL;
    }
}