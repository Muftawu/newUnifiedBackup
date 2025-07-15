using Shared.Domain.Models;
using DTOs;
using GenericResponse;
using Frontend.Endpoints;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Frontend.Services;

public class ApiService
{
    private readonly HttpClient _httpClient;

    public ApiService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<List<RequestType>> GetAllRequestTypes()
    {
        try
        {
            var response = await _httpClient.GetFromJsonAsync<GenericResponseDTO<RequestType>>(ApplicationEndpoints.AllRequests);
            if (response?.Data != null)
            {
                return response.Data;
            }
            return new List<RequestType>();
        }
        catch (Exception ex)
        {
            Console.WriteLine($"An error occurred: {ex.Message}");
            return new List<RequestType>();
        }
    }

    public async Task<(bool Status, List<ProgrammeRead> programmes)> GetUserProgrammes(string userId) 
    {
    try
        {
            var response = await _httpClient.GetFromJsonAsync<GenericResponseDTO<ProgrammeRead>>($"{ApplicationEndpoints.GetUserProgrammes}/{userId}");
            if (response?.Data != null)
            {
                return (true, response.Data);
            }
            return (false, new List<ProgrammeRead>());
        }
        catch (Exception ex)
        {
            Console.WriteLine($"An error occurred from getting user programmes: {ex.Message}");
            return (false, new List<ProgrammeRead>());
        }

    }

    
    public async Task<(bool Status, List<Department> departments)> GetUserDepartments(string userId) 
    {
    try
        {
            var response = await _httpClient.GetFromJsonAsync<GenericResponseDTO<Department>>(ApplicationEndpoints.GetUserDepartments);
            if (response?.Data != null)
            {
                return (true, response.Data);
            }
            return (false, new List<Department>());
        }
        catch (Exception ex)
        {
            Console.WriteLine($"An error occurred from getting user departmetns: {ex.Message}");
            return (false, new List<Department>());
        }

    }

    public async Task<RequestType> GetRequestTypeById(string requestTypeId)
    {
        try
        {
            var url = $"{ApplicationEndpoints.GetRequestTypeById}/{requestTypeId}";
            var requestTypeResponse = await _httpClient.GetFromJsonAsync<GenericResponseDTO<RequestType>>(url);
            var requestType = requestTypeResponse?.Data?.First();
            if (requestType != null)
            {
                return requestType;
            }
            return new RequestType()!;
        }
        catch (Exception ex)
        {
            Console.WriteLine($"An error occurred: {ex.Message}");
            return new RequestType();
        }
    }

    public async Task<Request> GetApplicantRequestById(string requestId)
    {
        try
        {
            var url = $"{ApplicationEndpoints.GetApplicantRequestById}/{requestId}";
            var requestResponse = await _httpClient.GetFromJsonAsync<GenericResponseDTO<Request>>(url);
            var request = requestResponse?.Data?.First();
            if (request != null)
            {
                return request;
            }
            return new Request()!;
        }
        catch (Exception ex)
        {
            Console.WriteLine($"An error occurred: {ex.Message}");
            return new Request();
        }
    }


    public async Task<(bool Status, List<DepartmentRequestType> departmentRequestTypes)> GetAllDepartmentRequestTypesByDepartmentId (int? departmentId)
    {
        try
        {
            var response = await _httpClient.GetFromJsonAsync<GenericResponseDTO<DepartmentRequestType>>($"{ApplicationEndpoints.AllDepartmentRequestTypeById}/{departmentId}");
            if (response != null)
            {        
                return (true, response.Data);
            }
            return (false, new List<DepartmentRequestType>());
        }
        catch (Exception ex)
        {
            Console.WriteLine($"An error occured {ex.Message}");
            return (false, new List<DepartmentRequestType>());
        }
    }

    public async Task<List<DepartmentRequestType>> GetAllDepartmentRequestTypes()
    {
        try
        {
            var response = await _httpClient.GetFromJsonAsync<GenericResponseDTO<DepartmentRequestType>>($"{ApplicationEndpoints.AllDepartmentRequestTypes}");
            if (response != null)
            {
                return response?.Data!;
            }
            return new List<DepartmentRequestType>();
        }
        catch (Exception ex)
        {
            Console.WriteLine($"An error occured {ex.Message}");
            return new List<DepartmentRequestType>();
        }
    }

