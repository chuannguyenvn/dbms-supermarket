using System.Collections.Generic;

public class FunctionToQueryMapper
{
    private Dictionary<Function, string> Dictionary = new()
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
        {Function.ReadCustomer, "query"},
        {Function.UpdateCustomer, "query"},
        {Function.ReadGoods, "query"},
        {Function.ReadCustomerExportBills, "query"},
        {Function.ReadCustomerCard, "query"},

        #endregion
    };
}