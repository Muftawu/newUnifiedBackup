using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Shared.Domain.Models;
using Shared.Application;

using DTOs;

namespace Shared.Infrastructure;

public class AuthService : IAuthService
{
    private readonly UserManager<User> _userManager;
    private readonly IJwtService _jwtService;
    private readonly IEmailService _emailService;
    private readonly ApplicationDbContext _dbcontext;
    private readonly IHttpContextAccessor _httpContextAccessor;


    public AuthService(UserManager<User> userManager, IJwtService jwtService, ApplicationDbContext dbcontext, IEmailService emailService, IHttpContextAccessor httpContextAccessor)
    {
        _userManager = userManager;
        _jwtService = jwtService;
        _emailService = emailService;
        _dbcontext = dbcontext;
        _httpContextAccessor = httpContextAccessor;
    }

    public async Task<ResponseDTO> Register(RegisterDTO registerDTO)
    {
        var existingUser = await _userManager.FindByEmailAsync(registerDTO?.Email!);
        if (existingUser != null)
        {
            return new ResponseDTO
            {
                Status = false,
                Message = "User already exists"
            };
        }

        var usernameDomain = registerDTO.Email.Split("@")[0].ToUpper();
        var emailDomain = registerDTO.Email.Split("@")[1].ToLower();
        bool isEmailConfirmed = false;
        bool isProfileVerifed = false;

        if (emailDomain == "knust.edu.gh" || emailDomain == "dev.knust.edu.gh") 
        {
            isEmailConfirmed = true;
            isProfileVerifed = true;
        }

        if (emailDomain == "gmail.com") 
        {
            isEmailConfirmed = true;
            isProfileVerifed = false;
        }


        var user = new User
        {
            UserName = registerDTO.Email,
            Email = registerDTO.Email,
            UserType = registerDTO.UserType.HasValue ? registerDTO.UserType.Value : null,
            EmailConfirmed = isEmailConfirmed,
            IsProfileVerified = isProfileVerifed
        };

        var result = await _userManager.CreateAsync(
            user,
            registerDTO.Password!
        );

        if (result.Succeeded)
        {
            if (registerDTO.UserType == UserRoles.DepartmentAdmin) await _userManager.AddToRoleAsync(user, "DepartmentAdmin");
            if (registerDTO.UserType == UserRoles.Applicant) await _userManager.AddToRoleAsync(user, "Applicant");
            if (registerDTO.UserType == UserRoles.Developer) await _userManager.AddToRoleAsync(user, "Developer");
            
            // var token = await _userManager.GenerateEmailConfirmationTokenAsync(user);
            // var confirmationLink = $"http://localhost:5161/confirm-email?userId={user.Id}&token={Uri.EscapeDataString(token)}";

            // var userId = user.Id;
            // var encodedToken = Uri.EscapeDataString(token);
            // var confirmationLink = $"http://localhost:5245/email-confirm/{userId}/{encodedToken}";
            // Console.WriteLine($"user token => {encodedToken}");

            // string emailTemplate = await File.ReadAllTextAsync("./EmailTemplates/EmailConfirmation.html", Encoding.UTF8);
            // string emailBody = emailTemplate.Replace("{CONFIRMATION_LINK}", confirmationLink);

            // string sendCredentialMailTemplate = await File.ReadAllTextAsync("./EmailTemplates/SendLoginCredentials.html", Encoding.UTF8);
            // string sendCredentialBody = sendCredentialMailTemplate
            //     .Replace("{USERNAME}", usernameDomain)
            //     .Replace("{CREDENTIALS}", usernameDomain);

            // try
            // {   if (emailDomain == "knust.edu.gh")
            //     {
            //         await _emailService.SendEmailAsync(user.Email, "Credentials for Department Admin - KNUST Unified Self Service", sendCredentialBody, true);
            //     }
            //     else
            //     {
            //         await _emailService.SendEmailAsync(user.Email, "Confirm Your Email - KNUST Unified Self Service", emailBody, true);
            //     }
            // } catch (Exception e)
            // {
            //     Console.WriteLine($"Failed to send mail: {e.Message}");
            // }

            return new ResponseDTO
            {
                Status = true,
                // Message = "User creation success. Please check your email to confirm your account.",
                Message = "User creation success. Please login.",
            };
        }
       
        return new ResponseDTO
        {
            Status = false,
            Message = string.Join(", ", result.Errors.Select(e => e.Description))
        };

    }


public async Task<LoginResponseDTOJWT> Login(LoginDTO loginDTO)
    {
        var user = await _userManager.FindByEmailAsync(loginDTO.Email!);

        if (user == null)
        {
            return new LoginResponseDTOJWT 
            {
                Status = false,
                Message = "User not found."
            };
        }

        if (!user.EmailConfirmed)
        {
            return new LoginResponseDTOJWT 
            {
                Status = false,
                Message = "Email not confirmed. Please check your email."
            };
        }

        var isPasswordValid = await _userManager.CheckPasswordAsync(user, loginDTO.Password ?? string.Empty);

        if (!isPasswordValid)
        {
            return new LoginResponseDTOJWT 
            {
                Status = false,
                Message = "Invalid credentials"
            };
        }

        return new LoginResponseDTOJWT
        {
            Status = true,
            Message = "Login Successful",
            Token = _jwtService.GenerateToken(user),
            UserType = user.UserType.HasValue ? user.UserType.Value : null,
        };
    }

