namespace GRLZOHO.Shared
{
    public partial class NavMenu
    {
        #region Properties
        IJSObjectReference module;
        [Inject] IJSRuntime js { get; set; }
        private bool collapseNavMenu = true;
        private string? NavMenuCssClass => collapseNavMenu ? "collapse" : null;
        public static string FilePath_All { get; set; }
        public static long Owner_Id { get; set; }
        public static List<string> Project_Name { get; set; }
        public static List<string> Project_Link { get; set; }
        public static string Project_RemoveRegex { get; set; }
        public static string P_PName { get; set; }
        public static string Task_url { get; set; }
        public static string All_Task_list { get; set; }
        public static string Milestone_url { get; set; }
        public static string All_Milestone_list { get; set; }
        public static string Issue_url { get; set; }
        public static string All_Issues_list { get; set; }
        public static string Selected_Issue { get; set; }
        public static string Document_url { get; set; }
        public static string Folder_url { get; set; }
        public static string All_Documents_list { get; set; }
        public static string All_Folders_list { get; set; }
        public static string TaskList_url { get; set; }
        public static string All_TaskList_list { get; set; }
        public static string All_SubTask_list { get; set; }
        public static string Selected_SubTask { get; set; }

        //public static string TaskList_Folder { get; set; }
        //public static string Projects_All { get; set; }
        //public static string Selected_Task { get; set; }
        //public static string Projects_Folder { get; set; }
        //public static string? SelectedFilepathAll { get; set; }
        //public static string Task_Folder { get; set; }
        //public static string? Selected_Project { get; set; }
        //public static string Milestone_Folder { get; set; }
        //public string ProjectName_Regex { get; set; }
        //public int jsoncount { get; set; }
        //public static int Index_All { get; set; }
        //public static int SP_Index_No { get; set; }
        //public static int Index_Task { get; set; }
        //public static string Selected_TaskList { get; set; }

        Filepath _FilePath = new Filepath();
        //UserAuthenticationHelper _UserAuth = new UserAuthenticationHelper();
        #endregion
        private void ToggleNavMenu()
        {
            collapseNavMenu = !collapseNavMenu;
        }

        /// <summary>
        /// Gets Initialized Only once when the page is initialized
        /// </summary>
        protected override void OnInitialized()
        {
            Project_Name = new List<string>();
            Project_Link = new List<string>();
            string Projects_Folder = _FilePath.AllFilePath();
            UserAuthenticationHelper.CreateDirectoryFolder(Projects_Folder);
            CheckFile();
        }

        /// <summary>
        /// Generates Access Token for every 45 Minutes automatically
        /// </summary>
        public class TimerToken
        {
            public static System.Timers.Timer GenerateToken;
            /// <summary>
            /// Timer Gets Initialized
            /// </summary>
            public static void Initialize_Timer()
            {
                GenerateToken = new System.Timers.Timer();
                GenerateToken.Elapsed += GenerateAccessToken;
                GenerateToken.AutoReset = false;
                GenerateToken.Interval = 2700000; /* 60 * 45 * 1000 => 45 Minutes */
                GenerateToken.Start();
            }
            /// <summary>
            /// Function To Call Generate Aceess Token
            /// </summary>
            /// <param name="sender"></param>
            /// <param name="e"></param>
            private static void GenerateAccessToken(object sender, System.Timers.ElapsedEventArgs e)
            {
                GenerateToken.Stop();
                try
                {
                    RegenerateAcc_Token.RegenerateAccessToken(Linksforall.A_Token, _Post);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
                finally
                {
                    GenerateToken.Start();
                }
            }
        }

