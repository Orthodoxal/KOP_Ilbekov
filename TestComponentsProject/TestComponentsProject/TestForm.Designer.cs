namespace TestComponentsProject
{
    partial class TestForm
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
            this.ilbekovComboBox = new IlbekovVisualComponents.IlbekovComboBox();
            this.buttonClear = new System.Windows.Forms.Button();
            this.groupBoxComboBoxTest = new System.Windows.Forms.GroupBox();
            this.textBoxSetItem = new System.Windows.Forms.TextBox();
            this.labelItem = new System.Windows.Forms.Label();
            this.buttonSetSelectedItem = new System.Windows.Forms.Button();
            this.buttonGetSelectedItem = new System.Windows.Forms.Button();
            this.ilbekovTextBox = new IlbekovVisualComponents.IlbekovTextBox();
            this.groupBoxTextBoxTest = new System.Windows.Forms.GroupBox();
            this.labelCheckedText = new System.Windows.Forms.Label();
            this.buttonGetTextFromTextBox = new System.Windows.Forms.Button();
            this.ilbekovListBox = new IlbekovVisualComponents.IlbekovListBox();
            this.groupBoxListBoxTest = new System.Windows.Forms.GroupBox();
            this.buttonGetSelected = new System.Windows.Forms.Button();
            this.labelItemFromList = new System.Windows.Forms.Label();
            this.groupBoxComboBoxTest.SuspendLayout();
            this.groupBoxTextBoxTest.SuspendLayout();
            this.groupBoxListBoxTest.SuspendLayout();
            this.SuspendLayout();
            // 
            // ilbekovComboBox
            // 
            this.ilbekovComboBox.ChoosenItem = "";
            this.ilbekovComboBox.Location = new System.Drawing.Point(6, 26);
            this.ilbekovComboBox.Name = "ilbekovComboBox";
            this.ilbekovComboBox.Size = new System.Drawing.Size(188, 38);
            this.ilbekovComboBox.TabIndex = 0;
            // 
            // buttonClear
            // 
            this.buttonClear.Location = new System.Drawing.Point(184, 140);
            this.buttonClear.Name = "buttonClear";
            this.buttonClear.Size = new System.Drawing.Size(94, 29);
            this.buttonClear.TabIndex = 1;
            this.buttonClear.Text = "Clear";
            this.buttonClear.UseVisualStyleBackColor = true;
            this.buttonClear.Click += new System.EventHandler(this.buttonClear_Click);
            // 
            // groupBoxComboBoxTest
            // 
            this.groupBoxComboBoxTest.Controls.Add(this.textBoxSetItem);
            this.groupBoxComboBoxTest.Controls.Add(this.labelItem);
            this.groupBoxComboBoxTest.Controls.Add(this.buttonSetSelectedItem);
            this.groupBoxComboBoxTest.Controls.Add(this.buttonGetSelectedItem);
            this.groupBoxComboBoxTest.Controls.Add(this.ilbekovComboBox);
            this.groupBoxComboBoxTest.Controls.Add(this.buttonClear);
            this.groupBoxComboBoxTest.Location = new System.Drawing.Point(12, 12);
            this.groupBoxComboBoxTest.Name = "groupBoxComboBoxTest";
            this.groupBoxComboBoxTest.Size = new System.Drawing.Size(293, 187);
            this.groupBoxComboBoxTest.TabIndex = 2;
            this.groupBoxComboBoxTest.TabStop = false;
            this.groupBoxComboBoxTest.Text = "ComboBox";
            // 
            // textBoxSetItem
            // 
            this.textBoxSetItem.Location = new System.Drawing.Point(6, 107);
            this.textBoxSetItem.Name = "textBoxSetItem";
            this.textBoxSetItem.Size = new System.Drawing.Size(172, 27);
            this.textBoxSetItem.TabIndex = 5;
            // 
            // labelItem
            // 
            this.labelItem.AutoSize = true;
            this.labelItem.Location = new System.Drawing.Point(19, 74);
            this.labelItem.Name = "labelItem";
            this.labelItem.Size = new System.Drawing.Size(0, 20);
            this.labelItem.TabIndex = 4;
            // 
            // buttonSetSelectedItem
            // 
            this.buttonSetSelectedItem.Location = new System.Drawing.Point(184, 105);
            this.buttonSetSelectedItem.Name = "buttonSetSelectedItem";
            this.buttonSetSelectedItem.Size = new System.Drawing.Size(94, 29);
            this.buttonSetSelectedItem.TabIndex = 3;
            this.buttonSetSelectedItem.Text = "Set item";
            this.buttonSetSelectedItem.UseVisualStyleBackColor = true;
            this.buttonSetSelectedItem.Click += new System.EventHandler(this.buttonSetSelectedItem_Click);
            // 
            // buttonGetSelectedItem
            // 
            this.buttonGetSelectedItem.Location = new System.Drawing.Point(184, 70);
            this.buttonGetSelectedItem.Name = "buttonGetSelectedItem";
            this.buttonGetSelectedItem.Size = new System.Drawing.Size(94, 29);
            this.buttonGetSelectedItem.TabIndex = 2;
            this.buttonGetSelectedItem.Text = "Get item";
            this.buttonGetSelectedItem.UseVisualStyleBackColor = true;
            this.buttonGetSelectedItem.Click += new System.EventHandler(this.buttonGetSelectedItem_Click);
            // 
            // ilbekovTextBox
            // 
            this.ilbekovTextBox.Location = new System.Drawing.Point(6, 26);
            this.ilbekovTextBox.Name = "ilbekovTextBox";
            this.ilbekovTextBox.Size = new System.Drawing.Size(182, 29);
            this.ilbekovTextBox.TabIndex = 3;
            this.ilbekovTextBox.Template = "";
            // 
            // groupBoxTextBoxTest
            // 
            this.groupBoxTextBoxTest.Controls.Add(this.labelCheckedText);
            this.groupBoxTextBoxTest.Controls.Add(this.buttonGetTextFromTextBox);
            this.groupBoxTextBoxTest.Controls.Add(this.ilbekovTextBox);
            this.groupBoxTextBoxTest.Location = new System.Drawing.Point(311, 12);
            this.groupBoxTextBoxTest.Name = "groupBoxTextBoxTest";
            this.groupBoxTextBoxTest.Size = new System.Drawing.Size(250, 187);
            this.groupBoxTextBoxTest.TabIndex = 4;
            this.groupBoxTextBoxTest.TabStop = false;
            this.groupBoxTextBoxTest.Text = "TextBox with Date";
            // 
            // labelCheckedText
            // 
            this.labelCheckedText.AutoSize = true;
            this.labelCheckedText.Location = new System.Drawing.Point(21, 70);
            this.labelCheckedText.Name = "labelCheckedText";
            this.labelCheckedText.Size = new System.Drawing.Size(0, 20);
            this.labelCheckedText.TabIndex = 5;
            // 
            // buttonGetTextFromTextBox
            // 
            this.buttonGetTextFromTextBox.Location = new System.Drawing.Point(150, 114);
            this.buttonGetTextFromTextBox.Name = "buttonGetTextFromTextBox";
            this.buttonGetTextFromTextBox.Size = new System.Drawing.Size(94, 29);
            this.buttonGetTextFromTextBox.TabIndex = 4;
            this.buttonGetTextFromTextBox.Text = "Check text";
            this.buttonGetTextFromTextBox.UseVisualStyleBackColor = true;
            this.buttonGetTextFromTextBox.Click += new System.EventHandler(this.buttonGetTextFromTextBox_Click);
            // 
            // ilbekovListBox
            // 
            this.ilbekovListBox.Location = new System.Drawing.Point(6, 26);
            this.ilbekovListBox.Name = "ilbekovListBox";
            this.ilbekovListBox.Size = new System.Drawing.Size(148, 140);
            this.ilbekovListBox.TabIndex = 5;
            // 
            // groupBoxListBoxTest
            // 
            this.groupBoxListBoxTest.Controls.Add(this.labelItemFromList);
            this.groupBoxListBoxTest.Controls.Add(this.buttonGetSelected);
            this.groupBoxListBoxTest.Controls.Add(this.ilbekovListBox);
            this.groupBoxListBoxTest.Location = new System.Drawing.Point(567, 21);
            this.groupBoxListBoxTest.Name = "groupBoxListBoxTest";
            this.groupBoxListBoxTest.Size = new System.Drawing.Size(221, 302);
            this.groupBoxListBoxTest.TabIndex = 6;
            this.groupBoxListBoxTest.TabStop = false;
            this.groupBoxListBoxTest.Text = "ListBox";
            // 
            // buttonGetSelected
            // 
            this.buttonGetSelected.Location = new System.Drawing.Point(121, 267);
            this.buttonGetSelected.Name = "buttonGetSelected";
            this.buttonGetSelected.Size = new System.Drawing.Size(94, 29);
            this.buttonGetSelected.TabIndex = 6;
            this.buttonGetSelected.Text = "Get";
            this.buttonGetSelected.UseVisualStyleBackColor = true;
            this.buttonGetSelected.Click += new System.EventHandler(this.buttonGetSelected_Click);
            // 
            // labelItemFromList
            // 
            this.labelItemFromList.AutoSize = true;
            this.labelItemFromList.Location = new System.Drawing.Point(21, 214);
            this.labelItemFromList.Name = "labelItemFromList";
            this.labelItemFromList.Size = new System.Drawing.Size(0, 20);
            this.labelItemFromList.TabIndex = 7;
            // 
            // TestForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.groupBoxListBoxTest);
            this.Controls.Add(this.groupBoxTextBoxTest);
            this.Controls.Add(this.groupBoxComboBoxTest);
            this.Name = "TestForm";
            this.Text = "Form for testing components";
            this.groupBoxComboBoxTest.ResumeLayout(false);
            this.groupBoxComboBoxTest.PerformLayout();
            this.groupBoxTextBoxTest.ResumeLayout(false);
            this.groupBoxTextBoxTest.PerformLayout();
            this.groupBoxListBoxTest.ResumeLayout(false);
            this.groupBoxListBoxTest.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private IlbekovVisualComponents.IlbekovComboBox ilbekovComboBox;
        private System.Windows.Forms.Button buttonClear;
        private System.Windows.Forms.GroupBox groupBoxComboBoxTest;
        private System.Windows.Forms.Label labelItem;
        private System.Windows.Forms.Button buttonSetSelectedItem;
        private System.Windows.Forms.Button buttonGetSelectedItem;
        private System.Windows.Forms.TextBox textBoxSetItem;
        private IlbekovVisualComponents.IlbekovTextBox ilbekovTextBox;
        private System.Windows.Forms.GroupBox groupBoxTextBoxTest;
        private System.Windows.Forms.Label labelCheckedText;
        private System.Windows.Forms.Button buttonGetTextFromTextBox;
        private IlbekovVisualComponents.IlbekovListBox ilbekovListBox;
        private System.Windows.Forms.GroupBox groupBoxListBoxTest;
        private System.Windows.Forms.Label labelItemFromList;
        private System.Windows.Forms.Button buttonGetSelected;
    }
}
