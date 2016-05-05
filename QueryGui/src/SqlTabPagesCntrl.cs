﻿using System;
using System.IO;
using System.Windows.Forms;
using hoTools.Settings;
using hoTools.Utils.SQL;
using EAAddinFramework.Utils;

namespace hoTools.Query
{
    /// <summary>
    /// SqlTabPagesCntrl creates and handles TabPages of a ControlTab to work with *.sql files.
    /// - Create Menu Items
    /// -- Templates SQL
    /// -- Templates Macros
    /// - Events
    /// - SQL File properties
    /// 
    /// </summary>
    public class SqlTabPagesCntrl
    {
        /// <summary>
        /// Setting with the file history.
        /// </summary>
        AddinSettings _settings;
        Model _model;
        System.ComponentModel.IContainer _components;
        TabControl _tabControl;
        TextBox _sqlTextBoxSearchTerm;


        /// <summary>
        /// Reusable ToolStripMenuItem: File Menu: New Tab and Load Recent Files 
        /// </summary>
        public ToolStripMenuItem FileNewTabAndLoadRecentFileItem => _fileNewTabAndLoadRecentFileItem;
        readonly ToolStripMenuItem _fileNewTabAndLoadRecentFileItem;

        /// <summary>
        /// Reusable ToolStripMenuItem: File Menu: Load Recent Files in current Tab
        /// </summary>
        public ToolStripMenuItem FileLoadRecentFileItem => _fileLoadRecentFileItem;
        readonly ToolStripMenuItem _fileLoadRecentFileItem;

        readonly ToolStripMenuItem _newTabFromItem = new ToolStripMenuItem("New Tab from...");
        readonly ToolStripMenuItem _loadTabFromFileItem  = new ToolStripMenuItem("Load from...");


        const string DEFAULT_TAB_NAME = "noName";

