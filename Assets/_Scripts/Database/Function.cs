public enum Function
{
    #region Manager

    ReadManagerProfile,
    UpdateManagerProfile,
    ReadManagingSupermarket,
    ReadAllAvailablePromotions,
    //Choose promotion to apply...,
    ReadManagingSupermarketPromotions,
    ReadSupermarketSuppliers,
    ReadSupermarketImportBill,
    ReadGoodsQuantities,
    ReadSavingPointPolicy,
    ReadSupermarketRevenueOfDay,
    ReadSupermarketRevenueOfMonth,
    ReadSupermarketRevenueOfYear,
    CreateSupplier,
    UpdateSupplier,
    DeleteSupplier,
    CreateEmployee,
    UpdateEmployee,
    DeleteEmployee,

    #endregion

    #region Cashier
    
    ReadCashier,
    CreateExportBill,
    CreateImportBill,
    //Add goods to storage...,
    CreateCustomer,
    CreateCustomerCard,
    ReadSupermarketPromotions,
    UpdateCashier,

    #endregion

    #region Customer

    BuyGoods,
    //ReadSavingPointPolicy,
    ReadCustomer,
    UpdateCustomer,
    ReadGoods,
    ReadCustomerExportBills,
    ReadCustomerCard,
    // ReadSupermarketPromotions,
    
    
    
    #endregion
}