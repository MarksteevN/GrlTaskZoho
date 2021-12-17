namespace GRLZOHO.Data
{
    public class Owner
    {
        public string zpuid { get; set; }
        public string name { get; set; }
        public string id { get; set; }
        public string email { get; set; }
    }

    public class Details
    {
        public List<Owner> owners { get; set; }
    }

    public class CustomField
    {
        public string column_name { get; set; }
        public string label_name { get; set; }
        public string value { get; set; }
    }

    public class FOLLOWER
    {
        public string FPHOTO { get; set; }
        public string FOLLOWERID { get; set; }
        public string FNAME { get; set; }
    }

    public class TaskFollowers
    {
        public string FOLUSERS { get; set; }
        public int FOLLOWERSIZE { get; set; }
        public List<FOLLOWER> FOLLOWERS { get; set; }
    }

    public class Tasklist
    {
        public string name { get; set; }
        public string id_string { get; set; }
        public string id { get; set; }
    }

    public class Status
    {
        public string name { get; set; }
        public string id { get; set; }
        public string type { get; set; }
        public string color_code { get; set; }
    }

    public class Timesheet
    {
        public string url { get; set; }
    }

    public class Web
    {
        public string url { get; set; }
    }

    public class Self
    {
        public string url { get; set; }
    }

    public class Subtask
    {
        public string url { get; set; }
    }

    public class Link
    {
        public Timesheet timesheet { get; set; }
        public Web web { get; set; }
        public Self self { get; set; }
        public Subtask subtask { get; set; }
    }

    public class ASSOCIATEDTEAMS
    {
        public string AnyTeam { get; set; }
    }

    public class GROUPNAME
    {
        public ASSOCIATEDTEAMS ASSOCIATED_TEAMS { get; set; }
        public int ASSOCIATED_TEAMS_COUNT { get; set; }
        public bool IS_TEAM_UNASSIGNED { get; set; }
    }

    public class LogHours
    {
        public string non_billable_hours { get; set; }
        public string billable_hours { get; set; }
    }

    public class TaskInfo
    {
        public object start_date_long { get; set; }
        public bool is_comment_added { get; set; }
        public string end_date_format { get; set; }
        public object last_updated_time_long { get; set; }
        public bool is_forum_associated { get; set; }
        public Details details { get; set; }
        public object id { get; set; }
        public string created_time { get; set; }
        public string work { get; set; }
        public List<CustomField> custom_fields { get; set; }
        public string start_date_format { get; set; }
        public bool isparent { get; set; }
        public object completed_time_long { get; set; }
        public string work_type { get; set; }
        public bool completed { get; set; }
        public TaskFollowers task_followers { get; set; }
        public string priority { get; set; }
        public string created_by { get; set; }
        public string last_updated_time { get; set; }
        public string name { get; set; }
        public bool is_docs_assocoated { get; set; }
        public Tasklist tasklist { get; set; }
        public string last_updated_time_format { get; set; }
        public string billingtype { get; set; }
        public long order_sequence { get; set; }
        public Status status { get; set; }
        public string end_date { get; set; }
        public bool is_sprints_task { get; set; }
        public string milestone_id { get; set; }
        public Link link { get; set; }
        public string description { get; set; }
        public string created_by_zpuid { get; set; }
        public string work_form { get; set; }
        public string completed_time_format { get; set; }
        public object end_date_long { get; set; }
        public string duration { get; set; }
        public string created_by_email { get; set; }
        public string key { get; set; }
        public string start_date { get; set; }
        public string created_person { get; set; }
        public object created_time_long { get; set; }
        public bool is_reminder_set { get; set; }
        public bool is_recurrence_set { get; set; }
        public string created_time_format { get; set; }
        public bool subtasks { get; set; }
        public string duration_type { get; set; }
        public string percent_complete { get; set; }
        public GROUPNAME GROUP_NAME { get; set; }
        public string completed_time { get; set; }
        public string id_string { get; set; }
        public LogHours log_hours { get; set; }
    }

    public class TaskDetails
    {
        public List<TaskInfo> tasks { get; set; }
    }
}