    public async Task<List<RequestTransaction>> GetAllRequestTransactions()
    {
        try
        {
            var url = $"{ApplicationEndpoints.AllRequestTransactions}";
            var response = await _httpClient.GetFromJsonAsync<GenericResponseDTO<RequestTransaction>>(url);
            if (response != null)
            {
                return response?.Data!;
            }
            return new List<RequestTransaction>();
        }
        catch (Exception ex)
        {
            Console.WriteLine($"An error occured {ex.Message}");
            return new List<RequestTransaction>();
        }
    }

    public async Task<DepartmentRequestType> GetDepartmentRequestTypeByName(string departmentRequestTypeName)
    {
        try
        {
            var url = $"{ApplicationEndpoints.GetDepartmentRequestTypeByName}/{departmentRequestTypeName}";
            var response = await _httpClient.GetFromJsonAsync<GenericResponseDTO<DepartmentRequestType>>(url);
            var departmentRequestType = response?.Data!.First();
            if (departmentRequestType != null)
            {
                return departmentRequestType!;
            }
            return new DepartmentRequestType();
        }
        catch (Exception ex)
        {
            Console.WriteLine($"An error occured {ex.Message}");
            return new DepartmentRequestType();
        }
    }

    public async Task<DepartmentRequestType> GetDepartmentRequestTypeById(string departmentRequestTypeId)
    {
        try
        {
            var url = $"{ApplicationEndpoints.GetDepartmentRequestTypeById}/{departmentRequestTypeId}";
            var response = await _httpClient.GetFromJsonAsync<GenericResponseDTO<DepartmentRequestType>>(url);
            var departmentRequestType = response?.Data!.First();
            if (departmentRequestType != null)
            {
                return departmentRequestType!;
            }
            return new DepartmentRequestType();
        }
        catch (Exception ex)
        {
            Console.WriteLine($"An error occured [GetDepartmentRequestTypeById] {ex.Message}");
            return new DepartmentRequestType();
        }
    }

    public async Task<(bool Status,DepartmentRequestPaymentChannel departmentRequestPaymentChannel)> GetDepartmentRequestTypePaymentChannel(string departmentRequestTypeId)
    {
        try
        {
            var url = $"{ApplicationEndpoints.GetDepartmentRequestPaymentChannelById}/{departmentRequestTypeId}";
            var response = await _httpClient.GetFromJsonAsync<GenericResponseDTO<DepartmentRequestPaymentChannel>>(url);
            var departmentRequestPaymentChannel = response?.Data!.First();
            if (departmentRequestPaymentChannel != null)
            {
                return (true, departmentRequestPaymentChannel!);
            }
            return (false, new DepartmentRequestPaymentChannel());
        }
        catch (Exception ex)
        {
            Console.WriteLine($"An error occured [GetDepartmentRequestPaymentChannel] {ex.Message}");
            return (false, new DepartmentRequestPaymentChannel());
        }
    }

    public async Task<DepartmentRequestType> GetSingleDepartmentRequestTypeById(string departmentRequestTypeId)
    {
        try
        {
            var url = $"{ApplicationEndpoints.GetSingleDepartmentRequestTypeById}/{departmentRequestTypeId}";
            var response = await _httpClient.GetFromJsonAsync<GenericResponseDTO<DepartmentRequestType>>(url);
            var departmentRequestType = response?.Data!.First();
            if (departmentRequestType.RequestType != null)
            {
                return departmentRequestType!;
            }
            return new DepartmentRequestType();
        }
        catch (Exception ex)
        {
            Console.WriteLine($"An error occured {ex.Message}");
            return new DepartmentRequestType();
        }
    }

    public async Task<User> GetUserById(string userId)
    {
        try
        {
            var response = await _httpClient.GetFromJsonAsync<GenericResponseDTO<User>>($"{ApplicationEndpoints.GetUserById}/{userId}");
            var user = response?.Data!.First();
            if (user != null)
            {
                return user!;
            }
            return new User();
        }
        catch (Exception ex)
        {
            Console.WriteLine($"An error occured {ex.Message}");
            return new User();
        }
    }

