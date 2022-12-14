using System;
using System.Collections.Generic;
using UnityEngine;

public static class FunctionToQueryMapper
{
    private static readonly Dictionary<Function, string> dictionary = new()
    {
        #region Manager

        {Function.ReadManagerProfile, @"select * from employee where role = 'Manager' AND ID = @ID;"},
        {Function.UpdateManagerProfile, @"update employee set First_name = @First_name, Last_name = @Last_name, Start_date = @Start_date, Phone_number = @Phone_number, Address = @Address, Salary = @Salary, Role = @Role, Gender = @Gender, Date_of_birth = @Date_of_birth, Supermarket_Scode = @Supermarket_Scode where role = 'Manager' AND ID = @ID;"},
        {Function.ReadManagingSupermarket, @"
            select s.SCode, s.Name, s.Location, s.Number_of_employees
            from supermarket as s, employee as e
            where e.Role = 'Manager' and e.Supermarket_SCode = s.SCode and e.ID = @ID;"},
        {Function.ReadManagingEmployeeProfile, @"
            select e.ID, e.Phone_number, e.Address, e.First_name, e.Last_name, e.Start_date, e.Salary, e.Role, e.Gender, e.Date_of_birth, e.Supermarket_Scode
            from employee as e, employee as m
            where e.Role = 'Cashier' AND m.Role = 'Manager' AND e.Supermarket_SCode = m.Supermarket_Scode AND m.ID = @ID AND e.ID = @Employee_ID;"},
        {Function.ReadManagingEmployeeList, @"
            select e.ID, e.Phone_number, e.Address, e.First_name, e.Last_name, e.Start_date, e.Salary, e.Role, e.Gender, e.Date_of_birth, e.Supermarket_Scode
            from employee as e, employee as m
            where e.Role = 'Cashier' AND m.Role = 'Manager' AND e.Supermarket_SCode = m.Supermarket_Scode AND m.ID = @ID;"},
        {Function.CreateManagingAvailablePromotions, @"query"},
        {Function.ReadManagingAvailablePromotions, @"
            select sp.ID, sp.Name
            from offer as o, employee as e, sales_promotion as sp
            where e.Role = 'Manager' AND e.ID = @ID AND e.Supermarket_Scode = o.Supermarket_Scode AND o.Sale_promo_ID = sp.ID"},
        {Function.ReadManagingSupermarketSuppliers, @"
            select sup.ID, sup.Name, sup.Location, sup.Email_address, sup.Phone_number, gds.Name
            from employee as e, supermarket as s, import_bill as ib, supplier as sup, import_goods as ig, goods as gds
            where e.Role = 'Manager' AND e.ID = @ID AND e.Supermarket_Scode = s.SCode AND s.SCode = ib.Supermarket_Scode AND ib.Supplier_ID = sup.ID AND ig.Import_Bill_ID = ib.ID AND ig.Goods_ID = gds.ID;"},
        {Function.ReadManagingSupermarketImportBill, @"
            select ib.ID, ib.Name, ib.Date, sup.ID, sup.Name, ig.Goods_ID, gd.Name, ig.Quantity, ig.Total_cost
            from employee as e, supermarket as s, import_bill as ib, supplier as sup, import_goods as ig, goods as gd 
            where e.Role = 'Manager' AND e.ID = @ID AND e.Supermarket_Scode = s.SCode AND s.SCode = ib.Supermarket_Scode AND ib.ID = ig.Import_Bill_ID AND ig.Goods_ID = gd.ID AND ib.Supplier_ID = sup.ID;"},
        {Function.ReadManagingSupermarketExportBill, @"
            select eb.ID, eb.Name, eb.Date, eb.Customer_ID, c.First_name, c.Last_name, g.ID, g.Name, bhg.Quantity, bhg.Total_cost
            from employee as e, employee as m, export_bill as eb, customer as c, goods as g, bill_has_goods as bhg
            where m.Role = 'Manager' AND e.Supermarket_Scode = m.Supermarket_Scode AND m.ID = @ID AND e.ID = eb.Cashier_ID AND eb.Customer_ID = c.ID AND bhg.Export_Bill_ID = eb.ID AND bhg.Goods_ID = g.ID;"},
        {Function.ReadManagingSupermarketGoodsQuantities, @"
            select eb.ID, eb.Name, eb.Date, eb.Customer_ID, c.First_name, c.Last_name, g.ID, g.Name, bhg.Quantity, bhg.Total_cost
            from employee as e, employee as m, export_bill as eb, customer as c, goods as g, bill_has_goods as bhg
            where m.Role = 'Manager' AND e.Supermarket_Scode = m.Supermarket_Scode AND m.ID = @ID AND e.ID = eb.Cashier_ID AND eb.Customer_ID = c.ID AND bhg.Export_Bill_ID = eb.ID AND bhg.Goods_ID = g.ID;"},
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
        {Function.ReadGoods, @"
            SELECT brand, Name, Price, Type,  Quantity, Description
            FROM store
            JOIN goods
            ON store.Goods_ID = goods.ID
            WHERE Supermarket_Scode = @Supermarket_Scode"},
        {Function.UpdateGoods, @"query"},
        {Function.DeleteGoods, @"query"},
        {Function.CreateAllCustomerCard, @"query"},
        {Function.ReadAllCustomerCard, @"query"},
        {Function.UpdateAllCustomerCard, @"query"},
        {Function.DeleteAllCustomerCard, @"query"},
        {Function.ReadSupermarketPromotions, @"
            SELECT Supermarket_Scode, Sale_promo_ID, Start_date, End_date, Name, Discount_rate, Customer_Type, Cost_Threshold
            FROM (offer JOIN sales_promotion ON Sale_promo_ID = sales_promotion.ID)
            JOIN sales_promotion_condition
            ON Sale_promo_ID = sales_promotion_condition.ID
            WHERE Supermarket_Scode = @Supermarket_Scode"},

        #endregion

        #region Customer

        {Function.BuyGoods, @"query"},

        {Function.ReadCustomerProfile, @"query"},

        {Function.UpdateCustomerProfile, @"
            UPDATE customer
            SET First_name = @First_name, Last_name = @Last_name, Gender = @Gender, Address = @Address, Phone_number = @Phone_number, Date_of_birth = @Date_of_birth, Type = @Type
            WHERE ID = @ID;"},

        {Function.ReadCustomerExportBills, @"
            SELECT export_bill.ID as Bill_ID, export_bill.Date, export_bill.Name, export_bill.Cashier_ID, export_bill.Customer_ID, export_bill.Saving_point_policy_ID, bill_has_goods.Goods_ID, Brand, goods.Name as Goods_Name, goods.Type, goods.Price, bill_has_goods.Quantity, bill_has_goods.Total_cost, goods.Description
            FROM (bill_has_goods JOIN goods ON Goods_ID = goods.ID)
            JOIN export_bill
            ON export_bill.ID = bill_has_goods.Export_Bill_ID
            WHERE Customer_ID = @Customer_ID"},

        {Function.ReadCustomerCard, @"
            SELECT Customer_ID, Issue_date, Saving_point
            FROM customer_card
            WHERE Customer_ID = @Customer_ID"},

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