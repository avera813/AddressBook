using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AddressBook
{
    class CheckFile
    {
        private string fileName;

        public CheckFile(string fileName)
        {
            this.fileName = fileName;
        }

        public FileStream GetReadFileStream()
        {
            FileStream fs = null;
            try
            {
                fs = File.OpenRead(fileName);
            }
            catch (DirectoryNotFoundException)
            {
                throw new DirectoryNotFoundException("Cannot find directory: " + fileName);
            }
            catch (FileNotFoundException)
            {
                throw new FileNotFoundException("Cannot find file: " + fileName);
            }
            catch (UnauthorizedAccessException)
            {
                throw new UnauthorizedAccessException("Read access denied to file: " + fileName);
            }
            return fs;
        }

        public FileStream GetWriteFileStream()
        {
            FileStream fs = null;
            try
            {
                fs = new FileStream(fileName, FileMode.OpenOrCreate);
            }
            catch (DirectoryNotFoundException)
            {
                Directory.CreateDirectory(fileName);
            }
            catch (UnauthorizedAccessException)
            {
                throw new UnauthorizedAccessException("Write access denied to file: " + fileName);
            }
            return fs;
        }
    }
}
