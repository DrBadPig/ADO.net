namespace ADO_NET_1
{
    partial class Form1
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.comboSearchType = new System.Windows.Forms.ComboBox();
            this.textBoxTableName = new System.Windows.Forms.TextBox();
            this.labelTableName = new System.Windows.Forms.Label();
            this.buttonTableHelp = new System.Windows.Forms.Button();
            this.buttonFind = new System.Windows.Forms.Button();
            this.buttonSetPath = new System.Windows.Forms.Button();
            this.folderBrowserDialog = new System.Windows.Forms.FolderBrowserDialog();
            this.SuspendLayout();
            // 
            // comboSearchType
            // 
            this.comboSearchType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboSearchType.FormattingEnabled = true;
            this.comboSearchType.Items.AddRange(new object[] {
            "Verbs",
            "Adjectives"});
            this.comboSearchType.Location = new System.Drawing.Point(12, 42);
            this.comboSearchType.Name = "comboSearchType";
            this.comboSearchType.Size = new System.Drawing.Size(180, 21);
            this.comboSearchType.TabIndex = 0;
            // 
            // textBoxTableName
            // 
            this.textBoxTableName.Location = new System.Drawing.Point(12, 82);
            this.textBoxTableName.MaxLength = 200;
            this.textBoxTableName.Name = "textBoxTableName";
            this.textBoxTableName.Size = new System.Drawing.Size(154, 20);
            this.textBoxTableName.TabIndex = 1;
            // 
            // labelTableName
            // 
            this.labelTableName.AutoSize = true;
            this.labelTableName.BackColor = System.Drawing.Color.Transparent;
            this.labelTableName.ForeColor = System.Drawing.SystemColors.Control;
            this.labelTableName.Location = new System.Drawing.Point(10, 66);
            this.labelTableName.Name = "labelTableName";
            this.labelTableName.Size = new System.Drawing.Size(63, 13);
            this.labelTableName.TabIndex = 2;
            this.labelTableName.Text = "Table name";
            // 
            // buttonTableHelp
            // 
            this.buttonTableHelp.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("buttonTableHelp.BackgroundImage")));
            this.buttonTableHelp.Cursor = System.Windows.Forms.Cursors.Help;
            this.buttonTableHelp.Location = new System.Drawing.Point(172, 82);
            this.buttonTableHelp.Name = "buttonTableHelp";
            this.buttonTableHelp.Size = new System.Drawing.Size(20, 20);
            this.buttonTableHelp.TabIndex = 3;
            this.buttonTableHelp.Text = "?";
            this.buttonTableHelp.UseVisualStyleBackColor = true;
            this.buttonTableHelp.Click += new System.EventHandler(this.buttonTableHelp_Click);
            // 
            // buttonFind
            // 
            this.buttonFind.BackColor = System.Drawing.Color.Transparent;
            this.buttonFind.Location = new System.Drawing.Point(198, 13);
            this.buttonFind.Name = "buttonFind";
            this.buttonFind.Size = new System.Drawing.Size(62, 89);
            this.buttonFind.TabIndex = 4;
            this.buttonFind.Text = "Find";
            this.buttonFind.UseVisualStyleBackColor = false;
            this.buttonFind.Click += new System.EventHandler(this.buttonFind_Click);
            // 
            // buttonSetPath
            // 
            this.buttonSetPath.Location = new System.Drawing.Point(12, 13);
            this.buttonSetPath.Name = "buttonSetPath";
            this.buttonSetPath.Size = new System.Drawing.Size(180, 23);
            this.buttonSetPath.TabIndex = 5;
            this.buttonSetPath.Text = "Set Path";
            this.buttonSetPath.UseVisualStyleBackColor = true;
            this.buttonSetPath.Click += new System.EventHandler(this.buttonSetPath_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(273, 116);
            this.Controls.Add(this.buttonSetPath);
            this.Controls.Add(this.buttonFind);
            this.Controls.Add(this.buttonTableHelp);
            this.Controls.Add(this.labelTableName);
            this.Controls.Add(this.textBoxTableName);
            this.Controls.Add(this.comboSearchType);
            this.Cursor = System.Windows.Forms.Cursors.Default;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox comboSearchType;
        private System.Windows.Forms.TextBox textBoxTableName;
        private System.Windows.Forms.Label labelTableName;
        private System.Windows.Forms.Button buttonTableHelp;
        private System.Windows.Forms.Button buttonFind;
        private System.Windows.Forms.Button buttonSetPath;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog;
    }
}

