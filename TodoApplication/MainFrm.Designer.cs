﻿namespace TodoApplication
{
    partial class mainWindow
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
            this.btnTotal = new System.Windows.Forms.Button();
            this.btnReset = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.btnInsertTodo = new System.Windows.Forms.Button();
            this.entryTodoName = new System.Windows.Forms.TextBox();
            this.entryTodoDateTime = new System.Windows.Forms.TextBox();
            this.entryTodoDescription = new System.Windows.Forms.RichTextBox();
            this.btnTasksPerUser = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // btnTotal
            // 
            this.btnTotal.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTotal.Location = new System.Drawing.Point(12, 515);
            this.btnTotal.Name = "btnTotal";
            this.btnTotal.Size = new System.Drawing.Size(152, 45);
            this.btnTotal.TabIndex = 0;
            this.btnTotal.Text = "Total Time";
            this.btnTotal.UseVisualStyleBackColor = true;
            // 
            // btnReset
            // 
            this.btnReset.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnReset.Location = new System.Drawing.Point(12, 617);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(152, 45);
            this.btnReset.TabIndex = 1;
            this.btnReset.Text = "Reset";
            this.btnReset.UseVisualStyleBackColor = true;
            this.btnReset.Click += new System.EventHandler(this.btnReset_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(12, 12);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(973, 493);
            this.dataGridView1.TabIndex = 2;
            // 
            // btnInsertTodo
            // 
            this.btnInsertTodo.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnInsertTodo.Location = new System.Drawing.Point(444, 632);
            this.btnInsertTodo.Name = "btnInsertTodo";
            this.btnInsertTodo.Size = new System.Drawing.Size(200, 39);
            this.btnInsertTodo.TabIndex = 3;
            this.btnInsertTodo.Text = "Insert Todo";
            this.btnInsertTodo.UseVisualStyleBackColor = true;
            this.btnInsertTodo.Click += new System.EventHandler(this.btnInsertTodo_Click);
            // 
            // entryTodoName
            // 
            this.entryTodoName.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.entryTodoName.Location = new System.Drawing.Point(186, 515);
            this.entryTodoName.Name = "entryTodoName";
            this.entryTodoName.Size = new System.Drawing.Size(458, 26);
            this.entryTodoName.TabIndex = 4;
            // 
            // entryTodoDateTime
            // 
            this.entryTodoDateTime.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.entryTodoDateTime.Location = new System.Drawing.Point(186, 632);
            this.entryTodoDateTime.Name = "entryTodoDateTime";
            this.entryTodoDateTime.Size = new System.Drawing.Size(252, 26);
            this.entryTodoDateTime.TabIndex = 5;
            // 
            // entryTodoDescription
            // 
            this.entryTodoDescription.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.entryTodoDescription.Location = new System.Drawing.Point(186, 547);
            this.entryTodoDescription.Name = "entryTodoDescription";
            this.entryTodoDescription.Size = new System.Drawing.Size(458, 79);
            this.entryTodoDescription.TabIndex = 6;
            this.entryTodoDescription.Text = "";
            // 
            // btnTasksPerUser
            // 
            this.btnTasksPerUser.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTasksPerUser.Location = new System.Drawing.Point(12, 566);
            this.btnTasksPerUser.Name = "btnTasksPerUser";
            this.btnTasksPerUser.Size = new System.Drawing.Size(152, 45);
            this.btnTasksPerUser.TabIndex = 8;
            this.btnTasksPerUser.Text = "Tasks Per User";
            this.btnTasksPerUser.UseVisualStyleBackColor = true;
            this.btnTasksPerUser.Click += new System.EventHandler(this.btnGroupByUser_Click);
            // 
            // mainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(997, 706);
            this.Controls.Add(this.btnTasksPerUser);
            this.Controls.Add(this.entryTodoDescription);
            this.Controls.Add(this.entryTodoDateTime);
            this.Controls.Add(this.entryTodoName);
            this.Controls.Add(this.btnInsertTodo);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.btnReset);
            this.Controls.Add(this.btnTotal);
            this.Name = "mainWindow";
            this.Text = "Todo Tracker";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnTotal;
        private System.Windows.Forms.Button btnReset;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button btnInsertTodo;
        private System.Windows.Forms.TextBox entryTodoName;
        private System.Windows.Forms.TextBox entryTodoDateTime;
        private System.Windows.Forms.RichTextBox entryTodoDescription;
        private System.Windows.Forms.Button btnTasksPerUser;
    }
}

