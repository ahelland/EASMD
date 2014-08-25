
namespace EAS_Protocol
{
    public static class Enums
    {
        //MS-ASCMD 2.2.3.170.3 Type (FolderSync)
        //http://msdn.microsoft.com/en-us/library/gg650877(v=exchg.80).aspx
        public enum FolderSyncTypes
        {
            UserCreated_Generic = 1,
            Default_Inbox = 2,
            Default_Drafts = 3,
            Default_DeletedItems = 4,
            Default_SentItems = 5,
            Default_Outbox = 6,
            Default_Tasks = 7,
            Default_Calendar = 8,
            Default_Contacts = 9,
            Default_Notes = 10,
            Default_Journal = 11,
            UserCreated_Mail = 12,
            UserCreated_Calendar = 13,
            UserCreated_Contacts = 14,
            UserCreated_Tasks = 15,
            UserCreated_Journal = 16,
            UserCreated_Notes = 17,
            Unknown_Type = 18,
            Recipient_Info_Cache = 19,
        }        
    }

    public static class FolderSyncTypes
    {
        public const int 
            UserCreated_Generic = 1,
            Default_Inbox = 2,
            Default_Drafts = 3,
            Default_DeletedItems = 4,
            Default_SentItems = 5,
            Default_Outbox = 6,
            Default_Tasks = 7,
            Default_Calendar = 8,
            Default_Contacts = 9,
            Default_Notes = 10,
            Default_Journal = 11,
            UserCreated_Mail = 12,
            UserCreated_Calendar = 13,
            UserCreated_Contacts = 14,
            UserCreated_Tasks = 15,
            UserCreated_Journal = 16,
            UserCreated_Notes = 17,
            Unknown_Type = 18,
            Recipient_Info_Cache = 19;

    }

    //MS-ASCMD 2.2.2.22 Type (Body)
    //http://msdn.microsoft.com/en-us/library/hh475675(v=exchg.80).aspx
    public static class BodyTypes
    {
        public const string PLAIN_TEXT = "1";
        public const string HTML = "2";
        public const string RTF = "3";
        public const string MIME = "4";
    }

    //MS-ASCMD 2.2.3.110.2 Name (Search)
    //http://msdn.microsoft.com/en-us/library/gg650862(v=exchg.80).aspx
    public static class SearchTypes
    {
        public const string SEARCH_GAL = "GAL";
        public const string SEARCH_MAILBOX = "Mailbox";
        public const string SEARCH_DOCUMENT_LIBRARY = "DocumentLibrary";
    }

    //MS-ASCMD 2.2.2.8 ItemOperations
    //http://msdn.microsoft.com/en-us/library/ee202415(v=exchg.80).aspx
    public static class ItemOperationTypes
    {
        public const string FETCH = "Fetch";
        public const string EMPTY_FOLDER_CONTENTS = "EmptyFolderContents";
        public const string MOVE = "Move";
    }
}
