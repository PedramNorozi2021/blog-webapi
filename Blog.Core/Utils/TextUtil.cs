
using System.Text.RegularExpressions;

namespace Blog.Core.Utils;
public  class TextUtil
{
    public static bool IsValidSlug(string slug)
    {
        return Regex.IsMatch(slug, @"^[a-zA-Z\-]+$");
    }
}
