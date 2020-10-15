namespace SIGO.Utils
{
    public static class Configuration
    {
        public class Keys
        {
            public static string EventBusConnection = nameof(EventBusConnection);
            public static string EventBusUserName = nameof(EventBusUserName);
            public static string EventBusPassword = nameof(EventBusPassword);
            public static string EventBusRetryCount = nameof(EventBusRetryCount);
            public static string SubscriptionClientName = nameof(SubscriptionClientName);
            public static string SimuladorESBMuleURI = nameof(SimuladorESBMuleURI);
        }

        public class LogContextUtils
        {
            public static string IntegrationEventContext = nameof(IntegrationEventContext);
        }
    }
}
