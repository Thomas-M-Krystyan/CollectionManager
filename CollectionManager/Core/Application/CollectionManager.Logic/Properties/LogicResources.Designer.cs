﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace CollectionManager.Logic.Properties {
    using System;
    
    
    /// <summary>
    ///   A strongly-typed resource class, for looking up localized strings, etc.
    /// </summary>
    // This class was auto-generated by the StronglyTypedResourceBuilder
    // class via a tool like ResGen or Visual Studio.
    // To add or remove a member, edit your .ResX file then rerun ResGen
    // with the /str option, or rebuild your VS project.
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Resources.Tools.StronglyTypedResourceBuilder", "17.0.0.0")]
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    internal class LogicResources {
        
        private static global::System.Resources.ResourceManager resourceMan;
        
        private static global::System.Globalization.CultureInfo resourceCulture;
        
        [global::System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal LogicResources() {
        }
        
        /// <summary>
        ///   Returns the cached ResourceManager instance used by this class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        internal static global::System.Resources.ResourceManager ResourceManager {
            get {
                if (object.ReferenceEquals(resourceMan, null)) {
                    global::System.Resources.ResourceManager temp = new global::System.Resources.ResourceManager("CollectionManager.Logic.Properties.LogicResources", typeof(LogicResources).Assembly);
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
        ///   Looks up a localized string similar to The operation failed: .
        /// </summary>
        internal static string CrudStatus_Failure {
            get {
                return ResourceManager.GetString("CrudStatus_Failure", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to The operation succeeded: .
        /// </summary>
        internal static string CrudStatus_Success {
            get {
                return ResourceManager.GetString("CrudStatus_Success", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to No objects of type &apos;{0}&apos; could be retrieved. Reason: {1}.
        /// </summary>
        internal static string OperationGetAll_Failure {
            get {
                return ResourceManager.GetString("OperationGetAll_Failure", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to All objects of type &apos;{0}&apos; were retrieved successfully..
        /// </summary>
        internal static string OperationGetAll_Success {
            get {
                return ResourceManager.GetString("OperationGetAll_Success", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to The object with ID &apos;{0}&apos; could not be removed. Reason: {1}.
        /// </summary>
        internal static string OperationRemove_Failure {
            get {
                return ResourceManager.GetString("OperationRemove_Failure", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to The object with ID &apos;{0}&apos; was removed successfully..
        /// </summary>
        internal static string OperationRemove_Success {
            get {
                return ResourceManager.GetString("OperationRemove_Success", resourceCulture);
            }
        }
    }
}