        /// <summary>
        /// Constructor to initialize TabControl, create ToolStripItems (New Tab from, Recent Files) with file history. 
        /// </summary>
        /// <param name="model"></param>
        /// <param name="settings"></param>
        /// <param name="components"></param>
        /// <param name="tabControl"></param>
        /// <param name="sqlTextBoxSearchTerm"></param>
        /// <param name="fileNewTabAndLoadRecentFileItem">File, New Tab from recent files</param>
        /// <param name="fileLoadRecentFileItem">File, Load Tab from recent files</param>
        public SqlTabPagesCntrl(Model model, AddinSettings settings, 
            System.ComponentModel.IContainer components, 
            TabControl tabControl, TextBox sqlTextBoxSearchTerm,
            ToolStripMenuItem fileNewTabAndLoadRecentFileItem,
            ToolStripMenuItem fileLoadRecentFileItem)
        {
            _settings = settings;
            _model = model;
            _tabControl = tabControl;
            _components = components;
            _sqlTextBoxSearchTerm = sqlTextBoxSearchTerm;

            _fileNewTabAndLoadRecentFileItem = fileNewTabAndLoadRecentFileItem;
            _fileLoadRecentFileItem = fileLoadRecentFileItem;

            // Load recent files into ToolStripMenu
            loadRecentFilesIntoToolStripItems();

        }
        /// <summary>
        /// Add a tab to the tab control
        /// </summary>
        /// <returns></returns>
        public TabPage addTab()
        {
            // create a new TabPage in TabControl
            TabPage tabPage = new TabPage();
            _tabControl.Controls.Add(tabPage);

            SqlFile sqlFile = new SqlFile($"{DEFAULT_TAB_NAME}{_tabControl.Controls.Count}.sql", false);
            tabPage.Tag = sqlFile;
            tabPage.Text = sqlFile.DisplayName;
            tabPage.ToolTipText = sqlFile.FullName;
            _tabControl.SelectTab(tabPage);

            //-----------------------------------------------------------------
            // Tab with ContextMenuStrip
            // Create a text box in TabPage for the SQL string
            TextBox sqlTextBox = new TextBox();
            sqlTextBox.Multiline = true;
            sqlTextBox.ScrollBars = ScrollBars.Both;
            sqlTextBox.AcceptsReturn = true;
            sqlTextBox.AcceptsTab = true;
            sqlTextBox.TextChanged += sqlTextBox_TextChanged;

                        // Set WordWrap to true to allow text to wrap to the next line.
            sqlTextBox.WordWrap = true;
            sqlTextBox.Modified = false;
            sqlTextBox.Dock = DockStyle.Fill;

            tabPage.Controls.Add(sqlTextBox);

            // ContextMenu
            ContextMenuStrip tabPageContextMenuStrip = new ContextMenuStrip(_components);

            // Load sql File into TabPage
            ToolStripMenuItem _loadTabMenuItem = new ToolStripMenuItem();
            _loadTabMenuItem.Text = "Load File";
            _loadTabMenuItem.Click += new System.EventHandler(this.fileLoadMenuItem_Click);

            // Save sql File from TabPage
            ToolStripMenuItem fileSaveMenuItem = new ToolStripMenuItem();
            fileSaveMenuItem.Text = "Save File";
            fileSaveMenuItem.Click += new System.EventHandler(this.fileSaveMenuItem_Click);

            // Save As sql File from TabPage
            ToolStripMenuItem fileSaveAsMenuItem = new ToolStripMenuItem();
            fileSaveAsMenuItem.Text = "Save File As..";
            fileSaveAsMenuItem.Click += new System.EventHandler(this.fileSaveAsMenuItem_Click);

            // New TabPage
            ToolStripMenuItem _newTabMenuItem = new ToolStripMenuItem();
            _newTabMenuItem.Text = "New Tab";
            _newTabMenuItem.Click += new System.EventHandler(this.addTabMenuItem_Click);

            // Close TabPage
            ToolStripMenuItem closeMenuItem = new ToolStripMenuItem();
            closeMenuItem.Text = "Close Tab";
            closeMenuItem.Click += new System.EventHandler(this.closeMenuItem_Click);

            // Run sql File 
            ToolStripMenuItem fileRunMenuItem = new ToolStripMenuItem();
            fileRunMenuItem.Text = "Run sql";
            fileRunMenuItem.Click += new System.EventHandler(this.fileRunMenuItem_Click);


            //------------------------------------------------------------------------------------------------------------------
            // Insert Template
            ToolStripMenuItem insertTemplateMenuItem = new ToolStripMenuItem("Insert &Template");

            // Insert Element Template
            ToolStripMenuItem insertElementTemplateMenuItem = new ToolStripMenuItem();
            insertElementTemplateMenuItem.Text = "Insert Element Template";
            insertElementTemplateMenuItem.ToolTipText = SqlTemplates.getTooltip(SqlTemplates.SQL_TEMPLATE_ID.ELEMENT_TEMPLATE);
            insertElementTemplateMenuItem.Tag = SqlTemplates.getTemplate(SqlTemplates.SQL_TEMPLATE_ID.ELEMENT_TEMPLATE);
            insertElementTemplateMenuItem.Click += new System.EventHandler(insertTemplate_Click);

            // Insert Element Type Template
            ToolStripMenuItem insertElementTypeTemplateMenuItem = new ToolStripMenuItem();
            insertElementTypeTemplateMenuItem.Text = "Insert Element Type Template";
            insertElementTypeTemplateMenuItem.ToolTipText = SqlTemplates.getTooltip(SqlTemplates.SQL_TEMPLATE_ID.ELEMENT_TYPE_TEMPLATE);
            insertElementTypeTemplateMenuItem.Tag = SqlTemplates.getTemplate(SqlTemplates.SQL_TEMPLATE_ID.ELEMENT_TYPE_TEMPLATE);
            insertElementTypeTemplateMenuItem.Click += new System.EventHandler(insertTemplate_Click);

            // Insert Diagram Template
            ToolStripMenuItem insertDiagramTemplateMenuItem = new ToolStripMenuItem();
            insertDiagramTemplateMenuItem.Text = "Insert Diagram Template";
            insertDiagramTemplateMenuItem.ToolTipText = SqlTemplates.getTooltip(SqlTemplates.SQL_TEMPLATE_ID.DIAGRAM_TEMPLATE);
            insertDiagramTemplateMenuItem.Tag = SqlTemplates.getTemplate(SqlTemplates.SQL_TEMPLATE_ID.DIAGRAM_TEMPLATE);
            insertDiagramTemplateMenuItem.Click += new System.EventHandler(insertTemplate_Click);

            // Insert Diagram Type Template
            ToolStripMenuItem insertDiagramTypeTemplateMenuItem = new ToolStripMenuItem();
            insertDiagramTypeTemplateMenuItem.Text = "Insert Diagram Type Template";
            insertDiagramTypeTemplateMenuItem.ToolTipText = SqlTemplates.getTooltip(SqlTemplates.SQL_TEMPLATE_ID.DIAGRAM_TYPE_TEMPLATE);
            insertDiagramTypeTemplateMenuItem.Tag = SqlTemplates.getTemplate(SqlTemplates.SQL_TEMPLATE_ID.DIAGRAM_TYPE_TEMPLATE);
            insertDiagramTypeTemplateMenuItem.Click += new System.EventHandler(insertTemplate_Click);

            // Insert Package Template
            ToolStripMenuItem insertPackageTemplateMenuItem = new ToolStripMenuItem();
            insertPackageTemplateMenuItem.Text = "Insert Package Template";
            insertPackageTemplateMenuItem.ToolTipText = SqlTemplates.getTooltip(SqlTemplates.SQL_TEMPLATE_ID.PACKAGE_TEMPLATE);
            insertPackageTemplateMenuItem.Tag = SqlTemplates.getTemplate(SqlTemplates.SQL_TEMPLATE_ID.PACKAGE_TEMPLATE);
            insertPackageTemplateMenuItem.Click += new System.EventHandler(insertTemplate_Click);

            // Insert DiagramObject Template
            ToolStripMenuItem insertDiagramObjectTemplateMenuItem = new ToolStripMenuItem();
            insertDiagramObjectTemplateMenuItem.Text = "Insert Diagram Object Template";
            insertDiagramObjectTemplateMenuItem.ToolTipText = SqlTemplates.getTooltip(SqlTemplates.SQL_TEMPLATE_ID.DIAGRAM_OBJECT_TEMPLATE);
            insertDiagramObjectTemplateMenuItem.Tag = SqlTemplates.getTemplate(SqlTemplates.SQL_TEMPLATE_ID.DIAGRAM_OBJECT_TEMPLATE);
            insertDiagramObjectTemplateMenuItem.Click += new System.EventHandler(insertTemplate_Click);

            // Insert Attribute Template
            ToolStripMenuItem insertAttributeTemplateMenuItem = new ToolStripMenuItem();
            insertAttributeTemplateMenuItem.Text = "Insert Attribute Template";
            insertAttributeTemplateMenuItem.ToolTipText = SqlTemplates.getTooltip(SqlTemplates.SQL_TEMPLATE_ID.ATTRIBUTE_TEMPLATE);
            insertAttributeTemplateMenuItem.Tag = SqlTemplates.getTemplate(SqlTemplates.SQL_TEMPLATE_ID.ATTRIBUTE_TEMPLATE);
            insertAttributeTemplateMenuItem.Click += new System.EventHandler(insertTemplate_Click);

            // Insert Operation Template
            ToolStripMenuItem insertOperationTemplateMenuItem = new ToolStripMenuItem();
            insertOperationTemplateMenuItem.Text = "Insert Operation Template";
            insertOperationTemplateMenuItem.ToolTipText = SqlTemplates.getTooltip(SqlTemplates.SQL_TEMPLATE_ID.OPERATION_TEMPLATE);
            insertOperationTemplateMenuItem.Tag = SqlTemplates.getTemplate(SqlTemplates.SQL_TEMPLATE_ID.OPERATION_TEMPLATE);
            insertOperationTemplateMenuItem.Click += new System.EventHandler(insertTemplate_Click);
            insertTemplateMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
                insertElementTemplateMenuItem,
                insertElementTypeTemplateMenuItem,
                insertDiagramTemplateMenuItem,
                insertDiagramTypeTemplateMenuItem,
                insertPackageTemplateMenuItem,
                insertDiagramObjectTemplateMenuItem,
                insertAttributeTemplateMenuItem,
                insertOperationTemplateMenuItem


                
                });


