namespace GRLZOHO.Data
{
    public class Task_STL
    {
        public string url { get; set; }
    }

    public class Self_STL
    {
        public string url { get; set; }
    }

    public class Link_STL
    {
        public Task_STL task { get; set; }
        public Self_STL self { get; set; }
        public Status_STL status { get; set; }
    }

    public class TaskCount_STL
    {
        public int closed { get; set; }
    }

    public class Status_STL
    {
        public string url { get; set; }
    }

    public class Project_STL
    {
        public string name { get; set; }
        public string id { get; set; }
    }

    public class StatusDet_STL
    {
        public string name { get; set; }
        public string colorcode { get; set; }
        public string id { get; set; }
    }

    public class Milestone_STL
    {
        public string end_date { get; set; }
        public string flag { get; set; }
        public string owner_id { get; set; }
        public bool is_workfield_removed { get; set; }
        public Link_STL link { get; set; }
        public Project_STL project { get; set; }
        public long start_date_long { get; set; }
        public StatusDet_STL status_det { get; set; }
        public long end_date_long { get; set; }
        public string end_date_format { get; set; }
        public string owner_zpuid { get; set; }
        public long last_updated_time_long { get; set; }
        public long id { get; set; }
        public string start_date { get; set; }
        public long created_time_long { get; set; }
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

    public class Tasklist_STL
    {
        public long created_time_long { get; set; }
        public int open_tasks { get; set; }
        public string created_time { get; set; }
        public string flag { get; set; }
        public string created_time_format { get; set; }
        public Link_STL link { get; set; }
        public bool completed { get; set; }
        public bool rolled { get; set; }
        public int closed_tasks { get; set; }
        public TaskCount_STL task_count { get; set; }
        public int sequence { get; set; }
        public Milestone_STL milestone { get; set; }
        public string last_updated_time { get; set; }
        public long last_updated_time_long { get; set; }
        public string name { get; set; }
        public string id_string { get; set; }
        public long id { get; set; }
        public string last_updated_time_format { get; set; }
    }

    public class STaskListDetails
    {
        public List<Tasklist_STL> tasklists { get; set; }
    }
}