    public async Task<ResponseDTO> GetUserById(Guid userId)
    {
        if (string.IsNullOrWhiteSpace(userId.ToString()))
        {
            return new ResponseDTO
            {
                Status = false,
                Message = "User Id cannot be null"
            };
        }

        var user = await _userManager.FindByIdAsync(userId.ToString());

        if (user != null)
        {
            return new ResponseDTO
            {
                Status = true,
                Message = "User Found",
                DataObject = new List<User> { user }
            };
        }

        return new ResponseDTO
        {
            Status = false,
            Message = "User not found",
        };
    }

    public async Task<ResponseDTO> UpdateUser(Guid userId, UserDTO userDTO)
    {
        var user = await _userManager.FindByIdAsync(userId.ToString());
        if (user == null)
        {
            return new ResponseDTO
            {
                Status = false,
                Message = "User not found"
            };
        }   

        if (!string.IsNullOrWhiteSpace(userDTO.ReferenceNumber)) user.ReferenceNumber = userDTO.ReferenceNumber;
        if (!string.IsNullOrWhiteSpace(userDTO.IndexNumber)) user.IndexNumber = userDTO.IndexNumber;
        if (!string.IsNullOrWhiteSpace(userDTO.Surname)) user.Surname = userDTO.Surname;
        if (!string.IsNullOrWhiteSpace(userDTO.OtherNames)) user.OtherNames = userDTO.OtherNames;
        if (!string.IsNullOrWhiteSpace(userDTO.Gender)) user.Gender = userDTO.Gender;
        if (userDTO.DateOfBirth.HasValue && DateTime.TryParse(userDTO.DateOfBirth.Value.ToString(), out DateTime dob))
        {
            user.DateOfBirth = dob.Date;
        };
        if (!string.IsNullOrWhiteSpace(userDTO.CountryCode)) user.CountryCode = userDTO.CountryCode;
        if (!string.IsNullOrWhiteSpace(userDTO.PhoneNumber)) user.PhoneNumber = userDTO.PhoneNumber;
        if (!string.IsNullOrWhiteSpace(userDTO.CountryOfResidence)) user.CountryOfResidence = userDTO.CountryOfResidence;
        if (!string.IsNullOrWhiteSpace(userDTO.Gender)) user.Gender = userDTO.Gender;
        
        if (!string.IsNullOrWhiteSpace(userDTO.Email)) 
        {
            var existingUser = await _userManager.FindByEmailAsync(userDTO.Email);
            if (existingUser != null && existingUser.Id != user.Id)
            {
                return new ResponseDTO
                {
                    Status = false,
                    Message = "Email already in use"
                };
            }
            user.Email = userDTO.Email;
        }

        // if (!string.IsNullOrWhiteSpace(userDTO.UserRole))
        // {
        //     var roles = await _userManager.GetRolesAsync(user);
        //     await _userManager.RemoveFromRolesAsync(user, roles);
        //     await _userManager.AddToRoleAsync(user, userDTO.UserRole);
        // }

        try
        {
            var result = await _userManager.UpdateAsync(user);
            if (result.Succeeded)
            {
                return new ResponseDTO
                {
                    Status = true,
                    Message = "User updated successfully"
                };
            }
            else
            {
                return new ResponseDTO
                {
                    Status = false,
                    Message = $"Error updating user: {string.Join(", ", result.Errors.Select(e => e.Description))}"
                };
            }
        }
    catch (Exception e)
    {
        return new ResponseDTO
        {
            Status = false,
            Message = $"Exception updating user: {e.Message}"
        };
    }
    }

