﻿Imports Microsoft.AspNet.Identity
Imports Microsoft.AspNet.Identity.Owin
Imports Microsoft.Owin
Imports Microsoft.Owin.Security.Cookies
Imports Microsoft.Owin.Security.Google
Imports Owin

Partial Public Class Startup
    ' Para obter mais informações sobre a autenticação de configuração, visite https://go.microsoft.com/fwlink/?LinkId=301864
    Public Sub ConfigureAuth(app As IAppBuilder)
        ' Configurar contexto db, gerenciador de usuários e gerenciador de entradas para usar uma única instância por solicitação
        app.CreatePerOwinContext(AddressOf ApplicationDbContext.Create)
        app.CreatePerOwinContext(Of ApplicationUserManager)(AddressOf ApplicationUserManager.Create)
        app.CreatePerOwinContext(Of ApplicationSignInManager)(AddressOf ApplicationSignInManager.Create)

        ' Ativar o aplicativo para usar um cookie e armazenar informações para o usuário conectado
        ' e para usar um cookie para armazenar temporariamente informações sobre o login de um usuário com um provedor de login de terceiros
        ' Configure o cookie de entrada
        ' OnValidateIdentity permite que o aplicativo valide o carimbo de segurança quando o usuário efetua login.
        ' Este é um recurso de segurança que é usado quando você altera uma senha ou adiciona um login externo à sua conta.
        app.UseCookieAuthentication(New CookieAuthenticationOptions() With {
            .AuthenticationType = DefaultAuthenticationTypes.ApplicationCookie,
            .Provider = New CookieAuthenticationProvider() With {
                .OnValidateIdentity = SecurityStampValidator.OnValidateIdentity(Of ApplicationUserManager, ApplicationUser)(
                    validateInterval:=TimeSpan.FromMinutes(30),
                    regenerateIdentity:=Function(manager, user) user.GenerateUserIdentityAsync(manager))},
            .LoginPath = New PathString("/Account/Login")})

        app.UseExternalSignInCookie(DefaultAuthenticationTypes.ExternalCookie)

        ' Permite que o aplicativo armazene temporariamente informações dos usuários quando eles estiverem verificando o segundo fator no processo de autenticação de dois fatores.
        app.UseTwoFactorSignInCookie(DefaultAuthenticationTypes.TwoFactorCookie, TimeSpan.FromMinutes(5))

        ' Permite que o aplicativo lembre o segundo fator de verificação de logon, como um telefone ou email.
        ' Depois de marcar esta opção, sua segunda etapa de verificação durante o processo de logon será lembrada no dispositivo do qual você entrou.
        ' Isso é semelhante à opção RememberMe quando você entra.
        app.UseTwoFactorRememberBrowserCookie(DefaultAuthenticationTypes.TwoFactorRememberBrowserCookie)

        ' Remover comentário das linhas a seguir para ativar o logon com provedores de logon terceirizados
        'app.UseMicrosoftAccountAuthentication(
        '    clientId:="",
        '    clientSecret:="")

        'app.UseTwitterAuthentication(
        '   consumerKey:="",
        '   consumerSecret:="")

        'app.UseFacebookAuthentication(
        '   appId:="",
        '   appSecret:="")

        'app.UseGoogleAuthentication(New GoogleOAuth2AuthenticationOptions() With {
        '   .ClientId = "",
        '   .ClientSecret = ""})
    End Sub
End Class
