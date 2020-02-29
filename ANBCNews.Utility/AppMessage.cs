using System;

namespace ANBCNews.Utility
{
    public class AppMessage
    {
        public const string SystemError = "Some error occurred.";
        public const string RecordSave = "Record saved successfully.";
        public const string RecordUpdate = "Record updated successfully.";
        public const string RecordDelete = "Record deleted successfully.";
        public const string ResetPassword = "User default password has been reset and sent to email address.";
        public const string UnknownError = "Some error occurred.";
        public const string DuplicateRecord = "#Record# is already exist.";
        public const string RecordNotUpdate = "Record not updated.";
        public const string RecordNotSave = "Record not save.";
        public const string MassageSend = "Message  send successfully.";
        public const string RecordNotDelete = "Record Not deleted.";
    }
    public class APIStatusCode 
    {
        public const string SystemError = "10501";
        public const string ValidationFailed = "10502";
        public const string InternalError = "10503";
        public const string Success = "10200";
    }
}
