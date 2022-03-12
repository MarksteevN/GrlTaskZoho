namespace GRLZOHO.Data
{
    public class Filepath
    {
        //UserAuthenticationHelper _UserAuth = new UserAuthenticationHelper();

        /// <summary>
        /// This function reads the present directory with some input parameters
        /// </summary>
        /// <returns>"D:\\Marksteev_GRL\\Github_Files\\GRLZOHO\\GRLZOHO\\Appdata\\Projects"</returns>
        public string AllFilePath()
        {
            string GetDirectory = Directory.GetCurrentDirectory();
            string CompleteFolderName = Path.Combine(GetDirectory, AppData, Projects);
            return CompleteFolderName;
        }

        /// <summary>
        /// This function helps to locate the present directory along with the generated txt file
        /// </summary>
        /// <returns>Returns the filepath</returns>
        public string PD_Folder()
        {
            string CP_Details = UserAuthenticationHelper.GenerateTextFile(Complete_ProjectDetails, _Null);
            string CompleteFolderName = AllFilePath();
            string CProject_Details = Path.Combine(CompleteFolderName, CP_Details);
            return CProject_Details;
        }

        /// <summary>
        /// Creates a Filepath by adding two input string
        /// </summary>
        /// <param name="P_Name">Filepath1 acts as a input</param>
        /// <param name="NullVariable">Filepath2 acts as a second input, Second input checks for the null value, if the value is not null it appends the second input to the first input</param>
        /// <returns>Returns a filepath by adding the projects folder along with input1 and input2</returns>
        public string ProjectNameFilepath(string P_Name, string NullVariable)
        {
            string NullCheck = UserAuthenticationHelper.CheckNullValue(NullVariable);
            string CompleteFolderName = AllFilePath();
            string ProjectName = Path.Combine(CompleteFolderName, P_Name, NullCheck);
            return ProjectName;
        }

        /// <summary>
        /// This function accepts four input values to form the path to the locate the expected file
        /// </summary>
        /// <param name="Filepath">Parameter 1</param>
        /// <param name="Name">Parameter 2</param>
        /// <param name="NullVariable1">Parameter 3 ( Checks for Null value )</param>
        /// <param name="NullVariable2">Parameter 4 ( Checks for Null value )</param>
        /// <returns>Returns the filepath expected</returns>
        public string Filepath_Operations(string Filepath, string Name, string NullVariable1, string NullVariable2)
        {
            string CheckNull1 = UserAuthenticationHelper.CheckNullValue(NullVariable1);
            string CheckNull2 = UserAuthenticationHelper.CheckNullValue(NullVariable2);
            string ProjectName = Path.Combine(Filepath, Name, CheckNull1, CheckNull2);
            return ProjectName;
        }

        /// <summary>
        /// This function is used to combine 3 inputs file path to a sing filepath
        /// </summary>
        /// <param name="Path1">Parameter 1</param>
        /// <param name="Path2">Parameter 2</param>
        /// <param name="Path3">Parameter 3 ( Checks for Null value )</param>
        /// <returns></returns>
        public string Combine_Filepath(string Path1, string Path2, string Path3)
        {
            string CheckNull = UserAuthenticationHelper.CheckNullValue(Path3);
            string FilepathCombined = Path.Combine(Path1, Path2, CheckNull);
            return FilepathCombined;
        }

        /// <summary>
        /// This function is invoked only when the catch is called
        /// </summary>
        /// <param name="Filepath">Filepath as parameter 1</param>
        /// <param name="TLMIDT_Folder">Folders name i.e., Tasklsit folder, task folder, issue folder, etc... as parameter 2</param>
        /// <param name="Txt_File">Name of the txt file as parameter 3</param>
        /// <param name="Url">The required url for the data to generate as parameter 4</param>
        /// <returns></returns>
        public string SelectedCatchPart(string Filepath, string TLMIDT_Folder, string Txt_File, string Url)
        {
            string DefaultFolder = Filepath_Operations(Filepath, D_Folder, TLMIDT_Folder, _Null);
            UserAuthenticationHelper.CreateDirectoryFolder(DefaultFolder);
            string DefaultFile = UserAuthenticationHelper.GenerateTextFile(Txt_File, _Null);
            string DefaultFilepath = Filepath_Operations(Filepath, D_Folder, TLMIDT_Folder, DefaultFile);
            UserAuthenticationHelper.PrintDataToFile(DefaultFilepath, Url, _Get, _Null, false);
            return DefaultFilepath;
        }
    }
    public static class IJSRuntimeExtensionMethods
    {
        //static IJSObjectReference module;
        //public static async ValueTask<bool> Confirm(this IJSRuntime js, string message)
        //{
        //    //module = await js.InvokeAsync<IJSObjectReference>("import", "./JS/AlertMessage.js");
        //    return await InvokeVoidAsync("displayAlert", $"{message}");
        //}

    }
}