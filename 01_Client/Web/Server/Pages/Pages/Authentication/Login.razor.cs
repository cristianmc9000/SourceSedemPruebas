using Blazored.FluentValidation;
using Infraestructura.Abstract;
using Infraestructura.Models.Authentication;
using MudBlazor;

namespace Server.Pages.Pages.Authentication
{
    public partial class Login
    {
        private LoginRequest _tokenModel = new();
        private FluentValidationValidator _fluentValidationValidator;
        bool PasswordVisibility;
        InputType PasswordInput = InputType.Password;
        string PasswordInputIcon = Icons.Material.Filled.VisibilityOff;
        private bool Validated => _fluentValidationValidator.Validate(options => { options.IncludeAllRuleSets(); });

        async void SubmitAsync()
        {
            _Loading.Show();
            var result = await _Rest.PostAsync("Identity/autenticate", _tokenModel);
            if (result.StatusCode != System.Net.HttpStatusCode.OK)
            {
                _MessageShow(result.message, State.Error);
                _DialogShow(result.message, State.Error);
                _Loading.Hide();
            }
            else
            {
                await _LoginService.LoginAsync(result);
                _Loading.Hide();
                _navMgr.NavigateTo("/dashboard", true);
            }
        }

        void TogglePasswordVisibility()
        {
            if (PasswordVisibility)
            {
                PasswordVisibility = false;
                PasswordInputIcon = Icons.Material.Filled.VisibilityOff;
                PasswordInput = InputType.Password;
            }
            else
            {
                PasswordVisibility = true;
                PasswordInputIcon = Icons.Material.Filled.Visibility;
                PasswordInput = InputType.Text;
            }
        }
    }
}