            //-----------------------------------------------------------------------------------------------------------------
            // Insert Macro
            ToolStripMenuItem insertMacroMenuItem = new ToolStripMenuItem();
            insertMacroMenuItem.Text = "Insert &Macro";

            // Insert Macro
            ToolStripMenuItem insertMacroSearchTermMenuItem = new ToolStripMenuItem();
            insertMacroSearchTermMenuItem.Text = "Insert <Search Term>";
            insertMacroSearchTermMenuItem.ToolTipText = SqlTemplates.getTooltip(SqlTemplates.SQL_TEMPLATE_ID.SEARCH_TERM);
            insertMacroSearchTermMenuItem.Tag = SqlTemplates.getTemplate(SqlTemplates.SQL_TEMPLATE_ID.SEARCH_TERM);
            insertMacroSearchTermMenuItem.Click += new System.EventHandler(insertTemplate_Click);

            // Insert Package
            ToolStripMenuItem insertPackageMenuItem = new ToolStripMenuItem();
            insertPackageMenuItem.Text = "Insert #Package#";
            insertPackageMenuItem.ToolTipText = SqlTemplates.getTooltip(SqlTemplates.SQL_TEMPLATE_ID.PACKAGE_ID);
            insertPackageMenuItem.Tag = SqlTemplates.getTemplate(SqlTemplates.SQL_TEMPLATE_ID.PACKAGE_ID);
            insertPackageMenuItem.Click += new System.EventHandler(insertTemplate_Click);

