

using Microsoft.AspNetCore.Http;

namespace Blog.Core.Utils;
public interface IFileManeger
{
    /// <summary>
    /// upload file and raturn name
    /// </summary>
    /// <param name="dir">directory path</param>
    /// <param name="file">file</param>
    /// <returns>file name</returns>
    string UploadFile(string dir, IFormFile file);
}

public class FileManeger : IFileManeger
{

    public string UploadFile(string dir, IFormFile file)
    {
        string fileName = Guid.NewGuid().ToString() + "_" + new Random().Next(100, 999) + ".jpg";
        string pathDir = Path.Combine(Directory.GetCurrentDirectory(), dir).Replace("/", "\\");
        if (!Directory.Exists(pathDir))
            Directory.CreateDirectory(pathDir);

        string fullPath = Path.Combine(pathDir, fileName);
        using (FileStream stream = new FileStream(fullPath, FileMode.Create))
        {
            file.CopyTo(stream);
        }
        return fileName;

        //1) create fileName
        //2) create path Directory
        //3) add file to path
        //4) return fileName from add to database
    }
}

