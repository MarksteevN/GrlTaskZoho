namespace GRLZOHO.Data
{
    public class TimesheetIssue
    {
        public string url { get; set; }
    }

    public class WebIssue
    {
        public string url { get; set; }
    }

    public class SelfIssue
    {
        public string url { get; set; }
    }

    public class LinkIssue
    {
        public TimesheetIssue timesheet { get; set; }
        public WebIssue web { get; set; }
        public SelfIssue self { get; set; }
    }

    public class Severity
    {
        public object id { get; set; }
        public string type { get; set; }
    }

    public class Reproducible
    {
        public object id { get; set; }
        public string type { get; set; }
    }

    public class Module
    {
        public string name { get; set; }
        public object id { get; set; }
    }

    public class Classification
    {
        public object id { get; set; }
        public string type { get; set; }
    }

    public class ASSOCIATEDTEAMSISSUE
    {
        public string AnyTeam { get; set; }
    }

    public class GROUPNAMEIssue
    {
        public ASSOCIATEDTEAMSISSUE ASSOCIATED_TEAMS { get; set; }
        public int ASSOCIATED_TEAMS_COUNT { get; set; }
        public bool IS_TEAM_UNASSIGNED { get; set; }
    }

    public class StatusIssue
    {
        public string colorcode { get; set; }
        public string id { get; set; }
        public string type { get; set; }
    }

    public class Bug
    {
        public object updated_time_long { get; set; }
        public string comment_count { get; set; }
        public string updated_time { get; set; }
        public object assignee_zpuid { get; set; }
        public string flag { get; set; }
        public string updated_time_format { get; set; }
        public LinkIssue link { get; set; }
        public string description { get; set; }
        public string title { get; set; }
        public string assignee_name { get; set; }
        public string reporter_id { get; set; }
        public object id { get; set; }
        public string escalation_level { get; set; }
        public string key { get; set; }
        public object created_time_long { get; set; }
        public Severity severity { get; set; }
        public string created_time { get; set; }
        public string created_time_format { get; set; }
        public Reproducible reproducible { get; set; }
        public Module module { get; set; }
        public Classification classification { get; set; }
        public GROUPNAMEIssue GROUP_NAME { get; set; }
        public string bug_number { get; set; }
        public string reporter_non_zuser { get; set; }
        public string reported_person { get; set; }
        public string reporter_email { get; set; }
        public string id_string { get; set; }
        public bool closed { get; set; }
        public string bug_prefix { get; set; }
        public string attachment_count { get; set; }
        public StatusIssue status { get; set; }
    }

    public class IssueDetail
    {
        public List<Bug> bugs { get; set; }
    }

}