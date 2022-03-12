namespace GRLZOHO.Data
{
    public class Selfname
    {
        public string url { get; set; }
    }

    public class StatusInfo
    {
        public string url { get; set; }
    }

    public class LinkInfo
    {
        public Selfname self { get; set; }
        public StatusInfo status { get; set; }
    }

    public class Project
    {
        public string name { get; set; }
        public string id { get; set; }
    }

    public class StatusDet
    {
        public string name { get; set; }
        public string colorcode { get; set; }
        public string id { get; set; }
    }

    public class Milestone
    {
        public string end_date { get; set; }
        public string flag { get; set; }
        public string owner_id { get; set; }
        public bool is_workfield_removed { get; set; }
        public LinkInfo link { get; set; }
        public Project project { get; set; }
        public object start_date_long { get; set; }
        public StatusDet status_det { get; set; }
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

    public class MilestoneDetails
    {
        public List<Milestone> milestones { get; set; }
    }

}