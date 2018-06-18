//---------------------------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated by T4Model template for T4 (https://github.com/linq2db/linq2db).
//    Changes to this file may cause incorrect behavior and will be lost if the code is regenerated.
// </auto-generated>
//---------------------------------------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.Linq;

using LinqToDB;
using LinqToDB.Mapping;

namespace DataModels.VcSymbols
{
    /// <summary>
    /// Database       : .BROWSE.VC
    /// Data Source    : .BROWSE.VC
    /// Server Version : 3.19.3
    /// </summary>BROWSEVCDB/BrowseVcDB
    public partial class BROWSEVCDB : LinqToDB.Data.DataConnection
	{
		public ITable<AssocSpans>       AssocSpans       { get { return this.GetTable<AssocSpans>(); } }
		public ITable<AssocText>        AssocText        { get { return this.GetTable<AssocText>(); } }
		public ITable<BaseClassParents> BaseClassParents { get { return this.GetTable<BaseClassParents>(); } }
		public ITable<CodeItemKinds>    CodeItemKinds    { get { return this.GetTable<CodeItemKinds>(); } }
		public ITable<CodeItems>        CodeItems        { get { return this.GetTable<CodeItems>(); } }
		public ITable<Config>           Configs          { get { return this.GetTable<Config>(); } }
		public ITable<ConfigFiles>      ConfigFiles      { get { return this.GetTable<ConfigFiles>(); } }
		public ITable<File>             Files            { get { return this.GetTable<File>(); } }
		public ITable<FileMap>          FileMap          { get { return this.GetTable<FileMap>(); } }
		public ITable<FileSignatures>   FileSignatures   { get { return this.GetTable<FileSignatures>(); } }
		public ITable<HintFiles>        HintFiles        { get { return this.GetTable<HintFiles>(); } }
		public ITable<Parser>           Parsers          { get { return this.GetTable<Parser>(); } }
		public ITable<Project>          Projects         { get { return this.GetTable<Project>(); } }
		public ITable<ProjectRefs>      ProjectRefs      { get { return this.GetTable<ProjectRefs>(); } }
		public ITable<Property>         Properties       { get { return this.GetTable<Property>(); } }
		public ITable<SharedText>       SharedText       { get { return this.GetTable<SharedText>(); } }

		public BROWSEVCDB()
		{
			InitDataContext();
		}

		public BROWSEVCDB(string configuration)
			: base(configuration)
		{
			InitDataContext();
		}

		partial void InitDataContext();
	}

	[Table("assoc_spans")]
	public partial class AssocSpans
	{
		[Column("code_item_id"), NotNull] public long CodeItemId  { get; set; } // bigint
		[Column("kind"),         NotNull] public byte Kind        { get; set; } // tinyint
		[Column("start_column"), NotNull] public long StartColumn { get; set; } // integer
		[Column("start_line"),   NotNull] public long StartLine   { get; set; } // integer
		[Column("end_column"),   NotNull] public long EndColumn   { get; set; } // integer
		[Column("end_line"),     NotNull] public long EndLine     { get; set; } // integer

		#region Associations

		/// <summary>
		/// FK_assoc_spans_0_0
		/// </summary>
		[Association(ThisKey="CodeItemId", OtherKey="Id", CanBeNull=false, Relationship=Relationship.ManyToOne, KeyName="FK_assoc_spans_0_0", BackReferenceName="assocspans")]
		public CodeItems code_item_ { get; set; }

		#endregion
	}

	[Table("assoc_text")]
	public partial class AssocText
	{
		[Column("code_item_id"), NotNull] public long   CodeItemId { get; set; } // bigint
		[Column("kind"),         NotNull] public byte   Kind       { get; set; } // tinyint
		[Column("text"),         NotNull] public string Text       { get; set; } // text(max)

		#region Associations

		/// <summary>
		/// FK_assoc_text_0_0
		/// </summary>
		[Association(ThisKey="CodeItemId", OtherKey="Id", CanBeNull=false, Relationship=Relationship.ManyToOne, KeyName="FK_assoc_text_0_0", BackReferenceName="assoctexts")]
		public CodeItems code_item_ { get; set; }

		#endregion
	}

	[Table("base_class_parents")]
	public partial class BaseClassParents
	{
		[Column("base_code_item_id"),   NotNull] public long BaseCodeItemId   { get; set; } // bigint
		[Column("parent_code_item_id"), NotNull] public long ParentCodeItemId { get; set; } // bigint

