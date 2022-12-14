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
        {Function.ReadSavingPointPolicy, @"query"},
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
        {Function.ReadGoods, @"query"},
        {Function.UpdateGoods, @"query"},
        {Function.DeleteGoods, @"query"},
        {Function.CreateAllCustomerCard, @"query"},
        {Function.ReadAllCustomerCard, @"query"},
        {Function.UpdateAllCustomerCard, @"query"},
        {Function.DeleteAllCustomerCard, @"query"},
        {Function.ReadSupermarketPromotions, @"query"},

        #endregion

        #region Customer

        {Function.BuyGoods, @"query"},
        {Function.ReadCustomerProfile, @"query"},
        {Function.UpdateCustomerProfile, @"query"},
        {Function.ReadCustomerExportBills, @"query"},
        {Function.ReadCustomerCard, @"query"},

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