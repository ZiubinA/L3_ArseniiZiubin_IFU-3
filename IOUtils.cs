using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace L3_ArseniiZiubin_IFU_3
{
    static class IOUtils
    {
        /// <summary> 
        /// Reads initial data from folder 
        /// </summary> 
        /// <param name="folderPath">Path to selected folder</param> 
        /// <returns>Associative container (dictionary) of electronic devices 
        /// Key: Owner name 
        /// Value:data of electronic devices </returns> 
        public static Dictionary<string, MyLinkedList> Read(string folderPath)
        {
            // Associative container to store initial data 
            Dictionary<string, MyLinkedList> Data =
                         new Dictionary<string, MyLinkedList>();
            // Get Path for selected directory 
            DirectoryInfo selectedFolder = new DirectoryInfo(folderPath);
            // Scan files in selected folder 
            foreach (FileInfo file in selectedFolder.GetFiles())
            {
                // Returns file path as a string 
                string fileName = file.ToString();
                string fullName = file.FullName;
                // Check for .txt files 
                // Extract extension for file 
                string extension = fileName.Substring(fileName.IndexOf("."));
                extension = extension.ToLower();
                if (extension.Equals(".txt"))
                {
                    // Avoid program crash if selected folder is inappropriate 
                    try
                    {
                        // Process each text file 
                        using (StreamReader reader = new StreamReader(fullName))
                        {
                            // Extract header fields 
                            string[] OwnerHeader = reader.ReadLine().Split(';');
                            string ownerName = OwnerHeader[0];
                            string mLine;
                            MyLinkedList PostCard = new MyLinkedList();
                            while ((mLine = reader.ReadLine()) != null)
                            {
                                string[] parts = mLine.Split(';');
                                string name = parts[0].Trim();
                                string country = parts[1].Trim();
                                int year = Convert.ToInt32(parts[2]);
                                string type = parts[3].Trim();
                                int height = Convert.ToInt32(parts[4]);
                                int width = Convert.ToInt32(parts[5]);
                                int quantity = Convert.ToInt32(parts[6]);
                                PostCard PC =
                                     new PostCard(name, country, year, type, height, width, quantity);
                                // Avoid  duplicates 
                                if (!PostCard.Contains(PC))
                                    // ElectronicDevices.AddToFront(PC);  
                                    PostCard.AddToEnd(PC);
                            }
                            // Add read contents to dictionary 
                            // Key: name of owner 
                            // Value: data of electronic devices 
                            // Avoid possible key duplicates 
                            if (!Data.ContainsKey(ownerName))
                            {
                                Data.Add(ownerName, PostCard);
                            }
                        }
                    }
                    catch (Exception)
                    {
                        throw;    // Rethrow exception (handled in method call) 
                    }
                }
            }
            return Data;
        }

        /// <summary> 
        /// Read data of electronic devices for insertion 
        /// </summary> 
        /// <param name="Path">Path to selected data file</param> 
        /// <returns>Linked list of electronic devices</returns> 
        public static MyLinkedList ReadForInsertion(string Path)
        {
            MyLinkedList Insertion = new MyLinkedList();
            using (StreamReader reader = new StreamReader(Path))
            {
                string mLine;
                while ((mLine = reader.ReadLine()) != null)
                {
                    string[] parts = mLine.Split(';');
                    string model = parts[0].Trim();
                    string type = parts[1].Trim();
                    int batteryLife = Convert.ToInt32(parts[2]);
                    PostCard PC = new PostCard(model, type, batteryLife);
                    // Avoid  duplicates 
                    if (!Insertion.Contains(PC))
                        // ElectronicDevices.AddToFront(ED);  
                        Insertion.AddToEnd(PC);
                }
            }
            return Insertion;
        }
    }
}
