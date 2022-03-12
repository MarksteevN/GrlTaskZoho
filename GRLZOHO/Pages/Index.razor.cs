namespace GRLZOHO.Pages
{
    public partial class Index
    {
        #region Properties
        public bool Selection { get; set; } = true;
        public int TasklistCount { get; set; }
        public int Document_count { get; set; }
        public static int TasklistMileIndex { get; set; }
        public static string MileTaskListId { get; set; }
        public static long Mile_task { get; set; }
        public static string Mile_Id { get; set; }
        public string IssueFile { get; set; }
        public string TaskFile { get; set; }
        public string MilestoneFile { get; set; }
        public string TaskListFile { get; set; }
        //public string Task_Error { get; set; }
        //public string Milestone_Error { get; set; }
        //public string Issue_Error { get; set; }
        public string Document_Error { get; set; }
        //public string Tasklist_Error { get; set; }
        public static string MilestoneJson { get; set; }
        public static string File_Path_TaskList { get; set; }
        public static string File_Path_Mile { get; set; }
        public static string File_Path_Issue { get; set; }
        public static string File_Path_Document { get; set; }
        public static string DefaultMilestoneFilepath { get; set; }
        public static string DefaultIssueFilepath { get; set; }
        public static string DefaultFolderFilepath { get; set; }
        public static string DefaultTaskFilepath { get; set; }
        public static string DefaultTaskListFilepath { get; set; }
        public static string File_Path_Task { get; set; }
        public static string File_Path_TaskList1 { get; set; }
        public static string File_Path_Mile1 { get; set; }
        public static string File_Path_Task1 { get; set; }
        public static string Tasklist_All { get; set; }
        public static string Milestone_All { get; set; }
        public static string Issue_All { get; set; }
        public static string Document_All { get; set; }
        public static string Task_All { get; set; }
        public static string Tasklist_All1 { get; set; }
        //public static string Milestone_All1 { get; set; }
        //public string DefaultFolder { get; set; }
        public static string Task_All1 { get; set; }
        public static string Milstonename_Regex { get; set; }
        //public static string? Tasklistname_Regex { get; set; }
        //public static string? TaskListMileFolder_Size { get; set; }
        public static string Task_Regex { get; set; }
        public static List<string> T_TName { get; set; }
        public static List<string> M_MName { get; set; }
        public static List<string> M_MFlag { get; set; }
        public static List<string> I_IName { get; set; }
        public List<string> D_DDName { get; set; }
        public List<string> res_name { get; set; }
        public List<string> res_id { get; set; }
        public static List<string> T_TTaskListName { get; set; }
        public static List<string> T_TLink { get; set; }
        public static List<string> M_MLink { get; set; }
        public static List<string> I_ILink { get; set; }
        public List<string> D_DDUrl { get; set; }
        public static List<string> T_TTaskListLink { get; set; }
        public List<string> T_TaskListTaskUrl { get; set; }
        public List<string> T_TTLMSID { get; set; }
        public List<string> M_MID { get; set; }
        public List<string> T_TasklistId { get; set; }
        public static string Milestone_Id { get; set; }
        public static string Tasklist_Id_string { get; set; }
        //public static string TasklistFlag { get; set; }

        IJSObjectReference module;
        [Inject] IJSRuntime js { get; set; }
        //UserAuthenticationHelper _UserAuth = new UserAuthenticationHelper();
        Filepath _FilePath = new Filepath();
        #endregion

        /// <summary>
        /// Gets Initialized Only once when the page is initialized
        /// </summary>
        protected override void OnInitialized()
        {
            T_TName = new List<string>();
            M_MName = new List<string>();
            I_IName = new List<string>();
            D_DDName = new List<string>();
            T_TTaskListName = new List<string>();
            T_TLink = new List<string>();
            M_MLink = new List<string>();
            I_ILink = new List<string>();
            D_DDUrl = new List<string>();
            T_TTaskListLink = new List<string>();
            M_MID = new List<string>();
            T_TaskListTaskUrl = new List<string>();
            T_TasklistId = new List<string>();
            T_TTLMSID = new List<string>();
            M_MFlag = new List<string>();
            res_id = new List<string>();
            res_name = new List<string>();
        }

        /// <summary>
        /// This function  helps to display all the milestones, tasks, issues, documents etc..
        /// </summary>
        public void TaskMiles()
        {
            T_TTaskDetails();
            M_MMilestoneDetails();
            UserAuthenticationHelper.ClearAllList(T_TTaskListName, T_TTaskListLink);
            I_IIssueDetails();
            D_DDocumentDetails();
            Selection = true;
        }

        /// <summary>
        /// This function is used to update the txt files with the updated files
        /// </summary>
        /// <returns></returns>
        public async Task RestoreAllFiles()
        {
            //Tasks
            T_TName.Clear();
            T_TLink.Clear();
            string File_Path_Task = $"{NavMenu.All_Task_list}";
            string urlTask = NavMenu.Task_url;
            RegenerateAcc_Token.Operations_View(urlTask, RegenerateAcc_Token.Access_Token, _Get);
            File.WriteAllText(File_Path_Task, RegenerateAcc_Token.QueryResponse_Json);

            //Milestones
            M_MName.Clear();
            M_MLink.Clear();
            M_MID.Clear();
            M_MFlag.Clear();
            string File_Path_Milestone = $"{NavMenu.All_Milestone_list}";
            string urlMilestone = NavMenu.Milestone_url;
            RegenerateAcc_Token.Operations_View(urlMilestone, RegenerateAcc_Token.Access_Token, _Get);
            File.WriteAllText(File_Path_Milestone, RegenerateAcc_Token.QueryResponse_Json);

            //Issues
            I_IName.Clear();
            I_ILink.Clear();
            string File_Path_Issue = $"{NavMenu.All_Issues_list}";
            string urlIssue = NavMenu.Issue_url;
            RegenerateAcc_Token.Operations_View(urlIssue, RegenerateAcc_Token.Access_Token, _Get);
            File.WriteAllText(File_Path_Issue, RegenerateAcc_Token.QueryResponse_Json);

            //Documents
            D_DDName.Clear();
            D_DDUrl.Clear();
            string File_Path_Documents = $"{NavMenu.All_Documents_list}";
            string urlDocuments = NavMenu.Document_url;
            RegenerateAcc_Token.Operations_View(urlDocuments, RegenerateAcc_Token.Access_Token, _Get);
            File.WriteAllText(File_Path_Documents, RegenerateAcc_Token.QueryResponse_Json);

            T_TTaskListName.Clear();
            T_TTaskListLink.Clear();

            TaskMiles();

            if (RegenerateAcc_Token.StatusOperation == "OK")
            {
                module = await js.InvokeAsync<IJSObjectReference>("import", "./JS/AlertMessage.js");
                await module.InvokeVoidAsync("displayAlert", "Your Pages are Refreshed");
            }
        }

        #region Tasks

        /// <summary>
        /// This function iterates through the file to fetch data of Tasks
        /// </summary>
        public async Task T_TTaskDetails()
        {
            Selection = true;
            UserAuthenticationHelper.ClearAllList(T_TName, T_TLink);
            try
            {
                string File_Path = UserAuthenticationHelper.PrintDataToFile(NavMenu.All_Task_list, NavMenu.Task_url, _Get, _Null, true);

                TaskFile = File.ReadAllText(File_Path);
                var myJsonObject = JsonConvert.DeserializeObject<TaskDetails>(TaskFile);

                if (myJsonObject != null)
                {
                    for (var i = 0; i < myJsonObject.tasks.Count; i++)
                    {
                        T_TName.Add(myJsonObject.tasks[i].name);
                        T_TLink.Add(myJsonObject.tasks[i].link.self.url);

                        string TaskName = UserAuthenticationHelper.Name_Size_Folder(T_TName[i]);
                        Task_All = _FilePath.Filepath_Operations(NavMenu.FilePath_All, T_Folder, TaskName, _Null);
                        try
                        {
                            UserAuthenticationHelper.CreateDirectoryFolder(Task_All);
                        }
                        catch (Exception ex)
                        {
                            string DefaultFolder = _FilePath.Filepath_Operations(NavMenu.FilePath_All, D_Folder, T_Folder, _Null);
                            UserAuthenticationHelper.CreateDirectoryFolder(DefaultFolder);
                            Console.WriteLine(ex.ToString());
                        }
                    }
                }
                else
                {
                    Console.WriteLine(Task_Error);
                }
            }
            catch
            {
                module = await js.InvokeAsync<IJSObjectReference>("import", "./JS/AlertMessage.js");
                await module.InvokeVoidAsync("displayAlert", "Please Select the Project");
            }
        }

        /// <summary>
        /// Fetches the details of selected Tasks
        /// </summary>
        /// <param name="indNo"></param>
        public void T_TTaskSelect(int indNo)
        {
            if (indNo < T_TLink.Count)
            {
                TaskComponent1 taskComponent = new TaskComponent1();
                int temp = taskComponent.GetTaskIndex(indNo);
                try
                {
                    string Task_Name = UserAuthenticationHelper.Name_Size_Folder(T_TName[temp]);
                    string Task_txt = UserAuthenticationHelper.GenerateTextFile(Task_Name, _Null);
                    File_Path_Task = _FilePath.Filepath_Operations(NavMenu.FilePath_All, T_Folder, Task_Name, Task_txt);
                    UserAuthenticationHelper.PrintDataToFile(File_Path_Task, T_TLink[indNo], _Get, _Null, true);
                    NavigateToTaskTab();
                }
                catch
                {
                    DefaultTaskFilepath = _FilePath.SelectedCatchPart(NavMenu.FilePath_All, MS_Folder, DTF_Folder, T_TLink[indNo]);
                    NavigateToTaskTab();
                }
            }
        }

        /// <summary>
        /// Function to Navigate to the new tab where details of Selected Tasks are accepted
        /// </summary>
        /// <returns></returns>
        public async Task NavigateToTaskTab()
        {
            string url = "Task_Details";
            await jsRuntime.InvokeAsync<object>("open", url, "_blank");
        }

        /// <summary>
        /// This function gets invoked when there is a need to update in the txt files of milstones
        /// </summary>
        /// <returns></returns>
        public async Task RefreshTask()
        {
            module = await js.InvokeAsync<IJSObjectReference>("import", "./JS/AlertMessage.js");
            try
            {
                string Filepath = UserAuthenticationHelper.PrintDataToFile(NavMenu.All_Task_list, NavMenu.Task_url, _Get, _Null, false);
                T_TTaskDetails();
                await module.InvokeVoidAsync("displayAlert", "Tasks Have Been Refreshed");
            }
            catch
            {
                await module.InvokeVoidAsync("displayAlert", "Please Select the Project");
            }
        }

        /// <summary>
        /// Navigate to the page to add New Tasklist
        /// </summary>
        /// <param name="Tasklist_id">Selects the Selected milestone to tasklist id</param>
        /// <returns></returns>
        public async Task NavigateToTaskAdd(string Tasklist_id)
        {
            Tasklist_Id_string = Tasklist_id;
            string url = "Task/form";
            await jsRuntime.InvokeAsync<object>("open", url, "_blank");
        }

        /// <summary>
        /// Selects the specific tasks from the selected tasklist
        /// </summary>
        /// <param name="TaskList_Url">Url for the selected tasklist for access the specific tasks</param>
        /// <param name="INdNO">Index number of the selected tasklist</param>
        public void SpecficTaskForTasklist(string TaskList_Url, int INdNO)
        {
            Selection = true;
            UserAuthenticationHelper.ClearAllList(T_TName, T_TLink);

            string Milestone_Name = UserAuthenticationHelper.Name_Size_Folder(T_TTLMSID[INdNO]);
            string TaskList_Name = UserAuthenticationHelper.Name_Size_Folder(T_TTaskListName[INdNO]);
            string TextFileName = UserAuthenticationHelper.GenerateTextFile(TaskList_Name, _Null);
            string CombinedFilepath = _FilePath.Combine_Filepath(NavMenu.FilePath_All, MS_Folder, Milestone_Name);
            string CombinedFilepath1 = _FilePath.Combine_Filepath(TL_Folder, TaskList_Name, SPT_Folder);
            string File_Path = _FilePath.Filepath_Operations(CombinedFilepath, CombinedFilepath1, TextFileName, _Null);
            UserAuthenticationHelper.PrintDataToFile(File_Path, TaskList_Url, _Get, _Null, true);

            TaskFile = File.ReadAllText(File_Path);
            var myJsonObject = JsonConvert.DeserializeObject<TaskDetails>(TaskFile);

            if (myJsonObject != null)
            {
                for (var i = 0; i < myJsonObject.tasks.Count; i++)
                {
                    T_TName.Add(myJsonObject.tasks[i].name);
                    T_TLink.Add(myJsonObject.tasks[i].link.self.url);
                }
            }
            else
            {
                Console.WriteLine(Task_Error);
            }
        }

        #endregion

        #region TaskLists

        /// <summary>
        /// Helps to view the tasklist of the selected milestone
        /// </summary>
        /// <param name="Mile_id">Milestone id of the selected milestone</param>
        /// <param name="INDNO">Index No of the selected Milestone</param>
        /// <param name="Flag">Flag might Be internal or external</param>
        public void T_TaskListDetails(string Mile_id, int INDNO, string Flag)
        {
            Selection = true;
            UserAuthenticationHelper.ClearAllList(T_TTaskListName, T_TTaskListLink, T_TaskListTaskUrl, T_TTLMSID, T_TasklistId);

            TasklistMileIndex = INDNO;
            string url1 = NavMenu.TaskList_url;
            Mile_task = Convert.ToInt64(Mile_id);
            string UrlParameters = $"?flag={Flag}&milestone_id={Mile_task}";

            string Tastlist_txt = UserAuthenticationHelper.GenerateTextFile(NavMenu.Project_RemoveRegex, All_TaskList_SP);
            string File_Path = _FilePath.Filepath_Operations(NavMenu.FilePath_All, MS_Folder, Tastlist_txt, _Null);
            UserAuthenticationHelper.PrintDataToFile(File_Path, url1, _Get, UrlParameters, false);

            TaskListFile = File.ReadAllText(File_Path);
            var myJsonObject = JsonConvert.DeserializeObject<TaskListDetails>(TaskListFile);
            TasklistCount = myJsonObject.tasklists.Count;

            if (TasklistCount != 0)
            {
                for (var i = 0; i < myJsonObject.tasklists.Count; i++)
                {
                    T_TTaskListName.Add(myJsonObject.tasklists[i].name);
                    T_TTaskListLink.Add(myJsonObject.tasklists[i].link.self.url);
                    T_TaskListTaskUrl.Add(myJsonObject.tasklists[i].link.task.url);
                    T_TTLMSID.Add(myJsonObject.tasklists[i].milestone.name);
                    T_TasklistId.Add(myJsonObject.tasklists[i].id_string);

                    string TLMilstoneName = UserAuthenticationHelper.Name_Size_Folder(M_MName[INDNO]);
                    string TLFolderName = UserAuthenticationHelper.Name_Size_Folder(T_TTaskListName[i]);
                    string TLFolder_SPT_Folder = _FilePath.Combine_Filepath(TL_Folder, TLFolderName, SPT_Folder);

                    Tasklist_All = _FilePath.Filepath_Operations(NavMenu.FilePath_All, MS_Folder, TLMilstoneName, TLFolder_SPT_Folder);
                    try
                    {
                        UserAuthenticationHelper.CreateDirectoryFolder(Tasklist_All);
                    }
                    catch (Exception ex)
                    {
                        string DefaultFolder = _FilePath.Filepath_Operations(NavMenu.FilePath_All, D_Folder, TL_Folder, _Null);
                        UserAuthenticationHelper.CreateDirectoryFolder(DefaultFolder);
                        Console.WriteLine(ex.ToString());
                    }
                }
            }
            else
            {
                Console.WriteLine(Tasklist_Error);
            }
        }

        /// <summary>
        /// Details of the selected tasklist
        /// </summary>
        /// <param name="indNo">Index Number of the selected tasklist to view the corresponding details of the tasklists</param>
        public void T_TTaskListSelect(int indNo)
        {
            if (indNo < T_TTaskListLink.Count)
            {
                TaskListComponent taskListComponent = new TaskListComponent();
                int temp = taskListComponent.GetTaskListIndex(indNo);
                try
                {
                    string TLMilestone_Name = UserAuthenticationHelper.Name_Size_Folder(M_MName[TasklistMileIndex]);
                    string TLFolder_Name = UserAuthenticationHelper.Name_Size_Folder(T_TTaskListName[temp]);
                    string Tasklist_txt = UserAuthenticationHelper.GenerateTextFile(TLFolder_Name, _Null);
                    string FP_MS_TLMN_Folder = _FilePath.Combine_Filepath(NavMenu.FilePath_All, MS_Folder, TLMilestone_Name);
                    File_Path_TaskList = _FilePath.Filepath_Operations(FP_MS_TLMN_Folder, TL_Folder, TLFolder_Name, Tasklist_txt);
                    UserAuthenticationHelper.PrintDataToFile(File_Path_TaskList, T_TTaskListLink[indNo], _Get, _Null, true);
                    NavigateToTaskListTab();
                }
                catch
                {
                    DefaultTaskListFilepath = _FilePath.SelectedCatchPart(NavMenu.FilePath_All, TL_Folder, DTLF_Folder, T_TTaskListLink[indNo]);
                    NavigateToTaskListTab();
                }
            }
        }

        /// <summary>
        /// Navigates to the New tasklist tab to vie the details of the selected tasklist
        /// </summary>
        /// <returns></returns>
        public async Task NavigateToTaskListTab()
        {
            string url = "TaskList_Details";
            await jsRuntime.InvokeAsync<object>("open", url, "_blank");
        }

        /// <summary>
        /// Navigates to the tasklist add page for the milestone selected
        /// </summary>
        /// <param name="Mile_id">Milestone id for the selected milestone to add</param>
        /// <returns></returns>
        public async Task NavigateToTaskListAdd(string Mile_id)
        {
            Mile_Id = Mile_id;
            string url = "TaskList/form";
            await jsRuntime.InvokeAsync<object>("open", url, "_blank");
        }

        #endregion

        #region Milestones

        /// <summary>
        /// This function iterates through the file to fetch data of milestones
        /// </summary>
        public async Task M_MMilestoneDetails()
        {
            Selection = true;
            UserAuthenticationHelper.ClearAllList(M_MName, M_MLink, M_MID, M_MFlag);
            try
            {
                string File_Path = UserAuthenticationHelper.PrintDataToFile(NavMenu.All_Milestone_list, NavMenu.Milestone_url, _Get, _Null, true);

                MilestoneFile = File.ReadAllText(File_Path);
                var myJsonObject = JsonConvert.DeserializeObject<MilestoneDetails>(MilestoneFile);

                if (myJsonObject != null)
                {
                    for (var i = 0; i < myJsonObject.milestones.Count; i++)
                    {
                        M_MName.Add(myJsonObject.milestones[i].name);
                        M_MLink.Add(myJsonObject.milestones[i].link.self.url);
                        M_MID.Add(myJsonObject.milestones[i].id_string);
                        M_MFlag.Add(myJsonObject.milestones[i].flag);

                        string MileStone_Name = UserAuthenticationHelper.Name_Size_Folder(M_MName[i]);
                        Milestone_All = _FilePath.Filepath_Operations(NavMenu.FilePath_All, MS_Folder, MileStone_Name, _Null);
                        try
                        {
                            UserAuthenticationHelper.CreateDirectoryFolder(Milestone_All);
                        }
                        catch (Exception ex)
                        {
                            string DefaultFolder = _FilePath.Filepath_Operations(NavMenu.FilePath_All, D_Folder, MS_Folder, _Null);
                            UserAuthenticationHelper.CreateDirectoryFolder(DefaultFolder);
                            Console.WriteLine(ex.ToString());
                        }
                    }
                }
                else
                {
                    Console.WriteLine(Milestone_Error);
                }
            }
            catch
            {
                module = await js.InvokeAsync<IJSObjectReference>("import", "./JS/AlertMessage.js");
                await module.InvokeVoidAsync("displayAlert", "Please Select the Project");
            }
        }

        /// <summary>
        /// Fetches the details of selected Milestone
        /// </summary>
        /// <param name="indNo">Index No of the selected project </param>
        public void M_MMilestoneSelect(int indNo)
        {
            if (indNo < M_MLink.Count)
            {
                MiestoneComponent1 milstone = new MiestoneComponent1();
                int temp = milstone.GetMileIndex(indNo);
                try
                {
                    string Milestone_N = UserAuthenticationHelper.Name_Size_Folder(M_MName[temp]);
                    string Milestone_txt_file = UserAuthenticationHelper.GenerateTextFile(Milestone_N, _Null);
                    File_Path_Mile = _FilePath.Filepath_Operations(NavMenu.FilePath_All, MS_Folder, Milestone_N, Milestone_txt_file);
                    UserAuthenticationHelper.PrintDataToFile(File_Path_Mile, M_MLink[indNo], _Get, _Null, true);
                    NavigateToMilestoneTab();
                }
                catch
                {
                    DefaultMilestoneFilepath = _FilePath.SelectedCatchPart(NavMenu.FilePath_All, MS_Folder, DMF_Folder, M_MLink[indNo]);
                    NavigateToMilestoneTab();
                }
            }
        }

        /// <summary>
        /// Function to Navigate to the new tab where details of Selected Milestones are accepted
        /// </summary>
        /// <returns></returns>
        public async Task NavigateToMilestoneTab()
        {
            string url = "Milestone_Details";
            await jsRuntime.InvokeAsync<object>("open", url, "_blank");
        }

        /// <summary>
        /// This function gets invoked when there is a need to update in the txt files of milstones
        /// </summary>
        /// <returns></returns>
        public async Task RefreshMilestone()
        {
            module = await js.InvokeAsync<IJSObjectReference>("import", "./JS/AlertMessage.js");
            try
            {
                string File_Path = UserAuthenticationHelper.PrintDataToFile(NavMenu.All_Milestone_list, NavMenu.Milestone_url, _Get, _Null, false);
                M_MMilestoneDetails();
                await module.InvokeVoidAsync("displayAlert", "Your Milestones Have Been Updated");
            }
            catch
            {
                await module.InvokeVoidAsync("displayAlert", "Please Select the Project First");
            }
        }

        /// <summary>
        /// Page to add a new Milstone
        /// </summary>
        /// <returns></returns>
        public async Task NavigateToMileAdd()
        {
            string url = "Milestone/form";
            await jsRuntime.InvokeAsync<object>("open", url, "_blank");
        }

        #endregion

        #region Issues

        public async Task I_IIssueDetails()
        {
            Selection = false;
            UserAuthenticationHelper.ClearAllList(I_IName, I_ILink);
            try
            {
                string File_Path = UserAuthenticationHelper.PrintDataToFile(NavMenu.All_Issues_list, NavMenu.Issue_url, _Get, _Null, true);

                IssueFile = File.ReadAllText(File_Path);
                var myJsonObject = JsonConvert.DeserializeObject<IssueDetail>(IssueFile);

                if (myJsonObject != null)
                {
                    for (var i = 0; i < myJsonObject.bugs.Count; i++)
                    {
                        I_IName.Add(myJsonObject.bugs[i].title);
                        I_ILink.Add(myJsonObject.bugs[i].link.self.url);

                        string Issue_Name = UserAuthenticationHelper.Name_Size_Folder(I_IName[i]);
                        Issue_All = _FilePath.Filepath_Operations(NavMenu.FilePath_All, I_Folder, Issue_Name, _Null);
                        try
                        {
                            UserAuthenticationHelper.CreateDirectoryFolder(Issue_All);
                        }
                        catch (Exception ex)
                        {
                            string DefaultFolder = _FilePath.Filepath_Operations(NavMenu.FilePath_All, D_Folder, I_Folder, _Null);
                            UserAuthenticationHelper.CreateDirectoryFolder(DefaultFolder);
                            Console.WriteLine(ex.ToString());
                        }
                    }
                }
                else
                {
                    Console.WriteLine(Issue_Error);
                }
            }
            catch
            {
                module = await js.InvokeAsync<IJSObjectReference>("import", "./JS/AlertMessage.js");
                await module.InvokeVoidAsync("displayAlert", "Please Select the Project");
            }
        }
        public void I_IIssueSelect(int indNo)
        {
            //IssueComponent1 _IssueComp = new IssueComponent1();
            //int temp = _IssueComp.GetIssueIndex(indNo);
            if (indNo < I_ILink.Count)
            {
                int temp = IssueComponent1.GetIssueIndex(indNo);
                try
                {
                    string Issue_N = UserAuthenticationHelper.Name_Size_Folder(I_IName[temp]);
                    string Issue_txt_file = UserAuthenticationHelper.GenerateTextFile(Issue_N, _Null);
                    File_Path_Issue = _FilePath.Filepath_Operations(NavMenu.FilePath_All, I_Folder, Issue_N, Issue_txt_file);
                    UserAuthenticationHelper.PrintDataToFile(File_Path_Issue, I_ILink[indNo], _Get, _Null, true);
                    NavigateToIssueTab();
                }
                catch
                {
                    DefaultIssueFilepath = _FilePath.SelectedCatchPart(NavMenu.FilePath_All, I_Folder, DIF_Folder, I_ILink[indNo]);
                    NavigateToIssueTab();
                }
                //HorizontalNavMenu horizontalNavMenu = new HorizontalNavMenu();
                //if (indNo < I_ILink.Count)
                //{
                //    //horizontalNavMenu.St_Pt_Url(I_ILink[indNo]);
                //    //NavigateToIssueTab();
                //}
            }
        }
        public async Task NavigateToIssueTab()
        {
            string url = "Issue_Details";
            await jsRuntime.InvokeAsync<object>("open", url, "_blank");
        }
        public async Task RefreshIssue()
        {
            module = await js.InvokeAsync<IJSObjectReference>("import", "./JS/AlertMessage.js");
            try
            {
                string File_Path = UserAuthenticationHelper.PrintDataToFile(NavMenu.All_Issues_list, NavMenu.Issue_url, _Get, _Null, false);
                I_IIssueDetails();
                await module.InvokeVoidAsync("displayAlert", "Your Issues Have Been Updated");
            }
            catch
            {
                await module.InvokeVoidAsync("displayAlert", "Please Select the Project First");
            }
        }
        public async Task NavigateToIssueAdd()
        {
            string url = "Issue/form";
            await jsRuntime.InvokeAsync<object>("open", url, "_blank");
        }

        #endregion

        #region Document

        public void D_DocumentFolder()
        {
            Selection = false;
            UserAuthenticationHelper.ClearAllList(res_name, res_id);
            string File_Path = $"{NavMenu.All_Folders_list}";
            if (!File.Exists(File_Path))
            {
                string url1 = NavMenu.Folder_url;
                RegenerateAcc_Token.Operations_View(url1, RegenerateAcc_Token.Access_Token, _Get);
                File.WriteAllText(File_Path, RegenerateAcc_Token.QueryResponse_Json);
            }
            string myjsonstrimg = File.ReadAllText(File_Path);
            var myjsonobject = JsonConvert.DeserializeObject<FolderDetails>(myjsonstrimg);
            for(var i = 0; i < myjsonobject.folders.Count; i++)
            {
                res_name.Add(myjsonobject.folders[i].res_name);
                res_id.Add(myjsonobject.folders[i].res_id);

                string Document_Name = UserAuthenticationHelper.Name_Size_Folder(res_name[i]);
                Document_All = _FilePath.Filepath_Operations(NavMenu.FilePath_All, DF_Folder, Document_Name, _Null);
                try
                {
                    UserAuthenticationHelper.CreateDirectoryFolder(Document_All);
                }
                catch (Exception ex)
                {
                    string DefaultFolder = _FilePath.Filepath_Operations(NavMenu.FilePath_All, D_Folder, DF_Folder, _Null);
                    UserAuthenticationHelper.CreateDirectoryFolder(DefaultFolder);
                    Console.WriteLine(ex.ToString());
                }
            }
            //@onclick="(()=> D_DDocumentSelect(index))"
        }

        public void D_FolderSelect(int indNo)
        {
            DocumentComponent _docCom = new DocumentComponent();
            if (indNo < res_id.Count)
            {
                int temp = _docCom.GetFolderIndex(indNo);
                try
                {
                    string Folder_N = UserAuthenticationHelper.Name_Size_Folder(res_name[temp]);
                    string Document_txt_file = UserAuthenticationHelper.GenerateTextFile(Folder_N, _Null);
                    File_Path_Document = _FilePath.Filepath_Operations(NavMenu.FilePath_All, DF_Folder, Folder_N, Document_txt_file);
                    UserAuthenticationHelper.PrintDataToFile(File_Path_Document, NavMenu.Folder_url, _Get, _Null, true);
                    NavigateToFolderTab();
                }
                catch
                {
                    DefaultFolderFilepath = _FilePath.SelectedCatchPart(NavMenu.FilePath_All, DF_Folder, DDF_Folder, NavMenu.Folder_url);
                    NavigateToFolderTab();
                }
            }
        }
        public async Task NavigateToFolderTab()
        {
            string url = "Documents_Details";
            await jsRuntime.InvokeAsync<object>("open", url, "_blank");
        }
        public void D_DDocumentDetails()
        {
            Selection = false;
            D_DDName.Clear();
            D_DDUrl.Clear();
            Document_Error = "There is No Douments Found !!!";
            string File_Path = $"{NavMenu.All_Documents_list}";
            if (!File.Exists(File_Path))
            {
                string url1 = NavMenu.Document_url;
                RegenerateAcc_Token.Operations_View(url1, RegenerateAcc_Token.Access_Token, _Get);
                System.IO.File.WriteAllText(File_Path, RegenerateAcc_Token.QueryResponse_Json);
            }

            string myJsonString = File.ReadAllText(File_Path);

            var myJsonObject = JsonConvert.DeserializeObject<DocumentDetail>(myJsonString);
            if (myJsonObject != null)
            {
                for (var i = 0; i < myJsonObject.dataobj.Count; i++)
                {
                    D_DDName.Add(myJsonObject.dataobj[i].res_name);
                    Document_count = D_DDUrl.Count;
                    D_DDUrl.Add(myJsonObject.dataobj[i].download_url);
                }
            }
        }
        public async Task D_DDocumentSelect(int indNo)
        {
            if (indNo < D_DDUrl.Count)
            {
                var confirmed = await jsRuntime.InvokeAsync<bool>("confirm", $"Do you Want to Download the {D_DDName[indNo]} File ?");
                if (confirmed)
                {
                    await St_Url(D_DDUrl[indNo]);
                }
            }
        }
        public async Task St_Url(string Downloadlink)
        {
            string url = Downloadlink;
            await jsRuntime.InvokeAsync<object>("open", url, "_blank");
        }

        #endregion
    }
}