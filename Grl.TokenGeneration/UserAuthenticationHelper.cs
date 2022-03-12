namespace Grl.TokenGeneration
{
    public class UserAuthenticationHelper
    {
        /// <summary>
        /// Sleep function for delay
        /// </summary>
        /// <param name="waitTimeMilli">Numbers in milliseconds</param>
        public static void Sleep(int waitTimeMilli)
        {
            if (waitTimeMilli <= 0)
                waitTimeMilli = 1;

            int i = 0;
            System.Timers.Timer delayTimer = new System.Timers.Timer(waitTimeMilli);
            delayTimer.AutoReset = false;
            delayTimer.Elapsed += (s, args) => i = 1;
            delayTimer.Start();
            while (i == 0) { };
        }

        /// <summary>
        /// Function to remove Escape Sequence and Regex Symbols
        /// </summary>
        /// <param name="KeywordToRemoveRegexSymbol">Name or a keyboard which needs to remove escape sequence</param>
        /// <returns>Returns the only string without escape sequence and regex symbol</returns>
        public static string RemoveRegex(string KeywordToRemoveRegexSymbol)
        {
            string name = KeywordToRemoveRegexSymbol;
            string RemoveEscapeSequence = Regex.Replace(name, @"\t|\n|\r|:", "");
            string RemoveForwardSlash = RemoveEscapeSequence.Replace(@"\", "");
            string RemoveBackwardSlash = RemoveForwardSlash.Replace(@"/", " ");
            string RemoveQuotesSlash = RemoveBackwardSlash.Replace("\"", "");
            string FinalName = RemoveQuotesSlash.TrimEnd();
            return FinalName;
        }

        /// <summary>
        /// Function to Extract the number of substrings in a string
        /// </summary>
        /// <param name="NameOfFolder">Name needs to be get extracted</param>
        /// <returns>Returns the Extracted Name</returns>
        public static string LengthOfFolder(string NameOfFolder)
        {
            string name = NameOfFolder;
            int length = name.Length;
            if (length >= 30)
            {
                string FolderNameSize = name.Substring(0, 29);
                string FolderName = FolderNameSize.TrimEnd();
                return FolderName;
            }
            else if (length <= 29)
            {
                string FolderNameSize = name;
                string FolderName = FolderNameSize.TrimEnd();
                return FolderName;
            }
            return string.Empty;
        }
        
        /// <summary>
        /// Function to call both Removeregex and length of folder in one call
        /// </summary>
        /// <param name="Name">Name or a keyword needs to be performed the steps of removeregex and length ofd folder metds Both</param>
        /// <returns>returns the name with removing characters</returns>
        public static string Name_Size_Folder(string Name)
        {
            string FolderName = RemoveRegex(Name);
            string FolderSize = LengthOfFolder(FolderName);
            return FolderSize;
        }
        
        /// <summary>
        /// to generate a txt file
        /// </summary>
        /// <param name="TextFileName">Txt file name as parameter</param>
        /// <param name="NullVariable">If extra name is needed input 2 can be used</param>
        /// <returns>Returns the txt file name along with the extension .txt with the filename added to it</returns>
        public static string GenerateTextFile(string TextFileName, string NullVariable)
        {
            string NullText = CheckNullValue(NullVariable);
            string textname = TextFileName;
            string FileName = textname + NullText;
            string TFileName = FileName + ".txt";
            return TFileName;
        }

        /// <summary>
        /// Function to change the date format as mm__dd_yyyy
        /// </summary>
        /// <param name="date">Date in other format</param>
        /// <returns>Returns the MM_DD_YYYY format with the input date</returns>
        public static string MM_DD_YYYY_format(DateOnly date)
        {
            string DateFormat = DateTime.ParseExact(date.ToString(), "dd/MM/yyyy", null).ToString("MM/dd/yyyy");
            return DateFormat;
        }

        /// <summary>
        /// This function used to generate data and print to the data to specified location
        /// </summary>
        /// <param name="Filepath">Filepath of the file where the upfdatewd data needs to be printed</param>
        /// <param name="Url">Url for the data to genereate as input 2</param>
        /// <param name="Method">Method can be GET or POST only</param>
        /// <param name="NullVariable">If there is a parameters need to be passed along with url then this variable can the parameters as a single string</param>
        /// <param name="TrueFalse">true or false if the file doesnt want to change the original data its accepts true or else false</param>
        /// <returns>Returns the filepath of the printed data</returns>
        public static string PrintDataToFile(string Filepath, string Url, string Method, string NullVariable, bool TrueFalse)
        {
            if(NullVariable == null)
            {
                if (TrueFalse == true)
                {
                    if (!File.Exists(Filepath))
                    {
                        RegenerateAcc_Token.Operations_View(Url, RegenerateAcc_Token.Access_Token, Method);
                        File.WriteAllText(Filepath, RegenerateAcc_Token.QueryResponse_Json);
                    }
                    return Filepath;
                }
                else
                {
                    RegenerateAcc_Token.Operations_View(Url, RegenerateAcc_Token.Access_Token, Method);
                    File.WriteAllText(Filepath, RegenerateAcc_Token.QueryResponse_Json);
                    return Filepath;
                }
            }
            else
            {
                string NullValue = CheckNullValue(NullVariable);
                if (TrueFalse == true)
                {
                    if (!File.Exists(Filepath))
                    {
                        RegenerateAcc_Token.MT_MileTasklist(Url, RegenerateAcc_Token.Access_Token, Method, NullValue);
                        File.WriteAllText(Filepath, RegenerateAcc_Token.QueryResponse_Json);
                    }
                    return Filepath;
                }
                else
                {
                    RegenerateAcc_Token.MT_MileTasklist(Url, RegenerateAcc_Token.Access_Token, Method, NullValue);
                    File.WriteAllText(Filepath, RegenerateAcc_Token.QueryResponse_Json);
                    return Filepath;
                }
            }
        }

        /// <summary>
        /// Function to create a directory
        /// </summary>
        /// <param name="Filepath">Filepath for the directory to be created</param>
        /// <returns>Returns the filepath</returns>
        public static string CreateDirectoryFolder(string Filepath)
        {
            if (!Directory.Exists(Filepath))
            {
                Directory.CreateDirectory(Filepath);
            }
            return Filepath;
        }

        /// <summary>
        /// Function to check for string if the null value is present or not
        /// </summary>
        /// <param name="str">String to check null</param>
        /// <returns>returns the string if there is no null present</returns>
        public static string CheckNullValue(string str)
        {
            string Name = str != null ? "" + str : "";
            return Name;
        }

        /// <summary>
        /// Function to clear the list data
        /// </summary>
        /// <param name="lists">No of lists wanted to clear the data present</param>
        public static void ClearAllList(params IList[] lists) => lists.ToList().ForEach(x => x.Clear());

    }
}