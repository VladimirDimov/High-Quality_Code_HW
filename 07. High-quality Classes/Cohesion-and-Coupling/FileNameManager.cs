namespace CohesionAndCoupling
{
    using System;

    public static class FileNameManager
    {
        public static string GetFileExtension(string fileName)
        {
            if (fileName == string.Empty)
            {
                throw new ArgumentException("Invalid empty file name");
            }

            int indexOfLastDot = fileName.LastIndexOf(".");

            if (indexOfLastDot == -1)
            {
                return string.Empty;
            }
            else
            {
                string extension = fileName.Substring(indexOfLastDot + 1);
                return extension;
            }
        }

        public static string GetFileNameWithoutExtension(string fileName)
        {
            int indexOfLastDot = fileName.LastIndexOf(".");

            if (indexOfLastDot == -1)
            {
                return fileName;
            }

            string fileNameWithoutExtension = fileName.Substring(0, indexOfLastDot);
            return fileNameWithoutExtension;
        }
    }
}