    public async Task<(bool Status, string Message)> UpdateUserProfile(string userId, UserDTO userDTO)
    {
        try
        {
            var userContent = new StringContent(JsonSerializer.Serialize(userDTO), Encoding.UTF8, "application/json");
            var response = await _httpClient.PostAsync($"{ApplicationEndpoints.UpdateUserProfile}/{userId}", userContent);

            if (response.IsSuccessStatusCode)
            {
                var responseBody = await response.Content.ReadFromJsonAsync<GenericResponseDTOPost>();
                return (true, responseBody.Message);
            }
            else
            {
                var errorContentString = await response.Content.ReadAsStringAsync();
                var errorContent = await response.Content.ReadFromJsonAsync<ResponseDTO>();
                return (false, $"{errorContent.Message}");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"An error occured {ex.Message}");
            return (false, $"{ex.Message}");
        }
    }

    public async Task<List<Request>> GetAllApplicantRequests(string userId, string departmentRequestTypeId)
    {
        try
        {
            var url = $"{ApplicationEndpoints.GetAllApplicantRequestPerLetter}/{userId}/{departmentRequestTypeId}";
            var response = await _httpClient.GetFromJsonAsync<GenericResponseDTO<Request>>(url);
            if (response != null)
            {
                return response?.Data!;
            }
            return new List<Request>();
        }
        catch (Exception ex)
        {
            Console.WriteLine($"An error occured (requests) {ex.Message}");
            return new List<Request>();
        }
    }

    public async Task<RequestTransaction> GetApplicantRequestTransaction(string userId, string requestId)
    {
        try
        {
            var url = $"{ApplicationEndpoints.GetAllApplicantRequestTransactions}/{userId}/{requestId}";
            var response = await _httpClient.GetFromJsonAsync<GenericResponseDTO<RequestTransaction>>(url);
            var requestTransaction = response?.Data!.First();
            if (requestTransaction != null)
            {
                return requestTransaction;
            }
            return new RequestTransaction();
        }
        catch (Exception ex)
        {
            Console.WriteLine($"An error occured (transaction) {ex.Message}");
            return new RequestTransaction();
        }
    }

    public async Task<List<Request>> GetAllDepartmentRequests(string departmentRequestTypeId)
    {
        try
        {
            var url = $"{ApplicationEndpoints.AllDepartmentRequestTransactions}/{departmentRequestTypeId}/?pageNumber=1&pageSize=10";
            var response = await _httpClient.GetFromJsonAsync<GenericResponseDTO<Request>>(url);
            var requests = response?.Data!;
            if (requests != null)
            {
                return requests;
            }
            return new List<Request>();
        }
        catch (Exception ex)
        {
            Console.WriteLine($"An error occured (transaction) {ex.Message}");
            return new List<Request>();
        }
    }

