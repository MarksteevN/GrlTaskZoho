namespace GRLZOHO.Pages
{
    public partial class CreateTask
    {
        #region Properties
        private TaskDetails taskDetails = new TaskDetails();
        IJSObjectReference module;
        [Inject] IJSRuntime js { get; set; }
        //private UserAuthenticationHelper _UserAuth = new UserAuthenticationHelper();
        #endregion

        /// <summary>
        /// Gets Initialized Only once when the page is initialized
        /// </summary>
        protected override void OnInitialized()
        {
            taskDetails.start_date = DateOnly.FromDateTime(DateTime.Today);
            taskDetails.end_date = DateOnly.FromDateTime(DateTime.Today);
        }

        /// <summary>
        /// This function helps to reinitialize the values as in the begining
        /// </summary>
        public void reset()
        {
            taskDetails.Name = " ";
            taskDetails.Description = " ";
            taskDetails.start_date = DateOnly.FromDateTime(DateTime.Today);
            taskDetails.end_date = DateOnly.FromDateTime(DateTime.Today);
            taskDetails.Priority = "Choose Priority";
        }

        /// <summary>
        /// On Valid submit this function gets trigerred and call the other method to create a Task by passing some of the parameters
        /// </summary>
        /// <returns></returns>
        public async Task Submit()
        {
            string? Id_string = Index.Tasklist_Id_string;
            long TL_Mile_ID = Convert.ToInt64(Id_string);
            string? TaskName = taskDetails.Name;
            string? Description = taskDetails.Description;
            DateOnly SDate = taskDetails.start_date;
            DateOnly EDate = taskDetails.end_date;
            string? StartDate = UserAuthenticationHelper.MM_DD_YYYY_format(SDate);
            string? EndDate = UserAuthenticationHelper.MM_DD_YYYY_format(EDate);
            string? Priority = taskDetails.Priority;
            string? url1 = NavMenu.Task_url;
            string UrlParameters = $"?tasklist_id={TL_Mile_ID}&name={TaskName}&start_date={StartDate}&end_date={EndDate}&priority={Priority}&description={Description}";
            module = await js.InvokeAsync<IJSObjectReference>("import", "./JS/AlertMessage.js");
            RegenerateAcc_Token.MT_MileTasklist(url1, RegenerateAcc_Token.Access_Token, _Post, UrlParameters);
            if (RegenerateAcc_Token.Ststuscode == "Created")
            {
                await module.InvokeVoidAsync("displayAlert", "Task is Created");
            }
            else if (RegenerateAcc_Token.Ststuscode == "BadRequest")
            {
                await module.InvokeVoidAsync("displayAlert", "Input Parameter Does not Match the Pattern Specified");
            }
            else
            {
                await module.InvokeVoidAsync("displayAlert", "Task is not Created");
            }
            await module.InvokeVoidAsync("CloseWindow");
        }

        /// <summary>
        /// Required properties for Creating Tasks
        /// </summary>
        class TaskDetails
        {
            [Required(ErrorMessage = "Task Name is required")]
            public string? Name { get; set; }

            //[Required(ErrorMessage = "This flag field is required")]
            public string? Description { get; set; }

            [Required(ErrorMessage = "Start Date is required")]
            public DateOnly start_date { get; set; }

            [Required(ErrorMessage = "End Date is required")]
            public DateOnly end_date { get; set; }

            [Required(ErrorMessage = "Priority field is required")]
            public string? Priority { get; set; }
        }
    }
}