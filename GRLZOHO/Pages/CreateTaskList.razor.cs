namespace GRLZOHO.Pages
{
    public partial class CreateTaskList
    {
        #region Properties
        private TasklistDetails taskListName = new TasklistDetails();
        IJSObjectReference module;
        [Inject] IJSRuntime js { get; set; }
        #endregion

        /// <summary>
        /// This function helps to reinitialize the values as in the begining
        /// </summary>
        public void reset()
        {
            taskListName.Name = " ";
            taskListName.flag = "Choose flag";
        }

        /// <summary>
        /// On Valid submit this function gets trigerred and call the other method to create a tasklist by passing some of the parameters
        /// </summary>
        /// <returns></returns>
        public async Task Submit()
        {
            string TL_Mile_ID = Index.Mile_Id;
            string TaskListName = taskListName.Name;
            string flag = taskListName.flag;
            string url1 = NavMenu.TaskList_url;
            module = await js.InvokeAsync<IJSObjectReference>("import", "./JS/AlertMessage.js");

            if (url1 == null)
            {
                await module.InvokeVoidAsync("displayAlert", "Select the Milestone");
            }
            else
            {
                string UrlParameters = $"?milestone_id={TL_Mile_ID}&name={TaskListName}&flag={flag}";
                RegenerateAcc_Token.MT_MileTasklist(url1, RegenerateAcc_Token.Access_Token, _Post, UrlParameters);
                if (RegenerateAcc_Token.Ststuscode == "Created")
                {
                    await module.InvokeVoidAsync("displayAlert", "Your TaskList is Created");
                }
                else if (RegenerateAcc_Token.Ststuscode == "BadRequest")
                {
                    await module.InvokeVoidAsync("displayAlert", "Input Parameter Does not Match the Pattern Specified");
                }
                else if (RegenerateAcc_Token.Ststuscode == "NotImplemented")
                {
                    await module.InvokeVoidAsync("displayAlert", "You cannot associate an external tasklist to a milestone that is flagged internal , ViceVersa. Try associating only internal tasklists.");
                }
                else
                {
                    await module.InvokeVoidAsync("displayAlert", "Your TaskList is not Created");
                }
            }
            await module.InvokeVoidAsync("CloseWindow");
        }

        /// <summary>
        /// Required Properties for Creating Tasklist
        /// </summary>
        class TasklistDetails
        {
            [Required(ErrorMessage = "TaskList Name is required")]
            public string Name { get; set; }

            [Required(ErrorMessage = "Flag field is required")]
            public string flag { get; set; }
        }
    }
}