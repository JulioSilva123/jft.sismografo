﻿'------------------------------------------------------------------------------
' <auto-generated>
'     O código foi gerado por uma ferramenta.
'     Versão de Tempo de Execução:4.0.30319.42000
'
'     As alterações ao arquivo poderão causar comportamento incorreto e serão perdidas se
'     o código for gerado novamente.
' </auto-generated>
'------------------------------------------------------------------------------

Namespace jft.sismografo.applstracecsharp.Properties
    <Global.System.Runtime.CompilerServices.CompilerGeneratedAttribute()>
    <Global.System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.VisualStudio.Editors.SettingsDesigner.SettingsSingleFileGenerator", "16.10.0.0")>
    Friend NotInheritable Partial Class Settings
        Inherits Global.System.Configuration.ApplicationSettingsBase

        Private Shared defaultInstance As Settings = CType((Global.System.Configuration.ApplicationSettingsBase.Synchronized(New Settings())), Settings)

        Public Shared ReadOnly Property [Default] As Settings
            Get
                Return defaultInstance
            End Get
        End Property

        <Global.System.Configuration.UserScopedSettingAttribute()>
        <Global.System.Diagnostics.DebuggerNonUserCodeAttribute()>
        <Global.System.Configuration.DefaultSettingValueAttribute("False")>
        Public Property chk_transpose As Boolean
            Get
                Return CBool(Me("chk_transpose"))
            End Get
            Set(ByVal value As Boolean)
                Me("chk_transpose") = value
            End Set
        End Property

        <Global.System.Configuration.UserScopedSettingAttribute()>
        <Global.System.Diagnostics.DebuggerNonUserCodeAttribute()>
        <Global.System.Configuration.DefaultSettingValueAttribute("12")>
        Public Property freq_low As Single
            Get
                Return CSng(Me("freq_low"))
            End Get
            Set(ByVal value As Single)
                Me("freq_low") = value
            End Set
        End Property

        <Global.System.Configuration.UserScopedSettingAttribute()>
        <Global.System.Diagnostics.DebuggerNonUserCodeAttribute()>
        <Global.System.Configuration.DefaultSettingValueAttribute("25")>
        Public Property freq_high As Single
            Get
                Return CSng(Me("freq_high"))
            End Get
            Set(ByVal value As Single)
                Me("freq_high") = value
            End Set
        End Property
    End Class
End Namespace