		#region Associations

		/// <summary>
		/// FK_base_class_parents_1_0
		/// </summary>
		[Association(ThisKey="BaseCodeItemId", OtherKey="Id", CanBeNull=false, Relationship=Relationship.ManyToOne, KeyName="FK_base_class_parents_1_0", BackReferenceName="FK_base_class_parents_1_0_BackReferences")]
		public CodeItems base_code_item_ { get; set; }

		/// <summary>
		/// FK_base_class_parents_0_0
		/// </summary>
		[Association(ThisKey="ParentCodeItemId", OtherKey="Id", CanBeNull=false, Relationship=Relationship.ManyToOne, KeyName="FK_base_class_parents_0_0", BackReferenceName="baseclassparents")]
		public CodeItems parent_code_item_ { get; set; }

		#endregion
	}

	[Table("code_item_kinds")]
	public partial class CodeItemKinds
	{
		[Column("id"),          PrimaryKey, NotNull] public long   Id         { get; set; } // integer
		[Column("name"),                    NotNull] public string Name       { get; set; } // text(max)
		[Column("parser_guid"),             NotNull] public string ParserGuid { get; set; } // text(max)

		#region Associations

		/// <summary>
		/// FK_code_item_kinds_0_0
		/// </summary>
		[Association(ThisKey="ParserGuid", OtherKey="ParserGuid", CanBeNull=false, Relationship=Relationship.ManyToOne, KeyName="FK_code_item_kinds_0_0", BackReferenceName="codeitemkinds")]
		public Parser parser_gu { get; set; }

		#endregion
	}

	[Table("code_items")]
	public partial class CodeItems
	{
		[Column("id"),                               PrimaryKey,  NotNull] public long   Id                           { get; set; } // bigint
		[Column("file_id"),                                       NotNull] public long   FileId                       { get; set; } // bigint
		[Column("parent_id"),                                     NotNull] public long   ParentId                     { get; set; } // bigint
		[Column("kind"),                                          NotNull] public long   Kind                         { get; set; } // integer
		[Column("attributes"),                                    NotNull] public long   Attributes                   { get; set; } // integer
		[Column("name"),                                          NotNull] public string Name                         { get; set; } // text(max)
		[Column("type"),                                Nullable         ] public string Type                         { get; set; } // text(max)
		[Column("start_column"),                                  NotNull] public long   StartColumn                  { get; set; } // integer
		[Column("start_line"),                                    NotNull] public long   StartLine                    { get; set; } // integer
		[Column("end_column"),                                    NotNull] public long   EndColumn                    { get; set; } // integer
		[Column("end_line"),                                      NotNull] public long   EndLine                      { get; set; } // integer
		[Column("name_start_column"),                             NotNull] public long   NameStartColumn              { get; set; } // integer
		[Column("name_start_line"),                               NotNull] public long   NameStartLine                { get; set; } // integer
		[Column("name_end_column"),                               NotNull] public long   NameEndColumn                { get; set; } // integer
		[Column("name_end_line"),                                 NotNull] public long   NameEndLine                  { get; set; } // integer
		[Column("param_default_value"),                 Nullable         ] public string ParamDefaultValue            { get; set; } // text(max)
		[Column("param_default_value_start_column"),    Nullable         ] public long?  ParamDefaultValueStartColumn { get; set; } // integer
		[Column("param_default_value_start_line"),      Nullable         ] public long?  ParamDefaultValueStartLine   { get; set; } // integer
		[Column("param_default_value_end_column"),      Nullable         ] public long?  ParamDefaultValueEndColumn   { get; set; } // integer
		[Column("param_default_value_end_line"),        Nullable         ] public long?  ParamDefaultValueEndLine     { get; set; } // integer
		[Column("param_number"),                        Nullable         ] public short? ParamNumber                  { get; set; } // smallint
		[Column("lower_name_hint"),                               NotNull] public string LowerNameHint                { get; set; } // text(max)

		#region Associations

		/// <summary>
		/// FK_assoc_spans_0_0_BackReference
		/// </summary>
		[Association(ThisKey="Id", OtherKey="CodeItemId", CanBeNull=true, Relationship=Relationship.OneToMany, IsBackReference=true)]
		public IEnumerable<AssocSpans> assocspans { get; set; }