    public async Task UpdateUserProfileStatus(Guid userId, UserDTO userDTO)
    {
        var user = await _userManager.FindByIdAsync(userId.ToString());
        try
        {
            user.IsProfileVerified = true;
            await UpdateUser(userId, userDTO);
        }
        catch (Exception e)
        {
            Console.WriteLine($"failed to verify user profile status: {e}");
        }
    }

    public async Task<ResponseDTO> CreateUserProfile(CreateUserProfileDTO createUserProfileDTO)
    {

        if (string.IsNullOrWhiteSpace(createUserProfileDTO.userId.ToString()))
        {
            return new ResponseDTO
            {
                Status = false,
                Message = "User Id cannot be null"
            };
        }

        var userObj = await GetUserById(Guid.Parse(createUserProfileDTO.userId));
        if (!userObj.Status)
        {
            return new ResponseDTO
            {
                Status = false,
                Message = "User not found"
            };
        }

        var user = await _userManager.FindByIdAsync(createUserProfileDTO.userId);
        
        var userIdentificationObj = new IdentificationCard
        {
            UserId = Guid.Parse(createUserProfileDTO.userId),
            IdentificationCardType = createUserProfileDTO.identificationCardDTO.IdentificationCardType,
            IdentificationCardNumber = createUserProfileDTO.identificationCardDTO.IdentificationCardNumber,
            IdentificationCardFile = createUserProfileDTO.identificationCardDTO.IdentificationCardFile
        };

        var userProgrammeRead = new ProgrammeRead
        {
            UserId = Guid.Parse(createUserProfileDTO.userId),
            FullNameOnCertificate = createUserProfileDTO.programmesReadDTO.FullNameOnCertificate,
            StudentNumber = createUserProfileDTO.programmesReadDTO.StudentNumber,
            IndexNumber = createUserProfileDTO.programmesReadDTO.IndexNumber,
            ProgrammeId = createUserProfileDTO.programmesReadDTO.ProgrammeId,
            AdmissionYear = createUserProfileDTO.programmesReadDTO.AdmissionYear,
            GraduationYear = createUserProfileDTO.programmesReadDTO.GraduationYear,
            ThesisTopic = createUserProfileDTO.programmesReadDTO.ThesisTopic,
            GraduateType = createUserProfileDTO.programmesReadDTO.GraduateType
        };
        
        try
        {
            await UpdateUser(Guid.Parse(createUserProfileDTO.userId), createUserProfileDTO.userDTO);
            await _dbcontext.IdentificationCards.AddAsync(userIdentificationObj);
            await _dbcontext.ProgrammeReads.AddAsync(userProgrammeRead);
            var saveResult = await _dbcontext.SaveChangesAsync();

            if (saveResult > 0)
            {
                await UpdateUserProfileStatus(Guid.Parse(createUserProfileDTO.userId), createUserProfileDTO.userDTO);
                return new ResponseDTO
                {
                    Status = true,
                    Message = "User Profile created successfully",
                };
            }

            return new ResponseDTO
            {
                Status = false,
                Message = "Failed to create user profile",
            };
        }

        catch(Exception e)
        {
            return new ResponseDTO
            {
                Status = false,
                Message = $"An error occured while creating user profile{e.Message}",
            };
        }
        
    }
}