    public async Task<(bool Status, string AlertType, string Message)> Register(RegisterDTO registerDTO)
    {
        var responseString = string.Empty;
        try
        {
            var jsonOptions = new JsonSerializerOptions
            {
                Converters = { new JsonStringEnumConverter() }
            };

            var registerDataContent = new StringContent(JsonSerializer.Serialize(registerDTO, jsonOptions), Encoding.UTF8, "application/json");
            var response = await _httpClient.PostAsync(ApplicationEndpoints.Register, registerDataContent);
            responseString = await response.Content.ReadAsStringAsync();

            if (response.IsSuccessStatusCode)
            {
                var responseBody = await response.Content.ReadFromJsonAsync<GenericResponseDTOPost>();
                return (true, "success", responseBody.Message);
            }
            else
            {
                var errorContent = await response.Content.ReadAsStringAsync();
                Console.WriteLine($"respnose {errorContent}");
                var errorResponse = JsonSerializer.Deserialize<AuthResponseDTO>(errorContent, new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                });

                if (errorResponse?.Errors != null)
                {
                    if (errorResponse.Errors.ContainsKey("ConfirmPassword"))
                    {
                        return (false, "warning", string.Join(", ", errorResponse.Errors["ConfirmPassword"]));
                    }
                    else if (errorResponse.Errors.ContainsKey("SubscribedDepartmentId"))
                    {
                        return (false, "warning", string.Join(", ", JsonSerializer.Serialize(errorResponse.Errors["SubscribedDepartmentId"][0])));
                    }
                }
                Console.WriteLine($"Error in response: {JsonSerializer.Serialize(errorResponse?.Errors)}");
                return (false, "warning", $"{JsonSerializer.Serialize(errorResponse?.Errors)}");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"An error occured {ex.Message}");
            return (false, "danger", $"{responseString}");
        }
    }

    public async Task<(bool Status, string AlertType, string Message, string Token, UserRoles? UserType)> Login(LoginDTO loginDTO)
    {
        try
        {
            var loginDataContent = new StringContent(JsonSerializer.Serialize(loginDTO), Encoding.UTF8, "application/json");
            var response = await _httpClient.PostAsync(ApplicationEndpoints.Login, loginDataContent);

            if (response.IsSuccessStatusCode)
            {
                var responseBody = await response.Content.ReadFromJsonAsync<LoginResponseDTOJWT>();
                return (true, "success", responseBody.Message, responseBody.Token, responseBody.UserType);
            }
            else
            {
                var errorContentString = await response.Content.ReadAsStringAsync();
                var errorContent = await response.Content.ReadFromJsonAsync<LoginResponseDTOJWT>();
                return (false, "danger", $"{errorContent?.Message}", string.Empty, null);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"An error occured {ex.Message}");
            return (false, "danger", string.Empty, $"{ex.Message}", null);
        }
    }

    public async Task<bool> VerifyApplicantRequest(string requestTransactionId)
    {
        try
        {
            var requestTransactionData = new StringContent(JsonSerializer.Serialize(requestTransactionId), Encoding.UTF8, "application/json");
            var response = await _httpClient.PostAsync($"{ApplicationEndpoints.VerifyApplicantRequest}/{requestTransactionId}", null);
            Console.WriteLine($"response from api => {response}");

            if (response.IsSuccessStatusCode)
            {
                var responseBody = await response.Content.ReadFromJsonAsync<GenericResponseDTOPost>();
                Console.WriteLine($"response => {responseBody}");
                return true;
            }
            else
            {
                var errorContentString = await response.Content.ReadAsStringAsync();
                var errorContent = await response.Content.ReadFromJsonAsync<GenericResponseDTOPost>();
                Console.WriteLine($"{response}");
                return false;
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"An error occured from verify {ex.Message}");
            return false;
        }
    }

    public async Task<(bool Status, string Message)> CreateNewApplicantRequest(string userId, string departmentRequestTypeId, RequestTransactionDTO requestTransactionDTO)
    {
        var requestTransactionModelData = JsonSerializer.Serialize(requestTransactionDTO);
        var requestTransactionModelContent = new StringContent(requestTransactionModelData, Encoding.UTF8, "application/json");
        var response = await _httpClient.PostAsync($"{ApplicationEndpoints.CreateNewRequest}/{userId}/{departmentRequestTypeId}", requestTransactionModelContent);

        try
        {
            if (response.IsSuccessStatusCode)
            {
                var responseBody = await response.Content.ReadFromJsonAsync<GenericResponseDTOPost>();
                return (true, responseBody.Message);
            }
            else
            {
                var errorContentString = await response.Content.ReadAsStringAsync();
                var errorContent = await response.Content.ReadFromJsonAsync<LoginResponseDTOJWT>();
                Console.WriteLine($"{response}");
                return (false, errorContentString);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"An error occured from verify {ex.Message}");
            return (false, $"{ex.Message}");
        }
    }

    public async Task<(bool Status, string Message)> AddNewDepartmentSubscription(DepartmentDTO DepartmentDTO, bool generateCredential, string adminEmail)
    {
        var subscribedDepartmentData = JsonSerializer.Serialize(new { DepartmentDTO, generateCredential, adminEmail });
        var subscribedDepartmentContent = new StringContent(subscribedDepartmentData, Encoding.UTF8, "application/json");
        var response = await _httpClient.PostAsync(ApplicationEndpoints.AddNewDepartmentSubscription, subscribedDepartmentContent);

        try
        {
            if (response.IsSuccessStatusCode)
            {
                var responseBody = await response.Content.ReadFromJsonAsync<GenericResponseDTOPost>();
                return (responseBody.Status, responseBody.Message);
            }
            else
            {
                var errorContentString = await response.Content.ReadAsStringAsync();
                var errorContent = await response.Content.ReadFromJsonAsync<GenericResponseDTOPost>();
                Console.WriteLine($"error from adding new department: {errorContentString}");
                return (false, errorContentString);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"An error occured from addding new department: {ex.Message}");
            return (false, $"{ex.Message}");
        }
    }

    public async Task<(bool Status, RequestType requestType)> AddNewRequestType(RequestTypeDTO requestTypeDTO)
    {
        var requestTypeData = JsonSerializer.Serialize(requestTypeDTO);
        var requestTypeContent = new StringContent(requestTypeData, Encoding.UTF8, "application/json");
        var response = await _httpClient.PostAsync(ApplicationEndpoints.CreateNewRequestType, requestTypeContent);
        try
        {
            if (response.IsSuccessStatusCode)
            {
                var responseBody = await response.Content.ReadFromJsonAsync<GenericResponseDTO<RequestType>>();
                return (true, responseBody.Data.First());
            }
            else
            {
                var errorContentString = await response.Content.ReadAsStringAsync();
                var errorContent = await response.Content.ReadFromJsonAsync<GenericResponseDTOPost>();
                Console.WriteLine($"if request type creation does not succeed{response}");
                return (false, new RequestType());
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"An error occured from verify {ex.Message}");
            return (false, new RequestType());
        }
    }

    public async Task<(bool Status, string Message)> CreateNewDepartmentRequestType(DepartmentSubscriptionDTO departmentSubscriptionDTO)
    {
        var departmentRequestTypeData = JsonSerializer.Serialize(departmentSubscriptionDTO);
        var departmentRequestTypeContent = new StringContent(departmentRequestTypeData, Encoding.UTF8, "application/json");
        var response = await _httpClient.PostAsync(ApplicationEndpoints.CreateNewDepartmentRequestType, departmentRequestTypeContent);
        Console.WriteLine($"response form creating new departmetnt request type: {response}");

        try
        {
            if (response.IsSuccessStatusCode)
            {
                var responseBody = await response.Content.ReadFromJsonAsync<GenericResponseDTOPost>();
                return (true, responseBody.Message);
            }
            else
            {
                var errorContentString = await response.Content.ReadAsStringAsync();
                var errorContent = await response.Content.ReadFromJsonAsync<GenericResponseDTOPost>();
                Console.WriteLine($"error from adding new department: {errorContentString}");
                return (false, errorContentString);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"An error occured from addding new department: {ex.Message}");
            return (false, $"{ex.Message}");
        }
    }

    public async Task<(bool Status, ErrorResponse err)> CreateUserProfile(CreateUserProfileDTO createUserProfileDTO)
    {
        ErrorResponse err = new();
        var userProfileData = JsonSerializer.Serialize(createUserProfileDTO);
        Console.WriteLine($"create user profile: {userProfileData}");
        var userProfileContent = new StringContent(userProfileData, Encoding.UTF8, "application/json");
        var response = await _httpClient.PostAsync(ApplicationEndpoints.CreateUserProfile, userProfileContent);
        Console.WriteLine($"response from creating user profile: {response}");

        try
        {
            if (response.IsSuccessStatusCode)
            {
                var responseBody = await response.Content.ReadFromJsonAsync<GenericResponseDTOPost>();
                return (true, err);
            }
            else
            {
                var errorContent = await response.Content.ReadFromJsonAsync<ErrorResponse>();
                Console.WriteLine($"error from creating user profile in apiservice: {errorContent}");
                return (false, err);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"An error occured creating user profile: {ex.Message}");
            return (false, err);
        }
    }

    public async Task<(bool Status, string Message)> ConfirmEmailAsync(string userId, string token)
    {
        var response = await _httpClient.PostAsync($"{ApplicationEndpoints.ConfirmEmail}/{userId}/{token}", null);
        Console.WriteLine($"response {response}");

        try
        {
            if (response.IsSuccessStatusCode)
            {
                var responseBody = await response.Content.ReadFromJsonAsync<GenericResponseDTOPost>();
                Console.WriteLine($"responseBody {responseBody}");
                return (true, responseBody.Message);
            }
            else
            {
                var errorContentString = await response.Content.ReadAsStringAsync();
                var errorContent = await response.Content.ReadFromJsonAsync<LoginResponseDTOJWT>();
                Console.WriteLine($"error confirming email {response}");
                return (false, errorContentString);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"An error occured from verify {ex.Message}");
            return (false, $"{ex.Message}");
        }
    }

    public async Task<List<ProgrammeRead>> GetApplicantProgrammesRead(string userId)
    {
        try
        {
            var response = await _httpClient.GetFromJsonAsync<GenericResponseDTO<ProgrammeRead>>($"{ApplicationEndpoints.GetApplicantProgrammesRead}/{userId}");
            var programmes = response?.Data!;
            if (programmes != null)
            {
                return programmes!;
            }
            return new List<ProgrammeRead>();
        }
        catch (Exception ex)
        {
            Console.WriteLine($"An error occured {ex.Message}");
            return new List<ProgrammeRead>();
        }
    }

    public async Task<IdentificationCard> GetApplicantIdentification(string userId)
    {
        try
        {
            var response = await _httpClient.GetFromJsonAsync<GenericResponseDTO<IdentificationCard>>($"{ApplicationEndpoints.GetApplicantIdentification}/{userId}");
            Console.WriteLine($"response from gettign usr id: {response}");
            var idcard = response?.Data!.First();
            if (idcard != null)
            {
                return idcard!;
            }
            return new IdentificationCard();
        }
        catch (Exception ex)
        {
            Console.WriteLine($"An error occured {ex.Message}");
            return new IdentificationCard();
        }
    }

    public async Task<(bool Status, string Message)> DeleteRequestType(string requestTypeId)
    {
        try
        {
            var response = await _httpClient.DeleteAsync($"{ApplicationEndpoints.DeleteRequestType}/{requestTypeId}");
            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                var result = JsonSerializer.Deserialize<GenericResponseDTO<RequestType>>(content, new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                });
                return (true, result.Message);
            }
            return (false, "Failed to delete request type");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"An error occured while deleting request type: {ex.Message}");
            return (false, $"{ex.Message}");
        }
    }

    public async Task<(bool Status, string Message)> AddDepartmentRequestTypeFormField(string departmentRequestTypeId, FormFieldDTO formFieldDTO)
    {
        var formData = JsonSerializer.Serialize(formFieldDTO);
        var formDataContent = new StringContent(formData, Encoding.UTF8, "application/json");
        var response = await _httpClient.PostAsync($"{ApplicationEndpoints.DepartmentRequestTypeFormField}/{departmentRequestTypeId}", formDataContent);
        try
        {
            if (response.IsSuccessStatusCode)
            {
                var responseBody = await response.Content.ReadFromJsonAsync<GenericResponseDTOPost>();
                return (true, responseBody.Message);
            }
            else
            {
                var errorContentString = await response.Content.ReadAsStringAsync();
                 Console.WriteLine($"error from adding new department request type field in apiservice: {errorContentString}");
                return (false, errorContentString);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"An error occured creating user profile: {ex.Message}");
            return (false, $"{ex.Message}");
        }
    }

    public async Task<(bool Status, List<FormFields> formFields)> FetchDepartmentRequestTypeFormFields(string departmentRequestTypeId)
    {
        try
        {
            var response = await _httpClient.GetFromJsonAsync<GenericResponseDTO<FormFields>>($"{ApplicationEndpoints.DepartmentRequestTypeFormField}/{departmentRequestTypeId}");
            var formFields = response?.Data!;
            if (formFields != null)
            {
                return (true, formFields!);
            }
            return (false, new List<FormFields>());
        }
        catch (Exception ex)
        {
            Console.WriteLine($"An error occured [fetching all form fields for a department request type]: {ex.Message}");
            return (false, new List<FormFields>());
        }
    }

    public async Task<(bool Status, string Message)> DeleteDepartmentRequestTypeFormField(string departmentRequestTypeFormFieldId)
    {
        try
        {
            var response = await _httpClient.DeleteAsync($"{ApplicationEndpoints.DepartmentRequestTypeFormField}/{departmentRequestTypeFormFieldId}");
            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                var result = JsonSerializer.Deserialize<GenericResponseDTO<FormFields>>(content, new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                });
                return (true, result.Message);
            }
            return (false, "Failed to delete request type");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"An error occured while deleting request type: {ex.Message}");
            return (false, $"{ex.Message}");
        }
    }
    
    // DYNAMIC FORM FIELDS
    public async Task<(bool Status, List<RequestTypeFormStep> requestTypeFormStep)> AddFormStep(string serviceId, List<RequestTypeFormStepDTO> formStepDTO)
    {
        var formData = JsonSerializer.Serialize(formStepDTO);
        var formDataContent = new StringContent(formData, Encoding.UTF8, "application/json");
        var response = await _httpClient.PostAsync($"{ApplicationEndpoints.NewFormStep}/{serviceId}", formDataContent);
        try
        {
            if (response.IsSuccessStatusCode)
            {
                var responseBody = await response.Content.ReadFromJsonAsync<GenericResponseDTO<RequestTypeFormStep>>();
                return (true, responseBody.Data);
            }
            else
            {
                var errorContentString = await response.Content.ReadAsStringAsync();
                 Console.WriteLine($"error from adding new form step in apiservice: {errorContentString}");
                return (false, new List<RequestTypeFormStep>());
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"An error occured in adding new form step : {ex.Message}");
            return (false, new List<RequestTypeFormStep>());
        }
    }

    public async Task<(bool Status, string Message)> AddGenericServiceFormField(string formStepId, FormFieldWithOptionsDTO request)
    {
        var formData = JsonSerializer.Serialize(request);
        var formDataContent = new StringContent(formData, Encoding.UTF8, "application/json");
        var response = await _httpClient.PostAsync($"{ApplicationEndpoints.GenericServiceFormField}/{formStepId}", formDataContent);
        try
        {
            if (response.IsSuccessStatusCode)
            {
                var responseBody = await response.Content.ReadFromJsonAsync<GenericResponseDTOPost>();
                return (true, responseBody.Message);
            }
            else
            {
                var errorContentString = await response.Content.ReadAsStringAsync();
                 Console.WriteLine($"error from adding new form step in apiservice: {errorContentString}");
                return (false, errorContentString);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"An error occured in adding new form step : {ex.Message}");
            return (false, ex.Message);
        }
    }
    
     public async Task<(bool Status, List<RequestTypeFormStep> requestTypeFormStep)> FetchGenericServiceFormFields(string serviceTypeId)
     {
        try
        {
            var response = await _httpClient.GetFromJsonAsync<GenericResponseDTO<RequestTypeFormStep>>($"{ApplicationEndpoints.FetchGenericFormFields}/{serviceTypeId}");
            Console.WriteLine($"response from generic response {response}");
            var formFields = response?.Data!;
            if (formFields != null)
            {
                return (true, formFields!);
            }
            return (false, new List<RequestTypeFormStep>());
        }
        catch (Exception ex)
        {
            Console.WriteLine($"An error occured [fetching all form fields for a generic form]: {ex.Message}");
            return (false, new List<RequestTypeFormStep>());
        }
    }

    public async Task<(bool Status, List<RequestTypeFormStep> requestTypeFormSteps)> FetchServiceFormSteps(string serviceId)
    {
        try
        {
            var response = await _httpClient.GetFromJsonAsync<GenericResponseDTO<RequestTypeFormStep>>($"{ApplicationEndpoints.FetchServiceFormSteps}/{serviceId}");
            var formFields = response?.Data!;
            if (formFields != null)
            {
                return (true, formFields!);
            }
            return (false, new List<RequestTypeFormStep>());
        }
        catch (Exception ex)
        {
            Console.WriteLine($"An error occured [fetching all form steps for a service: apiservice] {ex.Message}");
            return (false, new List<RequestTypeFormStep>());
        }
    }



}
