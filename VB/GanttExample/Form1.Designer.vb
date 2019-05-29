Namespace GanttExample
    Partial Public Class Form1
        ''' <summary>
        ''' Required designer variable.
        ''' </summary>
        Private components As System.ComponentModel.IContainer = Nothing

        ''' <summary>
        ''' Clean up any resources being used.
        ''' </summary>
        ''' <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        Protected Overrides Sub Dispose(ByVal disposing As Boolean)
            If disposing AndAlso (components IsNot Nothing) Then
                components.Dispose()
            End If
            MyBase.Dispose(disposing)
        End Sub

        #Region "Windows Form Designer generated code"

        ''' <summary>
        ''' Required method for Designer support - do not modify
        ''' the contents of this method with the code editor.
        ''' </summary>
        Private Sub InitializeComponent()
            Me.components = New System.ComponentModel.Container()
            Dim timeRuler4 As New DevExpress.XtraScheduler.TimeRuler()
            Dim timeRuler5 As New DevExpress.XtraScheduler.TimeRuler()
            Dim timeRuler6 As New DevExpress.XtraScheduler.TimeRuler()
            Me.splitContainerControl1 = New DevExpress.XtraEditors.SplitContainerControl()
            Me.resourcesTree1 = New DevExpress.XtraScheduler.UI.ResourcesTree()
            Me.schedulerControl1 = New DevExpress.XtraScheduler.SchedulerControl()
            Me.schedulerDataStorage1 = New DevExpress.XtraScheduler.SchedulerDataStorage(Me.components)
            Me.taskDependenciesBindingSource = New System.Windows.Forms.BindingSource(Me.components)
            Me.gantTestDataSet = New GantTestDataSet()
            Me.appointmentsBindingSource = New System.Windows.Forms.BindingSource(Me.components)
            Me.resourcesBindingSource = New System.Windows.Forms.BindingSource(Me.components)
            Me.appointmentsTableAdapter = New GantTestDataSetTableAdapters.AppointmentsTableAdapter()
            Me.resourcesTableAdapter = New GantTestDataSetTableAdapters.ResourcesTableAdapter()
            Me.taskDependenciesTableAdapter = New GantTestDataSetTableAdapters.TaskDependenciesTableAdapter()
            Me.colId = New DevExpress.XtraScheduler.Native.ResourceTreeColumn()
            Me.colIdSort = New DevExpress.XtraScheduler.Native.ResourceTreeColumn()
            Me.colDescription = New DevExpress.XtraScheduler.Native.ResourceTreeColumn()
            CType(Me.splitContainerControl1, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.splitContainerControl1.SuspendLayout()
            CType(Me.resourcesTree1, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.schedulerControl1, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.schedulerDataStorage1, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.taskDependenciesBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.gantTestDataSet, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.appointmentsBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.resourcesBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.SuspendLayout()
            ' 
            ' splitContainerControl1
            ' 
            Me.splitContainerControl1.Dock = System.Windows.Forms.DockStyle.Fill
            Me.splitContainerControl1.Location = New System.Drawing.Point(0, 0)
            Me.splitContainerControl1.Name = "splitContainerControl1"
            Me.splitContainerControl1.Panel1.Controls.Add(Me.resourcesTree1)
            Me.splitContainerControl1.Panel1.Text = "Panel1"
            Me.splitContainerControl1.Panel2.Controls.Add(Me.schedulerControl1)
            Me.splitContainerControl1.Panel2.Text = "Panel2"
            Me.splitContainerControl1.Size = New System.Drawing.Size(700, 489)
            Me.splitContainerControl1.SplitterPosition = 179
            Me.splitContainerControl1.TabIndex = 0
            Me.splitContainerControl1.Text = "splitContainerControl1"
            ' 
            ' resourcesTree1
            ' 
            Me.resourcesTree1.Columns.AddRange(New DevExpress.XtraTreeList.Columns.TreeListColumn() {Me.colIdSort, Me.colId, Me.colDescription})
            Me.resourcesTree1.Dock = System.Windows.Forms.DockStyle.Fill
            Me.resourcesTree1.Location = New System.Drawing.Point(0, 0)
            Me.resourcesTree1.Name = "resourcesTree1"
            Me.resourcesTree1.OptionsBehavior.Editable = False
            Me.resourcesTree1.SchedulerControl = Me.schedulerControl1
            Me.resourcesTree1.Size = New System.Drawing.Size(179, 489)
            Me.resourcesTree1.TabIndex = 0
            ' 
            ' schedulerControl1
            ' 
            Me.schedulerControl1.DataStorage = Me.schedulerDataStorage1
            Me.schedulerControl1.Dock = System.Windows.Forms.DockStyle.Fill
            Me.schedulerControl1.Location = New System.Drawing.Point(0, 0)
            Me.schedulerControl1.Name = "schedulerControl1"
            Me.schedulerControl1.Size = New System.Drawing.Size(509, 489)
            Me.schedulerControl1.Start = New Date(2017, 6, 27, 0, 0, 0, 0)
            Me.schedulerControl1.TabIndex = 0
            Me.schedulerControl1.Text = "schedulerControl1"
            Me.schedulerControl1.Views.DayView.TimeRulers.Add(timeRuler4)
            Me.schedulerControl1.Views.FullWeekView.Enabled = True
            Me.schedulerControl1.Views.FullWeekView.TimeRulers.Add(timeRuler5)
            Me.schedulerControl1.Views.WeekView.Enabled = False
            Me.schedulerControl1.Views.WorkWeekView.TimeRulers.Add(timeRuler6)
            ' 
            ' schedulerStorage1
            ' 
            Me.schedulerDataStorage1.AppointmentDependencies.DataSource = Me.taskDependenciesBindingSource
            Me.schedulerDataStorage1.AppointmentDependencies.Mappings.DependentId = "DependentId"
            Me.schedulerDataStorage1.AppointmentDependencies.Mappings.ParentId = "ParentId"
            Me.schedulerDataStorage1.AppointmentDependencies.Mappings.Type = "Type"
            Me.schedulerDataStorage1.Appointments.DataSource = Me.appointmentsBindingSource
            Me.schedulerDataStorage1.Appointments.Mappings.AllDay = "AllDay"
            Me.schedulerDataStorage1.Appointments.Mappings.AppointmentId = "UniqueId"
            Me.schedulerDataStorage1.Appointments.Mappings.Description = "Description"
            Me.schedulerDataStorage1.Appointments.Mappings.End = "EndDate"
            Me.schedulerDataStorage1.Appointments.Mappings.Label = "Label"
            Me.schedulerDataStorage1.Appointments.Mappings.Location = "Location"
            Me.schedulerDataStorage1.Appointments.Mappings.PercentComplete = "PercentComplete"
            Me.schedulerDataStorage1.Appointments.Mappings.RecurrenceInfo = "RecurrenceInfo"
            Me.schedulerDataStorage1.Appointments.Mappings.ReminderInfo = "ReminderInfo"
            Me.schedulerDataStorage1.Appointments.Mappings.ResourceId = "ResourceId"
            Me.schedulerDataStorage1.Appointments.Mappings.Start = "StartDate"
            Me.schedulerDataStorage1.Appointments.Mappings.Status = "Status"
            Me.schedulerDataStorage1.Appointments.Mappings.Subject = "Subject"
            Me.schedulerDataStorage1.Appointments.Mappings.TimeZoneId = "TimeZoneId"
            Me.schedulerDataStorage1.Appointments.Mappings.Type = "Type"
            Me.schedulerDataStorage1.Resources.CustomFieldMappings.Add(New DevExpress.XtraScheduler.ResourceCustomFieldMapping("IdSort", "IdSort"))
            Me.schedulerDataStorage1.Resources.CustomFieldMappings.Add(New DevExpress.XtraScheduler.ResourceCustomFieldMapping("CustomField1", "CustomField1"))
            Me.schedulerDataStorage1.Resources.DataSource = Me.resourcesBindingSource
            Me.schedulerDataStorage1.Resources.Mappings.Caption = "Description"
            Me.schedulerDataStorage1.Resources.Mappings.Color = "Color"
            Me.schedulerDataStorage1.Resources.Mappings.Id = "Id"
            Me.schedulerDataStorage1.Resources.Mappings.Image = "Image"
            Me.schedulerDataStorage1.Resources.Mappings.ParentId = "ParentId"
            ' 
            ' taskDependenciesBindingSource
            ' 
            Me.taskDependenciesBindingSource.DataMember = "TaskDependencies"
            Me.taskDependenciesBindingSource.DataSource = Me.gantTestDataSet
            ' 
            ' gantTestDataSet
            ' 
            Me.gantTestDataSet.DataSetName = "GantTestDataSet"
            Me.gantTestDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
            ' 
            ' appointmentsBindingSource
            ' 
            Me.appointmentsBindingSource.DataMember = "Appointments"
            Me.appointmentsBindingSource.DataSource = Me.gantTestDataSet
            ' 
            ' resourcesBindingSource
            ' 
            Me.resourcesBindingSource.DataMember = "Resources"
            Me.resourcesBindingSource.DataSource = Me.gantTestDataSet
            ' 
            ' appointmentsTableAdapter
            ' 
            Me.appointmentsTableAdapter.ClearBeforeFill = True
            ' 
            ' resourcesTableAdapter
            ' 
            Me.resourcesTableAdapter.ClearBeforeFill = True
            ' 
            ' taskDependenciesTableAdapter
            ' 
            Me.taskDependenciesTableAdapter.ClearBeforeFill = True
            ' 
            ' colId
            ' 
            Me.colId.FieldName = "Id"
            Me.colId.Name = "colId"
            ' 
            ' colIdSort
            ' 
            Me.colIdSort.FieldName = "IdSort"
            Me.colIdSort.Name = "colIdSort"
            Me.colIdSort.SortOrder = System.Windows.Forms.SortOrder.Ascending
            ' 
            ' colDescription
            ' 
            Me.colDescription.FieldName = "Description"
            Me.colDescription.Name = "colDescription"
            Me.colDescription.Visible = True
            Me.colDescription.VisibleIndex = 0
            ' 
            ' Form1
            ' 
            Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0F, 13.0F)
            Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
            Me.ClientSize = New System.Drawing.Size(700, 489)
            Me.Controls.Add(Me.splitContainerControl1)
            Me.Name = "Form1"
            Me.Text = "Form1"
            CType(Me.splitContainerControl1, System.ComponentModel.ISupportInitialize).EndInit()
            Me.splitContainerControl1.ResumeLayout(False)
            CType(Me.resourcesTree1, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.schedulerControl1, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.schedulerDataStorage1, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.taskDependenciesBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.gantTestDataSet, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.appointmentsBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.resourcesBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
            Me.ResumeLayout(False)

        End Sub

#End Region

        Private splitContainerControl1 As DevExpress.XtraEditors.SplitContainerControl
        Private schedulerControl1 As DevExpress.XtraScheduler.SchedulerControl
        Private schedulerDataStorage1 As DevExpress.XtraScheduler.SchedulerDataStorage
        Private gantTestDataSet As GantTestDataSet
        Private appointmentsBindingSource As System.Windows.Forms.BindingSource
        Private appointmentsTableAdapter As GantTestDataSetTableAdapters.AppointmentsTableAdapter
        Private resourcesBindingSource As System.Windows.Forms.BindingSource
        Private resourcesTableAdapter As GantTestDataSetTableAdapters.ResourcesTableAdapter
        Private taskDependenciesBindingSource As System.Windows.Forms.BindingSource
        Private taskDependenciesTableAdapter As GantTestDataSetTableAdapters.TaskDependenciesTableAdapter
        Private resourcesTree1 As DevExpress.XtraScheduler.UI.ResourcesTree
        Private colIdSort As DevExpress.XtraScheduler.Native.ResourceTreeColumn
        Private colId As DevExpress.XtraScheduler.Native.ResourceTreeColumn
        Private colDescription As DevExpress.XtraScheduler.Native.ResourceTreeColumn
    End Class
End Namespace

