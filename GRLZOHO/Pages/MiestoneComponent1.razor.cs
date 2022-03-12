namespace GRLZOHO.Pages
{
    public partial class MiestoneComponent1
    {
        #region Properties
        public string Project_Name { get; set; }
        public string Milestone_Name { get; set; }
        public string Owner_M_name { get; set; }
        public string Statuss_M { get; set; }
        public string Startdate_M { get; set; }
        public string EndDtae_M { get; set; }
        public string M_Web { get; set; }
        public static string Milssto_id { get; set; }
        public static int GetMileIndexNo { get; set; }
        IJSObjectReference module;
        [Inject] IJSRuntime js { get; set; }
        //UserAuthenticationHelper _UserAuth = new UserAuthenticationHelper();
        #endregion

        /// <summary>
        /// Gets Initialized Only once when the page is initialized
        /// </summary>
        protected override void OnInitialized()
        {
            if (File.Exists(Index.File_Path_Mile))
            {
                Milestone_Details(Index.File_Path_Mile);
            }
            else
            {
                Milestone_Details(Index.DefaultMilestoneFilepath);
                Console.WriteLine("Error Occured While printing");
            }

        }

        /// <summary>
        /// the function Makes sure of updated data
        /// </summary>
        /// <returns></returns>
        public async Task RefreshSelectedMilestone()
        {
            UserAuthenticationHelper.PrintDataToFile(Index.File_Path_Mile, Index.M_MLink[GetMileIndexNo], _Get, _Null, false);
            Milestone_Details(Index.File_Path_Mile);
            module = await js.InvokeAsync<IJSObjectReference>("import", "./JS/AlertMessage.js");
            await module.InvokeVoidAsync("displayAlert", "Milestones have been refreshed");
        }
        
        /// <summary>
        /// Fetching the data from the txt file
        /// </summary>
        /// <param name="FilePath">Filepath for the txt file</param>
        public void Milestone_Details(string FilePath)
        {
            int indNo = 0;

            var myJsonString = File.ReadAllText(FilePath);
            var myJsonObject = JsonConvert.DeserializeObject<MilestoneDetails>(myJsonString);

            Project_Name = myJsonObject.milestones[indNo].project.name;
            Milestone_Name = myJsonObject.milestones[indNo].name;
            Owner_M_name = myJsonObject.milestones[indNo].owner_name;
            Statuss_M = myJsonObject.milestones[indNo].status_det.name;
            Startdate_M = myJsonObject.milestones[indNo].start_date;
            EndDtae_M = myJsonObject.milestones[indNo].end_date;
            Milssto_id = myJsonObject.milestones[indNo].id_string;
        }
        
        /// <summary>
        /// Makes the selected mile index no as static so that it can be used in other places too
        /// </summary>
        /// <param name="indNO">Index number of the selected milestone</param>
        /// <returns></returns>
        public int GetMileIndex(int indNO)
        {
            GetMileIndexNo = indNO;
            return indNO;
        }
    }
}