using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraScheduler;
using System.Data.SqlClient;

namespace GanttExample {
    public partial class Form1 : Form {
        private int LastSplitContainerControlSplitterPosition;

        public Form1() {
            InitializeComponent();
            #region #AppointmentEvents
            schedulerDataStorage1.AppointmentsInserted += new PersistentObjectsEventHandler(schedulerDataStorage1_AppointmentsInserted);
            schedulerDataStorage1.AppointmentsChanged += new PersistentObjectsEventHandler(schedulerDataStorage1_AppointmentsChanged);
            schedulerDataStorage1.AppointmentsDeleted += new PersistentObjectsEventHandler(schedulerDataStorage1_AppointmentsDeleted);
            #endregion #AppointmentEvents
            #region #AppointmentDependencyEvents
            schedulerDataStorage1.AppointmentDependenciesInserted += new PersistentObjectsEventHandler(schedulerDataStorage1_AppointmentDependenciesInserted);
            schedulerDataStorage1.AppointmentDependenciesChanged += new PersistentObjectsEventHandler(schedulerDataStorage1_AppointmentDependenciesChanged);
            schedulerDataStorage1.AppointmentDependenciesDeleted += new PersistentObjectsEventHandler(schedulerDataStorage1_AppointmentDependenciesDeleted);
            #endregion #AppointmentDependencyEvents

            //Fix the view type and splitter position.
            schedulerControl1.ActiveViewChanged += new EventHandler(schedulerControl1_ActiveViewChanged);
            this.splitContainerControl1.SplitterPositionChanged += new System.EventHandler(this.splitContainerControl1_SplitterPositionChanged);

            // Set the date to show existing appointments from the database.
            schedulerControl1.Start = new DateTime(2017, 6, 02);

        }

        private void Form1_Load(object sender, EventArgs e) {
            LastSplitContainerControlSplitterPosition = 180;

            // TODO: This line of code loads data into the 'gantTestDataSet.TaskDependencies' table. You can move, or remove it, as needed.
            this.taskDependenciesTableAdapter.Fill(this.gantTestDataSet.TaskDependencies);
            // TODO: This line of code loads data into the 'gantTestDataSet.Resources' table. You can move, or remove it, as needed.
            this.resourcesTableAdapter.Fill(this.gantTestDataSet.Resources);
            // TODO: This line of code loads data into the 'gantTestDataSet.Appointments' table. You can move, or remove it, as needed.
            this.appointmentsTableAdapter.Fill(this.gantTestDataSet.Appointments);            
            this.appointmentsTableAdapter.Adapter.RowUpdated += new SqlRowUpdatedEventHandler(appointmentsTableAdapter_RowUpdated);   

            #region #Adjustment
            schedulerControl1.ActiveViewType = SchedulerViewType.Gantt;
            schedulerControl1.GroupType = SchedulerGroupType.Resource;
            schedulerControl1.GanttView.CellsAutoHeightOptions.Enabled = true;
            // Hide unnecessary visual elements.
            schedulerControl1.GanttView.ShowResourceHeaders = false;
            schedulerControl1.GanttView.NavigationButtonVisibility = NavigationButtonVisibility.Never;
            // Disable user sorting in the Resource Tree (clicking the column will not change the sort order).
            colDescription.OptionsColumn.AllowSort = false;
            #endregion #Adjustment
        }

        #region #Appointment
        private void schedulerDataStorage1_AppointmentsChanged(object sender, PersistentObjectsEventArgs e) {
            CommitTask();
        }

        private void schedulerDataStorage1_AppointmentsDeleted(object sender, PersistentObjectsEventArgs e) {
            CommitTask();
        }
        private void schedulerDataStorage1_AppointmentsInserted(object sender, PersistentObjectsEventArgs e) {

            CommitTask();
            schedulerDataStorage1.SetAppointmentId(((Appointment)e.Objects[0]), id);
        }
        void CommitTask() {

            appointmentsTableAdapter.Update(gantTestDataSet);
            this.gantTestDataSet.AcceptChanges();
        }
        #endregion #Appointment

        #region #TaskDependencies
        private void schedulerDataStorage1_AppointmentDependenciesChanged(object sender, PersistentObjectsEventArgs e) {
            CommitTaskDependency();
        }

        private void schedulerDataStorage1_AppointmentDependenciesDeleted(object sender, PersistentObjectsEventArgs e) {
            CommitTaskDependency();
        }

        private void schedulerDataStorage1_AppointmentDependenciesInserted(object sender, PersistentObjectsEventArgs e) {
            CommitTaskDependency();
        }
        void CommitTaskDependency() {
            taskDependenciesTableAdapter.Update(this.gantTestDataSet);
            this.gantTestDataSet.AcceptChanges();
        }
        #endregion #TaskDependencies

        #region #RowUpdatedHandlers
        int id = 0;
        private void appointmentsTableAdapter_RowUpdated(object sender, SqlRowUpdatedEventArgs e) {
            if (e.Status == UpdateStatus.Continue && e.StatementType == StatementType.Insert) {
                id = 0;
                using (SqlCommand cmd = new SqlCommand("SELECT @@IDENTITY", appointmentsTableAdapter.Connection)) {
                    id = Convert.ToInt32(cmd.ExecuteScalar());
                    e.Row["UniqueId"] = id;
                }
            }
        }
        #endregion #RowUpdatedHandlers

        private void schedulerControl1_ActiveViewChanged(object sender, EventArgs e) {
            this.splitContainerControl1.SplitterPositionChanged -= new System.EventHandler(this.splitContainerControl1_SplitterPositionChanged);
            bool isGanttView = schedulerControl1.ActiveViewType == SchedulerViewType.Gantt;
            try {
                splitContainerControl1.SplitterPosition = (isGanttView) ? LastSplitContainerControlSplitterPosition : 0;
            }
            finally {
                this.splitContainerControl1.SplitterPositionChanged += new System.EventHandler(this.splitContainerControl1_SplitterPositionChanged);
            }
        }

        private void splitContainerControl1_SplitterPositionChanged(object sender, EventArgs e) {
            LastSplitContainerControlSplitterPosition = splitContainerControl1.SplitterPosition;
        }

    }
}
