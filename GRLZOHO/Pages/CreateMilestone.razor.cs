namespace GRLZOHO.Pages
{
    public partial class CreateMilestone
    {
        #region Properties
        MilestoneName milestoneName = new MilestoneName();
        IJSObjectReference module;
        [Inject] IJSRuntime js { get; set; }
        public string P_Name { get; set; }
        //private UserAuthenticationHelper _UserAuth = new UserAuthenticationHelper();
        #endregion

        /// <summary>
        /// Gets Initialized Only once when the page is initialized
        /// </summary>
        protected override void OnInitialized()
        {
            milestoneName.start_date = DateOnly.FromDateTime(DateTime.Today);
            milestoneName.end_date = DateOnly.FromDateTime(DateTime.Today);
        }

        /// <summary>
        /// This function helps to reinitialize the values as in the begining
        /// </summary>
        public void reset()
        {
            milestoneName.Name = " ";
            milestoneName.start_date = DateOnly.FromDateTime(DateTime.Today);
            milestoneName.end_date = DateOnly.FromDateTime(DateTime.Today);
            milestoneName.flag = "Choose flag";
        }

        /// <summary>
        /// On Valid submit this function gets trigerred and call the other method to create a Milestone by passing some of the parameters
        /// </summary>
        /// <returns></returns>
        public async Task Submit()
        {
            string MileName = milestoneName.Name;
            DateOnly SDate = milestoneName.start_date;
            DateOnly EDate = milestoneName.end_date;
            string StartDate = UserAuthenticationHelper.MM_DD_YYYY_format(SDate);
            string EndDate = UserAuthenticationHelper.MM_DD_YYYY_format(EDate);
            long Ownerid = NavMenu.Owner_Id;
            string flag = milestoneName.flag;
            string url1 = NavMenu.Milestone_url;
            module = await js.InvokeAsync<IJSObjectReference>("import", "./JS/AlertMessage.js");

            if (url1 == null || Ownerid == 0)
            {
                await module.InvokeVoidAsync("displayAlert", "Select the project");
            }
            else
            {
                string UrlParameters = $"?name={MileName}&start_date={StartDate}&end_date={EndDate}&owner={Ownerid}&flag={flag}";
                RegenerateAcc_Token.MT_MileTasklist(url1, RegenerateAcc_Token.Access_Token, _Post, UrlParameters);
                if (RegenerateAcc_Token.Ststuscode == "Created")
                {
                    await module.InvokeVoidAsync("displayAlert", "Your Milestone is Created");
                }
                else if (RegenerateAcc_Token.Ststuscode == "BadRequest")
                {
                    await module.InvokeVoidAsync("displayAlert", "Input Parameter Does not Match the Pattern Specified");
                }
                else
                {
                    await module.InvokeVoidAsync("displayAlert", "Your Milestone is not Created");
                }
            }
            await module.InvokeVoidAsync("CloseWindow");
        }

        /// <summary>
        /// Required properties for Creating Milestones
        /// </summary>
        class MilestoneName
        {
            [Required(ErrorMessage = "Milestone Name is required")]
            public string Name { get; set; }

            [Required(ErrorMessage = "Start Date is required")]
            public DateOnly start_date { get; set; }

            [Required(ErrorMessage = "End Date is required")]
            public DateOnly end_date { get; set; }

            [Required(ErrorMessage = "flag field is required")]
            public string? flag { get; set; }
        }
    }
}