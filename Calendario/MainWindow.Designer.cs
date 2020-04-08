using System.Drawing;
using System.Windows.Forms;

namespace CalendarProject
{
    //IMPORTANT: ALL THIS CODE AND COMMENTS ARE GENERATED AUTOMATICALlY. MIGUEL SAID IN CLASS THAT WE DO NOT HAVE TO MODIFY THIS
    partial class MainWindow
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.Calendar = new System.Windows.Forms.DataGridView();
            this.mondayColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tuesdayColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.wednesdayColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.thursdayColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fridayColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.saturdayColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sundayColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.currentDateTitle = new System.Windows.Forms.Label();
            this.previousMonth = new System.Windows.Forms.Button();
            this.nextMonth = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.Calendar)).BeginInit();
            this.SuspendLayout();
            // 
            // Calendar
            // 
            this.Calendar.AllowUserToAddRows = false;
            this.Calendar.AllowUserToResizeRows = false;
            this.Calendar.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Raised;
            this.Calendar.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.Calendar.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.mondayColumn,
            this.tuesdayColumn,
            this.wednesdayColumn,
            this.thursdayColumn,
            this.fridayColumn,
            this.saturdayColumn,
            this.sundayColumn});
            this.Calendar.Enabled = false;
            this.Calendar.GridColor = System.Drawing.SystemColors.ButtonShadow;
            this.Calendar.Location = new System.Drawing.Point(2, 143);
            this.Calendar.Name = "Calendar";
            this.Calendar.ReadOnly = true;
            this.Calendar.RowHeadersVisible = false;
            this.Calendar.RowTemplate.Height = 100;
            this.Calendar.Size = new System.Drawing.Size(703, 633);
            this.Calendar.TabIndex = 0;
            // 
            // mondayColumn
            // 
            this.mondayColumn.HeaderText = "Monday";
            this.mondayColumn.Name = "mondayColumn";
            this.mondayColumn.ReadOnly = true;
            this.mondayColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // tuesdayColumn
            // 
            this.tuesdayColumn.HeaderText = "Tuesday";
            this.tuesdayColumn.Name = "tuesdayColumn";
            this.tuesdayColumn.ReadOnly = true;
            this.tuesdayColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // wednesdayColumn
            // 
            this.wednesdayColumn.HeaderText = "Wednesday";
            this.wednesdayColumn.Name = "wednesdayColumn";
            this.wednesdayColumn.ReadOnly = true;
            this.wednesdayColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // thursdayColumn
            // 
            this.thursdayColumn.HeaderText = "Thursday";
            this.thursdayColumn.Name = "thursdayColumn";
            this.thursdayColumn.ReadOnly = true;
            this.thursdayColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // fridayColumn
            // 
            this.fridayColumn.HeaderText = "Friday";
            this.fridayColumn.Name = "fridayColumn";
            this.fridayColumn.ReadOnly = true;
            this.fridayColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // saturdayColumn
            // 
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(233)))), ((int)(((byte)(245)))), ((int)(((byte)(248)))));
            this.saturdayColumn.DefaultCellStyle = dataGridViewCellStyle1;
            this.saturdayColumn.HeaderText = "Saturday";
            this.saturdayColumn.Name = "saturdayColumn";
            this.saturdayColumn.ReadOnly = true;
            this.saturdayColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // sundayColumn
            // 
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(233)))), ((int)(((byte)(245)))), ((int)(((byte)(248)))));
            this.sundayColumn.DefaultCellStyle = dataGridViewCellStyle2;
            this.sundayColumn.HeaderText = "Sunday";
            this.sundayColumn.Name = "sundayColumn";
            this.sundayColumn.ReadOnly = true;
            this.sundayColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // currentDateTitle
            // 
            this.currentDateTitle.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.currentDateTitle.Font = new System.Drawing.Font("Microsoft YaHei UI", 48F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.currentDateTitle.Location = new System.Drawing.Point(43, 26);
            this.currentDateTitle.Name = "currentDateTitle";
            this.currentDateTitle.Size = new System.Drawing.Size(623, 83);
            this.currentDateTitle.TabIndex = 1;
            this.currentDateTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // previousMonth
            // 
            this.previousMonth.Font = new System.Drawing.Font("Microsoft YaHei UI", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.previousMonth.Location = new System.Drawing.Point(12, 40);
            this.previousMonth.Name = "previousMonth";
            this.previousMonth.Size = new System.Drawing.Size(26, 56);
            this.previousMonth.TabIndex = 2;
            this.previousMonth.Text = "<";
            this.previousMonth.UseVisualStyleBackColor = true;
            this.previousMonth.Click += new System.EventHandler(this.PreviousMonthClick);
            // 
            // nextMonth
            // 
            this.nextMonth.Font = new System.Drawing.Font("Microsoft YaHei UI", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nextMonth.Location = new System.Drawing.Point(679, 40);
            this.nextMonth.Name = "nextMonth";
            this.nextMonth.Size = new System.Drawing.Size(26, 56);
            this.nextMonth.TabIndex = 3;
            this.nextMonth.Text = ">";
            this.nextMonth.UseVisualStyleBackColor = true;
            this.nextMonth.Click += new System.EventHandler(this.NextMonthClick);
            // 
            // MainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(714, 788);
            this.Controls.Add(this.nextMonth);
            this.Controls.Add(this.previousMonth);
            this.Controls.Add(this.currentDateTitle);
            this.Controls.Add(this.Calendar);
            this.Name = "MainWindow";
            this.Text = "MainWindow";
            this.Load += new System.EventHandler(this.MainWindowLoad);
            ((System.ComponentModel.ISupportInitialize)(this.Calendar)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView Calendar;
        private System.Windows.Forms.DataGridViewTextBoxColumn mondayColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn tuesdayColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn wednesdayColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn thursdayColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn fridayColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn saturdayColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn sundayColumn;
        private System.Windows.Forms.Label currentDateTitle;
        private System.Windows.Forms.Button previousMonth;
        private System.Windows.Forms.Button nextMonth;
    }
}

