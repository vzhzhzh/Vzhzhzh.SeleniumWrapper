namespace Vzhzhzh.SeleniumWrapper.Examples.Proprietary.Data
{
    public class Users
    {
        public static LoginInfo MeetingAppointment
        {
            get
            {
                return new LoginInfo("testUserMeetApp", "testUserMeetApp");
            }
        }

        public static LoginInfo CreditAppIncoming
        {
            get
            {
                return new LoginInfo("testUserIncSales", "testUserIncSales");
            }
        }
    }
}