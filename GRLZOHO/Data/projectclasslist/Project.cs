using System.Collections.Generic; 
namespace GRLZOHO.Data.projectclasslist{ 

    public class Project
    {
        public string is_strict { get; set; }
        public string project_percent { get; set; }
        public string role { get; set; }
        public BugCount bug_count { get; set; }
        public bool IS_BUG_ENABLED { get; set; }
        public string owner_id { get; set; }
        public string bug_client_permission { get; set; }
        public string taskbug_prefix { get; set; }
        public Link link { get; set; }
        public string custom_status_id { get; set; }
        public string description { get; set; }
        public MilestoneCount milestone_count { get; set; }
        public object updated_date_long { get; set; }
        public bool show_project_overview { get; set; }
        public TaskCount task_count { get; set; }
        public string updated_date_format { get; set; }
        public string workspace_id { get; set; }
        public string custom_status_name { get; set; }
        public string owner_zpuid { get; set; }
        public string is_client_assign_bug { get; set; }
        public string bug_defaultview { get; set; }
        public string billing_status { get; set; }
        public object id { get; set; }
        public string key { get; set; }
        public bool is_chat_enabled { get; set; }
        public bool is_sprints_project { get; set; }
        public string custom_status_color { get; set; }
        public string owner_name { get; set; }
        public object created_date_long { get; set; }
        public List<CustomField> custom_fields { get; set; }
        public string created_date_format { get; set; }
        public object profile_id { get; set; }
        public List<string> enabled_tabs { get; set; }
        public string name { get; set; }
        public string is_public { get; set; }
        public string id_string { get; set; }
        public string created_date { get; set; }
        public string updated_date { get; set; }
        public string bug_prefix { get; set; }
        public CascadeSetting cascade_setting { get; set; }
        public LayoutDetails layout_details { get; set; }
        public string status { get; set; }
        public long? start_date_long { get; set; }
        public string start_date { get; set; }
        public string end_date { get; set; }
        public long? end_date_long { get; set; }
        public long? sprints_project_id { get; set; }
        public string sprints_project_key { get; set; }
        public string completed_on { get; set; }
        public long? completed_on_long { get; set; }
        public string group_name { get; set; }
        public long? group_id { get; set; }
    }

}