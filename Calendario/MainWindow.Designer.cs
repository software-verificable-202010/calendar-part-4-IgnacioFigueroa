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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle16 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle11 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle12 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle13 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle14 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle15 = new System.Windows.Forms.DataGridViewCellStyle();
            this.monthCalendarGrid = new System.Windows.Forms.DataGridView();
            this.mondayMonthColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tuesdayMonthColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.wednesdayMonthColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.thursdayMonthColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fridayMonthColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.saturdayMonthColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sundayMonthColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.weekCalendarGrid = new System.Windows.Forms.DataGridView();
            this.timeWeekColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.mondayWeekColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tuesdayWeekColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.wednesdayWeekColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.thursdayWeekColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fridayWeekColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.saturdayWeekColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sundayWeekColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.currentDateMonthTitle = new System.Windows.Forms.Label();
            this.previousMonth = new System.Windows.Forms.Button();
            this.nextMonth = new System.Windows.Forms.Button();
            this.viewModeSelector = new System.Windows.Forms.ComboBox();
            this.monthPanel = new System.Windows.Forms.Panel();
            this.weekPanel = new System.Windows.Forms.Panel();
            this.weekControlPanel = new System.Windows.Forms.Panel();
            this.currentDateWeekTitle = new System.Windows.Forms.Label();
            this.nextWeek = new System.Windows.Forms.Button();
            this.previousWeek = new System.Windows.Forms.Button();
            this.monthControlPanel = new System.Windows.Forms.Panel();
            this.createAppointment = new System.Windows.Forms.Button();
            this.appointmentsDataGrid = new System.Windows.Forms.DataGridView();
            this.appointmentId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TitleColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.descriptionColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.StartTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.endTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.logoutButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.monthCalendarGrid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.weekCalendarGrid)).BeginInit();
            this.monthPanel.SuspendLayout();
            this.weekPanel.SuspendLayout();
            this.weekControlPanel.SuspendLayout();
            this.monthControlPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.appointmentsDataGrid)).BeginInit();
            this.SuspendLayout();
            // 
            // monthCalendarGrid
            // 
            this.monthCalendarGrid.AllowUserToAddRows = false;
            this.monthCalendarGrid.AllowUserToResizeRows = false;
            this.monthCalendarGrid.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Raised;
            this.monthCalendarGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.monthCalendarGrid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.mondayMonthColumn,
            this.tuesdayMonthColumn,
            this.wednesdayMonthColumn,
            this.thursdayMonthColumn,
            this.fridayMonthColumn,
            this.saturdayMonthColumn,
            this.sundayMonthColumn});
            this.monthCalendarGrid.GridColor = System.Drawing.SystemColors.ButtonShadow;
            this.monthCalendarGrid.Location = new System.Drawing.Point(0, 0);
            this.monthCalendarGrid.Name = "monthCalendarGrid";
            this.monthCalendarGrid.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.monthCalendarGrid.RowHeadersVisible = false;
            this.monthCalendarGrid.RowTemplate.Height = 112;
            this.monthCalendarGrid.Size = new System.Drawing.Size(844, 672);
            this.monthCalendarGrid.TabIndex = 0;
            this.monthCalendarGrid.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.MonthCalendarGridCellClick);
            // 
            // mondayMonthColumn
            // 
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopLeft;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.mondayMonthColumn.DefaultCellStyle = dataGridViewCellStyle1;
            this.mondayMonthColumn.HeaderText = "Monday";
            this.mondayMonthColumn.Name = "mondayMonthColumn";
            this.mondayMonthColumn.ReadOnly = true;
            this.mondayMonthColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.mondayMonthColumn.Width = 120;
            // 
            // tuesdayMonthColumn
            // 
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopLeft;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.tuesdayMonthColumn.DefaultCellStyle = dataGridViewCellStyle2;
            this.tuesdayMonthColumn.HeaderText = "Tuesday";
            this.tuesdayMonthColumn.Name = "tuesdayMonthColumn";
            this.tuesdayMonthColumn.ReadOnly = true;
            this.tuesdayMonthColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.tuesdayMonthColumn.Width = 120;
            // 
            // wednesdayMonthColumn
            // 
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopLeft;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.wednesdayMonthColumn.DefaultCellStyle = dataGridViewCellStyle3;
            this.wednesdayMonthColumn.HeaderText = "Wednesday";
            this.wednesdayMonthColumn.Name = "wednesdayMonthColumn";
            this.wednesdayMonthColumn.ReadOnly = true;
            this.wednesdayMonthColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.wednesdayMonthColumn.Width = 120;
            // 
            // thursdayMonthColumn
            // 
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopLeft;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.thursdayMonthColumn.DefaultCellStyle = dataGridViewCellStyle4;
            this.thursdayMonthColumn.HeaderText = "Thursday";
            this.thursdayMonthColumn.Name = "thursdayMonthColumn";
            this.thursdayMonthColumn.ReadOnly = true;
            this.thursdayMonthColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.thursdayMonthColumn.Width = 120;
            // 
            // fridayMonthColumn
            // 
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopLeft;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.fridayMonthColumn.DefaultCellStyle = dataGridViewCellStyle5;
            this.fridayMonthColumn.HeaderText = "Friday";
            this.fridayMonthColumn.Name = "fridayMonthColumn";
            this.fridayMonthColumn.ReadOnly = true;
            this.fridayMonthColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.fridayMonthColumn.Width = 120;
            // 
            // saturdayMonthColumn
            // 
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(233)))), ((int)(((byte)(245)))), ((int)(((byte)(248)))));
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.saturdayMonthColumn.DefaultCellStyle = dataGridViewCellStyle6;
            this.saturdayMonthColumn.HeaderText = "Saturday";
            this.saturdayMonthColumn.Name = "saturdayMonthColumn";
            this.saturdayMonthColumn.ReadOnly = true;
            this.saturdayMonthColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.saturdayMonthColumn.Width = 120;
            // 
            // sundayMonthColumn
            // 
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopLeft;
            dataGridViewCellStyle7.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(233)))), ((int)(((byte)(245)))), ((int)(((byte)(248)))));
            dataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.sundayMonthColumn.DefaultCellStyle = dataGridViewCellStyle7;
            this.sundayMonthColumn.HeaderText = "Sunday";
            this.sundayMonthColumn.Name = "sundayMonthColumn";
            this.sundayMonthColumn.ReadOnly = true;
            this.sundayMonthColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.sundayMonthColumn.Width = 120;
            // 
            // weekCalendarGrid
            // 
            this.weekCalendarGrid.AllowUserToAddRows = false;
            this.weekCalendarGrid.AllowUserToDeleteRows = false;
            this.weekCalendarGrid.AllowUserToResizeColumns = false;
            this.weekCalendarGrid.AllowUserToResizeRows = false;
            dataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.weekCalendarGrid.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle8;
            this.weekCalendarGrid.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Raised;
            this.weekCalendarGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.weekCalendarGrid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.timeWeekColumn,
            this.mondayWeekColumn,
            this.tuesdayWeekColumn,
            this.wednesdayWeekColumn,
            this.thursdayWeekColumn,
            this.fridayWeekColumn,
            this.saturdayWeekColumn,
            this.sundayWeekColumn});
            this.weekCalendarGrid.GridColor = System.Drawing.SystemColors.ButtonShadow;
            this.weekCalendarGrid.Location = new System.Drawing.Point(0, 0);
            this.weekCalendarGrid.Name = "weekCalendarGrid";
            this.weekCalendarGrid.RowHeadersVisible = false;
            dataGridViewCellStyle16.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopLeft;
            this.weekCalendarGrid.RowsDefaultCellStyle = dataGridViewCellStyle16;
            this.weekCalendarGrid.RowTemplate.Height = 50;
            this.weekCalendarGrid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.weekCalendarGrid.Size = new System.Drawing.Size(860, 635);
            this.weekCalendarGrid.TabIndex = 0;
            this.weekCalendarGrid.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.WeekCalendarGridCellClick);
            // 
            // timeWeekColumn
            // 
            this.timeWeekColumn.HeaderText = "Time";
            this.timeWeekColumn.Name = "timeWeekColumn";
            this.timeWeekColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.timeWeekColumn.Width = 105;
            // 
            // mondayWeekColumn
            // 
            dataGridViewCellStyle9.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.mondayWeekColumn.DefaultCellStyle = dataGridViewCellStyle9;
            this.mondayWeekColumn.HeaderText = "Monday";
            this.mondayWeekColumn.Name = "mondayWeekColumn";
            this.mondayWeekColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.mondayWeekColumn.Width = 105;
            // 
            // tuesdayWeekColumn
            // 
            dataGridViewCellStyle10.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.tuesdayWeekColumn.DefaultCellStyle = dataGridViewCellStyle10;
            this.tuesdayWeekColumn.HeaderText = "Tuesday";
            this.tuesdayWeekColumn.Name = "tuesdayWeekColumn";
            this.tuesdayWeekColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.tuesdayWeekColumn.Width = 105;
            // 
            // wednesdayWeekColumn
            // 
            dataGridViewCellStyle11.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.wednesdayWeekColumn.DefaultCellStyle = dataGridViewCellStyle11;
            this.wednesdayWeekColumn.HeaderText = "Wednesday";
            this.wednesdayWeekColumn.Name = "wednesdayWeekColumn";
            this.wednesdayWeekColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.wednesdayWeekColumn.Width = 105;
            // 
            // thursdayWeekColumn
            // 
            dataGridViewCellStyle12.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.thursdayWeekColumn.DefaultCellStyle = dataGridViewCellStyle12;
            this.thursdayWeekColumn.HeaderText = "Thursday";
            this.thursdayWeekColumn.Name = "thursdayWeekColumn";
            this.thursdayWeekColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.thursdayWeekColumn.Width = 105;
            // 
            // fridayWeekColumn
            // 
            dataGridViewCellStyle13.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.fridayWeekColumn.DefaultCellStyle = dataGridViewCellStyle13;
            this.fridayWeekColumn.HeaderText = "Friday";
            this.fridayWeekColumn.Name = "fridayWeekColumn";
            this.fridayWeekColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.fridayWeekColumn.Width = 105;
            // 
            // saturdayWeekColumn
            // 
            dataGridViewCellStyle14.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(233)))), ((int)(((byte)(245)))), ((int)(((byte)(248)))));
            dataGridViewCellStyle14.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.saturdayWeekColumn.DefaultCellStyle = dataGridViewCellStyle14;
            this.saturdayWeekColumn.HeaderText = "Saturday";
            this.saturdayWeekColumn.Name = "saturdayWeekColumn";
            this.saturdayWeekColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.saturdayWeekColumn.Width = 105;
            // 
            // sundayWeekColumn
            // 
            dataGridViewCellStyle15.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(233)))), ((int)(((byte)(245)))), ((int)(((byte)(248)))));
            dataGridViewCellStyle15.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.sundayWeekColumn.DefaultCellStyle = dataGridViewCellStyle15;
            this.sundayWeekColumn.HeaderText = "Sunday";
            this.sundayWeekColumn.Name = "sundayWeekColumn";
            this.sundayWeekColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.sundayWeekColumn.Width = 105;
            // 
            // currentDateMonthTitle
            // 
            this.currentDateMonthTitle.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.currentDateMonthTitle.Font = new System.Drawing.Font("Microsoft YaHei UI", 27.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.currentDateMonthTitle.Location = new System.Drawing.Point(91, 0);
            this.currentDateMonthTitle.Name = "currentDateMonthTitle";
            this.currentDateMonthTitle.Size = new System.Drawing.Size(376, 83);
            this.currentDateMonthTitle.TabIndex = 1;
            this.currentDateMonthTitle.Text = "CurrentMonth Year";
            this.currentDateMonthTitle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // previousMonth
            // 
            this.previousMonth.Font = new System.Drawing.Font("Microsoft YaHei UI", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.previousMonth.Location = new System.Drawing.Point(12, 15);
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
            this.nextMonth.Location = new System.Drawing.Point(59, 15);
            this.nextMonth.Name = "nextMonth";
            this.nextMonth.Size = new System.Drawing.Size(26, 56);
            this.nextMonth.TabIndex = 3;
            this.nextMonth.Text = ">";
            this.nextMonth.UseVisualStyleBackColor = true;
            this.nextMonth.Click += new System.EventHandler(this.NextMonthClick);
            // 
            // viewModeSelector
            // 
            this.viewModeSelector.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.viewModeSelector.FormattingEnabled = true;
            this.viewModeSelector.Items.AddRange(new object[] {
            CalendarProject.Constants.VisualizationTypes.Month,
            CalendarProject.Constants.VisualizationTypes.Week});
            this.viewModeSelector.Location = new System.Drawing.Point(699, 65);
            this.viewModeSelector.Name = "viewModeSelector";
            this.viewModeSelector.Size = new System.Drawing.Size(138, 21);
            this.viewModeSelector.TabIndex = 4;
            this.viewModeSelector.SelectedValueChanged += new System.EventHandler(this.ViewModeSelectorSelectedValueChanged);
            // 
            // monthPanel
            // 
            this.monthPanel.Controls.Add(this.monthCalendarGrid);
            this.monthPanel.Location = new System.Drawing.Point(0, 146);
            this.monthPanel.Name = "monthPanel";
            this.monthPanel.Size = new System.Drawing.Size(844, 672);
            this.monthPanel.TabIndex = 5;
            // 
            // weekPanel
            // 
            this.weekPanel.Controls.Add(this.weekCalendarGrid);
            this.weekPanel.Location = new System.Drawing.Point(1, 146);
            this.weekPanel.Name = "weekPanel";
            this.weekPanel.Size = new System.Drawing.Size(870, 672);
            this.weekPanel.TabIndex = 6;
            // 
            // weekControlPanel
            // 
            this.weekControlPanel.Controls.Add(this.currentDateWeekTitle);
            this.weekControlPanel.Controls.Add(this.nextWeek);
            this.weekControlPanel.Controls.Add(this.previousWeek);
            this.weekControlPanel.Location = new System.Drawing.Point(0, 25);
            this.weekControlPanel.Name = "weekControlPanel";
            this.weekControlPanel.Size = new System.Drawing.Size(631, 95);
            this.weekControlPanel.TabIndex = 11;
            // 
            // currentDateWeekTitle
            // 
            this.currentDateWeekTitle.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.currentDateWeekTitle.Font = new System.Drawing.Font("Microsoft YaHei UI", 27.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.currentDateWeekTitle.Location = new System.Drawing.Point(89, 0);
            this.currentDateWeekTitle.Name = "currentDateWeekTitle";
            this.currentDateWeekTitle.Size = new System.Drawing.Size(511, 83);
            this.currentDateWeekTitle.TabIndex = 1;
            this.currentDateWeekTitle.Text = "Current Week Title";
            this.currentDateWeekTitle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // nextWeek
            // 
            this.nextWeek.Font = new System.Drawing.Font("Microsoft YaHei UI", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nextWeek.Location = new System.Drawing.Point(59, 15);
            this.nextWeek.Name = "nextWeek";
            this.nextWeek.Size = new System.Drawing.Size(26, 56);
            this.nextWeek.TabIndex = 9;
            this.nextWeek.Text = ">";
            this.nextWeek.UseVisualStyleBackColor = true;
            this.nextWeek.Click += new System.EventHandler(this.NextWeekClick);
            // 
            // previousWeek
            // 
            this.previousWeek.Font = new System.Drawing.Font("Microsoft YaHei UI", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.previousWeek.Location = new System.Drawing.Point(12, 15);
            this.previousWeek.Name = "previousWeek";
            this.previousWeek.Size = new System.Drawing.Size(26, 56);
            this.previousWeek.TabIndex = 8;
            this.previousWeek.Text = "<";
            this.previousWeek.UseVisualStyleBackColor = true;
            this.previousWeek.Click += new System.EventHandler(this.PreviousWeekClick);
            // 
            // monthControlPanel
            // 
            this.monthControlPanel.Controls.Add(this.nextMonth);
            this.monthControlPanel.Controls.Add(this.previousMonth);
            this.monthControlPanel.Controls.Add(this.currentDateMonthTitle);
            this.monthControlPanel.Location = new System.Drawing.Point(0, 25);
            this.monthControlPanel.Name = "monthControlPanel";
            this.monthControlPanel.Size = new System.Drawing.Size(634, 95);
            this.monthControlPanel.TabIndex = 7;
            // 
            // createAppointment
            // 
            this.createAppointment.Location = new System.Drawing.Point(701, 25);
            this.createAppointment.Name = "createAppointment";
            this.createAppointment.Size = new System.Drawing.Size(136, 25);
            this.createAppointment.TabIndex = 10;
            this.createAppointment.Text = "Create Appointment";
            this.createAppointment.UseVisualStyleBackColor = true;
            this.createAppointment.Click += new System.EventHandler(this.CreateAppointmentClick);
            // 
            // appointmentsDataGrid
            // 
            this.appointmentsDataGrid.AllowUserToAddRows = false;
            this.appointmentsDataGrid.AllowUserToDeleteRows = false;
            this.appointmentsDataGrid.AllowUserToResizeColumns = false;
            this.appointmentsDataGrid.AllowUserToResizeRows = false;
            this.appointmentsDataGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.appointmentsDataGrid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.appointmentId,
            this.TitleColumn,
            this.descriptionColumn,
            this.StartTime,
            this.endTime});
            this.appointmentsDataGrid.Location = new System.Drawing.Point(899, 65);
            this.appointmentsDataGrid.Name = "appointmentsDataGrid";
            this.appointmentsDataGrid.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.appointmentsDataGrid.RowHeadersVisible = false;
            this.appointmentsDataGrid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.appointmentsDataGrid.Size = new System.Drawing.Size(557, 716);
            this.appointmentsDataGrid.TabIndex = 12;
            this.appointmentsDataGrid.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.AppointmentsDataGridCellClick);
            // 
            // appointmentId
            // 
            this.appointmentId.HeaderText = "appointmentId";
            this.appointmentId.Name = "appointmentId";
            this.appointmentId.Visible = false;
            // 
            // TitleColumn
            // 
            this.TitleColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.TitleColumn.HeaderText = "Title";
            this.TitleColumn.Name = "TitleColumn";
            this.TitleColumn.Width = 52;
            // 
            // descriptionColumn
            // 
            this.descriptionColumn.HeaderText = "Description";
            this.descriptionColumn.Name = "descriptionColumn";
            this.descriptionColumn.Width = 250;
            // 
            // StartTime
            // 
            this.StartTime.HeaderText = "Start Time";
            this.StartTime.Name = "StartTime";
            // 
            // endTime
            // 
            this.endTime.HeaderText = "End Time";
            this.endTime.Name = "endTime";
            // 
            // logoutButton
            // 
            this.logoutButton.Location = new System.Drawing.Point(1381, 12);
            this.logoutButton.Name = "logoutButton";
            this.logoutButton.Size = new System.Drawing.Size(75, 23);
            this.logoutButton.TabIndex = 13;
            this.logoutButton.Text = "Log Out";
            this.logoutButton.UseVisualStyleBackColor = true;
            this.logoutButton.Click += new System.EventHandler(this.LogoutButtonClick);
            // 
            // MainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1470, 868);
            this.Controls.Add(this.logoutButton);
            this.Controls.Add(this.appointmentsDataGrid);
            this.Controls.Add(this.weekPanel);
            this.Controls.Add(this.weekControlPanel);
            this.Controls.Add(this.createAppointment);
            this.Controls.Add(this.monthControlPanel);
            this.Controls.Add(this.monthPanel);
            this.Controls.Add(this.viewModeSelector);
            this.Name = "MainWindow";
            this.Text = "Calendar";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.MainWindowFormClosed);
            this.Load += new System.EventHandler(this.MainWindowLoad);
            ((System.ComponentModel.ISupportInitialize)(this.monthCalendarGrid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.weekCalendarGrid)).EndInit();
            this.monthPanel.ResumeLayout(false);
            this.weekPanel.ResumeLayout(false);
            this.weekControlPanel.ResumeLayout(false);
            this.monthControlPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.appointmentsDataGrid)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView monthCalendarGrid;

        private System.Windows.Forms.Label currentDateMonthTitle;
        private System.Windows.Forms.Button previousMonth;
        private System.Windows.Forms.Button nextMonth;
        private ComboBox viewModeSelector;
        private Panel monthPanel;
        private Panel weekPanel;
        private DataGridView weekCalendarGrid;

        private Panel monthControlPanel;
        private DataGridViewTextBoxColumn mondayMonthColumn;
        private DataGridViewTextBoxColumn tuesdayMonthColumn;
        private DataGridViewTextBoxColumn wednesdayMonthColumn;
        private DataGridViewTextBoxColumn thursdayMonthColumn;
        private DataGridViewTextBoxColumn fridayMonthColumn;
        private DataGridViewTextBoxColumn saturdayMonthColumn;
        private DataGridViewTextBoxColumn sundayMonthColumn;
        private Button previousWeek;
        private Button nextWeek;
        private Button createAppointment;
        private DataGridViewTextBoxColumn timeWeekColumn;
        private DataGridViewTextBoxColumn mondayWeekColumn;
        private DataGridViewTextBoxColumn tuesdayWeekColumn;
        private DataGridViewTextBoxColumn wednesdayWeekColumn;
        private DataGridViewTextBoxColumn thursdayWeekColumn;
        private DataGridViewTextBoxColumn fridayWeekColumn;
        private DataGridViewTextBoxColumn saturdayWeekColumn;
        private DataGridViewTextBoxColumn sundayWeekColumn;
        private Panel weekControlPanel;
        private Label currentDateWeekTitle;
        private DataGridView appointmentsDataGrid;
        private Button logoutButton;
        private DataGridViewTextBoxColumn appointmentId;
        private DataGridViewTextBoxColumn TitleColumn;
        private DataGridViewTextBoxColumn descriptionColumn;
        private DataGridViewTextBoxColumn StartTime;
        private DataGridViewTextBoxColumn endTime;
    }
}