		/// <summary>
		/// FK_assoc_text_0_0_BackReference
		/// </summary>
		[Association(ThisKey="Id", OtherKey="CodeItemId", CanBeNull=true, Relationship=Relationship.OneToMany, IsBackReference=true)]
		public IEnumerable<AssocText> assoctexts { get; set; }

		/// <summary>
		/// FK_base_class_parents_0_0_BackReference
		/// </summary>
		[Association(ThisKey="Id", OtherKey="ParentCodeItemId", CanBeNull=true, Relationship=Relationship.OneToMany, IsBackReference=true)]
		public IEnumerable<BaseClassParents> baseclassparents { get; set; }

		/// <summary>
		/// FK_base_class_parents_1_0_BackReference
		/// </summary>
		[Association(ThisKey="Id", OtherKey="BaseCodeItemId", CanBeNull=true, Relationship=Relationship.OneToMany, IsBackReference=true)]
		public IEnumerable<BaseClassParents> FK_base_class_parents_1_0_BackReferences { get; set; }

		#endregion
	}

	[Table("configs")]
	public partial class Config
	{
		[Column("id"),                              PrimaryKey,  NotNull] public long   Id                           { get; set; } // bigint
		[Column("hash"),                                         NotNull] public long   Hash                         { get; set; } // bigint
		[Column("project_id"),                                   NotNull] public long   ProjectId                    { get; set; } // bigint
		[Column("name"),                                         NotNull] public string Name                         { get; set; } // text(max)
		[Column("toolset_isense_identifier"),          Nullable         ] public string ToolsetIsenseIdentifier      { get; set; } // text(max)
		[Column("exclude_path"),                                 NotNull] public long   ExcludePath                  { get; set; } // bigint
		[Column("config_include_path"),                          NotNull] public long   ConfigIncludePath            { get; set; } // bigint
		[Column("config_framework_include_path"),                NotNull] public long   ConfigFrameworkIncludePath   { get; set; } // bigint
		[Column("config_options"),                               NotNull] public long   ConfigOptions                { get; set; } // bigint
		[Column("platform_include_path"),                        NotNull] public long   PlatformIncludePath          { get; set; } // bigint
		[Column("platform_framework_include_path"),              NotNull] public long   PlatformFrameworkIncludePath { get; set; } // bigint
		[Column("platform_options"),                             NotNull] public long   PlatformOptions              { get; set; } // bigint

		#region Associations

		/// <summary>
		/// FK_config_files_1_0_BackReference
		/// </summary>
		[Association(ThisKey="Id", OtherKey="ConfigId", CanBeNull=true, Relationship=Relationship.OneToMany, IsBackReference=true)]
		public IEnumerable<ConfigFiles> configfiles { get; set; }

		/// <summary>
		/// FK_configs_0_0
		/// </summary>
		[Association(ThisKey="ProjectId", OtherKey="Id", CanBeNull=false, Relationship=Relationship.ManyToOne, KeyName="FK_configs_0_0", BackReferenceName="configs")]
		public Project project_ { get; set; }

		/// <summary>
		/// FK_project_refs_0_0_BackReference
		/// </summary>
		[Association(ThisKey="Id", OtherKey="ConfigId", CanBeNull=true, Relationship=Relationship.OneToMany, IsBackReference=true)]
		public IEnumerable<ProjectRefs> projectrefs { get; set; }

		#endregion
	}

	[Table("config_files")]
	public partial class ConfigFiles
	{
		[Column("config_id"),              NotNull] public long ConfigId             { get; set; } // bigint
		[Column("file_id"),                NotNull] public long FileId               { get; set; } // bigint
		[Column("implicit"),               NotNull] public byte @implicit            { get; set; } // tinyint
		[Column("reference"),              NotNull] public byte Reference            { get; set; } // tinyint
		[Column("compiled"),               NotNull] public byte Compiled             { get; set; } // tinyint
		[Column("compiled_pch"),           NotNull] public byte CompiledPch          { get; set; } // tinyint
		[Column("explicit"),               NotNull] public byte @explicit            { get; set; } // tinyint
		[Column("shared"),                 NotNull] public byte Shared               { get; set; } // tinyint
		[Column("generated"),              NotNull] public byte Generated            { get; set; } // tinyint
		[Column("config_final"),           NotNull] public byte ConfigFinal          { get; set; } // tinyint
		[Column("include_path"),           NotNull] public long IncludePath          { get; set; } // bigint
		[Column("framework_include_path"), NotNull] public long FrameworkIncludePath { get; set; } // bigint
		[Column("options"),                NotNull] public long Options              { get; set; } // bigint

