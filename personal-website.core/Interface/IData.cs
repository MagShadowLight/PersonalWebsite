using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace personal_website.core.Interface
{
    public interface IData
    {
        public void BlogFileWriter (string path, string blogs);
        public void PortfolioFileWriter (string path, string portfolioItems);

        public void FileReader (string path);
    }
}
