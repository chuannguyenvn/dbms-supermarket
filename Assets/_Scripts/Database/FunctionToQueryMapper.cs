using System;
using System.Collections.Generic;
using UnityEngine;

public static class FunctionToQueryMapper
{
    private static readonly Dictionary<Function, string> dictionary = new()
    {
        #region Manager

        {Function.ReadManagerProfile, "query"},
        {Function.UpdateManagerProfile, "query"},
        {Function.ReadManagingSupermarket, "query"},
        {Function.ReadAllAvailablePromotions, "query"},
        // {Function.Choose promotion to apply..., "query},
        {Function.ReadManagingSupermarketPromotions, "query"},
        {Function.ReadSupermarketSuppliers, "query"},
        {Function.ReadSupermarketImportBill, "query"},
        {Function.ReadGoodsQuantities, "query"},
        {Function.ReadSavingPointPolicy, "query"},
        {Function.ReadSupermarketRevenueOfDay, "query"},
        {Function.ReadSupermarketRevenueOfMonth, "query"},
        {Function.ReadSupermarketRevenueOfYear, "query"},
        {Function.CreateSupplier, "query"},
        {Function.UpdateSupplier, "query"},
        {Function.DeleteSupplier, "query"},
        {Function.CreateEmployee, "query"},
        {Function.UpdateEmployee, "query"},
        {Function.DeleteEmployee, "query"},

        #endregion

        #region Cashier

        {Function.ReadCashier, "query"},
        {Function.CreateExportBill, "query"},
        {Function.CreateImportBill, "query"},
        // {Function.Add goods to storage..., "query"},
        {Function.CreateCustomer, "query"},
        {Function.CreateCustomerCard, "query"},
        {Function.ReadSupermarketPromotions, "query"},
        {Function.UpdateCashier, "query"},

        #endregion

        #region Customer

        {Function.BuyGoods, "query"},
        // {Function.ReadSavingPointPolicy, "query"},
        {Function.ReadCustomer, "SELECT * FROM customer WHERE id = @id"},
        {Function.UpdateCustomer, "query"},
        {Function.ReadGoods, "SELECT * FROM goods"},
        {Function.ReadCustomerExportBills, "query"},
        {Function.ReadCustomerCard, "query"},

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