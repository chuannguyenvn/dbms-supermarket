public class PolicyManager : PersistentSingleton<PolicyManager>
{
    public const int CUSTOMER_CARD_TYPE_SILVER_REQUIREMENT = 1000;
    public const int CUSTOMER_CARD_TYPE_GOLD_REQUIREMENT = 2000;
    public const int CUSTOMER_CARD_TYPE_VIP_REQUIREMENT = 3000;

    public string GetCustomerCardType(int point)
    {
        if (point < CUSTOMER_CARD_TYPE_SILVER_REQUIREMENT) return "Normal";
        if (point < CUSTOMER_CARD_TYPE_GOLD_REQUIREMENT) return "Silver";
        if (point < CUSTOMER_CARD_TYPE_VIP_REQUIREMENT) return "Gold";
        return "VIP";
    }
}