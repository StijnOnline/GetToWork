using System;
using System.Linq;
using System.Text.RegularExpressions;

public class StringCompare{

    public const string MATCH_CLONE_TEXT = @"(\s*\([cC]lone\))";
    public const string MATCH_NUMBER_TEXT = @"(\s*\(+\d+\)+)|(\s*\d+\s)|(\s*_\d+)";

    public static bool SimpleComparison(string a, string b) {        
        return ReduceName(a) == ReduceName(b);
    }

	public static string FindStem(String[] arr, bool CaseSensitive = false) {
        int n = arr.Length;

        String s = arr[0].ToLower();
        int len = s.Length;

        String res = "";

        for(int i = 0; i < len; i++) {
            for(int j = i + 1; j <= len; j++) {

                String stem = s.Substring(i, j - i);
                int k = 1;
                for(k = 1; k < n; k++) {
                    if(!arr[k].ToLower().Contains(stem))
                        break;
                }
                if(k == n && res.Length < stem.Length)
                    res = stem;
            }
        }

        return res;
    }

    public static string[] Group(String[] arr, bool CaseSensitive = false) {
        return null;
    }
    private static string ReplaceStuff(string input,string[] Matches) {        
        return Regex.Replace(input, string.Join("|",Matches), "");
    }

    public static string ReduceName(string input) {
        string[] match = { MATCH_CLONE_TEXT, MATCH_NUMBER_TEXT };
        return ReplaceStuff(input, match);
    }
}