﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace WPFnba.Properties {
    
    
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.VisualStudio.Editors.SettingsDesigner.SettingsSingleFileGenerator", "17.12.0.0")]
    internal sealed partial class Settings : global::System.Configuration.ApplicationSettingsBase {
        
        private static Settings defaultInstance = ((Settings)(global::System.Configuration.ApplicationSettingsBase.Synchronized(new Settings())));
        
        public static Settings Default {
            get {
                return defaultInstance;
            }
        }
        
        [global::System.Configuration.ApplicationScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.SpecialSettingAttribute(global::System.Configuration.SpecialSetting.ConnectionString)]
        [global::System.Configuration.DefaultSettingValueAttribute("Server=tcp:sql-server-diegofercri.database.windows.net,1433;Initial Catalog=nbadb" +
            ";Persist Security Info=False;User ID=diego;Password=wjt7utrX*XAErMxis@GebdXM;Mul" +
            "tipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection" +
            " Timeout=30;")]
        public string WPFnbaConnectionString {
            get {
                return ((string)(this["WPFnbaConnectionString"]));
            }
        }
        
        [global::System.Configuration.ApplicationScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.SpecialSettingAttribute(global::System.Configuration.SpecialSetting.ConnectionString)]
        [global::System.Configuration.DefaultSettingValueAttribute("Data Source=sql-server-diegofercri.database.windows.net;Initial Catalog=nbadb;Per" +
            "sist Security Info=True;User ID=diego;Encrypt=True;TrustServerCertificate=True")]
        public string nbadbConnectionString1 {
            get {
                return ((string)(this["nbadbConnectionString1"]));
            }
        }
        
        [global::System.Configuration.ApplicationScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.SpecialSettingAttribute(global::System.Configuration.SpecialSetting.ConnectionString)]
        [global::System.Configuration.DefaultSettingValueAttribute("Server=tcp:sql-server-diegofercri.database.windows.net,1433;Initial Catalog=nbadb" +
            ";Persist Security Info=False;User ID=diego;Password=wjt7utrX*XAErMxis@GebdXM;Mul" +
            "tipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection" +
            " Timeout=30;")]
        public string nbadbConnectionString {
            get {
                return ((string)(this["nbadbConnectionString"]));
            }
        }
        
        [global::System.Configuration.ApplicationScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.SpecialSettingAttribute(global::System.Configuration.SpecialSetting.ConnectionString)]
        [global::System.Configuration.DefaultSettingValueAttribute("Data Source=sql-server-diegofercri.database.windows.net;Initial Catalog=nbadb;Per" +
            "sist Security Info=True;User ID=diego;Password=wjt7utrX*XAErMxis@GebdXM;Encrypt=" +
            "True;TrustServerCertificate=True")]
        public string nbadbConnectionString2 {
            get {
                return ((string)(this["nbadbConnectionString2"]));
            }
        }
        
        [global::System.Configuration.ApplicationScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.SpecialSettingAttribute(global::System.Configuration.SpecialSetting.ConnectionString)]
        [global::System.Configuration.DefaultSettingValueAttribute("Data Source=sql-server-diegofercri.database.windows.net;Initial Catalog=nbadb;Per" +
            "sist Security Info=True;User ID=diego;Encrypt=True;TrustServerCertificate=True")]
        public string nbadbConnectionString3 {
            get {
                return ((string)(this["nbadbConnectionString3"]));
            }
        }
    }
}
