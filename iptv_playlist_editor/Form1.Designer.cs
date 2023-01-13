namespace iptv_playlist_editor
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.txtUrl = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnLoad = new System.Windows.Forms.Button();
            this.dgvGroup = new System.Windows.Forms.DataGridView();
            this.Del = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.Group = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvGroupChannels = new System.Windows.Forms.DataGridView();
            this.Title = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.btnSave = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.btnDel = new System.Windows.Forms.Button();
            this.gridSummary = new System.Windows.Forms.DataGridView();
            this.SeriesTitle = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnSAll = new System.Windows.Forms.Button();
            this.bSNone = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvGroup)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvGroupChannels)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridSummary)).BeginInit();
            this.SuspendLayout();
            // 
            // txtUrl
            // 
            this.txtUrl.Location = new System.Drawing.Point(59, 12);
            this.txtUrl.Name = "txtUrl";
            this.txtUrl.Size = new System.Drawing.Size(632, 23);
            this.txtUrl.TabIndex = 0;
            this.txtUrl.Text = "" +
    "lus&output=mpegts";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(29, 15);
            this.label1.TabIndex = 1;
            this.label1.Text = "Link";
            // 
            // btnLoad
            // 
            this.btnLoad.Location = new System.Drawing.Point(697, 12);
            this.btnLoad.Name = "btnLoad";
            this.btnLoad.Size = new System.Drawing.Size(75, 23);
            this.btnLoad.TabIndex = 2;
            this.btnLoad.Text = "Load";
            this.btnLoad.UseVisualStyleBackColor = true;
            this.btnLoad.Click += new System.EventHandler(this.btnLoad_Click);
            // 
            // dgvGroup
            // 
            this.dgvGroup.AllowUserToAddRows = false;
            this.dgvGroup.AllowUserToDeleteRows = false;
            this.dgvGroup.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvGroup.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Del,
            this.Group});
            this.dgvGroup.Location = new System.Drawing.Point(12, 70);
            this.dgvGroup.Name = "dgvGroup";
            this.dgvGroup.RowTemplate.Height = 25;
            this.dgvGroup.Size = new System.Drawing.Size(363, 769);
            this.dgvGroup.TabIndex = 3;
            this.dgvGroup.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvGroup_CellClick);
            this.dgvGroup.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvGroup_CellContentClick);
            this.dgvGroup.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvGroup_CellEndEdit);
            this.dgvGroup.CellMouseDown += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgvGroup_CellMouseDown);
            this.dgvGroup.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvGroup_CellValueChanged);
            this.dgvGroup.CurrentCellDirtyStateChanged += new System.EventHandler(this.dgvGroup_CurrentCellDirtyStateChanged);
            this.dgvGroup.RowHeaderMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgvGroup_RowHeaderMouseClick);
            this.dgvGroup.RowsRemoved += new System.Windows.Forms.DataGridViewRowsRemovedEventHandler(this.dgvGroup_RowsRemoved);
            this.dgvGroup.UserDeletedRow += new System.Windows.Forms.DataGridViewRowEventHandler(this.dgvGroup_UserDeletedRow);
            this.dgvGroup.UserDeletingRow += new System.Windows.Forms.DataGridViewRowCancelEventHandler(this.dgvGroup_UserDeletingRow);
            // 
            // Del
            // 
            this.Del.DataPropertyName = "Del";
            this.Del.HeaderText = "Delete";
            this.Del.Name = "Del";
            // 
            // Group
            // 
            this.Group.DataPropertyName = "Group";
            this.Group.HeaderText = "Group";
            this.Group.Name = "Group";
            this.Group.Width = 200;
            // 
            // dgvGroupChannels
            // 
            this.dgvGroupChannels.AllowUserToAddRows = false;
            this.dgvGroupChannels.AllowUserToDeleteRows = false;
            this.dgvGroupChannels.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvGroupChannels.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Title});
            this.dgvGroupChannels.Location = new System.Drawing.Point(381, 411);
            this.dgvGroupChannels.Name = "dgvGroupChannels";
            this.dgvGroupChannels.ReadOnly = true;
            this.dgvGroupChannels.RowTemplate.Height = 25;
            this.dgvGroupChannels.Size = new System.Drawing.Size(743, 428);
            this.dgvGroupChannels.TabIndex = 4;
            // 
            // Title
            // 
            this.Title.DataPropertyName = "Title";
            this.Title.HeaderText = "Title";
            this.Title.Name = "Title";
            this.Title.ReadOnly = true;
            this.Title.Width = 500;
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(1015, 12);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(92, 23);
            this.btnSave.TabIndex = 5;
            this.btnSave.Text = "Save M3U";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 49);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(45, 15);
            this.label2.TabIndex = 6;
            this.label2.Text = "Groups";
            // 
            // btnDel
            // 
            this.btnDel.Location = new System.Drawing.Point(235, 41);
            this.btnDel.Name = "btnDel";
            this.btnDel.Size = new System.Drawing.Size(140, 23);
            this.btnDel.TabIndex = 8;
            this.btnDel.Text = "Delete Selected Group";
            this.btnDel.UseVisualStyleBackColor = true;
            this.btnDel.Click += new System.EventHandler(this.btnDel_Click);
            // 
            // gridSummary
            // 
            this.gridSummary.AllowUserToAddRows = false;
            this.gridSummary.AllowUserToDeleteRows = false;
            this.gridSummary.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridSummary.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.SeriesTitle});
            this.gridSummary.Location = new System.Drawing.Point(381, 70);
            this.gridSummary.Name = "gridSummary";
            this.gridSummary.ReadOnly = true;
            this.gridSummary.RowTemplate.Height = 25;
            this.gridSummary.Size = new System.Drawing.Size(743, 335);
            this.gridSummary.TabIndex = 9;
            // 
            // SeriesTitle
            // 
            this.SeriesTitle.DataPropertyName = "SeriesTitle";
            this.SeriesTitle.HeaderText = "SeriesTitle";
            this.SeriesTitle.Name = "SeriesTitle";
            this.SeriesTitle.ReadOnly = true;
            this.SeriesTitle.Width = 500;
            // 
            // btnSAll
            // 
            this.btnSAll.Location = new System.Drawing.Point(381, 41);
            this.btnSAll.Name = "btnSAll";
            this.btnSAll.Size = new System.Drawing.Size(96, 23);
            this.btnSAll.TabIndex = 10;
            this.btnSAll.Text = "Select All";
            this.btnSAll.UseVisualStyleBackColor = true;
            this.btnSAll.Click += new System.EventHandler(this.btnSAll_Click);
            // 
            // bSNone
            // 
            this.bSNone.Location = new System.Drawing.Point(483, 41);
            this.bSNone.Name = "bSNone";
            this.bSNone.Size = new System.Drawing.Size(96, 23);
            this.bSNone.TabIndex = 11;
            this.bSNone.Text = "Select None";
            this.bSNone.UseVisualStyleBackColor = true;
            this.bSNone.Click += new System.EventHandler(this.bSNone_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1127, 848);
            this.Controls.Add(this.bSNone);
            this.Controls.Add(this.btnSAll);
            this.Controls.Add(this.gridSummary);
            this.Controls.Add(this.btnDel);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.dgvGroupChannels);
            this.Controls.Add(this.dgvGroup);
            this.Controls.Add(this.btnLoad);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtUrl);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.dgvGroup)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvGroupChannels)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridSummary)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private TextBox txtUrl;
        private Label label1;
        private Button btnLoad;
        private DataGridView dgvGroup;
        private DataGridView dgvGroupChannels;
        private SaveFileDialog saveFileDialog1;
        private Button btnSave;
        private Label label2;
        private DataGridViewTextBoxColumn Title;
        private Button btnDel;
        private DataGridViewCheckBoxColumn Del;
        private DataGridViewTextBoxColumn Group;
        private DataGridView gridSummary;
        private DataGridViewTextBoxColumn SeriesTitle;
        private Button btnSAll;
        private Button bSNone;
    }
}