using Grl.TokenGeneration;

namespace GRLZOHO.Shared
{
    public partial class HorizontalNavMenu
    {
        public void St_Pt_Url(string url)
        {
            RegenerateAcc_Token.Operations_View(url, RegenerateAcc_Token.Access_Token, _Get);
        }

        /// <summary>
        /// Function to invoke selected Milestone
        /// </summary>
        /// <param name="url">Url for the selected Milestone</param>
        //public void St_Pt_Url_Mile(string url)
        //{
        //    string? File_Mile = GRLZOHO.Pages.Index.File_Path_Mile;
        //    string? File_Mile1 = GRLZOHO.Pages.Index.File_Path_Mile1;
        //    RegenerateAcc_Token.Operations_View(url, RegenerateAcc_Token.access_token, EnumClass.METHOD.GET.ToString());
        //    try
        //    {
        //        System.IO.File.WriteAllText(File_Mile, RegenerateAcc_Token.QueryResponse_Json);
        //    }
        //    catch
        //    {
        //        System.IO.File.WriteAllText(File_Mile1, RegenerateAcc_Token.QueryResponse_Json);
        //    }
        //}
        //public void St_Pt_Url_TaskList(string url)
        //{
        //    string? File_TaskList = GRLZOHO.Pages.Index.File_Path_TaskList;
        //    string? File_TaskList1 = GRLZOHO.Pages.Index.File_Path_TaskList1;
        //    RegenerateAcc_Token.Operations_View(url, RegenerateAcc_Token.access_token, EnumClass.METHOD.GET.ToString());
        //    try
        //    {
        //        System.IO.File.WriteAllText(File_TaskList, RegenerateAcc_Token.QueryResponse_Json);
        //    }
        //    catch
        //    {
        //        System.IO.File.WriteAllText(File_TaskList1, RegenerateAcc_Token.QueryResponse_Json);
        //    }
        //}

        /// <summary>
        /// Function to invoke selected task
        /// </summary>
        /// <param name="url">url for the selected task</param>
        //public void St_Pt_Url_Task(string url)
        //{
        //    string? File_Task = GRLZOHO.Pages.Index.File_Path_Task;
        //    string? File_Task1 = GRLZOHO.Pages.Index.File_Path_Task1;
        //    RegenerateAcc_Token.Operations_View(url, RegenerateAcc_Token.access_token, _Get);
        //    try
        //    {
        //        System.IO.File.WriteAllText(File_Task, RegenerateAcc_Token.QueryResponse_Json);
        //    }
        //    catch
        //    {
        //        System.IO.File.WriteAllText(File_Task1, RegenerateAcc_Token.QueryResponse_Json);
        //    }
        //}
    }
}