		#region Associations

		/// <summary>
		/// FK_config_files_1_0
		/// </summary>
		[Association(ThisKey="ConfigId", OtherKey="Id", CanBeNull=false, Relationship=Relationship.ManyToOne, KeyName="FK_config_files_1_0", BackReferenceName="configfiles")]
		public Config config_ { get; set; }

		/// <summary>
		/// FK_config_files_0_0
		/// </summary>
		[Association(ThisKey="FileId", OtherKey="Id", CanBeNull=false, Relationship=Relationship.ManyToOne, KeyName="FK_config_files_0_0", BackReferenceName="configs")]
		public File file_ { get; set; }

		#endregion
	}

	[Table("files")]
	public partial class File
	{
		[Column("id"),          PrimaryKey, NotNull] public long   Id         { get; set; } // bigint
		[Column("timestamp"),               NotNull] public long   Timestamp  { get; set; } // bigint
		[Column("parsetime"),               NotNull] public long   Parsetime  { get; set; } // integer
		[Column("addtime"),                 NotNull] public long   Addtime    { get; set; } // integer
		[Column("difftime"),                NotNull] public long   Difftime   { get; set; } // integer
		[Column("name"),                    NotNull] public string Name       { get; set; } // text(max)
		[Column("leaf_name"),               NotNull] public string LeafName   { get; set; } // text(max)
		[Column("attributes"),              NotNull] public long   Attributes { get; set; } // integer
		[Column("parser_guid"),             NotNull] public string ParserGuid { get; set; } // text(max)

		#region Associations

		/// <summary>
		/// FK_config_files_0_0_BackReference
		/// </summary>
		[Association(ThisKey="Id", OtherKey="FileId", CanBeNull=true, Relationship=Relationship.OneToMany, IsBackReference=true)]
		public IEnumerable<ConfigFiles> configs { get; set; }

		/// <summary>
		/// FK_file_signatures_0_0_BackReference
		/// </summary>
		[Association(ThisKey="Id", OtherKey="FileId", CanBeNull=true, Relationship=Relationship.OneToMany, IsBackReference=true)]
		public IEnumerable<FileSignatures> filesignatures { get; set; }

		/// <summary>
		/// FK_files_0_0
		/// </summary>
		[Association(ThisKey="ParserGuid", OtherKey="ParserGuid", CanBeNull=false, Relationship=Relationship.ManyToOne, KeyName="FK_files_0_0", BackReferenceName="files")]
		public Parser parser_gu { get; set; }

		#endregion
	}

	[Table("file_map")]
	public partial class FileMap
	{
		[Column("code_item_id"), NotNull] public long CodeItemId { get; set; } // bigint
		[Column("config_id"),    NotNull] public long ConfigId   { get; set; } // bigint
		[Column("file_id"),      NotNull] public long FileId     { get; set; } // bigint
	}

	[Table("file_signatures")]
	public partial class FileSignatures
	{
		[Column("file_id"),   NotNull] public long   FileId    { get; set; } // bigint
		[Column("kind"),      NotNull] public byte   Kind      { get; set; } // tinyint
		[Column("signature"), NotNull] public byte[] Signature { get; set; } // blob

		#region Associations

		/// <summary>
		/// FK_file_signatures_0_0
		/// </summary>
		[Association(ThisKey="FileId", OtherKey="Id", CanBeNull=false, Relationship=Relationship.ManyToOne, KeyName="FK_file_signatures_0_0", BackReferenceName="filesignatures")]
		public File file_ { get; set; }

		#endregion
	}

	[Table("hint_files")]
	public partial class HintFiles
	{
		[Column("id"),        PrimaryKey, NotNull] public long   Id        { get; set; } // bigint
		[Column("timestamp"),             NotNull] public long   Timestamp { get; set; } // bigint
		[Column("name"),                  NotNull] public string Name      { get; set; } // text(max)
	}

	[Table("parsers")]
	public partial class Parser
	{
		[Column("parser_guid"), PrimaryKey, NotNull] public string ParserGuid { get; set; } // text(max)
		[Column("name"),                    NotNull] public string Name       { get; set; } // text(max)
		[Column("short_name"),              NotNull] public string ShortName  { get; set; } // text(max)

