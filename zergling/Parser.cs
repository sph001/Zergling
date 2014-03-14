using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;
using System.Threading.Tasks;

namespace zergling
{
    class Parser
    {
        //-----------ParseDirect---------------//
        //usage: ParseDirect designates which  //
        //syntax it will be parsing.           //
        //string s = unparsed line             //
        //int i = which miner is being used    //
        // 1 = CGminer; 2=Cudaminer; 3=CPUminer//
        //-------------------------------------//
        public static void ParseDirect(string s, int i)
        {
            //Debug.WriteLine("in ParseDirect");
            if (i == 1)
            {
                ParseCG(s);
            }
            if (i == 2)
            {
                ParseCuda(s);
            }
            if (i == 3)
            {
                ParseCPU(s);
            }
        }
        #region syntax specific parsing functions (ParseCuda, ParseCG, ParseCPU)

        public static string ParseCuda (string s)
        {
            //Debug.WriteLine("in ParseCuda");
            string FinalString = "";
            List<string> split1 = new List<string>(s.Split(new string[] { "] "}, StringSplitOptions.None));
            if (split1.Count >= 1)
            {
                if (split1[1].Contains("GPU"))
                {
                    List<string> split2 = new List<string>(split1[1].Split(new string[] { " #", ": ", ", ", " khash/s" }, StringSplitOptions.None));                 
                    if(split2[1].Contains("0") && split2.Count >=5)
                    {
                        worker.GPU1HashRate = split2[3];
                    }
                    if (split2[1].Contains("1") && split2.Count >= 5)
                    {
                        worker.GPU2HashRate = split2[3];
                    }
                    if (split2[1].Contains("2") && split2.Count >= 5)
                    {
                        worker.GPU3HashRate = split2[3];
                    }
                    if (split2[1].Contains("3") && split2.Count >= 5)
                    {
                        worker.GPU4HashRate = split2[3];
                    }
                    if (split2[1].Contains("4") && split2.Count >= 5)
                    {
                        worker.GPU5HashRate = split2[3];
                    }
                    if (split2[1].Contains("5") && split2.Count >= 5)
                    {
                        worker.GPU6HashRate = split2[3];
                    }                   
                }
                if (split1[1].Contains("accepted:"))
                {
                    List<string> split2 = new List<string>(split1[1].Split(new string[] { ": ", " < ", " ("}, StringSplitOptions.None));
                    if ( split2.Count >= 2)
                    {
                        worker.Shares = split2[1];
                    }    
                }
            }
            return FinalString;
        }
        public static string ParseCG(string s)
        {
            string FinalString = "";
            List<string> split1 = new List<string>(s.Split(new string[] { "] " }, StringSplitOptions.None));
            if (split1.Count >= 2)
            {
                if (!split1[1].Contains("Init GPU"))
                {
                    List<string> split2 = new List<string>(split1[1].Split(new string[] { " | ", "(avg):" }, StringSplitOptions.None));
                    if (split2.Count >= 3)
                    {
                        List<string> split3 = new List<string>(split2[0].Split(new string[] { "  " }, StringSplitOptions.None));
                        if (Convert.ToBoolean(split3[0].Contains("GPU0")))
                        {
                            if (split2.Count >= 3)
                            {
                                List<string> split4 = new List<string>(split2[2].Split(new string[] { "M" }, StringSplitOptions.None));
                                if (split4.Count >=2)
                                {
                                    worker.GPU1HashRate = split4[0];
                                }
                                else
                                {
                                    List<string> split5 = new List<string>(split2[2].Split(new string[] { "k" }, StringSplitOptions.None));
                                    if (split2[1].IndexOf("K") == 5)
                                    {
                                        worker.GPU1HashRate = split5[0];
                                    }
                                }            
                            }
                        }
                        if (Convert.ToBoolean(split2[1].Contains("GPU1")))
                        {
                            if (split2.Count >= 3)
                            {
                                List<string> split4 = new List<string>(split2[2].Split(new string[] { "M" }, StringSplitOptions.None));
                                if (split4.Count >= 2)
                                {
                                    worker.GPU1HashRate = split4[0];
                                }
                                else
                                {
                                    List<string> split5 = new List<string>(split2[2].Split(new string[] { "k" }, StringSplitOptions.None));
                                    if (split2[1].IndexOf("K") == 5)
                                    {
                                        worker.GPU1HashRate = split5[0];
                                    }
                                }
                            }
                        }
                        if (Convert.ToBoolean(split2[1].Contains("GPU2")))
                        {
                            if (split2.Count >= 3)
                            {
                                List<string> split4 = new List<string>(split2[2].Split(new string[] { "M" }, StringSplitOptions.None));
                                if (split4.Count >= 2)
                                {
                                    worker.GPU1HashRate = split4[0];
                                }
                                else
                                {
                                    List<string> split5 = new List<string>(split2[2].Split(new string[] { "k" }, StringSplitOptions.None));
                                    if (split2[1].IndexOf("K") == 5)
                                    {
                                        worker.GPU1HashRate = split5[0];
                                    }
                                }
                            }
                        }
                        if (Convert.ToBoolean(split2[1].Contains("GPU3")))
                        {
                            if (split2.Count >= 3)
                            {
                                List<string> split4 = new List<string>(split2[2].Split(new string[] { "M" }, StringSplitOptions.None));
                                if (split4.Count >= 2)
                                {
                                    worker.GPU1HashRate = split4[0];
                                }
                                else
                                {
                                    List<string> split5 = new List<string>(split2[2].Split(new string[] { "k" }, StringSplitOptions.None));
                                    if (split2[1].IndexOf("K") == 5)
                                    {
                                        worker.GPU1HashRate = split5[0];
                                    }
                                }
                            }
                        }
                        if (Convert.ToBoolean(split2[1].Contains("GPU4")))
                        {
                            if (split2.Count >= 3)
                            {
                                List<string> split4 = new List<string>(split2[2].Split(new string[] { "M" }, StringSplitOptions.None));
                                if (split4.Count >= 2)
                                {
                                    worker.GPU1HashRate = split4[0];
                                }
                                else
                                {
                                    List<string> split5 = new List<string>(split2[2].Split(new string[] { "k" }, StringSplitOptions.None));
                                    if (split2[1].IndexOf("K") == 5)
                                    {
                                        worker.GPU1HashRate = split5[0];
                                    }
                                }
                            }
                        }
                        if (Convert.ToBoolean(split2[1].Contains("GPU5")))
                        {
                            if (split2.Count >= 3)
                            {
                                List<string> split4 = new List<string>(split2[2].Split(new string[] { "M" }, StringSplitOptions.None));
                                if (split4.Count >= 2)
                                {
                                    worker.GPU1HashRate = split4[0];
                                }
                                else
                                {
                                    List<string> split5 = new List<string>(split2[2].Split(new string[] { "k" }, StringSplitOptions.None));
                                    if (split2[1].IndexOf("K") == 5)
                                    {
                                        worker.GPU1HashRate = split5[0];
                                    }
                                }
                            }
                        }
                    }
                }
                if (split1[1].Contains("accepted:"))
                {
                    List<string> split2 = new List<string>(split1[1].Split(new string[] { ": ", " < ", " (" }, StringSplitOptions.None));
                    if (split2.Count >= 2)
                    {
                        worker.Shares = split2[1];
                    }
                }
            }
            return FinalString;
        }
        public static string ParseCPU(string s)
        {
            string FinalString = "";

            return FinalString;
        }
        #endregion
        #region cudaminer parsing functions (ParseCudaGPU, ParseCudeAccepted, ParseCudaStratum)
        private static string ParseCudaGPU (string s)
        {
            string FinalString = "";

            return FinalString;
        }
        private static string ParseCudaAccepted (string s)
        {
            string FinalString = "";

            return FinalString;
        }
        private static string ParseCudaStratum (string s)
        {
            string FinalString = "";

            return FinalString;
        }
        #endregion
        //------------CheckString-----------//
        //Checks a split string for a value //
        //true = value there; false no value//
    }
}
