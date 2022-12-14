using System;
using System.Collections.Generic;
using UnityEngine;

public static class FunctionToQueryMapper
{
    private static readonly Dictionary<Function, string> dictionary = new()
    {
        #region Manager

        {Function.ReadManagerProfile, @"query"},
        {Function.UpdateManagerProfile, @"query"},
        {Function.ReadManagingSupermarket, @"query"},
        {Function.ReadManagingEmployeeProfile, @"query"},
        {Function.ReadManagingEmployeeList, @"query"},
        {Function.CreateManagingAvailablePromotions, @"query"},
        {Function.ReadManagingAvailablePromotions, @"query"},
        {Function.ReadManagingSupermarketSuppliers, @"query"},
        {Function.ReadManagingSupermarketImportBill, @"query"},
        {Function.ReadManagingSupermarketExportBill, @"query"},
        {Function.ReadManagingSupermarketGoodsQuantities, @"query"},
        {Function.ReadSavingPointPolicy, @"SELECT * FROM saving_point_policy;"},
        {Function.ReadManagingSupermarketRevenueOfDay, @"query"},
        {Function.ReadManagingSupermarketRevenueOfMonth, @"query"},
        {Function.ReadManagingSupermarketRevenueOfYear, @"query"},

        #endregion

        #region Cashier

        {Function.ReadCashierProfile, @"query"},
        {Function.UpdateCashierProfile, @"query"},
        {Function.CreateExportBill, @"query"},
        {Function.ReadExportBill, @"query"},
        {Function.UpdateExportBill, @"query"},
        {Function.DeleteExportBill, @"query"},
        {Function.CreateImportBill, @"query"},
        {Function.ReadImportBill, @"query"},
        {Function.UpdateImportBill, @"query"},
        {Function.DeleteImportBill, @"query"},
        {Function.CreateGoods, @"query"},
        {
            Function.ReadGoods, @"
            SELECT brand, Name, Price, Type,  Quantity, Description
            FROM store
            JOIN goods
            ON store.Goods_ID = goods.ID
            WHERE Supermarket_Scode = @Supermarket_Scode"
        },
        {Function.UpdateGoods, @"query"},
        {Function.DeleteGoods, @"query"},
        {Function.CreateAllCustomerCard, @"query"},
        {Function.ReadAllCustomerCard, @"query"},
        {Function.UpdateAllCustomerCard, @"query"},
        {Function.DeleteAllCustomerCard, @"query"},
        {
            Function.ReadSupermarketPromotions, @"
            SELECT Supermarket_Scode, Sale_promo_ID, Start_date, End_date, Name, Discount_rate, Customer_Type, Cost_Threshold
            FROM (offer JOIN sales_promotion ON Sale_promo_ID = sales_promotion.ID)
            JOIN sales_promotion_condition
            ON Sale_promo_ID = sales_promotion_condition.ID
            WHERE Supermarket_Scode = @Supermarket_Scode"
        },

        #endregion

        #region Customer

        {Function.BuyGoods, @"query"},
        {
            Function.ReadCustomerProfile, @"
            SELECT * 
            FROM customer 
            WHERE ID = @ID;"
        },
        {
            Function.UpdateCustomerProfile, @"
            UPDATE customer
            SET First_name = @First_name, Last_name = @Last_name, Gender = @Gender, Address = @Address, Phone_number = @Phone_number, Date_of_birth = @Date_of_birth, Type = @Type
            WHERE ID = @ID;"
        },
        {
            Function.ReadCustomerExportBills, @"
            SELECT export_bill.ID as Bill_ID, export_bill.Date, export_bill.Name, export_bill.Cashier_ID, export_bill.Customer_ID, export_bill.Saving_point_policy_ID, bill_has_goods.Goods_ID, Brand, goods.Name as Goods_Name, goods.Type, goods.Price, bill_has_goods.Quantity, bill_has_goods.Total_cost, goods.Description
            FROM (bill_has_goods JOIN goods ON Goods_ID = goods.ID)
            JOIN export_bill
            ON export_bill.ID = bill_has_goods.Export_Bill_ID
            WHERE Customer_ID = @Customer_ID"
        },
        {
            Function.ReadCustomerCard, @"
            SELECT Customer_ID, Issue_date, Saving_point
            FROM customer_card
            WHERE Customer_ID = @Customer_ID"
        },

        #endregion

        #region Admin

        {Function.CreateAllManagerProfile, @"query"},
        {Function.ReadAllManagerProfile, @"query"},
        {Function.UpdateAllManagerProfile, @"query"},
        {Function.DeleteAllManagerProfile, @"query"},
        {Function.CreateAllCashierProfile, @"query"},
        {Function.ReadAllCashierProfile, @"query"},
        {Function.UpdateAllCashierProfile, @"query"},
        {Function.DeleteAllCashierProfile, @"query"},
        {Function.CreateAllCustomerProfile, @"query"},
        {Function.ReadAllCustomerProfile, @"query"},
        {Function.UpdateAllCustomerProfile, @"query"},
        {Function.DeleteAllCustomerProfile, @"query"},
        {Function.CreateAllSupermarketInformation, @"query"},
        {Function.ReadAllSupermarketInformation, @"query"},
        {Function.UpdateAllSupermarketInformation, @"query"},
        {Function.DeleteAllSupermarketInformation, @"query"},
        {Function.ReadAllEmployeeList, @"query"},
        {Function.AssignManagerToSupermarket, @"query"},
        {Function.CreateAllSupplierList, @"query"},
        {Function.ReadAllSupplierList, @"query"},
        {Function.UpdateAllSupplierList, @"query"},
        {Function.DeleteAllSupplierList, @"query"},
        {Function.ReadAllSupermarketRevenueOfDay, @"query"},
        {Function.ReadAllSupermarketRevenueOfMonth, @"query"},
        {Function.ReadAllSupermarketRevenueOfYear, @"query"},
        {Function.ReadAllGoods, @"query"},
        {Function.ReadAllImportBill, @"query"},
        {Function.ReadAllExportBill, @"query"},
        {Function.UpdateSavingPointPolicy, @"query"},
        {Function.ReadAllAvailablePromotions, @"query"},

        #endregion
    };

    public static string GetQuery(Function function)
    {
        try
        {
            return dictionary[function];
        }
        catch
        {
            Debug.Log("Function " + function + " not implemented.");
            throw;
        }
    }
}