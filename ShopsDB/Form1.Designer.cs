namespace ShopsDB
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.SaveDB_button = new System.Windows.Forms.Button();
            this.UpdateDB_button = new System.Windows.Forms.Button();
            this.LoadDB_button = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.ClearDB_button = new System.Windows.Forms.Button();
            this.SearchDB_button = new System.Windows.Forms.Button();
            this.SearchDB_textBox = new System.Windows.Forms.TextBox();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.UserManual_button = new System.Windows.Forms.Button();
            this.DevInfo_button = new System.Windows.Forms.Button();
            this.shopsDataSet = new ShopsDB.ShopsDataSet();
            this.shopsDataSetBindingSource = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.shopsDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.shopsDataSetBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells;
            this.dataGridView1.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedCells;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            resources.ApplyResources(this.dataGridView1, "dataGridView1");
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            this.dataGridView1.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellValueChanged);
            this.dataGridView1.EditingControlShowing += new System.Windows.Forms.DataGridViewEditingControlShowingEventHandler(this.dataGridView1_EditingControlShowing);
            this.dataGridView1.UserAddedRow += new System.Windows.Forms.DataGridViewRowEventHandler(this.dataGridView1_UserAddedRow);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.SaveDB_button);
            this.groupBox1.Controls.Add(this.UpdateDB_button);
            this.groupBox1.Controls.Add(this.LoadDB_button);
            resources.ApplyResources(this.groupBox1, "groupBox1");
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.TabStop = false;
            // 
            // SaveDB_button
            // 
            resources.ApplyResources(this.SaveDB_button, "SaveDB_button");
            this.SaveDB_button.Name = "SaveDB_button";
            this.SaveDB_button.UseVisualStyleBackColor = true;
            this.SaveDB_button.Click += new System.EventHandler(this.SaveDB_Click);
            // 
            // UpdateDB_button
            // 
            resources.ApplyResources(this.UpdateDB_button, "UpdateDB_button");
            this.UpdateDB_button.Name = "UpdateDB_button";
            this.UpdateDB_button.UseVisualStyleBackColor = true;
            this.UpdateDB_button.Click += new System.EventHandler(this.UpdateDB_button_Click);
            // 
            // LoadDB_button
            // 
            resources.ApplyResources(this.LoadDB_button, "LoadDB_button");
            this.LoadDB_button.Name = "LoadDB_button";
            this.LoadDB_button.UseVisualStyleBackColor = true;
            this.LoadDB_button.Click += new System.EventHandler(this.LoadDB_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.ClearDB_button);
            this.groupBox2.Controls.Add(this.SearchDB_button);
            this.groupBox2.Controls.Add(this.SearchDB_textBox);
            resources.ApplyResources(this.groupBox2, "groupBox2");
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.TabStop = false;
            // 
            // ClearDB_button
            // 
            resources.ApplyResources(this.ClearDB_button, "ClearDB_button");
            this.ClearDB_button.Name = "ClearDB_button";
            this.ClearDB_button.UseVisualStyleBackColor = true;
            this.ClearDB_button.Click += new System.EventHandler(this.ClearDB_button_Click);
            // 
            // SearchDB_button
            // 
            resources.ApplyResources(this.SearchDB_button, "SearchDB_button");
            this.SearchDB_button.Name = "SearchDB_button";
            this.SearchDB_button.UseVisualStyleBackColor = true;
            this.SearchDB_button.Click += new System.EventHandler(this.SearchDB_button_Click);
            // 
            // SearchDB_textBox
            // 
            resources.ApplyResources(this.SearchDB_textBox, "SearchDB_textBox");
            this.SearchDB_textBox.Name = "SearchDB_textBox";
            this.toolTip1.SetToolTip(this.SearchDB_textBox, resources.GetString("SearchDB_textBox.ToolTip"));
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.UserManual_button);
            this.groupBox3.Controls.Add(this.DevInfo_button);
            resources.ApplyResources(this.groupBox3, "groupBox3");
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.TabStop = false;
            // 
            // UserManual_button
            // 
            resources.ApplyResources(this.UserManual_button, "UserManual_button");
            this.UserManual_button.Name = "UserManual_button";
            this.UserManual_button.UseVisualStyleBackColor = true;
            this.UserManual_button.Click += new System.EventHandler(this.UserManual_button_Click);
            // 
            // DevInfo_button
            // 
            resources.ApplyResources(this.DevInfo_button, "DevInfo_button");
            this.DevInfo_button.Name = "DevInfo_button";
            this.DevInfo_button.UseVisualStyleBackColor = true;
            this.DevInfo_button.Click += new System.EventHandler(this.DevInfo_button_Click);
            // 
            // shopsDataSet
            // 
            this.shopsDataSet.DataSetName = "ShopsDataSet";
            this.shopsDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // shopsDataSetBindingSource
            // 
            this.shopsDataSetBindingSource.DataSource = this.shopsDataSet;
            this.shopsDataSetBindingSource.Position = 0;
            // 
            // Form1
            // 
            resources.ApplyResources(this, "$this");
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.dataGridView1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.shopsDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.shopsDataSetBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button SaveDB_button;
        private System.Windows.Forms.Button UpdateDB_button;
        private System.Windows.Forms.Button LoadDB_button;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button SearchDB_button;
        private System.Windows.Forms.TextBox SearchDB_textBox;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.Button ClearDB_button;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button UserManual_button;
        private System.Windows.Forms.Button DevInfo_button;
        private System.Windows.Forms.BindingSource shopsDataSetBindingSource;
        private ShopsDataSet shopsDataSet;
    }
}

