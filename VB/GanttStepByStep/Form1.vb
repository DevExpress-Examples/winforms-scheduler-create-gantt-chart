Imports System
Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.Data
Imports System.Drawing
Imports System.Linq
Imports System.Text
Imports System.Windows.Forms

Imports System.Data.SqlClient
Imports DevExpress.XtraScheduler

Namespace GanttStepByStep
    Partial Public Class Form1
        Inherits Form

        Private LastSplitContainerControlSplitterPosition As Integer

        Public Sub New()
            InitializeComponent()
'            #Region "#AppointmentEvents"
            AddHandler schedulerStorage1.AppointmentsInserted, AddressOf schedulerStorage1_AppointmentsInserted
            AddHandler schedulerStorage1.AppointmentsChanged, AddressOf schedulerStorage1_AppointmentsChanged
            AddHandler schedulerStorage1.AppointmentsDeleted, AddressOf schedulerStorage1_AppointmentsDeleted
'            #End Region ' #AppointmentEvents
'            #Region "#AppointmentDependencyEvents"
            AddHandler schedulerStorage1.AppointmentDependenciesInserted, AddressOf schedulerStorage1_AppointmentDependenciesInserted
            AddHandler schedulerStorage1.AppointmentDependenciesChanged, AddressOf schedulerStorage1_AppointmentDependenciesChanged
            AddHandler schedulerStorage1.AppointmentDependenciesDeleted, AddressOf schedulerStorage1_AppointmentDependenciesDeleted
'            #End Region ' #AppointmentDependencyEvents

            'Fix the view type and splitter position.
            AddHandler schedulerControl1.ActiveViewChanged, AddressOf schedulerControl1_ActiveViewChanged
            AddHandler splitContainerControl1.SplitterPositionChanged, AddressOf splitContainerControl1_SplitterPositionChanged

            ' Set the date to show existing appointments from the database.
            schedulerControl1.Start = New Date(2016, 11, 02)
        End Sub


        Private Sub Form1_Load(ByVal sender As Object, ByVal e As EventArgs) Handles MyBase.Load
            LastSplitContainerControlSplitterPosition = 180

            ' TODO: This line of code loads data into the 'gantTestDataSet.TaskDependencies' table. You can move, or remove it, as needed.
            Me.taskDependenciesTableAdapter.Fill(Me.gantTestDataSet.TaskDependencies)
            ' TODO: This line of code loads data into the 'gantTestDataSet.Resources' table. You can move, or remove it, as needed.
            Me.resourcesTableAdapter.Fill(Me.gantTestDataSet.Resources)
            ' TODO: This line of code loads data into the 'gantTestDataSet.Appointments' table. You can move, or remove it, as needed.
            Me.appointmentsTableAdapter.Fill(Me.gantTestDataSet.Appointments)
'            #Region "#CommitIdToDataSource"
            schedulerStorage1.Appointments.CommitIdToDataSource = False
            AddHandler appointmentsTableAdapter.Adapter.RowUpdated, AddressOf appointmentsTableAdapter_RowUpdated
'            #End Region ' #CommitIdToDataSource

'            #Region "#Adjustment"
            schedulerControl1.ActiveViewType = SchedulerViewType.Gantt
            schedulerControl1.GroupType = SchedulerGroupType.Resource
            schedulerControl1.GanttView.CellsAutoHeightOptions.Enabled = True
            ' Hide unnecessary visual elements.
            schedulerControl1.GanttView.ShowResourceHeaders = False
            schedulerControl1.GanttView.NavigationButtonVisibility = NavigationButtonVisibility.Never
            ' Disable user sorting in the Resource Tree (clicking the column will not change the sort order).
            colDescription.OptionsColumn.AllowSort = False
'            #End Region ' #Adjustment

        End Sub


        #Region "#RowUpdatedHandlers"
        Private id As Integer = 0
        Private Sub appointmentsTableAdapter_RowUpdated(ByVal sender As Object, ByVal e As SqlRowUpdatedEventArgs)
            If e.Status = UpdateStatus.Continue AndAlso e.StatementType = StatementType.Insert Then
                id = 0
                Using cmd As New SqlCommand("SELECT @@IDENTITY", appointmentsTableAdapter.Connection)
                    id = Convert.ToInt32(cmd.ExecuteScalar())
                    e.Row("UniqueId") = id
                End Using
            End If
        End Sub
        #End Region ' #RowUpdatedHandlers

        #Region "#Appointment"
        Private Sub schedulerStorage1_AppointmentsChanged(ByVal sender As Object, ByVal e As PersistentObjectsEventArgs)
            CommitTask()
        End Sub

        Private Sub schedulerStorage1_AppointmentsDeleted(ByVal sender As Object, ByVal e As PersistentObjectsEventArgs)
            CommitTask()
        End Sub
        Private Sub schedulerStorage1_AppointmentsInserted(ByVal sender As Object, ByVal e As PersistentObjectsEventArgs)

            CommitTask()
            schedulerStorage1.SetAppointmentId((CType(e.Objects(0), Appointment)), id)
        End Sub
        Private Sub CommitTask()

            appointmentsTableAdapter.Update(gantTestDataSet)
            Me.gantTestDataSet.AcceptChanges()
        End Sub
        #End Region ' #Appointment
        #Region "#TaskDependencies"
        Private Sub schedulerStorage1_AppointmentDependenciesChanged(ByVal sender As Object, ByVal e As PersistentObjectsEventArgs)
            CommitTaskDependency()
        End Sub

        Private Sub schedulerStorage1_AppointmentDependenciesDeleted(ByVal sender As Object, ByVal e As PersistentObjectsEventArgs)
            CommitTaskDependency()
        End Sub

        Private Sub schedulerStorage1_AppointmentDependenciesInserted(ByVal sender As Object, ByVal e As PersistentObjectsEventArgs)
             CommitTaskDependency()
        End Sub
        Private Sub CommitTaskDependency()
            taskDependenciesTableAdapter.Update(Me.gantTestDataSet)
            Me.gantTestDataSet.AcceptChanges()
        End Sub
        #End Region ' #TaskDependencies

        Private Sub schedulerControl1_ActiveViewChanged(ByVal sender As Object, ByVal e As EventArgs)
            RemoveHandler splitContainerControl1.SplitterPositionChanged, AddressOf splitContainerControl1_SplitterPositionChanged
            Dim isGanttView As Boolean = schedulerControl1.ActiveViewType = SchedulerViewType.Gantt
            Try
                splitContainerControl1.SplitterPosition = If(isGanttView, LastSplitContainerControlSplitterPosition, 0)
            Finally
                AddHandler splitContainerControl1.SplitterPositionChanged, AddressOf splitContainerControl1_SplitterPositionChanged
            End Try
        End Sub

        Private Sub splitContainerControl1_SplitterPositionChanged(ByVal sender As Object, ByVal e As EventArgs)
            LastSplitContainerControlSplitterPosition = splitContainerControl1.SplitterPosition
        End Sub
    End Class
End Namespace
