using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Windows;
using System.Windows.Forms;

namespace DirectoryComparer
{
    /// <summary>
    /// Interaktionslogik für Window1.xaml
    /// </summary>
    public partial class MainWindow
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void btnOpenOldDir_Click(object sender, RoutedEventArgs e)
        {
            var dlg = new FolderBrowserDialog
                          {
                              Description = "Wählen Sie den Ordner, in dem sich die alte Version befindet.",
                              ShowNewFolderButton = false
                          };
            if (dlg.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                tbxDirOld.Text = dlg.SelectedPath;
            }
        }

        private void btnOpenNewDir_Click(object sender, RoutedEventArgs e)
        {
            var dlg = new FolderBrowserDialog
            {
                Description = "Wählen Sie den Ordner, in dem sich die neue Version befindet.",
                ShowNewFolderButton = false
            };
            if (dlg.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                tbxDirNew.Text = dlg.SelectedPath;
            }
        }

        private void btnCompare_Click(object sender, RoutedEventArgs e)
        {
            if (Directory.Exists(tbxDirOld.Text) && Directory.Exists(tbxDirNew.Text))
            {
                lbxDifferences.Items.Clear();

                var filesOld = new Dictionary<string, FileInfo>();
                foreach (var file in Directory.GetFiles(tbxDirOld.Text, "*.*", SearchOption.AllDirectories))
                {
                    filesOld.Add(RelativePath(file, tbxDirOld.Text), new FileInfo(file));
                }

                var filesNew = new Dictionary<string, FileInfo>();
                foreach (var file in Directory.GetFiles(tbxDirNew.Text, "*.*", SearchOption.AllDirectories))
                {
                    filesNew.Add(RelativePath(file, tbxDirNew.Text), new FileInfo(file));
                }

                var filesDifference = new List<FileDifference>();
                foreach (var file in filesNew)
                {
                    if (!filesOld.ContainsKey(file.Key))
                    {
                        filesDifference.Add(new FileDifference { Action = FileDifference.ActionType.Added, File = file.Value });
                    }
                }

                foreach (var file in filesOld)
                {
                    if (!filesNew.ContainsKey(file.Key))
                    {
                        filesDifference.Add(new FileDifference { Action = FileDifference.ActionType.Deleted, File = file.Value });
                    }
                }

                foreach (var file in filesDifference)
                {
                    if (filesOld.ContainsKey(RelativePath(file.File.FullName, tbxDirOld.Text)))
                    {
                        filesOld.Remove(RelativePath(file.File.FullName, tbxDirOld.Text));
                    }

                    if (filesNew.ContainsKey(RelativePath(file.File.FullName, tbxDirNew.Text)))
                    {
                        filesNew.Remove(RelativePath(file.File.FullName, tbxDirNew.Text));
                    }
                }

                if (filesOld.Count == filesNew.Count)
                {
                    var newFiles = new FileInfo[filesNew.Count];
                    filesNew.Values.CopyTo(newFiles, 0);

                    var oldFiles = new FileInfo[filesOld.Count];
                    filesOld.Values.CopyTo(oldFiles, 0);

                    for (int i = 0; i < filesOld.Count; i++)
                    {
                        if ((newFiles[i].Length != oldFiles[i].Length) || 
                            (newFiles[i].LastWriteTime != oldFiles[i].LastWriteTime))// || 
                            //(newFiles[i].Attributes != oldFiles[i].Attributes) || 
                            //(newFiles[i].CreationTime != oldFiles[i].CreationTime))
                        {
                            filesDifference.Add(new FileDifference{Action = FileDifference.ActionType.Modified,File = new FileInfo(newFiles[i].FullName)});
                        }
                    }
                }

                foreach (var fileDifference in filesDifference)
                {
                    lbxDifferences.Items.Add(string.Format("[{0}]: {1}", fileDifference.Action,
                                                           fileDifference.File.FullName));
                }
            }
        }

        private static string RelativePath(string absolutePath, string relativeTo)
        {
            string[] absoluteDirectories = absolutePath.Split('\\');
            string[] relativeDirectories = relativeTo.Split('\\');

            //Get the shortest of the two paths
            int length = absoluteDirectories.Length < relativeDirectories.Length ? absoluteDirectories.Length : relativeDirectories.Length;

            //Use to determine where in the loop we exited
            int lastCommonRoot = -1;
            int index;

            //Find common root
            for (index = 0; index < length; index++)
                if (absoluteDirectories[index] == relativeDirectories[index])
                    lastCommonRoot = index;
                else
                    break;

            //If we didn't find a common prefix then throw
            if (lastCommonRoot == -1)
                throw new ArgumentException("Paths do not have a common base");

            //Build up the relative path
            var relativePath = new StringBuilder();

            //Add on the ..
            for (index = lastCommonRoot + 1; index < absoluteDirectories.Length; index++)
                if (absoluteDirectories[index].Length > 0)
                    //relativePath.Append("..\\");
                    relativePath.Append(absoluteDirectories[index] + "\\");

            //Add on the folders
            //for (index = lastCommonRoot + 1; index < relativeDirectories.Length - 1; index++)
            //    relativePath.Append(relativeDirectories[index] + "\\");
            //relativePath.Append(relativeDirectories[relativeDirectories.Length - 1]);

            return relativePath.ToString();
        }
    }

    public struct FileDifference
    {
        public enum ActionType
        {
            Added,
            Deleted,
            Modified
        }

        public ActionType Action { get; set; }
        public FileInfo File { get; set; }
    }
}
