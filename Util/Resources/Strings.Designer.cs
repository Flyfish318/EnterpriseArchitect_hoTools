﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace hoTools.Utils.Resources {
    using System;
    
    
    /// <summary>
    ///   A strongly-typed resource class, for looking up localized strings, etc.
    /// </summary>
    // This class was auto-generated by the StronglyTypedResourceBuilder
    // class via a tool like ResGen or Visual Studio.
    // To add or remove a member, edit your .ResX file then rerun ResGen
    // with the /str option, or rebuild your VS project.
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Resources.Tools.StronglyTypedResourceBuilder", "4.0.0.0")]
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    internal class Strings {
        
        private static global::System.Resources.ResourceManager resourceMan;
        
        private static global::System.Globalization.CultureInfo resourceCulture;
        
        [global::System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal Strings() {
        }
        
        /// <summary>
        ///   Returns the cached ResourceManager instance used by this class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        internal static global::System.Resources.ResourceManager ResourceManager {
            get {
                if (object.ReferenceEquals(resourceMan, null)) {
                    global::System.Resources.ResourceManager temp = new global::System.Resources.ResourceManager("hoTools.Utils.Resources.Strings", typeof(Strings).Assembly);
                    resourceMan = temp;
                }
                return resourceMan;
            }
        }
        
        /// <summary>
        ///   Overrides the current thread's CurrentUICulture property for all
        ///   resource lookups using this strongly typed resource class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        internal static global::System.Globalization.CultureInfo Culture {
            get {
                return resourceCulture;
            }
            set {
                resourceCulture = value;
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to //
        ///// Get Connector (conveyed items) from selected Elements
        ///// Select Element and get diagram
        /////
        ///select  s.ea_guid AS CLASSGUID, s.object_type AS CLASSTYPE, s.name As Source , d.name As Destination
        ///from t_xref x,   // a lot of things like properties,..
        ///     t_connector c,
        ///     t_object s, // Souce element
        ///     t_object d  // destination element
        ///
        ///where  x.description like  &apos;#WC##CurrentElementGUID##WC#&apos; AND
        ///       x.Behavior = &apos;conveyed&apos; AND
        ///       c.ea_guid = x.client    
        ///
        ///and    c.ea_guid = x [rest of string was truncated]&quot;;.
        /// </summary>
        internal static string ConnectorsFromElementTemplate {
            get {
                return ResourceManager.GetString("ConnectorsFromElementTemplate", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to //
        ///// Get Elements from selected Connector (conveyed Items)
        /////
        ///select  o.ea_guid AS CLASSGUID, o.object_type AS CLASSTYPE, o.name As Element
        ///from t_object o
        ///
        ///where  o.Object_ID in ( #ConveyedItemIDS# ).
        /// </summary>
        internal static string ConveyedItemsIdsTemplate {
            get {
                return ResourceManager.GetString("ConveyedItemsIdsTemplate", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to //
        ///// Get current Item GUID (Package, Diagram, Element, Attribut, Operation)
        /////
        ///// Template for macro: #CurrentItemGUID# or Alias #CurrentElementGUID#
        /////
        ///// V1.00 17. May 2016 created
        /////
        ///
        ///// As Element
        ///select o.ea_guid AS CLASSGUID, o.object_type AS CLASSTYPE,o.Name AS Name,o.object_type As Type 
        ///from t_object o
        ///where o.ea_guid = &apos;#CurrentElementGUID#&apos;
        ///
        ///UNION
        ///
        ///// As Diagram
        ///select dia.ea_guid AS CLASSGUID, dia.diagram_type AS CLASSTYPE,dia.Name AS Name,dia.diagram_type As Type 
        ///from t_diagr [rest of string was truncated]&quot;;.
        /// </summary>
        internal static string CurrentItemGuidTemplate {
            get {
                return ResourceManager.GetString("CurrentItemGuidTemplate", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to //
        ///// Get current Item ID (Package, Diagram, Element, Attribut, Operation)
        /////
        ///// Template for macro: #CurrentItemID# or Alias #CurrentElementID#
        ///// Pay Attention: ID may be ambiguous. Better use #CurrentItemId#
        /////
        ///// V1.00 17. May 2016 created
        /////
        ///
        ///// As Element
        ///select o.ea_guid AS CLASSGUID, o.object_type AS CLASSTYPE,o.Name AS Name,o.object_type As Type 
        ///from t_object o
        ///where o.object_ID = #CurrentElementID#
        ///
        ///UNION
        ///
        ///// As Diagram
        ///select dia.ea_guid AS CLASSGUID, dia.diagram_type AS CLASSTY [rest of string was truncated]&quot;;.
        /// </summary>
        internal static string CurrentItemIdTemplate {
            get {
                return ResourceManager.GetString("CurrentItemIdTemplate", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to //
        ///// Template delete tree selected 
        /////
        ///delete from t_object 
        ///where ea_guid in (#TreeSelectedGUIDS#).
        /// </summary>
        internal static string DeleteTreeSelectedItemsTemplate {
            get {
                return ResourceManager.GetString("DeleteTreeSelectedItemsTemplate", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to //
        ///// Template DemoRunScript
        ///// use Script: 
        ///// - hoDemoScript (3 parameters)
        ///// - hoDemoPrintContext (2 parameters)
        /////
        /////
        ///select o.ea_guid AS CLASSGUID, o.object_type AS CLASSTYPE,o.Name AS Name,o.object_type As Type 
        ///from t_object o
        ///where o.name like &apos;&lt;Search Term&gt;#WC#&apos; AND      o.object_type in 
        ///     (
        ///      &quot;Class&quot;,&quot;Component&quot;
        ///      )
        ///ORDER BY o.Name.
        /// </summary>
        internal static string DemoRunScript {
            get {
                return ResourceManager.GetString("DemoRunScript", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to //
        ///// Template DiagramElements_IDS
        /////
        ///select o.ea_guid AS CLASSGUID, o.object_type AS CLASSTYPE,o.Name AS Name,o.object_type As Type 
        ///from t_object o
        ///where o.object_ID in (#DiagramElements_IDS#)
        ///  
        ///ORDER BY o.Name.
        /// </summary>
        internal static string DiagramElementsIdsTemplate {
            get {
                return ResourceManager.GetString("DiagramElementsIdsTemplate", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to //
        ///// Template DiagramElements_IDS
        /////
        ///select o.ea_guid AS CLASSGUID, o.object_type AS CLASSTYPE,o.Name AS Name,o.object_type As Type 
        ///from t_object o
        ///where o.object_ID in (#DiagramSelectedElements_IDS#)
        ///  
        ///ORDER BY o.Name.
        /// </summary>
        internal static string DiagramSelectedElementsIdsTemplate {
            get {
                return ResourceManager.GetString("DiagramSelectedElementsIdsTemplate", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to //
        ///// Template Insert Element into current selected Package (direct or indirect selected via Element, Diagram, Operation, Attribute in Package)
        /////
        ///insert into t_object 
        ///   (ea_guid, object_type, Name, Package_ID)
        ///values
        ///   (&apos;#NewGuid#&apos;, &apos;Class&apos;, &apos;XXXX&apos;, #Package#).
        /// </summary>
        internal static string InsertElementIntoCurrentPackage {
            get {
                return ResourceManager.GetString("InsertElementIntoCurrentPackage", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to &lt;?xml version=&quot;1.0&quot; encoding=&quot;utf-8&quot;?&gt;
        ///&lt;RootSearch&gt;
        ///  &lt;Search Name=&quot;Favorites&quot; GUID=&quot;{A70B9F0E-14CD-4c03-B8FE-21C644DC2D5E}&quot; PkgGUID=&quot;-1&quot; Type=&quot;0&quot; LnksToObj=&quot;0&quot; CustomSearch=&quot;1&quot; AddinAndMethodName=&quot;&quot;&gt;
        ///    &lt;SrchOn&gt;
        ///      &lt;RootTable Filter=&quot;select o.ea_guid As CLASSGUID, o.Object_Type as CLASSTYPE, o.Name, o.stereotype, o.object_type As [EAType], &apos;Element&apos; As [Type]&amp;#xD;&amp;#xA;from t_object o inner join t_xref x on (o.EA_GUID = x.client)&amp;#xD;&amp;#xA;where Type = &apos;Favorite&apos;&amp;#xD;&amp;#xA;UNION&amp;#xD;&amp;#xA;select d.ea_g [rest of string was truncated]&quot;;.
        /// </summary>
        internal static string SearchFavorite {
            get {
                return ResourceManager.GetString("SearchFavorite", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Favorites.
        /// </summary>
        internal static string SearchFavoriteName {
            get {
                return ResourceManager.GetString("SearchFavoriteName", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to //
        ///// Template Update Current selected Item (Element, Diagram, Attribute, Operation) 
        /////
        ///update t_object set
        ///   name = &apos;XXXClass55&apos;
        ///where object_ID = #CurrentItemID#.
        /// </summary>
        internal static string UpdateCurrentSelectedItemTemplate {
            get {
                return ResourceManager.GetString("UpdateCurrentSelectedItemTemplate", resourceCulture);
            }
        }
    }
}
