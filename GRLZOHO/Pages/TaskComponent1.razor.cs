namespace GRLZOHO.Pages
{
    public partial class TaskComponent1
    {
        #region Properties
        public List<string> Owner_name { get; set; }
        public List<string> Followers_Name { get; set; }
        public string Priority { get; set; }
        public string Statuss { get; set; }
        public string Startdate { get; set; }
        public string EndDtae { get; set; }
        public string SubTask_Error { get; set; }
        public string Taskname { get; set; }
        public string T_Web { get; set; }
        public int TaskFollowers_Count { get; set; }
        public string TaskFollowers_Error { get; set; }
        public string T_Description { get; set; }
        public string Tasklist_Name { get; set; }
        public static int GetTaskIndexNo { get; set; }
        IJSObjectReference module;
        [Inject] IJSRuntime js { get; set; }
        //UserAuthenticationHelper _UserAuth = new UserAuthenticationHelper();
        #endregion

        /// <summary>
        /// Gets Initialized Only once when the page is initialized
        /// </summary>
        protected override void OnInitialized()
        {
            Owner_name = new List<string>();
            Followers_Name = new List<string>();
            if (File.Exists(Index.File_Path_Task))
            {
                Task_Details(Index.File_Path_Task);
            }
            else
            {
                Task_Details(Index.DefaultTaskFilepath);
                Console.WriteLine("Error Occured While printing");
            }
        }

        /// <summary>
        /// the function Makes sure of updated data
        /// </summary>
        /// <returns></returns>
        public async Task RefreshSelectedTask()
        {
            UserAuthenticationHelper.ClearAllList(Owner_name, Followers_Name);
            UserAuthenticationHelper.PrintDataToFile(Index.File_Path_Task, Index.T_TLink[GetTaskIndexNo], _Get, _Null, false);
            Task_Details(Index.File_Path_Task);
            module = await js.InvokeAsync<IJSObjectReference>("import", "./JS/AlertMessage.js");
            await module.InvokeVoidAsync("displayAlert", "Task have been refreshed");
        }

        /// <summary>
        /// Fetching the data from the txt file
        /// </summary>
        /// <param name="FilePath">Filepath for the txt file</param>
        public void Task_Details(string FilePath)
        {
            int indNo = 0;
            var myJsonString = File.ReadAllText(FilePath);
            var myJsonObject = JsonConvert.DeserializeObject<TaskDetails>(myJsonString);

            Taskname = myJsonObject.tasks[indNo].name;
            for (var i = 0; i < myJsonObject.tasks[indNo].details.owners.Count; i++)
            {
                Owner_name.Add(myJsonObject.tasks[indNo].details.owners[i].name);
            }
            TaskFollowers_Count = myJsonObject.tasks[indNo].task_followers.FOLLOWERS.Count;
            for (var i = 0; i < TaskFollowers_Count; i++)
            {
                Followers_Name.Add(myJsonObject.tasks[indNo].task_followers.FOLLOWERS[i].FNAME);
            }

            Priority = myJsonObject.tasks[indNo].priority;
            T_Web = myJsonObject.tasks[indNo].link.web.url;
            Statuss = myJsonObject.tasks[indNo].status.name;
            Startdate = myJsonObject.tasks[indNo].start_date;
            EndDtae = myJsonObject.tasks[indNo].end_date;
            T_Description = myJsonObject.tasks[indNo].description;
            Tasklist_Name = myJsonObject.tasks[indNo].tasklist.name;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public async Task SubtaskDetails()
        {
            var confirmed = await jsRuntime.InvokeAsync<bool>("confirm", $"Do you Want to See SubTask of {Taskname} ?");
            if (confirmed)
            {
                int indNo = 0;
                string File_Path = $"{Index.File_Path_Task}";
                System.IO.File.WriteAllText(File_Path, RegenerateAcc_Token.QueryResponse_Json);
                var myJsonString = File.ReadAllText(File_Path);

                //string FilePath = @"D:\Marksteev_GRL\Github Files\GRLZOHO\GRLZOHO\Appdata\Selected_Task.txt";
                //var myJsonString = File.ReadAllText(FilePath);
                var myJsonObject = JsonConvert.DeserializeObject<TaskDetails>(myJsonString);
                try
                {

                    string SelfTask_Link = myJsonObject.tasks[indNo].link.subtask.url;
                    RegenerateAcc_Token.Operations_View(SelfTask_Link, RegenerateAcc_Token.Access_Token, EnumClass.METHOD.GET.ToString());

                    UriHelper.NavigateTo("projectlist/task/taskdetails/SubTask");
                }
                catch (Exception e)
                {
                    SubTask_Error = "There is No SubTask Found";
                    UriHelper.NavigateTo("/SubTask/NotFound");
                    Console.WriteLine(e.Message);
                }
            }
        }
        
        /// <summary>
        /// Navigates to the actual webpage of zoho
        /// </summary>
        /// <returns></returns>
        public async Task NavigateToNewTab()
        {
            var confirmed = await jsRuntime.InvokeAsync<bool>("confirm", "Do you Want to See Tasks In Detail ?");
            if (confirmed)
            {
                string url = T_Web;
                await jsRuntime.InvokeAsync<object>("open", url, "_blank");
            }
        }

        /// <summary>
        /// Makes the selected task index no as static so that it can be used in other places too
        /// </summary>
        /// <param name="indNO">Index Number of the selected task</param>
        /// <returns></returns>
        public int GetTaskIndex(int indNO)
        {
            GetTaskIndexNo = indNO;
            return indNO;
        }
    }
}