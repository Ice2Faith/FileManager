using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Diagnostics;
using System.Collections;

using Microsoft.VisualBasic;
using Microsoft.Win32;

namespace 文件分析仪
{
    
    public partial class FormMain : Form
    {
        class FileItemInfo
        {
            public string path;
            public string name;
            public string extension;
            public bool isFile;
            public long size;
            public string type;
            public FileAttributes attribute;
            public DateTime createTime;
            public DateTime lastWriteTime;
            public DateTime lastAccessTime;
            public string checkCode;
            
            public FileItemInfo(string path,bool needDir=false,bool needFileCode=false)
            {
                this.path = path;
                FileInfo fi = new FileInfo(path);
                DirectoryInfo di = new DirectoryInfo(path);
                this.name = fi.Name;
                this.extension = fi.Extension;
                this.isFile = fi.Exists;
  
                if(this.isFile)
                {
                    this.size = fi.Length;
                    this.type = fi.Extension + "文件";
                    this.attribute = fi.Attributes;
                    this.createTime = fi.CreationTimeUtc;
                    this.lastWriteTime = fi.LastWriteTimeUtc;
                    this.lastAccessTime = fi.LastAccessTimeUtc;
                    if (needFileCode)
                    {;
                        int pckcode=getFileCheckSumCode(fi);
                       // this.checkCode = String.Format("{0:X8}-{1:D3}",pckcode,(long)(pckcode&0xffffffff)%1000); 
                        this.checkCode = String.Format("{0:D3}-{1:X8}", (long)(pckcode & 0xffffffff) % 1000, pckcode); 
                    }
                    else
                        this.checkCode = "-";
                }
                else
                {
                    this.size = 0;
                    this.type = getFloderType(di, "文件夹");
                    this.attribute = FileAttributes.Directory;
                    this.createTime = di.CreationTimeUtc;
                    this.lastAccessTime = new DateTime(0);
                    this.lastWriteTime = new DateTime(0);
                    this.checkCode = "-";
                    if(needDir)
                    {
                        this.lastAccessTime = new DateTime(0);
                        this.lastWriteTime = new DateTime(0);
                        try
                        {
                            getDirectoryInfos(this.path);
                        }
                        catch (Exception)
                        {
                            
                            //throw;
                        }
                        
                    }
                }
            }
            public  void getDirectoryInfos(string path)
            {
                DirectoryInfo fdir = new DirectoryInfo(path);
                if (fdir.Exists == false)
                    return;
                foreach(FileInfo file in fdir.GetFiles())
                {
                    this.size += file.Length;
                    if (file.LastAccessTimeUtc > this.lastAccessTime)
                        this.lastAccessTime = file.LastAccessTimeUtc;
                    if (file.LastWriteTimeUtc > this.lastWriteTime)
                        this.lastWriteTime = file.LastWriteTimeUtc;
                }
                foreach (DirectoryInfo dir in fdir.GetDirectories())
                {
                    getDirectoryInfos(dir.FullName);
                }
            }
            public override string ToString()
            {
                return this.path;
            }
        }

        private  const string PATH_COMPUTER = "Computer";
        private string m_currentPath = PATH_COMPUTER;
        public enum FilterType
        {
            All = 0,
            OnlyRegular=1,
            OnlyDirectory = 2,
            OnlyFile = 3,
            Picture = 4,
            Video = 5,
            Audio = 6,
            Document = 7,
            Execuable = 8,
            Compress=9,
            LinkFile=10,
            LibDll=11,
           
        }
        private FilterType m_filterType = FilterType.All;

        public enum SortType
        {
            None,
            Name,
            Type,
            Size,
            Attr,
            LModify,
            Create,
            LAccess,
            CheckCode,
        }
        private SortType m_sortType=SortType.None;
        private bool m_isSortRaise = true;


        private static string[] g_clipbordItems = null;
        public enum ClipType { None,Copy, Cut };
        private static ClipType g_clipType = ClipType.None;

        private bool m_isAnaliesDirectory = false;
        private bool m_isNeedFileCheckCode = false;

        private LinkedList<string> m_historyPathList = new LinkedList<string>();
        private LinkedListNode<string> m_currentHistoryNode = null;
        private void addHistoryPath(string path)
        {
            if(m_currentHistoryNode==null)
            {
                m_historyPathList.AddLast(path);
                m_currentHistoryNode = m_historyPathList.Last;
            }
            else
            {
                string previous = m_currentHistoryNode.Previous==null?"":m_currentHistoryNode.Previous.Value;
                string next = m_currentHistoryNode.Next == null ? "" : m_currentHistoryNode.Next.Value;
                if(path!=previous && path!=next)
                {
                    m_historyPathList.AddAfter(m_currentHistoryNode, path);
                    m_currentHistoryNode = m_currentHistoryNode.Next;
                }
            }
        }


        private string getNextHistoryPath(string defPath)
        {
            if(m_currentHistoryNode.Next==null)
            {
                addHistoryPath(defPath);
                return defPath;
            }
            m_currentHistoryNode = m_currentHistoryNode.Next;
            return m_currentHistoryNode.Value;
        }

        private string getPreviousHistoryPath(string defPath)
        {
            if (m_currentHistoryNode.Previous == null)
            {
                addHistoryPath(defPath);
                return defPath;
            }
            m_currentHistoryNode = m_currentHistoryNode.Previous;
            return m_currentHistoryNode.Value;
        }

        private void ToPreviousHistoryPath()
        {
            string path = getPreviousHistoryPath(m_currentPath);
            if (path == PATH_COMPUTER)
                showDirvers();
            else
                showDirectory(path);
        }
        private void ToPreviousHistoryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ToPreviousHistoryPath();
        }

        private void ToNextHistoryPath()
        {
            string path = getNextHistoryPath(m_currentPath);
            if (path == PATH_COMPUTER)
                showDirvers();
            else
                showDirectory(path);
        }