        /// <summary>
        /// Projects gets Reloaded When this function is Invoked
        /// </summary>
        /// <returns></returns>
        public async Task ReloadProjects()
        {
            UserAuthenticationHelper.ClearAllList(Project_Name, Project_Link);
            module = await js.InvokeAsync<IJSObjectReference>("import", "./JS/AlertMessage.js");
            string ProjectFile = _FilePath.PD_Folder();
            if (RegenerateAcc_Token.Access_Token != null)
            {
                RegenerateAcc_Token.Operations_View(Linksforall.AllProjects, RegenerateAcc_Token.Access_Token, _Get);
                File.WriteAllText(ProjectFile, RegenerateAcc_Token.QueryResponse_Json);
            }
            else
            {
                await module.InvokeVoidAsync("displayAlert", "Token has not Generated Properly Kindly Refresh the project");
            }
            LoadProject(ProjectFile);
            await module.InvokeVoidAsync("ReloadPage");
            await module.InvokeVoidAsync("displayAlert", "projects have been Refreshed");
        }

        /// <summary>
        /// This function checks the Projects file is there are not if not it Creates the file
        /// </summary>
        /// <returns></returns>
        public async Task CheckFile()
        {
            if (RegenerateAcc_Token.Access_Token == null)
            {
                RegenerateAcc_Token.RegenerateAccessToken(Linksforall.A_Token, _Post);
            }
            TimerToken.Initialize_Timer();
            UserAuthenticationHelper.ClearAllList(Project_Name, Project_Link);
            string ProjectFile = _FilePath.PD_Folder();
            if (!File.Exists(ProjectFile))
            {
                if (RegenerateAcc_Token.Access_Token != null)
                {
                    RegenerateAcc_Token.Operations_View(Linksforall.AllProjects, RegenerateAcc_Token.Access_Token, _Get);
                    File.WriteAllText(ProjectFile, RegenerateAcc_Token.QueryResponse_Json);
                }
                else
                {
                    module = await js.InvokeAsync<IJSObjectReference>("import", "./JS/AlertMessage.js");
                    await module.InvokeVoidAsync("displayAlert", "Token has not Generated Properly Kindly Refresh the project");
                }
                LoadProject(ProjectFile);
            }
            else
            {
                LoadProject(ProjectFile);
            }
        }

        /// <summary>
        /// This Function Load Data From the File
        /// </summary>
        /// <param name="filepaths">Accepts The filepath of the Project Details</param>
        public void LoadProject(string filepaths)
        {
            var myJsonString = File.ReadAllText(filepaths);
            var myJsonObject = JsonConvert.DeserializeObject<ProjectDetails>(myJsonString);

            //Total count of the projects
            int jsoncount = myJsonObject.projects.Count;

            //Iterates through all the projects name and link
            for (var i = 0; i < jsoncount; i++)
            {
                Project_Name.Add(myJsonObject.projects[i].name);
                Project_Link.Add(myJsonObject.projects[i].link.self.url);

                string ProjectName_Regex = UserAuthenticationHelper.RemoveRegex(Project_Name[i]);
                //Project Folder
                string Projects_All = _FilePath.ProjectNameFilepath(ProjectName_Regex, _Null);
                UserAuthenticationHelper.CreateDirectoryFolder(Projects_All);
                //Milestone Folder
                string Milestone_Folder = _FilePath.ProjectNameFilepath(ProjectName_Regex, MS_Folder);
                UserAuthenticationHelper.CreateDirectoryFolder(Milestone_Folder);
                //Task Folder
                string Task_Folder = _FilePath.ProjectNameFilepath(ProjectName_Regex, T_Folder);
                UserAuthenticationHelper.CreateDirectoryFolder(Task_Folder);
                //Issue Folder
                string Issue_Folder = _FilePath.ProjectNameFilepath(ProjectName_Regex, I_Folder);
                UserAuthenticationHelper.CreateDirectoryFolder(Issue_Folder);
                //Document Folder
                string Document_Folder = _FilePath.ProjectNameFilepath(ProjectName_Regex, DF_Folder);
                UserAuthenticationHelper.CreateDirectoryFolder(Document_Folder);
            }
        }

