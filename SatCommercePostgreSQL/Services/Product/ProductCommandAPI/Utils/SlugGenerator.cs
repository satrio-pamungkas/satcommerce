using System.Text;
using System.Globalization;
using System.Text.RegularExpressions;

namespace ProductCommandAPI.Utils;

public static class SlugGenerator
{
    private static string Parse(string text)
    {
        if (string.IsNullOrWhiteSpace(text)) 
            return text;

        text = text.Normalize(NormalizationForm.FormD);
        char[] chars = text  
            .Where(c => CharUnicodeInfo.GetUnicodeCategory(c)   
                        != UnicodeCategory.NonSpacingMark).ToArray();  
  
        return new string(chars).Normalize(NormalizationForm.FormC);
    }

    public static string Slug(string name, Guid uuid)
    {
        string output = Parse(name).ToLower();  

        output = Regex.Replace(output, @"[^A-Za-z0-9\s-]", "");
        output = Regex.Replace(output, @"\s+", " ").Trim();
        output = Regex.Replace(output, @"\s", "-");
        output = output + "-" + uuid.ToString();
        
        return output;  
    }
}