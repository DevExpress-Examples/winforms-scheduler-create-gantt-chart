Imports System
Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.Data
Imports System.Drawing
Imports System.Linq
Imports System.Text
Imports System.Threading.Tasks
Imports System.Windows.Forms
Imports DevExpress.XtraScheduler
Imports System.Data.SqlClient

Namespace GanttExample
    Partial Public Class Form1
        Inherits Form

        Private LastSplitContainerControlSplitterPosition As Integer

        Public Sub New()
            InitializeComponent()
            '            #Region "#AppointmentEvents"
            AddHandler schedulerDataStorage1.AppointmentsInserted, AddressOf schedulerDataStorage1_AppointmentsInserted
            AddHandler schedulerDataStorage1.AppointmentsChanged, AddressOf schedulerDataStorage1_AppointmentsChanged
            AddHandler schedulerDataStorage1.AppointmentsDeleted, AddressOf schedulerDataStorage1_AppointmentsDeleted
            '            #End Region ' #AppointmentEvents
            '            #Region "#AppointmentDependencyEvents"
            AddHandler schedulerDataStorage1.AppointmentDependenciesInserted, AddressOf schedulerDataStorage1_AppointmentDependenciesInserted
            AddHandler schedulerDataStorage1.AppointmentDependenciesChanged, AddressOf schedulerDataStorage1_AppointmentDependenciesChanged
            AddHandler schedulerDataStorage1.AppointmentDependenciesDeleted, AddressOf schedulerDataStorage1_AppointmentDependenciesDeleted
            '            #End Region ' #AppointmentDependencyEvents

            'Fix the view type and splitter position.
            AddHandler schedulerControl1.ActiveViewChanged, AddressOf schedulerControl1_ActiveViewChanged
            AddHandler splitContainerControl1.SplitterPositionChanged, AddressOf splitContainerControl1_SplitterPositionChanged

            ' Set the date to show existing appointments from the database.
            schedulerControl1.Start = New Date(2017, 6, 2)

        End Sub

        Private Sub Form1_Load(ByVal sender As Object, ByVal e As EventArgs) Handles Me.Load
            LastSplitContainerControlSplitterPosition = 180

            ' TODO: This line of code loads data into the 'gantTestDataSet.TaskDependencies' table. You can move, or remove it, as needed.
            Me.taskDependenciesTableAdapter.Fill(Me.gantTestDataSet.TaskDependencies)
            ' TODO: This line of code loads data into the 'gantTestDataSet.Resources' table. You can move, or remove it, as needed.
            Me.resourcesTableAdapter.Fill(Me.gantTestDataSet.Resources)
            ' TODO: This line of code loads data into the 'gantTestDataSet.Appointments' table. You can move, or remove it, as needed.
            Me.appointmentsTableAdapter.Fill(Me.gantTestDataSet.Appointments)           '           

            AddHandler appointmentsTableAdapter.Adapter.RowUpdated, AddressOf appointmentsTableAdapter_RowUpdated            '          

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

#Region "#Appointment"
        Private Sub schedulerDataStorage1_AppointmentsChanged(ByVal sender As Object, ByVal e As PersistentObjectsEventArgs)
            CommitTask()
        End Sub

        Private Sub schedulerDataStorage1_AppointmentsDeleted(ByVal sender As Object, ByVal e As PersistentObjectsEventArgs)
            CommitTask()
        End Sub
        Private Sub schedulerDataStorage1_AppointmentsInserted(ByVal sender As Object, ByVal e As PersistentObjectsEventArgs)

            CommitTask()
            schedulerDataStorage1.SetAppointmentId((CType(e.Objects(0), Appointment)), id)
        End Sub
        Private Sub CommitTask()

            appointmentsTableAdapter.Update(gantTestDataSet)
            Me.gantTestDataSet.AcceptChanges()
        End Sub
#End Region ' #Appointment

#Region "#TaskDependencies"
        Private Sub schedulerDataStorage1_AppointmentDependenciesChanged(ByVal sender As Object, ByVal e As PersistentObjectsEventArgs)
            CommitTaskDependency()
        End Sub

        Private Sub schedulerDataStorage1_AppointmentDependenciesDeleted(ByVal sender As Object, ByVal e As PersistentObjectsEventArgs)
            CommitTaskDependency()
        End Sub

        Private Sub schedulerDataStorage1_AppointmentDependenciesInserted(ByVal sender As Object, ByVal e As PersistentObjectsEventArgs)
            CommitTaskDependency()
        End Sub
        Private Sub CommitTaskDependency()
            taskDependenciesTableAdapter.Update(Me.gantTestDataSet)
            Me.gantTestDataSet.AcceptChanges()
        End Sub
        #End Region ' #TaskDependencies

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