        /// <summary>
        /// Details of Selected Project
        /// </summary>
        /// <param name="indNo">Index No of the selected Project</param>
        /// <returns></returns>
        public void Select_Project(int indNo)
        {
            if (indNo < Project_Link.Count)
            {
                Project_RemoveRegex = UserAuthenticationHelper.RemoveRegex(Project_Name[indNo]);
                string SelectedProject_txt = UserAuthenticationHelper.GenerateTextFile(Project_RemoveRegex, Project_Details);
                string All_Task_txt = UserAuthenticationHelper.GenerateTextFile(Project_RemoveRegex, All_Tasks_SP);
                string All_Milestone_txt = UserAuthenticationHelper.GenerateTextFile(Project_RemoveRegex, All_Milestones_SP);
                string All_Issues_txt = UserAuthenticationHelper.GenerateTextFile(Project_RemoveRegex, All_Issues_SP);
                //string All_TaskList_txt = _UserAuth.GenerateTextFile(Project_RemoveRegex, All_TaskList_SP);
                #region need to modify ltr
                //string Issues_txt = UserAuthenticationHelper.GenerateTextFile(Project_RemoveRegex, S_Issue);
                string All_Documents_txt = UserAuthenticationHelper.GenerateTextFile(Project_RemoveRegex, All_Documents_SP);
                string All_Folder_txt = UserAuthenticationHelper.GenerateTextFile(Project_RemoveRegex, All_Folders_SP);
                string All_SubTask_txt = UserAuthenticationHelper.GenerateTextFile(Project_RemoveRegex, All_SubTask);
                string S_SubTask_txt = UserAuthenticationHelper.GenerateTextFile(Project_RemoveRegex, S_SubTask);
                //string S_TaskList_txt = _UserAuth.GenerateTextFile(Project_RemoveRegex, S_TaskList);
                #endregion

                FilePath_All = Filepath_ALL(Project_RemoveRegex);
                
                #region FilePaths
                string Selected_Project = _FilePath.ProjectNameFilepath(FilePath_All, SelectedProject_txt);
                All_Task_list = _FilePath.ProjectNameFilepath(FilePath_All, All_Task_txt);
                All_Milestone_list = _FilePath.ProjectNameFilepath(FilePath_All, All_Milestone_txt);
                //All_TaskList_list = _FilePath.ProjectNameFilepath(FilePath_All, All_TaskList_txt);
                All_Issues_list = _FilePath.ProjectNameFilepath(FilePath_All, All_Issues_txt);
                //Selected_Issue = _FilePath.ProjectNameFilepath(FilePath_All, Issues_txt);
                All_Documents_list = _FilePath.ProjectNameFilepath(FilePath_All, All_Documents_txt);
                All_Folders_list = _FilePath.ProjectNameFilepath(FilePath_All, All_Folder_txt);
                All_SubTask_list = _FilePath.ProjectNameFilepath(FilePath_All, All_SubTask_txt);
                Selected_SubTask = _FilePath.ProjectNameFilepath(FilePath_All, S_SubTask_txt);
                //Selected_TaskList = _FilePath.ProjectNameFilepath(FilePath_All, S_TaskList_txt);
                #endregion
                UserAuthenticationHelper.PrintDataToFile(Selected_Project, Project_Link[indNo], _Get, _Null, true);

                var myJsonString = File.ReadAllText(Selected_Project);
                var myJsonObject = JsonConvert.DeserializeObject<ProjectDetails>(myJsonString);

                for (var i = 0; i < myJsonObject.projects.Count; i++)
                {
                    P_PName = myJsonObject.projects[i].name;
                    Task_url = myJsonObject.projects[i].link.task.url;
                    Milestone_url = myJsonObject.projects[i].link.milestone.url;
                    Issue_url = myJsonObject.projects[i].link.bug.url;
                    Document_url = myJsonObject.projects[i].link.document.url;
                    Folder_url = myJsonObject.projects[i].link.folder.url;
                    TaskList_url = myJsonObject.projects[i].link.tasklist.url;
                    Owner_Id = myJsonObject.projects[i].owner_id;
                }
            }
        }

        /// <summary>
        /// Function which creates the filepath of the selected Project
        /// </summary>
        /// <param name="indNo">Index No of the selected Project</param>
        /// <param name="PName">Project Name of the selected project</param>
        /// <returns>Filepath of the Selected Project</returns>
        public string Filepath_ALL(string PName)
        {
            string FPath = _FilePath.ProjectNameFilepath(PName, _Null);
            return FPath;
        }
    }
}