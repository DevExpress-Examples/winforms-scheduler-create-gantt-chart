# How to create Gantt chart using the Scheduler bound to MS SQL Server database


<p>This is a simple example of XtraScheduler bound to MS SQL Server database displaying <a href="http://documentation.devexpress.com/#WindowsForms/CustomDocument10698"><u>Gantt view</u></a>. This project also utilizes the <a href="http://documentation.devexpress.com/#WindowsForms/CustomDocument10685"><u>ResourcesTree control</u></a> to display an hierarchy of resources and the <a href="http://documentation.devexpress.com/#WindowsForms/clsDevExpressXtraEditorsSplitContainerControltopic"><u>SplitContainer control</u></a> to allow resizing of Scheduler and ResourceTree controls.<br> The project has been created by following the step-by-step guide in the <a href="http://documentation.devexpress.com/#WindowsForms/CustomDocument10699"><u>How to: Bind a Scheduler to Data and Show the Gantt View</u></a>.<br><br><img src="https://raw.githubusercontent.com/DevExpress-Examples/how-to-create-gantt-chart-using-the-scheduler-bound-to-ms-sql-server-database-e3574/11.2.5+/media/35cef863-5b49-11e7-80c0-00155d624807.png"></p>


<h3>Description</h3>

<p>Please note that <strong>ResourcesTreeControl </strong>version 2011.2 does not support independent ordering using the <strong>SortOrder </strong>property of its columns. If the sorting order is specified, resource tree may become out of sync with the bound scheduler. So you are advised to modify the <strong>Step 11</strong>  in Step-by-Step Guide and do not specify sort order for the <strong>IdSort </strong>field as well as for other fields.</p>

<br/>