        private void ToNextHistoryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ToNextHistoryPath();
        }

        public FormMain()
        {
            InitializeComponent();
        }

        private void FormMain_Load(object sender, EventArgs e)
        {
            this.Size = new Size(1080, 720);
            showDirvers();
            this.textBoxCurrentPath.Text = m_currentPath;

            this.AnaliesFileOnlyToolStripMenuItem.Checked = true;
            this.SortTypeNoneToolStripMenuItem.Checked = true;
            this.JumpToDesktopToolStripMenuItem_Click(this, null);

            this.ShowFloderCheckStateToolStripMenuItem.Checked = true;

            this.StateTipstoolStripStatusLabel.Text = "就绪";
        }

        private void listViewFiles_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                foreach(ListViewItem it in this.listViewFiles.SelectedItems)
                {
                    string selPath = it.Tag.ToString().Trim();
                    if (new DirectoryInfo(selPath).Exists)
                    {
                        showDirectory(selPath);
                    }
                    else
                    {
                        Process.Start(selPath);
                    }
                }
            }
            catch (Exception)
            {
                
                //throw;
            }
           
        }

        /////////////////////////////////////////////////////////////////////////
        private void refreshCurrentDirectory()
        {
            if (m_currentPath == PATH_COMPUTER)
                showDirvers();
            else
            {
                showDirectory(m_currentPath);
            }
        }
        private string[] getFilterExtendsArray(FilterType type)
        {
            string[] pictures = { ".jpg",
                                ".jpeg",
                                ".png",
                                ".gif",
                                ".tif",
                                ".bmp",
                                ".ico",
                                ".raw",
                                ".exif",
                                ".webp",
                                ".wmf",
                                ".svg",
                                ".psd"};
            string[] videos = { ".mp4",
                              ".mkv",
                              ".rmvb",
                              ".flv",
                              ".avi",
                              ".mov",
                              ".wmv",
                              ".3gp",
                              ".yuv"};
            string[] audios ={".mp3",
                            ".ogg",
                            ".wav",
                            ".aac",
                            ".pcm",
                            ".flac",
                            ".wma",
                            ".vqf",
                            ".amr",
                            ".ape"};
            string[] documents = { ".txt",
                                 ".log",
                                 ".doc",
                                 ".docx",
                                 ".xls",
                                 ".xlsx",
                                 ".ppt",
                                 ".pptx",
                                 ".pdf",
                                 ".html",
                                 ".htm",
                                 ".xml",
                                 ".json",
                                 ".php",
                                 ".asp",
                                 ".config",
                                 ".c",
                                 ".h",
                                 ".cpp",
                                 ".hpp",
                                 ".asm",
                                 ".py",
                                 ".java",
                                 ".cs",
                                 ".ini",
                                 ".bat",
                                 ".sh",
                                 ".css",
                                 ".js"};
            string[] execuables = { ".exe",
                                  ".msc",
                                  ".elf",
                                  ".apk",
                                  ".bat",
                                  ".jar",
                                  ".py",
                                  ".sh",
                                  ".class"};
            string[] compresses = { ".zip",
                                  ".rar",
                                  ".gz",
                                  ".tar",
                                  ".7z",
                                  ".iso",
                                  ".apk",
                                  ".bin",
                                  ".zipx",
                                  ".tgz",
                                  ".xz",
                                  ".war",
                                  ".img",
                                  ".wim",
                                  ".udf"};
            string[] links = { ".lnk"};
            string[] libdlls = { ".lib",
                               ".dll",
                               ".sys",
                               ".so",
                               ".a",};
            string[] ret = null;
            if(type==FilterType.Picture)
            {
                ret = pictures;
            }
            else if(type==FilterType.Video)
            {
                ret = videos;
            }
            else if (type == FilterType.Audio)
            {
                ret = audios;
            }
            else if (type == FilterType.Document)
            {
                ret = documents;
            }
            else if (type == FilterType.Execuable)
            {
                ret = execuables;
            }
            else if (type == FilterType.Compress)
            {
                ret = compresses;
            }
            else if (type == FilterType.LinkFile)
            {
                ret = links;
            }
            else if (type == FilterType.LibDll)
            {
                ret = libdlls;
            }
            return ret;
        }
        private bool isPassedFilter(string path)
        {
            if(m_filterType==FilterType.All)
            {
                return true;
            }
            else if (m_filterType == FilterType.OnlyRegular)
            {
                FileInfo fsi = new FileInfo(path);
                DirectoryInfo dsi = new DirectoryInfo(path);
                if(fsi.Exists)
                {
                    if (((int)fsi.Attributes & (int)FileAttributes.Hidden )!=0 || ((int)fsi.Attributes & (int)FileAttributes.System) !=0)
                        return false;
                }
                else
                {
                    if (((int)dsi.Attributes & (int)FileAttributes.Hidden) != 0 || ((int)dsi.Attributes & (int)FileAttributes.System) != 0)
                        return false;
                }
                return true;

            }
            else if (m_filterType == FilterType.OnlyDirectory)
            {
                return new DirectoryInfo(path).Exists;
            }else if(m_filterType==FilterType.OnlyFile)
            {
                return new FileInfo(path).Exists;
            }else
            {
                string[] filter = getFilterExtendsArray(m_filterType);
                if (filter == null)
                    return true;


                bool ret = false;
                FileInfo pfile=new FileInfo(path);
                if (pfile.Exists == false)
                {
                    if (this.ShowFloderCheckStateToolStripMenuItem.Checked &&  new DirectoryInfo(path).Exists)
                        return true;
                    return false;
                }
                   
                string ptil=pfile.Extension.ToLower();
                foreach(string til in filter)
                {
                    if(til==ptil)
                    {
                        ret = true;
                        break;
                    }
                }
                return ret;
            }
            
        }
        private void updateCurrentPath(string path)
        {
            addHistoryPath(path);

            m_currentPath = path;
            this.textBoxCurrentPath.Text = m_currentPath;

        }
        private static string getFloderType(DirectoryInfo dir,string tips="文件夹")
        {
            FileSystemInfo[] flinfos = null;
            try
            {
                flinfos=dir.GetFileSystemInfos();
            }
            catch (Exception)
            {
                
                //throw;
            }
            int len = 0;
            if (flinfos != null)
                len=flinfos.Length;
            return tips+"[" +len+ "]";
        }

        private static int getFileCheckSumCode(FileInfo file)
        {
            int ret = 0;
            if (file.Exists == false)
                return 0;
            try
            {
                ret = (int)(file.Length*3/7);
                FileStream fs = file.OpenRead();
                if (fs == null || fs.CanRead == false)
                    return ret;

                int fac = 0x23571113;
                int temp = 0;
                while ((temp = fs.ReadByte())>=0)
                {

                    ret = (int)(ret * 7 + (temp * 31)) ^ fac;
                    fac = (int)(fac + 19);

                }
                fs.Close();
                return ret;
            }
            catch (Exception)
            {
                return ret;   
                //throw;
            }
            return ret;
        }
        private void showDirvers()
        {
            updateCurrentPath(PATH_COMPUTER);

            this.listViewFiles.Items.Clear();
            DriveInfo[] driveInfos = DriveInfo.GetDrives();
            foreach (DriveInfo driveInfo in driveInfos)
            {
                ListViewItem tn = new ListViewItem();
                try
                {
                    tn.Text = driveInfo.VolumeLabel + "(" + driveInfo.Name.Substring(0, 2) + ")";
                }
                catch (Exception)
                {
                    tn.Text = "(" + driveInfo.Name.Substring(0, 2) + ")";

                }

                tn.Tag = driveInfo.RootDirectory;
                tn.ImageKey = "floder";
                tn.SubItems.Add(getFloderType(driveInfo.RootDirectory,"驱动器"));
                tn.SubItems.Add("-");
                tn.SubItems.Add("磁盘根");
                tn.SubItems.Add("-");
                tn.SubItems.Add("-");
                tn.SubItems.Add("-");
                tn.SubItems.Add("-");
                this.listViewFiles.Items.Add(tn);

            }

            this.StateTipstoolStripStatusLabel.Text = "总："+listViewFiles.Items.Count;
        }
        private void showDirectory(string path)
        {
            updateCurrentPath(path);

            string searchContent = this.textBoxSearchContent.Text.Trim();
            string[] content=searchContent.Split(new string[]{" ","\t","\n","\r","\v"}, StringSplitOptions.RemoveEmptyEntries);
            if (searchContent == null || searchContent.Length==0)
                getAllDirectoryItems(path);
            else
            {
                this.listViewFiles.Items.Clear();
                this.StateTipstoolStripStatusLabel.Text = "搜索中...";
                for (int i = 0; i < content.Length;i++ )
                {
                    content[i] = content[i].ToLower();
                }
                getSearchDirectoryItems(path, content);
                this.StateTipstoolStripStatusLabel.Text = "搜索结束";
            }


            this.StateTipstoolStripStatusLabel.Text = "总：" + listViewFiles.Items.Count;

            if (m_sortType == SortType.None)
                return;

            int itemsCount=listViewFiles.Items.Count;
            ListViewItem[] itemsArr=new ListViewItem[itemsCount];
            for (int i = 0; i < itemsArr.Length;i++ )
            {
                itemsArr[i]=listViewFiles.Items[i];
            }
            sortItemsArray(itemsArr);

            listViewFiles.Items.Clear();
           
            listViewFiles.Items.AddRange(itemsArr);

            
        }
        bool isSearchContent(string path,string[] content)
        {
            path = path.ToLower();
            for (int i = 0; i < content.Length;i++ )
            {
                if(path.IndexOf(content[i])>=0)
                {
                    return true;
                }
            }
            return false;
        }
        void getSearchDirectoryItems(string path,string[] content)
        {
            try
            {
                DirectoryInfo dir = new DirectoryInfo(path);
                foreach (DirectoryInfo pdir in dir.GetDirectories())
                {
                     if (isPassedFilter(pdir.FullName)) 
                    {
                        if (isSearchContent(pdir.Name, content))
                        {
                            ListViewItem item = new ListViewItem();
                            FileItemInfo finfo = new FileItemInfo(pdir.FullName, m_isAnaliesDirectory,m_isNeedFileCheckCode);
                            item.Text = finfo.name;
                            item.Tag = finfo;
                            item.ImageKey = "floder";
                            item.SubItems.Add(finfo.type);

                            item.SubItems.Add(fileSizeToString(finfo.size));
                            item.SubItems.Add(fileAttributeToString(finfo.attribute));
                            item.SubItems.Add(finfo.lastWriteTime.ToString());
                            item.SubItems.Add(finfo.createTime.ToString());
                            item.SubItems.Add(finfo.lastAccessTime.ToString());
                            item.SubItems.Add(finfo.checkCode);
                            this.listViewFiles.Items.Add(item);
                        }
                        getSearchDirectoryItems(pdir.FullName,content);
                       
                    }

                }

                foreach (FileInfo pfile in dir.GetFiles())
                {
                    if (isPassedFilter(pfile.FullName)) 
                    {
                       if (isSearchContent(pfile.Name, content)) 
                        {
                                ListViewItem item = new ListViewItem();
                                FileItemInfo finfo = new FileItemInfo(pfile.FullName, m_isAnaliesDirectory,m_isNeedFileCheckCode);
                                item.Text = pfile.Name;
                                item.Tag = finfo;
                                if (pfile.Extension == null || pfile.Extension == "")
                                {
                                    item.ImageKey = "unkown";
                                }
                                else
                                {
                                    if (this.imageListMain.Images.Keys.Contains(pfile.Extension) == false)
                                    {
                                        Icon icon = System.Drawing.Icon.ExtractAssociatedIcon(pfile.FullName);
                                        this.imageListMain.Images.Add(pfile.Extension, icon);
                                    }
                                    item.ImageKey = pfile.Extension;
                                }
                                item.SubItems.Add(finfo.type);

                                item.SubItems.Add(fileSizeToString(finfo.size));
                                item.SubItems.Add(fileAttributeToString(finfo.attribute));
                                item.SubItems.Add(finfo.lastWriteTime.ToString());
                                item.SubItems.Add(finfo.createTime.ToString());
                                item.SubItems.Add(finfo.lastAccessTime.ToString());
                                item.SubItems.Add(finfo.checkCode);
                                this.listViewFiles.Items.Add(item);
                        }
                     
                    }
                }
            }
            catch (Exception)
            {

                // throw;
            }
            
        }
        void getAllDirectoryItems(string path)
        {

            this.listViewFiles.Items.Clear();
            try
            {
                DirectoryInfo dir = new DirectoryInfo(path);
                foreach (DirectoryInfo pdir in dir.GetDirectories())
                {
                    if (isPassedFilter(pdir.FullName))
                    {
                        ListViewItem item = new ListViewItem();
                        FileItemInfo finfo = new FileItemInfo(pdir.FullName, m_isAnaliesDirectory,m_isNeedFileCheckCode);
                        item.Text = finfo.name;
                        item.Tag = finfo;
                        item.ImageKey = "floder";
                        item.SubItems.Add(finfo.type);

                        item.SubItems.Add(fileSizeToString(finfo.size));
                        item.SubItems.Add(fileAttributeToString(finfo.attribute));
                        item.SubItems.Add(finfo.lastWriteTime.ToString());
                        item.SubItems.Add(finfo.createTime.ToString());
                        item.SubItems.Add(finfo.lastAccessTime.ToString());
                        item.SubItems.Add(finfo.checkCode);
                        this.listViewFiles.Items.Add(item);
                    }

                }

                foreach (FileInfo pfile in dir.GetFiles())
                {
                    if (isPassedFilter(pfile.FullName))
                    {
                        ListViewItem item = new ListViewItem();
                        FileItemInfo finfo = new FileItemInfo(pfile.FullName, m_isAnaliesDirectory,m_isNeedFileCheckCode);
                        item.Text = pfile.Name;
                        item.Tag = finfo;
                        if (pfile.Extension == null || pfile.Extension == "")
                        {
                            item.ImageKey = "unkown";
                        }
                        else
                        {
                            if (this.imageListMain.Images.Keys.Contains(pfile.Extension) == false)
                            {
                                Icon icon = System.Drawing.Icon.ExtractAssociatedIcon(pfile.FullName);
                                this.imageListMain.Images.Add(pfile.Extension, icon);
                            }
                            item.ImageKey = pfile.Extension;
                        }
                        item.SubItems.Add(finfo.type);

                        item.SubItems.Add(fileSizeToString(finfo.size));
                        item.SubItems.Add(fileAttributeToString(finfo.attribute));
                        item.SubItems.Add(finfo.lastWriteTime.ToString());
                        item.SubItems.Add(finfo.createTime.ToString());
                        item.SubItems.Add(finfo.lastAccessTime.ToString());
                        item.SubItems.Add(finfo.checkCode);
                        this.listViewFiles.Items.Add(item);
                    }
                }
            }
            catch (Exception)
            {

                // throw;
            }
        }
        private long comparator4Sort(ListViewItem it1,ListViewItem it2)
        {
            FileItemInfo info1=(FileItemInfo)it1.Tag;
            FileItemInfo info2=(FileItemInfo)it2.Tag;
            if(m_sortType==SortType.None)
            {
                return -1;
            }
            else if(m_sortType==SortType.Name)
            {
                string st1 = info1.name.ToLower();
                string st2 = info2.name.ToLower();
                return st1.CompareTo(st2);
            }
            else if(m_sortType==SortType.Type)
            {
                return info1.type.CompareTo(info2.type);
            }
            else if(m_sortType==SortType.Attr)
            {
                return (long)info1.attribute - (long)info2.attribute;
            }
            else if(m_sortType==SortType.Size)
            {
                return info1.size - info2.size;
            }
            else if(m_sortType==SortType.LModify)
            {
                return info1.lastWriteTime.Ticks - info2.lastWriteTime.Ticks;
            }
            else if(m_sortType==SortType.Create)
            {
                return info1.createTime.Ticks - info2.createTime.Ticks;
            }
            else if(m_sortType==SortType.LAccess)
            {
                return info1.lastAccessTime.Ticks - info2.lastAccessTime.Ticks;
            }
            else if(m_sortType==SortType.CheckCode)
            {
                return info1.checkCode.CompareTo(info2.checkCode);
            }
            else
            {
                return 0;
            }
        }
        private void sortItemsArray(ListViewItem[] arr)
        {
            for(int i=0;i<arr.Length;i++)
            {
                bool swap = false;
                for(int j=1;j<arr.Length;j++)
                {
                    if (comparator4Sort(arr[j-1],arr[j])>0 == m_isSortRaise)
                    {
                        ListViewItem tp = arr[j - 1];
                        arr[j - 1] = arr[j];
                        arr[j] = tp;
                        swap=true;
                    }
                }
                if (swap == false)
                    break;
            }
        }
        private string fileAttributeToString(FileAttributes attr)
        {
            string ret = "";
            if((((int)attr)&((int)FileAttributes.Normal))!=0)
            {
                ret += "[常规]";
            }
            if ((((int)attr) & ((int)FileAttributes.Compressed)) != 0)
            {
                ret += "[压缩]";
            }
            if ((((int)attr) & ((int)FileAttributes.Device)) != 0)
            {
                ret += "[设备]";
            }
            if ((((int)attr) & ((int)FileAttributes.Directory)) != 0)
            {
                ret += "[目录]";
            }
            if ((((int)attr) & ((int)FileAttributes.Encrypted)) != 0)
            {
                ret += "[加密]";
            }
            if ((((int)attr) & ((int)FileAttributes.Hidden)) != 0)
            {
                ret += "[隐藏]";
            }
            if ((((int)attr) & ((int)FileAttributes.ReadOnly)) != 0)
            {
                ret += "[只读]";
            }
            if ((((int)attr) & ((int)FileAttributes.System)) != 0)
            {
                ret += "[系统]";
            }

            if ((((int)attr) & ((int)FileAttributes.Temporary)) != 0)
            {
                ret += "临时";
            }
            if ((((int)attr) & ((int)FileAttributes.IntegrityStream)) != 0)
            {
                ret += "[完整性支持]";
            }
            if ((((int)attr) & ((int)FileAttributes.NoScrubData)) != 0)
            {
                ret += "[排除完整性]";
            }
            if ((((int)attr) & ((int)FileAttributes.NotContentIndexed)) != 0)
            {
                ret += "[无内容索引]";
            }
            if ((((int)attr) & ((int)FileAttributes.Offline)) != 0)
            {
                ret += "[脱机状态]";
            }
            
            if ((((int)attr) & ((int)FileAttributes.ReparsePoint)) != 0)
            {
                ret += "[重新分析点]";
            }

            if ((((int)attr) & ((int)FileAttributes.SparseFile)) != 0)
            {
                ret += "[稀疏]";
            }


            if (ret.Length == 0)
                ret = "[文件]";
            return ret;
        }
        private string fileSizeToString(long size)
        {
            string ret = "";
            if(size<1024)
            {
                ret = size + " Byte";
            }
            else if(size<1024*1024)
            {
                ret = (size/1024) + " Kb";
            }
            else if (size < 1024 * 1024*1024)
            {
                ret = (size/1024/1024) + " Mb";
            }
            else //if (size < 1024 * 1024*1024*1024L)
            {
                ret = (size/1024/1024/1024) + " Gb";
            }
            return ret;
        }

        private void JumpToParentDirectory()
        {
            if (m_currentPath == PATH_COMPUTER)
            {
                showDirvers();
                return;
            }
            DirectoryInfo pdir = new DirectoryInfo(m_currentPath).Parent;
            if (pdir != null && pdir.Exists)
            {
                showDirectory(pdir.FullName);
            }
            else
            {
                showDirvers();
            }
        }
        private void ParentToolStripMenuItem_Click(object sender, EventArgs e)
        {
            JumpToParentDirectory();
        }

        private void DisplayIconToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.listViewFiles.View = View.LargeIcon;
        }

        private void DisplayDetialToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.listViewFiles.View = View.Details;
        }

        private void DisplayListToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.listViewFiles.View = View.List;
        }

        private void DisplayTileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.listViewFiles.View = View.Tile;
        }

        private void FormMain_SizeChanged(object sender, EventArgs e)
        {
            this.splitContainerControl.SplitterDistance = this.textBoxCurrentPath.Height;
            this.splitContainerHeadLine.SplitterDistance = (int)(this.splitContainerHeadLine.Width * 0.66);
        }

        private void EnterPath()
        {
            string ppath = this.textBoxCurrentPath.Text.Trim();
            if (ppath.Length == 0 || ppath == PATH_COMPUTER)
            {
                showDirvers();
            }
            else if (new DirectoryInfo(ppath).Exists)
            {
                showDirectory(ppath);
            }
        }
        private void buttonEnter_Click(object sender, EventArgs e)
        {
            EnterPath();
        }

        private void OpenInSysExplorerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(this.listViewFiles.SelectedItems.Count==0)
            {
                if (new DirectoryInfo(m_currentPath).Exists)
                {
                    Process.Start("explorer", m_currentPath);
                }
            }
            else
            {
                foreach(ListViewItem it in listViewFiles.SelectedItems)
                {
                    Process.Start("explorer", it.Tag.ToString());
                }
            }
            
        }

        private void FilterAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            m_filterType = FilterType.All;
            refreshCurrentDirectory();
        }

        private void FilterOnlyRegularUserToolStripMenuItem_Click(object sender, EventArgs e)
        {
            m_filterType = FilterType.OnlyRegular;
            refreshCurrentDirectory();
        }
        private void FilterDirectoryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            m_filterType = FilterType.OnlyDirectory;
            refreshCurrentDirectory();
        }

        private void FilterFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            m_filterType = FilterType.OnlyFile;
            refreshCurrentDirectory();
        }

        private void FilterPictureToolStripMenuItem_Click(object sender, EventArgs e)
        {
            m_filterType = FilterType.Picture;
            refreshCurrentDirectory();
        }

        private void FilterVideoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            m_filterType = FilterType.Video;
            refreshCurrentDirectory();
        }

        private void FilterAudioToolStripMenuItem_Click(object sender, EventArgs e)
        {
            m_filterType = FilterType.Audio;
            refreshCurrentDirectory();
        }

        private void FilterDocumentToolStripMenuItem_Click(object sender, EventArgs e)
        {
            m_filterType = FilterType.Document;
            refreshCurrentDirectory();
        }

        private void FilterExecuableToolStripMenuItem_Click(object sender, EventArgs e)
        {
            m_filterType = FilterType.Execuable;
            refreshCurrentDirectory();
        }

        private void FilterCompressToolStripMenuItem_Click(object sender, EventArgs e)
        {
            m_filterType = FilterType.Compress;
            refreshCurrentDirectory();
        }
        private void FilterLinkFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            m_filterType = FilterType.LinkFile;
            refreshCurrentDirectory();
        }
        private void FilterLibDllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            m_filterType = FilterType.LibDll;
            refreshCurrentDirectory();
        }

        private void RefereshDisplayToolStripMenuItem_Click(object sender, EventArgs e)
        {
            refreshCurrentDirectory();
        }

        private void OpenLocalDirectoryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (listViewFiles.SelectedItems.Count == 0)
                return;
            foreach(ListViewItem it in listViewFiles.SelectedItems)
            {
                DirectoryInfo parent = new DirectoryInfo(it.Tag.ToString().Trim()).Parent;
                showDirectory(parent.FullName);
            }
        }

        private void StartWithParamToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (listViewFiles.SelectedItems.Count == 0)
                return;
            string str = Interaction.InputBox("请输入命令行参数：\n实际上执行的命令：\n\t选中的每一项的完整路径 输入的参数", "带参数启动输入框", "", -1, -1);
            str = str.Trim();
            foreach (ListViewItem it in listViewFiles.SelectedItems)
            {
                ProcessStartInfo sinfo = new ProcessStartInfo();
                sinfo.FileName = it.Tag.ToString();
                sinfo.Arguments = str;
                sinfo.WorkingDirectory = m_currentPath;
                Process.Start(sinfo);
            }
        }

        private void RunOnCmdlineToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (listViewFiles.SelectedItems.Count == 0)
                return;
            string str = Interaction.InputBox("请输入命令行参数：\n"+
                "这实际上是对每一项执行：\n"+
                "cmd /k 选中的每一项完整路径 你输入的参数", "带参数启动输入框", "", -1, -1);
            str = str.Trim();
            foreach (ListViewItem it in listViewFiles.SelectedItems)
            {
                ProcessStartInfo sinfo = new ProcessStartInfo();
                sinfo.FileName = "cmd";
                sinfo.Arguments = "/k "+it.Tag.ToString()+" "+str;
                sinfo.WorkingDirectory = m_currentPath;
                Process.Start(sinfo);
            }
        }
        private void RunCmdAsArgumentToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (listViewFiles.SelectedItems.Count == 0)
                return;
            string str = Interaction.InputBox("请输入运行命令，其中[%$]符号代表填充的占位符，\n"+
                "这个占位符即代表你当前选中的每一项的完整路径\n"+
                "这将会将每一项带入命令格式中进行运行：\n"+
                "实际上执行：\n"+
                "cmd /c copy \"D:\\a.txt\" D:\\test\\\n"+
                "例如：\n"+
                "cmd /c copy %$ D:\\test\\", "命令输入框", "", -1, -1);
            str = str.Trim();
            string[] cmds = str.Split(new string[] { " ", "\t", "\n", "\r" }, 2, StringSplitOptions.RemoveEmptyEntries);
            if (cmds.Length < 2)
            {
                MessageBox.Show("参数不满足条件，至少一个运行程序和一个参数","参数提示");
                return;
            }

            if(cmds[1].IndexOf("%$")<0)
            {
                MessageBox.Show("参数不满足条件，未找到占位符","参数提示");
                return;
            }

            string program=cmds[0];
            string argsfmt=cmds[1].Replace("%$","\"{0}\"");

            foreach (ListViewItem it in listViewFiles.SelectedItems)
            {
                string args=String.Format(argsfmt,it.Tag.ToString());
                ProcessStartInfo sinfo = new ProcessStartInfo();
                sinfo.FileName = program;
                sinfo.Arguments = args;
                sinfo.WorkingDirectory = m_currentPath;
                Process.Start(sinfo);
            }
        }

        private void RunCmdAllAsArgumentsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (listViewFiles.SelectedItems.Count == 0)
                return;
            string str = Interaction.InputBox("请输入运行命令，其中[%$]符号代表填充的占位符，\n"+
                "这个占位符即代表你当前选中的每一项的完整路径的集合\n"+
                "这将会将每一项填入命令中占位符位置作为参数：\n"+
                "实际上执行：\n"+
                "压缩工具.exe D:\\save.zip \"D:\\a.txt\" \"D:\\b.txt\"\n"+
                "例如：\n压缩工具.exe %$ D:\\save.zip %$", "命令输入框", "", -1, -1);
            str = str.Trim();
            string[] cmds = str.Split(new string[] { " ", "\t", "\n", "\r" }, 2, StringSplitOptions.RemoveEmptyEntries);
            if (cmds.Length < 2)
            {
                MessageBox.Show("参数不满足条件，至少一个运行程序和一个参数", "参数提示");
                return;
            }

            if (cmds[1].IndexOf("%$") < 0)
            {
                MessageBox.Show("参数不满足条件，未找到占位符", "参数提示");
                return;
            }

            string program = cmds[0];
            string argsfmt = cmds[1].Replace("%$", "{0}");

            string argstr = "";
            foreach (ListViewItem it in listViewFiles.SelectedItems)
            {
                argstr += " \"" + it.Tag.ToString() + "\"";
            }
            string args = String.Format(argsfmt, argstr);

            ProcessStartInfo sinfo=new ProcessStartInfo();
            sinfo.FileName=program;
            sinfo.Arguments=args;
            sinfo.WorkingDirectory = m_currentPath;
            Process.Start(sinfo);
        }
        private void RunCmdDirectHereToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string str = Interaction.InputBox("请输入CMD命令:\n"+
                "多条命令使用[&&]符号拼接\n"+
                "例如：\n"+
                "color f5 && title CMDLINE", "命令输入框", "", -1, -1);
            ProcessStartInfo sinfo = new ProcessStartInfo();
            sinfo.WorkingDirectory = m_currentPath;
            sinfo.FileName = "cmd";
            sinfo.Arguments ="/c "+ str;
            sinfo.WindowStyle = ProcessWindowStyle.Hidden;
            Process.Start(sinfo);
        }
        private void OpenCmdInHereToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ProcessStartInfo info=new ProcessStartInfo();
            if (m_currentPath == PATH_COMPUTER)
                info.WorkingDirectory = "C:\\";
            else
                info.WorkingDirectory = m_currentPath;
            info.FileName="cmd";
            Process.Start(info);
        }


        private void JumpToSpecialFloder(string subName)
        {
            string pk = "HKEY_CURRENT_USER";
            string ck = "Software\\Microsoft\\Windows\\CurrentVersion\\Explorer\\User Shell Folders";

            string keyName = pk + "\\" + ck;

            string val = (string)Registry.GetValue(keyName, subName, "C:\\");
            showDirectory(val);
        }
        private void JumpToDesktopToolStripMenuItem_Click(object sender, EventArgs e)
        {
            JumpToSpecialFloder("Desktop");
        }

        private void JumpToMyComputerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            showDirvers();
        }

        private void JumpToMyDocumentToolStripMenuItem_Click(object sender, EventArgs e)
        {
            JumpToSpecialFloder("Personal");
        }

        private void JumpToMyPictureToolStripMenuItem_Click(object sender, EventArgs e)
        {
            JumpToSpecialFloder("My Pictures");
        }

        private void JumpToMyVideoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            JumpToSpecialFloder("My Video");
        }

        private void JumpToMyFavorateToolStripMenuItem_Click(object sender, EventArgs e)
        {
            JumpToSpecialFloder("Favorites");
        }

        private void JumpToMyMusicToolStripMenuItem_Click(object sender, EventArgs e)
        {
            JumpToSpecialFloder("My Music");
        }

        private void OpenItByNewWindowToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (listViewFiles.SelectedItems.Count == 0)
            {
                FormMain fm = new FormMain();
                fm.Show();
                fm.Text += " - 子窗口";
                fm.showDirectory(m_currentPath);
                return;
            }   
            foreach (ListViewItem it in listViewFiles.SelectedItems)
            {
                FormMain fm = new FormMain();
                fm.Show();
                fm.Text += " - 子窗口";
                fm.showDirectory(it.Tag.ToString());
            }
        }
        private void copySelectedItems()
        {
            int selCount = listViewFiles.SelectedItems.Count;
            if (selCount == 0)
                return;
            g_clipType = ClipType.Copy;
            g_clipbordItems = new string[selCount];
            for (int i = 0; i < selCount; i++)
            {
                g_clipbordItems[i] = listViewFiles.SelectedItems[i].Tag.ToString().Trim();
            }
        }
        private void CopySelectedToolStripMenuItem_Click(object sender, EventArgs e)
        {
            copySelectedItems();
        }
        private void cutSelectedItems()
        {
            int selCount = listViewFiles.SelectedItems.Count;
            if (selCount == 0)
                return;
            g_clipType = ClipType.Cut;
            g_clipbordItems = new string[selCount];
            for (int i = 0; i < selCount; i++)
            {
                g_clipbordItems[i] = listViewFiles.SelectedItems[i].Tag.ToString().Trim();
            }
        }
        private void CutSelectedToolStripMenuItem_Click(object sender, EventArgs e)
        {
            cutSelectedItems();
        }
        private void paustSelectedItems()
        {
            if (g_clipType != ClipType.None && g_clipbordItems != null)
            {
                foreach (string ppath in g_clipbordItems)
                {
                    FileInfo pfile = new FileInfo(ppath);
                    if (pfile.Exists)
                    {
                        if (g_clipType == ClipType.Copy)
                        {
                           // pfile.CopyTo(m_currentPath + "\\" + pfile.Name, true);
                            pfile.CopyTo(getUseableFileName(m_currentPath, getSingleFileNameFromFileInfo(pfile), pfile.Extension));
                        }
                        else if (g_clipType == ClipType.Cut)
                        {
                            //pfile.MoveTo(m_currentPath + "\\" + pfile.Name);
                            pfile.MoveTo(getUseableFileName(m_currentPath, getSingleFileNameFromFileInfo(pfile), pfile.Extension));
                        }
                    }
                    else
                    {
                        DirectoryInfo pdir = new DirectoryInfo(ppath);
                        if (pdir.Exists)
                        {
                            if (g_clipType == ClipType.Copy)
                            {
                                CopyDirectoryTo(pdir.FullName, m_currentPath + "\\" + pdir.Name);
                            }
                            else if (g_clipType == ClipType.Cut)
                            {
                                //pdir.MoveTo(m_currentPath + "\\" + pdir.Name);
                                pdir.MoveTo(getUseableFileName(m_currentPath, getSingleFileNameFromFileInfo(new FileInfo(ppath)), pdir.Extension));
                            }
                        }
                    }
                }

            }
            refreshCurrentDirectory();
            g_clipType = ClipType.None;
            g_clipbordItems = null;
        }
        private void PaustSelectedToolStripMenuItem_Click(object sender, EventArgs e)
        {
            paustSelectedItems();

        }
        private void CopyDirectoryTo(string srcPath,string destPath)
        {
            DirectoryInfo dstDir = new DirectoryInfo(destPath);
            dstDir.Create();

            DirectoryInfo srcDir=new DirectoryInfo(srcPath);
            foreach(FileInfo fi in srcDir.GetFiles())
            {
               // fi.CopyTo(destPath + "\\" + fi.Name, true);
                fi.CopyTo(getUseableFileName(destPath, getSingleFileNameFromFileInfo(fi), fi.Extension));
            }
            foreach(DirectoryInfo di in srcDir.GetDirectories())
            {
                CopyDirectoryTo(di.FullName, destPath + "\\" + di.Name);
            }
        }
        private void deleteSelectedItems()
        {
            int selCount = listViewFiles.SelectedItems.Count;
            if (selCount == 0)
                return;
            try
            {
                foreach (ListViewItem it in listViewFiles.SelectedItems)
                {
                    FileInfo file = new FileInfo(it.Tag.ToString().Trim());
                    if (file.Exists)
                    {
                        file.Delete();
                    }
                    else
                    {
                        DirectoryInfo dir = new DirectoryInfo(file.FullName);
                        dir.Delete(true);
                    }
                }

                refreshCurrentDirectory();
            }
            catch (Exception)
            {
                
                //throw;
            }
            
        }
        private void DeleteSelectedToolStripMenuItem_Click(object sender, EventArgs e)
        {
            deleteSelectedItems();
        }

        private void selectedAllItems()
        {
            foreach(ListViewItem it in listViewFiles.Items)
            {
                it.Selected = true;
            }
        }
        private void de_selectedAllItems()
        {
            foreach (ListViewItem it in listViewFiles.Items)
            {
                it.Selected = false;
            }
        }
        private void anti_selectedAllItems()
        {
            foreach (ListViewItem it in listViewFiles.Items)
            {
                it.Selected = !it.Selected;
            }
        }

        private void SelectedAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            selectedAllItems();
        }

        private void SelectedNothingToolStripMenuItem_Click(object sender, EventArgs e)
        {
            de_selectedAllItems();
        }

        private void SelectedAntiFaceToolStripMenuItem_Click(object sender, EventArgs e)
        {
            anti_selectedAllItems();
        }


        private void listViewFiles_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.C:
                    if (e.Control)
                    {
                        copySelectedItems();
                    }
                    break;
                case Keys.X:
                    if (e.Control)
                    {
                        cutSelectedItems();
                    }
                    break;
                case Keys.V:
                    if (e.Control)
                    {
                        paustSelectedItems();
                    }
                    break;
                case Keys.A:
                    if (e.Control)
                    {
                        selectedAllItems();
                    }
                    break;
                case Keys.Q:
                    if (e.Control)
                    {
                        de_selectedAllItems();
                    }
                    break;
                case Keys.W:
                    if (e.Control)
                    {
                        anti_selectedAllItems();
                    }
                    break;
                case Keys.Delete:
                    if (e.Control)
                    {
                        deleteSelectedItems();
                    }
                    break;
                case Keys.F5:
                    refreshCurrentDirectory();
                    break;
                case Keys.Escape:
                    JumpToParentDirectory();
                    break;
                case Keys.Left:
                    ToPreviousHistoryPath();
                    break;
                case Keys.Right:
                    ToNextHistoryPath();
                    break;
                case  Keys.F1:
                        MessageBox.Show("Copyright @ Ugex.Savelar -2020","文件分析仪");
                        break;
                    
            }
        }

        private void renameSelectedItems(string newName)
        {
             int selCount = listViewFiles.SelectedItems.Count;
            if (selCount == 0)
                return;
            if(selCount==1)
            {
                foreach (ListViewItem it in listViewFiles.SelectedItems)
                {
                    FileInfo file = new FileInfo(it.Tag.ToString().Trim());
                    if(file.Exists)
                    {
                        //file.MoveTo(file.DirectoryName +"\\"+ newName);
                        file.MoveTo(getUseableFileName(file.DirectoryName, getSingleFileNameFromFileInfo(new FileInfo(newName)), new FileInfo(newName).Extension));
                    }
                    else
                    {
                        DirectoryInfo dir = new DirectoryInfo(file.FullName);
                        //dir.MoveTo(dir.Parent.FullName + "\\" + newName);
                        dir.MoveTo(getUseableFileName(dir.Parent.FullName, getSingleFileNameFromFileInfo(new FileInfo(newName)), new FileInfo(newName).Extension));
                    }
                }
            }
            else
            {
                FileInfo pf=new FileInfo(newName);

                string pname = getSingleFileNameFromFileInfo(pf);

                foreach (ListViewItem it in listViewFiles.SelectedItems)
                {
                    FileInfo file = new FileInfo(it.Tag.ToString().Trim());
                    if (file.Exists)
                    {
                        //file.MoveTo(file.DirectoryName + "\\" + pname+file.Extension)
                        file.MoveTo(getUseableFileName(file.DirectoryName, pname, file.Extension));
                    }
                    else
                    {
                        DirectoryInfo dir = new DirectoryInfo(file.FullName);
                        //dir.MoveTo(dir.Parent.FullName + "\\" + pname+dir.Extension);
                        dir.MoveTo(getUseableFileName(dir.Parent.FullName, pname, dir.Extension));
                    }
                }
            }

            refreshCurrentDirectory();
        }

        private string getSingleFileNameFromFileInfo(FileInfo pf)
        {
            string pname = pf.Name;
            if (pf.Extension != null && pf.Extension.Length > 0)
                pname = pname.Remove(pf.Name.LastIndexOf(pf.Extension));
            return pname;
        }

        private string getUseableFileName(string parent,string name,string extension)
        {
            string ret = parent + "\\" + name + extension;
            if(new FileInfo(ret).Exists || new DirectoryInfo(ret).Exists)
            {
                int i = 1;
                while(new FileInfo(ret).Exists || new DirectoryInfo(ret).Exists)
                {
                    ret = parent + "\\" + name + "-" + i + extension;
                    i++;
                }
            }
            return ret;
        }
        private void RenameSelectedToolStripMenuItem_Click(object sender, EventArgs e)
        {
             int selCount = listViewFiles.SelectedItems.Count;
             if (selCount == 0)
                 return;
             listViewFiles.SelectedItems[0].BeginEdit();
        }


        private void listViewFiles_AfterLabelEdit(object sender, LabelEditEventArgs e)
        {
            renameSelectedItems(e.Label);
        }

        private void TouchNewFloderToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DirectoryInfo pdir = new DirectoryInfo(getUseableFileName(m_currentPath,"新建文件夹",""));
            pdir.Create();
           
            ListViewItem item = new ListViewItem();
            item.Text = pdir.Name;
            item.Tag = new FileItemInfo(pdir.FullName,m_isAnaliesDirectory,m_isNeedFileCheckCode);
            item.ImageKey = "floder";
            item.SubItems.Add(getFloderType(pdir, "文件夹"));
            item.SubItems.Add("-");
            item.SubItems.Add(fileAttributeToString(pdir.Attributes));
            item.SubItems.Add("-");
            item.SubItems.Add("-");
            item.SubItems.Add("-");
            this.listViewFiles.Items.Add(item);
            item.BeginEdit();
        }
        private void addNewFileItem(FileInfo pfile,bool needRename=false)
        {

            ListViewItem item = new ListViewItem();
            item.Text = pfile.Name;
            item.Tag = new FileItemInfo(pfile.FullName,m_isAnaliesDirectory,m_isNeedFileCheckCode);
            if (this.imageListMain.Images.Keys.Contains(pfile.Extension) == false)
            {
                Icon icon = System.Drawing.Icon.ExtractAssociatedIcon(pfile.FullName);
                this.imageListMain.Images.Add(pfile.Extension, icon);
            }
            item.ImageKey = pfile.Extension;
            item.SubItems.Add(pfile.Extension + "文件");
            item.SubItems.Add(fileSizeToString(pfile.Length));
            item.SubItems.Add(fileAttributeToString(pfile.Attributes));
            item.SubItems.Add(pfile.LastWriteTime.ToString());
            item.SubItems.Add(pfile.CreationTime.ToString());
            item.SubItems.Add(pfile.LastAccessTime.ToString());

            this.listViewFiles.Items.Add(item);
            if(needRename)
                item.BeginEdit();
        }
        private void TouchNewTxtFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FileInfo pfile = new FileInfo(getUseableFileName(m_currentPath, "文本文档", ".txt"));
            FileStream fs=pfile.Create();
            fs.Close();

            addNewFileItem(pfile,true);
        }

        private void TouchNewBatFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FileInfo pfile = new FileInfo(getUseableFileName(m_currentPath, "批处理文件", ".bat"));
            StreamWriter fs = pfile.CreateText();
            fs.WriteLine("@echo off");
            fs.WriteLine();
            fs.WriteLine("exit");
            fs.Close();

            addNewFileItem(pfile,true);
        }

        private void TouchNewClangFileGroupToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string str = Interaction.InputBox("请输入C语言文件名：", "文件名输入框", "", -1, -1);
            str = str.Trim();
            if (str.Length == 0)
                return;

            string upstr = str.ToUpper();
            FileInfo pfile = new FileInfo(getUseableFileName(m_currentPath, str, ".h"));
            StreamWriter fs = pfile.CreateText();
            fs.WriteLine("/*  */");
            fs.WriteLine("#ifndef _"+upstr+"_H_");
            fs.WriteLine("#define _"+upstr+"_H_");
            fs.WriteLine();
            fs.WriteLine("#endif // _"+upstr+"_H_");
            fs.WriteLine();
            fs.Close();

            addNewFileItem(pfile,false);

            pfile = new FileInfo(getUseableFileName(m_currentPath, str, ".c"));
            fs = pfile.CreateText();
            fs.WriteLine("/*  */");
            fs.WriteLine("#include\""+str+".h\"");
            fs.WriteLine("//#include<stdio.h>");
            fs.WriteLine("//#include<stdlib.h>");
            fs.WriteLine("//#include<string.h>");
            fs.WriteLine();
            fs.Close();

            addNewFileItem(pfile, false);

        }

        private void TouchNewCppFileGroupToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string str = Interaction.InputBox("请输入CPP文件名：", "文件名输入框", "", -1, -1);
            str = str.Trim();
            if (str.Length == 0)
                return;

            string upstr = str.ToUpper();
            string fupStr = ""+upstr[0]+str.Substring(1);
            

            FileInfo pfile = new FileInfo(getUseableFileName(m_currentPath, str, ".h"));
            StreamWriter fs = pfile.CreateText();
            fs.WriteLine("/*  */");
            fs.WriteLine("#ifndef _" + upstr + "_H_");
            fs.WriteLine("#define _" + upstr + "_H_");
            fs.WriteLine("class "+fupStr+" // : public Object");
            fs.WriteLine("{");
            fs.WriteLine("public:");
            fs.WriteLine("\t"+fupStr+"();");
            fs.WriteLine("\tvirtual ~" + fupStr + "();");
            fs.WriteLine("\t"+fupStr+"(const "+fupStr+" & obj);");
            fs.WriteLine("\t" + fupStr + "& operator=(const " + fupStr + " & obj);");
            fs.WriteLine("private:");
            fs.WriteLine("};");
            fs.WriteLine("#endif // _" + upstr + "_H_");
            fs.WriteLine();
            fs.Close();

            addNewFileItem(pfile, false);

            pfile = new FileInfo(getUseableFileName(m_currentPath, str, ".cpp"));
            fs = pfile.CreateText();
            fs.WriteLine("/*  */");
            fs.WriteLine("#include\"" + str + ".h\"");
            fs.WriteLine("//#include<iostream>");
            fs.WriteLine("//#include<string>");
            fs.WriteLine("//#include<cstdlib>");
            fs.WriteLine("//using namespace::std;");
            fs.WriteLine();
            fs.WriteLine(fupStr + "::" + fupStr + "()\n{\n\t\n}\n");
            fs.WriteLine(fupStr+"::~"+fupStr+"()\n{\n\t\n}\n");
            fs.WriteLine(fupStr+"::"+fupStr+"(const "+fupStr+" & obj)\n{\n\t\n}\n");
            fs.WriteLine(fupStr + " & " + fupStr + "::" + "operator=(const " + fupStr + " & obj)\n{\n\t\n\treturn *this;\n}\n");
            fs.Close();

            addNewFileItem(pfile, false);
        }

        private void TouchNewJavaFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string str = Interaction.InputBox("请输入Java文件名：", "文件名输入框", "", -1, -1);
            str = str.Trim();
            if (str.Length == 0)
                return;

            string upstr = str.ToUpper();
            string fupStr = "" + upstr[0] + str.Substring(1);


            FileInfo pfile = new FileInfo(getUseableFileName(m_currentPath, fupStr, ".java"));
            StreamWriter fs = pfile.CreateText();
            fs.WriteLine("/*  */");
            fs.WriteLine("public class "+fupStr+" //extends Object //implements Runnable{");
            fs.WriteLine("\tpublic static void main(String[] args){");
            fs.WriteLine("\t\t//System.out.println(\"hello java\");");
            fs.WriteLine("\t\t");
            fs.WriteLine("\t}");
            fs.WriteLine("\t");
            fs.WriteLine("}");
            fs.WriteLine();
            fs.Close();

            addNewFileItem(pfile, false);
        }

        private void TouchNewPythonFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string str = Interaction.InputBox("请输入Python文件名：", "文件名输入框", "", -1, -1);
            str = str.Trim();
            if (str.Length == 0)
                return;

            string upstr = str.ToUpper();
            string fupStr = "" + upstr[0] + str.Substring(1);


            FileInfo pfile = new FileInfo(getUseableFileName(m_currentPath, fupStr, ".py"));
            StreamWriter fs = pfile.CreateText();
            fs.WriteLine("# -- coding: gbk --");
            fs.WriteLine("'''\n\n'''");
            fs.WriteLine("def main():\n\tprint('hello py')\n\t");
            fs.WriteLine("\n\n");
            fs.WriteLine("if __name__=='__main__':\n\tmain()\n\t");
            fs.WriteLine();
            fs.Close();

            addNewFileItem(pfile, false);
        }

        private void AnaliesFileOnlyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            m_isAnaliesDirectory = false;
            this.AnaliesFileOnlyToolStripMenuItem.Checked = true;
            this.AnaliesFlodersInfoToolStripMenuItem.Checked = false;
            refreshCurrentDirectory();
        }

        private void AnaliesFlodersInfoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            m_isAnaliesDirectory = true;
            this.AnaliesFileOnlyToolStripMenuItem.Checked = false;
            this.AnaliesFlodersInfoToolStripMenuItem.Checked = true;
            refreshCurrentDirectory();
        }

        private void AnaliesFileCheckCodeFToolStripMenuItem_Click(object sender, EventArgs e)
        {
            m_isNeedFileCheckCode = !m_isNeedFileCheckCode;
            this.AnaliesFileCheckCodeFToolStripMenuItem.Checked = m_isNeedFileCheckCode;
            refreshCurrentDirectory();
        }

        private void listViewFiles_ColumnClick(object sender, ColumnClickEventArgs e)
        {
            int coli = e.Column;
            switch(coli)
            {
                case 0:
                    m_sortType = SortType.Name;
                    break;
                case 1:
                    m_sortType = SortType.Type;
                    break;
                case 2:
                    m_sortType = SortType.Size;
                    break;
                case 3:
                    m_sortType = SortType.Attr;
                    break;
                case 4:
                    m_sortType = SortType.LModify;
                    break;
                case 5:
                    m_sortType = SortType.Create;
                    break;
                case 6:
                    m_sortType = SortType.LAccess;
                    break;
                case 7:
                    m_sortType = SortType.CheckCode;
                    break;
                default:
                    m_sortType = SortType.None;
                    break;
            }
            refreshCurrentDirectory();
        }

        private void SortTypeNoneToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.SortTypeNoneToolStripMenuItem.Checked = true;
            this.RaiseSortModeToolStripMenuItem.Checked = false;
            this.DescSortModeToolStripMenuItem.Checked = false;
             m_sortType = SortType.None;
             refreshCurrentDirectory();
        }

        private void RaiseSortModeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.SortTypeNoneToolStripMenuItem.Checked = false;
            this.RaiseSortModeToolStripMenuItem.Checked = true;
            this.DescSortModeToolStripMenuItem.Checked = false;
            m_isSortRaise = true;
            refreshCurrentDirectory();
        }
        
        private void DescSortModeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.SortTypeNoneToolStripMenuItem.Checked = false;
            this.RaiseSortModeToolStripMenuItem.Checked = false;
            this.DescSortModeToolStripMenuItem.Checked = true;
            m_isSortRaise = false;
            refreshCurrentDirectory();
        }

        private void listViewFiles_DragDrop(object sender, DragEventArgs e)
        {
            if (MessageBox.Show("即将进行文件拖拽，是否继续？", "文件拖拽确认", MessageBoxButtons.OKCancel) == DialogResult.Cancel)
                return;

            bool isCut=false;
            if (MessageBox.Show("是复制文件还是剪切文件？\n确定==剪切，取消==复制", "文件拖拽询问", MessageBoxButtons.OKCancel) == DialogResult.OK)
                isCut = true;

            Array paths = ((Array)e.Data.GetData(DataFormats.FileDrop));
           for(int i=0;i<paths.Length;i++)
           {
               string ppath = paths.GetValue(i).ToString().Trim();
               FileInfo fi = new FileInfo(ppath);
               DirectoryInfo di = new DirectoryInfo(ppath);
               string newpath=getUseableFileName(m_currentPath,getSingleFileNameFromFileInfo(fi),fi.Extension);
               if (newpath == ppath)
                   continue;
               if(fi.Exists)
               {
                   if (isCut)
                       fi.MoveTo(newpath);
                   else
                       fi.CopyTo(newpath);
               }else if(di.Exists)
               {
                   if (isCut)
                       di.MoveTo(newpath);
                   else
                       CopyDirectoryTo(ppath, newpath);
               }
           }

           refreshCurrentDirectory();
        }

        private void listViewFiles_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
                e.Effect = DragDropEffects.All;
            else
                e.Effect = DragDropEffects.None;
        }

        private void OpenItByNotepadToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int selCount = listViewFiles.SelectedItems.Count;
            if (selCount == 0)
                return;
            foreach(ListViewItem it in listViewFiles.SelectedItems)
            {
                ProcessStartInfo sinfo = new ProcessStartInfo();
                sinfo.FileName = "notepad";
                sinfo.Arguments = it.Tag.ToString();
                sinfo.WorkingDirectory = m_currentPath;
                Process.Start(sinfo);
            }
        }

        private void CopyFullPathToClipbordToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int selCount = listViewFiles.SelectedItems.Count;
            if (selCount == 0)
            {
                Clipboard.SetDataObject(m_currentPath);
                return;
            }
            string str = "";
            foreach (ListViewItem it in listViewFiles.SelectedItems)
            {
                str += it.Tag.ToString() + "\n";
            }
            Clipboard.SetDataObject(str);
        }

        private void SearchPath()
        {
            refreshCurrentDirectory();
        }
        private void buttonSearch_Click(object sender, EventArgs e)
        {
            SearchPath();
        }

        private void RandomSelectNumToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int sum = listViewFiles.Items.Count;
            if (sum == 0)
                return;

            string str = Interaction.InputBox("请输入随机选择的项数：\n总：" + sum, "数量输入框", "" + (sum/2), -1, -1);
            str = str.Trim();
            if (str.Length == 0)
                return;
            try
            {
                int count = Convert.ToInt32(str);
                foreach(ListViewItem it in listViewFiles.Items)
                {
                     it.Selected=false;
                }
                if (count <= 0)
                    return;

                
                if(count>=sum)
                {
                    selectedAllItems();
                    return;
                }

                
                Random rand=new Random();
                int pcount = 0;
                while(pcount <count)
                {
                    int i = rand.Next(0, sum);
                    if(listViewFiles.Items[i].Selected==false)
                    {
                        listViewFiles.Items[i].Selected = true;
                        pcount++;
                    }
                }
            }
            catch (Exception)
            {
                
                //throw;
            }
        }

        private void listViewFiles_ItemSelectionChanged(object sender, ListViewItemSelectionChangedEventArgs e)
        {
            this.StateTipstoolStripStatusLabel.Text = "总："+listViewFiles.Items.Count+" 选："+listViewFiles.SelectedItems.Count;
        }

        private void ProMkdirsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string str = Interaction.InputBox("请输入多级目录：\n例如：\naaa/bbb\na\\b\\c", "目录输入框", "", -1, -1);
            str = str.Trim();
            if (str.Length == 0)
                return;
            string[] paths = str.Split(new string[] { "\\", "/" }, StringSplitOptions.RemoveEmptyEntries);
            string ppath = m_currentPath;
            for(int i=0;i<paths.Length;i++)
            {
                ppath = ppath + "\\" + paths[i];
                DirectoryInfo pdir = new DirectoryInfo(ppath);
                pdir.Create();
            }
            refreshCurrentDirectory();
        }

        private void NameToUpperToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int selCount = listViewFiles.SelectedItems.Count;
            if (selCount == 0)
            {
                return;
            }

            foreach(ListViewItem it in listViewFiles.SelectedItems)
            {
                FileInfo fi = new FileInfo(it.Tag.ToString());
                DirectoryInfo di = new DirectoryInfo(it.Tag.ToString());
                string tpname = getUseableFileName(di.Parent.FullName, "_temp_file", ".tmp");
                if(fi.Exists)
                {
                    string name = getSingleFileNameFromFileInfo(fi);
                    string suffix = fi.Extension;
                    fi.MoveTo(tpname);
                    new FileInfo(tpname).MoveTo(getUseableFileName(di.Parent.FullName, name.ToUpper(), suffix));

                }else if(di.Exists)
                {
                    string name = getSingleFileNameFromFileInfo(fi);
                    string suffix = fi.Extension;
                    di.MoveTo(tpname);
                    new DirectoryInfo(tpname).MoveTo(getUseableFileName(di.Parent.FullName, name.ToUpper(), suffix));
                }
            }

            refreshCurrentDirectory();
        }

        private void NameToLowerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int selCount = listViewFiles.SelectedItems.Count;
            if (selCount == 0)
            {
                return;
            }

            foreach (ListViewItem it in listViewFiles.SelectedItems)
            {
                FileInfo fi = new FileInfo(it.Tag.ToString());
                DirectoryInfo di = new DirectoryInfo(it.Tag.ToString());
                string tpname = getUseableFileName(di.Parent.FullName, "_temp_file", ".tmp");
                if (fi.Exists)
                {
                    string name = getSingleFileNameFromFileInfo(fi);
                    string suffix = fi.Extension;
                    fi.MoveTo(tpname);
                    new FileInfo(tpname).MoveTo(getUseableFileName(di.Parent.FullName, name.ToLower(), suffix));

                }
                else if (di.Exists)
                {
                    string name = getSingleFileNameFromFileInfo(fi);
                    string suffix = fi.Extension;
                    di.MoveTo(tpname);
                    new DirectoryInfo(tpname).MoveTo(getUseableFileName(di.Parent.FullName, name.ToLower(), suffix));
                }
            }

            refreshCurrentDirectory();
        }

        private void NameUnifySuffixToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int selCount = listViewFiles.SelectedItems.Count;
            if (selCount == 0)
            {
                return;
            }
            string suffix = Interaction.InputBox("请输入后缀：\n例如：\n.mp3\npng", "后缀输入框", "", -1, -1);
            suffix = suffix.Trim();
            if (suffix.Length == 0)
                return;
            if(suffix[0]!='.')
            {
                suffix = '.' + suffix;
            }

            foreach (ListViewItem it in listViewFiles.SelectedItems)
            {
                FileInfo fi = new FileInfo(it.Tag.ToString());
                DirectoryInfo di = new DirectoryInfo(it.Tag.ToString());
                string tpname = getUseableFileName(di.Parent.FullName, "_temp_file", ".tmp");
                if (fi.Exists)
                {
                    string name = getSingleFileNameFromFileInfo(fi);
                    
                    fi.MoveTo(tpname);
                    new FileInfo(tpname).MoveTo(getUseableFileName(di.Parent.FullName, name.ToLower(), suffix));

                }
                else if (di.Exists)
                {
                    string name = getSingleFileNameFromFileInfo(fi);
                    di.MoveTo(tpname);
                    new DirectoryInfo(tpname).MoveTo(getUseableFileName(di.Parent.FullName, name.ToLower(), suffix));
                }
            }

            refreshCurrentDirectory();
        }

        private void NameHeadAddNumberToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int selCount = listViewFiles.SelectedItems.Count;
            if (selCount == 0)
            {
                return;
            }
            string str = Interaction.InputBox("请输入起始序号：\n例如：\n1\n010\n0001", "序号输入框", "", -1, -1);
            str = str.Trim();
            if (str.Length == 0)
                return;

            try
            {
                int num = Convert.ToInt32(str);
                int wid = str.Length;
                string fmt = "{0:D"+wid+"}";

                int count = 0;
                for(int i=0;i<listViewFiles.Items.Count;i++)
                {
                    if(listViewFiles.Items[i].Selected)
                    {
                        FileInfo fi=new FileInfo(listViewFiles.Items[i].Tag.ToString());
                        string ppath = getUseableFileName(fi.DirectoryName, String.Format(fmt, (num + count)) + getSingleFileNameFromFileInfo(fi), fi.Extension);
                        fi.MoveTo(ppath);
                        count++;
                    }
                }
                refreshCurrentDirectory();
            }
            catch (Exception)
            {

               // throw;
            }

        }

        private void NameTialAddNumberToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int selCount = listViewFiles.SelectedItems.Count;
            if (selCount == 0)
            {
                return;
            }
            string str = Interaction.InputBox("请输入起始序号：\n例如：\n1\n010\n0001", "序号输入框", "", -1, -1);
            str = str.Trim();
            if (str.Length == 0)
                return;

            try
            {
                int num = Convert.ToInt32(str);
                int wid = str.Length;
                string fmt = "{0:D" + wid + "}";

                int count = 0;
                for (int i = 0; i < listViewFiles.Items.Count; i++)
                {
                    if (listViewFiles.Items[i].Selected)
                    {
                        FileInfo fi = new FileInfo(listViewFiles.Items[i].Tag.ToString());
                        string ppath = getUseableFileName(fi.DirectoryName, getSingleFileNameFromFileInfo(fi) + String.Format(fmt, (num + count)), fi.Extension);
                        fi.MoveTo(ppath);
                        count++;
                    }
                }
                refreshCurrentDirectory();
            }
            catch (Exception)
            {

                // throw;
            }
        }

        private void NameHeadAddTimeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int selCount = listViewFiles.SelectedItems.Count;
            if (selCount == 0)
            {
                return;
            }
            

            try
            {
                DateTime tm = DateTime.Now;
                string tmstr=tm.ToString("HHmmss");

                int count = 0;
                for (int i = 0; i < listViewFiles.Items.Count; i++)
                {
                    if (listViewFiles.Items[i].Selected)
                    {
                        FileInfo fi = new FileInfo(listViewFiles.Items[i].Tag.ToString());
                        string ppath = getUseableFileName(fi.DirectoryName, tmstr + getSingleFileNameFromFileInfo(fi), fi.Extension);
                        fi.MoveTo(ppath);
                        count++;
                    }
                }
                refreshCurrentDirectory();
            }
            catch (Exception)
            {

                // throw;
            }
        }

        private void NameTialAddTimeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int selCount = listViewFiles.SelectedItems.Count;
            if (selCount == 0)
            {
                return;
            }


            try
            {
                DateTime tm = DateTime.Now;
                string tmstr = tm.ToString("HHmmss");

                int count = 0;
                for (int i = 0; i < listViewFiles.Items.Count; i++)
                {
                    if (listViewFiles.Items[i].Selected)
                    {
                        FileInfo fi = new FileInfo(listViewFiles.Items[i].Tag.ToString());
                        string ppath = getUseableFileName(fi.DirectoryName, getSingleFileNameFromFileInfo(fi) + tmstr, fi.Extension);
                        fi.MoveTo(ppath);
                        count++;
                    }
                }
                refreshCurrentDirectory();
            }
            catch (Exception)
            {

                // throw;
            }
        }

        private void NameHeadAddDateToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int selCount = listViewFiles.SelectedItems.Count;
            if (selCount == 0)
            {
                return;
            }


            try
            {
                DateTime tm = DateTime.Now;
                string tmstr = tm.ToString("yyyyMMdd");

                int count = 0;
                for (int i = 0; i < listViewFiles.Items.Count; i++)
                {
                    if (listViewFiles.Items[i].Selected)
                    {
                        FileInfo fi = new FileInfo(listViewFiles.Items[i].Tag.ToString());
                        string ppath = getUseableFileName(fi.DirectoryName, tmstr + getSingleFileNameFromFileInfo(fi), fi.Extension);
                        fi.MoveTo(ppath);
                        count++;
                    }
                }
                refreshCurrentDirectory();
            }
            catch (Exception)
            {

                // throw;
            }
        }

        private void NameTialAddDateToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int selCount = listViewFiles.SelectedItems.Count;
            if (selCount == 0)
            {
                return;
            }


            try
            {
                DateTime tm = DateTime.Now;
                string tmstr = tm.ToString("yyyyMMdd");

                int count = 0;
                for (int i = 0; i < listViewFiles.Items.Count; i++)
                {
                    if (listViewFiles.Items[i].Selected)
                    {
                        FileInfo fi = new FileInfo(listViewFiles.Items[i].Tag.ToString());
                        string ppath = getUseableFileName(fi.DirectoryName, getSingleFileNameFromFileInfo(fi) + tmstr, fi.Extension);
                        fi.MoveTo(ppath);
                        count++;
                    }
                }
                refreshCurrentDirectory();
            }
            catch (Exception)
            {

                // throw;
            }
        }

        private void NameHeadAddStringToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int selCount = listViewFiles.SelectedItems.Count;
            if (selCount == 0)
            {
                return;
            }

            string str = Interaction.InputBox("请输入要添加的字符串：", "字符串输入框", "", -1, -1);
            if (str.Length == 0)
                return;

            try
            {
                
                

                int count = 0;
                for (int i = 0; i < listViewFiles.Items.Count; i++)
                {
                    if (listViewFiles.Items[i].Selected)
                    {
                        FileInfo fi = new FileInfo(listViewFiles.Items[i].Tag.ToString());
                        string ppath = getUseableFileName(fi.DirectoryName, str + getSingleFileNameFromFileInfo(fi), fi.Extension);
                        fi.MoveTo(ppath);
                        count++;
                    }
                }
                refreshCurrentDirectory();
            }
            catch (Exception)
            {

                // throw;
            }
        }

        private void NameTialAddStringToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int selCount = listViewFiles.SelectedItems.Count;
            if (selCount == 0)
            {
                return;
            }

            string str = Interaction.InputBox("请输入要添加的字符串：", "字符串输入框", "", -1, -1);
            if (str.Length == 0)
                return;

            try
            {



                int count = 0;
                for (int i = 0; i < listViewFiles.Items.Count; i++)
                {
                    if (listViewFiles.Items[i].Selected)
                    {
                        FileInfo fi = new FileInfo(listViewFiles.Items[i].Tag.ToString());
                        string ppath = getUseableFileName(fi.DirectoryName, getSingleFileNameFromFileInfo(fi) + str, fi.Extension);
                        fi.MoveTo(ppath);
                        count++;
                    }
                }
                refreshCurrentDirectory();
            }
            catch (Exception)
            {

                // throw;
            }
        }

        private void AttriAddReadOnlyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int selCount = listViewFiles.SelectedItems.Count;
            if (selCount == 0)
            {
                return;
            }


            try
            {
                foreach(ListViewItem it in listViewFiles.SelectedItems)
                {
                    FileInfo fi = new FileInfo(it.Tag.ToString());
                    DirectoryInfo di = new DirectoryInfo(it.Tag.ToString());
                    if(fi.Exists)
                    {
                        fi.Attributes=(FileAttributes)((int)FileAttributes.ReadOnly | (int)fi.Attributes);
                    }else if(di.Exists)
                    {
                        di.Attributes = (FileAttributes)((int)FileAttributes.ReadOnly | (int)di.Attributes);
                    }
                }

                refreshCurrentDirectory();
            }
            catch (Exception)
            {

                // throw;
            }
        }

        private void AttriCancelReadOnlyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int selCount = listViewFiles.SelectedItems.Count;
            if (selCount == 0)
            {
                return;
            }


            try
            {
                foreach (ListViewItem it in listViewFiles.SelectedItems)
                {
                    FileInfo fi = new FileInfo(it.Tag.ToString());
                    DirectoryInfo di = new DirectoryInfo(it.Tag.ToString());
                    if (fi.Exists)
                    {
                        fi.Attributes = (FileAttributes)((~((int)FileAttributes.ReadOnly)) & (int)fi.Attributes);
                    }
                    else if (di.Exists)
                    {
                        di.Attributes = (FileAttributes)((~((int)FileAttributes.ReadOnly)) & (int)di.Attributes);
                    }
                }

                refreshCurrentDirectory();
            }
            catch (Exception)
            {

                // throw;
            }
        }

        private void AttriAddHideToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int selCount = listViewFiles.SelectedItems.Count;
            if (selCount == 0)
            {
                return;
            }


            try
            {
                foreach (ListViewItem it in listViewFiles.SelectedItems)
                {
                    FileInfo fi = new FileInfo(it.Tag.ToString());
                    DirectoryInfo di = new DirectoryInfo(it.Tag.ToString());
                    if (fi.Exists)
                    {
                        fi.Attributes = (FileAttributes)((int)FileAttributes.Hidden | (int)fi.Attributes);
                    }
                    else if (di.Exists)
                    {
                        di.Attributes = (FileAttributes)((int)FileAttributes.Hidden | (int)di.Attributes);
                    }
                }

                refreshCurrentDirectory();
            }
            catch (Exception)
            {

                // throw;
            }
        }

        private void AttriCancelHideToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int selCount = listViewFiles.SelectedItems.Count;
            if (selCount == 0)
            {
                return;
            }


            try
            {
                foreach (ListViewItem it in listViewFiles.SelectedItems)
                {
                    FileInfo fi = new FileInfo(it.Tag.ToString());
                    DirectoryInfo di = new DirectoryInfo(it.Tag.ToString());
                    if (fi.Exists)
                    {
                        fi.Attributes = (FileAttributes)((~((int)FileAttributes.Hidden)) & (int)fi.Attributes);
                    }
                    else if (di.Exists)
                    {
                        di.Attributes = (FileAttributes)((~((int)FileAttributes.Hidden)) & (int)di.Attributes);
                    }
                }

                refreshCurrentDirectory();
            }
            catch (Exception)
            {

                // throw;
            }
        }

        private void ShowFloderCheckStateToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.ShowFloderCheckStateToolStripMenuItem.Checked = !this.ShowFloderCheckStateToolStripMenuItem.Checked;
            refreshCurrentDirectory();
        }

        private void textBoxCurrentPath_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if(e.KeyCode==Keys.Enter)
                 EnterPath();
        }

        private void textBoxSearchContent_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                SearchPath();
        }

        private void NameReplaceStringToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int selCount = listViewFiles.SelectedItems.Count;
            if (selCount == 0)
            {
                return;
            }
            string oldstr = Interaction.InputBox("请输入要被替换字符串：", "字符串输入框", "", -1, -1);
            if (oldstr.Length == 0)
                return;
            string newstr = Interaction.InputBox("请输入替换字符串：", "字符串输入框", "", -1, -1);

            foreach (ListViewItem it in listViewFiles.SelectedItems)
            {
                FileInfo fi = new FileInfo(it.Tag.ToString());
                DirectoryInfo di = new DirectoryInfo(it.Tag.ToString());
                string suffix = fi.Extension;
                string tpname = getUseableFileName(di.Parent.FullName, "_temp_file", ".tmp");
                if (fi.Exists)
                {
                    string name = getSingleFileNameFromFileInfo(fi);
                    name = name.Replace(oldstr, newstr);

                    fi.MoveTo(tpname);
                    new FileInfo(tpname).MoveTo(getUseableFileName(di.Parent.FullName, name, suffix));

                }
                else if (di.Exists)
                {
                    string name = getSingleFileNameFromFileInfo(fi);
                    name = name.Replace(oldstr, newstr);

                    di.MoveTo(tpname);
                    new DirectoryInfo(tpname).MoveTo(getUseableFileName(di.Parent.FullName, name, suffix));
                }
            }

            refreshCurrentDirectory();
        }

        private void ChoiceOpenMethodToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(listViewFiles.SelectedItems.Count==0)
            {
                return;
            }

            foreach(ListViewItem it in listViewFiles.SelectedItems)
            {
                FileInfo fi=new FileInfo(it.Tag.ToString());
                if(fi.Exists)
                {
                    ProcessStartInfo sinfo = new ProcessStartInfo();
                    sinfo.FileName = "rundll32.exe";
                    sinfo.Arguments = "shell32,OpenAs_RunDLL " + fi.FullName;
                    sinfo.WorkingDirectory = fi.DirectoryName;
                    Process.Start(sinfo);
                }
                
            }
        }

        private void cleanEmptyDirectories(DirectoryInfo dir,ref int sumCount,ref int delCount)
        {
            try
            {
                if (dir.Exists == false)
                {
                    return;
                }

                if (dir.GetFileSystemInfos().Length == 0)
                {
                    try
                    {
                        dir.Delete(false);
                        delCount++;
                    }
                    catch (Exception)
                    {
                       
                    }
                    
                }
                else
                {
                    DirectoryInfo[] dirs = dir.GetDirectories();
                    foreach (DirectoryInfo pdir in dirs)
                    {
                        sumCount++;
                        cleanEmptyDirectories(pdir,ref sumCount,ref delCount);
                    }
                }
            }
            catch (Exception)
            {

                
            }
            
        }
        private void cleanEmptyFiles(DirectoryInfo dir, ref int sumCount, ref int delCount)
        {
            try
            {
                if (dir.Exists == false)
                {
                    return;
                }

                if (dir.GetFileSystemInfos().Length > 0)
                {
                    FileInfo[] files = dir.GetFiles();
                    foreach(FileInfo pfile in files)
                    {
                        sumCount++;
                        if (pfile.Length == 0)
                        {
                            try
                            {
                                pfile.Delete();
                                delCount++;
                            }
                            catch (Exception)
                            {

                            }
                        }
                    }
                    DirectoryInfo[] dirs = dir.GetDirectories();
                    foreach (DirectoryInfo pdir in dirs)
                    {
                        cleanEmptyFiles(pdir, ref sumCount, ref delCount);
                    }
                }
            }
            catch (Exception)
            {


            }

        }


        private void CleanEmptyDirectoryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show(this,"确认对当前显示路径下所有文件树执行【空文件夹清理】操作吗？", "空文件夹清理询问", MessageBoxButtons.OKCancel) == DialogResult.Cancel)
            {
                return;
            }
            this.StateTipstoolStripStatusLabel.Text = "空文件夹清理正在进行中...";
            int sumCount = 0, delCount = 0;
            cleanEmptyDirectories(new DirectoryInfo(m_currentPath),ref sumCount,ref delCount);
            MessageBox.Show(this,"总共扫描文件夹【" + sumCount + "】，清理空文件夹【" + delCount + "】", "空文件夹清理提示");
            this.StateTipstoolStripStatusLabel.Text = "就绪";
        }

        private void CleanEmptyFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show(this,"确认对当前显示路径下所有文件树执行【空文件清理】操作吗？", "空文件清理询问", MessageBoxButtons.OKCancel) == DialogResult.Cancel)
            {
                return;
            }
            this.StateTipstoolStripStatusLabel.Text = "空文件清理正在进行中...";
            int sumCount = 0, delCount = 0;
            cleanEmptyFiles(new DirectoryInfo(m_currentPath), ref sumCount, ref delCount);
            MessageBox.Show(this,"总共扫描文件【" + sumCount + "】，清理空文件【" + delCount + "】", "空文件清理提示");
            this.StateTipstoolStripStatusLabel.Text = "就绪";
        }

        private void cleanFilesBySuffixes(DirectoryInfo dir,String[] suffixes, ref int sumCount, ref int delCount)
        {
            try
            {
                if (dir.Exists == false)
                {
                    return;
                }

                if (dir.GetFileSystemInfos().Length > 0)
                {
                    FileInfo[] files = dir.GetFiles();
                    foreach (FileInfo pfile in files)
                    {
                        sumCount++;
                        string psuffix = pfile.Extension.ToLower();
                        foreach (string suffix in suffixes)
                        {
                            if (psuffix == suffix.ToLower())
                            {
                                try
                                {
                                    pfile.Delete();
                                    delCount++;
                                }
                                catch (Exception)
                                {

                                }
                                break;
                            }
                        }
                        
                    }
                    DirectoryInfo[] dirs = dir.GetDirectories();
                    foreach (DirectoryInfo pdir in dirs)
                    {
                        cleanFilesBySuffixes(pdir,suffixes, ref sumCount, ref delCount);
                    }
                }
            }
            catch (Exception)
            {


            }

        }
        private void CleanFilesOfSuffixiesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show(this, "确认对当前显示路径下所有文件树执行【指定文件后缀清理】操作吗？", "指定文件后缀清理询问", MessageBoxButtons.OKCancel) == DialogResult.Cancel)
            {
                return;
            }

            string iline="";
            InputDialog.Show(this,out iline, "请按照如下形式输入你要清理的后缀列表，以换行分割，例如：\r\n.txt\r\n.png\r\n.ogg\r\njpg\r\nlog","后缀输入框");
            iline = iline.Trim();
            if (iline == "")
            {
                MessageBox.Show(this, "无效的输入，执行取消", "检查提示");
                return;
            }

            string sureSuffix = "";
            string[]  suffixes = iline.Split(new string[] { "\r\n" }, StringSplitOptions.RemoveEmptyEntries);
            for (int i = 0; i < suffixes.Length;i++ )
            {
                if (suffixes[i].StartsWith(".") == false)
                {
                    suffixes[i] = "." + suffixes[i];
                }
                sureSuffix = sureSuffix + " "+suffixes[i];
            }
            if (MessageBox.Show(this, "确认删除这些后缀文件吗？" + "\r\n" + sureSuffix, "确认提示", MessageBoxButtons.OKCancel) == DialogResult.Cancel)
            {
                MessageBox.Show(this, "用户操作终止，执行取消", "检查提示");
                return;
            }


            this.StateTipstoolStripStatusLabel.Text = "指定文件后缀清理正在进行中...";
            int sumCount = 0, delCount = 0;
            cleanFilesBySuffixes(new DirectoryInfo(m_currentPath),suffixes, ref sumCount, ref delCount);
            MessageBox.Show(this, "总共扫描文件【" + sumCount + "】，清理指定文件后缀【" + delCount + "】", "指定文件后缀清理提示");
            this.StateTipstoolStripStatusLabel.Text = "就绪";
        }


        private void WindowToTopmostToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.TopMost = !WindowToTopmostToolStripMenuItem.Checked;
            WindowToTopmostToolStripMenuItem.Checked = !WindowToTopmostToolStripMenuItem.Checked;
        }

        double transparentRate = 0.7;
       
        private void WindowToTransparentToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (WindowToTransparentToolStripMenuItem.Checked == false)
            {
                this.Opacity = transparentRate;
            }
            else
            {
                this.Opacity = 1.0;
            }
            WindowToTransparentToolStripMenuItem.Checked = !WindowToTransparentToolStripMenuItem.Checked;
        }

        private void WindowTransParentRateToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string outtext=""+transparentRate;
            InputDialog.Show(this, out outtext, "请输入不透明度（0.0-1.0，值越大越不透明），当前：" + transparentRate, "不透明度输入");
            try
            {
                double prate = Convert.ToDouble(outtext);
                if (prate >= 0.0 && prate <= 1.0)
                {
                    transparentRate = prate;
                }
                if (WindowToTransparentToolStripMenuItem.Checked == true)
                {
                    this.Opacity = transparentRate;
                }
            }
            catch (Exception)
            {
                
            }
            
        }

        private void WindowWhiteBecomeFullTransparentToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (WindowWhiteBecomeFullTransparentToolStripMenuItem.Checked == false)
            {
                this.BackColor = Color.FromArgb(255,0,1,1);
                this.panelMainView.BackColor = this.BackColor;
                this.listViewFiles.BackColor = this.BackColor;
                this.menuStripMain.BackColor = this.BackColor;
                this.splitContainerControl.BackColor = this.BackColor;
                this.statusStripMain.BackColor = this.BackColor;
               
                this.TransparencyKey = this.BackColor;
            }
            else
            {
                this.BackColor = Color.White;
                this.panelMainView.BackColor = this.BackColor;
                this.listViewFiles.BackColor = this.BackColor;
                this.menuStripMain.BackColor = this.BackColor;
                this.splitContainerControl.BackColor = this.BackColor;
                this.statusStripMain.BackColor = this.BackColor;

                this.TransparencyKey = Color.FromArgb(0,0,1,1);
            }
            WindowWhiteBecomeFullTransparentToolStripMenuItem.Checked = !WindowWhiteBecomeFullTransparentToolStripMenuItem.Checked;
        }

    }
}
