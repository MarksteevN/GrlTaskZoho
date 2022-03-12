namespace GRLZOHO.Pages
{
    public partial class TaskListComponent
    {
        #region Properties
        public string TaskListname { get; set; }
        public string Flag { get; set; }
        public List<string> TaskLink { get; set; }
        public int Open_task { get; set; }
        public int Closed_task { get; set; }
        public static int GetTaskListIndexNo { get; set; }
        IJSObjectReference module;
        [Inject] IJSRuntime js { get; set; }
        UserAuthenticationHelper _UserAuth = new UserAuthenticationHelper();
        #endregion

        /// <summary>
        /// Gets Initialized Only once when the page is initialized
        /// </summary>
        protected override void OnInitialized()
        {
            TaskLink = new List<string>();
            if (File.Exists(Index.File_Path_TaskList))
            {
                TaskList_Details(Index.File_Path_TaskList);
            }
            else
            {
                TaskList_Details(Index.DefaultTaskListFilepath);
                Console.WriteLine("Error Occured While printing");
            }
        }

        /// <summary>
        /// the function Makes sure of updated data
        /// </summary>
        /// <returns></returns>
        public async Task RefreshSelectedTasklist()
        {
            UserAuthenticationHelper.PrintDataToFile(Index.File_Path_TaskList, Index.T_TTaskListLink[GetTaskListIndexNo], _Get, _Null, false);
            TaskList_Details(Index.File_Path_TaskList);
            module = await js.InvokeAsync<IJSObjectReference>("import", "./JS/AlertMessage.js");
            await module.InvokeVoidAsync("displayAlert", "TaskList have been refreshed");
        }

        /// <summary>
        /// Fetching the data from the txt file
        /// </summary>
        /// <param name="Filepath">Filepath for the txt file</param>
        public void TaskList_Details(string Filepath)
        {
            var myJsonString = File.ReadAllText(Filepath);
            var myJsonObject = JsonConvert.DeserializeObject<STaskListDetails>(myJsonString);

            for (var i = 0; i < myJsonObject.tasklists.Count; i++)
            {
                TaskListname = myJsonObject.tasklists[i].name;
                Open_task = myJsonObject.tasklists[i].open_tasks;
                Closed_task = myJsonObject.tasklists[i].closed_tasks;
                Flag = myJsonObject.tasklists[i].flag;
                TaskLink.Add(myJsonObject.tasklists[i].link.task.url);
            }
        }

        /// <summary>
        /// Makes the selected tasklist index no as static so that it can be used in other places too
        /// </summary>
        /// <param name="indNO">Index number of the selected tasklist</param>
        /// <returns></returns>
        public int GetTaskListIndex(int indNO)
        {
            GetTaskListIndexNo = indNO;
            return indNO;
        }
    }
}