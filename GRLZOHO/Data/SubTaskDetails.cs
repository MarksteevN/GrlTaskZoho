namespace GRLZOHO.Data
{
    public class Owner_S
    {
        public string zpuid { get; set; }
        public string name { get; set; }
        public string id { get; set; }
    }

    public class Details_S
    {
        public List<Owner_S> owners { get; set; }
    }

    public class CustomField_S
    {
        public string column_name { get; set; }
        public string label_name { get; set; }
        public string value { get; set; }
    }

    public class TaskFollowers_S
    {
        public string FOLUSERS { get; set; }
        public int FOLLOWERSIZE { get; set; }
        public List<object> FOLLOWERS { get; set; }
    }

    public class Tasklist_S
    {
        public string name { get; set; }
        public string id_string { get; set; }
        public string id { get; set; }
    }

    public class Status_S
    {
        public string name { get; set; }
        public string id { get; set; }
        public string type { get; set; }
        public string color_code { get; set; }
    }

    public class Timesheet_S
    {
        public string url { get; set; }
    }

    public class Web_S
    {
        public string url { get; set; }
    }

    public class Self_S
    {
        public string url { get; set; }
    }

    public class Link_S
    {
        public Timesheet_S timesheet { get; set; }
        public Web_S web { get; set; }
        public Self_S self { get; set; }
    }

    public class ASSOCIATEDTEAMS_S
    {
        public string AnyTeam { get; set; }
    }

    public class GROUPNAME_S
    {
        public ASSOCIATEDTEAMS_S ASSOCIATED_TEAMS { get; set; }
        public int ASSOCIATED_TEAMS_COUNT { get; set; }
        public bool IS_TEAM_UNASSIGNED { get; set; }
    }

    public class LogHours_S
    {
        public string non_billable_hours { get; set; }
        public string billable_hours { get; set; }
    }

    public class Task_S_Info
    {
        public string parent_task_id { get; set; }
        public bool is_comment_added { get; set; }
        public object last_updated_time_long { get; set; }
        public bool is_forum_associated { get; set; }
        public Details_S details { get; set; }
        public object id { get; set; }
        public string created_time { get; set; }
        public string work { get; set; }
        public List<CustomField_S> custom_fields { get; set; }
        public bool isparent { get; set; }
        public string work_type { get; set; }
        public bool completed { get; set; }
        public TaskFollowers_S task_followers { get; set; }
        public string priority { get; set; }
        public string created_by { get; set; }
        public string last_updated_time { get; set; }
        public string root_task_id { get; set; }
        public string name { get; set; }
        public bool is_docs_assocoated { get; set; }
        public Tasklist_S tasklist { get; set; }
        public string last_updated_time_format { get; set; }
        public string billingtype { get; set; }
        public int order_sequence { get; set; }
        public Status_S status { get; set; }
        public bool is_sprints_task { get; set; }
        public string milestone_id { get; set; }
        public Link_S link { get; set; }
        public string description { get; set; }
        public string created_by_zpuid { get; set; }
        public string work_form { get; set; }
        public string duration { get; set; }
        public string created_by_email { get; set; }
        public string key { get; set; }
        public string created_person { get; set; }
        public object created_time_long { get; set; }
        public bool is_reminder_set { get; set; }
        public bool is_recurrence_set { get; set; }
        public string created_time_format { get; set; }
        public bool subtasks { get; set; }
        public string duration_type { get; set; }
        public string parenttask_id { get; set; }
        public string percent_complete { get; set; }
        public GROUPNAME_S GROUP_NAME { get; set; }
        public int depth { get; set; }
        public string id_string { get; set; }
        public LogHours_S log_hours { get; set; }
    }

    public class SubTaskDetails
    {
        public List<Task_S_Info> tasks { get; set; }
    }

}