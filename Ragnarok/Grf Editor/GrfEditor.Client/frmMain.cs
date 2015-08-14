using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Reflection;
using System.Windows.Forms;
using GodLesZ.Library;
using GodLesZ.Library.Controls;
using GodLesZ.Library.Ragnarok.Grf;
using GodLesZ.Library.Win7.Taskbar;
using GrfEditor.Client.Properties;
using GrfEditor.Library;
using GrfEditor.Library.Controls;
using Resources = GrfEditor.Library.Properties.Resources;

namespace GrfEditor.Client {

    public partial class FrmMain : Form, IPreviewPanelHost, IEditorPluginHost {
        private static string mDefaultTitle = "";

        private readonly BackgroundWorker mBackgroundLoading = new BackgroundWorker();
        private readonly BackgroundWorker mBackgroundSaving = new BackgroundWorker();
        private readonly RoGrfFile mGrfFile = new RoGrfFile();

        private readonly List<IEditorPlugin> mPlugins = new List<IEditorPlugin>();
        private readonly string[] mStartupArgs;

        private readonly TaskbarManager mWin7Taskbar;
        private string mGrfFilepath;
        private Timer mInfoTimer;
        private Image mOldStateImage;
        private string mOldStateMessage = "";
        private ResnameParser mResname = new ResnameParser();
        private RoGrfFileItem mSelectedGrfItem;


        public FrmMain(string[] args) {
            InitializeComponent();
            InitializeListView();

            // Win7 taskbar support
            mWin7Taskbar = TaskbarManager.Instance;

            // Window title
            mDefaultTitle = Text;

            // GRF instance settings
            mGrfFile.WriteBytesPerTurn = (1024 * 1024) * 20; // 20MB

            mBackgroundLoading.WorkerReportsProgress = true;
            mBackgroundLoading.WorkerSupportsCancellation = true;
            mBackgroundLoading.DoWork += BackgroundLoading_DoWork;
            mBackgroundLoading.ProgressChanged += BackgroundLoading_ProgressChanged;
            mBackgroundLoading.RunWorkerCompleted += BackgroundLoading_RunWorkerCompleted;

            mBackgroundSaving.WorkerReportsProgress = true;
            mBackgroundSaving.WorkerSupportsCancellation = true;
            mBackgroundSaving.DoWork += mBackgroundSaving_DoWork;
            mBackgroundSaving.ProgressChanged += mBackgroundSaving_ProgressChanged;
            mBackgroundSaving.RunWorkerCompleted += mBackgroundSaving_RunWorkerCompleted;

            mGrfFile.ItemAdded += mGrfFile_ItemAdded;
            mGrfFile.ItemWrite += mGrfFile_ItemWrite;
            mGrfFile.ProgressUpdate += mGrfFile_ProgressUpdate;

            SetGrfInfo();

            ReloadPlugins();

            // Save startup args
            if (args != null && args.Length >= 1 && File.Exists(args[0])) {
                mStartupArgs = args;
            }
        }


        #region IEditorPluginHost Members
        public void ReloadPlugins() {
            // Clear plugins
            SetInfoState("Clear plugins..", Resources.information);
            if (mPlugins != null && mPlugins.Count > 0) {
                int i = 0;
                foreach (IEditorPlugin p in mPlugins) {
                    p.UnloadPlugin();
                    mainMenuPlugins.DropDownItems.RemoveByKey("mainMenuPluginsPlugin" + (i + 1));
                    i++;
                }
                mPlugins.Clear();
            }

            // Load new
            SetInfoState("Load plugins..", Resources.information);
            string pluginPath = Application.StartupPath + "/Plugin/";
            if (Directory.Exists(pluginPath) == false) {
                Directory.CreateDirectory(pluginPath);
            }
            string[] assemblies = Directory.GetFiles(pluginPath, "GrfEditor.Plugins.Preview*.dll");
            foreach (string filepath in assemblies) {
                Assembly asm = null;
                Type[] asmTypes = null;
                try {
                    asm = Assembly.LoadFile(filepath);
                    asmTypes = asm.GetTypes();
                } catch (Exception ex) {
                    MessageBox.Show(string.Format("Failed to load plugin: {0}", Path.GetFileName(filepath)));
                    Debug.WriteLine(ex);
                }

                if (asm == null || asmTypes == null || asmTypes.Length == 0) {
                    continue;
                }

                foreach (var t in asmTypes) {
                    var interfaceType = t.GetInterface("IEditorPlugin");
                    if (interfaceType == null) {
                        continue;
                    }

                    ConstructorInfo ctorInfo = t.GetConstructor(Type.EmptyTypes);
                    if (ctorInfo == null) {
                        continue;
                    }

                    var p = (IEditorPlugin)ctorInfo.Invoke(new object[] { });
                    // Load plugin 
                    p.LoadPlugin(this);
                    // Build menu item
                    var item = new ToolStripMenuItem(p.GetPluginName(), Resources.component_green) {
                        Name = "mainMenuPluginsPlugin" + mPlugins.Count,
                        ToolTipText = p.GetPluginDescription()
                    };
                    // Give plugin a chance to manipulate menu item
                    p.LoadMenu(item);
                    // Add menu
                    mainMenuPlugins.DropDownItems.Insert(0, item);
                    // Finally add plugin to the list
                    mPlugins.Add(p);
                    // Inform client
                    //SetInfoState("Plugin loaded: " + p.GetPluginName(), Resources.check);
                }
            }

            SetInfoState("Grf editor ready", Resources.check);
            SetInfoStateTimed("Plugins loaded: " + mPlugins.Count, Resources.check);
        }
        #endregion

