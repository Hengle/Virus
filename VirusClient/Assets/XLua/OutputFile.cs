using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class OutputFile {
    public void outputFile(string filePath, byte[] file)
    {
        if (File.Exists(filePath))
        {
            File.Delete(filePath);
        }
        FileStream fs = new FileStream(filePath, FileMode.CreateNew);
        fs.Seek(0, SeekOrigin.Begin);
        fs.Write(file, 0, file.Length);
        fs.Close();
    }
}
