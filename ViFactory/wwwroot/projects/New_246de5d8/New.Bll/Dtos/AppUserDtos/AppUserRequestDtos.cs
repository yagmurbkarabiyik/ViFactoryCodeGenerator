using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Http;
using System.ComponentModel;
using FluentValidation;
using New.Core.Enums;
using New.Domain.IdentityModels;

namespace New.Bll.Dtos.AppUserDtos
{
    public record AppUserCreateRequestDto()
    {
        [DisplayName("Adı *")]
        public string Name { get; set; } = null!;
        [DisplayName("Soyadı *")]
        public string Surname { get; set; } = null!;
        [DisplayName("Email *")]
        public string Email { get; set; } = null!;
        [DisplayName("Şifre *")]
        public string Password { get; set; } = null!;
        [DisplayName("Şifre Tekrar *")]
        public string PasswordConfirm { get; set; } = null!;
    }

    public class AppUserCreateRequestValidator : AbstractValidator<AppUserCreateRequestDto>
    {
        private readonly UserManager<AppUser> _userManager;

        public AppUserCreateRequestValidator(UserManager<AppUser> userManager)
        {
            _userManager = userManager;

            RuleFor(x => x.Name)
                .NotNull().WithMessage("Bu alan gereklidir")
                .NotEmpty().WithMessage("Bu alan gereklidir")
                .WithName("Adı");
            RuleFor(x => x.Surname)
                .NotNull().WithMessage("Bu alan gereklidir")
                .NotEmpty().WithMessage("Bu alan gereklidir")
                .WithName("Soyadı");
            RuleFor(x => x.Email)
                .NotNull().WithMessage("Bu alan gereklidir")
                .NotEmpty().WithMessage("Bu alan gereklidir")
                .EmailAddress().WithMessage("Geçerli bir email adresi giriniz")
                .Must(x => _userManager.FindByEmailAsync(x).Result == null)
                .WithMessage("Bu e-posta adresi kullanılmıştır")
                .WithName("E-posta adresi");
            RuleFor(x => x.Password).Matches("");
            RuleFor(x => x.PasswordConfirm).Must((dto, passwordConfirm) => dto.Password == passwordConfirm);
        }
    }

    public record AppUserUpdateRequestDto()
    {
        public int Id { get; set; }
        [DisplayName("Adı *")]
        public string Name { get; set; } = null!;
        [DisplayName("Soyadı *")]
        public string Surname { get; set; } = null!;
        [DisplayName("Email *")]
        public string Email { get; set; } = null!;
        [DisplayName("Durum *")]
        public DbEntityState State { get; set; }
        [DisplayName("Profil Resmi")]
        public IFormFile? DefaultPosterImage { get; set; }
    }

    public class AppUserUpdateRequestValidator : AbstractValidator<AppUserUpdateRequestDto>
    {
        private readonly UserManager<AppUser> _userManager;

        public AppUserUpdateRequestValidator(UserManager<AppUser> userManager)
        {
            _userManager = userManager;

            RuleFor(x => x.Name)
                .NotNull().WithMessage("Bu alan gereklidir")
                .NotEmpty().WithMessage("Bu alan gereklidir")
                .WithName("Adı");
            RuleFor(x => x.Surname)
                .NotNull().WithMessage("Bu alan gereklidir")
                .NotEmpty().WithMessage("Bu alan gereklidir")
                .WithName("Soyadı");
            RuleFor(x => x.Email)
                .NotNull().WithMessage("Bu alan gereklidir")
                .NotEmpty().WithMessage("Bu alan gereklidir")
                .EmailAddress().WithMessage("Geçerli bir email adresi giriniz")
                .Must((x, email) =>
                {
                    var appuser = _userManager.FindByEmailAsync(email).Result;
                    return appuser == null || appuser.Id == x.Id;
                })
                .WithMessage("Bu e-posta adresi kullanılmıştır")
                .WithName("E-posta adresi");
            RuleFor(x => x.State)
                .NotEmpty().WithMessage("Bu alan gereklidir")
                .WithName("Durum");
        }

    }

    public record AppUserSignInRequestDto(string Email, string Password, bool? IsPersistent);

    public class AppUserSignInRequestValidator : AbstractValidator<AppUserSignInRequestDto>
    {
        public AppUserSignInRequestValidator()
        {
            RuleFor(x => x.Email)
                .NotEmpty()
                .NotNull()
                .EmailAddress();
            RuleFor(x => x.Password)
                .NotEmpty()
                .NotNull();
        }
    }

    public record AppUserSignInRefreshRequestDto(string RefreshToken);

    public class AppUserSignInRefreshRequestValidator : AbstractValidator<AppUserSignInRefreshRequestDto>
    {
        public AppUserSignInRefreshRequestValidator()
        {
            RuleFor(x => x.RefreshToken)
                .NotEmpty()
                .NotNull();
        }
    }

    public record AppUserSendEmailPasswordResetCodeRequestDto(string Email);

    public class AppUserSendPasswordResetKeyValidator : AbstractValidator<AppUserSendEmailPasswordResetCodeRequestDto>
    {
        public AppUserSendPasswordResetKeyValidator()
        {
            RuleFor(x => x.Email)
                .NotEmpty()
                .NotNull()
                .EmailAddress();
        }
    }

    public record AppUserGetPasswordResetTokenRequestDto(string Email, string Code);

    public class AppUserGetPasswordResetTokenRequestValidator : AbstractValidator<AppUserGetPasswordResetTokenRequestDto>
    {
        public AppUserGetPasswordResetTokenRequestValidator()
        {
            RuleFor(x => x.Email)
                .NotEmpty()
                .NotNull()
                .EmailAddress();
            RuleFor(x => x.Code)
                .NotEmpty()
                .NotNull();
        }
    }

    public record AppUserPasswordResetRequestDto(string Token, string Password, string PasswordCheck);

    public class AppUserPasswordResetRequestValidator : AbstractValidator<AppUserPasswordResetRequestDto>
    {
        public AppUserPasswordResetRequestValidator()
        {
            RuleFor(x => x.Token)
                .NotEmpty()
                .NotNull();
            RuleFor(x => x.Password)
                .NotEmpty()
                .NotNull()
                .Matches(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*\W).{8,16}$");
            RuleFor(x => x.PasswordCheck)
                .NotEmpty()
                .NotNull()
                .Equal(x => x.Password);
        }
    }

    public record AppUserPasswordChangeRequestDto(string Email, string CurrentPassword, string NewPassword);

    public class AppUserChangePasswordRequestValidator : AbstractValidator<AppUserPasswordChangeRequestDto>
    {
        public AppUserChangePasswordRequestValidator()
        {
            RuleFor(x => x.Email)
                .NotEmpty()
                .NotNull()
                .EmailAddress();
            RuleFor(x => x.NewPassword)
                .NotEmpty()
                .NotNull()
                .Matches(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*\W).{8,16}$");
            RuleFor(x => x.CurrentPassword)
                .NotEmpty()
                .NotNull();
        }
    }
}