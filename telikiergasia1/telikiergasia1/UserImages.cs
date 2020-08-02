using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace telikiergasia1
{
    class UserImages
    {
        public String DirPath { get; set; }
        public String ImageName { get; set; }
        public bool IsImage { get; set; }

        public UserImages addDirPath(String DirPath)
        {
            this.DirPath = DirPath;
            return this;
        }
        public UserImages AddImageName(String ImageName)
        {
            this.ImageName = ImageName;
            return this;
        }
        public UserImages AddIsImage(bool IsImage)
        {
            this.IsImage = IsImage;
            return this;
        }
    }
}