            // Insert Branch
            ToolStripMenuItem insertBranchMenuItem = new ToolStripMenuItem();
            insertBranchMenuItem.Text = "Insert #Branch#";
            insertBranchMenuItem.ToolTipText = SqlTemplates.getTooltip(SqlTemplates.SQL_TEMPLATE_ID.BRANCH_IDS);
            insertBranchMenuItem.Tag = SqlTemplates.getTemplate(SqlTemplates.SQL_TEMPLATE_ID.BRANCH_IDS);
            insertBranchMenuItem.Click += new System.EventHandler(insertTemplate_Click);

            // Insert InBranch
            ToolStripMenuItem insertInBranchMenuItem = new ToolStripMenuItem();
            insertInBranchMenuItem.Text = "Insert #InBranch#";
            insertInBranchMenuItem.ToolTipText = SqlTemplates.getTooltip(SqlTemplates.SQL_TEMPLATE_ID.IN_BRANCH_IDS);
            insertInBranchMenuItem.Tag = SqlTemplates.getTemplate(SqlTemplates.SQL_TEMPLATE_ID.IN_BRANCH_IDS);
            insertInBranchMenuItem.Click += new System.EventHandler(insertTemplate_Click);

            // Insert CurrentID
            ToolStripMenuItem insertCurrentIdMenuItem = new ToolStripMenuItem();
            insertCurrentIdMenuItem.Text = "Insert #CurrentElementID#";
            insertCurrentIdMenuItem.ToolTipText = SqlTemplates.getTooltip(SqlTemplates.SQL_TEMPLATE_ID.CURRENT_ITEM_ID);
            insertCurrentIdMenuItem.Tag = SqlTemplates.getTemplate(SqlTemplates.SQL_TEMPLATE_ID.CURRENT_ITEM_ID);
            insertCurrentIdMenuItem.Click += new System.EventHandler(insertTemplate_Click);

            // Insert CurrentGUID
            ToolStripMenuItem insertCurrentGuidMenuItem = new ToolStripMenuItem();
            insertCurrentGuidMenuItem.Text = "Insert #CurrentElementGUID#";
            insertCurrentGuidMenuItem.ToolTipText = SqlTemplates.getTooltip(SqlTemplates.SQL_TEMPLATE_ID.CURRENT_ITEM_GUID);
            insertCurrentGuidMenuItem.Tag = SqlTemplates.getTemplate(SqlTemplates.SQL_TEMPLATE_ID.CURRENT_ITEM_GUID);
            insertCurrentGuidMenuItem.Click += new System.EventHandler(insertTemplate_Click);

