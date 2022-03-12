namespace GRLZOHO.Data
{
    public class Task_TaskList
    {
        public string url { get; set; }
    }

    public class Self_TaskList
    {
        public string url { get; set; }
    }

    public class Link_TaskList
    {
        public Task_TaskList task { get; set; }
        public Self_TaskList self { get; set; }
        public Status_TaskList status { get; set; }
    }

    public class TaskCount
    {
        public int closed { get; set; }
        public int open { get; set; }
    }

    public class Status_TaskList
    {
        public string url { get; set; }
    }

    public class Project_TaskList
    {
        public string name { get; set; }
        public string id { get; set; }
    }

    public class StatusDet_TaskList
    {
        public string name { get; set; }
        public string colorcode { get; set; }
        public string id { get; set; }
    }

    public class Milestone_TaskList
    {
        public string end_date { get; set; }
        public string flag { get; set; }
        public string owner_id { get; set; }
        public bool is_workfield_removed { get; set; }
        public Link_TaskList link { get; set; }
        public Project_TaskList project { get; set; }
        public object start_date_long { get; set; }
        public StatusDet_TaskList status_det { get; set; }
        public object end_date_long { get; set; }
        public string end_date_format { get; set; }
        public string owner_zpuid { get; set; }
        public object last_updated_time_long { get; set; }
        public object id { get; set; }
        public string start_date { get; set; }
        public object created_time_long { get; set; }
        public string created_time { get; set; }
        public string owner_name { get; set; }
        public string created_time_format { get; set; }
        public string start_date_format { get; set; }
        public int sequence { get; set; }
        public string last_updated_time { get; set; }
        public string name { get; set; }
        public string id_string { get; set; }
        public bool closed { get; set; }
        public string last_updated_time_format { get; set; }
        public string status { get; set; }
    }

    public class Tasklist_TaskList
    {
        public object created_time_long { get; set; }
        public string created_time { get; set; }
        public string flag { get; set; }
        public string created_time_format { get; set; }
        public Link_TaskList link { get; set; }
        public bool completed { get; set; }
        public bool rolled { get; set; }
        public TaskCount task_count { get; set; }
        public int sequence { get; set; }
        public Milestone_TaskList milestone { get; set; }
        public string last_updated_time { get; set; }
        public object last_updated_time_long { get; set; }
        public string name { get; set; }
        public string id_string { get; set; }
        public object id { get; set; }
        public string last_updated_time_format { get; set; }
    }

    public class TaskListDetails
    {
        public List<Tasklist_TaskList> tasklists { get; set; }
    }

}