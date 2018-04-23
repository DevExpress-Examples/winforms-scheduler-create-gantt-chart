using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using System.Data.SqlClient;
using DevExpress.XtraScheduler;

namespace GanttStepByStep
{
    public partial class Form1 : Form
    {
        private int LastSplitContainerControlSplitterPosition;

        public Form1()
        {
            InitializeComponent();

            schedulerStorage1.AppointmentsInserted += new PersistentObjectsEventHandler(schedulerStorage1_AppointmentsInserted);
            schedulerStorage1.AppointmentsChanged += new PersistentObjectsEventHandler(schedulerStorage1_AppointmentsChanged);
            schedulerStorage1.AppointmentsDeleted += new PersistentObjectsEventHandler(schedulerStorage1_AppointmentsDeleted);
            schedulerStorage1.AppointmentDependenciesInserted += new PersistentObjectsEventHandler(schedulerStorage1_AppointmentDependenciesInserted);
            schedulerStorage1.AppointmentDependenciesChanged += new PersistentObjectsEventHandler(schedulerStorage1_AppointmentDependenciesChanged);
            schedulerStorage1.AppointmentDependenciesDeleted += new PersistentObjectsEventHandler(schedulerStorage1_AppointmentDependenciesDeleted);

            schedulerControl1.ActiveViewChanged+=new EventHandler(schedulerControl1_ActiveViewChanged);

            this.splitContainerControl1.SplitterPositionChanged += new System.EventHandler(this.splitContainerControl1_SplitterPositionChanged);
        }


        private void Form1_Load(object sender, EventArgs e)
        {
            LastSplitContainerControlSplitterPosition = 180;
            
            // TODO: This line of code loads data into the 'gantTestDataSet.TaskDependencies' table. You can move, or remove it, as needed.
            this.taskDependenciesTableAdapter.Fill(this.gantTestDataSet.TaskDependencies);
            // TODO: This line of code loads data into the 'gantTestDataSet.Resources' table. You can move, or remove it, as needed.
            this.resourcesTableAdapter.Fill(this.gantTestDataSet.Resources);
            // TODO: This line of code loads data into the 'gantTestDataSet.Appointments' table. You can move, or remove it, as needed.
            this.appointmentsTableAdapter.Fill(this.gantTestDataSet.Appointments);

            schedulerStorage1.Appointments.CommitIdToDataSource = false;
            this.appointmentsTableAdapter.Adapter.RowUpdated += new SqlRowUpdatedEventHandler(appointmentsTableAdapter_RowUpdated);

            schedulerControl1.ActiveViewType = SchedulerViewType.Gantt;
            schedulerControl1.GroupType = SchedulerGroupType.Resource;
            schedulerControl1.GanttView.ShowResourceHeaders = true; 
        }


        #region #RowUpdatedHandlers
        int id = 0;
        private void appointmentsTableAdapter_RowUpdated(object sender, SqlRowUpdatedEventArgs e)
        {
            if (e.Status == UpdateStatus.Continue && e.StatementType == StatementType.Insert) {
                id = 0;
                using (SqlCommand cmd = new SqlCommand("SELECT @@IDENTITY", appointmentsTableAdapter.Connection)) {
                    id = Convert.ToInt32(cmd.ExecuteScalar());
                    e.Row["UniqueId"] = id;
                }
            }
        }
        #endregion #RowUpdatedHandlers

        #region #Appointment
        private void schedulerStorage1_AppointmentsChanged(object sender, PersistentObjectsEventArgs e)
        {
            CommitTask();
        }

        private void schedulerStorage1_AppointmentsDeleted(object sender, PersistentObjectsEventArgs e)
        {
            CommitTask();
        }
        private void schedulerStorage1_AppointmentsInserted(object sender, PersistentObjectsEventArgs e)
        {

            CommitTask();
            schedulerStorage1.SetAppointmentId(((Appointment)e.Objects[0]), id);
        }
        void CommitTask()
        {

            appointmentsTableAdapter.Update(gantTestDataSet);
            this.gantTestDataSet.AcceptChanges();
        }
        #endregion #Appointment
        #region #TaskDependencies
        private void schedulerStorage1_AppointmentDependenciesChanged(object sender, PersistentObjectsEventArgs e)
        {
            CommitTaskDependency();
        }

        private void schedulerStorage1_AppointmentDependenciesDeleted(object sender, PersistentObjectsEventArgs e)
        {
            CommitTaskDependency();
        }

        private void schedulerStorage1_AppointmentDependenciesInserted(object sender, PersistentObjectsEventArgs e)
        {
             CommitTaskDependency();
        }
        void CommitTaskDependency()
        {
            taskDependenciesTableAdapter.Update(this.gantTestDataSet);
            this.gantTestDataSet.AcceptChanges();
        }
        #endregion #TaskDependencies

        private void schedulerControl1_ActiveViewChanged(object sender, EventArgs e)
        {
            this.splitContainerControl1.SplitterPositionChanged -= new System.EventHandler(this.splitContainerControl1_SplitterPositionChanged);
            bool isGanttView = schedulerControl1.ActiveViewType == SchedulerViewType.Gantt;
            try {
                splitContainerControl1.SplitterPosition = (isGanttView) ? LastSplitContainerControlSplitterPosition : 0;
            }
            finally {
                this.splitContainerControl1.SplitterPositionChanged += new System.EventHandler(this.splitContainerControl1_SplitterPositionChanged);
            }
        }

        private void splitContainerControl1_SplitterPositionChanged(object sender, EventArgs e)
        {
            LastSplitContainerControlSplitterPosition = splitContainerControl1.SplitterPosition;
        }
    }
}