		#region Associations

		/// <summary>
		/// FK_code_item_kinds_0_0_BackReference
		/// </summary>
		[Association(ThisKey="ParserGuid", OtherKey="ParserGuid", CanBeNull=true, Relationship=Relationship.OneToMany, IsBackReference=true)]
		public IEnumerable<CodeItemKinds> codeitemkinds { get; set; }

		/// <summary>
		/// FK_files_0_0_BackReference
		/// </summary>
		[Association(ThisKey="ParserGuid", OtherKey="ParserGuid", CanBeNull=true, Relationship=Relationship.OneToMany, IsBackReference=true)]
		public IEnumerable<File> files { get; set; }

		#endregion
	}

	[Table("projects")]
	public partial class Project
	{
		[Column("id"),     PrimaryKey, NotNull] public long   Id     { get; set; } // bigint
		[Column("name"),               NotNull] public string Name   { get; set; } // text(max)
		[Column("guid"),               NotNull] public string Guid   { get; set; } // text(max)
		[Column("shared"),             NotNull] public byte   Shared { get; set; } // tinyint

		#region Associations

		/// <summary>
		/// FK_configs_0_0_BackReference
		/// </summary>
		[Association(ThisKey="Id", OtherKey="ProjectId", CanBeNull=true, Relationship=Relationship.OneToMany, IsBackReference=true)]
		public IEnumerable<Config> configs { get; set; }

		#endregion
	}

	[Table("project_refs")]
	public partial class ProjectRefs
	{
		[Column("config_id"),        NotNull] public long ConfigId       { get; set; } // bigint
		[Column("resolved_name"),    NotNull] public long ResolvedName   { get; set; } // bigint
		[Column("project_ref_name"), NotNull] public long ProjectRefName { get; set; } // bigint
		[Column("project_ref_guid"), NotNull] public long ProjectRefGuid { get; set; } // bigint

		#region Associations

		/// <summary>
		/// FK_project_refs_0_0
		/// </summary>
		[Association(ThisKey="ConfigId", OtherKey="Id", CanBeNull=false, Relationship=Relationship.ManyToOne, KeyName="FK_project_refs_0_0", BackReferenceName="projectrefs")]
		public Config config_ { get; set; }

		#endregion
	}

	[Table("properties")]
	public partial class Property
	{
		[Column("name"),  PrimaryKey, NotNull] public string Name  { get; set; } // text(max)
		[Column("value"),             NotNull] public string Value { get; set; } // text(max)
	}

	[Table("shared_text")]
	public partial class SharedText
	{
		[Column("id"),   PrimaryKey, NotNull] public long   Id   { get; set; } // bigint
		[Column("hash"),             NotNull] public long   Hash { get; set; } // bigint
		[Column("text"),             NotNull] public string Text { get; set; } // text(max)
	}

	public static partial class TableExtensions
	{
		public static CodeItemKinds Find(this ITable<CodeItemKinds> table, long Id)
		{
			return table.FirstOrDefault(t =>
				t.Id == Id);
		}

		public static CodeItems Find(this ITable<CodeItems> table, long Id)
		{
			return table.FirstOrDefault(t =>
				t.Id == Id);
		}

		public static Config Find(this ITable<Config> table, long Id)
		{
			return table.FirstOrDefault(t =>
				t.Id == Id);
		}

		public static File Find(this ITable<File> table, long Id)
		{
			return table.FirstOrDefault(t =>
				t.Id == Id);
		}

		public static HintFiles Find(this ITable<HintFiles> table, long Id)
		{
			return table.FirstOrDefault(t =>
				t.Id == Id);
		}

		public static Parser Find(this ITable<Parser> table, string ParserGuid)
		{
			return table.FirstOrDefault(t =>
				t.ParserGuid == ParserGuid);
		}

		public static Project Find(this ITable<Project> table, long Id)
		{
			return table.FirstOrDefault(t =>
				t.Id == Id);
		}

		public static Property Find(this ITable<Property> table, string Name)
		{
			return table.FirstOrDefault(t =>
				t.Name == Name);
		}

		public static SharedText Find(this ITable<SharedText> table, long Id)
		{
			return table.FirstOrDefault(t =>
				t.Id == Id);
		}
	}
}