            // Insert #WC#
            ToolStripMenuItem insertWcMenuItem = new ToolStripMenuItem();
            insertWcMenuItem.Text = "Insert #CurrentElementGUID#";
            insertWcMenuItem.ToolTipText = SqlTemplates.getTooltip(SqlTemplates.SQL_TEMPLATE_ID.WC);
            insertWcMenuItem.Tag = SqlTemplates.getTemplate(SqlTemplates.SQL_TEMPLATE_ID.WC);
            insertWcMenuItem.Click += new System.EventHandler(insertTemplate_Click);

            insertMacroMenuItem.DropDownItems.AddRange(new ToolStripItem[] {
                insertMacroSearchTermMenuItem,
                insertPackageMenuItem,
                insertBranchMenuItem,
                insertCurrentIdMenuItem,
                insertCurrentGuidMenuItem,
                insertWcMenuItem
                });

            // Load recent files into toolStrip menu
            loadRecentFilesIntoToolStripItems();


            //----------------------------------------------------------------------------------------------------------
            // ToolStripItem for
            // - TabPage
            // - SQL TextBox
            var toolStripItems = new ToolStripItem[] {
                _loadTabMenuItem,                   // load Tab from file
                _loadTabFromFileItem,                // load Tab from recent file        
                new ToolStripSeparator(),
                _newTabMenuItem,                     // new Tab
                _newTabFromItem,       // new Tab from recent file 
                new ToolStripSeparator(),
                insertTemplateMenuItem,             // insert template
                insertMacroMenuItem,                // insert macro
                new ToolStripSeparator(),
                fileRunMenuItem,                    // run query
                new ToolStripSeparator(),
                fileSaveMenuItem,                   // save query
                fileSaveAsMenuItem,                 // save query as..
                closeMenuItem
                };

            // Context Menu
            ContextMenuStrip contextMenuStrip = new ContextMenuStrip(_components);
            contextMenuStrip.Items.AddRange(toolStripItems);




