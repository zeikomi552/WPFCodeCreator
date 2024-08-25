using MVVMCore.Common.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPFCodeCreator.Models.Interface
{
    public interface IPropetyItemCollectionM
    {
        public string ClassName { get; set; }

        public bool ClassVisible { get; set; }

        public ModelList<PropertyM> PropertyItems { get; set; }

        public string SourceCode { get; }

        public string RefreshCode();

        public void Refresh();

        public void FileSave();

        public void FileLoad();

        public void LoadCS();

        public void ResetCheck();
    }
}
