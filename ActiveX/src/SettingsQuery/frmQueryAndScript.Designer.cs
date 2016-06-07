﻿namespace hoTools.Settings
{
    partial class FrmQueryAndScript
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
            this.components = new System.ComponentModel.Container();
            this.btnOk = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.rbOnlyQueryAddinWindow = new System.Windows.Forms.RadioButton();
            this.rbOnlyQueryTabWindow = new System.Windows.Forms.RadioButton();
            this.rbOnlyQueryDisableWindow = new System.Windows.Forms.RadioButton();
            this.rbScriptAndQueryAddinWindow = new System.Windows.Forms.RadioButton();
            this.rbScriptAndQueryTabWindow = new System.Windows.Forms.RadioButton();
            this.rbScriptAndQueryDisableWindow = new System.Windows.Forms.RadioButton();
            this.chkIsAskForUpdate = new System.Windows.Forms.CheckBox();
            this.txtSqlEditor = new System.Windows.Forms.TextBox();
            this.btnSqlEditor = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnOk
            // 
            this.btnOk.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnOk.Location = new System.Drawing.Point(24, 293);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(105, 31);
            this.btnOk.TabIndex = 0;
            this.btnOk.Text = "OK";
            this.btnOk.UseVisualStyleBackColor = true;
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancel.Location = new System.Drawing.Point(135, 293);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(105, 31);
            this.btnCancel.TabIndex = 1;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(75, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(268, 29);
            this.label1.TabIndex = 2;
            this.label1.Text = "Settings SQL and Script";
            // 
            // rbOnlyQueryAddinWindow
            // 
            this.rbOnlyQueryAddinWindow.AutoSize = true;
            this.rbOnlyQueryAddinWindow.Location = new System.Drawing.Point(11, 19);
            this.rbOnlyQueryAddinWindow.Name = "rbOnlyQueryAddinWindow";
            this.rbOnlyQueryAddinWindow.Size = new System.Drawing.Size(62, 22);
            this.rbOnlyQueryAddinWindow.TabIndex = 208;
            this.rbOnlyQueryAddinWindow.TabStop = true;
            this.rbOnlyQueryAddinWindow.Text = "Addin";
            this.toolTip1.SetToolTip(this.rbOnlyQueryAddinWindow, "Show SQL in Addin Window");
            this.rbOnlyQueryAddinWindow.UseVisualStyleBackColor = true;
            // 
            // rbOnlyQueryTabWindow
            // 
            this.rbOnlyQueryTabWindow.AutoSize = true;
            this.rbOnlyQueryTabWindow.Location = new System.Drawing.Point(70, 19);
            this.rbOnlyQueryTabWindow.Name = "rbOnlyQueryTabWindow";
            this.rbOnlyQueryTabWindow.Size = new System.Drawing.Size(51, 22);
            this.rbOnlyQueryTabWindow.TabIndex = 209;
            this.rbOnlyQueryTabWindow.TabStop = true;
            this.rbOnlyQueryTabWindow.Text = "Tab";
            this.toolTip1.SetToolTip(this.rbOnlyQueryTabWindow, "Show SQL in Tab Window");
            this.rbOnlyQueryTabWindow.UseVisualStyleBackColor = true;
            // 
            // rbOnlyQueryDisableWindow
            // 
            this.rbOnlyQueryDisableWindow.AutoSize = true;
            this.rbOnlyQueryDisableWindow.Location = new System.Drawing.Point(121, 19);
            this.rbOnlyQueryDisableWindow.Name = "rbOnlyQueryDisableWindow";
            this.rbOnlyQueryDisableWindow.Size = new System.Drawing.Size(75, 22);
            this.rbOnlyQueryDisableWindow.TabIndex = 210;
            this.rbOnlyQueryDisableWindow.TabStop = true;
            this.rbOnlyQueryDisableWindow.Text = "Disable";
            this.toolTip1.SetToolTip(this.rbOnlyQueryDisableWindow, "Disable SQL");
            this.rbOnlyQueryDisableWindow.UseVisualStyleBackColor = true;
            // 
            // rbScriptAndQueryAddinWindow
            // 
            this.rbScriptAndQueryAddinWindow.AutoSize = true;
            this.rbScriptAndQueryAddinWindow.Location = new System.Drawing.Point(11, 19);
            this.rbScriptAndQueryAddinWindow.Name = "rbScriptAndQueryAddinWindow";
            this.rbScriptAndQueryAddinWindow.Size = new System.Drawing.Size(62, 22);
            this.rbScriptAndQueryAddinWindow.TabIndex = 208;
            this.rbScriptAndQueryAddinWindow.TabStop = true;
            this.rbScriptAndQueryAddinWindow.Text = "Addin";
            this.toolTip1.SetToolTip(this.rbScriptAndQueryAddinWindow, "Show SQL Query and run Script in Addin Windows");
            this.rbScriptAndQueryAddinWindow.UseVisualStyleBackColor = true;
            // 
            // rbScriptAndQueryTabWindow
            // 
            this.rbScriptAndQueryTabWindow.AutoSize = true;
            this.rbScriptAndQueryTabWindow.Location = new System.Drawing.Point(70, 19);
            this.rbScriptAndQueryTabWindow.Name = "rbScriptAndQueryTabWindow";
            this.rbScriptAndQueryTabWindow.Size = new System.Drawing.Size(51, 22);
            this.rbScriptAndQueryTabWindow.TabIndex = 209;
            this.rbScriptAndQueryTabWindow.TabStop = true;
            this.rbScriptAndQueryTabWindow.Text = "Tab";
            this.toolTip1.SetToolTip(this.rbScriptAndQueryTabWindow, "Show SQL Query and run Script in Tab Windows");
            this.rbScriptAndQueryTabWindow.UseVisualStyleBackColor = true;
            // 
            // rbScriptAndQueryDisableWindow
            // 
            this.rbScriptAndQueryDisableWindow.AutoSize = true;
            this.rbScriptAndQueryDisableWindow.Location = new System.Drawing.Point(121, 19);
            this.rbScriptAndQueryDisableWindow.Name = "rbScriptAndQueryDisableWindow";
            this.rbScriptAndQueryDisableWindow.Size = new System.Drawing.Size(75, 22);
            this.rbScriptAndQueryDisableWindow.TabIndex = 210;
            this.rbScriptAndQueryDisableWindow.TabStop = true;
            this.rbScriptAndQueryDisableWindow.Text = "Disable";
            this.toolTip1.SetToolTip(this.rbScriptAndQueryDisableWindow, "Disable SQL Query and run Script");
            this.rbScriptAndQueryDisableWindow.UseVisualStyleBackColor = true;
            // 
            // chkIsAskForUpdate
            // 
            this.chkIsAskForUpdate.AutoSize = true;
            this.chkIsAskForUpdate.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkIsAskForUpdate.Location = new System.Drawing.Point(321, 169);
            this.chkIsAskForUpdate.Name = "chkIsAskForUpdate";
            this.chkIsAskForUpdate.Size = new System.Drawing.Size(122, 22);
            this.chkIsAskForUpdate.TabIndex = 212;
            this.chkIsAskForUpdate.Text = "Ask for update";
            this.toolTip1.SetToolTip(this.chkIsAskForUpdate, "If checked: SQL will ask to update  query display content if file has changed out" +
        "side.");
            this.chkIsAskForUpdate.UseVisualStyleBackColor = true;
            // 
            // txtSqlEditor
            // 
            this.txtSqlEditor.Location = new System.Drawing.Point(29, 191);
            this.txtSqlEditor.Name = "txtSqlEditor";
            this.txtSqlEditor.Size = new System.Drawing.Size(270, 20);
            this.txtSqlEditor.TabIndex = 214;
            this.toolTip1.SetToolTip(this.txtSqlEditor, "Enter path of your beloved SQL Editor. You also can use the button to define your" +
        " favorable Editor.\r\n\r\nIf nothing is entered hoTools uses the Windows preferences" +
        " for *.sql type.");
            // 
            // btnSqlEditor
            // 
            this.btnSqlEditor.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSqlEditor.Location = new System.Drawing.Point(321, 191);
            this.btnSqlEditor.Name = "btnSqlEditor";
            this.btnSqlEditor.Size = new System.Drawing.Size(94, 23);
            this.btnSqlEditor.TabIndex = 215;
            this.btnSqlEditor.Text = "Find SQL editor";
            this.toolTip1.SetToolTip(this.btnSqlEditor, "Click to specify your beloved SQL editor. If nothing is entered hoTools uses the " +
        "Windows preferences for *.sql type.\r\n\r\nCurrently not supported.");
            this.btnSqlEditor.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.rbOnlyQueryDisableWindow);
            this.groupBox1.Controls.Add(this.rbOnlyQueryTabWindow);
            this.groupBox1.Controls.Add(this.rbOnlyQueryAddinWindow);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(26, 63);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(334, 43);
            this.groupBox1.TabIndex = 210;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Edit and run SQL";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.rbScriptAndQueryDisableWindow);
            this.groupBox2.Controls.Add(this.rbScriptAndQueryTabWindow);
            this.groupBox2.Controls.Add(this.rbScriptAndQueryAddinWindow);
            this.groupBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.Location = new System.Drawing.Point(26, 121);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(334, 43);
            this.groupBox2.TabIndex = 211;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Edit SQL Query and run Script with results";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(26, 169);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(224, 18);
            this.label2.TabIndex = 213;
            this.label2.Text = "Ask for update if file has changed";
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // FrmQueryAndScript
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(476, 328);
            this.Controls.Add(this.btnSqlEditor);
            this.Controls.Add(this.txtSqlEditor);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.chkIsAskForUpdate);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOk);
            this.Name = "FrmQueryAndScript";
            this.Text = "hoTools: Settings SQL and Script";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnOk;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton rbOnlyQueryDisableWindow;
        private System.Windows.Forms.RadioButton rbOnlyQueryTabWindow;
        private System.Windows.Forms.RadioButton rbOnlyQueryAddinWindow;
        private System.Windows.Forms.RadioButton rbScriptAndQueryAddinWindow;
        private System.Windows.Forms.RadioButton rbScriptAndQueryTabWindow;
        private System.Windows.Forms.RadioButton rbScriptAndQueryDisableWindow;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.CheckBox chkIsAskForUpdate;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.TextBox txtSqlEditor;
        private System.Windows.Forms.Button btnSqlEditor;
    }
}