            // Add ContextMenuStrip to TabControl an TextBox
            sqlTextBox.ContextMenuStrip = contextMenuStrip; 
            _tabControl.ContextMenuStrip = contextMenuStrip;
            return tabPage;
        }

         void sqlTextBox_TextChanged(object sender, EventArgs e)
        {
            // get TabPage
            TabPage tabPage = _tabControl.TabPages[_tabControl.SelectedIndex];
            SqlFile sqlFile = (SqlFile)tabPage.Tag;
            sqlFile.IsChanged = true;
            tabPage.Text = sqlFile.DisplayName;
        }

        /// <summary>
        /// Load RecentFiles MenuItems into MenuItemStrip
        /// </summary>
        /// <param name="loadRecentFileStripMenuItem">Item to load recent files as drop down items</param>
        /// <param name="eventHandler_Click">Function to handle event</param>
         void loadRecentFilesMenuItems(ToolStripMenuItem loadRecentFileStripMenuItem, EventHandler eventHandler_Click)
        {
            // delete all previous entries
            loadRecentFileStripMenuItem.DropDownItems.Clear();
            // over all history files
            foreach (HistoryFile historyFile in _settings.sqlFiles.lSqlHistoryFilesCfg)
            {
                // ignore empty entries
                if (historyFile.FullName == "") continue;
                ToolStripMenuItem historyEntry = new ToolStripMenuItem();
                historyEntry.Text = historyFile.DisplayName;
                historyEntry.Tag = historyFile;
                historyEntry.ToolTipText = historyFile.FullName;
                historyEntry.Click += eventHandler_Click;
                loadRecentFileStripMenuItem.DropDownItems.Add(historyEntry);

            }
        }
        /// <summary>
        /// New Tab and Load from history item
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
         void newTabAnLoadFromHistoryEntry_Click(object sender, EventArgs e)
        {
            // Add a new Tab
            TabPage tabPage = addTab();

            // get TabPage
            SqlFile sqlFile = (SqlFile)tabPage.Tag;

            // get TextBox
            TextBox textBox = (TextBox)tabPage.Controls[0];

            // Contend changed, need to be stored first
            if (sqlFile.IsChanged)
            {
                DialogResult result = MessageBox.Show($"Old File: '{sqlFile.FullName}'",
                    "First store old File? ", MessageBoxButtons.YesNoCancel);
                if (result == DialogResult.Cancel) return;
                if (result == DialogResult.Yes)
                {
                    save(tabPage);
                    sqlFile.IsChanged = false;
                    tabPage.ToolTipText = ((SqlFile)tabPage.Tag).FullName;
                }
            }
            HistoryFile historyFile = (HistoryFile)((ToolStripMenuItem)sender).Tag;
            string file = historyFile.FullName;
            loadFileForTabPage(tabPage, file);
        }

        /// <summary>
        /// Load file for tab Page
        /// </summary>
        /// <param name="tabPage"></param>
        /// <param name="file"></param>
         static void loadFileForTabPage(TabPage tabPage, string file)
        {
            
            try
            {
                StreamReader myStream = new StreamReader(file);
                if (myStream != null)
                {
                    TextBox textBox = (TextBox)tabPage.Controls[0];
                    textBox.Text = myStream.ReadToEnd();
                    myStream.Close();

                    // set TabName
                    SqlFile sqlFile = (SqlFile)tabPage.Tag;
                    sqlFile.FullName = file;
                    sqlFile.IsChanged = false;
                    tabPage.ToolTipText = ((SqlFile)tabPage.Tag).FullName;
                    tabPage.Text = sqlFile.DisplayName;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"{ex.Message}", $"Error reading File {file}");
                return;
            }
        }



        /// <summary>
        /// Load from history item
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void loadFromHistoryEntry_Click(object sender, EventArgs e)
        {
            // get TabPage
            TabPage tabPage = _tabControl.TabPages[_tabControl.SelectedIndex];
            SqlFile sqlFile = (SqlFile)tabPage.Tag;

            // get TextBox
            TextBox textBox = (TextBox)tabPage.Controls[0];

            // Contend changed, need to be stored first
            if (sqlFile.IsChanged)
            {
                DialogResult result = MessageBox.Show($"Old File: '{sqlFile.FullName}'",
                    "First store old File? ", MessageBoxButtons.YesNoCancel);
                if (result == DialogResult.Cancel) return;
                if (result == DialogResult.Yes) { 
                    saveAs(tabPage);
                    sqlFile.IsChanged = false;
                    tabPage.ToolTipText = ((SqlFile)tabPage.Tag).FullName;
                }
            }


            // load File
            HistoryFile historyFile = (HistoryFile)((ToolStripMenuItem)sender).Tag;
            string file = historyFile.FullName;
            loadFileForTabPage(tabPage, file);
        }
         void insertTemplate_Click(object sender, EventArgs e)
        {
            // get TabPage
            TabPage tabPage = _tabControl.TabPages[_tabControl.SelectedIndex];

            // get TextBox
            TextBox textBox = (TextBox)tabPage.Controls[0];

            // get the template to insert text
            ToolStripMenuItem menuItem = (ToolStripMenuItem)sender;
            SqlTemplate template = (SqlTemplate)menuItem.Tag;

            // Insert text
            var selectionIndex = textBox.SelectionStart;
            var templateText = template.TemplateText;
            textBox.Text = textBox.Text.Insert(selectionIndex, templateText);
            textBox.SelectionStart = selectionIndex + templateText.Length;


        }
       

        /// <summary>
        /// Event File Save As
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
         void fileSaveAsMenuItem_Click(object sender,  EventArgs e)
        {
            saveSqlTabAs();

        }

        
        #region saveTabAs
        /// <summary>
        /// Save current Tab into desired file
        /// </summary>
        public void saveSqlTabAs()
        {
            // get TabPage
            TabPage tabPage = _tabControl.TabPages[_tabControl.SelectedIndex];

            // get TextBox
            TextBox textBox = (TextBox)tabPage.Controls[0];
            saveAs(tabPage);
            tabPage.ToolTipText = ((SqlFile)tabPage.Tag).FullName;
            tabPage.Text = ((SqlFile)tabPage.Tag).DisplayName;
        }
        #endregion

        /// <summary>
        /// Event File Save
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void fileSaveMenuItem_Click(object sender, EventArgs e)
        {
            TabPage tabPage = _tabControl.TabPages[_tabControl.SelectedIndex];
            save(tabPage);
        }
       
        /// <summary>
        /// Save all unchanged Tabs. 
        /// </summary>
        public void saveAll()
        {
            foreach (TabPage tabPage in _tabControl.TabPages)
            {
                save(tabPage);
            }
        }
       
        /// <summary>
        /// Event File Load fired by TabControl
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void fileLoadMenuItem_Click(object sender, EventArgs e)
        {
            // get TabPage
            TabPage tabPage = _tabControl.TabPages[_tabControl.SelectedIndex];

            

            loadTabPage(tabPage);
            tabPage.ToolTipText = ((SqlFile)tabPage.Tag).FullName;
            tabPage.Text = ((SqlFile)tabPage.Tag).DisplayName;

        }
        /// <summary>
        /// Add tab fired by TabControl or TabPage
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
         void addTabMenuItem_Click(object sender, EventArgs e)
        {
            // get TabPage
            TabPage tabPage = _tabControl.TabPages[_tabControl.SelectedIndex];

            // get TextBox
            TextBox textBox = (TextBox)tabPage.Controls[0];

            addTab();


        }

        /// <summary>
        /// Event Close TabPage 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
         void closeMenuItem_Click(object sender, EventArgs e)
        {
            // get TabPage
            TabPage tabPage = _tabControl.TabPages[_tabControl.SelectedIndex];
            close(tabPage);

        }



        /// <summary>
        /// Load sql string from *.sql File into TabPage with TextBox inside.
        /// - Update and save the list of sql files 
        /// </summary>
        /// <param name="tabPage"></param>
        void loadTabPage(TabPage tabPage)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();

            openFileDialog.InitialDirectory = @"c:\temp\sql";
            openFileDialog.RestoreDirectory = true;
            openFileDialog.Filter = "sql files (*.sql)|*.sql|All files (*.*)|*.*";
            openFileDialog.FilterIndex = 1;

            if (openFileDialog.ShowDialog() == DialogResult.OK)

            {
                StreamReader myStream = new StreamReader(openFileDialog.OpenFile());
                if (myStream != null)
                {
                    // Code to write the stream goes here.
                    // get TextBox
                    TextBox textBox = (TextBox)tabPage.Controls[0];
                    textBox.Text = myStream.ReadToEnd();
                    myStream.Close();
                    tabPage.Text = Path.GetFileName(openFileDialog.FileName);

                    // store the complete filename in settings
                    _settings.sqlFiles.insert(openFileDialog.FileName);
                    _settings.save();

                    // Store TabData in TabPage
                    SqlFile sqlFile = new SqlFile(openFileDialog.FileName);
                    sqlFile.IsChanged = true;
                    tabPage.Tag = sqlFile;

                    // set TabName
                    tabPage.Text = sqlFile.DisplayName;

                    // Load recent files into ToolStripMenu
                    loadRecentFilesIntoToolStripItems();
                    
                }
            }

        }
        /// <summary>
        /// Save As... TabPage in *.sql File.
        /// </summary>
        /// <param name="tabPage></param>
         void saveAs(TabPage tabPage)
        {

            SqlFile sqlFile = (SqlFile)tabPage.Tag;
            SaveFileDialog saveFileDialog = new SaveFileDialog();

            saveFileDialog.InitialDirectory = sqlFile.DirectoryName;
            // get File name
            saveFileDialog.FileName = sqlFile.FullName;
            saveFileDialog.RestoreDirectory = true;
            saveFileDialog.Filter = "sql files (*.sql)|*.sql|All files (*.*)|*.*";
            saveFileDialog.FilterIndex = 1;

            if (saveFileDialog.ShowDialog() == DialogResult.OK)

            {
                StreamWriter myStream = new StreamWriter(saveFileDialog.OpenFile());
                if (myStream != null)
                {
                    // Code to write the stream goes here.
                    TextBox textBox = (TextBox)tabPage.Controls[0];
                    myStream.Write(textBox.Text);
                    myStream.Close();
                    tabPage.Text = Path.GetFileName(saveFileDialog.FileName);

                    // store the complete filename in settings
                    _settings.sqlFiles.insert(saveFileDialog.FileName);
                    _settings.save();

                    // Store TabData in TabPage
                    sqlFile.FullName = saveFileDialog.FileName;
                    sqlFile.IsChanged = false;

                    // set TabName
                    tabPage.Text = sqlFile.DisplayName;
                    tabPage.ToolTipText = ((SqlFile)tabPage.Tag).FullName;
                    loadRecentFilesIntoToolStripItems();
                }
            }
        }
        /// <summary>
        /// Update the following Menu Items with recent files:
        /// <para/>-File, Load Tab from..
        /// <para/>-File, Add Tab from..
        /// <para/>-Tab,  Load Tab from..
        /// <para/>-Tab,  Add Tab from..
        /// </summary>
        void loadRecentFilesIntoToolStripItems()
        {
            // File, Load Tab from
            loadRecentFilesMenuItems(_fileLoadRecentFileItem, loadFromHistoryEntry_Click);
            // File, Add Tab from..
            loadRecentFilesMenuItems(_fileNewTabAndLoadRecentFileItem, newTabAnLoadFromHistoryEntry_Click);

            // Tab,  Load Tab from..
            loadRecentFilesMenuItems(_loadTabFromFileItem, loadFromHistoryEntry_Click);
            // Tab,  Add Tab from..
            loadRecentFilesMenuItems(_newTabFromItem, newTabAnLoadFromHistoryEntry_Click);
        }

        /// <summary>
        /// Save sql TabPage in *.sql File.
        /// </summary>
        /// <param name="tabPage"></param>
        public void save(TabPage tabPage)
        {
            SqlFile sqlFile = (SqlFile)tabPage.Tag;
            if (! sqlFile.IsPersistant )
            {
                saveAs(tabPage);
                return;
            }

            try {
                StreamWriter myStream = new StreamWriter(sqlFile.FullName);
                if (myStream != null)
                {
                    TextBox textBox = (TextBox)tabPage.Controls[0];
                    myStream.Write(textBox.Text);
                    myStream.Close();
                    sqlFile.IsChanged = false;


                    // set TabName
                    tabPage.Text = sqlFile.DisplayName;
                }
            } catch (Exception ex)
            {
                MessageBox.Show($"{ex.Message}", $"Error writing File {sqlFile.FullName}");
                return;
            }
        }

        /// <summary>
        /// Close all Tab Pages
        /// </summary>
        public void closeAll()
        {
            foreach (TabPage tabPage in _tabControl.TabPages)
            {
                close(tabPage);
            }
        }
        /// <summary>
        /// Close TabPage
        /// - Ask to store content if changed
        /// </summary>
        /// <param name="tabPage"></param>
        public void close(TabPage tabPage)
        {

            SqlFile sqlFile = (SqlFile)tabPage.Tag;
            if (sqlFile.IsChanged)
            {

                DialogResult result = MessageBox.Show($"", "Close TabPage: Sql has changed, store content?", MessageBoxButtons.YesNoCancel);
                switch (result) {
                    case DialogResult.OK:
                        save(tabPage);
                        break;
                    case DialogResult.No:
                        break;
                    case DialogResult.Cancel:
                        return;

                }
            }
            _tabControl.TabPages.Remove(tabPage);
        }

        #region runSqlTabPage
        /// <summary>
        /// Run SQL for selected TabPage
        /// </summary>
        public void runSqlTabPage()
        {
            Cursor.Current = Cursors.WaitCursor;

            // get TabPage
            TabPage tabPage = _tabControl.TabPages[_tabControl.SelectedIndex];

            // get TextBox
            TextBox textBox = (TextBox)tabPage.Controls[0];
            GuiFunction.RunSql(_model, textBox.Text, _sqlTextBoxSearchTerm.Text);
            Cursor.Current = Cursors.Default;
        }
        #endregion

        void fileRunMenuItem_Click(object sender, EventArgs e)
        {
            runSqlTabPage();
        }



    }
}
