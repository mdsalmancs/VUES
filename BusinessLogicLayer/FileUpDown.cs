using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer
{
    public class FileUpDown
    {
        string fileName;
        string sourcePath;
        string targetPath;

        string sourceFile;
        string destFile;

        public FileUpDown()
        {
        }

        public FileUpDown(string f, string s, string t)
        {
            fileName = f;
            sourcePath = s;
            targetPath = t;

            sourceFile = System.IO.Path.Combine(sourcePath, fileName);
            destFile = System.IO.Path.Combine(targetPath, fileName);
        }

        public void Transfer()
        {

            if (!System.IO.Directory.Exists(targetPath))
            {
                System.IO.Directory.CreateDirectory(targetPath);
            }

            System.IO.File.Copy(sourceFile, destFile, true);

            if (System.IO.Directory.Exists(sourcePath))
            {
                string[] files = System.IO.Directory.GetFiles(sourcePath);

                foreach (string s in files)
                {
                    fileName = System.IO.Path.GetFileName(s);
                    destFile = System.IO.Path.Combine(targetPath, fileName);
                    System.IO.File.Copy(s, destFile, true);
                }
            }
            else
            {

            }
        }
    }
}

