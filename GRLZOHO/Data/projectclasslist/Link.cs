namespace GRLZOHO.Data.projectclasslist{ 

    public class Link
    {
        public Activity activity { get; set; }
        public Document document { get; set; }
        public Forum forum { get; set; }
        public Timesheet timesheet { get; set; }
        public TaskInfo task { get; set; }
        public Folder folder { get; set; }
        public Milestone milestone { get; set; }
        public Bug bug { get; set; }
        public Self self { get; set; }
        public Tasklist tasklist { get; set; }
        public Event @event { get; set; }
        public User user { get; set; }
        public Status status { get; set; }
    }

}