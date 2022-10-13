namespace GroceryStore
{
    partial class FormProduct
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
            this.labelName = new System.Windows.Forms.Label();
            this.labelDescription = new System.Windows.Forms.Label();
            this.labelCategory = new System.Windows.Forms.Label();
            this.labelCount = new System.Windows.Forms.Label();
            this.textBoxName = new System.Windows.Forms.TextBox();
            this.textBoxDescription = new System.Windows.Forms.TextBox();
            this.ilbekovComboBoxCategory = new IlbekovVisualComponents.IlbekovComboBox();
            this.madyshevTextBoxCount = new MadyshevVisualComponents.MadyshevTextBox();
            this.buttonSave = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // labelName
            // 
            this.labelName.AutoSize = true;
            this.labelName.Location = new System.Drawing.Point(23, 13);
            this.labelName.Name = "labelName";
            this.labelName.Size = new System.Drawing.Size(73, 16);
            this.labelName.TabIndex = 0;
            this.labelName.Text = "Название";
            // 
            // labelDescription
            // 
            this.labelDescription.AutoSize = true;
            this.labelDescription.Location = new System.Drawing.Point(23, 80);
            this.labelDescription.Name = "labelDescription";
            this.labelDescription.Size = new System.Drawing.Size(72, 16);
            this.labelDescription.TabIndex = 1;
            this.labelDescription.Text = "Описание";
            // 
            // labelCategory
            // 
            this.labelCategory.AutoSize = true;
            this.labelCategory.Location = new System.Drawing.Point(23, 134);
            this.labelCategory.Name = "labelCategory";
            this.labelCategory.Size = new System.Drawing.Size(75, 16);
            this.labelCategory.TabIndex = 2;
            this.labelCategory.Text = "Категория";
            // 
            // labelCount
            // 
            this.labelCount.AutoSize = true;
            this.labelCount.Location = new System.Drawing.Point(23, 198);
            this.labelCount.Name = "labelCount";
            this.labelCount.Size = new System.Drawing.Size(85, 16);
            this.labelCount.TabIndex = 3;
            this.labelCount.Text = "Количество";
            // 
            // textBoxName
            // 
            this.textBoxName.Location = new System.Drawing.Point(12, 33);
            this.textBoxName.Name = "textBoxName";
            this.textBoxName.Size = new System.Drawing.Size(355, 22);
            this.textBoxName.TabIndex = 4;
            // 
            // textBoxDescription
            // 
            this.textBoxDescription.Location = new System.Drawing.Point(12, 99);
            this.textBoxDescription.Name = "textBoxDescription";
            this.textBoxDescription.Size = new System.Drawing.Size(355, 22);
            this.textBoxDescription.TabIndex = 5;
            // 
            // ilbekovComboBoxCategory
            // 
            this.ilbekovComboBoxCategory.ChoosenItem = "";
            this.ilbekovComboBoxCategory.Location = new System.Drawing.Point(12, 152);
            this.ilbekovComboBoxCategory.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.ilbekovComboBoxCategory.Name = "ilbekovComboBoxCategory";
            this.ilbekovComboBoxCategory.Size = new System.Drawing.Size(355, 24);
            this.ilbekovComboBoxCategory.TabIndex = 6;
            // 
            // madyshevTextBoxCount
            // 
            this.madyshevTextBoxCount.Location = new System.Drawing.Point(12, 217);
            this.madyshevTextBoxCount.Name = "madyshevTextBoxCount";
            this.madyshevTextBoxCount.Size = new System.Drawing.Size(355, 47);
            this.madyshevTextBoxCount.TabIndex = 7;
            this.madyshevTextBoxCount.TextBoxValue = null;
            // 
            // buttonSave
            // 
            this.buttonSave.AutoSize = true;
            this.buttonSave.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.buttonSave.Location = new System.Drawing.Point(0, 270);
            this.buttonSave.Name = "buttonSave";
            this.buttonSave.Size = new System.Drawing.Size(379, 26);
            this.buttonSave.TabIndex = 8;
            this.buttonSave.Text = "Сохранить";
            this.buttonSave.UseVisualStyleBackColor = true;
            this.buttonSave.Click += new System.EventHandler(this.buttonSave_Click);
            // 
            // FormProduct
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(379, 296);
            this.Controls.Add(this.buttonSave);
            this.Controls.Add(this.madyshevTextBoxCount);
            this.Controls.Add(this.ilbekovComboBoxCategory);
            this.Controls.Add(this.textBoxDescription);
            this.Controls.Add(this.textBoxName);
            this.Controls.Add(this.labelCount);
            this.Controls.Add(this.labelCategory);
            this.Controls.Add(this.labelDescription);
            this.Controls.Add(this.labelName);
            this.Name = "FormProduct";
            this.Text = "Продукт";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormProduct_FormClosing);
            this.Load += new System.EventHandler(this.FormProduct_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelName;
        private System.Windows.Forms.Label labelDescription;
        private System.Windows.Forms.Label labelCategory;
        private System.Windows.Forms.Label labelCount;
        private System.Windows.Forms.TextBox textBoxName;
        private System.Windows.Forms.TextBox textBoxDescription;
        private IlbekovVisualComponents.IlbekovComboBox ilbekovComboBoxCategory;
        private MadyshevVisualComponents.MadyshevTextBox madyshevTextBoxCount;
        private System.Windows.Forms.Button buttonSave;
    }
}