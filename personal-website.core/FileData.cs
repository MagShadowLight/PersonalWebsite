using personal_website.core.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace personal_website.core
{
    public class FileData : IData
    {
        public void BlogFileWriter(string path, string blogs)
        {
            //Console.WriteLine("blog adding to file");
            //if (!File.Exists(path))
            //{
            //    Directory.CreateDirectory("Data");
            //    File.Create("Blogs.txt");
            //}
            //using (StreamWriter writer = new StreamWriter(path, true))
            //{
            //    writer.WriteLine(blogs);
            //}
            //Console.WriteLine("blog added");
        }

        public void FileReader(string path)
        {
            //throw new NotImplementedException();
        }

       

        public void PortfolioFileWriter(string path, string portfolioItems)
        {
            //throw new NotImplementedException();
        }
    }
}