        #region IPreviewPanelHost Members
        public Panel GetPreviewHost() {
            return pnlPreview;
        }


        public void OnPreviewReady() {
            listView.Enabled = true;
            listView.Focus();
        }
        #endregion

        #region Background Loading
        private void BackgroundLoading_DoWork(object sender, DoWorkEventArgs e) {
            InvokeHelper.Invoke(lblStatusProgress, delegate {
                lblStatusProgress.Value = 0;
            });

            if (mGrfFile.Files.Count != 0) {
                mGrfFile.Dispose();
            }

            mGrfFile.ReadGrf(mGrfFilepath);

            LoadResnametable();

            FillListView();

            mBackgroundLoading.ReportProgress(100);
        }

        private void mGrfFile_ItemAdded(RoGrfFileItem item, int percent) {
            mBackgroundLoading.ReportProgress(percent, item);
        }

        private void BackgroundLoading_ProgressChanged(object sender, ProgressChangedEventArgs e) {
            lblStatusProgress.Value = Math.Min(100, e.ProgressPercentage);
            if (TaskbarManager.IsPlatformSupported) {
                mWin7Taskbar.SetProgressValue(lblStatusProgress.Value, 100);
            }
        }

        private void BackgroundLoading_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e) {
            if (TaskbarManager.IsPlatformSupported) {
                mWin7Taskbar.SetProgressValue(100, 100);
                mWin7Taskbar.SetProgressState(TaskbarProgressBarState.NoProgress);
            }

            SetGuiState(true);
            SetInfoState("GRF " + Path.GetFileName(mGrfFilepath) + " successfully opened (" + mGrfFile.Files.Count + " Files)", Resources.check);
            SetGrfInfo();
            lblStatusProgress.Value = 0;

            if (mResname == null && Settings.Default.EnableResnametableSearch) {
                if (Settings.Default.ErrorOnResnametable) {
                    MessageBox.Show("Failed to load id2resnametable.txt and idnum2itemdisplaynametable.txt!", "File not found", MessageBoxButtons.OK, MessageBoxIcon.Error);
                } else {
                    SetInfoStateTimed("Failed to load id2resnametable.txt and idnum2itemdisplaynametable.txt", Resources.delete);
                }
            }

            // Focus on filter
            txtFilterText.Focus();
            // If we have a previous filter, re-run it
            if (string.IsNullOrEmpty(txtFilterText.Text) == false) {
                btnFilter.PerformClick();
            }
        }
        #endregion

        #region Background Saving
        private void mBackgroundSaving_DoWork(object sender, DoWorkEventArgs e) {
            var filepath = (string)((object[])e.Argument)[0];
            var repack = (bool)((object[])e.Argument)[1];

            Stopwatch watch = Stopwatch.StartNew();
            mGrfFile.Save(filepath, repack);
            mGrfFile.Flush();
            string timeInfo = "File saving needed " + watch.ElapsedMilliseconds + "ms";
            Debug.WriteLine(timeInfo);
            SetInfoStateTimed(timeInfo, Resources.information);

            e.Result = filepath;
        }

        private void mGrfFile_ProgressUpdate(int progress) {
            mBackgroundSaving.ReportProgress(progress);
        }

        private void mGrfFile_ItemWrite(RoGrfFileItem item, int percent) {
            mBackgroundSaving.ReportProgress(percent, item);
        }

