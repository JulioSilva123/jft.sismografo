﻿@ModelType ManageLoginsViewModel
@Imports Microsoft.Owin.Security
@Imports Microsoft.AspNet.Identity
@Code
    ViewBag.Title = "Gerenciar seus logons externos"
End Code

<h2>@ViewBag.Title.</h2>

<p class="text-success">@ViewBag.StatusMessage</p>
@Code
    Dim loginProviders = Context.GetOwinContext().Authentication.GetExternalAuthenticationTypes()
    If loginProviders.Count = 0 Then
        @<div>
            <p>
                Não há nenhum serviço de autenticação externo configurado. Confira <a href="https://go.microsoft.com/fwlink/?LinkId=313242">este artigo</a>
                para obter detalhes de como configurar este aplicativo ASP.NET para permitir o registro em log usando serviços externos.
            </p>
        </div>
    Else
        If Model.CurrentLogins.Count > 0  Then
            @<h4>Logons registrados</h4>
            @<table class="table">
                <tbody>
                    @For Each account As UserLoginInfo In Model.CurrentLogins
                        @<tr>
                            <td>@account.LoginProvider</td>
                            <td>
                                @If ViewBag.ShowRemoveButton
                                    @Using Html.BeginForm("RemoveLogin", "Manage")
                                        @Html.AntiForgeryToken()
                                        @<div>
                                            @Html.Hidden("loginProvider", account.LoginProvider)
                                            @Html.Hidden("providerKey", account.ProviderKey)
                                            <input type="submit" class="btn btn-default" value="Remover" title="Remova este logon @account.LoginProvider de sua conta" />
                                        </div>
                                    End Using
                                Else
                                    @: &nbsp;
                                End If
                            </td>
                        </tr>
                    Next
                </tbody>
            </table>
        End If
        If Model.OtherLogins.Count > 0
            @<text>
            <h4>Adicione outro serviço para entrar.</h4>
            <hr />
            </text>
            @Using Html.BeginForm("LinkLogin", "Manage")
                @Html.AntiForgeryToken()
                @<div id="socialLoginList">
                <p>
                    @For Each p As AuthenticationDescription In Model.OtherLogins
                        @<button type="submit" class="btn btn-default" id="@p.AuthenticationType" name="provider" value="@p.AuthenticationType" title="Faça login usando sua conta @p.Caption">@p.AuthenticationType</button>
                    Next
                </p>
                </div>
            End Using
        End If
    End If
End Code
