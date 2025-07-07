namespace Frontend.Endpoints;

public static class ApplicationEndpoints
{
    // Auth URL
    public static string Login = "http://localhost:5161/login";
    public static string Register = "http://localhost:5161/register";
    public static string GetUserById = "http://localhost:5161/getUserById";
    public static string UpdateUserProfile = "http://localhost:5161/updateUser";
    public static string CreateUserProfile = "http://localhost:5161/createUserProfile";

    // Email 
    public static string ConfirmEmail = "http://localhost:5161/confirm-email";

    // applicant 
    public static string GetAllApplicantRequestPerLetter = "http://localhost:5161/applicant/allRequests";
    public static string GetAllApplicantRequestTransactions = "http://localhost:5161/applicant/allTransactions";
    public static string GetApplicantRequestById = "http://localhost:5161/applicant/request";
    public static string GetApplicantProgrammesRead = "http://localhost:5161/applicant/profile/programmesRead";
    public static string GetApplicantIdentification = "http://localhost:5161/applicant/profile/identification/";
    public static string GetUserProgrammes = "http://localhost:5161/applicant/profile/programmesRead"; 
    public static string GetUserDepartments = "http://localhost:5161/applicant/departments";

    // Request Types 
    public static string AllRequests = "http://localhost:5161/request_type";
    public static string GetRequestTypeById = "http://localhost:5161/requestType";
    public static string GetDepartmentRequestTypeByName = "http://localhost:5161/departmentRequestTypeByName";
    public static string GetDepartmentRequestTypeById = "http://localhost:5161/singleDepartmentRequestTypeById"; 
    public static string GetSingleDepartmentRequestTypeById = "http://localhost:5161/singleDepartmentRequestTypeById"; 
    public static string CreateNewRequest = "http://localhost:5161/applicant/request";
    public static string CreateNewRequestType = "http://localhost:5161/request_type";
    public static string DeleteRequestType = "http://localhost:5161/request-type/delete";
    public static string GetDepartmentRequestPaymentChannelById = "http://localhost:5161/departmentPaymentChannel";
    public static string DepartmentRequestTypeFormField = "http://localhost:5161/departmentRequestTypeFormField";

    // department 
    public static string AllSubscribedDepartments = "http://localhost:5161/allSubscribedDepartments";
    public static string GetSubscribedDepartmentById = "http://localhost:5161/getSubscribedDepartment";
    public static string AllDepartmentRequestTypeById = " http://localhost:5161/allDepartmentRequestTypesByDepartmentId";

    public static string AllDepartmentRequestTypes = "http://localhost:5161/allDepartmentRequestTypes";
    public static string AddNewDepartmentSubscription = "http://localhost:5161/department_subscription";
    public static string CreateNewDepartmentRequestType = "http://localhost:5161/createDepartmentRequestType";

    // Admin
    public static string AllDepartmentRequestTransactions = "http://localhost:5161/allApplicantRequests";
    public static string VerifyApplicantRequest = "http://localhost:5161/applicant/verify-requestTransaction";

    // Dev Admin
    public static string AllRequestTransactions = "http://localhost:5161/all-request-transactions";
    public static string NewFormStep = "http://localhost:5161/addFormStep";
    public static string GenericServiceFormField = "http://localhost:5161/serviceFormField";
    public static string FetchGenericFormFields = "http://localhost:5161/formStep";

}