        private void mBackgroundSaving_ProgressChanged(object sender, ProgressChangedEventArgs e) {
            int p = Math.Min(100, e.ProgressPercentage);
            lblStatusProgress.Value = p;
            SetInfoState("Saving.. " + p + "%", Resources.information);

            if (TaskbarManager.IsPlatformSupported) {
                mWin7Taskbar.SetProgressValue(lblStatusProgress.Value, 100);
            }
        }

        private void mBackgroundSaving_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e) {
            var filepath = (string)e.Result;

            lblStatusProgress.Value = 0;
            if (TaskbarManager.IsPlatformSupported) {
                mWin7Taskbar.SetProgressValue(100, 100);
                mWin7Taskbar.SetProgressState(TaskbarProgressBarState.NoProgress);
            }

            // reopen as a new grf
            OpenGrf(filepath);
        }
        #endregion

        #region frmMain Events
        private void frmMain_Load(object sender, EventArgs e) {
            // Disable resnametable search

            // Controls are initialized now - hide them
            HidePreviewControls();
        }

        private void frmMain_Shown(object sender, EventArgs e) {
            // Load startup file
            if (mStartupArgs != null && mStartupArgs.Length >= 1 && File.Exists(mStartupArgs[0])) {
                SetInfoStateTimed("Open GRF from command line args: " + Path.GetFileName(mStartupArgs[0]), Resources.information);
                OpenGrf(mStartupArgs[0]);
            }
        }

        private void frmMain_FormClosing(object sender, FormClosingEventArgs e) {
            if (mBackgroundSaving.IsBusy) {
                string message = "Saving is not finished!\n\nAre you sure to close the Application and\ncancel the process?";
                if (MessageBox.Show(message, "Saving not finished", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes) {
                    return;
                }

                e.Cancel = true;
            }
        }

        private void frmMain_DragEnter(object sender, DragEventArgs e) {
            e.Effect = DragDropEffects.None;

            string[] filenames;
            if (e.Data.GetDataPresent("FileNameW") && (filenames = (string[])e.Data.GetData(DataFormats.FileDrop)).Length == 1) {
                if (Path.GetExtension(filenames[0]) == ".grf" || Path.GetExtension(filenames[0]) == ".gpf") {
                    e.Effect = DragDropEffects.Copy;
                }
            }
        }

        private void frmMain_DragDrop(object sender, DragEventArgs e) {
            var fileNames = (string[])e.Data.GetData(DataFormats.FileDrop);

            if (fileNames.Length == 1) {
                SetInfoStateTimed("Open GRF from drag & drop: " + Path.GetFileName(fileNames[0]), Resources.information);
                OpenGrf(fileNames[0]);
            }
        }
        #endregion

        #region MenuGrf Events
        private void mainMenuEditExit_Click(object sender, EventArgs e) {
            Close();
        }

        private void mainMenuEditOpen_Click(object sender, EventArgs e) {
            using (var dlg = new OpenFileDialog()) {
                dlg.Filter = "GRF file (*.grf)|*.grf;*.gpf|All files|*.*";
                if (mGrfFile != null) {
                    dlg.InitialDirectory = mGrfFile.Filepath;
                } else {
                    dlg.InitialDirectory = Application.StartupPath;
                }

                if (dlg.ShowDialog(this) != DialogResult.OK) {
                    return;
                }

                OpenGrf(dlg.FileName);
            }
        }

        private void mainMenuEditSave_Click(object sender, EventArgs e) {
            if (mGrfFile == null || string.IsNullOrEmpty(mGrfFile.Filepath)) {
                mainMenuEditSaveAs.PerformClick();
                return;
            }

            SaveGrf(mGrfFile.Filepath);
        }

        private void mainMenuEditSaveAs_Click(object sender, EventArgs e) {
            using (var dlg = new SaveFileDialog()) {
                dlg.Filter = "GRF/GPF File|*.grf;*.gpf";
                dlg.FileName = Path.GetFileName(mGrfFile.Filepath);
                if (dlg.ShowDialog() != DialogResult.OK) {
                    return;
                }

                SaveGrf(dlg.FileName);
            }
        }

        private void mainMenuEditNew_Click(object sender, EventArgs e) {
            using (var dlg = new SaveFileDialog()) {
                dlg.Filter = "GRF/GPF File|*.grf;*.gpf";
                dlg.FileName = Path.GetFileName(mGrfFile.Filepath);
                if (dlg.ShowDialog() != DialogResult.OK) {
                    return;
                }

                mGrfFile.CreateNew(dlg.FileName);
                SaveGrf(dlg.FileName);
            }
        }

        private void mainMenuSettings_Click(object sender, EventArgs e) {
            using (var frm = new FrmSettings()) {
                if (frm.ShowDialog(this) != DialogResult.OK) {
                    return;
                }

                Settings.Default.Save();
                txtEn2Korea.Enabled = Settings.Default.EnableResnametableSearch;
                txtID2Name.Enabled = Settings.Default.EnableResnametableSearch;

                // Load resnametable, if not yet done
                LoadResnametable();
            }
        }

        private void mainMenuPluginsReload_Click(object sender, EventArgs e) {
            // Save info message
            string oldMessage = lblStatus.Text;
            Image oldMessageImg = lblStatus.Image;

            // Unload & load
            ReloadPlugins();

            // Hide them
            HidePreviewControls();

            // Set selection to show preview for current selection
            if (mSelectedGrfItem != null) {
                SetPreview(mSelectedGrfItem);
            }

            // #1 Set old info
            SetInfoState(oldMessage, oldMessageImg);
            // #2 Set timed info
            SetInfoStateTimed("Plugins reloaded: " + mPlugins.Count, Resources.check);
        }

        private void mainMenuAbout_Click(object sender, EventArgs e) {
        }
        #endregion

        #region ListView Events
        private void listView_SelectionChanged(object sender, EventArgs e) {
            int selectionCount = listView.GetSelectedObjects().Count;
            if (selectionCount > 0) {
                SetInfoStateTimed("Selected " + selectionCount + "/" + listView.GetItemCount() + " files", Resources.information);
            }

            var grfItemCached = (RoGrfFileItem)listView.GetSelectedObject();
            if (grfItemCached == null) {
                SetPreview(null);
                return;
            }

            RoGrfFileItem grfItem = mGrfFile.GetFileByHash(grfItemCached.NameHash);
            SetPreview(grfItem);
        }

        private void listView_KeyPress(object sender, KeyPressEventArgs e) {
            switch (e.KeyChar) {
                case '\b': // delete
                    e.Handled = true;
                    if (listView.SelectedIndices.Count == 0) {
                        break;
                    }

                    RemoveSelectedFiles();
                    break;
            }
        }
        #endregion

        #region ListView ContextMenu Events
        private void listViewContext_Opening(object sender, CancelEventArgs e) {
            int selectedItems = listView.SelectedIndices.Count;
            bool selectedNone = (selectedItems == 0);
            bool selectedOne = (selectedItems == 1);
            bool selectedMulti = (selectedNone == false && selectedOne == false);

            if (mGrfFile == null || mGrfFile.Version == 0) {
                e.Cancel = true;
                return;
            }

            listViewContextCopyPath.Enabled = (selectedNone == false);
            listViewContextExtract.Enabled = (selectedNone == false);
            listViewContextFileRemove.Enabled = (selectedNone == false);
            if (selectedOne == false) {
                listViewContextExtract.Text = "Extract ..";
                listViewContextFileRemove.Text = "Delete ..";
            } else if (selectedMulti) {
                listViewContextExtract.Text = "Extract selected files (" + selectedItems + ") ..";
                listViewContextFileRemove.Text = "Delete selected files (" + selectedItems + ") ..";
            } else {
                // Selected single file
                string filename = Path.GetFileName((listView.GetSelectedObject() as RoGrfFileItem).Filepath);
                listViewContextExtract.Text = "Extract file: " + filename + "..";
                listViewContextFileRemove.Text = "Delete file: " + filename + "..";
            }
            listViewContextExtractAll.Enabled = (mGrfFile.Files.Count > 0);
            listViewContextFileAdd.Enabled = true;
            listViewContextFolderAdd.Enabled = true;
            listViewContextFolderRemove.Enabled = selectedOne;
        }

        private void listViewContextCopyPath_Click(object sender, EventArgs e) {
            ArrayList array = listView.GetSelectedObjects();
            if (array == null || array.Count == 0) {
                return;
            }

            var pathArray = new string[array.Count];
            for (int i = 0; i < array.Count; i++) {
                pathArray[i] = (array[i] as RoGrfFileItem).Filepath;
            }
            string filepath = pathArray.JoinArray(Environment.NewLine);

            try {
                Clipboard.SetDataObject(filepath, true);
            } catch {
                SetInfoStateTimed("Failed to copy path info", Resources.delete);
            }
        }

        private void listViewContextExtract_Click(object sender, EventArgs e) {
            var dlg = new FolderBrowserDialog();
            dlg.Description = "File destination";
            if (dlg.ShowDialog() != DialogResult.OK) {
                return;
            }

            // Extract single file directly to choosen folder
            ArrayList selectedObjects = listView.GetSelectedObjects();
            if (selectedObjects == null || selectedObjects.Count == 0) {
                return;
            } else if (selectedObjects.Count == 1) {
                string nameHash = (selectedObjects[0] as RoGrfFileItem).NameHash;
                mGrfFile.ExtractFile(dlg.SelectedPath, nameHash, true, true);
                mGrfFile.Flush();
                return;
            }

            // Extract more than one file
            using (var frm = new FrmExtract(mGrfFile, dlg.SelectedPath, listView.GetSelectedObjects())) {
                if (frm.ShowDialog(this) != DialogResult.OK) {
                    return;
                }
            }

            mGrfFile.Flush();
        }

        private void listViewContextExtractAll_Click(object sender, EventArgs e) {
            var dlg = new FolderBrowserDialog();
            dlg.Description = "File destination";
            if (dlg.ShowDialog() != DialogResult.OK) {
                return;
            }

            using (var frm = new FrmExtract(mGrfFile, dlg.SelectedPath, new ArrayList())) {
                if (frm.ShowDialog(this) != DialogResult.OK) {
                    return;
                }
            }

            mGrfFile.Flush();
        }

        private void listViewContextFileAdd_Click(object sender, EventArgs e) {
            string[] files;
            using (var dlg = new OpenFileDialog()) {
                dlg.Multiselect = true;
                if (dlg.ShowDialog(this) != DialogResult.OK) {
                    return;
                }

                files = dlg.FileNames;
            }

            if (files.Length > 0) {
                for (int i = 0; i < files.Length - 1; i++) {
                    string filepath = files[i];
                    AddFile(filepath, false);
                }
                AddFile(files[files.Length - 1], true);
            }
        }

        private void listViewContextFolderAdd_Click(object sender, EventArgs e) {
            string folder;
            using (var dlg = new FolderBrowserDialog()) {
                if (dlg.ShowDialog() != DialogResult.OK) {
                    return;
                }

                folder = dlg.SelectedPath;
            }

            AddFolder(folder);
        }

        private void listViewContextFileRemove_Click(object sender, EventArgs e) {
            RemoveSelectedFiles();
        }

        private void listViewContextFolderRemove_Click(object sender, EventArgs e) {
            RemoveSelectedFilesByFolder();
        }
        #endregion

        #region Filter Events
        private void txtFilterText_TextChanged(object sender, EventArgs e) {
            btnFilter.PerformClick();
        }

        private void txtFilterText_KeyUp(object sender, KeyEventArgs e) {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Execute) {
                btnFilter.PerformClick();
            }
        }

        private void btnFilter_Click(object sender, EventArgs e) {
            TimedFilter();
        }


        private void txtID2Name_TextChanged(object sender, EventArgs e) {
            string idString = txtID2Name.Text.Trim();
            if (idString.Length == 0 || mResname == null || mResname.ID2Korea.Count == 0) {
                return;
            }

            int realID = int.Parse(idString);
            if (mResname.ID2Korea.ContainsKey(realID) == false) {
                return;
            }

            txtFilterText.Text = mResname.ID2Korea[realID];
            txtID2Name.Text = "";
        }

        private void txtEn2Korea_TextChanged(object sender, EventArgs e) {
            string idString = txtEn2Korea.Text.Trim();
            if (idString.Length == 0 || mResname == null || mResname.ID2Korea.Count == 0) {
                return;
            }

            idString = idString.ToLower().Replace(' ', '_'); // this is gravity style, so replace it..
            if (mResname.En2Korea.ContainsKey(idString) == false) {
                return;
            }

            txtFilterText.Text = mResname.En2Korea[idString];
            txtEn2Korea.Text = "";
        }
        #endregion

        #region Helper Methods
        public void SetInfoState(string Text) {
            SetInfoState(Text, null);
        }

        public void SetInfoState(string Text, Image stateImage) {
            // Ensure no timer is running 
            if (mInfoTimer != null && mInfoTimer.Enabled) {
                mInfoTimer.Stop();
            }

            lblStatus.Text = Text;
            if (stateImage != null) {
                lblStatus.Image = stateImage;
            }
        }


        public void SetInfoStateTimed(string message, Image stateImage) {
            SetInfoStateTimed(message, stateImage, 3000);
        }

        public void SetInfoStateTimed(string message, Image stateImage, int timeout) {
            if (mInfoTimer == null) {
                mInfoTimer = new Timer();
                mInfoTimer.Tick += delegate {
                    mInfoTimer.Stop();

                    SetInfoState(mOldStateMessage, mOldStateImage);
                    mOldStateMessage = "";
                    mOldStateImage = null;
                };
            }

            // Timer active?
            if (mInfoTimer.Enabled) {
                mInfoTimer.Stop();

                // Preserve old message
            } else {
                // No timer means a fixed message is the old one
                mOldStateMessage = lblStatus.Text;
                mOldStateImage = lblStatus.Image;
            }

            SetInfoState(message, stateImage);
            mInfoTimer.Interval = timeout;
            mInfoTimer.Start();
        }


        public void SetGuiState(bool flag) {
            // Toggle control Enabled state
            InvokeHelper.Invoke(mainMenuEditOpen, delegate {
                mainMenuEditOpen.Enabled = flag;
            });
            InvokeHelper.Invoke(mainMenuEditSave, delegate {
                mainMenuEditSave.Enabled = flag;
            });
            InvokeHelper.Invoke(mainMenuEditSaveAs, delegate {
                mainMenuEditSaveAs.Enabled = flag;
            });
            InvokeHelper.Invoke(mainMenuEditNew, delegate {
                mainMenuEditNew.Enabled = flag;
            });
            InvokeHelper.Invoke(txtFilterText, delegate {
                txtFilterText.Enabled = flag;
                txtFilterText.ReadOnly = !flag;
            });
            InvokeHelper.Invoke(txtEn2Korea, delegate {
                txtEn2Korea.Enabled = flag;
                txtEn2Korea.ReadOnly = !flag;
            });
            InvokeHelper.Invoke(txtID2Name, delegate {
                txtID2Name.Enabled = flag;
                txtID2Name.ReadOnly = !flag;
            });
            InvokeHelper.Invoke(btnFilter, delegate {
                btnFilter.Enabled = flag;
            });
            InvokeHelper.Invoke(listView, delegate {
                listView.Enabled = flag;
            });
        }

        public void SetGrfInfo() {
            string nl = Environment.NewLine;

            lblStatusProgress.Visible = false;
            lblGrfInfo.Visible = true;

            if (mGrfFile == null || mGrfFile.Version == 0) {
                lblGrfInfo.Text = "No valid grf";

                Text = mDefaultTitle;
                return;
            }

            lblGrfInfo.Text = string.Format("Version: 0x{0:X2} | Wasted: {1}", mGrfFile.Version, mGrfFile.WastedSpace.FormatFileSize());
            Text = mDefaultTitle + " - " + Path.GetFileName(mGrfFilepath) + " (" + mGrfFile.Files.Count + " Items)";
        }


        private void OpenGrf(string filepath) {
            listView.DeselectAll();
            mSelectedGrfItem = null;

            mGrfFilepath = filepath;
            SetGuiState(false);
            SetInfoState("Opening GRF: " + filepath, Resources.information);
            lblStatusProgress.Visible = true;
            lblGrfInfo.Visible = false;

            if (TaskbarManager.IsPlatformSupported) {
                mWin7Taskbar.SetProgressState(TaskbarProgressBarState.Normal);
                mWin7Taskbar.SetProgressValue(0, 100);
            }
            mBackgroundLoading.RunWorkerAsync();
        }

        private void SaveGrf(string filepath) {
            // Repack or dirty?
            bool repack = MessageBox.Show("Do you want to repack the full grf? (Needs more time but saves space)" + Environment.NewLine + "Current wasted space: " + mGrfFile.WastedSpace.FormatFileSize(), "Repack or dirty?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes;

            lblStatusProgress.Visible = true;
            lblGrfInfo.Visible = false;

            SetGuiState(false);

            SetInfoState("Prepare saving..", Resources.information);
            if (TaskbarManager.IsPlatformSupported) {
                mWin7Taskbar.SetProgressState(TaskbarProgressBarState.Normal);
                mWin7Taskbar.SetProgressValue(0, 100);
            }
            mBackgroundSaving.RunWorkerAsync(new object[] { filepath, repack });
        }

        private void FillListView() {
            var grfItems = new RoGrfFileItem[mGrfFile.Files.Count];
            mGrfFile.Files.Values.CopyTo(grfItems, 0);

            listView.ClearCachedInfo();
            listView.SetObjects(grfItems);
            grfItems = null;
        }

        private void LoadResnametable() {
            if (Settings.Default.EnableResnametableSearch == false) {
                return;
            }

            if (mGrfFile.Files.Count > 0) {
                mResname = new ResnameParser();
                mResname.Parse(mGrfFile);
            } else {
                mResname = null;
            }
        }


        private void TimedFilter() {
            string txt = txtFilterText.Text.Trim();
            if (txt.Length == 0) {
                listView.DefaultRenderer = null;
                listView.ModelFilter = null;

                SetInfoState("GRF " + Path.GetFileName(mGrfFilepath) + " successfully opened (" + mGrfFile.Files.Count + " Files)", Resources.check);
                return;
            }

            var filter = new FilepathTextMatchFilter(listView, txt, TextMatchFilter.MatchKind.Regex);
            listView.DefaultRenderer = new FilepathHighlightTextRenderer(filter);
            listView.ModelFilter = filter;

            SetInfoState("Found " + listView.GetItemCount() + " files", Resources.information);
        }

        private void SetPreview(RoGrfFileItem grfItem) {
            HidePreviewControls();

            // No selection or selected a dir; or empty items (possible?)
            if (grfItem == null || grfItem.Flags == 0 || (grfItem.IsAdded == false && grfItem.IsUpdated == false && grfItem.FileData != null && grfItem.FileData.Length == 0)) {
                return;
            }

            int extIndex = grfItem.Filepath.LastIndexOf('.');
            if (extIndex == -1) {
                // Maybe a directory
                return;
            }

            // Ensure data got loaded and decompressed
            byte[] buf = mGrfFile.GetFileData(grfItem, true);
            // Get extension without leading dot
            string ext = grfItem.Filepath.Substring(extIndex + 1).ToLower();
            // Will be true, if list view should be blocked until preview control released it
            bool blockListView = false;

            if (buf != null && buf.Length > 0) {
                foreach (var p in mPlugins) {
                    var previewPanel = p as IPreviewPanel;
                    if (previewPanel == null || previewPanel.IsSupported(ext) == false) {
                        continue;
                    }

                    previewPanel.SetData(buf, Path.GetFileNameWithoutExtension(grfItem.Filepath));
                    var control = p as Control;
                    if (control != null) {
                        control.Visible = true;
                    }

                    if (previewPanel.BlockListView()) {
                        blockListView = true;
                    }
                    break;
                }

                if (blockListView) {
                    // Block listView selecting new items until pewview is ready
                    listView.Enabled = false;
                }
            } // if(buf != null && buf.Length > 0)

            buf = null;
            grfItem.Flush();

            mSelectedGrfItem = grfItem;
        }

        private int GetItemImageIndex(RoGrfFileItem grfItem) {
            // Default to "data"
            int index = 0;
            if (grfItem == null) {
                return index;
            }

            // New file
            if (grfItem.IsAdded) {
                return 5;
            }
            // Updated file
            if (grfItem.IsUpdated) {
                return 6;
            }

            int extIndex = grfItem.Filepath.LastIndexOf('.');
            if (extIndex == -1) {
                // Dir
                return 4;
            }
            // Extension without leading dot
            switch (grfItem.Filepath.Substring(extIndex + 1).ToLower()) {
                case "txt":
                case "lua":
                    index = 1;
                    break;
                case "jpg":
                case "jepg":
                case "png":
                case "bmp":
                case "tga":
                    index = 2;
                    break;
                case "wav":
                case "mp3":
                    index = 3;
                    break;
            }

            return index;
        }

        private void HidePreviewControls() {
            foreach (Control c in pnlPreview.Controls) {
                c.Visible = false;
            }
        }
        #endregion

        #region File operations
        private void AddFile(string filepath, bool refresh = true) {
            var newItem = new RoGrfFileItem();
            newItem.LoadFromFile(mGrfFile, filepath);

            // Try getting clone of exsting item
            // Used to refresh the item list after an update
            string nameHash = newItem.NameHash;
            var existingItem = mGrfFile.GetFileByHash(nameHash);
            OLVListItem existingListItem = null;
            if (existingItem != null) {
                existingListItem = listView.ModelToItem(existingItem);
            }

            // Add the item
            ERoGrfFileItemState result = mGrfFile.AddFile(newItem);
            // Added a new item to the grf?
            if (result == ERoGrfFileItemState.Added) {
                listView.AddObject(newItem);
            } else if (result == ERoGrfFileItemState.Updated) {
                // Updated an item, try get the origin
                if (existingListItem != null) {
                    existingListItem.RowObject = mGrfFile.GetFileByHash(newItem.NameHash);
                    listView.RefreshItem(existingListItem);
                }
            }

            // Refresh info
            if (refresh) {
                SetGrfInfo();
            }

            newItem = null;
        }

        private void AddFolder(string folder) {
            // Add all files in this folder
            string[] files = Directory.GetFiles(folder);
            if (files.Length > 0) {
                // Add files without gui refresh
                for (int i = 0; i < files.Length - 1; i++) {
                    string filepath = files[i];
                    AddFile(filepath, false);
                }

                // Add last item with refresh
                AddFile(files[files.Length - 1], true);
            }

            string[] folders = Directory.GetDirectories(folder);
            foreach (string subFolder in folders) {
                AddFolder(subFolder);
            }
        }

        private void RemoveSelectedFiles() {
            if (listView.SelectedIndices.Count == 0) {
                return;
            }

            if (listView.SelectedIndices.Count == 1) {
                var item = listView.GetModelObject(listView.SelectedIndices[0]) as RoGrfFileItem;
                if (MessageBox.Show("Are you sure to delete the selected file?" + Environment.NewLine + "File: " + item.Filepath, "Delete selected file", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes) {
                    return;
                }
            } else {
                if (MessageBox.Show("Are you sure to delete all " + listView.SelectedIndices.Count + " selected files?", "Delete selected files", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes) {
                    return;
                }
            }

            int selectedIndex;
            object obj;
            RoGrfFileItem grfItem;
            for (int i = listView.SelectedIndices.Count - 1; i >= 0; i--) {
                selectedIndex = listView.SelectedIndices[i];
                obj = listView.GetModelObject(selectedIndex);
                grfItem = obj as RoGrfFileItem;
                if (grfItem.Flags == 0) {
                    MessageBox.Show("A folder can not be replaced or deleted.", "Folder error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    continue;
                }

                RemoveFile(grfItem, selectedIndex, false);
            }

            // We dont refresh in the loop, so do it here
            SetGrfInfo();
        }

        private void RemoveSelectedFilesByFolder() {
            if (listView.SelectedIndices.Count == 0) {
                return;
            }

            // Get all different folders
            var folders = new List<string>();
            RoGrfFileItem grfItem;

            foreach (object obj in listView.GetSelectedObjects()) {
                grfItem = obj as RoGrfFileItem;
                string selectedFolder = Path.GetDirectoryName(grfItem.Filepath);

                if (folders.Contains(selectedFolder) == false) {
                    folders.Add(selectedFolder);
                }
            }

            foreach (string selectedFolder in folders) {
                if (MessageBox.Show("Are you sure to delet ALL files in the Folder?" + Environment.NewLine + "Selected folder: " + selectedFolder, "Delete files in folder", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes) {
                    return;
                }

                string nameHash = null;
                while ((nameHash = mGrfFile.ContainsFilepart(selectedFolder)) != null) {
                    grfItem = mGrfFile[nameHash];
                    int selectedIndex = listView.IndexOf(grfItem);
                    if (selectedIndex != -1) {
                        RemoveFile(grfItem, selectedIndex, false);
                    } else {
                        // Failed to find file.. dont know why this happens
                        MessageBox.Show("Failed to find file in list:" + Environment.NewLine + grfItem.Filepath, "Delete error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        break;
                    }
                }

                // manually refresh..
                SetGrfInfo();
            }
        }

        private void RemoveFile(RoGrfFileItem grfItem, int selectedIndex, bool refresh) {
            mGrfFile.DeleteFile(grfItem.NameHash);
            listView.RemoveIndizies(
                new List<int>(
                    new[] {
						selectedIndex
					}
                )
            );

            grfItem = null;

            // Refresh info
            if (refresh) {
                SetGrfInfo();
            }
        }
        #endregion

        private void InitializeListView() {
            // Column delegates for values

            colNum.AspectName = "Index";
            colNum.AspectToStringConverter = x => ((int)x + 1).ToString(CultureInfo.InvariantCulture);
            colNum.ImageGetter = x => GetItemImageIndex(((RoGrfFileItem)x));

            colDataSize.AspectName = "LengthCompressedAlign";
            colDataSize.AspectToStringConverter = x => ((uint)x).FormatFileSize();

            colDataSizeExtracted.AspectName = "LengthUnCompressed";
            colDataSizeExtracted.AspectToStringConverter = x => ((uint)x).FormatFileSize();

            colOffset.AspectName = "DataOffset";

            SetInfoStateTimed("Listview successfull initialized.", Resources.information);
        }

    }

}
