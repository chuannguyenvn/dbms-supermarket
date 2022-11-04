using System;

public static class ProductUtility
{
    public static string FormatVNDPrice(int price)
    {
        return String.Format("{0:n0}", price) + "đ";
    }
}