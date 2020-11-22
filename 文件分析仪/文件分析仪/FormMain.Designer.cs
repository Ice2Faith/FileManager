namespace 文件分析仪
{
    partial class FormMain
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormMain));
            this.listViewFiles = new System.Windows.Forms.ListView();
            this.columnHeaderName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeaderType = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeaderSize = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeaderAttribute = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeaderLastModifyTime = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeaderCreateTime = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeaderLastAccessTime = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeaderFileCode = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.contextMenuStripMain = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.TouchNewToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.TouchNewFloderToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.TouchNewTxtFileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.TouchNewOtherFileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.TouchNewBatFileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.TouchNewClangFileGroupToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.TouchNewCppFileGroupToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.TouchNewJavaFileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.TouchNewPythonFileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.RefereshDisplayToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ShowFloderCheckStateToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.OpenLocalDirectoryToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ChoiceOpenMethodToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.OpenInSysExplorerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.OpenItByNotepadToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.OpenItByNewWindowToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.CopyFullPathToClipbordToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
            this.StartWithParamToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.RunOnCmdlineToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.RunCmdAsArgumentToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.RunCmdAllAsArgumentsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.RunCmdDirectHereToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.OpenCmdInHereToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.CopySelectedToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.CutSelectedToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.PaustSelectedToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.DeleteSelectedToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.RenameSelectedToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.SelectedAllToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.SelectedNothingToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.SelectedAntiFaceToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.RandomSelectNumToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.imageListMain = new System.Windows.Forms.ImageList(this.components);
            this.menuStripMain = new System.Windows.Forms.MenuStrip();
            this.ToPreviousHistoryToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ToNextHistoryToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ParentToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.DisplayToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.DisplayIconToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.DisplayDetialToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.DisplayListToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.DisplayTileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.FilterToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.FilterAllToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.FilterOnlyRegularUserToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.FilterDirectoryToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.FilterFileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator6 = new System.Windows.Forms.ToolStripSeparator();
            this.FilterPictureToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.FilterVideoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.FilterAudioToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.FilterCompressToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.FilterDocumentToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.FilterExecuableToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.FilterLinkFileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.FilterLibDllToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.SpcificalFloderToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.JumpToDesktopToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.JumpToMyComputerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.JumpToMyDocumentToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.JumpToMyPictureToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.JumpToMyVideoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.JumpToMyFavorateToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.JumpToMyMusicToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.AnaliesFilesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.AnaliesFileOnlyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.AnaliesFlodersInfoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.AnaliesFileCheckCodeFToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.SortManageToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.RaiseSortModeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.DescSortModeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.SortTypeNoneToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.PowerProToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ProMkdirsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.NameToUpperToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.NameToLowerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.NameReplaceStringToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.NameUnifySuffixToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.NameHeadAddNumberToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.NameTialAddNumberToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.NameHeadAddTimeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.NameTialAddTimeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.NameHeadAddDateToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.NameTialAddDateToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.NameHeadAddStringToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.NameTialAddStringToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.AttributeEditorToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.AttriAddReadOnlyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.AttriCancelReadOnlyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.AttriAddHideToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.AttriCancelHideToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.panelWorker = new System.Windows.Forms.Panel();
            this.splitContainerControl = new System.Windows.Forms.SplitContainer();
            this.splitContainerHeadLine = new System.Windows.Forms.SplitContainer();
            this.textBoxCurrentPath = new System.Windows.Forms.TextBox();
            this.buttonEnter = new System.Windows.Forms.Button();
            this.panelSearch = new System.Windows.Forms.Panel();
            this.textBoxSearchContent = new System.Windows.Forms.TextBox();
            this.buttonSearch = new System.Windows.Forms.Button();
            this.panelMainView = new System.Windows.Forms.Panel();
            this.statusStripMain = new System.Windows.Forms.StatusStrip();
            this.StateTipstoolStripStatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.SeniorToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.CleanEmptyDirectoryToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.CleanEmptyFileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator7 = new System.Windows.Forms.ToolStripSeparator();
            this.CleanFilesOfSuffixiesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator8 = new System.Windows.Forms.ToolStripSeparator();
            this.WindowToTopmostToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.WindowToTransparentToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.WindowTransParentRateToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.WindowWhiteBecomeFullTransparentToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.contextMenuStripMain.SuspendLayout();
            this.menuStripMain.SuspendLayout();
            this.panelWorker.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl)).BeginInit();
            this.splitContainerControl.Panel1.SuspendLayout();
            this.splitContainerControl.Panel2.SuspendLayout();
            this.splitContainerControl.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerHeadLine)).BeginInit();
            this.splitContainerHeadLine.Panel1.SuspendLayout();
            this.splitContainerHeadLine.Panel2.SuspendLayout();
            this.splitContainerHeadLine.SuspendLayout();
            this.panelSearch.SuspendLayout();
            this.panelMainView.SuspendLayout();
            this.statusStripMain.SuspendLayout();
            this.SuspendLayout();
            // 
            // listViewFiles
            // 
            this.listViewFiles.AllowDrop = true;
            this.listViewFiles.BackColor = System.Drawing.Color.White;
            this.listViewFiles.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeaderName,
            this.columnHeaderType,
            this.columnHeaderSize,
            this.columnHeaderAttribute,
            this.columnHeaderLastModifyTime,
            this.columnHeaderCreateTime,
            this.columnHeaderLastAccessTime,
            this.columnHeaderFileCode});
            this.listViewFiles.ContextMenuStrip = this.contextMenuStripMain;
            this.listViewFiles.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listViewFiles.FullRowSelect = true;
            this.listViewFiles.LabelEdit = true;
            this.listViewFiles.LargeImageList = this.imageListMain;
            this.listViewFiles.Location = new System.Drawing.Point(0, 0);
            this.listViewFiles.Name = "listViewFiles";
            this.listViewFiles.Size = new System.Drawing.Size(1015, 377);
            this.listViewFiles.SmallImageList = this.imageListMain;
            this.listViewFiles.TabIndex = 0;
            this.listViewFiles.UseCompatibleStateImageBehavior = false;
            this.listViewFiles.View = System.Windows.Forms.View.Details;
            this.listViewFiles.AfterLabelEdit += new System.Windows.Forms.LabelEditEventHandler(this.listViewFiles_AfterLabelEdit);
            this.listViewFiles.ColumnClick += new System.Windows.Forms.ColumnClickEventHandler(this.listViewFiles_ColumnClick);
            this.listViewFiles.ItemSelectionChanged += new System.Windows.Forms.ListViewItemSelectionChangedEventHandler(this.listViewFiles_ItemSelectionChanged);
            this.listViewFiles.DragDrop += new System.Windows.Forms.DragEventHandler(this.listViewFiles_DragDrop);
            this.listViewFiles.DragEnter += new System.Windows.Forms.DragEventHandler(this.listViewFiles_DragEnter);
            this.listViewFiles.DoubleClick += new System.EventHandler(this.listViewFiles_DoubleClick);
            this.listViewFiles.KeyDown += new System.Windows.Forms.KeyEventHandler(this.listViewFiles_KeyDown);
            // 
            // columnHeaderName
            // 
            this.columnHeaderName.Text = "名称";
            this.columnHeaderName.Width = 180;
            // 
            // columnHeaderType
            // 
            this.columnHeaderType.Text = "类型";
            this.columnHeaderType.Width = 120;
            // 
            // columnHeaderSize
            // 
            this.columnHeaderSize.Text = "大小";
            this.columnHeaderSize.Width = 80;
            // 
            // columnHeaderAttribute
            // 
            this.columnHeaderAttribute.Text = "属性";
            // 
            // columnHeaderLastModifyTime
            // 
            this.columnHeaderLastModifyTime.Text = "最后修改";
            this.columnHeaderLastModifyTime.Width = 120;
            // 
            // columnHeaderCreateTime
            // 
            this.columnHeaderCreateTime.Text = "创建时间";
            this.columnHeaderCreateTime.Width = 120;
            // 
            // columnHeaderLastAccessTime
            // 
            this.columnHeaderLastAccessTime.Text = "最后访问";
            this.columnHeaderLastAccessTime.Width = 114;
            // 
            // columnHeaderFileCode
            // 
            this.columnHeaderFileCode.Text = "校验码";
            // 
            // contextMenuStripMain
            // 
            this.contextMenuStripMain.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.contextMenuStripMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.TouchNewToolStripMenuItem,
            this.RefereshDisplayToolStripMenuItem,
            this.ShowFloderCheckStateToolStripMenuItem,
            this.toolStripSeparator3,
            this.OpenLocalDirectoryToolStripMenuItem,
            this.ChoiceOpenMethodToolStripMenuItem,
            this.OpenInSysExplorerToolStripMenuItem,
            this.OpenItByNotepadToolStripMenuItem,
            this.OpenItByNewWindowToolStripMenuItem,
            this.CopyFullPathToClipbordToolStripMenuItem,
            this.toolStripSeparator5,
            this.StartWithParamToolStripMenuItem,
            this.RunOnCmdlineToolStripMenuItem,
            this.RunCmdAsArgumentToolStripMenuItem,
            this.RunCmdAllAsArgumentsToolStripMenuItem,
            this.RunCmdDirectHereToolStripMenuItem,
            this.OpenCmdInHereToolStripMenuItem,
            this.toolStripSeparator1,
            this.CopySelectedToolStripMenuItem,
            this.CutSelectedToolStripMenuItem,
            this.PaustSelectedToolStripMenuItem,
            this.DeleteSelectedToolStripMenuItem,
            this.RenameSelectedToolStripMenuItem,
            this.toolStripSeparator2,
            this.SelectedAllToolStripMenuItem,
            this.SelectedNothingToolStripMenuItem,
            this.SelectedAntiFaceToolStripMenuItem,
            this.RandomSelectNumToolStripMenuItem});
            this.contextMenuStripMain.Name = "contextMenuStripMain";
            this.contextMenuStripMain.Size = new System.Drawing.Size(250, 604);
            // 
            // TouchNewToolStripMenuItem
            // 
            this.TouchNewToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.TouchNewFloderToolStripMenuItem,
            this.TouchNewTxtFileToolStripMenuItem,
            this.TouchNewOtherFileToolStripMenuItem});
            this.TouchNewToolStripMenuItem.Name = "TouchNewToolStripMenuItem";
            this.TouchNewToolStripMenuItem.Size = new System.Drawing.Size(249, 24);
            this.TouchNewToolStripMenuItem.Text = "新建(&T)";
            // 
            // TouchNewFloderToolStripMenuItem
            // 
            this.TouchNewFloderToolStripMenuItem.Name = "TouchNewFloderToolStripMenuItem";
            this.TouchNewFloderToolStripMenuItem.Size = new System.Drawing.Size(166, 26);
            this.TouchNewFloderToolStripMenuItem.Text = "文件夹(&F)";
            this.TouchNewFloderToolStripMenuItem.Click += new System.EventHandler(this.TouchNewFloderToolStripMenuItem_Click);
            // 
            // TouchNewTxtFileToolStripMenuItem
            // 
            this.TouchNewTxtFileToolStripMenuItem.Name = "TouchNewTxtFileToolStripMenuItem";
            this.TouchNewTxtFileToolStripMenuItem.Size = new System.Drawing.Size(166, 26);
            this.TouchNewTxtFileToolStripMenuItem.Text = "TXT文档(&T)";
            this.TouchNewTxtFileToolStripMenuItem.Click += new System.EventHandler(this.TouchNewTxtFileToolStripMenuItem_Click);
            // 
            // TouchNewOtherFileToolStripMenuItem
            // 
            this.TouchNewOtherFileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.TouchNewBatFileToolStripMenuItem,
            this.TouchNewClangFileGroupToolStripMenuItem,
            this.TouchNewCppFileGroupToolStripMenuItem,
            this.TouchNewJavaFileToolStripMenuItem,
            this.TouchNewPythonFileToolStripMenuItem});
            this.TouchNewOtherFileToolStripMenuItem.Name = "TouchNewOtherFileToolStripMenuItem";
            this.TouchNewOtherFileToolStripMenuItem.Size = new System.Drawing.Size(166, 26);
            this.TouchNewOtherFileToolStripMenuItem.Text = "其他文件(&O)";
            // 
            // TouchNewBatFileToolStripMenuItem
            // 
            this.TouchNewBatFileToolStripMenuItem.Name = "TouchNewBatFileToolStripMenuItem";
            this.TouchNewBatFileToolStripMenuItem.Size = new System.Drawing.Size(221, 26);
            this.TouchNewBatFileToolStripMenuItem.Text = "bat批处理文件[.bat]";
            this.TouchNewBatFileToolStripMenuItem.Click += new System.EventHandler(this.TouchNewBatFileToolStripMenuItem_Click);
            // 
            // TouchNewClangFileGroupToolStripMenuItem
            // 
            this.TouchNewClangFileGroupToolStripMenuItem.Name = "TouchNewClangFileGroupToolStripMenuItem";
            this.TouchNewClangFileGroupToolStripMenuItem.Size = new System.Drawing.Size(221, 26);
            this.TouchNewClangFileGroupToolStripMenuItem.Text = "c语言文件组[.h/.c]";
            this.TouchNewClangFileGroupToolStripMenuItem.ToolTipText = "将会创建对应名称的.c和.h文件";
            this.TouchNewClangFileGroupToolStripMenuItem.Click += new System.EventHandler(this.TouchNewClangFileGroupToolStripMenuItem_Click);
            // 
            // TouchNewCppFileGroupToolStripMenuItem
            // 
            this.TouchNewCppFileGroupToolStripMenuItem.Name = "TouchNewCppFileGroupToolStripMenuItem";
            this.TouchNewCppFileGroupToolStripMenuItem.Size = new System.Drawing.Size(221, 26);
            this.TouchNewCppFileGroupToolStripMenuItem.Text = "c++文件组[.h/.cpp]";
            this.TouchNewCppFileGroupToolStripMenuItem.ToolTipText = "将会创建对应名称的.cpp和.h文件";
            this.TouchNewCppFileGroupToolStripMenuItem.Click += new System.EventHandler(this.TouchNewCppFileGroupToolStripMenuItem_Click);
            // 
            // TouchNewJavaFileToolStripMenuItem
            // 
            this.TouchNewJavaFileToolStripMenuItem.Name = "TouchNewJavaFileToolStripMenuItem";
            this.TouchNewJavaFileToolStripMenuItem.Size = new System.Drawing.Size(221, 26);
            this.TouchNewJavaFileToolStripMenuItem.Text = "java源文件[.java]";
            this.TouchNewJavaFileToolStripMenuItem.Click += new System.EventHandler(this.TouchNewJavaFileToolStripMenuItem_Click);
            // 
            // TouchNewPythonFileToolStripMenuItem
            // 
            this.TouchNewPythonFileToolStripMenuItem.Name = "TouchNewPythonFileToolStripMenuItem";
            this.TouchNewPythonFileToolStripMenuItem.Size = new System.Drawing.Size(221, 26);
            this.TouchNewPythonFileToolStripMenuItem.Text = "python源文件[.py]";
            this.TouchNewPythonFileToolStripMenuItem.Click += new System.EventHandler(this.TouchNewPythonFileToolStripMenuItem_Click);
            // 
            // RefereshDisplayToolStripMenuItem
            // 
            this.RefereshDisplayToolStripMenuItem.Name = "RefereshDisplayToolStripMenuItem";
            this.RefereshDisplayToolStripMenuItem.Size = new System.Drawing.Size(249, 24);
            this.RefereshDisplayToolStripMenuItem.Text = "刷新(&F)";
            this.RefereshDisplayToolStripMenuItem.ToolTipText = "F5";
            this.RefereshDisplayToolStripMenuItem.Click += new System.EventHandler(this.RefereshDisplayToolStripMenuItem_Click);
            // 
            // ShowFloderCheckStateToolStripMenuItem
            // 
            this.ShowFloderCheckStateToolStripMenuItem.Name = "ShowFloderCheckStateToolStripMenuItem";
            this.ShowFloderCheckStateToolStripMenuItem.Size = new System.Drawing.Size(249, 24);
            this.ShowFloderCheckStateToolStripMenuItem.Text = "显示文件夹(&K)";
            this.ShowFloderCheckStateToolStripMenuItem.ToolTipText = "仅影响过滤菜单功能部分";
            this.ShowFloderCheckStateToolStripMenuItem.Click += new System.EventHandler(this.ShowFloderCheckStateToolStripMenuItem_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(246, 6);
            // 
            // OpenLocalDirectoryToolStripMenuItem
            // 
            this.OpenLocalDirectoryToolStripMenuItem.Name = "OpenLocalDirectoryToolStripMenuItem";
            this.OpenLocalDirectoryToolStripMenuItem.Size = new System.Drawing.Size(249, 24);
            this.OpenLocalDirectoryToolStripMenuItem.Text = "打开所在路径(&O)";
            this.OpenLocalDirectoryToolStripMenuItem.ToolTipText = "在本程序内打开所选项目所在的文件夹";
            this.OpenLocalDirectoryToolStripMenuItem.Click += new System.EventHandler(this.OpenLocalDirectoryToolStripMenuItem_Click);
            // 
            // ChoiceOpenMethodToolStripMenuItem
            // 
            this.ChoiceOpenMethodToolStripMenuItem.Name = "ChoiceOpenMethodToolStripMenuItem";
            this.ChoiceOpenMethodToolStripMenuItem.Size = new System.Drawing.Size(249, 24);
            this.ChoiceOpenMethodToolStripMenuItem.Text = "选择打开方式(&P)";
            this.ChoiceOpenMethodToolStripMenuItem.Click += new System.EventHandler(this.ChoiceOpenMethodToolStripMenuItem_Click);
            // 
            // OpenInSysExplorerToolStripMenuItem
            // 
            this.OpenInSysExplorerToolStripMenuItem.Name = "OpenInSysExplorerToolStripMenuItem";
            this.OpenInSysExplorerToolStripMenuItem.Size = new System.Drawing.Size(249, 24);
            this.OpenInSysExplorerToolStripMenuItem.Text = "在Explorer中打开(&E)";
            this.OpenInSysExplorerToolStripMenuItem.ToolTipText = "用系统的文件管理器打开所选的项目";
            this.OpenInSysExplorerToolStripMenuItem.Click += new System.EventHandler(this.OpenInSysExplorerToolStripMenuItem_Click);
            // 
            // OpenItByNotepadToolStripMenuItem
            // 
            this.OpenItByNotepadToolStripMenuItem.Name = "OpenItByNotepadToolStripMenuItem";
            this.OpenItByNotepadToolStripMenuItem.Size = new System.Drawing.Size(249, 24);
            this.OpenItByNotepadToolStripMenuItem.Text = "用记事本打开(&I)";
            this.OpenItByNotepadToolStripMenuItem.Click += new System.EventHandler(this.OpenItByNotepadToolStripMenuItem_Click);
            // 
            // OpenItByNewWindowToolStripMenuItem
            // 
            this.OpenItByNewWindowToolStripMenuItem.Name = "OpenItByNewWindowToolStripMenuItem";
            this.OpenItByNewWindowToolStripMenuItem.Size = new System.Drawing.Size(249, 24);
            this.OpenItByNewWindowToolStripMenuItem.Text = "在新子窗口中打开(&N)";
            this.OpenItByNewWindowToolStripMenuItem.ToolTipText = "弹出一个本程序的子窗口进行显示选中的项目";
            this.OpenItByNewWindowToolStripMenuItem.Click += new System.EventHandler(this.OpenItByNewWindowToolStripMenuItem_Click);
            // 
            // CopyFullPathToClipbordToolStripMenuItem
            // 
            this.CopyFullPathToClipbordToolStripMenuItem.Name = "CopyFullPathToClipbordToolStripMenuItem";
            this.CopyFullPathToClipbordToolStripMenuItem.Size = new System.Drawing.Size(249, 24);
            this.CopyFullPathToClipbordToolStripMenuItem.Text = "复制完整路径";
            this.CopyFullPathToClipbordToolStripMenuItem.ToolTipText = "复制所选内容的完整路径到剪切板，他们以换行分割";
            this.CopyFullPathToClipbordToolStripMenuItem.Click += new System.EventHandler(this.CopyFullPathToClipbordToolStripMenuItem_Click);
            // 
            // toolStripSeparator5
            // 
            this.toolStripSeparator5.Name = "toolStripSeparator5";
            this.toolStripSeparator5.Size = new System.Drawing.Size(246, 6);
            // 
            // StartWithParamToolStripMenuItem
            // 
            this.StartWithParamToolStripMenuItem.Name = "StartWithParamToolStripMenuItem";
            this.StartWithParamToolStripMenuItem.Size = new System.Drawing.Size(249, 24);
            this.StartWithParamToolStripMenuItem.Text = "带参数启动(&B)";
            this.StartWithParamToolStripMenuItem.ToolTipText = "给定运行使用的命令行参数进行运行选中项";
            this.StartWithParamToolStripMenuItem.Click += new System.EventHandler(this.StartWithParamToolStripMenuItem_Click);
            // 
            // RunOnCmdlineToolStripMenuItem
            // 
            this.RunOnCmdlineToolStripMenuItem.Name = "RunOnCmdlineToolStripMenuItem";
            this.RunOnCmdlineToolStripMenuItem.Size = new System.Drawing.Size(249, 24);
            this.RunOnCmdlineToolStripMenuItem.Text = "在命令行中运行";
            this.RunOnCmdlineToolStripMenuItem.Click += new System.EventHandler(this.RunOnCmdlineToolStripMenuItem_Click);
            // 
            // RunCmdAsArgumentToolStripMenuItem
            // 
            this.RunCmdAsArgumentToolStripMenuItem.Name = "RunCmdAsArgumentToolStripMenuItem";
            this.RunCmdAsArgumentToolStripMenuItem.Size = new System.Drawing.Size(249, 24);
            this.RunCmdAsArgumentToolStripMenuItem.Text = "置于命令参数中运行";
            this.RunCmdAsArgumentToolStripMenuItem.Click += new System.EventHandler(this.RunCmdAsArgumentToolStripMenuItem_Click);
            // 
            // RunCmdAllAsArgumentsToolStripMenuItem
            // 
            this.RunCmdAllAsArgumentsToolStripMenuItem.Name = "RunCmdAllAsArgumentsToolStripMenuItem";
            this.RunCmdAllAsArgumentsToolStripMenuItem.Size = new System.Drawing.Size(249, 24);
            this.RunCmdAllAsArgumentsToolStripMenuItem.Text = "全部作为命令参数";
            this.RunCmdAllAsArgumentsToolStripMenuItem.Click += new System.EventHandler(this.RunCmdAllAsArgumentsToolStripMenuItem_Click);
            // 
            // RunCmdDirectHereToolStripMenuItem
            // 
            this.RunCmdDirectHereToolStripMenuItem.Name = "RunCmdDirectHereToolStripMenuItem";
            this.RunCmdDirectHereToolStripMenuItem.Size = new System.Drawing.Size(249, 24);
            this.RunCmdDirectHereToolStripMenuItem.Text = "在此处直接运行CMD命令";
            this.RunCmdDirectHereToolStripMenuItem.Click += new System.EventHandler(this.RunCmdDirectHereToolStripMenuItem_Click);
            // 
            // OpenCmdInHereToolStripMenuItem
            // 
            this.OpenCmdInHereToolStripMenuItem.Name = "OpenCmdInHereToolStripMenuItem";
            this.OpenCmdInHereToolStripMenuItem.Size = new System.Drawing.Size(249, 24);
            this.OpenCmdInHereToolStripMenuItem.Text = "在此处打开命令行";
            this.OpenCmdInHereToolStripMenuItem.Click += new System.EventHandler(this.OpenCmdInHereToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(246, 6);
            // 
            // CopySelectedToolStripMenuItem
            // 
            this.CopySelectedToolStripMenuItem.Name = "CopySelectedToolStripMenuItem";
            this.CopySelectedToolStripMenuItem.Size = new System.Drawing.Size(249, 24);
            this.CopySelectedToolStripMenuItem.Text = "复制(&C)";
            this.CopySelectedToolStripMenuItem.ToolTipText = "Ctrl+C";
            this.CopySelectedToolStripMenuItem.Click += new System.EventHandler(this.CopySelectedToolStripMenuItem_Click);
            // 
            // CutSelectedToolStripMenuItem
            // 
            this.CutSelectedToolStripMenuItem.Name = "CutSelectedToolStripMenuItem";
            this.CutSelectedToolStripMenuItem.Size = new System.Drawing.Size(249, 24);
            this.CutSelectedToolStripMenuItem.Text = "剪切(&X)";
            this.CutSelectedToolStripMenuItem.ToolTipText = "Ctrl+X";
            this.CutSelectedToolStripMenuItem.Click += new System.EventHandler(this.CutSelectedToolStripMenuItem_Click);
            // 
            // PaustSelectedToolStripMenuItem
            // 
            this.PaustSelectedToolStripMenuItem.Name = "PaustSelectedToolStripMenuItem";
            this.PaustSelectedToolStripMenuItem.Size = new System.Drawing.Size(249, 24);
            this.PaustSelectedToolStripMenuItem.Text = "粘贴(&V)";
            this.PaustSelectedToolStripMenuItem.ToolTipText = "Ctrl+V";
            this.PaustSelectedToolStripMenuItem.Click += new System.EventHandler(this.PaustSelectedToolStripMenuItem_Click);
            // 
            // DeleteSelectedToolStripMenuItem
            // 
            this.DeleteSelectedToolStripMenuItem.Name = "DeleteSelectedToolStripMenuItem";
            this.DeleteSelectedToolStripMenuItem.Size = new System.Drawing.Size(249, 24);
            this.DeleteSelectedToolStripMenuItem.Text = "删除(&D)";
            this.DeleteSelectedToolStripMenuItem.ToolTipText = "Ctrl+Delete";
            this.DeleteSelectedToolStripMenuItem.Click += new System.EventHandler(this.DeleteSelectedToolStripMenuItem_Click);
            // 
            // RenameSelectedToolStripMenuItem
            // 
            this.RenameSelectedToolStripMenuItem.Name = "RenameSelectedToolStripMenuItem";
            this.RenameSelectedToolStripMenuItem.Size = new System.Drawing.Size(249, 24);
            this.RenameSelectedToolStripMenuItem.Text = "重命名(&M)";
            this.RenameSelectedToolStripMenuItem.Click += new System.EventHandler(this.RenameSelectedToolStripMenuItem_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(246, 6);
            // 
            // SelectedAllToolStripMenuItem
            // 
            this.SelectedAllToolStripMenuItem.Name = "SelectedAllToolStripMenuItem";
            this.SelectedAllToolStripMenuItem.Size = new System.Drawing.Size(249, 24);
            this.SelectedAllToolStripMenuItem.Text = "全选(&A)";
            this.SelectedAllToolStripMenuItem.ToolTipText = "Ctrl+A";
            this.SelectedAllToolStripMenuItem.Click += new System.EventHandler(this.SelectedAllToolStripMenuItem_Click);
            // 
            // SelectedNothingToolStripMenuItem
            // 
            this.SelectedNothingToolStripMenuItem.Name = "SelectedNothingToolStripMenuItem";
            this.SelectedNothingToolStripMenuItem.Size = new System.Drawing.Size(249, 24);
            this.SelectedNothingToolStripMenuItem.Text = "全不选(&Q)";
            this.SelectedNothingToolStripMenuItem.ToolTipText = "Ctrl+Q";
            this.SelectedNothingToolStripMenuItem.Click += new System.EventHandler(this.SelectedNothingToolStripMenuItem_Click);
            // 
            // SelectedAntiFaceToolStripMenuItem
            // 
            this.SelectedAntiFaceToolStripMenuItem.Name = "SelectedAntiFaceToolStripMenuItem";
            this.SelectedAntiFaceToolStripMenuItem.Size = new System.Drawing.Size(249, 24);
            this.SelectedAntiFaceToolStripMenuItem.Text = "反选(&W)";
            this.SelectedAntiFaceToolStripMenuItem.ToolTipText = "Ctrl+W";
            this.SelectedAntiFaceToolStripMenuItem.Click += new System.EventHandler(this.SelectedAntiFaceToolStripMenuItem_Click);
            // 
            // RandomSelectNumToolStripMenuItem
            // 
            this.RandomSelectNumToolStripMenuItem.Name = "RandomSelectNumToolStripMenuItem";
            this.RandomSelectNumToolStripMenuItem.Size = new System.Drawing.Size(249, 24);
            this.RandomSelectNumToolStripMenuItem.Text = "随机选择";
            this.RandomSelectNumToolStripMenuItem.Click += new System.EventHandler(this.RandomSelectNumToolStripMenuItem_Click);
            // 
            // imageListMain
            // 
            this.imageListMain.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageListMain.ImageStream")));
            this.imageListMain.TransparentColor = System.Drawing.Color.Transparent;
            this.imageListMain.Images.SetKeyName(0, "floder");
            this.imageListMain.Images.SetKeyName(1, "unkown");
            // 
            // menuStripMain
            // 
            this.menuStripMain.BackColor = System.Drawing.SystemColors.Control;
            this.menuStripMain.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStripMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ToPreviousHistoryToolStripMenuItem,
            this.ToNextHistoryToolStripMenuItem,
            this.ParentToolStripMenuItem,
            this.DisplayToolStripMenuItem,
            this.FilterToolStripMenuItem,
            this.SpcificalFloderToolStripMenuItem,
            this.AnaliesFilesToolStripMenuItem,
            this.SortManageToolStripMenuItem,
            this.PowerProToolStripMenuItem,
            this.AttributeEditorToolStripMenuItem,
            this.SeniorToolStripMenuItem});
            this.menuStripMain.Location = new System.Drawing.Point(0, 0);
            this.menuStripMain.Name = "menuStripMain";
            this.menuStripMain.Size = new System.Drawing.Size(1015, 28);
            this.menuStripMain.TabIndex = 2;
            this.menuStripMain.Text = "menuStrip1";
            // 
            // ToPreviousHistoryToolStripMenuItem
            // 
            this.ToPreviousHistoryToolStripMenuItem.Name = "ToPreviousHistoryToolStripMenuItem";
            this.ToPreviousHistoryToolStripMenuItem.Size = new System.Drawing.Size(61, 24);
            this.ToPreviousHistoryToolStripMenuItem.Text = "<<(&L)";
            this.ToPreviousHistoryToolStripMenuItem.ToolTipText = "Left 上一个";
            this.ToPreviousHistoryToolStripMenuItem.Click += new System.EventHandler(this.ToPreviousHistoryToolStripMenuItem_Click);
            // 
            // ToNextHistoryToolStripMenuItem
            // 
            this.ToNextHistoryToolStripMenuItem.Name = "ToNextHistoryToolStripMenuItem";
            this.ToNextHistoryToolStripMenuItem.Size = new System.Drawing.Size(63, 24);
            this.ToNextHistoryToolStripMenuItem.Text = ">>(&R)";
            this.ToNextHistoryToolStripMenuItem.ToolTipText = "Right 下一个";
            this.ToNextHistoryToolStripMenuItem.Click += new System.EventHandler(this.ToNextHistoryToolStripMenuItem_Click);
            // 
            // ParentToolStripMenuItem
            // 
            this.ParentToolStripMenuItem.Name = "ParentToolStripMenuItem";
            this.ParentToolStripMenuItem.Size = new System.Drawing.Size(85, 24);
            this.ParentToolStripMenuItem.Text = "上一层(&B)";
            this.ParentToolStripMenuItem.ToolTipText = "Esc";
            this.ParentToolStripMenuItem.Click += new System.EventHandler(this.ParentToolStripMenuItem_Click);
            // 
            // DisplayToolStripMenuItem
            // 
            this.DisplayToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.DisplayIconToolStripMenuItem,
            this.DisplayDetialToolStripMenuItem,
            this.DisplayListToolStripMenuItem,
            this.DisplayTileToolStripMenuItem});
            this.DisplayToolStripMenuItem.Name = "DisplayToolStripMenuItem";
            this.DisplayToolStripMenuItem.Size = new System.Drawing.Size(72, 24);
            this.DisplayToolStripMenuItem.Text = "显示(&D)";
            // 
            // DisplayIconToolStripMenuItem
            // 
            this.DisplayIconToolStripMenuItem.Name = "DisplayIconToolStripMenuItem";
            this.DisplayIconToolStripMenuItem.Size = new System.Drawing.Size(135, 26);
            this.DisplayIconToolStripMenuItem.Text = "图标(&I)";
            this.DisplayIconToolStripMenuItem.Click += new System.EventHandler(this.DisplayIconToolStripMenuItem_Click);
            // 
            // DisplayDetialToolStripMenuItem
            // 
            this.DisplayDetialToolStripMenuItem.Name = "DisplayDetialToolStripMenuItem";
            this.DisplayDetialToolStripMenuItem.Size = new System.Drawing.Size(135, 26);
            this.DisplayDetialToolStripMenuItem.Text = "详细(&D)";
            this.DisplayDetialToolStripMenuItem.Click += new System.EventHandler(this.DisplayDetialToolStripMenuItem_Click);
            // 
            // DisplayListToolStripMenuItem
            // 
            this.DisplayListToolStripMenuItem.Name = "DisplayListToolStripMenuItem";
            this.DisplayListToolStripMenuItem.Size = new System.Drawing.Size(135, 26);
            this.DisplayListToolStripMenuItem.Text = "列表(&L)";
            this.DisplayListToolStripMenuItem.Click += new System.EventHandler(this.DisplayListToolStripMenuItem_Click);
            // 
            // DisplayTileToolStripMenuItem
            // 
            this.DisplayTileToolStripMenuItem.Name = "DisplayTileToolStripMenuItem";
            this.DisplayTileToolStripMenuItem.Size = new System.Drawing.Size(135, 26);
            this.DisplayTileToolStripMenuItem.Text = "平铺(&T)";
            this.DisplayTileToolStripMenuItem.Click += new System.EventHandler(this.DisplayTileToolStripMenuItem_Click);
            // 
            // FilterToolStripMenuItem
            // 
            this.FilterToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.FilterAllToolStripMenuItem,
            this.FilterOnlyRegularUserToolStripMenuItem,
            this.FilterDirectoryToolStripMenuItem,
            this.FilterFileToolStripMenuItem,
            this.toolStripSeparator6,
            this.FilterPictureToolStripMenuItem,
            this.FilterVideoToolStripMenuItem,
            this.FilterAudioToolStripMenuItem,
            this.FilterCompressToolStripMenuItem,
            this.FilterDocumentToolStripMenuItem,
            this.FilterExecuableToolStripMenuItem,
            this.FilterLinkFileToolStripMenuItem,
            this.FilterLibDllToolStripMenuItem});
            this.FilterToolStripMenuItem.Name = "FilterToolStripMenuItem";
            this.FilterToolStripMenuItem.Size = new System.Drawing.Size(69, 24);
            this.FilterToolStripMenuItem.Text = "过滤(&F)";
            // 
            // FilterAllToolStripMenuItem
            // 
            this.FilterAllToolStripMenuItem.Name = "FilterAllToolStripMenuItem";
            this.FilterAllToolStripMenuItem.Size = new System.Drawing.Size(220, 26);
            this.FilterAllToolStripMenuItem.Text = "所有(&Z)";
            this.FilterAllToolStripMenuItem.Click += new System.EventHandler(this.FilterAllToolStripMenuItem_Click);
            // 
            // FilterOnlyRegularUserToolStripMenuItem
            // 
            this.FilterOnlyRegularUserToolStripMenuItem.Name = "FilterOnlyRegularUserToolStripMenuItem";
            this.FilterOnlyRegularUserToolStripMenuItem.Size = new System.Drawing.Size(220, 26);
            this.FilterOnlyRegularUserToolStripMenuItem.Text = "仅常规(&R)";
            this.FilterOnlyRegularUserToolStripMenuItem.Click += new System.EventHandler(this.FilterOnlyRegularUserToolStripMenuItem_Click);
            // 
            // FilterDirectoryToolStripMenuItem
            // 
            this.FilterDirectoryToolStripMenuItem.Name = "FilterDirectoryToolStripMenuItem";
            this.FilterDirectoryToolStripMenuItem.Size = new System.Drawing.Size(220, 26);
            this.FilterDirectoryToolStripMenuItem.Text = "仅文件夹(&D)";
            this.FilterDirectoryToolStripMenuItem.Click += new System.EventHandler(this.FilterDirectoryToolStripMenuItem_Click);
            // 
            // FilterFileToolStripMenuItem
            // 
            this.FilterFileToolStripMenuItem.Name = "FilterFileToolStripMenuItem";
            this.FilterFileToolStripMenuItem.Size = new System.Drawing.Size(220, 26);
            this.FilterFileToolStripMenuItem.Text = "仅文件(&F)";
            this.FilterFileToolStripMenuItem.Click += new System.EventHandler(this.FilterFileToolStripMenuItem_Click);
            // 
            // toolStripSeparator6
            // 
            this.toolStripSeparator6.Name = "toolStripSeparator6";
            this.toolStripSeparator6.Size = new System.Drawing.Size(217, 6);
            // 
            // FilterPictureToolStripMenuItem
            // 
            this.FilterPictureToolStripMenuItem.Name = "FilterPictureToolStripMenuItem";
            this.FilterPictureToolStripMenuItem.Size = new System.Drawing.Size(220, 26);
            this.FilterPictureToolStripMenuItem.Text = "图片(&P)";
            this.FilterPictureToolStripMenuItem.Click += new System.EventHandler(this.FilterPictureToolStripMenuItem_Click);
            // 
            // FilterVideoToolStripMenuItem
            // 
            this.FilterVideoToolStripMenuItem.Name = "FilterVideoToolStripMenuItem";
            this.FilterVideoToolStripMenuItem.Size = new System.Drawing.Size(220, 26);
            this.FilterVideoToolStripMenuItem.Text = "视频(&V)";
            this.FilterVideoToolStripMenuItem.Click += new System.EventHandler(this.FilterVideoToolStripMenuItem_Click);
            // 
            // FilterAudioToolStripMenuItem
            // 
            this.FilterAudioToolStripMenuItem.Name = "FilterAudioToolStripMenuItem";
            this.FilterAudioToolStripMenuItem.Size = new System.Drawing.Size(220, 26);
            this.FilterAudioToolStripMenuItem.Text = "音频(&A)";
            this.FilterAudioToolStripMenuItem.Click += new System.EventHandler(this.FilterAudioToolStripMenuItem_Click);
            // 
            // FilterCompressToolStripMenuItem
            // 
            this.FilterCompressToolStripMenuItem.Name = "FilterCompressToolStripMenuItem";
            this.FilterCompressToolStripMenuItem.Size = new System.Drawing.Size(220, 26);
            this.FilterCompressToolStripMenuItem.Text = "压缩(&C)";
            this.FilterCompressToolStripMenuItem.Click += new System.EventHandler(this.FilterCompressToolStripMenuItem_Click);
            // 
            // FilterDocumentToolStripMenuItem
            // 
            this.FilterDocumentToolStripMenuItem.Name = "FilterDocumentToolStripMenuItem";
            this.FilterDocumentToolStripMenuItem.Size = new System.Drawing.Size(220, 26);
            this.FilterDocumentToolStripMenuItem.Text = "文档(&T)";
            this.FilterDocumentToolStripMenuItem.Click += new System.EventHandler(this.FilterDocumentToolStripMenuItem_Click);
            // 
            // FilterExecuableToolStripMenuItem
            // 
            this.FilterExecuableToolStripMenuItem.Name = "FilterExecuableToolStripMenuItem";
            this.FilterExecuableToolStripMenuItem.Size = new System.Drawing.Size(220, 26);
            this.FilterExecuableToolStripMenuItem.Text = "可执行(&E)";
            this.FilterExecuableToolStripMenuItem.Click += new System.EventHandler(this.FilterExecuableToolStripMenuItem_Click);
            // 
            // FilterLinkFileToolStripMenuItem
            // 
            this.FilterLinkFileToolStripMenuItem.Name = "FilterLinkFileToolStripMenuItem";
            this.FilterLinkFileToolStripMenuItem.Size = new System.Drawing.Size(220, 26);
            this.FilterLinkFileToolStripMenuItem.Text = "快捷方式(&L)";
            this.FilterLinkFileToolStripMenuItem.Click += new System.EventHandler(this.FilterLinkFileToolStripMenuItem_Click);
            // 
            // FilterLibDllToolStripMenuItem
            // 
            this.FilterLibDllToolStripMenuItem.Name = "FilterLibDllToolStripMenuItem";
            this.FilterLibDllToolStripMenuItem.Size = new System.Drawing.Size(220, 26);
            this.FilterLibDllToolStripMenuItem.Text = "连接/库/驱动文件(&B)";
            this.FilterLibDllToolStripMenuItem.Click += new System.EventHandler(this.FilterLibDllToolStripMenuItem_Click);
            // 
            // SpcificalFloderToolStripMenuItem
            // 
            this.SpcificalFloderToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.JumpToDesktopToolStripMenuItem,
            this.JumpToMyComputerToolStripMenuItem,
            this.JumpToMyDocumentToolStripMenuItem,
            this.JumpToMyPictureToolStripMenuItem,
            this.JumpToMyVideoToolStripMenuItem,
            this.JumpToMyFavorateToolStripMenuItem,
            this.JumpToMyMusicToolStripMenuItem});
            this.SpcificalFloderToolStripMenuItem.Name = "SpcificalFloderToolStripMenuItem";
            this.SpcificalFloderToolStripMenuItem.Size = new System.Drawing.Size(115, 24);
            this.SpcificalFloderToolStripMenuItem.Text = "特殊文件夹(&S)";
            // 
            // JumpToDesktopToolStripMenuItem
            // 
            this.JumpToDesktopToolStripMenuItem.Name = "JumpToDesktopToolStripMenuItem";
            this.JumpToDesktopToolStripMenuItem.Size = new System.Drawing.Size(169, 26);
            this.JumpToDesktopToolStripMenuItem.Text = "桌面(&D)";
            this.JumpToDesktopToolStripMenuItem.Click += new System.EventHandler(this.JumpToDesktopToolStripMenuItem_Click);
            // 
            // JumpToMyComputerToolStripMenuItem
            // 
            this.JumpToMyComputerToolStripMenuItem.Name = "JumpToMyComputerToolStripMenuItem";
            this.JumpToMyComputerToolStripMenuItem.Size = new System.Drawing.Size(169, 26);
            this.JumpToMyComputerToolStripMenuItem.Text = "我的电脑(&C)";
            this.JumpToMyComputerToolStripMenuItem.Click += new System.EventHandler(this.JumpToMyComputerToolStripMenuItem_Click);
            // 
            // JumpToMyDocumentToolStripMenuItem
            // 
            this.JumpToMyDocumentToolStripMenuItem.Name = "JumpToMyDocumentToolStripMenuItem";
            this.JumpToMyDocumentToolStripMenuItem.Size = new System.Drawing.Size(169, 26);
            this.JumpToMyDocumentToolStripMenuItem.Text = "我的文档(&T)";
            this.JumpToMyDocumentToolStripMenuItem.Click += new System.EventHandler(this.JumpToMyDocumentToolStripMenuItem_Click);
            // 
            // JumpToMyPictureToolStripMenuItem
            // 
            this.JumpToMyPictureToolStripMenuItem.Name = "JumpToMyPictureToolStripMenuItem";
            this.JumpToMyPictureToolStripMenuItem.Size = new System.Drawing.Size(169, 26);
            this.JumpToMyPictureToolStripMenuItem.Text = "我的图片(&P)";
            this.JumpToMyPictureToolStripMenuItem.Click += new System.EventHandler(this.JumpToMyPictureToolStripMenuItem_Click);
            // 
            // JumpToMyVideoToolStripMenuItem
            // 
            this.JumpToMyVideoToolStripMenuItem.Name = "JumpToMyVideoToolStripMenuItem";
            this.JumpToMyVideoToolStripMenuItem.Size = new System.Drawing.Size(169, 26);
            this.JumpToMyVideoToolStripMenuItem.Text = "我的视频(&V)";
            this.JumpToMyVideoToolStripMenuItem.Click += new System.EventHandler(this.JumpToMyVideoToolStripMenuItem_Click);
            // 
            // JumpToMyFavorateToolStripMenuItem
            // 
            this.JumpToMyFavorateToolStripMenuItem.Name = "JumpToMyFavorateToolStripMenuItem";
            this.JumpToMyFavorateToolStripMenuItem.Size = new System.Drawing.Size(169, 26);
            this.JumpToMyFavorateToolStripMenuItem.Text = "我的收藏(&F)";
            this.JumpToMyFavorateToolStripMenuItem.Click += new System.EventHandler(this.JumpToMyFavorateToolStripMenuItem_Click);
            // 
            // JumpToMyMusicToolStripMenuItem
            // 
            this.JumpToMyMusicToolStripMenuItem.Name = "JumpToMyMusicToolStripMenuItem";
            this.JumpToMyMusicToolStripMenuItem.Size = new System.Drawing.Size(169, 26);
            this.JumpToMyMusicToolStripMenuItem.Text = "我的音乐(&M)";
            this.JumpToMyMusicToolStripMenuItem.Click += new System.EventHandler(this.JumpToMyMusicToolStripMenuItem_Click);
            // 
            // AnaliesFilesToolStripMenuItem
            // 
            this.AnaliesFilesToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.AnaliesFileOnlyToolStripMenuItem,
            this.AnaliesFlodersInfoToolStripMenuItem,
            this.AnaliesFileCheckCodeFToolStripMenuItem});
            this.AnaliesFilesToolStripMenuItem.Name = "AnaliesFilesToolStripMenuItem";
            this.AnaliesFilesToolStripMenuItem.Size = new System.Drawing.Size(72, 24);
            this.AnaliesFilesToolStripMenuItem.Text = "分析(&A)";
            // 
            // AnaliesFileOnlyToolStripMenuItem
            // 
            this.AnaliesFileOnlyToolStripMenuItem.Name = "AnaliesFileOnlyToolStripMenuItem";
            this.AnaliesFileOnlyToolStripMenuItem.Size = new System.Drawing.Size(180, 26);
            this.AnaliesFileOnlyToolStripMenuItem.Text = "常规(&N)";
            this.AnaliesFileOnlyToolStripMenuItem.Click += new System.EventHandler(this.AnaliesFileOnlyToolStripMenuItem_Click);
            // 
            // AnaliesFlodersInfoToolStripMenuItem
            // 
            this.AnaliesFlodersInfoToolStripMenuItem.Name = "AnaliesFlodersInfoToolStripMenuItem";
            this.AnaliesFlodersInfoToolStripMenuItem.Size = new System.Drawing.Size(180, 26);
            this.AnaliesFlodersInfoToolStripMenuItem.Text = "分析文件夹(&D)";
            this.AnaliesFlodersInfoToolStripMenuItem.ToolTipText = "将会递归地分析文件夹，得到文件夹的大小等属性，将会比较耗时";
            this.AnaliesFlodersInfoToolStripMenuItem.Click += new System.EventHandler(this.AnaliesFlodersInfoToolStripMenuItem_Click);
            // 
            // AnaliesFileCheckCodeFToolStripMenuItem
            // 
            this.AnaliesFileCheckCodeFToolStripMenuItem.Name = "AnaliesFileCheckCodeFToolStripMenuItem";
            this.AnaliesFileCheckCodeFToolStripMenuItem.Size = new System.Drawing.Size(180, 26);
            this.AnaliesFileCheckCodeFToolStripMenuItem.Text = "分析文件(&F)";
            this.AnaliesFileCheckCodeFToolStripMenuItem.ToolTipText = "一般来说，相同文件的校验码也相同，虽然有时候不相同文件的校验码也可能相同";
            this.AnaliesFileCheckCodeFToolStripMenuItem.Click += new System.EventHandler(this.AnaliesFileCheckCodeFToolStripMenuItem_Click);
            // 
            // SortManageToolStripMenuItem
            // 
            this.SortManageToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.RaiseSortModeToolStripMenuItem,
            this.DescSortModeToolStripMenuItem,
            this.SortTypeNoneToolStripMenuItem});
            this.SortManageToolStripMenuItem.Name = "SortManageToolStripMenuItem";
            this.SortManageToolStripMenuItem.Size = new System.Drawing.Size(73, 24);
            this.SortManageToolStripMenuItem.Text = "排序(&O)";
            // 
            // RaiseSortModeToolStripMenuItem
            // 
            this.RaiseSortModeToolStripMenuItem.Name = "RaiseSortModeToolStripMenuItem";
            this.RaiseSortModeToolStripMenuItem.Size = new System.Drawing.Size(150, 26);
            this.RaiseSortModeToolStripMenuItem.Text = "升序(&S)";
            this.RaiseSortModeToolStripMenuItem.Click += new System.EventHandler(this.RaiseSortModeToolStripMenuItem_Click);
            // 
            // DescSortModeToolStripMenuItem
            // 
            this.DescSortModeToolStripMenuItem.Name = "DescSortModeToolStripMenuItem";
            this.DescSortModeToolStripMenuItem.Size = new System.Drawing.Size(150, 26);
            this.DescSortModeToolStripMenuItem.Text = "降序(&D)";
            this.DescSortModeToolStripMenuItem.Click += new System.EventHandler(this.DescSortModeToolStripMenuItem_Click);
            // 
            // SortTypeNoneToolStripMenuItem
            // 
            this.SortTypeNoneToolStripMenuItem.Name = "SortTypeNoneToolStripMenuItem";
            this.SortTypeNoneToolStripMenuItem.Size = new System.Drawing.Size(150, 26);
            this.SortTypeNoneToolStripMenuItem.Text = "无排序(&U)";
            this.SortTypeNoneToolStripMenuItem.ToolTipText = "当你在点击了列表框的列标头之后，会进行排序，如果你想回复默认排序，请点击此处";
            this.SortTypeNoneToolStripMenuItem.Click += new System.EventHandler(this.SortTypeNoneToolStripMenuItem_Click);
            // 
            // PowerProToolStripMenuItem
            // 
            this.PowerProToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ProMkdirsToolStripMenuItem,
            this.NameToUpperToolStripMenuItem,
            this.NameToLowerToolStripMenuItem,
            this.NameReplaceStringToolStripMenuItem,
            this.NameUnifySuffixToolStripMenuItem,
            this.toolStripSeparator4,
            this.NameHeadAddNumberToolStripMenuItem,
            this.NameTialAddNumberToolStripMenuItem,
            this.NameHeadAddTimeToolStripMenuItem,
            this.NameTialAddTimeToolStripMenuItem,
            this.NameHeadAddDateToolStripMenuItem,
            this.NameTialAddDateToolStripMenuItem,
            this.NameHeadAddStringToolStripMenuItem,
            this.NameTialAddStringToolStripMenuItem});
            this.PowerProToolStripMenuItem.Name = "PowerProToolStripMenuItem";
            this.PowerProToolStripMenuItem.Size = new System.Drawing.Size(70, 24);
            this.PowerProToolStripMenuItem.Text = "增强(&P)";
            // 
            // ProMkdirsToolStripMenuItem
            // 
            this.ProMkdirsToolStripMenuItem.Name = "ProMkdirsToolStripMenuItem";
            this.ProMkdirsToolStripMenuItem.Size = new System.Drawing.Size(204, 26);
            this.ProMkdirsToolStripMenuItem.Text = "创建多级目录";
            this.ProMkdirsToolStripMenuItem.ToolTipText = "给定一个相对当前显示目录的路径，自动为您创建多级目录";
            this.ProMkdirsToolStripMenuItem.Click += new System.EventHandler(this.ProMkdirsToolStripMenuItem_Click);
            // 
            // NameToUpperToolStripMenuItem
            // 
            this.NameToUpperToolStripMenuItem.Name = "NameToUpperToolStripMenuItem";
            this.NameToUpperToolStripMenuItem.Size = new System.Drawing.Size(204, 26);
            this.NameToUpperToolStripMenuItem.Text = "转换为大写";
            this.NameToUpperToolStripMenuItem.ToolTipText = "对选中项目的名称重命名为大写形式";
            this.NameToUpperToolStripMenuItem.Click += new System.EventHandler(this.NameToUpperToolStripMenuItem_Click);
            // 
            // NameToLowerToolStripMenuItem
            // 
            this.NameToLowerToolStripMenuItem.Name = "NameToLowerToolStripMenuItem";
            this.NameToLowerToolStripMenuItem.Size = new System.Drawing.Size(204, 26);
            this.NameToLowerToolStripMenuItem.Text = "转换为小写";
            this.NameToLowerToolStripMenuItem.Click += new System.EventHandler(this.NameToLowerToolStripMenuItem_Click);
            // 
            // NameReplaceStringToolStripMenuItem
            // 
            this.NameReplaceStringToolStripMenuItem.Name = "NameReplaceStringToolStripMenuItem";
            this.NameReplaceStringToolStripMenuItem.Size = new System.Drawing.Size(204, 26);
            this.NameReplaceStringToolStripMenuItem.Text = "替换字符串";
            this.NameReplaceStringToolStripMenuItem.Click += new System.EventHandler(this.NameReplaceStringToolStripMenuItem_Click);
            // 
            // NameUnifySuffixToolStripMenuItem
            // 
            this.NameUnifySuffixToolStripMenuItem.Name = "NameUnifySuffixToolStripMenuItem";
            this.NameUnifySuffixToolStripMenuItem.Size = new System.Drawing.Size(204, 26);
            this.NameUnifySuffixToolStripMenuItem.Text = "统一后缀";
            this.NameUnifySuffixToolStripMenuItem.ToolTipText = "对选中项目的后缀，进行统一为给定的后缀";
            this.NameUnifySuffixToolStripMenuItem.Click += new System.EventHandler(this.NameUnifySuffixToolStripMenuItem_Click);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(201, 6);
            // 
            // NameHeadAddNumberToolStripMenuItem
            // 
            this.NameHeadAddNumberToolStripMenuItem.Name = "NameHeadAddNumberToolStripMenuItem";
            this.NameHeadAddNumberToolStripMenuItem.Size = new System.Drawing.Size(204, 26);
            this.NameHeadAddNumberToolStripMenuItem.Text = "添加序号（首部）";
            this.NameHeadAddNumberToolStripMenuItem.Click += new System.EventHandler(this.NameHeadAddNumberToolStripMenuItem_Click);
            // 
            // NameTialAddNumberToolStripMenuItem
            // 
            this.NameTialAddNumberToolStripMenuItem.Name = "NameTialAddNumberToolStripMenuItem";
            this.NameTialAddNumberToolStripMenuItem.Size = new System.Drawing.Size(204, 26);
            this.NameTialAddNumberToolStripMenuItem.Text = "添加序号（尾部）";
            this.NameTialAddNumberToolStripMenuItem.Click += new System.EventHandler(this.NameTialAddNumberToolStripMenuItem_Click);
            // 
            // NameHeadAddTimeToolStripMenuItem
            // 
            this.NameHeadAddTimeToolStripMenuItem.Name = "NameHeadAddTimeToolStripMenuItem";
            this.NameHeadAddTimeToolStripMenuItem.Size = new System.Drawing.Size(204, 26);
            this.NameHeadAddTimeToolStripMenuItem.Text = "添加时间（首部）";
            this.NameHeadAddTimeToolStripMenuItem.Click += new System.EventHandler(this.NameHeadAddTimeToolStripMenuItem_Click);
            // 
            // NameTialAddTimeToolStripMenuItem
            // 
            this.NameTialAddTimeToolStripMenuItem.Name = "NameTialAddTimeToolStripMenuItem";
            this.NameTialAddTimeToolStripMenuItem.Size = new System.Drawing.Size(204, 26);
            this.NameTialAddTimeToolStripMenuItem.Text = "添加时间（尾部）";
            this.NameTialAddTimeToolStripMenuItem.Click += new System.EventHandler(this.NameTialAddTimeToolStripMenuItem_Click);
            // 
            // NameHeadAddDateToolStripMenuItem
            // 
            this.NameHeadAddDateToolStripMenuItem.Name = "NameHeadAddDateToolStripMenuItem";
            this.NameHeadAddDateToolStripMenuItem.Size = new System.Drawing.Size(204, 26);
            this.NameHeadAddDateToolStripMenuItem.Text = "添加日期（首部）";
            this.NameHeadAddDateToolStripMenuItem.Click += new System.EventHandler(this.NameHeadAddDateToolStripMenuItem_Click);
            // 
            // NameTialAddDateToolStripMenuItem
            // 
            this.NameTialAddDateToolStripMenuItem.Name = "NameTialAddDateToolStripMenuItem";
            this.NameTialAddDateToolStripMenuItem.Size = new System.Drawing.Size(204, 26);
            this.NameTialAddDateToolStripMenuItem.Text = "添加日期（尾部）";
            this.NameTialAddDateToolStripMenuItem.Click += new System.EventHandler(this.NameTialAddDateToolStripMenuItem_Click);
            // 
            // NameHeadAddStringToolStripMenuItem
            // 
            this.NameHeadAddStringToolStripMenuItem.Name = "NameHeadAddStringToolStripMenuItem";
            this.NameHeadAddStringToolStripMenuItem.Size = new System.Drawing.Size(204, 26);
            this.NameHeadAddStringToolStripMenuItem.Text = "添加字符（首部）";
            this.NameHeadAddStringToolStripMenuItem.Click += new System.EventHandler(this.NameHeadAddStringToolStripMenuItem_Click);
            // 
            // NameTialAddStringToolStripMenuItem
            // 
            this.NameTialAddStringToolStripMenuItem.Name = "NameTialAddStringToolStripMenuItem";
            this.NameTialAddStringToolStripMenuItem.Size = new System.Drawing.Size(204, 26);
            this.NameTialAddStringToolStripMenuItem.Text = "添加字符（尾部）";
            this.NameTialAddStringToolStripMenuItem.Click += new System.EventHandler(this.NameTialAddStringToolStripMenuItem_Click);
            // 
            // AttributeEditorToolStripMenuItem
            // 
            this.AttributeEditorToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.AttriAddReadOnlyToolStripMenuItem,
            this.AttriCancelReadOnlyToolStripMenuItem,
            this.AttriAddHideToolStripMenuItem,
            this.AttriCancelHideToolStripMenuItem});
            this.AttributeEditorToolStripMenuItem.Name = "AttributeEditorToolStripMenuItem";
            this.AttributeEditorToolStripMenuItem.Size = new System.Drawing.Size(70, 24);
            this.AttributeEditorToolStripMenuItem.Text = "属性(T)";
            // 
            // AttriAddReadOnlyToolStripMenuItem
            // 
            this.AttriAddReadOnlyToolStripMenuItem.Name = "AttriAddReadOnlyToolStripMenuItem";
            this.AttriAddReadOnlyToolStripMenuItem.Size = new System.Drawing.Size(144, 26);
            this.AttriAddReadOnlyToolStripMenuItem.Text = "转只读";
            this.AttriAddReadOnlyToolStripMenuItem.Click += new System.EventHandler(this.AttriAddReadOnlyToolStripMenuItem_Click);
            // 
            // AttriCancelReadOnlyToolStripMenuItem
            // 
            this.AttriCancelReadOnlyToolStripMenuItem.Name = "AttriCancelReadOnlyToolStripMenuItem";
            this.AttriCancelReadOnlyToolStripMenuItem.Size = new System.Drawing.Size(144, 26);
            this.AttriCancelReadOnlyToolStripMenuItem.Text = "取消只读";
            this.AttriCancelReadOnlyToolStripMenuItem.Click += new System.EventHandler(this.AttriCancelReadOnlyToolStripMenuItem_Click);
            // 
            // AttriAddHideToolStripMenuItem
            // 
            this.AttriAddHideToolStripMenuItem.Name = "AttriAddHideToolStripMenuItem";
            this.AttriAddHideToolStripMenuItem.Size = new System.Drawing.Size(144, 26);
            this.AttriAddHideToolStripMenuItem.Text = "转隐藏";
            this.AttriAddHideToolStripMenuItem.Click += new System.EventHandler(this.AttriAddHideToolStripMenuItem_Click);
            // 
            // AttriCancelHideToolStripMenuItem
            // 
            this.AttriCancelHideToolStripMenuItem.Name = "AttriCancelHideToolStripMenuItem";
            this.AttriCancelHideToolStripMenuItem.Size = new System.Drawing.Size(144, 26);
            this.AttriCancelHideToolStripMenuItem.Text = "取消隐藏";
            this.AttriCancelHideToolStripMenuItem.Click += new System.EventHandler(this.AttriCancelHideToolStripMenuItem_Click);
            // 
            // panelWorker
            // 
            this.panelWorker.Controls.Add(this.splitContainerControl);
            this.panelWorker.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelWorker.Location = new System.Drawing.Point(0, 28);
            this.panelWorker.Name = "panelWorker";
            this.panelWorker.Size = new System.Drawing.Size(1015, 448);
            this.panelWorker.TabIndex = 3;
            // 
            // splitContainerControl
            // 
            this.splitContainerControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerControl.Location = new System.Drawing.Point(0, 0);
            this.splitContainerControl.Name = "splitContainerControl";
            this.splitContainerControl.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainerControl.Panel1
            // 
            this.splitContainerControl.Panel1.Controls.Add(this.splitContainerHeadLine);
            // 
            // splitContainerControl.Panel2
            // 
            this.splitContainerControl.Panel2.Controls.Add(this.panelMainView);
            this.splitContainerControl.Panel2.Controls.Add(this.statusStripMain);
            this.splitContainerControl.Size = new System.Drawing.Size(1015, 448);
            this.splitContainerControl.SplitterDistance = 42;
            this.splitContainerControl.TabIndex = 1;
            // 
            // splitContainerHeadLine
            // 
            this.splitContainerHeadLine.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerHeadLine.Location = new System.Drawing.Point(0, 0);
            this.splitContainerHeadLine.Name = "splitContainerHeadLine";
            // 
            // splitContainerHeadLine.Panel1
            // 
            this.splitContainerHeadLine.Panel1.Controls.Add(this.textBoxCurrentPath);
            this.splitContainerHeadLine.Panel1.Controls.Add(this.buttonEnter);
            // 
            // splitContainerHeadLine.Panel2
            // 
            this.splitContainerHeadLine.Panel2.Controls.Add(this.panelSearch);
            this.splitContainerHeadLine.Panel2.Controls.Add(this.buttonSearch);
            this.splitContainerHeadLine.Size = new System.Drawing.Size(1015, 42);
            this.splitContainerHeadLine.SplitterDistance = 588;
            this.splitContainerHeadLine.TabIndex = 3;
            // 
            // textBoxCurrentPath
            // 
            this.textBoxCurrentPath.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBoxCurrentPath.Location = new System.Drawing.Point(0, 0);
            this.textBoxCurrentPath.Name = "textBoxCurrentPath";
            this.textBoxCurrentPath.Size = new System.Drawing.Size(513, 25);
            this.textBoxCurrentPath.TabIndex = 0;
            this.textBoxCurrentPath.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.textBoxCurrentPath_PreviewKeyDown);
            // 
            // buttonEnter
            // 
            this.buttonEnter.Dock = System.Windows.Forms.DockStyle.Right;
            this.buttonEnter.Location = new System.Drawing.Point(513, 0);
            this.buttonEnter.Name = "buttonEnter";
            this.buttonEnter.Size = new System.Drawing.Size(75, 42);
            this.buttonEnter.TabIndex = 1;
            this.buttonEnter.Text = "进入";
            this.buttonEnter.UseVisualStyleBackColor = true;
            this.buttonEnter.Click += new System.EventHandler(this.buttonEnter_Click);
            // 
            // panelSearch
            // 
            this.panelSearch.Controls.Add(this.textBoxSearchContent);
            this.panelSearch.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelSearch.Location = new System.Drawing.Point(0, 0);
            this.panelSearch.Name = "panelSearch";
            this.panelSearch.Size = new System.Drawing.Size(348, 42);
            this.panelSearch.TabIndex = 5;
            // 
            // textBoxSearchContent
            // 
            this.textBoxSearchContent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBoxSearchContent.Location = new System.Drawing.Point(0, 0);
            this.textBoxSearchContent.Name = "textBoxSearchContent";
            this.textBoxSearchContent.Size = new System.Drawing.Size(348, 25);
            this.textBoxSearchContent.TabIndex = 0;
            this.textBoxSearchContent.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.textBoxSearchContent_PreviewKeyDown);
            // 
            // buttonSearch
            // 
            this.buttonSearch.Dock = System.Windows.Forms.DockStyle.Right;
            this.buttonSearch.Location = new System.Drawing.Point(348, 0);
            this.buttonSearch.Name = "buttonSearch";
            this.buttonSearch.Size = new System.Drawing.Size(75, 42);
            this.buttonSearch.TabIndex = 4;
            this.buttonSearch.Text = "搜索";
            this.buttonSearch.UseVisualStyleBackColor = true;
            this.buttonSearch.Click += new System.EventHandler(this.buttonSearch_Click);
            // 
            // panelMainView
            // 
            this.panelMainView.Controls.Add(this.listViewFiles);
            this.panelMainView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelMainView.Location = new System.Drawing.Point(0, 0);
            this.panelMainView.Name = "panelMainView";
            this.panelMainView.Size = new System.Drawing.Size(1015, 377);
            this.panelMainView.TabIndex = 2;
            // 
            // statusStripMain
            // 
            this.statusStripMain.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.statusStripMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.StateTipstoolStripStatusLabel});
            this.statusStripMain.Location = new System.Drawing.Point(0, 377);
            this.statusStripMain.Name = "statusStripMain";
            this.statusStripMain.Size = new System.Drawing.Size(1015, 25);
            this.statusStripMain.TabIndex = 1;
            this.statusStripMain.Text = "statusStrip1";
            // 
            // StateTipstoolStripStatusLabel
            // 
            this.StateTipstoolStripStatusLabel.Name = "StateTipstoolStripStatusLabel";
            this.StateTipstoolStripStatusLabel.Size = new System.Drawing.Size(39, 20);
            this.StateTipstoolStripStatusLabel.Text = "就绪";
            // 
            // SeniorToolStripMenuItem
            // 
            this.SeniorToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.CleanEmptyDirectoryToolStripMenuItem,
            this.CleanEmptyFileToolStripMenuItem,
            this.toolStripSeparator7,
            this.CleanFilesOfSuffixiesToolStripMenuItem,
            this.toolStripSeparator8,
            this.WindowToTopmostToolStripMenuItem,
            this.WindowToTransparentToolStripMenuItem,
            this.WindowTransParentRateToolStripMenuItem,
            this.WindowWhiteBecomeFullTransparentToolStripMenuItem});
            this.SeniorToolStripMenuItem.Name = "SeniorToolStripMenuItem";
            this.SeniorToolStripMenuItem.Size = new System.Drawing.Size(70, 24);
            this.SeniorToolStripMenuItem.Text = "高级(&S)";
            // 
            // CleanEmptyDirectoryToolStripMenuItem
            // 
            this.CleanEmptyDirectoryToolStripMenuItem.Name = "CleanEmptyDirectoryToolStripMenuItem";
            this.CleanEmptyDirectoryToolStripMenuItem.Size = new System.Drawing.Size(223, 26);
            this.CleanEmptyDirectoryToolStripMenuItem.Text = "空文件夹清理(&D)";
            this.CleanEmptyDirectoryToolStripMenuItem.Click += new System.EventHandler(this.CleanEmptyDirectoryToolStripMenuItem_Click);
            // 
            // CleanEmptyFileToolStripMenuItem
            // 
            this.CleanEmptyFileToolStripMenuItem.Name = "CleanEmptyFileToolStripMenuItem";
            this.CleanEmptyFileToolStripMenuItem.Size = new System.Drawing.Size(223, 26);
            this.CleanEmptyFileToolStripMenuItem.Text = "空文件清理(&F)";
            this.CleanEmptyFileToolStripMenuItem.Click += new System.EventHandler(this.CleanEmptyFileToolStripMenuItem_Click);
            // 
            // toolStripSeparator7
            // 
            this.toolStripSeparator7.Name = "toolStripSeparator7";
            this.toolStripSeparator7.Size = new System.Drawing.Size(220, 6);
            // 
            // CleanFilesOfSuffixiesToolStripMenuItem
            // 
            this.CleanFilesOfSuffixiesToolStripMenuItem.Name = "CleanFilesOfSuffixiesToolStripMenuItem";
            this.CleanFilesOfSuffixiesToolStripMenuItem.Size = new System.Drawing.Size(223, 26);
            this.CleanFilesOfSuffixiesToolStripMenuItem.Text = "指定文件后缀清理(&S)";
            this.CleanFilesOfSuffixiesToolStripMenuItem.Click += new System.EventHandler(this.CleanFilesOfSuffixiesToolStripMenuItem_Click);
            // 
            // toolStripSeparator8
            // 
            this.toolStripSeparator8.Name = "toolStripSeparator8";
            this.toolStripSeparator8.Size = new System.Drawing.Size(220, 6);
            // 
            // WindowToTopmostToolStripMenuItem
            // 
            this.WindowToTopmostToolStripMenuItem.Name = "WindowToTopmostToolStripMenuItem";
            this.WindowToTopmostToolStripMenuItem.Size = new System.Drawing.Size(223, 26);
            this.WindowToTopmostToolStripMenuItem.Text = "窗口置顶(&P)";
            this.WindowToTopmostToolStripMenuItem.Click += new System.EventHandler(this.WindowToTopmostToolStripMenuItem_Click);
            // 
            // WindowToTransparentToolStripMenuItem
            // 
            this.WindowToTransparentToolStripMenuItem.Name = "WindowToTransparentToolStripMenuItem";
            this.WindowToTransparentToolStripMenuItem.Size = new System.Drawing.Size(223, 26);
            this.WindowToTransparentToolStripMenuItem.Text = "窗口半透明(&T)";
            this.WindowToTransparentToolStripMenuItem.Click += new System.EventHandler(this.WindowToTransparentToolStripMenuItem_Click);
            // 
            // WindowTransParentRateToolStripMenuItem
            // 
            this.WindowTransParentRateToolStripMenuItem.Name = "WindowTransParentRateToolStripMenuItem";
            this.WindowTransParentRateToolStripMenuItem.Size = new System.Drawing.Size(223, 26);
            this.WindowTransParentRateToolStripMenuItem.Text = "设置半透明度(&R)";
            this.WindowTransParentRateToolStripMenuItem.Click += new System.EventHandler(this.WindowTransParentRateToolStripMenuItem_Click);
            // 
            // WindowWhiteBecomeFullTransparentToolStripMenuItem
            // 
            this.WindowWhiteBecomeFullTransparentToolStripMenuItem.Name = "WindowWhiteBecomeFullTransparentToolStripMenuItem";
            this.WindowWhiteBecomeFullTransparentToolStripMenuItem.Size = new System.Drawing.Size(223, 26);
            this.WindowWhiteBecomeFullTransparentToolStripMenuItem.Text = "窗口空白全透明(&G)";
            this.WindowWhiteBecomeFullTransparentToolStripMenuItem.Click += new System.EventHandler(this.WindowWhiteBecomeFullTransparentToolStripMenuItem_Click);
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1015, 476);
            this.Controls.Add(this.panelWorker);
            this.Controls.Add(this.menuStripMain);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStripMain;
            this.Name = "FormMain";
            this.Text = "文件管理器";
            this.Load += new System.EventHandler(this.FormMain_Load);
            this.SizeChanged += new System.EventHandler(this.FormMain_SizeChanged);
            this.contextMenuStripMain.ResumeLayout(false);
            this.menuStripMain.ResumeLayout(false);
            this.menuStripMain.PerformLayout();
            this.panelWorker.ResumeLayout(false);
            this.splitContainerControl.Panel1.ResumeLayout(false);
            this.splitContainerControl.Panel2.ResumeLayout(false);
            this.splitContainerControl.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl)).EndInit();
            this.splitContainerControl.ResumeLayout(false);
            this.splitContainerHeadLine.Panel1.ResumeLayout(false);
            this.splitContainerHeadLine.Panel1.PerformLayout();
            this.splitContainerHeadLine.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerHeadLine)).EndInit();
            this.splitContainerHeadLine.ResumeLayout(false);
            this.panelSearch.ResumeLayout(false);
            this.panelSearch.PerformLayout();
            this.panelMainView.ResumeLayout(false);
            this.statusStripMain.ResumeLayout(false);
            this.statusStripMain.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListView listViewFiles;
        private System.Windows.Forms.ImageList imageListMain;
        private System.Windows.Forms.ContextMenuStrip contextMenuStripMain;
        private System.Windows.Forms.MenuStrip menuStripMain;
        private System.Windows.Forms.Panel panelWorker;
        private System.Windows.Forms.ToolStripMenuItem DisplayToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem DisplayIconToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem DisplayDetialToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem DisplayListToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem DisplayTileToolStripMenuItem;
        private System.Windows.Forms.ColumnHeader columnHeaderName;
        private System.Windows.Forms.ColumnHeader columnHeaderType;
        private System.Windows.Forms.ColumnHeader columnHeaderSize;
        private System.Windows.Forms.ColumnHeader columnHeaderLastModifyTime;
        private System.Windows.Forms.ColumnHeader columnHeaderCreateTime;
        private System.Windows.Forms.ColumnHeader columnHeaderLastAccessTime;
        private System.Windows.Forms.ColumnHeader columnHeaderAttribute;
        private System.Windows.Forms.ToolStripMenuItem ParentToolStripMenuItem;
        private System.Windows.Forms.SplitContainer splitContainerControl;
        private System.Windows.Forms.TextBox textBoxCurrentPath;
        private System.Windows.Forms.Button buttonEnter;
        private System.Windows.Forms.ToolStripMenuItem OpenInSysExplorerToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem FilterToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem FilterAllToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem FilterDirectoryToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem FilterFileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem FilterPictureToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem FilterVideoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem FilterAudioToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem FilterDocumentToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem FilterExecuableToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem FilterCompressToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem RefereshDisplayToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem OpenLocalDirectoryToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem StartWithParamToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem RunOnCmdlineToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem OpenCmdInHereToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem SpcificalFloderToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem JumpToDesktopToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem JumpToMyDocumentToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem JumpToMyPictureToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem JumpToMyVideoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem JumpToMyFavorateToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem JumpToMyMusicToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem OpenItByNewWindowToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem CopySelectedToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem CutSelectedToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem PaustSelectedToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem DeleteSelectedToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem RenameSelectedToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem SelectedAllToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem SelectedNothingToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem SelectedAntiFaceToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem TouchNewToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripMenuItem TouchNewFloderToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem TouchNewTxtFileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem TouchNewOtherFileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem TouchNewBatFileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem TouchNewClangFileGroupToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem TouchNewCppFileGroupToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem TouchNewJavaFileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem TouchNewPythonFileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem AnaliesFilesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem AnaliesFileOnlyToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem AnaliesFlodersInfoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem SortManageToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem FilterOnlyRegularUserToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem RaiseSortModeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem DescSortModeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem SortTypeNoneToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem OpenItByNotepadToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem CopyFullPathToClipbordToolStripMenuItem;
        private System.Windows.Forms.SplitContainer splitContainerHeadLine;
        private System.Windows.Forms.Button buttonSearch;
        private System.Windows.Forms.TextBox textBoxSearchContent;
        private System.Windows.Forms.Panel panelSearch;
        private System.Windows.Forms.StatusStrip statusStripMain;
        private System.Windows.Forms.Panel panelMainView;
        private System.Windows.Forms.ToolStripStatusLabel StateTipstoolStripStatusLabel;
        private System.Windows.Forms.ToolStripMenuItem RandomSelectNumToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem PowerProToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ProMkdirsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem NameToUpperToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem NameToLowerToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem NameUnifySuffixToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripMenuItem NameHeadAddNumberToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem NameTialAddNumberToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem NameHeadAddTimeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem NameTialAddTimeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem NameHeadAddDateToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem NameTialAddDateToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem NameHeadAddStringToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem NameTialAddStringToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem AttributeEditorToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem AttriAddReadOnlyToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem AttriCancelReadOnlyToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem AttriAddHideToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem AttriCancelHideToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem FilterLinkFileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem FilterLibDllToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem RunCmdAsArgumentToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem RunCmdAllAsArgumentsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem RunCmdDirectHereToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator5;
        private System.Windows.Forms.ToolStripMenuItem JumpToMyComputerToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ShowFloderCheckStateToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator6;
        private System.Windows.Forms.ColumnHeader columnHeaderFileCode;
        private System.Windows.Forms.ToolStripMenuItem AnaliesFileCheckCodeFToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ToPreviousHistoryToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ToNextHistoryToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem NameReplaceStringToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ChoiceOpenMethodToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem SeniorToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem CleanEmptyDirectoryToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem CleanEmptyFileToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator7;
        private System.Windows.Forms.ToolStripMenuItem CleanFilesOfSuffixiesToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator8;
        private System.Windows.Forms.ToolStripMenuItem WindowToTopmostToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem WindowToTransparentToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem WindowTransParentRateToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem WindowWhiteBecomeFullTransparentToolStripMenuItem;

    }
}

