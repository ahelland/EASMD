using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EAS_Protocol.WBXML
{
    public class ASCodePageProvider : ICodePageProvider
    {
        private IList<CodePage> codePages;

        public ASCodePageProvider()
        {
            codePages = new List<CodePage>
            {
                new CodePage { Code = 0, Namespace = "AirSync",
                    Tokens = new List<Token> 
                    { 
                        new Token { Code = 0x05, Name = "Sync" },
                        new Token { Code = 0x06, Name = "Responses" },
                        new Token { Code = 0x07, Name = "Add" },
                        new Token { Code = 0x08, Name = "Change" },
                        new Token { Code = 0x09, Name = "Delete" },
                        new Token { Code = 0x0A, Name = "Fetch" },
                        new Token { Code = 0x0B, Name = "SyncKey" },
                        new Token { Code = 0x0C, Name = "ClientId" },
                        new Token { Code = 0x0D, Name = "ServerId" },
                        new Token { Code = 0x0E, Name = "Status" },
                        new Token { Code = 0x0F, Name = "Collection" },
                        new Token { Code = 0x10, Name = "Class" },
                        new Token { Code = 0x12, Name = "CollectionId" },
                        new Token { Code = 0x13, Name = "GetChanges" },
                        new Token { Code = 0x14, Name = "MoreAvailable" },
                        new Token { Code = 0x15, Name = "WindowSize" },
                        new Token { Code = 0x16, Name = "Commands" },
                        new Token { Code = 0x17, Name = "Options" },
                        new Token { Code = 0x18, Name = "FilterType" },
                        new Token { Code = 0x1B, Name = "Conflict" },
                        new Token { Code = 0x1C, Name = "Collections" },
                        new Token { Code = 0x1D, Name = "ApplicationData" },
                        new Token { Code = 0x1E, Name = "DeletesAsMoves" },
                        new Token { Code = 0x20, Name = "Supported" },
                        new Token { Code = 0x21, Name = "SoftDelete" },
                        new Token { Code = 0x22, Name = "MIMESupport" },
                        new Token { Code = 0x23, Name = "MIMETruncation" },
                        new Token { Code = 0x24, Name = "Wait" },
                        new Token { Code = 0x25, Name = "Limit" },
                        new Token { Code = 0x26, Name = "Partial" },
                        new Token { Code = 0x27, Name = "ConversationMode" },
                        new Token { Code = 0x28, Name = "MaxItems" },
                        new Token { Code = 0x29, Name = "HeartbeatInterval" }
                    }
                },
                new CodePage { Code = 1, Namespace = "Contacts",
                    Tokens = new List<Token> 
                    { 
                        new Token { Code = 0x05, Name = "Anniversary" },
                        new Token { Code = 0x06, Name = "AssistantName" },
                        new Token { Code = 0x07, Name = "AssistantTelephoneNumber" },
                        new Token { Code = 0x08, Name = "Birthday" },
                        new Token { Code = 0x0C, Name = "Business2PhoneNumber" },
                        new Token { Code = 0x0D, Name = "BusinessCity" },
                        new Token { Code = 0x0E, Name = "BusinessCountry" },
                        new Token { Code = 0x0F, Name = "BusinessPostalCode" },
                        new Token { Code = 0x10, Name = "BusinessState" },
                        new Token { Code = 0x11, Name = "BusinessStreet" },
                        new Token { Code = 0x12, Name = "BusinessFaxNumber" },
                        new Token { Code = 0x13, Name = "BusinessPhoneNumber" },
                        new Token { Code = 0x14, Name = "CarPhoneNumber" },
                        new Token { Code = 0x15, Name = "Categories" },
                        new Token { Code = 0x16, Name = "Category" },
                        new Token { Code = 0x17, Name = "Children" },
                        new Token { Code = 0x18, Name = "Child" },
                        new Token { Code = 0x19, Name = "CompanyName" },
                        new Token { Code = 0x1A, Name = "Department" },
                        new Token { Code = 0x1B, Name = "Email1Address" },
                        new Token { Code = 0x1C, Name = "Email2Address" },
                        new Token { Code = 0x1D, Name = "Email3Address" },
                        new Token { Code = 0x1E, Name = "FileAs" },
                        new Token { Code = 0x1F, Name = "FirstName" },
                        new Token { Code = 0x20, Name = "Home2PhoneNumber" },
                        new Token { Code = 0x21, Name = "HomeCity" },
                        new Token { Code = 0x22, Name = "HomeCountry" },
                        new Token { Code = 0x23, Name = "HomePostalCode" },
                        new Token { Code = 0x24, Name = "HomeState" },
                        new Token { Code = 0x25, Name = "HomeStreet" },
                        new Token { Code = 0x26, Name = "HomeFaxNumber" },
                        new Token { Code = 0x27, Name = "HomePhoneNumber" },
                        new Token { Code = 0x28, Name = "JobTitle" },
                        new Token { Code = 0x29, Name = "LastName" },
                        new Token { Code = 0x2A, Name = "MiddleName" },
                        new Token { Code = 0x2B, Name = "MobilePhoneNumber" },
                        new Token { Code = 0x2C, Name = "OfficeLocation" },
                        new Token { Code = 0x2D, Name = "OtherCity" },
                        new Token { Code = 0x2E, Name = "OtherCountry" },
                        new Token { Code = 0x2F, Name = "OtherPostalCode" },
                        new Token { Code = 0x30, Name = "OtherState" },
                        new Token { Code = 0x31, Name = "OtherStreet" },
                        new Token { Code = 0x32, Name = "PagerNumber" },
                        new Token { Code = 0x33, Name = "RadioPhoneNumber" },
                        new Token { Code = 0x34, Name = "Spouse" },
                        new Token { Code = 0x35, Name = "Suffix" },
                        new Token { Code = 0x36, Name = "Title" },
                        new Token { Code = 0x37, Name = "Webpage" },
                        new Token { Code = 0x38, Name = "YomiCompanyName" },
                        new Token { Code = 0x39, Name = "YomiFirstName" },
                        new Token { Code = 0x3A, Name = "YomiLastName" },
                        new Token { Code = 0x3C, Name = "Picture" },
                        new Token { Code = 0x3D, Name = "Alias" },
                        new Token { Code = 0x3E, Name = "WeightedRank" },
                    }
                },
                new CodePage { Code = 2, Namespace = "Email",
                    Tokens = new List<Token> 
                    { 
                        new Token { Code = 0x0F, Name = "DateReceived" },
                        new Token { Code = 0x11, Name = "DisplayTo" },
                        new Token { Code = 0x12, Name = "Importance" },
                        new Token { Code = 0x13, Name = "MessageClass" },
                        new Token { Code = 0x14, Name = "Subject" },
                        new Token { Code = 0x15, Name = "Read" },
                        new Token { Code = 0x16, Name = "To" },
                        new Token { Code = 0x17, Name = "Cc" },
                        new Token { Code = 0x18, Name = "From" },
                        new Token { Code = 0x19, Name = "ReplyTo" },
                        new Token { Code = 0x1A, Name = "AllDayEvent" },
                        new Token { Code = 0x1B, Name = "Categories" },
                        new Token { Code = 0x1C, Name = "Category" },
                        new Token { Code = 0x1D, Name = "DTStamp" },
                        new Token { Code = 0x1E, Name = "EndTime" },
                        new Token { Code = 0x1F, Name = "InstanceType" },
                        new Token { Code = 0x20, Name = "BusyStatus" },
                        new Token { Code = 0x21, Name = "Location" },
                        new Token { Code = 0x22, Name = "MeetingRequest" },
                        new Token { Code = 0x23, Name = "Organizer" },
                        new Token { Code = 0x24, Name = "RecurrenceId" },
                        new Token { Code = 0x25, Name = "Reminder" },
                        new Token { Code = 0x26, Name = "ResponseRequested" },
                        new Token { Code = 0x27, Name = "Recurrences" },
                        new Token { Code = 0x28, Name = "Recurrence" },
                        new Token { Code = 0x29, Name = "Recurrence_Type" },
                        new Token { Code = 0x2A, Name = "Recurrence_Until" },
                        new Token { Code = 0x2B, Name = "Recurrence_Occurrences" },
                        new Token { Code = 0x2C, Name = "Recurrence_Interval" },
                        new Token { Code = 0x2D, Name = "Recurrence_DayOfWeek" },
                        new Token { Code = 0x2E, Name = "Recurrence_DayOfMonth" },
                        new Token { Code = 0x2F, Name = "Recurrence_WeekOfMonth" },
                        new Token { Code = 0x30, Name = "Recurrence_MonthOfYear" },
                        new Token { Code = 0x31, Name = "StartTime" },
                        new Token { Code = 0x32, Name = "Sensitivity" },
                        new Token { Code = 0x33, Name = "TimeZone" },
                        new Token { Code = 0x34, Name = "GlobalObjId" },
                        new Token { Code = 0x35, Name = "ThreadTopic" },
                        new Token { Code = 0x39, Name = "InternetCPID" },
                        new Token { Code = 0x3A, Name = "Flag" },
                        new Token { Code = 0x3B, Name = "FlagStatus" },
                        new Token { Code = 0x3C, Name = "ContentClass" },
                        new Token { Code = 0x3D, Name = "FlagType" },
                        new Token { Code = 0x3E, Name = "CompleteTime" },
                        new Token { Code = 0x3F, Name = "DisallowNewTimeProposal" },
                    }
                },
                new CodePage { Code = 3, Namespace = "AirNotify",
                    Tokens = new List<Token> 
                    { 
                    }
                },
                new CodePage { Code = 4, Namespace = "Calendar",
                    Tokens = new List<Token> 
                    { 
                        new Token { Code = 0x05, Name = "TimeZone" },
                        new Token { Code = 0x06, Name = "AllDayEvent" },
                        new Token { Code = 0x07, Name = "Attendees" },
                        new Token { Code = 0x08, Name = "Attendee" },
                        new Token { Code = 0x09, Name = "Attendee_Email" },
                        new Token { Code = 0x0A, Name = "Attendee_Name" },
                        new Token { Code = 0x0D, Name = "BusyStatus" },
                        new Token { Code = 0x0E, Name = "Categories" },
                        new Token { Code = 0x0F, Name = "Category" },
                        new Token { Code = 0x11, Name = "DTStamp" },
                        new Token { Code = 0x12, Name = "EndTime" },
                        new Token { Code = 0x13, Name = "Exception" },
                        new Token { Code = 0x14, Name = "Exceptions" },
                        new Token { Code = 0x15, Name = "Exception_Deleted" },
                        new Token { Code = 0x16, Name = "Exception_StartTime" },
                        new Token { Code = 0x17, Name = "Location" },
                        new Token { Code = 0x18, Name = "MeetingStatus" },
                        new Token { Code = 0x19, Name = "Organizer_Email" },
                        new Token { Code = 0x1A, Name = "Organizer_Name" },
                        new Token { Code = 0x1B, Name = "Recurrence" },
                        new Token { Code = 0x1C, Name = "Recurrence_Type" },
                        new Token { Code = 0x1D, Name = "Recurrence_Until" },
                        new Token { Code = 0x1E, Name = "Recurrence_Occurrences" },
                        new Token { Code = 0x1F, Name = "Recurrence_Interval" },
                        new Token { Code = 0x20, Name = "Recurrence_DayOfWeek" },
                        new Token { Code = 0x21, Name = "Recurrence_DayOfMonth" },
                        new Token { Code = 0x22, Name = "Recurrence_WeekOfMonth" },
                        new Token { Code = 0x23, Name = "Recurrence_MonthOfYear" },
                        new Token { Code = 0x24, Name = "Reminder" },
                        new Token { Code = 0x25, Name = "Sensitivity" },
                        new Token { Code = 0x26, Name = "Subject" },
                        new Token { Code = 0x27, Name = "StartTime" },
                        new Token { Code = 0x28, Name = "UID" },
                        new Token { Code = 0x29, Name = "Attendee_Status" },
                        new Token { Code = 0x2A, Name = "Attendee_Type" },
                        new Token { Code = 0x33, Name = "DisallowNewTimeProposal" },
                        new Token { Code = 0x34, Name = "ResponseRequested" },
                        new Token { Code = 0x35, Name = "AppointmentReplyTime" },
                        new Token { Code = 0x36, Name = "ResponseType" },
                        new Token { Code = 0x37, Name = "CalendarType" },
                        new Token { Code = 0x38, Name = "IsLeapMonth" },
                        new Token { Code = 0x39, Name = "FirstDayOfWeek" },
                        new Token { Code = 0x3A, Name = "OnlineMeetingConfLink" },
                        new Token { Code = 0x3B, Name = "OnlineMeetingExternalLink" },
                    }
                },
                new CodePage { Code = 5, Namespace = "Move",
                    Tokens = new List<Token> 
                    { 
                        new Token { Code = 0x05, Name = "MoveItems" },
                        new Token { Code = 0x06, Name = "Move" },
                        new Token { Code = 0x07, Name = "SrcMsgId" },
                        new Token { Code = 0x08, Name = "SrcFldId" },
                        new Token { Code = 0x09, Name = "DstFldId" },
                        new Token { Code = 0x0A, Name = "Response" },
                        new Token { Code = 0x0B, Name = "Status" },
                        new Token { Code = 0x0C, Name = "DstMsgId" },
                    }
                },
                new CodePage { Code = 6, Namespace = "ItemEstimate",
                    Tokens = new List<Token> 
                    { 
                        new Token { Code = 0x05, Name = "GetItemEstimate" },
                        new Token { Code = 0x06, Name = "Version" },
                        new Token { Code = 0x07, Name = "Collections" },
                        new Token { Code = 0x08, Name = "Collection" },
                        new Token { Code = 0x09, Name = "Class" },
                        new Token { Code = 0x0A, Name = "CollectionId" },
                        new Token { Code = 0x0B, Name = "DateTime" },
                        new Token { Code = 0x0C, Name = "Estimate" },
                        new Token { Code = 0x0D, Name = "Response" },
                        new Token { Code = 0x0E, Name = "Status" },
                    }
                },
                new CodePage { Code = 7, Namespace = "FolderHierarchy",
                    Tokens = new List<Token> 
                    { 
                        new Token { Code = 0x07, Name = "DisplayName" },
                        new Token { Code = 0x08, Name = "ServerId" },
                        new Token { Code = 0x09, Name = "ParentId" },
                        new Token { Code = 0x0A, Name = "Type" },
                        new Token { Code = 0x0C, Name = "Status" },
                        new Token { Code = 0x0E, Name = "Changes" },
                        new Token { Code = 0x0F, Name = "Add" },
                        new Token { Code = 0x10, Name = "Delete" },
                        new Token { Code = 0x11, Name = "Update" },
                        new Token { Code = 0x12, Name = "SyncKey" },
                        new Token { Code = 0x13, Name = "FolderCreate" },
                        new Token { Code = 0x14, Name = "FolderDelete" },
                        new Token { Code = 0x15, Name = "FolderUpdate" },
                        new Token { Code = 0x16, Name = "FolderSync" },
                        new Token { Code = 0x17, Name = "Count" },
                    }
                },
                new CodePage { Code = 8, Namespace = "MeetingResponse",
                    Tokens = new List<Token> 
                    { 
                        new Token { Code = 0x05, Name = "CalendarId" },
                        new Token { Code = 0x06, Name = "CollectionId" },
                        new Token { Code = 0x07, Name = "MeetingResponse" },
                        new Token { Code = 0x08, Name = "RequestId" },
                        new Token { Code = 0x09, Name = "Request" },
                        new Token { Code = 0x0A, Name = "Result" },
                        new Token { Code = 0x0B, Name = "Status" },
                        new Token { Code = 0x0C, Name = "UserResponse" },
                        new Token { Code = 0x0E, Name = "InstanceId" },
                    }
                },
                new CodePage { Code = 9, Namespace = "Tasks",
                    Tokens = new List<Token> 
                    { 
                        new Token { Code = 0x08, Name = "Categories" }, 
                        new Token { Code = 0x09, Name = "Category" }, 
                        new Token { Code = 0x0A, Name = "Complete" }, 
                        new Token { Code = 0x0B, Name = "DateCompleted" }, 
                        new Token { Code = 0x0C, Name = "DueDate" }, 
                        new Token { Code = 0x0D, Name = "UTCDueDate" }, 
                        new Token { Code = 0x0E, Name = "Importance" }, 
                        new Token { Code = 0x0F, Name = "Recurrence" }, 
                        new Token { Code = 0x10, Name = "Recurrence_Type" }, 
                        new Token { Code = 0x11, Name = "Recurrence_Start" }, 
                        new Token { Code = 0x12, Name = "Recurrence_Until" }, 
                        new Token { Code = 0x13, Name = "Recurrence_Occurrences" }, 
                        new Token { Code = 0x14, Name = "Recurrence_Interval" }, 
                        new Token { Code = 0x15, Name = "Recurrence_DayOfMonth" }, 
                        new Token { Code = 0x16, Name = "Recurrence_DayOfWeek" }, 
                        new Token { Code = 0x17, Name = "Recurrence_WeekOfMonth" }, 
                        new Token { Code = 0x18, Name = "Recurrence_MonthOfYear" }, 
                        new Token { Code = 0x19, Name = "Recurrence_Regenerate" }, 
                        new Token { Code = 0x1A, Name = "Recurrence_DeadOccur" }, 
                        new Token { Code = 0x1B, Name = "ReminderSet" }, 
                        new Token { Code = 0x1C, Name = "ReminderTime" }, 
                        new Token { Code = 0x1D, Name = "Sensitivity" }, 
                        new Token { Code = 0x1E, Name = "StartDate" }, 
                        new Token { Code = 0x1F, Name = "UTCStartDate" }, 
                        new Token { Code = 0x20, Name = "Subject" }, 
                        new Token { Code = 0x22, Name = "OrdinalDate" }, 
                        new Token { Code = 0x23, Name = "SubOrdinalDate" }, 
                        new Token { Code = 0x24, Name = "CalendarType" }, 
                        new Token { Code = 0x25, Name = "IsLeapMonth" }, 
                        new Token { Code = 0x26, Name = "FirstDayOfWeek" }, 
                    }
                },
                new CodePage { Code = 10, Namespace = "ResolveRecipients",
                    Tokens = new List<Token> 
                    { 
                        new Token { Code = 0x05, Name = "ResolveRecipients" }, 
                        new Token { Code = 0x06, Name = "Response" }, 
                        new Token { Code = 0x07, Name = "Status" }, 
                        new Token { Code = 0x08, Name = "Type" }, 
                        new Token { Code = 0x09, Name = "Recipient" }, 
                        new Token { Code = 0x0A, Name = "DisplayName" }, 
                        new Token { Code = 0x0B, Name = "EmailAddress" }, 
                        new Token { Code = 0x0C, Name = "Certificates" }, 
                        new Token { Code = 0x0D, Name = "Certificate" }, 
                        new Token { Code = 0x0E, Name = "MiniCertificate" }, 
                        new Token { Code = 0x0F, Name = "Options" }, 
                        new Token { Code = 0x10, Name = "To" }, 
                        new Token { Code = 0x11, Name = "CertificateRetrieval" }, 
                        new Token { Code = 0x12, Name = "RecipientCount" }, 
                        new Token { Code = 0x13, Name = "MaxCertificates" }, 
                        new Token { Code = 0x14, Name = "MaxAmbiguousRecipients" }, 
                        new Token { Code = 0x15, Name = "CertificateCount" }, 
                        new Token { Code = 0x16, Name = "Availability" }, 
                        new Token { Code = 0x17, Name = "StartTime" }, 
                        new Token { Code = 0x18, Name = "EndTime" }, 
                        new Token { Code = 0x19, Name = "MergedFreeBusy" }, 
                        new Token { Code = 0x1A, Name = "Picture" }, 
                        new Token { Code = 0x1B, Name = "MaxSize" }, 
                        new Token { Code = 0x1C, Name = "Data" }, 
                        new Token { Code = 0x1D, Name = "MaxPictures" }, 
                    }
                },
                new CodePage { Code = 11, Namespace = "ValidateCert",
                    Tokens = new List<Token> 
                    { 
                        new Token { Code = 0x05, Name = "ValidateCert" },
                        new Token { Code = 0x06, Name = "Certificates" }, 
                        new Token { Code = 0x07, Name = "Certificate" }, 
                        new Token { Code = 0x08, Name = "CertificateChain" }, 
                        new Token { Code = 0x09, Name = "CheckCRL" }, 
                        new Token { Code = 0x0A, Name = "Status" },                     
                    }
                },
                new CodePage { Code = 12, Namespace = "Contacts2",
                    Tokens = new List<Token> 
                    { 
                        new Token { Code = 0x05, Name = "CustomerId" }, 
                        new Token { Code = 0x06, Name = "GovernmentId" }, 
                        new Token { Code = 0x07, Name = "IMAddress" }, 
                        new Token { Code = 0x08, Name = "IMAddress2" }, 
                        new Token { Code = 0x09, Name = "IMAddress3" }, 
                        new Token { Code = 0x0A, Name = "ManagerName" }, 
                        new Token { Code = 0x0B, Name = "CompanyMainPhone" }, 
                        new Token { Code = 0x0C, Name = "AccountName" }, 
                        new Token { Code = 0x0D, Name = "NickName" }, 
                        new Token { Code = 0x0E, Name = "MMS" }, 
                    }
                },
                new CodePage { Code = 13, Namespace = "Ping",
                    Tokens = new List<Token> 
                    { 
                        new Token { Code = 0x05, Name = "Ping" }, 
                        new Token { Code = 0x06, Name = "AutdState" }, 
                        new Token { Code = 0x07, Name = "Status" }, 
                        new Token { Code = 0x08, Name = "HeartbeatInterval" }, 
                        new Token { Code = 0x09, Name = "Folders" }, 
                        new Token { Code = 0x0A, Name = "Folder" }, 
                        new Token { Code = 0x0B, Name = "Id" }, 
                        new Token { Code = 0x0C, Name = "Class" }, 
                        new Token { Code = 0x0D, Name = "MaxFolders" }, 
                    }
                },
                new CodePage { Code = 14, Namespace = "Provision",
                    Tokens = new List<Token> 
                    { 
                        new Token { Code = 0x05, Name = "Provision" }, 
                        new Token { Code = 0x06, Name = "Policies" }, 
                        new Token { Code = 0x07, Name = "Policy" }, 
                        new Token { Code = 0x08, Name = "PolicyType" }, 
                        new Token { Code = 0x09, Name = "PolicyKey" }, 
                        new Token { Code = 0x0A, Name = "Data" }, 
                        new Token { Code = 0x0B, Name = "Status" }, 
                        new Token { Code = 0x0C, Name = "RemoteWipe" }, 
                        new Token { Code = 0x0D, Name = "EASProvisionDoc" }, 
                        new Token { Code = 0x0E, Name = "DevicePasswordEnabled" }, 
                        new Token { Code = 0x0F, Name = "AlphanumericDevicePasswordRequired" }, 
                        new Token { Code = 0x10, Name = "DeviceEncryptionEnabled" }, 
                        new Token { Code = 0x10, Name = "RequireStorageCardEncryption" }, 
                        new Token { Code = 0x11, Name = "PasswordRecoveryEnabled" }, 
                        new Token { Code = 0x13, Name = "AttachmentsEnabled" }, 
                        new Token { Code = 0x14, Name = "MinDevicePasswordLength" }, 
                        new Token { Code = 0x15, Name = "MaxInactivityTimeDeviceLock" }, 
                        new Token { Code = 0x16, Name = "MaxDevicePasswordFailedAttempts" }, 
                        new Token { Code = 0x17, Name = "MaxAttachmentSize" }, 
                        new Token { Code = 0x18, Name = "AllowSimpleDevicePassword" }, 
                        new Token { Code = 0x19, Name = "DevicePasswordExpiration" }, 
                        new Token { Code = 0x1A, Name = "DevicePasswordHistory" }, 
                        new Token { Code = 0x1B, Name = "AllowStorageCard" }, 
                        new Token { Code = 0x1C, Name = "AllowCamera" }, 
                        new Token { Code = 0x1D, Name = "RequireDeviceEncryption" }, 
                        new Token { Code = 0x1E, Name = "AllowUnsignedApplications" }, 
                        new Token { Code = 0x1F, Name = "AllowUnsignedInstallationPackages" }, 
                        new Token { Code = 0x20, Name = "MinDevicePasswordComplexCharacters" }, 
                        new Token { Code = 0x21, Name = "AllowWiFi" }, 
                        new Token { Code = 0x22, Name = "AllowTextMessaging" }, 
                        new Token { Code = 0x23, Name = "AllowPOPIMAPEmail" }, 
                        new Token { Code = 0x24, Name = "AllowBluetooth" }, 
                        new Token { Code = 0x25, Name = "AllowIrDA" }, 
                        new Token { Code = 0x26, Name = "RequireManualSyncWhenRoaming" }, 
                        new Token { Code = 0x27, Name = "AllowDesktopSync" }, 
                        new Token { Code = 0x28, Name = "MaxCalendarAgeFilter" }, 
                        new Token { Code = 0x29, Name = "AllowHTMLEmail" }, 
                        new Token { Code = 0x2A, Name = "MaxEmailAgeFilter" }, 
                        new Token { Code = 0x2B, Name = "MaxEmailBodyTruncationSize" }, 
                        new Token { Code = 0x2C, Name = "MaxEmailHTMLBodyTruncationSize" }, 
                        new Token { Code = 0x2D, Name = "RequireSignedSMIMEMessages" }, 
                        new Token { Code = 0x2E, Name = "RequireEncryptedSMIMEMessages" }, 
                        new Token { Code = 0x2F, Name = "RequireSignedSMIMEAlgorithm" }, 
                        new Token { Code = 0x30, Name = "RequireEncryptionSMIMEAlgorithm" }, 
                        new Token { Code = 0x31, Name = "AllowSMIMEEncryptionAlgorithmNegotiation" }, 
                        new Token { Code = 0x32, Name = "AllowSMIMESoftCerts" }, 
                        new Token { Code = 0x33, Name = "AllowBrowser" }, 
                        new Token { Code = 0x34, Name = "AllowConsumerEmail" }, 
                        new Token { Code = 0x35, Name = "AllowRemoteDesktop" }, 
                        new Token { Code = 0x36, Name = "AllowInternetSharing" }, 
                        new Token { Code = 0x37, Name = "UnapprovedInROMApplicationList" }, 
                        new Token { Code = 0x38, Name = "ApplicationName" }, 
                        new Token { Code = 0x39, Name = "ApprovedApplicationList" }, 
                        new Token { Code = 0x3A, Name = "Hash" }, 
                    }
                },
                new CodePage { Code = 15, Namespace = "Search",
                    Tokens = new List<Token> 
                    { 
                        new Token { Code = 0x05, Name = "Search" }, 
                        new Token { Code = 0x07, Name = "Store" }, 
                        new Token { Code = 0x08, Name = "Name" }, 
                        new Token { Code = 0x09, Name = "Query" }, 
                        new Token { Code = 0x0A, Name = "Options" }, 
                        new Token { Code = 0x0B, Name = "Range" }, 
                        new Token { Code = 0x0C, Name = "Status" }, 
                        new Token { Code = 0x0D, Name = "Response" }, 
                        new Token { Code = 0x0E, Name = "Result" }, 
                        new Token { Code = 0x0F, Name = "Properties" }, 
                        new Token { Code = 0x10, Name = "Total" }, 
                        new Token { Code = 0x11, Name = "EqualTo" }, 
                        new Token { Code = 0x12, Name = "Value" }, 
                        new Token { Code = 0x13, Name = "And" },  
                        new Token { Code = 0x14, Name = "Or" }, 
                        new Token { Code = 0x15, Name = "FreeText" }, 
                        new Token { Code = 0x17, Name = "DeepTraversal" }, 
                        new Token { Code = 0x18, Name = "LongId" }, 
                        new Token { Code = 0x19, Name = "RebuildResults" }, 
                        new Token { Code = 0x1A, Name = "LessThan" }, 
                        new Token { Code = 0x1B, Name = "GreaterThan" }, 
                        new Token { Code = 0x1E, Name = "UserName" }, 
                        new Token { Code = 0x1F, Name = "Password" }, 
                        new Token { Code = 0x20, Name = "ConversationId" }, 
                        new Token { Code = 0x21, Name = "Picture" }, 
                        new Token { Code = 0x22, Name = "MaxSize" }, 
                        new Token { Code = 0x23, Name = "MaxPictures" }, 
                    }
                },
                new CodePage { Code = 16, Namespace = "GAL",
                    Tokens = new List<Token> 
                    { 
                        new Token { Code = 0x05, Name = "DisplayName" }, 
                        new Token { Code = 0x06, Name = "Phone" }, 
                        new Token { Code = 0x07, Name = "Office" }, 
                        new Token { Code = 0x08, Name = "Title" }, 
                        new Token { Code = 0x09, Name = "Company" }, 
                        new Token { Code = 0x0A, Name = "Alias" }, 
                        new Token { Code = 0x0B, Name = "FirstName" }, 
                        new Token { Code = 0x0C, Name = "LastName" }, 
                        new Token { Code = 0x0D, Name = "HomePhone" }, 
                        new Token { Code = 0x0E, Name = "MobilePhone" }, 
                        new Token { Code = 0x0F, Name = "EmailAddress" }, 
                        new Token { Code = 0x10, Name = "Picture" }, 
                        new Token { Code = 0x11, Name = "Status" }, 
                        new Token { Code = 0x12, Name = "Data" }, 
                    }
                },
                new CodePage { Code = 17, Namespace = "AirSyncBase",
                    Tokens = new List<Token> 
                    { 
                        new Token { Code = 0x05, Name = "BodyPreference" }, 
                        new Token { Code = 0x06, Name = "Type" }, 
                        new Token { Code = 0x07, Name = "TruncationSize" }, 
                        new Token { Code = 0x08, Name = "AllOrNone" }, 
                        new Token { Code = 0x0A, Name = "Body" }, 
                        new Token { Code = 0x0B, Name = "Data" }, 
                        new Token { Code = 0x0C, Name = "EstimatedDataSize" }, 
                        new Token { Code = 0x0D, Name = "Truncated" }, 
                        new Token { Code = 0x0E, Name = "Attachments" }, 
                        new Token { Code = 0x0F, Name = "Attachment" }, 
                        new Token { Code = 0x10, Name = "DisplayName" }, 
                        new Token { Code = 0x11, Name = "FileReference" }, 
                        new Token { Code = 0x12, Name = "Method" }, 
                        new Token { Code = 0x13, Name = "ContentId" }, 
                        new Token { Code = 0x14, Name = "ContentLocation" },  
                        new Token { Code = 0x15, Name = "IsInline" }, 
                        new Token { Code = 0x16, Name = "NativeBodyType" }, 
                        new Token { Code = 0x17, Name = "ContentType" }, 
                        new Token { Code = 0x18, Name = "Preview" }, 
                        new Token { Code = 0x19, Name = "BodyPartPreference" }, 
                        new Token { Code = 0x1A, Name = "BodyPart" }, 
                        new Token { Code = 0x1B, Name = "Status" },
                    }
                },
                new CodePage { Code = 18, Namespace = "Settings",
                    Tokens = new List<Token> 
                    { 
                        new Token { Code = 0x05, Name = "Settings" }, 
                        new Token { Code = 0x06, Name = "Status" }, 
                        new Token { Code = 0x07, Name = "Get" }, 
                        new Token { Code = 0x08, Name = "Set" }, 
                        new Token { Code = 0x09, Name = "Oof" }, 
                        new Token { Code = 0x0A, Name = "OofState" }, 
                        new Token { Code = 0x0B, Name = "StartTime" }, 
                        new Token { Code = 0x0C, Name = "EndTime" }, 
                        new Token { Code = 0x0D, Name = "OofMessage" }, 
                        new Token { Code = 0x0E, Name = "AppliesToInternal" }, 
                        new Token { Code = 0x0F, Name = "AppliesToExternalKnown" }, 
                        new Token { Code = 0x10, Name = "AppliesToExternalUnknown" }, 
                        new Token { Code = 0x11, Name = "Enabled" }, 
                        new Token { Code = 0x12, Name = "ReplyMessage" }, 
                        new Token { Code = 0x13, Name = "BodyType" }, 
                        new Token { Code = 0x14, Name = "DevicePassword" }, 
                        new Token { Code = 0x15, Name = "Password" }, 
                        new Token { Code = 0x16, Name = "DeviceInformaton" }, 
                        new Token { Code = 0x17, Name = "Model" }, 
                        new Token { Code = 0x18, Name = "IMEI" }, 
                        new Token { Code = 0x19, Name = "FriendlyName" }, 
                        new Token { Code = 0x1A, Name = "OS" }, 
                        new Token { Code = 0x1B, Name = "OSLanguage" }, 
                        new Token { Code = 0x1C, Name = "PhoneNumber" }, 
                        new Token { Code = 0x1D, Name = "UserInformation" }, 
                        new Token { Code = 0x1E, Name = "EmailAddresses" }, 
                        new Token { Code = 0x1F, Name = "SmtpAddress" }, 
                        new Token { Code = 0x20, Name = "UserAgent" }, 
                        new Token { Code = 0x21, Name = "EnableOutboundSMS" }, 
                        new Token { Code = 0x22, Name = "MobileOperator" }, 
                        new Token { Code = 0x23, Name = "PrimarySmtpAddress" }, 
                        new Token { Code = 0x24, Name = "Accounts" }, 
                        new Token { Code = 0x25, Name = "Account" }, 
                        new Token { Code = 0x26, Name = "AccountId" }, 
                        new Token { Code = 0x27, Name = "AccountName" }, 
                        new Token { Code = 0x28, Name = "UserDisplayName" }, 
                        new Token { Code = 0x29, Name = "SendDisabled" }, 
                        new Token { Code = 0x2B, Name = "RightsManagementInformation" }, 
                    }
                },
                new CodePage { Code = 19, Namespace = "DocumentLibrary",
                    Tokens = new List<Token> 
                    { 
                        new Token { Code = 0x05, Name = "LinkId" }, 
                        new Token { Code = 0x06, Name = "DisplayName" }, 
                        new Token { Code = 0x07, Name = "IsFolder" }, 
                        new Token { Code = 0x08, Name = "CreationDate" }, 
                        new Token { Code = 0x09, Name = "LastModifiedDate" }, 
                        new Token { Code = 0x0A, Name = "IsHidden" }, 
                        new Token { Code = 0x0B, Name = "ContentLength" }, 
                        new Token { Code = 0x0C, Name = "ContentType" }, 
                    }
                },
                new CodePage { Code = 20, Namespace = "ItemOperations",
                    Tokens = new List<Token> 
                    { 
                        new Token { Code = 0x05, Name = "ItemOperations" }, 
                        new Token { Code = 0x06, Name = "Fetch" }, 
                        new Token { Code = 0x07, Name = "Store" }, 
                        new Token { Code = 0x08, Name = "Options" }, 
                        new Token { Code = 0x09, Name = "Range" }, 
                        new Token { Code = 0x0A, Name = "Total" }, 
                        new Token { Code = 0x0B, Name = "Properties" }, 
                        new Token { Code = 0x0C, Name = "Data" }, 
                        new Token { Code = 0x0D, Name = "Status" }, 
                        new Token { Code = 0x0E, Name = "Response" }, 
                        new Token { Code = 0x0F, Name = "Version" }, 
                        new Token { Code = 0x10, Name = "Schema" }, 
                        new Token { Code = 0x11, Name = "Part" }, 
                        new Token { Code = 0x12, Name = "EmptyFolderContents" }, 
                        new Token { Code = 0x13, Name = "DeleteSubFolders" }, 
                        new Token { Code = 0x14, Name = "UserName" }, 
                        new Token { Code = 0x15, Name = "Password" }, 
                        new Token { Code = 0x16, Name = "Move" }, 
                        new Token { Code = 0x17, Name = "DstFldId" }, 
                        new Token { Code = 0x18, Name = "ConversationId" },
                        new Token { Code = 0x19, Name = "MoveAlways" }, 
                    }
                },
                new CodePage { Code = 21, Namespace = "ComposeMail",
                    Tokens = new List<Token> 
                    { 
                        new Token { Code = 0x05, Name = "SendMail" }, 
                        new Token { Code = 0x06, Name = "SmartForward" }, 
                        new Token { Code = 0x07, Name = "SmartReply" }, 
                        new Token { Code = 0x08, Name = "SaveInSentItems" }, 
                        new Token { Code = 0x09, Name = "ReplaceMime" }, 
                        new Token { Code = 0x0B, Name = "Source" }, 
                        new Token { Code = 0x0C, Name = "FolderId" }, 
                        new Token { Code = 0x0D, Name = "ItemId" }, 
                        new Token { Code = 0x0E, Name = "LongId" }, 
                        new Token { Code = 0x0F, Name = "InstanceId" }, 
                        new Token { Code = 0x10, Name = "MIME" }, 
                        new Token { Code = 0x11, Name = "ClientId" }, 
                        new Token { Code = 0x12, Name = "Status" }, 
                        new Token { Code = 0x13, Name = "AccountId" }, 
                    }
                },
                new CodePage { Code = 22, Namespace = "Email2",
                    Tokens = new List<Token> 
                    { 
                        new Token { Code = 0x05, Name = "UmCallerID" }, 
                        new Token { Code = 0x06, Name = "UmUserNotes" }, 
                        new Token { Code = 0x07, Name = "UmAttDuration" }, 
                        new Token { Code = 0x08, Name = "UmAttOrder" }, 
                        new Token { Code = 0x09, Name = "ConversationId" }, 
                        new Token { Code = 0x0A, Name = "ConversationIndex" }, 
                        new Token { Code = 0x0B, Name = "LastVerbExecuted" }, 
                        new Token { Code = 0x0C, Name = "LastVerbExecutionTime" }, 
                        new Token { Code = 0x0D, Name = "ReceivedAsBcc" }, 
                        new Token { Code = 0x0E, Name = "Sender" }, 
                        new Token { Code = 0x0F, Name = "CalendarType" }, 
                        new Token { Code = 0x10, Name = "IsLeapMonth" }, 
                        new Token { Code = 0x11, Name = "AccountId" }, 
                        new Token { Code = 0x12, Name = "FirstDayOfWeek" }, 
                        new Token { Code = 0x13, Name = "MeetingMessageType" }, 
                    }
                },
                new CodePage { Code = 23, Namespace = "Notes",
                    Tokens = new List<Token> 
                    { 
                        new Token { Code = 0x05, Name = "Subject" }, 
                        new Token { Code = 0x06, Name = "MessageClass" }, 
                        new Token { Code = 0x07, Name = "LastModifiedDate" }, 
                        new Token { Code = 0x08, Name = "Categories" }, 
                        new Token { Code = 0x09, Name = "Category" }, 
                    }
                },
                new CodePage { Code = 24, Namespace = "RightsManagement",
                    Tokens = new List<Token> 
                    { 
                        new Token { Code = 0x05, Name = "RightsManagementSupport" }, 
                        new Token { Code = 0x06, Name = "RightsManagementTemplates" }, 
                        new Token { Code = 0x07, Name = "RightsManagementTemplate" }, 
                        new Token { Code = 0x08, Name = "RightsManagementLicense" }, 
                        new Token { Code = 0x09, Name = "EditAllowed" }, 
                        new Token { Code = 0x0A, Name = "ReplyAllowed" }, 
                        new Token { Code = 0x0B, Name = "ReplyAllAllowed" }, 
                        new Token { Code = 0x0C, Name = "ForwardAllowed" }, 
                        new Token { Code = 0x0D, Name = "ModifyRecipientsAllowed" }, 
                        new Token { Code = 0x0E, Name = "ExtractAllowed" }, 
                        new Token { Code = 0x0F, Name = "PrintAllowed" }, 
                        new Token { Code = 0x10, Name = "ExportAllowed" }, 
                        new Token { Code = 0x11, Name = "ProgrammaticAccessAllowed" }, 
                        new Token { Code = 0x12, Name = "RMOwner" }, 
                        new Token { Code = 0x13, Name = "ContentExpiryDate" }, 
                        new Token { Code = 0x14, Name = "TemplateID" }, 
                        new Token { Code = 0x15, Name = "TemplateName" }, 
                        new Token { Code = 0x16, Name = "TemplateDescription" }, 
                        new Token { Code = 0x17, Name = "ContentOwner" }, 
                        new Token { Code = 0x18, Name = "RemoveRightsManagementDistribution" }, 
                    }
                },
            };
        }

        public int GetCodePage(string name)
        {
            var codePage = codePages.FirstOrDefault(c => string.Equals(c.Namespace, name.TrimEnd(':'), StringComparison.CurrentCultureIgnoreCase));
            if (codePage != null)
            {
                return codePage.Code;
            }

            return -1;
        }

        public int GetToken(string name, string tag)
        {
            return GetToken(GetCodePage(name), tag);
        }

        public int GetToken(int codePage, string tag)
        {
            if (codePage >= 0)
            {
                var token = codePages
                    .FirstOrDefault(c => c.Code == codePage).Tokens
                        .FirstOrDefault(t => string.Equals(tag, t.Name, StringComparison.CurrentCultureIgnoreCase));
                if (token != null)
                {
                    return token.Code;
                }
            }

            return -1;
        }

        internal class CodePage
        {
            internal int Code { get; set; }
            internal string Namespace { get; set; }
            internal IList<Token> Tokens { get; set; }
        }

        internal class Token
        {
            internal int Code { get; set; }
            internal string Name { get; set; }
        }

        public string GetCodePage(int currentPage)
        {
            return codePages.FirstOrDefault(c => c.Code == currentPage).Namespace;
        }

        public string GetToken(int currentPage, int token)
        {
            var page = codePages.FirstOrDefault(c => c.Code == currentPage);
            if (page == null)
            {
                return "Error";
            }
            var value = page.Tokens.FirstOrDefault(t => t.Code == token);
            if (value == null)
            {
                return "Error";
            }
            return value.Name;
        }
    }
}
