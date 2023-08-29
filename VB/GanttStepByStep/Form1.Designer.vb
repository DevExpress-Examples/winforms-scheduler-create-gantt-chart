Namespace GanttStepByStep

    Partial Class Form1

        ''' <summary>
        ''' Required designer variable.
        ''' </summary>
        Private components As System.ComponentModel.IContainer = Nothing

        ''' <summary>
        ''' Clean up any resources being used.
        ''' </summary>
        ''' <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        Protected Overrides Sub Dispose(ByVal disposing As Boolean)
            If disposing AndAlso (Me.components IsNot Nothing) Then
                Me.components.Dispose()
            End If

            MyBase.Dispose(disposing)
        End Sub

'#Region "Windows Form Designer generated code"
        ''' <summary>
        ''' Required method for Designer support - do not modify
        ''' the contents of this method with the code editor.
        ''' </summary>
        Private Sub InitializeComponent()
            Me.components = New System.ComponentModel.Container()
            Dim timeRuler1 As DevExpress.XtraScheduler.TimeRuler = New DevExpress.XtraScheduler.TimeRuler()
            Dim timeRuler2 As DevExpress.XtraScheduler.TimeRuler = New DevExpress.XtraScheduler.TimeRuler()
            Me.schedulerStorage1 = New DevExpress.XtraScheduler.SchedulerStorage(Me.components)
            Me.splitContainerControl1 = New DevExpress.XtraEditors.SplitContainerControl()
            Me.resourcesTree1 = New DevExpress.XtraScheduler.UI.ResourcesTree()
            Me.colId = New DevExpress.XtraScheduler.Native.ResourceTreeColumn()
            Me.schedulerControl1 = New DevExpress.XtraScheduler.SchedulerControl()
            Me.splitContainerControl2 = New DevExpress.XtraEditors.SplitContainerControl()
            Me.gantTestDataSet = New GanttStepByStep.GantTestDataSet()
            Me.appointmentsBindingSource = New System.Windows.Forms.BindingSource(Me.components)
            Me.appointmentsTableAdapter = New GanttStepByStep.GantTestDataSetTableAdapters.AppointmentsTableAdapter()
            Me.resourcesBindingSource = New System.Windows.Forms.BindingSource(Me.components)
            Me.resourcesTableAdapter = New GanttStepByStep.GantTestDataSetTableAdapters.ResourcesTableAdapter()
            Me.taskDependenciesBindingSource = New System.Windows.Forms.BindingSource(Me.components)
            Me.taskDependenciesTableAdapter = New GanttStepByStep.GantTestDataSetTableAdapters.TaskDependenciesTableAdapter()
            Me.colDescription = New DevExpress.XtraScheduler.Native.ResourceTreeColumn()
            CType((Me.schedulerStorage1), System.ComponentModel.ISupportInitialize).BeginInit()
            CType((Me.splitContainerControl1), System.ComponentModel.ISupportInitialize).BeginInit()
            Me.splitContainerControl1.SuspendLayout()
            CType((Me.resourcesTree1), System.ComponentModel.ISupportInitialize).BeginInit()
            CType((Me.schedulerControl1), System.ComponentModel.ISupportInitialize).BeginInit()
            CType((Me.splitContainerControl2), System.ComponentModel.ISupportInitialize).BeginInit()
            Me.splitContainerControl2.SuspendLayout()
            CType((Me.gantTestDataSet), System.ComponentModel.ISupportInitialize).BeginInit()
            CType((Me.appointmentsBindingSource), System.ComponentModel.ISupportInitialize).BeginInit()
            CType((Me.resourcesBindingSource), System.ComponentModel.ISupportInitialize).BeginInit()
            CType((Me.taskDependenciesBindingSource), System.ComponentModel.ISupportInitialize).BeginInit()
            Me.SuspendLayout()
            ' 
            ' schedulerStorage1
            ' 
            Me.schedulerStorage1.AppointmentDependencies.DataSource = Me.taskDependenciesBindingSource
            Me.schedulerStorage1.AppointmentDependencies.Mappings.DependentId = "DependentId"
            Me.schedulerStorage1.AppointmentDependencies.Mappings.ParentId = "ParentId"
            Me.schedulerStorage1.AppointmentDependencies.Mappings.Type = "Type"
            Me.schedulerStorage1.Appointments.DataSource = Me.appointmentsBindingSource
            Me.schedulerStorage1.Appointments.Mappings.AllDay = "AllDay"
            Me.schedulerStorage1.Appointments.Mappings.AppointmentId = "UniqueId"
            Me.schedulerStorage1.Appointments.Mappings.Description = "Description"
            Me.schedulerStorage1.Appointments.Mappings.[End] = "EndDate"
            Me.schedulerStorage1.Appointments.Mappings.Label = "Label"
            Me.schedulerStorage1.Appointments.Mappings.Location = "Location"
            Me.schedulerStorage1.Appointments.Mappings.PercentComplete = "PercentComplete"
            Me.schedulerStorage1.Appointments.Mappings.RecurrenceInfo = "RecurrenceInfo"
            Me.schedulerStorage1.Appointments.Mappings.ReminderInfo = "ReminderInfo"
            Me.schedulerStorage1.Appointments.Mappings.ResourceId = "ResourceId"
            Me.schedulerStorage1.Appointments.Mappings.Start = "StartDate"
            Me.schedulerStorage1.Appointments.Mappings.Status = "Status"
            Me.schedulerStorage1.Appointments.Mappings.Subject = "Subject"
            Me.schedulerStorage1.Appointments.Mappings.Type = "Type"
            Me.schedulerStorage1.Resources.DataSource = Me.resourcesBindingSource
            Me.schedulerStorage1.Resources.Mappings.Caption = "Description"
            Me.schedulerStorage1.Resources.Mappings.Color = "Color"
            Me.schedulerStorage1.Resources.Mappings.Id = "Id"
            Me.schedulerStorage1.Resources.Mappings.Image = "Image"
            Me.schedulerStorage1.Resources.Mappings.ParentId = "ParentId"
            ' 
            ' splitContainerControl1
            ' 
            Me.splitContainerControl1.Dock = System.Windows.Forms.DockStyle.Fill
            Me.splitContainerControl1.Location = New System.Drawing.Point(0, 0)
            Me.splitContainerControl1.Name = "splitContainerControl1"
            Me.splitContainerControl1.Panel1.Controls.Add(Me.resourcesTree1)
            Me.splitContainerControl1.Panel1.Text = "Panel1"
            Me.splitContainerControl1.Panel2.Controls.Add(Me.splitContainerControl2)
            Me.splitContainerControl1.Panel2.Controls.Add(Me.schedulerControl1)
            Me.splitContainerControl1.Panel2.Text = "Panel2"
            Me.splitContainerControl1.Size = New System.Drawing.Size(707, 450)
            Me.splitContainerControl1.SplitterPosition = 202
            Me.splitContainerControl1.TabIndex = 0
            Me.splitContainerControl1.Text = "splitContainerControl1"
            ' 
            ' resourcesTree1
            ' 
            Me.resourcesTree1.Columns.AddRange(New DevExpress.XtraTreeList.Columns.TreeListColumn() {Me.colId, Me.colDescription})
            Me.resourcesTree1.Dock = System.Windows.Forms.DockStyle.Fill
            Me.resourcesTree1.Location = New System.Drawing.Point(0, 0)
            Me.resourcesTree1.Name = "resourcesTree1"
            Me.resourcesTree1.SchedulerControl = Me.schedulerControl1
            Me.resourcesTree1.Size = New System.Drawing.Size(202, 450)
            Me.resourcesTree1.TabIndex = 0
            ' 
            ' colId
            ' 
            Me.colId.FieldName = "Id"
            Me.colId.Name = "colId"
            Me.colId.SortOrder = System.Windows.Forms.SortOrder.Ascending
            ' 
            ' schedulerControl1
            ' 
            Me.schedulerControl1.Dock = System.Windows.Forms.DockStyle.Fill
            Me.schedulerControl1.Location = New System.Drawing.Point(0, 0)
            Me.schedulerControl1.Name = "schedulerControl1"
            Me.schedulerControl1.Size = New System.Drawing.Size(500, 450)
            Me.schedulerControl1.Start = New System.DateTime(2011, 10, 26, 0, 0, 0, 0)
            Me.schedulerControl1.Storage = Me.schedulerStorage1
            Me.schedulerControl1.TabIndex = 0
            Me.schedulerControl1.Text = "schedulerControl1"
            Me.schedulerControl1.Views.DayView.TimeRulers.Add(timeRuler1)
            Me.schedulerControl1.Views.WorkWeekView.TimeRulers.Add(timeRuler2)
            ' 
            ' splitContainerControl2
            ' 
            Me.splitContainerControl2.Location = New System.Drawing.Point(422, 324)
            Me.splitContainerControl2.Name = "splitContainerControl2"
            Me.splitContainerControl2.Panel1.Text = "Panel1"
            Me.splitContainerControl2.Panel2.Text = "Panel2"
            Me.splitContainerControl2.Size = New System.Drawing.Size(8, 8)
            Me.splitContainerControl2.TabIndex = 1
            Me.splitContainerControl2.Text = "splitContainerControl2"
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
            ' appointmentsTableAdapter
            ' 
            Me.appointmentsTableAdapter.ClearBeforeFill = True
            ' 
            ' resourcesBindingSource
            ' 
            Me.resourcesBindingSource.DataMember = "Resources"
            Me.resourcesBindingSource.DataSource = Me.gantTestDataSet
            ' 
            ' resourcesTableAdapter
            ' 
            Me.resourcesTableAdapter.ClearBeforeFill = True
            ' 
            ' taskDependenciesBindingSource
            ' 
            Me.taskDependenciesBindingSource.DataMember = "TaskDependencies"
            Me.taskDependenciesBindingSource.DataSource = Me.gantTestDataSet
            ' 
            ' taskDependenciesTableAdapter
            ' 
            Me.taskDependenciesTableAdapter.ClearBeforeFill = True
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
            Me.AutoScaleDimensions = New System.Drawing.SizeF(6F, 13F)
            Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
            Me.ClientSize = New System.Drawing.Size(707, 450)
            Me.Controls.Add(Me.splitContainerControl1)
            Me.Name = "Form1"
            Me.Text = "Form1"
            AddHandler Me.Load, New System.EventHandler(AddressOf Me.Form1_Load)
            CType((Me.schedulerStorage1), System.ComponentModel.ISupportInitialize).EndInit()
            CType((Me.splitContainerControl1), System.ComponentModel.ISupportInitialize).EndInit()
            Me.splitContainerControl1.ResumeLayout(False)
            CType((Me.resourcesTree1), System.ComponentModel.ISupportInitialize).EndInit()
            CType((Me.schedulerControl1), System.ComponentModel.ISupportInitialize).EndInit()
            CType((Me.splitContainerControl2), System.ComponentModel.ISupportInitialize).EndInit()
            Me.splitContainerControl2.ResumeLayout(False)
            CType((Me.gantTestDataSet), System.ComponentModel.ISupportInitialize).EndInit()
            CType((Me.appointmentsBindingSource), System.ComponentModel.ISupportInitialize).EndInit()
            CType((Me.resourcesBindingSource), System.ComponentModel.ISupportInitialize).EndInit()
            CType((Me.taskDependenciesBindingSource), System.ComponentModel.ISupportInitialize).EndInit()
            Me.ResumeLayout(False)
        End Sub

'#End Region
        Private schedulerStorage1 As DevExpress.XtraScheduler.SchedulerStorage

        Private splitContainerControl1 As DevExpress.XtraEditors.SplitContainerControl

        Private resourcesTree1 As DevExpress.XtraScheduler.UI.ResourcesTree

        Private colId As DevExpress.XtraScheduler.Native.ResourceTreeColumn

        Private schedulerControl1 As DevExpress.XtraScheduler.SchedulerControl

        Private splitContainerControl2 As DevExpress.XtraEditors.SplitContainerControl

        Private gantTestDataSet As GanttStepByStep.GantTestDataSet

        Private appointmentsBindingSource As System.Windows.Forms.BindingSource

        Private appointmentsTableAdapter As GanttStepByStep.GantTestDataSetTableAdapters.AppointmentsTableAdapter

        Private resourcesBindingSource As System.Windows.Forms.BindingSource

        Private resourcesTableAdapter As GanttStepByStep.GantTestDataSetTableAdapters.ResourcesTableAdapter

        Private taskDependenciesBindingSource As System.Windows.Forms.BindingSource

        Private taskDependenciesTableAdapter As GanttStepByStep.GantTestDataSetTableAdapters.TaskDependenciesTableAdapter

        Private colDescription As DevExpress.XtraScheduler.Native.ResourceTreeColumn
    End Class
End Namespace
