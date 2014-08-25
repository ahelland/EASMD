using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace EAS_Protocol.Models
{
    public class Device
    {        
        public int UserId { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Credentials { get; set; }
        public string ServerAddress { get; set; }
        public string ASVersion { get; set; }
        public string DeviceID { get; set; }
        public string DeviceType { get; set; }
        public string UserAgent { get; set; }
        public string DeviceModel { get; set; }
        public string DeviceIMEI { get; set; }
        public string DeviceFriendlyName { get; set; }
        public string DeviceOS { get; set; }
        public string DeviceOSLanguage { get; set; }
        public string DevicePhoneNumber { get; set; }
        public string DeviceMO { get; set; }
        public string DeviceUserAgent { get; set; }
        public bool Provisionable { get; set; }
    }

    public class GALEntry
    {      
        public string DisplayName { get; set; }
        public string Phone { get; set; }
        public string Office { get; set; }
        public string Title { get; set; }
        public string Company { get; set; }
        public string Alias { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string HomePhone { get; set; }
        public string MobilePhone { get; set; }
        public string EmailAddress { get; set; }
        public string Picture { get; set; }
        public string Status { get; set; }
        public string Data { get; set; }
    }

    public class Contact
    {        
        public string Anniversary { get; set; }
        public string AssistantName { get; set; }
        public string AssistantPhoneNumber { get; set; }
        public string Birthday { get; set; }
        public string Business2PhoneNumber { get; set; }
        public string BusinessAddressCity { get; set; }
        public string BusinessAddressCountry { get; set; }
        public string BusinessAddressPostalCode { get; set; }
        public string BusinessAddressState { get; set; }
        public string BusinessAddressStreet { get; set; }
        public string BusinessFaxNumber { get; set; }
        public string BusinessPhoneNumber { get; set; }
        public string CarPhoneNumber { get; set; }
        public string Categories { get; set; }
        public string Category { get; set; }
        public string Children { get; set; }
        public string Child { get; set; }
        public string CompanyName { get; set; }
        public string Department { get; set; }
        public string Email1Address { get; set; }
        public string Email2Address { get; set; }
        public string Email3Address { get; set; }
        public string FileAs { get; set; }
        public string FirstName { get; set; }
        public string Home2PhoneNumber { get; set; }
        public string HomeAddressCity { get; set; }
        public string HomeAddressCountry { get; set; }
        public string HomeAddressPostalCode { get; set; }
        public string HomeAddressState { get; set; }
        public string HomeAddressStreet { get; set; }
        public string HomeFaxNumber { get; set; }
        public string HomePhoneNumber { get; set; }
        public string JobTitle { get; set; }
        public string LastName { get; set; }
        public string MiddleName { get; set; }
        public string MobilePhoneNumber { get; set; }
        public string OfficeLocation { get; set; }
        public string OtherAddressCity { get; set; }
        public string OtherAddressCountry { get; set; }
        public string OtherAddressPostalCode { get; set; }
        public string OtherAddressState { get; set; }
        public string OtherAddressStreet { get; set; }
        public string PagerNumber { get; set; }
        public string RadioPhoneNumber { get; set; }
        public string Spouse { get; set; }
        public string Suffix { get; set; }
        public string Title { get; set; }
        public string WebPage { get; set; }
        public string YomiCompanyName { get; set; }
        public string YomiFirstName { get; set; }
        public string YomiLastName { get; set; }
        //Picture as base64-string
        public string Picture { get; set; }
        public string Alias { get; set; }
        public string WeightedRank { get; set; }
    }

    public class CalendarEntry
    {
        public string TimeZone { get; set; }
        public string AllDayEvent { get; set; }
        public string Attendees { get; set; }
        public string Attendee { get; set; }
        public string Email { get; set; }
        public string Name { get; set; }
        public string BusyStatus { get; set; }
        public string Categories { get; set; }
        public string Category { get; set; }
        public string DTStamp { get; set; }
        public string EndTime { get; set; }
        public string Exception { get; set; }
        public string Exceptions { get; set; }
        public string Deleted { get; set; }
        public string ExceptionStartTime { get; set; }
        public string Location { get; set; }
        public string MeetingStatus { get; set; }
        public string Organizer_Email { get; set; }
        public string Organizer_Name { get; set; }
        public string Recurrence { get; set; }
        public string Type { get; set; }
        public string Until { get; set; }
        public string Occurences { get; set; }
        public string Interval { get; set; }
        public string DayOfWeek { get; set; }
        public string DayOfMonth { get; set; }
        public string WeekOfMonth { get; set; }
        public string MonthOfYear { get; set; }
        public string Reminder { get; set; }
        public string Sensitivity { get; set; }
        public string Subject { get; set; }
        public string StartTime { get; set; }
        public string UID { get; set; }
        public string AttendeeStatus { get; set; }
        public string AttendeeType { get; set; }
        public string DisallowNewTimeProposal { get; set; }
        public string ResponseRequested { get; set; }
        public string AppointmentReplyTime { get; set; }
        public string ResponseType { get; set; }
        public string CalendarType { get; set; }
        public string IsLeapMonth { get; set; }
        public string FirstDayOfWeek { get; set; }
        public string OnlineMeetingConfLink { get; set; }
        public string OnlineMeetingExternalLink { get; set; }
    }

    public class Email
    {
        //Code Page 2: Email
        //http://msdn.microsoft.com/en-us/library/ee178095(v=exchg.80).aspx

        public string DateReceived { get; set; }
        public string DisplayTo { get; set; }
        public string Importance { get; set; }
        public string MessageClass { get; set; }
        public string Subject { get; set; }
        public string Read { get; set; }
        public string To { get; set; }
        public string Cc { get; set; }
        public string From { get; set; }
        public string ReplyTo { get; set; }
        public string AllDayEvent { get; set; }
        public string Categories { get; set; }
        public string Category { get; set; }
        public string DtStamp { get; set; }
        public string EndTime { get; set; }
        public string InstanceType { get; set; }
        public string BusyStatus { get; set; }
        public string Location { get; set; }
        public string MeetingRequest { get; set; }
        public string Organizer { get; set; }
        public string RecurrenceId { get; set; }
        public string Reminder { get; set; }
        public string ResponseRequested { get; set; }
        public string Recurrences { get; set; }
        public string Recurrence { get; set; }
        public string Type { get; set; }
        public string Until { get; set; }
        public string Occurences { get; set; }
        public string Interval { get; set; }
        public string DayOfWeek { get; set; }
        public string DayOfMonth { get; set; }
        public string WeekOfMonth { get; set; }
        public string MonthOfYear { get; set; }
        public string StartTime { get; set; }
        public string Sensitivity { get; set; }
        public string TimeZone { get; set; }
        public string GlobalObjId { get; set; }
        public string ThreadTopic { get; set; }
        public string InternetCPID { get; set; }
        public string Flag { get; set; }
        public string Status { get; set; }
        public string ContentClass { get; set; }
        public string FlagType { get; set; }
        public string CompleteTime { get; set; }
        public string DisallowNewTimeProposal { get; set; }
    }

    public class Task
    {
        //Code Page 9: Tasks
        //http://msdn.microsoft.com/en-us/library/ee158068(v=exchg.80).aspx

        public string Categories { get; set; }
        public string Category  { get; set; }
        public string Complete  { get; set; }
        public string DateCompleted  { get; set; }
        public string DueDate  { get; set; }
        public string UTCDueDate  { get; set; }
        public string Importance  { get; set; }
        public string Recurrence  { get; set; }
        public string Type  { get; set; }
        public string Start  { get; set; }
        public string Until  { get; set; }
        public string Occurrences  { get; set; }
        public string Interval  { get; set; }
        public string DayOfMonth  { get; set; }
        public string DayOfWeek  { get; set; }
        public string WeekOfMonth  { get; set; }
        public string MonthOfYear  { get; set; }
        public string Regenerate  { get; set; }
        public string DeadOccur  { get; set; }
        public string ReminderSet  { get; set; }
        public string ReminderTime  { get; set; }
        public string Sensitivity  { get; set; }
        public string StartDate  { get; set; }
        public string UTCStartDate  { get; set; }
        public string Subject  { get; set; }
        public string OrdinalDate  { get; set; }
        public string SubOrdinalDate  { get; set; }
        public string CalendarType { get; set; }
        public string IsLeapMonth { get; set; }
        public string FirstDayOfWeek { get; set; }
    }
   
    public class Note
    {
        //Code Page 23: Notes
        //http://msdn.microsoft.com/en-us/library/ee218292(v=exchg.80).aspx
        
        public string Subject { get; set; }
        public string MessageClass { get; set; }
        public string LastModifiedDate { get; set; }
        public string Categories { get; set; }
        public string Category { get; set; }
    }
}
