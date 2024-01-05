namespace Coffee.Domain.IdentityModels
{
    public enum AppUserState
    {
        Available = 1, 
        Busy,
        BeRightBack,
        HourlyLeave,
        DailyLeave,
        AnnualLeave,
        BusinessTrip,
        Meeting
    }
}